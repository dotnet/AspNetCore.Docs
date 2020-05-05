---
title: Test ASP.NET Core middleware
author: cross
description: Learn how to test ASP.NET Core middleware with TestServer.
ms.author: riande
ms.custom: mvc
ms.date: 05/04/2019
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: test/middleware
---
# Test ASP.NET Core middleware

By [Chris Ross](https://github.com/Tratcher)

Middleware can be tested in isolation using the <xref:Microsoft.AspNetCore.TestHost.TestServer>. This allows you to instantiate an app pipeline containing only the components that you need to test and send custom requests to verify middleware behavior.

Advantages:

* Requests are sent in-memory rather than being serialized over the network.
* This avoids additional concerns, such as port management and HTTPS certificates.
* Exceptions in the middleware can flow directly back to the calling test.
* It's possible to customize server data structures, such as <xref:Microsoft.AspNetCore.Http.HttpContext>, directly in the test.

## Send requests with HttpClient



```csharp
using var host = await new HostBuilder()
    .ConfigureWebHost(webBuilder =>
    {
        webBuilder
            .UseTestServer()
            .ConfigureServices(services =>
            {
                services.AddMyServices();
            })
            .Configure(app =>
            {
                app.UseMiddleware<MyMiddleware>();
            });
    })
    .StartAsync();
```

Set up your test app, add your own middleware and services, and send a request using <xref:System.Net.Http.HttpClient>:

```csharp
[Fact]
public async Task GenericCreateAndStartHost_GetTestServer()
{
    using var host = await new HostBuilder()
        .ConfigureWebHost(webBuilder =>
        {
            webBuilder
                .UseTestServer()
                .Configure(app => { });
        })
        .StartAsync();

    var response = await host.GetTestServer().CreateClient().GetAsync("/");

    Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
}
```

A test app can also send a request using [SendAsync(Action\<HttpContext>, CancellationToken)](xref:Microsoft.AspNetCore.TestHost.TestServer.SendAsync%2A):

```csharp
[Fact]
public async Task ExpectedValuesAreAvailable()
{
    var builder = new WebHostBuilder().Configure(app => { });
    var server = new TestServer(builder);
    server.BaseAddress = new Uri("https://example.com/A/Path/");

    var context = await server.SendAsync(c =>
    {
        c.Request.Method = HttpMethods.Post;
        c.Request.Path = "/and/file.txt";
        c.Request.QueryString = new QueryString("?and=query");
    });

    Assert.True(context.RequestAborted.CanBeCanceled);
    Assert.Equal(HttpProtocol.Http11, context.Request.Protocol);
    Assert.Equal("POST", context.Request.Method);
    Assert.Equal("https", context.Request.Scheme);
    Assert.Equal("example.com", context.Request.Host.Value);
    Assert.Equal("/A/Path", context.Request.PathBase.Value);
    Assert.Equal("/and/file.txt", context.Request.Path.Value);
    Assert.Equal("?and=query", context.Request.QueryString.Value);
    Assert.NotNull(context.Request.Body);
    Assert.NotNull(context.Request.Headers);
    Assert.NotNull(context.Response.Headers);
    Assert.NotNull(context.Response.Body);
    Assert.Equal(404, context.Response.StatusCode);
    Assert.Null(context.Features.Get<IHttpResponseFeature>().ReasonPhrase);
}
```

`SendAsync` permits direct configuration of an <xref:Microsoft.AspNetCore.Http.HttpContext> object rather than using the `HttpClient` abstractions. Use `SendAsync` to manipulate structures only available on the server, such as [HttpContext.Items](xref:Microsoft.AspNetCore.Http.HttpContext.Items) or [HttpContext.Features](xref:Microsoft.AspNetCore.Http.HttpContext.Features).
