---
title: Handle errors in Minimal API apps
author: brunolins16
description: Learn about error handling with minimal APIs in ASP.NET Core.
ms.author: brolivei
monikerRange: '>= aspnetcore-7.0'
ms.date: 10/24/2022
uid: fundamentals/minimal-apis/handle-errors
---

# How to handle errors in Minimal API apps

## Exception handler

TODO

## Problem details

While [Problem Details for HTTP APIs](https://www.rfc-editor.org/rfc/rfc7807.html) are not the only response format for HTTP APIs error, they are commonly used to report errors.

In Minimal API apps can be configured to generate problem details response for all HTTP client and server error responses that ***don't have a body content yet*** using the [`AddProblemDetails`](/dotnet/api/microsoft.extensions.dependencyinjection.problemdetailsservicecollectionextensions.addproblemdetails?view=aspnetcore-7.0&preserve-view=true) extension method on <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>.

The following code configures the app to generate a problem details:

``` c#
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Route handler endpoints goes here


app.Run();
```

For more information on using [`AddProblemDetails`](/dotnet/api/microsoft.extensions.dependencyinjection.problemdetailsservicecollectionextensions.addproblemdetails?view=aspnetcore-7.0&preserve-view=true), see [Problem Details](aspnetcore/fundamentals/error-handling#pds7)
