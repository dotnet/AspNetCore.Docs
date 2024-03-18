---
title: Incremental migration of IHttpModules
description: Describes how to use the System.Web adapters to incrementally migrate IHttpModules
author: twsouthwick
ms.author: tasou
monikerRange: '>= aspnetcore-6.0'
ms.date: 3/11/2024
ms.topic: article
uid: migration/inc/http-modules
---

# ASP.NET to ASP.NET Core incremental IHttpModule migration

[Modules](../http-modules.md) are types that implement <xref:System.Web.IHttpModule> and are used in ASP.NET Framework to hook into the request pipeline at various events. In an ASP.NET Core application, these should ideally be migrated to middleware. However, there are times when this cannot be done. In order to support migration scenarios in which modules are required and cannot be moved to middleware, System.Web adapters support adding them to ASP.NET Core.

## IHttpModule Example

In order to support modules, an instance of <xref:System.Web.HttpApplication> must be available. If no custom <xref:System.Web.HttpApplication> is used, a default one will be used to add the modules to. Events declared in a custom application (including `Application_Start`) will be registered and run accordingly.

```csharp
using System.Web;
using Microsoft.AspNetCore.OutputCaching;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSystemWebAdapters()
    .AddHttpApplication<MyApp>(options =>
    {
        // Size of pool for HttpApplication instances. Should be what the expected concurrent requests will be
        options.PoolSize = 10;

        // Register a module (optionally) by name
        options.RegisterModule<MyModule>("MyModule");
    });

// Only available in .NET 7+
builder.Services.AddOutputCache(options =>
{
    options.AddHttpApplicationBasePolicy(_ => new[] { "browser" });
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthenticationEvents();

app.UseAuthorization();
app.UseAuthorizationEvents();

app.UseSystemWebAdapters();
app.UseOutputCache();

app.MapGet("/", () => "Hello World!")
    .CacheOutput();

app.Run();

class MyApp : HttpApplication
{
    protected void Application_Start()
    {
    }

    public override string? GetVaryByCustomString(System.Web.HttpContext context, string custom)
    {
        // Any custom vary-by string needed

        return base.GetVaryByCustomString(context, custom);
    }
}

class MyModule : IHttpModule
{
  public void Dispose()
  {
  }

  public void Init(HttpApplication application)
  {
    application.BeginRequest += (s, e) =>
    {
      // Handle events at the beginning of a request
    }

    application.AuthorizeRequest += (s, e) =>
    {
      // Handle events that need to be authorized
    }
  }
}
```

## Global.asax migration

This infrastructure can be used to migrate usage of `Global.asax` if needed. The source from `Global.asax` is a custom <xref:System.Web.HttpApplication> and the file can be included in you ASP.NET Core application. Since it is named `Global`, the following can be used to register it:

```csharp
builder.Services.AddSystemWebAdapters()
    .AddHttpApplication<Global>()
```

As long as the logic within it is available in ASP.NET Core, this approach can be used to incrementally migrate reliance on `Global.asax` to ASP.NET Core.

## Authentication/Authorization events

In order for the authentication and authorization events to run at the desired time, the following pattern should be used:

```csharp
app.UseAuthentication();
app.UseAuthenticationEvents();

app.UseAuthorization();
app.UseAuthorizationEvents();
```

If this is not done, the events will still run. However, it will be during the call of `.UseSystemWebAdapters()`.

## HTTP Module pooling

 Because modules and applications in ASP.NET Framework were assigned to a request, a new instance is needed for each request. However, since they can be expensive to create, they are pooled using <xref:Microsoft.Extensions.ObjectPool.ObjectPool`1>. In order to customize the actual lifetime of the <xref:System.Web.HttpApplication> instances, a custom pool can be used:

```csharp
services.TryAddSingleton<ObjectPool<HttpApplication>>(sp =>
{
  // Recommended to use the in-built policy as that will ensure everything is initialized correctly and is not intended to be replaced
  var policy = sp.GetRequiredService<IPooledOjbectPolicy<HttpApplication>>()

  // Can use any provider needed
  var provider = new DefaultObjectPoolProvider();

  // Use the provider to create a custom pool that will then be used for the application.
  return provider.Create(policy);
});
```

## Additional resources

* [HTTP Module Migration](../http-modules.md)
* [HTTP Handlers and HTTP Modules Overview](/iis/configuration/system.webserver/)