using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Globalization;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Grpc.Core;
using static Messages.PDFBoxService;
using Google.Protobuf;
using SaleFinder.Base;
using SaleFinder.LeafletProcessors;
using SaleFinder.Domain;
using System.Text.RegularExpressions;

namespace SaleFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            const int Port = 9000;

            var channel = new Channel("localhost", 9000, SslCredentials.Insecure);
            var pdfBoxServiceClient = new PDFBoxServiceClient(channel);
           

            while (pdfBoxServiceClient.Chat().RequestStream.WriteAsync().)
            {
                var note = requestStream.Current;
                List<RouteNote> prevNotes = AddNoteForLocation(note.Location, note);
                foreach (var prevNote in prevNotes)
                {
                    await responseStream.WriteAsync(prevNote);
                }
            }


            //SaleFinderDb.InitDatabase();
            //string testDate = File.ReadAllText(@"D:\src\SaleFinder\SaleFinder\bin\Debug\netcoreapp2.2\07_Kaufland_20190218093710_0.txt");
            //string testDate = "3214312402-17-2013143214214";
            //Regex rgx = new Regex(@"\d{2}.\d{2}.\d{4}");
            //Match mat = rgx.Match(testDate);

            //SaleFinderDb.DeleteLeaflets("Kaufland");

            //SaleDb.AddLeaflet(new LeafletModel { });

            //SaleFinderDb.InitDatabase();

            //SaleFinderDb.AddLeaflet(new LeafletModel
            //{
            //    GroupName = "Kaufland",
            //    Pages = new List<LeafletPageModel>()
            //    {
            //       new LeafletPageModel { PageNumber = 1, Text = "to szklarnia jest" }
            //    }
            //});

            //var result = SaleFinderDb.FindInLeaflet("Kaufland", new string[] { "szklarnia" });
            //string t = "";
            //LeafletProcessor processor = new KauflandProcessor();
            //processor.Run();
            //var leaflets = SaleFinderDb.FindInLeaflet("Kaufland", new string[] { "Milka", "MILKA","milka" });
            //var cacert = File.ReadAllText(@"ca.crt");
            //var cert = File.ReadAllText(@"client.crt");
            //var key = File.ReadAllText(@"client.key");
            //var keypair = new KeyCertificatePair(cert, key);
            //SslCredentials creds = new SslCredentials(cacert, keypair);
            //var channel = new Channel("localhost", Port, SslCredentials.Insecure);
            //var pdfServiceClient = new PDFBoxServiceClient(channel);

            //var metadata = new Metadata
            //{
            //    new Metadata.Entry("Bedziemy", "miec deveopsa?")
            //};

            //var res1 = pdfServiceClient.PdfPagesCount(new Messages.PDFInfoMessage { FileName = "d:/gazetka.pdf" });
            //var count = res1.PagesCount;

            //var response = pdfServiceClient.ImportExport(new Messages.PDFExportRequest { PDFInputMessage = new Messages.PDFInputMessage {
            //    FileName = "d:/gazetka.pdf",
            //    Pagenr = 1
            //} });

            //var message = response.PDFOutputMessage;

            //pdfServiceClient.Ping(new Messages.PongRequest { }, headers:metadata);
            //pdfServiceClient.InportExport(new Messages.PDFExportRequest
            //{
            //    PDFInputMessage
            //    = new Messages.PDFInputMessage { FileName = "1.pdf", FileContent = ByteString.CopyFromUtf8("nudy") }
            //});

            //var client = new EmployeeServiceClient(channel);

            //string value = new KauflandProcessor().CalculateMD5("cef_sandbox.lib");
            //string value1 = new KauflandProcessor().CalculateMD5("cef_sandbox.lib");
            //int wwekYear = GetWeekNumber();
            //KauflandProcessor leafletDownloader = new KauflandProcessor();
            //leafletDownloader.Run();
            //string aldiUrl = "https://www.aldi.pl/gazetki.html";
            //string kauflandUrl = "https://www.promoceny.pl/gazetka/biedronka-20190128/p/1/";
            //CefBrowserHost.CreateBrowser(cefWindowInfo, cefClient, cefBrowserSettings, url);
            //var web = new HtmlWeb();
            //var doc = web.Load(kauflandUrl);

            //var links = ExtractAllAHrefTags(doc);


            //WebClient client = new WebClient();
            //var content = client.DownloadString("https://www.promoceny.pl/gazetka/biedronka-20190128/p/1/");

            /////var divs = doc.DocumentNode.SelectNodes("//div[contains(@class,'leaflet-browser')]");

            //var img2 = doc.DocumentNode.Descendants("img").ToList();

            //// var images = tag.SelectNodes("//img");

            //var images1 = doc.DocumentNode.SelectNodes("//img").Select(x=>x.Attributes.Select(y=>y.Value)).ToList();
            //foreach(var temp in images1)
            //{
            //    foreach(var item in temp.ToList())
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
            //foreach(var img in images1)
            //{
            //    var attributes = img.Attributes.ToList();
            //    var altAttribute = attributes.Where(x => x.Name == "alt").FirstOrDefault();
            //    if(altAttribute?.Value.IndexOf("biedronka",0, StringComparison.OrdinalIgnoreCase) > 0)
            //    {
            //        var biedronka = "";
            //    }
            //}

            //var img = images1.Where(x => x.Attributes.Where(attr => attr.Value.Contains("Biedronka")).Count() > 0);

            //var pdfs = links.Where(link => link.Contains("pdf")).ToList();

            //foreach(var pdfLink in pdfs)            
            //{
            //    WebClient downloader = new WebClient();
            //    string fullPath = "https://www.aldi.pl" + pdfLink;
            //    string downloadFileName = System.IO.Path.GetFileName(fullPath);

            //    downloader.DownloadFile(fullPath, downloadFileName);                
            //}

            //var text = ExportTextFromPdf2("KW_04_FIN_WEB.pdf");

            //var parser = new PDFParser();
            //parser.ExtractText("KW_04_FIN_WEB.pdf", "1.txt");

            //var text = ExportTextFromPdf("gazetka_V3_BIO_ALL_FIN.pdf"); 

            //Console.WriteLine("Hello World!");
            //CefRuntime.Shutdown();
        }
       
        public static HtmlNode GetTagsWithClass(HtmlDocument htmlDocument, List<string> @class)
        {
            // LoadHtml(html);           
            var result = htmlDocument.DocumentNode.Descendants()
                .Where(x => x.Attributes.Contains("class") && @class.Contains(x.Attributes["class"].Value)).ToList();
            return result.FirstOrDefault();
        }

        private static List<string> ExtractAllAHrefTags(HtmlDocument htmlSnippet)
        {
            List<string> hrefTags = new List<string>();

            foreach (HtmlNode link in htmlSnippet.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];
                hrefTags.Add(att.Value);
            }

            return hrefTags;
        }
    }

  

    public interface ILeaflet
    {
        string GroupName { get; set; }
        string MD5 { get; set; }
        string FileDownloadUrl { get; set; }
        string DownloadedFileName { get; set; }
        string FileName { get; }
        LeafletStatus Status { get; set; }

        IDictionary<string,object> Values { get; }
    }

    public enum LeafletStatus
    {
        Ready,
        Omit,
        StopProcessing
    }

    public class PDFLeaflet : ILeaflet
    {
        public string GroupName { get; set; }
        public string MD5 { get; set; }
        public string FileDownloadUrl { get; set; }
        public string DownloadedFileName { get; set; }
        public string FileName { get { return Path.GetFileName(DownloadedFileName); } }
        public LeafletStatus Status { get; set; } = LeafletStatus.Ready;
        public IDictionary<string, object> Values { get; } = new Dictionary<string, object>();
    }
}

   

