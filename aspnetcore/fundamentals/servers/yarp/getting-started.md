---
uid: fundamentals/servers/yarp/getting-started
title: Get started with YARP
description: Get started with the YARP library that provides core proxy functionality, customize library modules, and create a project that uses the YARP package.
author: wadepickett
ms.author: wpickett
ms.date: 04/24/2026
ms.topic: concept-article
content_well_notification: AI-contribution
ai-usage: ai-assisted

# customer intent: As an ASP.NET developer, I want to get started with the YARP library, so I can learn how to customize the modules for my project.
---
# Get started with YARP

YARP is designed as a .NET library that provides core proxy functionality. You can customize the library by adding or replacing modules. YARP is currently provided as a NuGet package and code samples, but a project template and prebuilt executable (`.exe`) are planned for the future.

YARP is implemented on top of .NET infrastructure and is usable on Windows, Linux, or macOS. You can develop apps with the .NET SDK and your favorite editor: [Microsoft Visual Studio](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/).

YARP 2.3.0 supports .NET 8 or later. You can download the .NET SDK from https://dotnet.microsoft.com/download/dotnet/.

This article describes how to create a basic ASP.NET Core app that uses the YARP library.

## Create a new project

Start by creating an empty ASP.NET Core app from the command line:

```dotnetcli
dotnet new web -n MyProxy
```

Or, build a new ASP.NET Core web app in Visual Studio 2022 by selecting **Empty** for the project template.

> [!NOTE]
> For the complete version of the project implemented in this article, download the [Basic YARP Sample](https://github.com/dotnet/yarp/tree/release/latest/samples/BasicYarpSample) on GitHub.

## Add the YARP package reference

Add a package reference for [Yarp.ReverseProxy](https://www.nuget.org/packages/Yarp.ReverseProxy) version 2.3.0 or later.

```dotnetcli
dotnet add package Yarp.ReverseProxy
```

[!INCLUDE[](~/includes/package-reference.md)]

## Add the YARP middleware

Update the _Program.cs_ file to use the YARP middleware:

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
var app = builder.Build();
app.MapReverseProxy();
app.Run();
```

## Customize the YARP configuration 

The configuration for YARP is defined in the _appsettings.json_ file. For more information, see [YARP configuration files](xref:fundamentals/servers/yarp/config-files).

You can also specify the configuration programmatically. For more information, see [YARP extensibility: Configuration providers](xref:fundamentals/servers/yarp/config-providers).

To learn more about the available configuration options, see the <xref:Yarp.ReverseProxy.Configuration.RouteConfig> and <xref:Yarp.ReverseProxy.Configuration.ClusterConfig> reference articles.
 
```json
 {
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ReverseProxy": {
    "Routes": {
      "route1" : {
        "ClusterId": "cluster1",
        "Match": {
          "Path": "{**catch-all}"
        }
      }
    },
    "Clusters": {
      "cluster1": {
        "Destinations": {
          "destination1": {
            "Address": "https://example.com/"
          }
        }
      }
    }
  }
}
```

## Run your YARP project application

To run your new YARP project:

- **.NET CLI**: Run the `dotnet run` command within the sample's directory, or use the `dotnet run --project <path to .csproj file>` command.

- **Visual Studio**: Start the app by selecting **Run** on the main menubar.

## Related content

- [Basic YARP sample on GitHub](https://github.com/dotnet/yarp/tree/release/latest/samples/BasicYarpSample)
- [YARP Configuration Files](xref:fundamentals/servers/yarp/config-files)
- [YARP extensibility: Configuration providers](xref:fundamentals/servers/yarp/config-providers)