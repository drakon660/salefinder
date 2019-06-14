package com.salefinder;

import io.grpc.stub.StreamObserver;

import java.io.IOException;

public class PDFBoxService extends PDFBoxServiceGrpc.PDFBoxServiceImplBase {


    @Override
    public void ping(com.salefinder.Messages.PingRequest request,
                     io.grpc.stub.StreamObserver<com.salefinder.Messages.PongResponse> responseObserver)
    {
        System.out.println("pong");



        Messages.PongResponse response = Messages.PongResponse.newBuilder().setMessage("pong").build();
        responseObserver.onNext(response);
        responseObserver.onCompleted();

    }

  @Override
  public void pdfPagesCount(Messages.PDFInfoMessage request,
                            StreamObserver<Messages.PDFInfoMessage> responseObserver) {

      System.out.println("pdfPagesCount");
       String fileName =  request.getFileName();

       try {
           PDFProcessor processor = new PDFProcessor(fileName);
           int pageCount = processor.pageCount();
           Messages.PDFInfoMessage message =  Messages.PDFInfoMessage.newBuilder().setPagesCount(pageCount).build();
           responseObserver.onNext(message);
           responseObserver.onCompleted();
       }
       catch(IOException e)
       {
           System.out.println(e.getMessage());
           responseObserver.onNext(null);
           responseObserver.onCompleted();
       }
  }

    @Override
    public void importExport(Messages.PDFExportRequest request, StreamObserver<Messages.PDFExportResponse> responseObserver) {

        System.out.println("importExport");

        Messages.PDFInputMessage requestMessage = request.getPDFInputMessage();
        String fileName = requestMessage.getFileName();
        Integer pageNr = requestMessage.getPagenr();
        try {
            PDFProcessor processor = new PDFProcessor(fileName);

            String text = processor.readTextFromPage(pageNr+1);
            processor.closeDocument();

            //System.out.println(text);
            System.out.println("Text from page read");

            Messages.PDFOutputMessage outputMessage = Messages.PDFOutputMessage.newBuilder()
                    .setText(text)
                    .setPagenr(pageNr)
                    .build();

            Messages.PDFExportResponse exportResponse = Messages.PDFExportResponse
                    .newBuilder().setPDFOutputMessage(outputMessage).build();

            System.out.println("sending message");
            responseObserver.onNext(exportResponse);
            responseObserver.onCompleted();
        }
        catch (IOException e)
        {
            System.out.println(e.getMessage());
            responseObserver.onNext(null);
            responseObserver.onCompleted();
        }
    }
}
