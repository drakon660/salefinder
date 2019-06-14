using SaleFinder.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using Grpc.Core;
using Messages;
using Google.Protobuf;
using SaleFinder.Domain;
using System.Text.RegularExpressions;

namespace SaleFinder.LeafletProcessors
{
    public class KauflandProcessor : LeafletProcessor
    {
        const string GROUPNAME = "Kaufland";
        private string _linkKWPart = "";
        private const string _linkPattern = "https://media.kaufland.com/leaflets/pl/KW{0}_1860/blaetterkatalog/blaetterkatalog/pdf/complete.pdf";
        private string _completeLink = "";

        public KauflandProcessor() : base()
        {
           
        }

        private string PrepareLink(int weekNumber)
        {
            _linkKWPart = weekNumber.ToString().PadLeft(2, '0');
            return string.Format(_linkPattern, _linkKWPart);
        }


        private string PrepareLink(string weekNumber)
        {
            _linkKWPart = weekNumber;
            return string.Format(_linkPattern, _linkKWPart);
        }

        protected override void FindLinksToDownload()
        {
            int weekNumber = GetWeekNumber<int>();

            int previousWeekNumber = weekNumber - 1;
            var previousLeaflet = new PDFLeaflet
            {
                GroupName = GROUPNAME,
                FileDownloadUrl = PrepareLink(previousWeekNumber)
            };

            previousLeaflet.Values.Add("week", previousWeekNumber);

            _leaflets.Add(previousLeaflet);

            var leaflet = new PDFLeaflet
            {
                GroupName = GROUPNAME,
                FileDownloadUrl = PrepareLink(weekNumber)
            };

            leaflet.Values.Add("week", weekNumber);

            _leaflets.Add(leaflet);

            int nextWeekNumber = weekNumber + 1;
            var nextleaflet = new PDFLeaflet
            {
                GroupName = GROUPNAME,
                FileDownloadUrl = PrepareLink(nextWeekNumber)
            };

            nextleaflet.Values.Add("week", nextWeekNumber);

            _leaflets.Add(nextleaflet);
        }

        protected override string PrepareDownloadFileName(ILeaflet leaflet)
        {
            int week = (int)leaflet.Values["week"];
            string weekPart = week.ToString().PadLeft(2, '0');
            return $"{weekPart}_Kaufland_{DateTime.Now.ToString("yyyyMMddhhmmss")}.pdf";
        }

        private T GetWeekNumber<T>()
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            if (typeof(T) == typeof(string))
            {
                return (T)(object)weekNum.ToString().PadLeft(2, '0');
            }
            else if (typeof(T) == typeof(int))
            {
                return (T)(object)weekNum;
            }
            else
            {
                throw new NotImplementedException("<T> can be only string or int");
            }
        }

        protected override void InitLeaflets()
        {
            _leaflets = new List<ILeaflet>();
        }

        protected override void ValidateExistingFiles()
        {
            var kauflandFiles = new DirectoryInfo(_tempFolder).GetFiles().Where(x => x.FullName.Contains(GROUPNAME)).ToList();

            List<int> weeks = Enumerable.Range(GetWeekNumber<int> () - 1, 3).ToList();

            foreach (var kauflandFile in kauflandFiles)
            {
                string prefix = kauflandFile.Name.Split("_")[0];
                int week = int.Parse(prefix);

                if (weeks.Contains(week))
                {
                    var exitingOne =_leaflets.Where(x => (int)x.Values["week"] == week).First();
                    exitingOne.DownloadedFileName = kauflandFile.Name;
                    exitingOne.Status = LeafletStatus.Omit;
                }
            }

        }
        protected override void GetText()
        {
            try
            {
                PongResponse pingResponse = _pdfBoxServiceClient.Ping(new PingRequest { Message = GROUPNAME });

                //SaleFinderDb.DeleteLeaflets(GROUPNAME);

                foreach (var leaflet in _leaflets)
                {
                    string fullFileName = Path.Combine(_tempFolder, leaflet.DownloadedFileName);
                    LeafletModel leafletModel = new LeafletModel
                    {
                        FileName = leaflet.DownloadedFileName,
                        GroupName = GROUPNAME,
                        Hash = leaflet.MD5,
                        Status = LeafletModelStatus.Processed,
                        Pages = new List<LeafletPageModel>()
                    };
                    bool saleDateFound = false;
                    var response = _pdfBoxServiceClient.PdfPagesCount(new Messages.PDFInfoMessage { FileName = fullFileName });
                    for (int i = 0; i < response.PagesCount; i++)
                    {
                        byte[] fileContent = File.ReadAllBytes(leaflet.DownloadedFileName);

                        var exportMessage = _pdfBoxServiceClient.ImportExport(new PDFExportRequest
                        {
                            PDFInputMessage = new PDFInputMessage
                            {
                                FileName = fullFileName,
                                Pagenr = i
                            }
                        });

                        LeafletPageModel leafletPageModel = new LeafletPageModel
                        {
                            PageNumber = i + 1,
                            Text = exportMessage.PDFOutputMessage.Text
                        };

                        if (!saleDateFound)
                        {
                            Regex rgx = new Regex(@"\d{2}.\d{2}.\d{4}");
                            Match mat = rgx.Match(leafletPageModel.Text);
                            if (mat.Success)
                            {

                            }
                        }
                        //string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(leaflet.DownloadedFileName);
                        //string textFileName = $"{fileNameWithoutExtension}_{i}.txt";

                        //File.WriteAllText(textFileName, exportMessage.PDFOutputMessage.Text);
                        leafletModel.Pages.Add(leafletPageModel);
                    }
                    SaleFinderDb.AddLeaflet(leafletModel);
                }
            }
            catch (RpcException e)
            {

            }
        }

        protected override void SearchInFiles()
        {
            var leaflets = SaleFinderDb.FindInLeaflet(GROUPNAME, new string[] { "PEPSI" });

        }
    }
}
