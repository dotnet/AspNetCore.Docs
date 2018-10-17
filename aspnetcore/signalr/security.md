---
title: Security considerations in ASP.NET Core SignalR
author: tdykstra
description: Learn how to use authentication and authorization in ASP.NET Core SignalR.
monikerRange: '>= aspnetcore-2.1'
ms.author: anurse
ms.custom: mvc
ms.date: 10/17/2018
uid: signalr/security
---

# Security considerations in ASP.NET Core SignalR

By [Andrew Stanton-Nurse](https://twitter.com/anurse)

SignalR provides a number of security protections by default. It's important to understand how to configure these protections.

## Cross-origin resource sharing

[Cross-origin resource sharing (CORS)](https://www.w3.org/TR/cors/) can be used to allow cross-origin SignalR connections in the browser. If JavaScript code is hosted on a different domain from the SignalR app, [CORS middleware](xref:security/cors) must be enabled to allow the JavaScript to connect to the SignalR app. Allow cross-origin requests only from domains you trust or control. For example:

* Your site is hosted on `http://www.example.com`
* Your SignalR app is hosted on `http://signalr.example.com`

CORS should be configured in the SignalR app to only allow the origin `www.example.com`.

For more information on configuring CORS, see [Enable Cross-Origin Requests (CORS)](xref:security/cors). SignalR requires the following CORS policies in order to operate correctly:

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

## WebSocket Origin Restriction

The protections provided by CORS don't apply to WebSockets. Browsers do **not**:

* Perform CORS pre-flight requests.
* Respect the restrictions specified in `Access-Control` headers when making WebSocket requests.

However, browsers do send the `Origin` header when issuing WebSocket requests.  Applications should be configured to validate these headers in order to ensure that only WebSockets coming from the origins you expect are allowed.

In ASP.NET Core 2.1, header validation can be achieved using a custom middleware placed **above `UseSignalR`, and any authentication middleware** in `Configure`:

```csharp
// In Startup, add a static field listing the allowed Origin values:
private static readonly HashSet<string> _allowedOrigins = new HashSet<string>()
{
    // Add allowed origins here. For example:
    "http://www.mysite.com",
    "http://mysite.com",
};

// Validate Origin header in Configure
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

        // The request is a valid Origin or not a WebSocket request, so continue.
        return next();
    });

    // ... other middleware ...

    app.UseSignalR();

    // ... other middleware ...
}
```

> [!NOTE]
> The `Origin` header is completely controlled by the client and, like the `Referer` header, can be faked. These headers should never be used as an authentication mechanism.

## Access token logging

When using WebSockets or Server-Sent Events, the browser client sends the access token in the query string. Receiving the access token via query string is generally as secure as using the standard `Authorization` header. However, many web servers log the URL for each request, including the query string. Logging the URLs may log the access token. A best practice is to set the web server's logging settings to prevent logging access tokens.

## Exceptions

Exception messages are generally considered sensitive data that shouldn't be revealed to a client. By default, SignalR doesn't send the details of an exception thrown by a hub method to the client. Instead, the client receives a generic message indicating an error occurred. You can override this behavior by setting the [`EnableDetailedErrors`](xref:signalr/configuration#configure-server-options) setting.

## Buffer management

SignalR uses per-connection buffers to manage incoming and outgoing messages. By default, SignalR limits these buffers to 32KB. The largest message a client or server can send is 32KB. The maximum memory consumed by a connection for messages is 32KB. If your messages are always smaller than than 32K, you can reduce the limit, which:

* Prevents a client from being able to send a larger message.
* The server will never need to allocate large buffers to accept messages.

If your messages are larger than 32K, you can increase the limit. Increasing this limit means:

* The client can cause the server to allocate large memory buffers.
* Server allocation of large buffers may reduce the number of concurrent connections.

There are limits for incoming and outgoing messages, both can be configured on the [`HttpConnectionDispatcherOptions`](xref:signalr/configuration#configure-server-options) object configured in `MapHub`:

* `ApplicationMaxBufferSize` represents the maximum number of bytes from the client that the server buffers. If the client attempts to send a message larger than this limit, the connection may be closed.
* `TransportMaxBufferSize` represents the maximum number of bytes the server can send. If the server attempts to send a message (including return values from hub methods) larger than this limit, an exception will be thrown.

Setting the limit to `0` disables the limit. However, disabling the limit should be done with extreme caution. Removing the limit allows a client to send a message of any size. Sending large messages could be used by a malicious client to cause excess memory to be allocated.  Excess memory usage can dramatically reduce the number of concurrent connections an app can support.
