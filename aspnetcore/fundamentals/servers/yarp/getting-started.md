---
uid: fundamentals/servers/yarp/getting-started
title: YARP Getting Started with YARP
description: YARP Getting Started with YARP
author: samsp-msft
ms.author: samsp
ms.date: 3/6/2025
ms.topic: article
content_well_notification: AI-contribution
ai-usage: ai-assisted
---
# Getting started with YARP

YARP is designed as a library that provides the core proxy functionality, which you can customize by adding or replacing modules. YARP is currently provided as a NuGet package and code samples. We plan on providing a project template and prebuilt executable (`.exe`) in the future.

YARP is implemented on top of .NET Core infrastructure and is usable on Windows, Linux or MacOS. Development can be done with the SDK and your favorite editor, [Microsoft Visual Studio](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/).

YARP 2.3.0 supports .NET 8 or later.

You can download the .NET SDK from https://dotnet.microsoft.com/download/dotnet/.

## Create a new project

A complete version of the project built using the steps below can be found at [Basic YARP Sample](https://github.com/microsoft/reverse-proxy/tree/release/latest/samples/BasicYarpSample).

Start by creating an empty ASP.NET Core application using the command line:

```dotnetcli
dotnet new web -n MyProxy
```

Alternatively, create a new ASP.NET Core web application in Visual Studio 2022, choosing "Empty" for the project template.

## Add the package reference

Add a package reference for [`Yarp.ReverseProxy`](https://www.nuget.org/packages/Yarp.ReverseProxy), version 2.3.0 or later.

```dotnetcli
dotnet add package Yarp.ReverseProxy
```

[!INCLUDE[](~/includes/package-reference.md)]

## Add the YARP Middleware

Update the `Program` file to use the YARP Middleware:

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
var app = builder.Build();
app.MapReverseProxy();
app.Run();
```

## Configuration 

The configuration for YARP is defined in the `appsettings.json` file. For more information, see <xref:fundamentals/servers/yarp/config-files>.

The configuration can also be provided programmatically. For more information, see <xref:fundamentals/servers/yarp/config-providers>.

Learn more about the available configuration options by looking at <xref:Yarp.ReverseProxy.Configuration.RouteConfig> and <xref:Yarp.ReverseProxy.Configuration.ClusterConfig>.
 
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

## Run the project

When using the .NET CLI, use `dotnet run` within the sample's directory or `dotnet run --project <path to .csproj file>`.

In Visual Studio, start the app by clicking the **Run** button.
