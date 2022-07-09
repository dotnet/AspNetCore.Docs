---
title: Test ASP.NET Core middleware
author: tratcher
description: Learn how to test ASP.NET Core middleware with TestServer.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 05/18/2022
uid: test/middleware
---
# Test ASP.NET Core middleware

By [Chris Ross](https://github.com/Tratcher)

Middleware can be tested in isolation with <xref:Microsoft.AspNetCore.TestHost.TestServer>. It allows you to:

* Instantiate an app pipeline containing only the components that you need to test.
* Send custom requests to verify middleware behavior.

Advantages:

* Requests are sent in-memory rather than being serialized over the network.
* This avoids additional concerns, such as port management and HTTPS certificates.
* Exceptions in the middleware can flow directly back to the calling test.
* It's possible to customize server data structures, such as <xref:Microsoft.AspNetCore.Http.HttpContext>, directly in the test.

## Set up the TestServer

In the test project, create a test:

* Build and start a host that uses <xref:Microsoft.AspNetCore.TestHost.TestServer>.
* Add any required services that the middleware uses.
* Add a package reference to the project for the [`Microsoft.AspNetCore.TestHost`](https://www.nuget.org/packages/Microsoft.AspNetCore.TestHost/) NuGet package.
* Configure the processing pipeline to use the middleware for the test.

  [!code-csharp[](middleware/samples_snapshot/3.x/setup.cs?highlight=4-18)]

[!INCLUDE[](~/includes/package-reference.md)]

## Send requests with HttpClient

Send a request using <xref:System.Net.Http.HttpClient>:

[!code-csharp[](middleware/samples_snapshot/3.x/request.cs?highlight=20)]

Assert the result. First, make an assertion the opposite of the result that you expect. An initial run with a false positive assertion confirms that the test fails when the middleware is performing correctly. Run the test and confirm that the test fails.

In the following example, the middleware should return a 404 status code (*Not Found*) when the root endpoint is requested. Make the first test run with `Assert.NotEqual( ... );`, which should fail:

[!code-csharp[](middleware/samples_snapshot/3.x/false-failure-check.cs?highlight=22)]

Change the assertion to test the middleware under normal operating conditions. The final test uses `Assert.Equal( ... );`. Run the test again to confirm that it passes.

[!code-csharp[](middleware/samples_snapshot/3.x/final-test.cs?highlight=22)]

## Send requests with HttpContext

A test app can also send a request using [SendAsync(Action\<HttpContext>, CancellationToken)](xref:Microsoft.AspNetCore.TestHost.TestServer.SendAsync%2A). In the following example, several checks are made when `https://example.com/A/Path/?and=query` is processed by the middleware:

```csharp
[Fact]
public async Task TestMiddleware_ExpectedResponse()
{
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

    var server = host.GetTestServer();
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

<xref:Microsoft.AspNetCore.TestHost.TestServer.SendAsync%2A> permits direct configuration of an <xref:Microsoft.AspNetCore.Http.HttpContext> object rather than using the <xref:System.Net.Http.HttpClient> abstractions. Use <xref:Microsoft.AspNetCore.TestHost.TestServer.SendAsync%2A> to manipulate structures only available on the server, such as [HttpContext.Items](xref:Microsoft.AspNetCore.Http.HttpContext.Items) or [HttpContext.Features](xref:Microsoft.AspNetCore.Http.HttpContext.Features).

As with the earlier example that tested for a *404 - Not Found* response, check the opposite for each `Assert` statement in the preceding test. The check confirms that the test fails correctly when the middleware is operating normally. After you've confirmed that the false positive test works, set the final `Assert` statements for the expected conditions and values of the test. Run it again to confirm that the test passes.

## TestServer limitations

TestServer:

* Was created to replicate server behaviors to test middleware.
* Does ***not*** try to replicate all <xref:System.Net.Http.HttpClient> behaviors.
* Attempts to give the client access to as much control over the server as possible, and with as much visibility into what's happening on the server as possible. For example it may throw exceptions not normally thrown by `HttpClient` in order to directly communicate server state.
* Doesn't set some transport specific headers by default as those aren't usually relevant to middleware. For more information, see the next section.
* Ignores the `Stream` position passed through <xref:System.Net.Http.StreamContent>. <xref:System.Net.Http.HttpClient> sends the entire stream from the start position, even when positioning is set. For more information, see [this GitHub issue](https://github.com/dotnet/aspnetcore/issues/33780).

### Content-Length and Transfer-Encoding headers

TestServer does ***not*** set transport related request or response headers such as [Content-Length](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Length) or [Transfer-Encoding](https://developer.mozilla.org/docs/Web/HTTP/Headers/Transfer-Encoding). Applications should avoid depending on these headers because their usage varies by client, scenario, and protocol. If `Content-Length` and `Transfer-Encoding` are necessary to test a specific scenario, they can be specified in the test when composing the <xref:System.Net.Http.HttpRequestMessage> or <xref:Microsoft.AspNetCore.Http.HttpContext>. For more information, see the following GitHub issues:

* [dotnet/aspnetcore#21677](https://github.com/dotnet/aspnetcore/issues/21677)
* [dotnet/aspnetcore#18463](https://github.com/dotnet/aspnetcore/issues/18463)
* [dotnet/aspnetcore#13273](https://github.com/dotnet/aspnetcore/issues/13273)
