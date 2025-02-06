# Lets Encrypt

## Introduction
YARP can support the certificate authority [Lets Encrypt](https://letsencrypt.org/) by using the API of another ASP.NET Core project [LettuceEncrypt](https://github.com/natemcmaster/LettuceEncrypt). It allows you to set up TLS between the client and YARP with minimal configuration.

## Requirements

Add the LettuceEncrypt package dependency:
```csproj
<PackageReference Include="LettuceEncrypt" Version="1.1.2" />
```

## Configuration
There are required options for LettuceEncrypt that should be set, see the example of `appsettings.json`:

```JSON
{
  "Urls": "http://*:80;https://*:443",

  "Logging": { ... },

  "ReverseProxy": {
    "Routes": { ... },
    "Clusters": { ... }
  },

  "LettuceEncrypt": {
    // Set this to automatically accept the terms of service of your certificate authority.
    // If you don't set this in config, you will need to press "y" whenever the application starts
    "AcceptTermsOfService": true,

    // You must specify at least one domain name
    "DomainNames": [ "example.com" ],

    // You must specify an email address to register with the certificate authority
    "EmailAddress": "it-admin@example.com"
  }
}
```

## Update Services

```C#
services.AddLettuceEncrypt();
```

For more options (i.e. saving certificates) see examples in [LettuceEncrypt doc](https://github.com/natemcmaster/LettuceEncrypt).

## Kestrel Endpoints

If your project is explicitly using kestrel options to configure IP addresses, ports, or HTTPS settings, you will also need to call `UseLettuceEncrypt`.

Example:

```C#
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

