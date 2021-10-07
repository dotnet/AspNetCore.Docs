---
title: Code samples migrated from ASP.NET Core 5.0 to 6.0
author: rick-anderson
description: Learn how to migrate an ASP.NET Core 5.0 project to ASP.NET Core 6.0.
ms.author: riande
ms.date: 10/15/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: migration/50-to-60-samples
---
# Code samples migrated from ASP.NET Core 5.0 to 6.0

This article provides samples of code migrated from ASP.NET Core 5.0  to ASP.NET Core 6.0.

## Add middleware

The following example adds static file middleware to an ASP.NET Core 5 app:

```csharp
public class Startup
{
    public void Configure(IApplicationBuilder app)
    {
        app.UseStaticFiles();
    }
}
```

The following example adds static file middleware to an ASP.NET Core 6 app:

[!code-csharp[](50-to-60-samples/samples/Web6Samples/Program.cs?name=snippet_mid)]
