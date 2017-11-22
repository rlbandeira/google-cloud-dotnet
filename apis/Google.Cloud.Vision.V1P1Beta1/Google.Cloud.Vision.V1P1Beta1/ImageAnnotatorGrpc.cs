// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: google/cloud/vision/v1p1beta1/image_annotator.proto
// Original file comments:
// Copyright 2017 Google Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#pragma warning disable 1591
#region Designer generated code

using System;
using System.Threading;
using System.Threading.Tasks;
using grpc = global::Grpc.Core;

namespace Google.Cloud.Vision.V1P1Beta1 {
  /// <summary>
  /// Service that performs Google Cloud Vision API detection tasks over client
  /// images, such as face, landmark, logo, label, and text detection. The
  /// ImageAnnotator service returns detected entities from the images.
  /// </summary>
  public static partial class ImageAnnotator
  {
    static readonly string __ServiceName = "google.cloud.vision.v1p1beta1.ImageAnnotator";

    static readonly grpc::Marshaller<global::Google.Cloud.Vision.V1P1Beta1.BatchAnnotateImagesRequest> __Marshaller_BatchAnnotateImagesRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Cloud.Vision.V1P1Beta1.BatchAnnotateImagesRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Google.Cloud.Vision.V1P1Beta1.BatchAnnotateImagesResponse> __Marshaller_BatchAnnotateImagesResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Cloud.Vision.V1P1Beta1.BatchAnnotateImagesResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::Google.Cloud.Vision.V1P1Beta1.BatchAnnotateImagesRequest, global::Google.Cloud.Vision.V1P1Beta1.BatchAnnotateImagesResponse> __Method_BatchAnnotateImages = new grpc::Method<global::Google.Cloud.Vision.V1P1Beta1.BatchAnnotateImagesRequest, global::Google.Cloud.Vision.V1P1Beta1.BatchAnnotateImagesResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "BatchAnnotateImages",
        __Marshaller_BatchAnnotateImagesRequest,
        __Marshaller_BatchAnnotateImagesResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Google.Cloud.Vision.V1P1Beta1.ImageAnnotatorReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of ImageAnnotator</summary>
    public abstract partial class ImageAnnotatorBase
    {
      /// <summary>
      /// Run image detection and annotation for a batch of images.
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::Google.Cloud.Vision.V1P1Beta1.BatchAnnotateImagesResponse> BatchAnnotateImages(global::Google.Cloud.Vision.V1P1Beta1.BatchAnnotateImagesRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for ImageAnnotator</summary>
    public partial class ImageAnnotatorClient : grpc::ClientBase<ImageAnnotatorClient>
    {
      /// <summary>Creates a new client for ImageAnnotator</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public ImageAnnotatorClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for ImageAnnotator that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public ImageAnnotatorClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected ImageAnnotatorClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected ImageAnnotatorClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      /// <summary>
      /// Run image detection and annotation for a batch of images.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Google.Cloud.Vision.V1P1Beta1.BatchAnnotateImagesResponse BatchAnnotateImages(global::Google.Cloud.Vision.V1P1Beta1.BatchAnnotateImagesRequest request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return BatchAnnotateImages(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Run image detection and annotation for a batch of images.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::Google.Cloud.Vision.V1P1Beta1.BatchAnnotateImagesResponse BatchAnnotateImages(global::Google.Cloud.Vision.V1P1Beta1.BatchAnnotateImagesRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_BatchAnnotateImages, null, options, request);
      }
      /// <summary>
      /// Run image detection and annotation for a batch of images.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Google.Cloud.Vision.V1P1Beta1.BatchAnnotateImagesResponse> BatchAnnotateImagesAsync(global::Google.Cloud.Vision.V1P1Beta1.BatchAnnotateImagesRequest request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return BatchAnnotateImagesAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Run image detection and annotation for a batch of images.
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::Google.Cloud.Vision.V1P1Beta1.BatchAnnotateImagesResponse> BatchAnnotateImagesAsync(global::Google.Cloud.Vision.V1P1Beta1.BatchAnnotateImagesRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_BatchAnnotateImages, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override ImageAnnotatorClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new ImageAnnotatorClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(ImageAnnotatorBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_BatchAnnotateImages, serviceImpl.BatchAnnotateImages).Build();
    }

  }
}
#endregion
