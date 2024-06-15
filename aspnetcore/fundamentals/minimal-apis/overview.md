---
title: Minimal APIs overview
author: JeremyLikness
description: An introduction to the fastest and easiest way to create web API endpoints with ASP.NET Core.
ms.author: jeliknes
monikerRange: '>= aspnetcore-6.0'
ms.date: 11/22/2022
uid: fundamentals/minimal-apis/overview
---
# Minimal APIs overview

Minimal APIs are a simplified approach for building fast HTTP APIs with  ASP.NET Core.
You can build fully functioning REST endpoints with minimal code and configuration. Skip traditional scaffolding and avoid unnecessary controllers by fluently declaring API routes and actions. For example, the following code creates an API at the root of the web app that returns the text, `"Hello World!"`.

```csharp
var app = WebApplication.Create(args);

app.MapGet("/", () => "Hello World!");

app.Run();
```

Most APIs accept parameters as part of the route.

```csharp 
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/users/{userId}/books/{bookId}", 
    (int userId, int bookId) => $"The user id is {userId} and book id is {bookId}");

app.Run();
```

That's all it takes to get started, but it's not all that's available. Minimal APIs support the configuration and customization needed to scale to multiple APIs, handle complex routes, apply authorization rules, and control the content of API responses. A good place to get started is <xref:tutorials/min-web-api>.

## Want to see some code examples?

For a full list of common scenarios with code examples, see <xref:fundamentals/minimal-apis>.

## Want to jump straight into your first project?

Build a minimal API app with our tutorial: <xref:tutorials/min-web-api>.
