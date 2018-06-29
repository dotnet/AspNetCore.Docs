---
title: Security Considerations in ASP.NET Core SignalR
author: rachelappel
description: Learn how to use authentication and authorization in ASP.NET Core SignalR.
monikerRange: '>= aspnetcore-2.1'
ms.author: rachelap
ms.custom: mvc
ms.date: 06/29/2018
uid: signalr/security
---

# Security Concepts in ASP.NET Core SignalR

By [Andrew Stanton-Nurse](https://twitter.com/anurse)

## Overview

SignalR provides a number of security protections by default, but it is important to understand their limitations.

### Cross-Origin Resource Sharing

[Cross-origin resource sharing](https://en.wikipedia.org/wiki/Cross-origin_resource_sharing) can be used to allow cross-origin SignalR connections in the browser. If your JavaScript code is hosted on a different domain name from your SignalR app, you will have to enable the [ASP.NET Core CORS middleware](xref:security/cors) in order to allow the connection. In general, allow cross-origin requests only from domains you control. For example, if your site is hosted on `http://www.example.com` and your SignalR app is hosted on `http://signalr.example.com`, you should configure CORS in your SignalR app to only allow the origin `www.example.com`.

For more information on configuring CORS, see [the documentation on ASP.NET Core CORS](xref:security/cors). SignalR requires the following CORS policies in order to operate correctly:

* The policy must allow the specific origins you expect, or allow any origin (not recommended).
* HTTP methods `GET` and `POST` must be allowed.
* Credentials must be enabled, even when you are not using authentication.

For example, the following CORS policy will allow a SignalR browser client hosted on `http://example.com` to access your SignalR app:

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

### Access Token Logging

Due to limitations in browser APIs, when using WebSockets or Server-Sent Events, the access token must be specified in the query string. This is generally as secure as using the standard `Authorization` header, however many web servers log the URL for each request, including the query string. This means the access token may be included in logs. Consider reviewing the web server's logging settings to avoid logging this information.

### Exceptions

Exception messages are generally considered sensitive data that should not be revealed to a client. By default SignalR doesn't send the details of an exception thrown by a hub method to the client. Instead, the client receives a generic message indicating an error occurred. You can override this behavior by setting the [`EnableDetailedErrors` setting](xref:signalr/configuration#configure-server-options).

### Buffer management

TODO!