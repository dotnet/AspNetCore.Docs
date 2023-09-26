---
title: SignalR HubContext
author: bradygaster
description: Learn how to use the ASP.NET Core SignalR HubContext service for sending notifications to clients from outside a hub.
monikerRange: '>= aspnetcore-2.1'
ms.author: bradyg
ms.custom: mvc
ms.date: 02/20/2023
uid: signalr/hubcontext
---
# Send messages from outside a hub

The SignalR hub is the core abstraction for sending messages to clients connected to the SignalR server. It's also possible to send messages from other places in your app using the `IHubContext` service. This article explains how to access a SignalR `IHubContext` to send notifications to clients from outside a hub.

> [!NOTE]
> The `IHubContext` is for sending notifications to clients, it is not used to call methods on the `Hub`.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/signalr/hubcontext/sample/) [(how to download)](xref:index#how-to-download-a-sample)

## Get an instance of `IHubContext`

In ASP.NET Core SignalR, you can access an instance of `IHubContext` via dependency injection. You can inject an instance of `IHubContext` into a controller, middleware, or other DI service. Use the instance to send messages to clients.

### Inject an instance of `IHubContext` in a controller

You can inject an instance of `IHubContext` into a controller by adding it to your constructor:

[!code-csharp[](hubcontext/sample/Controllers/HomeController.cs?range=12-19,57)]

With access to an instance of `IHubContext`, call client methods as if you were in the hub itself:

[!code-csharp[](hubcontext/sample/Controllers/HomeController.cs?range=21-25)]

### Get an instance of `IHubContext` in middleware

Access the `IHubContext` within the middleware pipeline like so:

```csharp
app.Use(async (context, next) =>
{
    var hubContext = context.RequestServices
                            .GetRequiredService<IHubContext<ChatHub>>();
    //...
    
    if (next != null)
    {
        await next.Invoke();
    }
});
```

> [!NOTE]
> When client methods are called from outside of the `Hub` class, there's no caller associated with the invocation. Therefore, there's no access to the `ConnectionId`, `Caller`, and `Others` properties.
>
> Apps that need to map a user to the connection ID and persist that mapping can do one of the following:
>
> - Persist mapping of single or multiple connections as groups. See [Groups in SignalR](xref:signalr/groups#groups-in-signalr) for more information.
> - Retain connection and user information through a singleton service. See [Inject services into a hub](xref:signalr/hubs#inject-services-into-a-hub) for more information. The singleton service can use any storage method, such as:
>   - In-memory storage in a dictionary.
>   - Permanent external storage.  For example, a database or Azure Table storage using the [Azure.Data.Tables NuGet package](https://www.nuget.org/packages/Azure.Data.Tables/).
> - Pass the connection ID between clients.

### Get an instance of `IHubContext` from IHost

Accessing an `IHubContext` from the web host is useful for
integrating with areas outside of ASP.NET Core, for example, using third-party dependency injection frameworks:

```csharp
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var hubContext = host.Services.GetService(typeof(IHubContext<ChatHub>));
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });
    }
```

### Inject a strongly-typed HubContext

To inject a strongly-typed HubContext, ensure your Hub inherits from `Hub<T>`. Inject it using the `IHubContext<THub, T>` interface rather than `IHubContext<THub>`.

```csharp
public class ChatController : Controller
{
    public IHubContext<ChatHub, IChatClient> _strongChatHubContext { get; }

    public ChatController(IHubContext<ChatHub, IChatClient> chatHubContext)
    {
        _strongChatHubContext = chatHubContext;
    }

    public async Task SendMessage(string user, string message)
    {
        await _strongChatHubContext.Clients.All.ReceiveMessage(user, message);
    }
}
```

See [Strongly typed hubs](xref:signalr/hubs#strongly-typed-hubs) for more information.

:::moniker range=">= aspnetcore-6.0"

### Use `IHubContext` in generic code

An injected `IHubContext<THub>` instance can be cast to `IHubContext` without a generic `Hub` type specified.

```csharp
class MyHub : Hub
{ }

class MyOtherHub : Hub
{ }

app.Use(async (context, next) =>
{
    var myHubContext = context.RequestServices
                            .GetRequiredService<IHubContext<MyHub>>();
    var myOtherHubContext = context.RequestServices
                            .GetRequiredService<IHubContext<MyOtherHub>>();
    await CommonHubContextMethod((IHubContext)myHubContext);
    await CommonHubContextMethod((IHubContext)myOtherHubContext);

    await next.Invoke();
}

async Task CommonHubContextMethod(IHubContext context)
{
    await context.Clients.All.SendAsync("clientMethod", new Args());
}
```

This is useful when:

* Writing libraries that don't have a reference to the specific `Hub` type the app is using.
* Writing code that is generic and can apply to multiple different `Hub` implementations

:::moniker-end

## Additional resources

* [SignalR assemblies in shared framework](xref:migration/22-to-30#signalr-assemblies-in-shared-framework)
* <xref:tutorials/signalr>
* <xref:signalr/hubs>
* <xref:signalr/publish-to-azure-web-app>
