## SignalR supports trimming and native AOT

Continuing the [native AOT journey](https://learn.microsoft.com/aspnet/core/fundamentals/native-aot) we started in .NET 8, we have enabled trimming and native AOT support for both SignalR client and server scenarios. You can now take advantage of the performance benefits of using native AOT in applications that use SignalR for real-time web communications.

### Getting started

Install the latest [.NET 9 SDK](https://get.dot.net/9).

Create a solution from the `webapiaot` template in a command shell using the following command:

```dotnetcli
dotnet new webapiaot -o MyAOTSingnalRChat
```

Replace the contents of the `Program.cs` file with the following SignalR code:

[!code-csharp[ChatHub](~/release-notes/aspnetcore-9/includes/Program.cs)]

The previous example produces a native Windows executable of `10 MB` and a Linux executable of `10.9 MB`.

### Limitations

* Only the JSON protocol is currently supported:
    * As shown above, apps need to use the System.Text.Json Source Generator. This follows the same approach as Minimal APIs.
* On a SignalR server, Hub method parameters of type `IAsyncEnumerable<T>` and `ChannelReader<T>` where `T` is a ValueType (i.e. `struct`) are not supported.
    * These will cause runtime exceptions at startup during development and in the published app. See this issue [Issue #56179](https://github.com/dotnet/aspnetcore/issues/56179) for more information.
* Client proxy generation is not supported in PublishAot and will result in warnings at build-time.
    * Works with `PublishTrimmed` with no warnings.
* Custom awaitables on the server are not supported in Trimming or AOT:
    * The feature switch `Microsoft.AspNetCore.SignalR.Hub.IsCustomAwaitableSupported` AppContext switch and `SignalRCustomAwaitableSupport` MSBuild property, is disabled by default in trimmed and AOT compiled apps.
