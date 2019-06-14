using Grpc.Core;
using Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using static Messages.PDFBoxService;

namespace SaleFinder.Serv
{
    class Program
    {
        static void Main(string[] args)
        {
            const int port = 9000;
            //var cacert = File.ReadAllText("ca.crt");
            //var cert = File.ReadAllText("server.crt");
            //var key = File.ReadAllText("server.key");
            //var keyPair = new KeyCertificatePair(cert, key);
            //var sslCredentials = new SslServerCredentials(new List<KeyCertificatePair>() {
            //        keyPair
            //}, cacert, false);

            //Server server = new Server()
            //{
            //    Ports = { new ServerPort("127.0.0.1", port, SslServerCredentials.Insecure) },
            //    Services = { BindService(new TestService()) }
            //};
            //server.Start();
            //Console.WriteLine("Server started");
            //Console.ReadKey();
        }
    }
    //class TestService : PDFBoxServiceBase
    //{
    //    public override Task<PongResponse> Pi ng(PongRequest request, ServerCallContext context)
    //    {
    //        Console.WriteLine("ping");
    //        Metadata entries = context.RequestHeaders;

    //        foreach (var entry in entries)
    //        {
    //            Console.WriteLine("key : " + entry.Key + " value: " + entry.Value);
    //        }

    //        return Task.FromResult(new PongResponse());
    //    }
    //    public override Task<PDFExportResponse> InportExport(PDFExportRequest request, ServerCallContext context)
    //    {
    //        Metadata entries = context.RequestHeaders;

    //        foreach(var entry in entries)
    //        {
    //            Console.WriteLine("key : " + entry.Key + " value: " + entry.Value);
    //        }

    //        return Task.FromResult(new PDFExportResponse());
    //    }
    //}
}
