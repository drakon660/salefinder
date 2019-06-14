package com.salefinder;

import static io.grpc.MethodDescriptor.generateFullMethodName;
import static io.grpc.stub.ClientCalls.asyncBidiStreamingCall;
import static io.grpc.stub.ClientCalls.asyncClientStreamingCall;
import static io.grpc.stub.ClientCalls.asyncServerStreamingCall;
import static io.grpc.stub.ClientCalls.asyncUnaryCall;
import static io.grpc.stub.ClientCalls.blockingServerStreamingCall;
import static io.grpc.stub.ClientCalls.blockingUnaryCall;
import static io.grpc.stub.ClientCalls.futureUnaryCall;
import static io.grpc.stub.ServerCalls.asyncBidiStreamingCall;
import static io.grpc.stub.ServerCalls.asyncClientStreamingCall;
import static io.grpc.stub.ServerCalls.asyncServerStreamingCall;
import static io.grpc.stub.ServerCalls.asyncUnaryCall;
import static io.grpc.stub.ServerCalls.asyncUnimplementedStreamingCall;
import static io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall;

/**
 */
@javax.annotation.Generated(
    value = "by gRPC proto compiler (version 1.18.0)",
    comments = "Source: messages.proto")
public final class PDFBoxServiceGrpc {

  private PDFBoxServiceGrpc() {}

  public static final String SERVICE_NAME = "PDFBoxService";

