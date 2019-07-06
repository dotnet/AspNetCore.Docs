---
title: Authentication and authorization in gRPC for ASP.NET Core
author: jamesnk
description: Learn how to use authentication and authorization in gRPC for ASP.NET Core.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 06/07/2019
uid: grpc/authn-and-authz
---

# Authentication and authorization in gRPC for ASP.NET Core

By [James Newton-King](https://twitter.com/jamesnk)

[View or download sample code](https://github.com/aspnet/AspNetCore.Docs/tree/master/aspnetcore/grpc/authn-and-authz/sample/) [(how to download)](xref:index#how-to-download-a-sample)

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
        routes.MapGrpcService<GreeterService>();
    });
}
```

> [!NOTE]
> The order in which you register the ASP.NET Core authentication middleware matters. Always call `UseAuthentication` and `UseAuthorization` after `UseRouting` and before `UseEndpoints`.

Once authentication has been setup the user can be accessed in a gRPC service methods via the `ServerCallContext`.

```csharp
public override Task<BuyTicketsResponse> BuyTickets(
    BuyTicketsRequest request, ServerCallContext context)
{
    var user = context.GetHttpContext().User;

    // ... access data from ClaimsPrincipal ...
}

```

### Bearer token authentication

The client can provide an access token for authentication. The server validates the token and uses it to identify the user. This validation is done only when the connection is established. During the life of the connection, the server doesn't automatically revalidate to check for token revocation.

On the server, bearer token authentication is configured using the [JWT Bearer middleware](/dotnet/api/microsoft.extensions.dependencyinjection.jwtbearerextensions.addjwtbearer).

In the .NET gRPC client, the token can be sent with calls as a header:

```cs
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

### Client certificate authentication

A client could alternatively provide a client certificate for authentication. Certificate authentication happens at the TLS level, long before it ever gets to ASP.NET Core. When the request enters ASP.NET Core [Microsoft.AspNetCore.Authentication.Certificate](xref:security/authentication/certauth) allows you to resolve the certificate to a `ClaimsPrincipal`.

In the .NET gRPC client, the client certificate is added to `HttpClientHandler` that is then used to create the gRPC client:

```cs
public Ticketer.TicketerClient CreateClientWithCert(
    string baseAddress,
    X509Certificate2 certificate)
{
    // Add client cert to the handler
    var handler = new HttpClientHandler();
    handler.ClientCertificates.Add(certificate);

    // Create the gRPC client
    var httpClient = new HttpClient(handler);
    httpClient.BaseAddress = new Uri(baseAddress);
    
    return GrpcClient.Create<Ticketer.TicketerClient>(httpClient);
}
```

## Authorize users to access services and service methods

By default, all methods in a service can be called by unauthenticated users. In order to require authentication, apply the [Authorize](/dotnet/api/microsoft.aspnetcore.authorization.authorizeattribute) attribute to the service:

```cs
[Authorize]
public class TicketerService : Ticketer.TicketerBase
{
}
```

You can use the constructor arguments and properties of the `[Authorize]` attribute to restrict access to only users matching specific [authorization policies](xref:security/authorization/policies). For example, if you have a custom authorization policy called `MyAuthorizationPolicy` you can ensure that only users matching that policy can access the service using the following code:

```csharp
[Authorize("MyAuthorizationPolicy")]
public class TicketerService : Ticketer.TicketerBase
{
}
```

Individual service methods can have the `[Authorize]` attribute applied as well. If the current user doesn't match the policy applied to the method, an error is returned to the caller:

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

* [Bearer Token Authentication in ASP.NET Core](https://blogs.msdn.microsoft.com/webdev/2016/10/27/bearer-token-authentication-in-asp-net-core/)