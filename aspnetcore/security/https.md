---
title: Setting up HTTPS for development in ASP.NET Core
author: Rick-Anderson
description: Shows how to set up HTTPS for development in ASP.NET Core 2.0.
keywords: ASP.NET Core, SSL, HTTPS
ms.author: riande
manager: wpickett
ms.date: 05/10/2017
ms.topic: article
ms.assetid: 94f2f1a4-7d46-45e2-a085-a57916e41724
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/https
---
# Setting up HTTPS for development in ASP.NET Core

> [!NOTE] 
> This topic applies to ASP.NET Core 2.0 Preview 1

You can configure your application to use HTTPS during development to simulate HTTPS in your production environment. Enabling HTTPS may be required to enable integration with various identity providers (like [Azure AD](https://azure.microsoft.com/services/active-directory) and [Azure AD B2C](https://azure.microsoft.com/services/active-directory-b2c/)).

<a name="iisxpress"></a>

On Windows if you’ve installed Visual Studio or IIS Express, the IIS Express Development Certificate will be in your LocalMachine certificate store. You can update your project properties in Visual Studio to use this certificate when running behind IIS Express.

   * In Solution Explorer, right-click the project and select **Properties**.
   * On the left pane, select **Debug**.
   * Check **Enable SSL**
   * Copy the SSL URL and paste it into the **App URL**

![Debug tab of web application properties](enforcing-ssl/_static/ssl.png)

For development you can use the IIS Express Development Certificate if it is available, or create a new certificate for development purposes. The development certificate should be configured in the `appsettings.Development.json` file so that it is not used in production:

```json
{
  "Certificates": {
    "HTTPS": {
      "Source": "Store",
      "StoreLocation": "LocalMachine",
      "StoreName": "My",
      "Subject": "CN=localhost",
      "AllowInvalid": true
    }
  }
}
```

An app with this configuration running in production will throw an exception saying "No certificate named 'HTTPS' found in configuration for the current environment (Production)". To switch the [environment](xref:fundamentals/environments) to `Development`, set the `ASPNETCORE_ENVIRONMENT` environment variable to `Development`.

If you do not have the IIS Express Development Certificate installed, you can create a development certificate yourself. On Windows you can create a development certificate and add it to the trusted root store for the current user by running the following PowerShell commands in an elevated prompt:

```powershell
$cert = New-SelfSignedCertificate -Subject localhost -DnsName localhost -FriendlyName "ASP.NET Core Development" -KeyUsage DigitalSignature -TextExtension @("2.5.29.37={text}1.3.6.1.5.5.7.3.1") 
Export-Certificate -Cert $cert -FilePath cert.cer
Import-Certificate -FilePath cert.cer -CertStoreLocation cert:/CurrentUser/Root
```

<a name="OpenSSL"></a>

## Kestrel on  macOS and Linux

You can  configure Kestrel to listen over HTTPS by configuring an endpoint with the desired IP address, port, and certificate. The certificate can be configured inline, or in the top-level `Certificates` section and then referenced by name:

```json
{
  "Kestrel": {
    "Endpoints": {
      "LocalhostHttps": {
        "Address": "127.0.0.1",
        "Port": "43434",
        "Certificate": "HTTPS"
      }
    }
  }
}

```

On macOS and Linux you can create a self-signed certificate for HTTPS using [OpenSSL](https://www.openssl.org/):

```bash
openssl req -new -x509 -newkey rsa:2048 -keyout localhost.key -out localhost.cer -days 365 -subj /CN=localhost
openssl pkcs12 -export -out certificate.pfx -inkey localhost.key -in localhost.cer
```

Once the `certificate.pfx` file has been generated, configure the HTTPS certificate in your `appsettings.Development.json` file:

```json
{
  "Certificates": {
    "HTTPS": {
      "Source": "File",
      "Path": "certificate.pfx"
    }
  }
}
```

You will also need to specify the passphrase for the certificate by setting the “Certificates:HTTPS:Password” config property. Passwords should not be stored in plain text. See [Safe Storage of App Secrets During Development](app-secrets.md) for appropriate handling of the certificate passphrase.

On macOS you can [add the certificate to your keychain](https://support.apple.com/kb/PH20129?locale=en_US) and [change its trust settings](https://support.apple.com/kb/PH20127?locale=en_US&viewlocale=en_US) so that it is trusted for HTTPS during development. To add the certificate to your keychain (the equivalent of the `CurrentUser/My` store on Windows) run the following command:

```bash
security import certificate.pfx -k ~/Library/Keychains/login.keychain-db
```

And then to trust the certificate:

```bash
security add-trusted-cert localhost.cer
```

You can then configure your app to use this certificate in development like this:

```json
{
  "Certificates": {
    "HTTPS": {
      "Source": "Store",
      "StoreLocation": "CurrentUser",
      "StoreName": "My",
      "Subject": "CN=localhost",
      "AllowInvalid": true
    }
  }
}
```
