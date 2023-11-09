:::moniker range=">= aspnetcore-5.0 < aspnetcore-8.0"

Processes running on the same machine can be designed to communicate with each other. Operating systems provide technologies for enabling fast and efficient [inter-process communication (IPC)](https://wikipedia.org/wiki/Inter-process_communication). Popular examples of IPC technologies are Unix domain sockets and Named pipes.

.NET provides support for inter-process communication using gRPC.

> [!NOTE]
> Built-in support for Named pipes in ASP.NET Core requires .NET 8 or later.  
> For more information, see [the .NET 8 or later version of this topic](xref:grpc/interprocess?view=aspnetcore-8.0)

## Get started

gRPC calls are sent from a client to a server. To communicate between apps on a machine with gRPC, at least one app must host an ASP.NET Core gRPC server.

ASP.NET Core and gRPC can be hosted in any app using .NET Core 3.1 or later by adding the `Microsoft.AspNetCore.App` framework to the project.

[!code-xml[](~/grpc/interprocess/Server.csproj?highlight=4-6)]

The preceding project file:

* Adds a framework reference to `Microsoft.AspNetCore.App`. The framework reference allows non-ASP.NET Core apps, such as Windows Services, WPF apps, or WinForms apps to use ASP.NET Core and host an ASP.NET Core server.
* Adds a NuGet package reference to [`Grpc.AspNetCore`](https://www.nuget.org/packages/Grpc.AspNetCore).
* Adds a `.proto` file.

## Configure Unix domain sockets

gRPC calls between a client and server on different machines are usually sent over TCP sockets. TCP was designed for communicating across a network. [Unix domain sockets (UDS)](https://wikipedia.org/wiki/Unix_domain_socket) are a widely supported IPC technology that's more efficient than TCP when the client and server are on the same machine. .NET provides built-in support for UDS in client and server apps.

Requirements:

* .NET 5 or later
* Linux, macOS, or [Windows 10/Windows Server 2019 or later](https://devblogs.microsoft.com/commandline/af_unix-comes-to-windows/)

### Server configuration

Unix domain sockets (UDS) are supported by [Kestrel](xref:fundamentals/servers/kestrel), which is configured in `Program.cs`:

```csharp
public static readonly string SocketPath = Path.Combine(Path.GetTempPath(), "socket.tmp");

public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
            webBuilder.ConfigureKestrel(options =>
            {
                if (File.Exists(SocketPath))
                {
                    File.Delete(SocketPath);
                }
                options.ListenUnixSocket(SocketPath, listenOptions =>
                {
                    listenOptions.Protocols = HttpProtocols.Http2;
                });
            });
        });
```

The preceding example:

* Configures Kestrel's endpoints in `ConfigureKestrel`.
* Calls <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenUnixSocket%2A> to listen to a UDS with the specified path.
* Creates a UDS endpoint that isn't configured to use HTTPS. For information about enabling HTTPS, see [Kestrel HTTPS endpoint configuration](xref:fundamentals/servers/kestrel/endpoints#listenoptionsusehttps).

### Client configuration

`GrpcChannel` supports making gRPC calls over custom transports. When a channel is created, it can be configured with a `SocketsHttpHandler` that has a custom `ConnectCallback`. The callback allows the client to make connections over custom transports and then send HTTP requests over that transport.

Unix domain sockets connection factory example:

```csharp
public class UnixDomainSocketConnectionFactory
{
    private readonly EndPoint _endPoint;

    public UnixDomainSocketConnectionFactory(EndPoint endPoint)
    {
        _endPoint = endPoint;
    }

    public async ValueTask<Stream> ConnectAsync(SocketsHttpConnectionContext _,
        CancellationToken cancellationToken = default)
    {
        var socket = new Socket(AddressFamily.Unix, SocketType.Stream, ProtocolType.Unspecified);

        try
        {
            await socket.ConnectAsync(_endPoint, cancellationToken).ConfigureAwait(false);
            return new NetworkStream(socket, true);
        }
        catch
        {
            socket.Dispose();
            throw;
        }
    }
}
```

Using the custom connection factory to create a channel:

```csharp
public static readonly string SocketPath = Path.Combine(Path.GetTempPath(), "socket.tmp");

public static GrpcChannel CreateChannel()
{
    var udsEndPoint = new UnixDomainSocketEndPoint(SocketPath);
    var connectionFactory = new UnixDomainSocketConnectionFactory(udsEndPoint);
    var socketsHttpHandler = new SocketsHttpHandler
    {
        ConnectCallback = connectionFactory.ConnectAsync
    };

    return GrpcChannel.ForAddress("http://localhost", new GrpcChannelOptions
    {
        HttpHandler = socketsHttpHandler
    });
}
```

Channels created using the preceding code send gRPC calls over Unix domain sockets. Support for other IPC technologies can be implemented using the extensibility in Kestrel and `SocketsHttpHandler`.

:::moniker-end
