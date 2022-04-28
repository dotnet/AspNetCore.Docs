---
title: Authentication and authorization in gRPC for ASP.NET Core
author: jamesnk
description: Learn how to use authentication and authorization in gRPC for ASP.NET Core.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 04/13/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/authn-and-authz
---
# Authentication and authorization in gRPC for ASP.NET Core

By [James Newton-King](https://twitter.com/jamesnk)
:::moniker range=">= aspnetcore-6.0"

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/grpc/authn-and-authz/sample/6.x/) [(how to download)](xref:index#how-to-download-a-sample)

## Authenticate users calling a gRPC service

gRPC can be used with [ASP.NET Core authentication](xref:security/authentication/identity) to associate a user with each call.

The following is an example of `Program.cs` which uses gRPC and ASP.NET Core authentication:

```csharp
app.UseRouting();
    
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<GreeterService>();
});
```

> [!NOTE]
> The order in which you register the ASP.NET Core authentication middleware matters. Always call `UseAuthentication` and `UseAuthorization` after `UseRouting` and before `UseEndpoints`.

The authentication mechanism your app uses during a call needs to be configured. Authentication configuration is added in `Program.cs` and will be different depending upon the authentication mechanism your app uses. For examples of how to secure ASP.NET Core apps, see [Authentication samples](xref:security/authentication/samples).

Once authentication has been setup, the user can be accessed in a gRPC service methods via the `ServerCallContext`.

```csharp
public override Task<BuyTicketsResponse> BuyTickets(
    BuyTicketsRequest request, ServerCallContext context)
{
    var user = context.GetHttpContext().User;

    // ... access data from ClaimsPrincipal ...
}

```

### Bearer token authentication

The client can provide an access token for authentication. The server validates the token and uses it to identify the user.

On the server, bearer token authentication is configured using the [JWT Bearer middleware](xref:Microsoft.Extensions.DependencyInjection.JwtBearerExtensions.AddJwtBearer%2A).

In the .NET gRPC client, the token can be sent with calls by using the `Metadata` collection. Entries in the `Metadata` collection are sent with a gRPC call as HTTP headers:

```csharp
public bool DoAuthenticatedCall(
    Ticketer.TicketerClient client, string token)
{
    var headers = new Metadata();
    headers.Add("Authorization", $"Bearer {token}");

    var request = new BuyTicketsRequest { Count = 1 };
    var response = await client.BuyTicketsAsync(request, headers);

    return response.Success;
}
```

Configuring `ChannelCredentials` on a channel is an alternative way to send the token to the service with gRPC calls. A `ChannelCredentials` can include `CallCredentials`, which provide a way to automatically set `Metadata`. `CallCredentials` is run each time a gRPC call is made, which avoids the need to write code in multiple places to pass the token yourself.

> [!NOTE]
> `CallCredentials` are only applied if the channel is secured with TLS. Sending authentication headers over an insecure connection has security implications and shouldn't be done in production environments. An app can configure a channel to ignore this behavior and always use `CallCredentials` by setting `UnsafeUseInsecureChannelCallCredentials` on a channel.

The credential in the following example configures the channel to send the token with every gRPC call:

```csharp
private static GrpcChannel CreateAuthenticatedChannel(string address)
{
    var credentials = CallCredentials.FromInterceptor((context, metadata) =>
    {
        if (!string.IsNullOrEmpty(_token))
        {
            metadata.Add("Authorization", $"Bearer {_token}");
        }
        return Task.CompletedTask;
    });

    var channel = GrpcChannel.ForAddress(address, new GrpcChannelOptions
    {
        Credentials = ChannelCredentials.Create(new SslCredentials(), credentials)
    });
    return channel;
}
```

#### Bearer token with gRPC client factory

gRPC client factory can create clients that send a bearer token using `AddCallCredentials`. This method is available in [Grpc.Net.ClientFactory](https://www.nuget.org/packages/Grpc.Net.ClientFactory) version 2.46.0 or later.

The delegate passed to `AddCallCredentials` is executed for each gRPC call:

```csharp
builder.Services
    .AddGrpcClient<Greeter.GreeterClient>(o =>
    {
        o.Address = new Uri("https://localhost:5001");
    })
    .AddCallCredentials((context, metadata) =>
    {
        if (!string.IsNullOrEmpty(_token))
        {
            metadata.Add("Authorization", $"Bearer {_token}");
        }
        return Task.CompletedTask;
    });
```

Dependency injection (DI) can be combined with `AddCallCredentials`. An overload passes `IServiceProvider` to the delegate, which can be used to get a service [constructed from DI using scoped and transient services](/dotnet/core/extensions/dependency-injection#service-lifetimes).

Consider an app that has:

* A user-defined `ITokenProvider` for getting a bearer token. `ITokenProvider` is registered in DI with a scoped lifetime.
* gRPC client factory is configured to create clients that are injected into gRPC services and Web API controllers.
* gRPC calls should use `ITokenProvider` to get a bearer token.

```csharp
public interface ITokenProvider
{
    Task<string> GetTokenAsync();
}

public class AppTokenProvider : ITokenProvider
{
    private string _token;

    public async Task<string> GetTokenAsync()
    {
        if (_token == null)
        {
            // App code to resolve the token here.
        }

        return _token;
    }
}
```

```csharp
builder.Services.AddScoped<ITokenProvider, AppTokenProvider>();

builder.Services
    .AddGrpcClient<Greeter.GreeterClient>(o =>
    {
        o.Address = new Uri("https://localhost:5001");
    })
    .AddCallCredentials(async (context, metadata, serviceProvider) =>
    {
        var provider = serviceProvider.GetRequiredService<ITokenProvider>();
        var token = await provider.GetTokenAsync();
        metadata.Add("Authorization", $"Bearer {token}");
    }));
```

The preceding code:

* Defines `ITokenProvider` and `AppTokenProvider`. These types handle resolving the authentication token for gRPC calls.
* Registers the `AppTokenProvider` type with DI in a scoped lifetime. `AppTokenProvider` caches the token so that only the first call in the scope is required to calculate it.
* Registers the `GreeterClient` type with client factory.
* Configures `AddCallCredentials` for this client. The delegate is executed each time a call is made and adds the token returned by `ITokenProvider` to the metadata.

### Client certificate authentication

A client could alternatively provide a client certificate for authentication. [Certificate authentication](https://tools.ietf.org/html/rfc5246#section-7.4.4) happens at the TLS level, long before it ever gets to ASP.NET Core. When the request enters ASP.NET Core, the [client certificate authentication package](xref:security/authentication/certauth) allows you to resolve the certificate to a `ClaimsPrincipal`.

> [!NOTE]
> Configure the server to accept client certificates. For information on accepting client certificates in Kestrel, IIS, and Azure, see <xref:security/authentication/certauth#configure-your-server-to-require-certificates>.

In the .NET gRPC client, the client certificate is added to `HttpClientHandler` that is then used to create the gRPC client:

```csharp
public Ticketer.TicketerClient CreateClientWithCert(
    string baseAddress,
    X509Certificate2 certificate)
{
    // Add client cert to the handler
    var handler = new HttpClientHandler();
    handler.ClientCertificates.Add(certificate);

    // Create the gRPC channel
    var channel = GrpcChannel.ForAddress(baseAddress, new GrpcChannelOptions
    {
        HttpHandler = handler
    });

    return new Ticketer.TicketerClient(channel);
}
```

### Other authentication mechanisms

Many ASP.NET Core supported authentication mechanisms work with gRPC:

* Azure Active Directory
* Client Certificate
* IdentityServer
* JWT Token
* OAuth 2.0
* OpenID Connect
* WS-Federation

For more information on configuring authentication on the server, see [ASP.NET Core authentication](xref:security/authentication/identity).

Configuring the gRPC client to use authentication will depend on the authentication mechanism you are using. The previous bearer token and client certificate examples show a couple of ways the gRPC client can be configured to send authentication metadata with gRPC calls:

* Strongly typed gRPC clients use `HttpClient` internally. Authentication can be configured on <xref:System.Net.Http.HttpClientHandler>, or by adding custom <xref:System.Net.Http.HttpMessageHandler> instances to the `HttpClient`.
* Each gRPC call has an optional `CallOptions` argument. Custom headers can be sent using the option's headers collection.

> [!NOTE]
> Windows Authentication (NTLM/Kerberos/Negotiate) can't be used with gRPC. gRPC requires HTTP/2, and HTTP/2 doesn't support Windows Authentication.

## Authorize users to access services and service methods

By default, all methods in a service can be called by unauthenticated users. To require authentication, apply the [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) attribute to the service:

```csharp
[Authorize]
public class TicketerService : Ticketer.TicketerBase
{
}
```

You can use the constructor arguments and properties of the `[Authorize]` attribute to restrict access to only users matching specific [authorization policies](xref:security/authorization/policies). For example, if you have a custom authorization policy called `MyAuthorizationPolicy`, ensure that only users matching that policy can access the service using the following code:

```csharp
[Authorize("MyAuthorizationPolicy")]
public class TicketerService : Ticketer.TicketerBase
{
}
```

Individual service methods can have the `[Authorize]` attribute applied as well. If the current user doesn't match the policies applied to **both** the method and the class, an error is returned to the caller:

```csharp
[Authorize]
public class TicketerService : Ticketer.TicketerBase
{
    public override Task<AvailableTicketsResponse> GetAvailableTickets(
        Empty request, ServerCallContext context)
    {
        // ... buy tickets for the current user ...
    }

    [Authorize("Administrators")]
    public override Task<BuyTicketsResponse> RefundTickets(
        BuyTicketsRequest request, ServerCallContext context)
    {
        // ... refund tickets (something only Administrators can do) ..
    }
}
```

## Additional resources

* [Bearer Token authentication in ASP.NET Core](https://blogs.msdn.microsoft.com/webdev/2016/10/27/bearer-token-authentication-in-asp-net-core/)
* [Configure Client Certificate authentication in ASP.NET Core](xref:security/authentication/certauth)

:::moniker-end

:::moniker range=">= aspnetcore-3.0 < aspnetcore-6.0"
[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/grpc/authn-and-authz/sample/) [(how to download)](xref:index#how-to-download-a-sample)

## Authenticate users calling a gRPC service

gRPC can be used with [ASP.NET Core authentication](xref:security/authentication/identity) to associate a user with each call.

The following is an example of `Startup.Configure` which uses gRPC and ASP.NET Core authentication:

```csharp
public void Configure(IApplicationBuilder app)
{
    app.UseRouting();
    
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapGrpcService<GreeterService>();
    });
}
```

> [!NOTE]
> The order in which you register the ASP.NET Core authentication middleware matters. Always call `UseAuthentication` and `UseAuthorization` after `UseRouting` and before `UseEndpoints`.

The authentication mechanism your app uses during a call needs to be configured. Authentication configuration is added in `Startup.ConfigureServices` and will be different depending upon the authentication mechanism your app uses. For examples of how to secure ASP.NET Core apps, see [Authentication samples](xref:security/authentication/samples).

Once authentication has been setup, the user can be accessed in a gRPC service methods via the `ServerCallContext`.

```csharp
public override Task<BuyTicketsResponse> BuyTickets(
    BuyTicketsRequest request, ServerCallContext context)
{
    var user = context.GetHttpContext().User;

    // ... access data from ClaimsPrincipal ...
}

```

### Bearer token authentication

The client can provide an access token for authentication. The server validates the token and uses it to identify the user.

On the server, bearer token authentication is configured using the [JWT Bearer middleware](xref:Microsoft.Extensions.DependencyInjection.JwtBearerExtensions.AddJwtBearer%2A).

In the .NET gRPC client, the token can be sent with calls by using the `Metadata` collection. Entries in the `Metadata` collection are sent with a gRPC call as HTTP headers:

```csharp
public bool DoAuthenticatedCall(
    Ticketer.TicketerClient client, string token)
{
    var headers = new Metadata();
    headers.Add("Authorization", $"Bearer {token}");

    var request = new BuyTicketsRequest { Count = 1 };
    var response = await client.BuyTicketsAsync(request, headers);

    return response.Success;
}
```

Configuring `ChannelCredentials` on a channel is an alternative way to send the token to the service with gRPC calls. A `ChannelCredentials` can include `CallCredentials`, which provide a way to automatically set `Metadata`.

`CallCredentials` is run each time a gRPC call is made, which avoids the need to write code in multiple places to pass the token yourself. Note that `CallCredentials` are only applied if the channel is secured with TLS. `CallCredentials` aren't applied on unsecured non-TLS channels.

The credential in the following example configures the channel to send the token with every gRPC call:

```csharp
private static GrpcChannel CreateAuthenticatedChannel(string address)
{
    var credentials = CallCredentials.FromInterceptor((context, metadata) =>
    {
        if (!string.IsNullOrEmpty(_token))
        {
            metadata.Add("Authorization", $"Bearer {_token}");
        }
        return Task.CompletedTask;
    });

    // SslCredentials is used here because this channel is using TLS.
    // CallCredentials can't be used with ChannelCredentials.Insecure on non-TLS channels.
    var channel = GrpcChannel.ForAddress(address, new GrpcChannelOptions
    {
        Credentials = ChannelCredentials.Create(new SslCredentials(), credentials)
    });
    return channel;
}
```

#### Bearer token with gRPC client factory

gRPC client factory can create clients that send a bearer token using `AddCallCredentials`. This method is available in [Grpc.Net.ClientFactory](https://www.nuget.org/packages/Grpc.Net.ClientFactory) version 2.46.0 or later.

The delegate passed to `AddCallCredentials` is executed for each gRPC call:

```csharp
services
    .AddGrpcClient<Greeter.GreeterClient>(o =>
    {
        o.Address = new Uri("https://localhost:5001");
    })
    .AddCallCredentials((context, metadata) =>
    {
        if (!string.IsNullOrEmpty(_token))
        {
            metadata.Add("Authorization", $"Bearer {_token}");
        }
        return Task.CompletedTask;
    });
```

Dependency injection (DI) can be combined with `AddCallCredentials`. An overload passes `IServiceProvider` to the delegate, which can be used to get a service [constructed from DI using scoped and transient services](/dotnet/core/extensions/dependency-injection#service-lifetimes).

Consider an app that has:

* A user-defined `ITokenProvider` for getting a bearer token. `ITokenProvider` is registered in DI with a scoped lifetime.
* gRPC client factory is configured to create clients that are injected into gRPC services and Web API controllers.
* gRPC calls should use `ITokenProvider` to get a bearer token.

```csharp
public interface ITokenProvider
{
    Task<string> GetTokenAsync();
}

public class AppTokenProvider : ITokenProvider
{
    private string _token;

    public async Task<string> GetTokenAsync()
    {
        if (_token == null)
        {
            // App code to resolve the token here.
        }

        return _token;
    }
}
```

```csharp
services.AddScoped<ITokenProvider, AppTokenProvider>();

services
    .AddGrpcClient<Greeter.GreeterClient>(o =>
    {
        o.Address = new Uri("https://localhost:5001");
    })
    .AddCallCredentials(async (context, metadata, serviceProvider) =>
    {
        var provider = serviceProvider.GetRequiredService<ITokenProvider>();
        var token = await provider.GetTokenAsync();
        metadata.Add("Authorization", $"Bearer {token}");
    }));
```

The preceding code:

* Defines `ITokenProvider` and `AppTokenProvider`. These types handle resolving the authentication token for gRPC calls.
* Registers the `AppTokenProvider` type with DI in a scoped lifetime. `AppTokenProvider` caches the token so that only the first call in the scope is required to calculate it.
* Registers the `GreeterClient` type with client factory.
* Configures `AddCallCredentials` for this client. The delegate is executed each time a call is made and adds the token returned by `ITokenProvider` to the metadata.

### Client certificate authentication

A client could alternatively provide a client certificate for authentication. [Certificate authentication](https://tools.ietf.org/html/rfc5246#section-7.4.4) happens at the TLS level, long before it ever gets to ASP.NET Core. When the request enters ASP.NET Core, the [client certificate authentication package](xref:security/authentication/certauth) allows you to resolve the certificate to a `ClaimsPrincipal`.

> [!NOTE]
> Configure the server to accept client certificates. For information on accepting client certificates in Kestrel, IIS, and Azure, see <xref:security/authentication/certauth#configure-your-server-to-require-certificates>.

In the .NET gRPC client, the client certificate is added to `HttpClientHandler` that is then used to create the gRPC client:

```csharp
public Ticketer.TicketerClient CreateClientWithCert(
    string baseAddress,
    X509Certificate2 certificate)
{
    // Add client cert to the handler
    var handler = new HttpClientHandler();
    handler.ClientCertificates.Add(certificate);

    // Create the gRPC channel
    var channel = GrpcChannel.ForAddress(baseAddress, new GrpcChannelOptions
    {
        HttpHandler = handler
    });

    return new Ticketer.TicketerClient(channel);
}
```

### Other authentication mechanisms

Many ASP.NET Core supported authentication mechanisms work with gRPC:

* Azure Active Directory
* Client Certificate
* IdentityServer
* JWT Token
* OAuth 2.0
* OpenID Connect
* WS-Federation

For more information on configuring authentication on the server, see [ASP.NET Core authentication](xref:security/authentication/identity).

Configuring the gRPC client to use authentication will depend on the authentication mechanism you are using. The previous bearer token and client certificate examples show a couple of ways the gRPC client can be configured to send authentication metadata with gRPC calls:

* Strongly typed gRPC clients use `HttpClient` internally. Authentication can be configured on <xref:System.Net.Http.HttpClientHandler>, or by adding custom <xref:System.Net.Http.HttpMessageHandler> instances to the `HttpClient`.
* Each gRPC call has an optional `CallOptions` argument. Custom headers can be sent using the option's headers collection.

> [!NOTE]
> Windows Authentication (NTLM/Kerberos/Negotiate) can't be used with gRPC. gRPC requires HTTP/2, and HTTP/2 doesn't support Windows Authentication.

## Authorize users to access services and service methods

By default, all methods in a service can be called by unauthenticated users. To require authentication, apply the [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) attribute to the service:

```csharp
[Authorize]
public class TicketerService : Ticketer.TicketerBase
{
}
```

You can use the constructor arguments and properties of the `[Authorize]` attribute to restrict access to only users matching specific [authorization policies](xref:security/authorization/policies). For example, if you have a custom authorization policy called `MyAuthorizationPolicy`, ensure that only users matching that policy can access the service using the following code:

```csharp
[Authorize("MyAuthorizationPolicy")]
public class TicketerService : Ticketer.TicketerBase
{
}
```

Individual service methods can have the `[Authorize]` attribute applied as well. If the current user doesn't match the policies applied to **both** the method and the class, an error is returned to the caller:

```csharp
[Authorize]
public class TicketerService : Ticketer.TicketerBase
{
    public override Task<AvailableTicketsResponse> GetAvailableTickets(
        Empty request, ServerCallContext context)
    {
        // ... buy tickets for the current user ...
    }

    [Authorize("Administrators")]
    public override Task<BuyTicketsResponse> RefundTickets(
        BuyTicketsRequest request, ServerCallContext context)
    {
        // ... refund tickets (something only Administrators can do) ..
    }
}
```

## Additional resources

* [Bearer Token authentication in ASP.NET Core](https://blogs.msdn.microsoft.com/webdev/2016/10/27/bearer-token-authentication-in-asp-net-core/)
* [Configure Client Certificate authentication in ASP.NET Core](xref:security/authentication/certauth)

:::moniker-end