  // Static method descriptors that strictly reflect the proto.
  private static volatile io.grpc.MethodDescriptor<com.salefinder.Messages.PDFInfoMessage,
      com.salefinder.Messages.PDFInfoMessage> getPdfPagesCountMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "PdfPagesCount",
      requestType = com.salefinder.Messages.PDFInfoMessage.class,
      responseType = com.salefinder.Messages.PDFInfoMessage.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<com.salefinder.Messages.PDFInfoMessage,
      com.salefinder.Messages.PDFInfoMessage> getPdfPagesCountMethod() {
    io.grpc.MethodDescriptor<com.salefinder.Messages.PDFInfoMessage, com.salefinder.Messages.PDFInfoMessage> getPdfPagesCountMethod;
    if ((getPdfPagesCountMethod = PDFBoxServiceGrpc.getPdfPagesCountMethod) == null) {
      synchronized (PDFBoxServiceGrpc.class) {
        if ((getPdfPagesCountMethod = PDFBoxServiceGrpc.getPdfPagesCountMethod) == null) {
          PDFBoxServiceGrpc.getPdfPagesCountMethod = getPdfPagesCountMethod = 
              io.grpc.MethodDescriptor.<com.salefinder.Messages.PDFInfoMessage, com.salefinder.Messages.PDFInfoMessage>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(
                  "PDFBoxService", "PdfPagesCount"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  com.salefinder.Messages.PDFInfoMessage.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  com.salefinder.Messages.PDFInfoMessage.getDefaultInstance()))
                  .setSchemaDescriptor(new PDFBoxServiceMethodDescriptorSupplier("PdfPagesCount"))
                  .build();
          }
        }
     }
     return getPdfPagesCountMethod;
  }

  private static volatile io.grpc.MethodDescriptor<com.salefinder.Messages.PDFExportRequest,
      com.salefinder.Messages.PDFExportResponse> getImportExportMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "ImportExport",
      requestType = com.salefinder.Messages.PDFExportRequest.class,
      responseType = com.salefinder.Messages.PDFExportResponse.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<com.salefinder.Messages.PDFExportRequest,
      com.salefinder.Messages.PDFExportResponse> getImportExportMethod() {
    io.grpc.MethodDescriptor<com.salefinder.Messages.PDFExportRequest, com.salefinder.Messages.PDFExportResponse> getImportExportMethod;
    if ((getImportExportMethod = PDFBoxServiceGrpc.getImportExportMethod) == null) {
      synchronized (PDFBoxServiceGrpc.class) {
        if ((getImportExportMethod = PDFBoxServiceGrpc.getImportExportMethod) == null) {
          PDFBoxServiceGrpc.getImportExportMethod = getImportExportMethod = 
              io.grpc.MethodDescriptor.<com.salefinder.Messages.PDFExportRequest, com.salefinder.Messages.PDFExportResponse>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(
                  "PDFBoxService", "ImportExport"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  com.salefinder.Messages.PDFExportRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  com.salefinder.Messages.PDFExportResponse.getDefaultInstance()))
                  .setSchemaDescriptor(new PDFBoxServiceMethodDescriptorSupplier("ImportExport"))
                  .build();
          }
        }
     }
     return getImportExportMethod;
  }

  private static volatile io.grpc.MethodDescriptor<com.salefinder.Messages.PingRequest,
      com.salefinder.Messages.PongResponse> getPingMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "Ping",
      requestType = com.salefinder.Messages.PingRequest.class,
      responseType = com.salefinder.Messages.PongResponse.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<com.salefinder.Messages.PingRequest,
      com.salefinder.Messages.PongResponse> getPingMethod() {
    io.grpc.MethodDescriptor<com.salefinder.Messages.PingRequest, com.salefinder.Messages.PongResponse> getPingMethod;
    if ((getPingMethod = PDFBoxServiceGrpc.getPingMethod) == null) {
      synchronized (PDFBoxServiceGrpc.class) {
        if ((getPingMethod = PDFBoxServiceGrpc.getPingMethod) == null) {
          PDFBoxServiceGrpc.getPingMethod = getPingMethod = 
              io.grpc.MethodDescriptor.<com.salefinder.Messages.PingRequest, com.salefinder.Messages.PongResponse>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(
                  "PDFBoxService", "Ping"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  com.salefinder.Messages.PingRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  com.salefinder.Messages.PongResponse.getDefaultInstance()))
                  .setSchemaDescriptor(new PDFBoxServiceMethodDescriptorSupplier("Ping"))
                  .build();
          }
        }
     }
     return getPingMethod;
  }

  private static volatile io.grpc.MethodDescriptor<com.salefinder.Messages.Words,
      com.salefinder.Messages.Words> getChatMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "Chat",
      requestType = com.salefinder.Messages.Words.class,
      responseType = com.salefinder.Messages.Words.class,
      methodType = io.grpc.MethodDescriptor.MethodType.BIDI_STREAMING)
  public static io.grpc.MethodDescriptor<com.salefinder.Messages.Words,
      com.salefinder.Messages.Words> getChatMethod() {
    io.grpc.MethodDescriptor<com.salefinder.Messages.Words, com.salefinder.Messages.Words> getChatMethod;
    if ((getChatMethod = PDFBoxServiceGrpc.getChatMethod) == null) {
      synchronized (PDFBoxServiceGrpc.class) {
        if ((getChatMethod = PDFBoxServiceGrpc.getChatMethod) == null) {
          PDFBoxServiceGrpc.getChatMethod = getChatMethod = 
              io.grpc.MethodDescriptor.<com.salefinder.Messages.Words, com.salefinder.Messages.Words>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.BIDI_STREAMING)
              .setFullMethodName(generateFullMethodName(
                  "PDFBoxService", "Chat"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  com.salefinder.Messages.Words.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  com.salefinder.Messages.Words.getDefaultInstance()))
                  .setSchemaDescriptor(new PDFBoxServiceMethodDescriptorSupplier("Chat"))
                  .build();
          }
        }
     }
     return getChatMethod;
  }

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static PDFBoxServiceStub newStub(io.grpc.Channel channel) {
    return new PDFBoxServiceStub(channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static PDFBoxServiceBlockingStub newBlockingStub(
      io.grpc.Channel channel) {
    return new PDFBoxServiceBlockingStub(channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary calls on the service
   */
  public static PDFBoxServiceFutureStub newFutureStub(
      io.grpc.Channel channel) {
    return new PDFBoxServiceFutureStub(channel);
  }

  /**
   */
  public static abstract class PDFBoxServiceImplBase implements io.grpc.BindableService {

    /**
     */
    public void pdfPagesCount(com.salefinder.Messages.PDFInfoMessage request,
        io.grpc.stub.StreamObserver<com.salefinder.Messages.PDFInfoMessage> responseObserver) {
      asyncUnimplementedUnaryCall(getPdfPagesCountMethod(), responseObserver);
    }

    /**
     */
    public void importExport(com.salefinder.Messages.PDFExportRequest request,
        io.grpc.stub.StreamObserver<com.salefinder.Messages.PDFExportResponse> responseObserver) {
      asyncUnimplementedUnaryCall(getImportExportMethod(), responseObserver);
    }

    /**
     */
    public void ping(com.salefinder.Messages.PingRequest request,
        io.grpc.stub.StreamObserver<com.salefinder.Messages.PongResponse> responseObserver) {
      asyncUnimplementedUnaryCall(getPingMethod(), responseObserver);
    }

    /**
     */
    public io.grpc.stub.StreamObserver<com.salefinder.Messages.Words> chat(
        io.grpc.stub.StreamObserver<com.salefinder.Messages.Words> responseObserver) {
      return asyncUnimplementedStreamingCall(getChatMethod(), responseObserver);
    }

    @java.lang.Override public final io.grpc.ServerServiceDefinition bindService() {
      return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
          .addMethod(
            getPdfPagesCountMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                com.salefinder.Messages.PDFInfoMessage,
                com.salefinder.Messages.PDFInfoMessage>(
                  this, METHODID_PDF_PAGES_COUNT)))
          .addMethod(
            getImportExportMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                com.salefinder.Messages.PDFExportRequest,
                com.salefinder.Messages.PDFExportResponse>(
                  this, METHODID_IMPORT_EXPORT)))
          .addMethod(
            getPingMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                com.salefinder.Messages.PingRequest,
                com.salefinder.Messages.PongResponse>(
                  this, METHODID_PING)))
          .addMethod(
            getChatMethod(),
            asyncBidiStreamingCall(
              new MethodHandlers<
                com.salefinder.Messages.Words,
                com.salefinder.Messages.Words>(
                  this, METHODID_CHAT)))
          .build();
    }
  }

  /**
   */
  public static final class PDFBoxServiceStub extends io.grpc.stub.AbstractStub<PDFBoxServiceStub> {
    private PDFBoxServiceStub(io.grpc.Channel channel) {
      super(channel);
    }

    private PDFBoxServiceStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected PDFBoxServiceStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new PDFBoxServiceStub(channel, callOptions);
    }

    /**
     */
    public void pdfPagesCount(com.salefinder.Messages.PDFInfoMessage request,
        io.grpc.stub.StreamObserver<com.salefinder.Messages.PDFInfoMessage> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getPdfPagesCountMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void importExport(com.salefinder.Messages.PDFExportRequest request,
        io.grpc.stub.StreamObserver<com.salefinder.Messages.PDFExportResponse> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getImportExportMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void ping(com.salefinder.Messages.PingRequest request,
        io.grpc.stub.StreamObserver<com.salefinder.Messages.PongResponse> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getPingMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public io.grpc.stub.StreamObserver<com.salefinder.Messages.Words> chat(
        io.grpc.stub.StreamObserver<com.salefinder.Messages.Words> responseObserver) {
      return asyncBidiStreamingCall(
          getChannel().newCall(getChatMethod(), getCallOptions()), responseObserver);
    }
  }

  /**
   */
  public static final class PDFBoxServiceBlockingStub extends io.grpc.stub.AbstractStub<PDFBoxServiceBlockingStub> {
    private PDFBoxServiceBlockingStub(io.grpc.Channel channel) {
      super(channel);
    }

    private PDFBoxServiceBlockingStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected PDFBoxServiceBlockingStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new PDFBoxServiceBlockingStub(channel, callOptions);
    }

    /**
     */
    public com.salefinder.Messages.PDFInfoMessage pdfPagesCount(com.salefinder.Messages.PDFInfoMessage request) {
      return blockingUnaryCall(
          getChannel(), getPdfPagesCountMethod(), getCallOptions(), request);
    }

    /**
     */
    public com.salefinder.Messages.PDFExportResponse importExport(com.salefinder.Messages.PDFExportRequest request) {
      return blockingUnaryCall(
          getChannel(), getImportExportMethod(), getCallOptions(), request);
    }

    /**
     */
    public com.salefinder.Messages.PongResponse ping(com.salefinder.Messages.PingRequest request) {
      return blockingUnaryCall(
          getChannel(), getPingMethod(), getCallOptions(), request);
    }
  }

  /**
   */
  public static final class PDFBoxServiceFutureStub extends io.grpc.stub.AbstractStub<PDFBoxServiceFutureStub> {
    private PDFBoxServiceFutureStub(io.grpc.Channel channel) {
      super(channel);
    }

    private PDFBoxServiceFutureStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected PDFBoxServiceFutureStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new PDFBoxServiceFutureStub(channel, callOptions);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<com.salefinder.Messages.PDFInfoMessage> pdfPagesCount(
        com.salefinder.Messages.PDFInfoMessage request) {
      return futureUnaryCall(
          getChannel().newCall(getPdfPagesCountMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<com.salefinder.Messages.PDFExportResponse> importExport(
        com.salefinder.Messages.PDFExportRequest request) {
      return futureUnaryCall(
          getChannel().newCall(getImportExportMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<com.salefinder.Messages.PongResponse> ping(
        com.salefinder.Messages.PingRequest request) {
      return futureUnaryCall(
          getChannel().newCall(getPingMethod(), getCallOptions()), request);
    }
  }

  private static final int METHODID_PDF_PAGES_COUNT = 0;
  private static final int METHODID_IMPORT_EXPORT = 1;
  private static final int METHODID_PING = 2;
  private static final int METHODID_CHAT = 3;

  private static final class MethodHandlers<Req, Resp> implements
      io.grpc.stub.ServerCalls.UnaryMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ServerStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ClientStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.BidiStreamingMethod<Req, Resp> {
    private final PDFBoxServiceImplBase serviceImpl;
    private final int methodId;

    MethodHandlers(PDFBoxServiceImplBase serviceImpl, int methodId) {
      this.serviceImpl = serviceImpl;
      this.methodId = methodId;
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_PDF_PAGES_COUNT:
          serviceImpl.pdfPagesCount((com.salefinder.Messages.PDFInfoMessage) request,
              (io.grpc.stub.StreamObserver<com.salefinder.Messages.PDFInfoMessage>) responseObserver);
          break;
        case METHODID_IMPORT_EXPORT:
          serviceImpl.importExport((com.salefinder.Messages.PDFExportRequest) request,
              (io.grpc.stub.StreamObserver<com.salefinder.Messages.PDFExportResponse>) responseObserver);
          break;
        case METHODID_PING:
          serviceImpl.ping((com.salefinder.Messages.PingRequest) request,
              (io.grpc.stub.StreamObserver<com.salefinder.Messages.PongResponse>) responseObserver);
          break;
        default:
          throw new AssertionError();
      }
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public io.grpc.stub.StreamObserver<Req> invoke(
        io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_CHAT:
          return (io.grpc.stub.StreamObserver<Req>) serviceImpl.chat(
              (io.grpc.stub.StreamObserver<com.salefinder.Messages.Words>) responseObserver);
        default:
          throw new AssertionError();
      }
    }
  }

  private static abstract class PDFBoxServiceBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoFileDescriptorSupplier, io.grpc.protobuf.ProtoServiceDescriptorSupplier {
    PDFBoxServiceBaseDescriptorSupplier() {}

    @java.lang.Override
    public com.google.protobuf.Descriptors.FileDescriptor getFileDescriptor() {
      return com.salefinder.Messages.getDescriptor();
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.ServiceDescriptor getServiceDescriptor() {
      return getFileDescriptor().findServiceByName("PDFBoxService");
    }
  }

  private static final class PDFBoxServiceFileDescriptorSupplier
      extends PDFBoxServiceBaseDescriptorSupplier {
    PDFBoxServiceFileDescriptorSupplier() {}
  }

  private static final class PDFBoxServiceMethodDescriptorSupplier
      extends PDFBoxServiceBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoMethodDescriptorSupplier {
    private final String methodName;

    PDFBoxServiceMethodDescriptorSupplier(String methodName) {
      this.methodName = methodName;
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.MethodDescriptor getMethodDescriptor() {
      return getServiceDescriptor().findMethodByName(methodName);
    }
  }

  private static volatile io.grpc.ServiceDescriptor serviceDescriptor;

  public static io.grpc.ServiceDescriptor getServiceDescriptor() {
    io.grpc.ServiceDescriptor result = serviceDescriptor;
    if (result == null) {
      synchronized (PDFBoxServiceGrpc.class) {
        result = serviceDescriptor;
        if (result == null) {
          serviceDescriptor = result = io.grpc.ServiceDescriptor.newBuilder(SERVICE_NAME)
              .setSchemaDescriptor(new PDFBoxServiceFileDescriptorSupplier())
              .addMethod(getPdfPagesCountMethod())
              .addMethod(getImportExportMethod())
              .addMethod(getPingMethod())
              .addMethod(getChatMethod())
              .build();
        }
      }
    }
    return result;
  }
}
