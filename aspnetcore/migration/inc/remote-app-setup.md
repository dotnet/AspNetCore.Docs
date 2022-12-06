---
title: Remote app setup
description: Remote app setup
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-6.0'
ms.date: 11/9/2022
ms.topic: article
ms.prod: aspnet-core
uid: migration/inc/remote-app-setup
---

# Remote app setup

In some incremental upgrade scenarios, it's useful for the new ASP.NET Core app to be able to communicate with the original ASP.NET app.

Specifically, this capability is used, currently, for [remote app authentication](xref:migration/inc/remote-authentication) and [remote session](xref:migration/inc/remote-session) features.

## Configuration

To enable the ASP.NET Core app to communicate with the ASP.NET app, it's necessary to make a couple small changes to each app.

### ASP.NET app configuration

To set up the ASP.NET app to be able to receive requests from the ASP.NET Core app, call the `AddRemoteApp` extension method on the `ISystemWebAdapterBuilder` as shown here.

```CSharp
SystemWebAdapterConfiguration.AddSystemWebAdapters(this)
    .AddRemoteAppServer(options =>
    {
        // ApiKey is a string representing a GUID
        options.ApiKey = ConfigurationManager.AppSettings["RemoteAppApiKey"];
    });
```

In the options configuration method passed to the `AddRemoteApp` call, you must specify an API key which is used to secure the endpoint so that only trusted callers can make requests to it (this same API key will be provided to the ASP.NET Core app when it is configured). The API key is a string and must be parsable as a GUID (128-bit hex number). Hyphens in the key are optional.

### ASP.NET Core app

To set up the ASP.NET Core app to be able to send requests to the ASP.NET app, you need to make a similar change, calling `AddRemoteApp` after registering System.Web adapter services with `AddSystemWebAdapters`.

```CSharp
builder.Services.AddSystemWebAdapters()
    .AddRemoteAppClient(options =>
    {
        options.RemoteAppUrl = new(builder.Configuration["ReverseProxy:Clusters:fallbackCluster:Destinations:fallbackApp:Address"]);
        options.ApiKey = builder.Configuration("RemoteAppApiKey");
    });
```

In the preceding code:

* The `AddRemoteApp` call is used to configure the remote app's URL and the shared secret API key.
* The `RemoteAppUrl` property specifies the URL of the ASP.NET Framework app that the ASP.NET Core app communicates with. In this example, the URL is read from an existing configuration setting used by the YARP proxy that proxies requests to the ASP.NET Framework app as part of the incremental migration's *strangler fig pattern*.

With both the ASP.NET and ASP.NET Core app updated, extension methods can now be used to set up [remote app authentication](xref:migration/inc/remote-authentication) or [remote session](xref:migration/inc/remote-session), as needed.

## Securing the remote app connection

Because remote app features involve serving requests on new endpoints from the ASP.NET app, it's important that communication to and from the ASP.NET app be secure.

First, make sure that the API key string used to authenticate the ASP.NET Core app with the ASP.NET app is unique and kept secret. It is a best practice to not store the API key in source control. Instead, load it at runtime from a secure source such as Azure Key Vault or other secure runtime configuration. In order to encourage secure API keys, remote app connections require that the keys be non-empty GUIDs (128-bit hex numbers).

Second, because it's important for the ASP.NET Core app to be able to trust that it is requesting information from the correct ASP.NET app, the ASP.NET app should use HTTPS in any production scenarios so that the ASP.NET Core app can know responses are being served by a trusted source.
