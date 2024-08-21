### SignalR supports trimming and native AOT

Continuing the [native AOT journey](xref:fundamentals/native-aot) started in .NET 8, we have enabled trimming and native ahead-of-time (AOT) compilation support for both SignalR client and server scenarios. You can now take advantage of the performance benefits of using native AOT in applications that use SignalR for real-time web communications.

#### Getting started

Install the latest [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0).

Create a solution from the `webapiaot` template in a command shell using the following command:

```dotnetcli
dotnet new webapiaot -o SignalRChatAOTExample
```

Replace the contents of the `Program.cs` file with the following SignalR code:

[!code-csharp[](~/release-notes/aspnetcore-9/samples/SignalRChatAOTExample/Program.cs)]

The preceding example produces a native Windows executable of 10 MB and a Linux executable of 10.9 MB.

#### Limitations

* Only the JSON protocol is currently supported:
  * As shown in the preceding code, apps that use JSON serialization and Native AOT must use the `System.Text.Json` Source Generator. 
  * This follows the same approach as minimal APIs.
* On the SignalR server, Hub method parameters of type `IAsyncEnumerable<T>` and `ChannelReader<T>` where `T` is a ValueType (i.e. `struct`) aren't supported. Using these types results in a runtime exception at startup in development and in the published app. For more information, see [SignalR: Using IAsyncEnumerable&lt;T&gt; and ChannelReader&lt;T&gt; with ValueTypes in native AOT (`dotnet/aspnetcore` #56179)](https://github.com/dotnet/aspnetcore/issues/56179).
* [Strongly typed hubs](xref:signalr/hubs#strongly-typed-hubs) aren't supported with Native AOT (`PublishAot`). Using strongly typed hubs with Native AOT will result in warnings during build and publish, and a runtime exception. Using strongly typed hubs with trimming (`PublishedTrimmed`) is supported.
* Only `Task`, `Task<T>`, `ValueTask`, or `ValueTask<T>` are supported for async return types.

