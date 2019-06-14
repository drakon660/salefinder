using Grpc.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using static Messages.PDFBoxService;

namespace SaleFinder.Base
{
    public abstract class LeafletProcessor
    {
        private readonly System.Net.WebClient _client;
        protected IList<ILeaflet> _leaflets;
        protected ILeaflet _currentLeaflet;
        protected string _tempFolder;
        protected readonly PDFBoxServiceClient _pdfBoxServiceClient;

        protected abstract void FindLinksToDownload();
        protected abstract string PrepareDownloadFileName(ILeaflet leaflet);
        protected abstract void InitLeaflets();

        public LeafletProcessor()
        {
            _tempFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var channel = new Channel("localhost", 9000, SslCredentials.Insecure);
            _pdfBoxServiceClient = new PDFBoxServiceClient(channel);

            _client = new System.Net.WebClient();
            //_client.DownloadProgressChanged += (s, e) =>
            //{
            //    Console.WriteLine(e.ProgressPercentage);
            //};
        }

        protected IDictionary<HttpStatusCode, Action<ILeaflet>> _downloadStrategiesAfterError = new Dictionary<HttpStatusCode, Action<ILeaflet>>();


        protected virtual void DownloadLeaflet(ILeaflet leaflet)
        {
            try
            {
                if (leaflet.Status == LeafletStatus.Ready)
                {

                    

                    string downloadedFileName = PrepareDownloadFileName(leaflet);

                    _client.DownloadFile(new Uri(leaflet.FileDownloadUrl), downloadedFileName);

                    leaflet.DownloadedFileName = downloadedFileName;
                }
            }
            catch (WebException e)
            {
                HttpWebResponse response = (HttpWebResponse)e.Response;
                leaflet.Status = LeafletStatus.StopProcessing;
                Console.WriteLine("Error downloading file");
            }
            catch (Exception e)
            {
                leaflet.Status = LeafletStatus.StopProcessing;
                Console.WriteLine("Global Error");
            }
        }

        protected virtual void DownloadLeaflets()
        {
            foreach (var leaflet in _leaflets)
            {
                _currentLeaflet = leaflet;
                DownloadLeaflet(_currentLeaflet);
            }
        }

        protected virtual void GetText()
        {

        }

        protected virtual void ValidateExistingFiles()
        {

        }

        public virtual void Run()
        {
            InitLeaflets();
            FindLinksToDownload();
            ValidateExistingFiles();
            DownloadLeaflets();
            //GenMD5();
            GetText();
            SearchInFiles();
        }

        protected virtual void GenMD5()
        {
            foreach (var leaflet in _leaflets)
            {
                if (leaflet.Status != LeafletStatus.Omit || leaflet.Status != LeafletStatus.StopProcessing)
                {
                    string md5 = CalculateMD5(leaflet.DownloadedFileName);
                    leaflet.MD5 = md5;
                }
            }
        }

        public virtual string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        protected virtual void SearchInFiles()
        {

        }
    }
}
