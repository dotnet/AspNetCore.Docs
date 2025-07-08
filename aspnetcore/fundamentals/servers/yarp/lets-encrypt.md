---
uid: fundamentals/servers/yarp/lets-encrypt
title: YARP Lets Encrypt
description: YARP Lets Encrypt
author: samsp-msft
monikerRange: '<= aspnetcore-7.0'
ms.author: samsp
$106/14/2025
ms.topic: article
content_well_notification: AI-contribution
ai-usage: ai-assisted
---
# YARP Lets Encrypt

> [!NOTE]
> The [`LettuceEncrypt` NuGet package](https://github.com/natemcmaster/LettuceEncrypt) described in this article is archived and no longer supported, so the package isn't recommended for use.

## Introduction

YARP can support the certificate authority [Lets Encrypt](https://letsencrypt.org/) by using the API of another ASP.NET Core project, [`LettuceEncrypt`](https://github.com/natemcmaster/LettuceEncrypt). It allows you to set up TLS between the client and YARP with minimal configuration.

## Requirements

Add the `LettuceEncrypt` package dependency:

```csproj
<PackageReference Include="LettuceEncrypt" Version="1.1.2" />
```

## Configuration

There are required options for `LettuceEncrypt` that should be set. See the example of `appsettings.json`:

```json
{
  "Urls": "http://*:80;https://*:443",

  "Logging": { ... },

  "ReverseProxy": {
    "Routes": { ... },
    "Clusters": { ... }
  },

  "LettuceEncrypt": {
    // Set this to automatically accept the terms of service of your certificate 
    // authority.
    // If you don't set this in config, you will need to press "y" whenever the 
    // application starts
    "AcceptTermsOfService": true,

    // You must specify at least one domain name
    "DomainNames": [ "example.com" ],

    // You must specify an email address to register with the certificate authority
    "EmailAddress": "it-admin@example.com"
  }
}
```

## Update Services

```csharp
services.AddLettuceEncrypt();
```

For more options (for example, saving certificates) see the examples in the [`LettuceEncrypt` project README](https://github.com/natemcmaster/LettuceEncrypt).

## Kestrel Endpoints

If your project is explicitly using Kestrel options to configure IP addresses, ports, or HTTPS settings, call `UseLettuceEncrypt`:

Example:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(kestrel =>
{
    kestrel.ListenAnyIP(443, portOptions =>
    {
        portOptions.UseHttps(h =>
        {
            h.UseLettuceEncrypt(kestrel.ApplicationServices);
        });
    });
});
```
