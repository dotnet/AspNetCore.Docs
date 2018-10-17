---
title: Security considerations in ASP.NET Core SignalR
author: tdykstra
description: Learn how to use authentication and authorization in ASP.NET Core SignalR.
monikerRange: '>= aspnetcore-2.1'
ms.author: anurse
ms.custom: mvc
ms.date: 06/29/2018
uid: signalr/security
---

# Security considerations in ASP.NET Core SignalR

By [Andrew Stanton-Nurse](https://twitter.com/anurse)

## Overview

SignalR provides a number of security protections by default. It's important to understand how to configure these protections.

### Cross-origin resource sharing

[Cross-origin resource sharing (CORS)](https://en.wikipedia.org/wiki/Cross-origin_resource_sharing) can be used to allow cross-origin SignalR connections in the browser. If your JavaScript code is hosted on a different domain name from your SignalR app, you have to enable the [ASP.NET Core CORS middleware](xref:security/cors) in order to allow the connection. In general, allow cross-origin requests only from domains you control. For example, if your site is hosted on `http://www.example.com` and your SignalR app is hosted on `http://signalr.example.com`, you should configure CORS in your SignalR app to only allow the origin `www.example.com`.

For more information on configuring CORS, see [the documentation on ASP.NET Core CORS](xref:security/cors). SignalR requires the following CORS policies in order to operate correctly:

* The policy must allow the specific origins you expect, or allow any origin (not recommended).
* HTTP methods `GET` and `POST` must be allowed.
* Credentials must be enabled, even when you aren't using authentication.

For example, the following CORS policy allows a SignalR browser client hosted on `http://example.com` to access your SignalR app:

```csharp
public void Configure(IApplicationBuilder app)
{
    // ... other middleware ...

    // Make sure the CORS middleware is ahead of SignalR.
    app.UseCors(builder => {
        builder.WithOrigins("http://example.com")
            .AllowAnyHeader()
            .WithMethods("GET", "POST")
            .AllowCredentials();
    });

    // ... other middleware ...

    app.UseSignalR();

    // ... other middleware ...
}
```

> [!NOTE]
> SignalR is not compatible with the built-in CORS feature in Azure App Service.

### WebSocket Origin Restriction

The protections provided by CORS do not apply to WebSockets. Browsers do not perform CORS pre-flight requests, nor do they respect the restrictions specified in `Access-Control` headers when making WebSocket requests. However, browsers do send the `Origin` header when issuing WebSocket requests. You should configure your application to validate these headers in order to ensure that only WebSockets coming from the origins you expect are allowed.

In ASP.NET Core 2.1, this can be achieved using a custom middleware you can place **above `UseSignalR`, and any authentication middleware** in your `Configure` method:

```csharp
// In your Startup class, add a static field listing the allowed Origin values:
private static readonly HashSet<string> _allowedOrigins = new HashSet<string>()
{
    // Add allowed origins here. For example:
    "http://www.mysite.com",
    "http://mysite.com",
};

// In your Configure method:
public void Configure(IApplicationBuilder app)
{
    // ... other middleware ...

    // Validate Origin header on WebSocket requests to prevent unexpected cross-site WebSocket requests
    app.Use((context, next) =>
    {
        // Check for a WebSocket request.
        if(string.Equals(context.Request.Headers["Upgrade"], "websocket"))
        {
            var origin = context.Request.Headers["Origin"];

            // If there is no origin header, or if the origin header doesn't match an allowed value:
            if(string.IsNullOrEmpty(origin) && !_allowedOrigins.Contains(origin))
            {
                // The origin is not allowed, reject the request
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return Task.CompletedTask;
            }
        }

        // The request is not a WebSocket request or is a valid Origin, so let it continue
        return next();
    });

    // ... other middleware ...

    app.UseSignalR();

    // ... other middleware ...
}
```

> [!NOTE]
> The `Origin` header is completely controlled by the client and, like the `Referer` header, can be faked. These headers should never be used as an authentication mechanism.

### Access token logging

When using WebSockets or Server-Sent Events, the browser client sends the access token in the query string. This is generally as secure as using the standard `Authorization` header, however many web servers log the URL for each request, including the query string. This means the access token may be included in logs. Consider reviewing the web server's logging settings to avoid logging this information.

### Exceptions

Exception messages are generally considered sensitive data that shouldn't be revealed to a client. By default, SignalR doesn't send the details of an exception thrown by a hub method to the client. Instead, the client receives a generic message indicating an error occurred. You can override this behavior by setting the [`EnableDetailedErrors`](xref:signalr/configuration#configure-server-options) setting.

### Buffer management

SignalR uses per-connection buffers in order to manage incoming and outgoing messages. By default, SignalR limits these buffers to 32KB. This means the largest possible message a client or server can send is 32KB. This also means the maximum amount of memory consumed by a connection for messages is 32KB. If you know your messages are always smaller than this limit, you can reduce this size to prevent a client from being able to send a larger message and force the server to allocate memory to accept it. Similarly, if you know your messages are larger than this limit, you can increase it. However, be aware that increasing this limit means that the client is able to cause the server to allocate additional memory and may reduce the number of concurrent connections your app can handle.

There are separate limits for incoming and outgoing messages, both can be configured on the [`HttpConnectionDispatcherOptions`](xref:signalr/configuration#configure-server-options) object configured in `MapHub`:

* `ApplicationMaxBufferSize` represents the maximum number of bytes from the client that the server buffers. If the client attempts to send a message larger than this limit, the connection may be closed.
* `TransportMaxBufferSize` represents the maximum number of bytes the server can send. If the server attempts to send a message (includes return values from hub methods) larger than this limit, an exception will be thrown.

Setting the limit to `0` disables the limit entirely. However, this should be done with extreme caution. Removing the limit allows a client to send a message of any size. This could be used by a malicious client to cause excess memory to be allocated, which could dramatically reduce the number of concurrent connections your app can support.
