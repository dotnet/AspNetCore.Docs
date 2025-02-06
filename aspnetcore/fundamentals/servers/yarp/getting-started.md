---
uid: getting-started
title: Getting Started with YARP
---

# Getting Started with YARP

YARP is designed as a library that provides the core proxy functionality which you can then customize by adding or replacing modules.
YARP is currently provided as a NuGet package and code snippets.
We plan on providing a project template and pre-built exe in the future.

YARP is implemented on top of .NET Core infrastructure and is usable on Windows, Linux or MacOS.
Development can be done with the SDK and your favorite editor, [Microsoft Visual Studio](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/).

YARP 2.1.0 supports ASP.NET Core 6.0 and newer, including ASP.NET Core 8.0.
You can download the .NET SDK from https://dotnet.microsoft.com/download/dotnet/.

Visual Studio support for .NET 8 is included in Visual Studio 2022 17.8.

### Create a new project

A complete version of the project built using the steps below can be found at [Basic YARP Sample](https://github.com/microsoft/reverse-proxy/tree/release/latest/samples/BasicYarpSample).

Start by creating an "Empty" ASP.NET Core application using the command line:

```Console
dotnet new web -n MyProxy -f net8.0
```

Or create a new ASP.NET Core web application in Visual Studio 2022, and choose "Empty" for the project template. 

### Add the project reference

 ```XML
<ItemGroup> 
  <PackageReference Include="Yarp.ReverseProxy" Version="2.1.0" />
</ItemGroup> 
```

### Add the YARP Middleware

Update Program.cs to use the YARP middleware:

```C#
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
var app = builder.Build();
app.MapReverseProxy();
app.Run();
```

## Configuration 

The configuration for YARP is defined in the appsettings.json file. See [Configuration Files](config-files.md) for details.

The configuration can also be provided programmatically. See [Configuration Providers](config-providers.md) for details.

You can find out more about the available configuration options by looking at [RouteConfig](xref:Yarp.ReverseProxy.Configuration.RouteConfig) and [ClusterConfig](xref:Yarp.ReverseProxy.Configuration.ClusterConfig).
 
 ```JSON
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

### Running the project

Use `dotnet run` called within the sample's directory or `dotnet run --project <path to .csproj file>`
