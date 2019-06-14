package com.salefinder;

import io.grpc.*;

public class PDFBoxServer {
    private Server server;
    public void start() throws Exception
    {
        PDFBoxService service = new PDFBoxService();
        ServerServiceDefinition serviceDefinition = ServerInterceptors.interceptForward(service,
                new HeaderServerInterceptor());

        server = ServerBuilder.forPort(9000).addService(serviceDefinition).build().start();

        System.out.println("Server started");

        Runtime.getRuntime().addShutdownHook(new Thread() {
            @Override
            public void run() {
                System.out.println("Shutting down server");
                PDFBoxServer.this.stop();
            }
        });

        server.awaitTermination();
    }
    private void stop()
    {
        if(server!=null)
            server.shutdown();
    }
}
