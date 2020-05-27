---
title: Authentication and authorization in gRPC for ASP.NET Core
author: jamesnk
description: Learn how to use authentication and authorization in gRPC for ASP.NET Core.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 05/26/2020
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/authn-and-authz
---

# Authentication and authorization in gRPC for ASP.NET Core

By [James Newton-King](https://twitter.com/jamesnk)

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/grpc/authn-and-authz/sample/) [(how to download)](xref:index#how-to-download-a-sample)

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

On the server, bearer token authentication is configured using the [JWT Bearer middleware](/dotnet/api/microsoft.extensions.dependencyinjection.jwtbearerextensions.addjwtbearer).

In the .NET gRPC client, the token can be sent with calls as a header:

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

Configuring `ChannelCredentials` on a channel is an alternative way to send the token to the service with gRPC calls. The credential is run each time a gRPC call is made, which avoids the need to write code in multiple places to pass the token yourself.

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

### Client certificate authentication

A client could alternatively provide a client certificate for authentication. [Certificate authentication](https://tools.ietf.org/html/rfc5246#section-7.4.4) happens at the TLS level, long before it ever gets to ASP.NET Core. When the request enters ASP.NET Core, the [client certificate authentication package](xref:security/authentication/certauth) allows you to resolve the certificate to a `ClaimsPrincipal`.

> [!NOTE]
> The host needs to be configured to accept client certificates. See [configure your host to require certificates](xref:security/authentication/certauth#configure-your-host-to-require-certificates) for information on accepting client certificates in Kestrel, IIS and Azure.

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

* Strongly typed gRPC clients use `HttpClient` internally. Authentication can be configured on [HttpClientHandler](/dotnet/api/system.net.http.httpclienthandler), or by adding custom [HttpMessageHandler](/dotnet/api/system.net.http.httpmessagehandler) instances to the `HttpClient`.
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
