### SignalR supports trimming and native AOT

Continuing the [native AOT journey](xref:fundamentals/native-aot) started in .NET 8, we have enabled trimming and native ahead-of-time (AOT) compilation support for both SignalR client and server scenarios. You can now take advantage of the performance benefits of using native AOT in applications that use SignalR for real-time web communications.

#### Getting started

Install the latest [.NET 9 SDK](https://get.dot.net/9).

Create a solution from the `webapiaot` template in a command shell using the following command:

```dotnetcli
dotnet new webapiaot -o SignalRChatAOTExample
```

Replace the contents of the `Program.cs` file with the following SignalR code:

[!code-csharp[](~/release-notes/aspnetcore-9/samples/SignalRChatAOTExample/Program.cs)]

The preceding example produces a native Windows executable of 10 MB and a Linux executable of 10.9 MB.

#### Limitations

* Only the JSON protocol is currently supported. As shown previously, apps need to use the System.Text.Json source generator. This follows the same approach as Minimal APIs.
* On a SignalR server, Hub method parameters of type `IAsyncEnumerable<T>` and `ChannelReader<T>` where `T` is a ValueType (i.e. `struct`) aren't supported. These will cause runtime exceptions at startup during development and in the published app. For more information, see [SignalR: Using IAsyncEnumerable&lt;T&gt; and ChannelReader&lt;T&gt; with ValueTypes in native AOT (`dotnet/aspnetcore` #56179)](https://github.com/dotnet/aspnetcore/issues/56179).
* Client proxy generation is not supported in PublishAot. Client proxy generation will result in warnings at build-time and works with `PublishTrimmed` with no warnings.
* Custom awaitables on the server are not supported in trimming or AOT. The feature switch `Microsoft.AspNetCore.SignalR.Hub.IsCustomAwaitableSupported` AppContext switch and `SignalRCustomAwaitableSupport` MSBuild property, is disabled by default in trimmed and AOT compiled apps.
