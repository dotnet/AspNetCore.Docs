---
title: HttpSys web server implementation in ASP.NET Core
author: rick-anderson
description: Introduces HttpSys, a web server for ASP.NET Core on Windows. Built on the Http.Sys kernel mode driver, HttpSys is an alternative to Kestrel that can be used for direct connection to the Internet without IIS.
keywords: ASP.NET Core, HttpSys, HttpListener, url prefixes, SSL 
ms.author: riande
manager: wpickett
ms.date: 08/07/2017
ms.topic: article
ms.assetid: 0a7286e4-6428-424e-b5c4-5c98815cf61c
ms.technology: aspnet
ms.prod: asp.net-core
uid: fundamentals/servers/HttpSys
---
# HttpSys web server implementation in ASP.NET Core

By [Tom Dykstra](http://github.com/tdykstra) and [Chris Ross](https://github.com/Tratcher)

> [!NOTE]
> This topic applies only to ASP.NET Core 2.0 and later. In earlier versions of ASP.NET Core, HttpSys is named [WebListener](WebListener.md).

HttpSys is a [web server for ASP.NET Core](index.md) that runs only on Windows. It's built on the [Http.Sys kernel mode driver](https://msdn.microsoft.com/library/windows/desktop/aa364510.aspx). HttpSys is an alternative to [Kestrel](kestrel.md) that offers some features that Kestel doesn't. **HttpSys can't be used with IIS or IIS Express, as it isn't compatible with the [ASP.NET Core Module](aspnet-core-module.md).**

HttpSys supports the following features:

- [Windows Authentication](xref:security/authentication/windowsauth)
- Port sharing
- HTTPS with SNI
- HTTP/2 over TLS (Windows 10)
- Direct file transmission
- Response caching
- WebSockets (Windows 8)

Supported Windows versions:

- Windows 7 and Windows Server 2008 R2 and later

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/servers/httpsys/sample)

## When to use HttpSys

HttpSys is useful for deployments where you need to expose the server directly to the Internet without using IIS.

![HttpSys to Internet](httpsys/_static/httpsys-to-internet.png)

Because it's built on Http.Sys, HttpSys doesn't require a reverse proxy server for protection against attacks. Http.Sys is mature technology that protects against many kinds of attacks and provides the robustness, security, and scalability of a full-featured web server. IIS itself runs as an HTTP listener on top of Http.Sys. 

HttpSys is a good choice for internal deployments when you need a feature not available in Kestrel.

![HttpSys to Internet](httpsys/_static/httpsys-to-internal.png)

## How to use HttpSys

Here's an overview of setup tasks for the host OS and your ASP.NET Core application.

### Configure Windows Server

* Install the version of .NET that your application requires, such as [.NET Core](https://go.microsoft.com/fwlink/?LinkID=827524) or .NET Framework.

* Preregister URL prefixes to bind to HttpSys, and set up SSL certificates

   If you don't preregister URL prefixes in Windows, you have to run your application with administrator privileges. The only exception is if you bind to localhost using HTTP (not HTTPS) with a port number greater than 1024; in that case administrator privileges aren't required.

   For details, see [How to preregister prefixes and configure SSL](#preregister-url-prefixes-and-configure-ssl) later in this article.

* Open firewall ports to allow traffic to reach HttpSys.

   You can use netsh.exe or [PowerShell cmdlets](https://technet.microsoft.com/library/jj554906).

There are also [Http.Sys registry settings](https://support.microsoft.com/kb/820129).

### Configure your ASP.NET Core application

* No package install is needed if you use the [Microsoft.AspNetCore.All](xref:fundamentals/metapackage) metapackage. The [Microsoft.AspNetCore.Server.HttpSys](https://www.nuget.org/packages/Microsoft.AspNetCore.Server.HttpSys/) package is included in the metapackage.

* Call the `UseHttpSys` extension method on `WebHostBuilder` in your `Main` method, specifying any HttpSys [options](https://github.com/aspnet/HttpSysServer/blob/rel/2.0.0/src/Microsoft.AspNetCore.Server.HttpSys/HttpSysOptions.cs) that you need, as shown in the following example:

  [!code-csharp[](HttpSys/sample/Program.cs?name=snippet_Main&highlight=13-18)]

* Configure URLs and ports to listen on 

  By default ASP.NET Core binds to `http://localhost:5000`. To configure URL prefixes and ports, you can use the `UseUrls` extension method, the `urls` command-line argument, or the `UrlPrefixes` property on [HttpSysOptions](https://github.com/aspnet/HttpSysServer/blob/rel/2.0.0/src/Microsoft.AspNetCore.Server.HttpSys/HttpSysOptions.cs). The preceding code example uses `UrlPrefixes`.

  An advantage of `UrlPrefixes` is that you get an error message immediately if you try to add a prefix that is formatted wrong. An advantage of `UseUrls` is that you can more easily switch between Kestrel and HttpSys. (But this applies only if you don't use SSL, because you can't use SSL with `UseUrls` and Kestrel.)

  If you use both `UseUrls` and `UrlPrefixes`, the settings in `UrlPrefixes` override the ones in `UseUrls`. For more information, see [Hosting](xref:fundamentals/hosting).

  HttpSys uses the [Http.Sys prefix string formats](https://msdn.microsoft.com/library/windows/desktop/aa364698.aspx). There are no prefix string format requirements that are specific to HttpSys.

  > [!NOTE]
  > Make sure that you specify the same prefix strings in `UseUrls` or `UrlPrefixes` that you preregister on the server. 

* Make sure your application is not configured to run IIS or IIS Express.

  In Visual Studio, the default launch profile is for IIS Express.  To run the project as a console application, manually change the selected profile, as shown in the following screen shot.

  ![Select console app profile](HttpSys/_static/vs-choose-profile.png)

## Preregister URL prefixes and configure SSL

Both IIS and HttpSys rely on the underlying Http.Sys kernel mode driver to listen for requests and do initial processing. In IIS, the management UI gives you a relatively easy way to configure everything. However, if you're using HttpSys you need to configure Http.Sys yourself. The built-in tool for doing that is netsh.exe. 

With netsh.exe you can reserve URL prefixes and assign SSL certificates.

It's not an easy tool to use. The following example shows the minimum needed to reserve URL prefixes for ports 80 and 443:

```console
netsh http add urlacl url=http://+:80/ user=Users
netsh http add urlacl url=https://+:443/ user=Users
```

The following example shows how to assign an SSL certificate:

```console
netsh http add sslcert ipport=0.0.0.0:443 certhash=MyCertHash_Here appid={00000000-0000-0000-0000-000000000000}".
```

Here is the reference documentation for netsh.exe:

* [Netsh Commands for Hypertext Transfer Protocol (HTTP)](http://technet.microsoft.com/library/cc725882.aspx)
* [UrlPrefix Strings](https://msdn.microsoft.com/library/windows/desktop/aa364698.aspx)

The following resources provide detailed instructions for several scenarios. Articles that refer to `HttpListener` apply equally to `HttpSys`, as both are based on Http.Sys.

* [How to: Configure a Port with an SSL Certificate](http://msdn.microsoft.com/library/ms733791.aspx)
* [HTTPS Communication - HttpListener based Hosting and Client Certification](http://sunshaking.blogspot.com/2012/11/https-communication-httplistener-based.html) This is a third-party blog and is fairly old but still has useful information.
* [How To: Walkthrough Using HttpListener or Http Server unmanaged code (C++) as an SSL Simple Server](http://blogs.msdn.com/b/jpsanders/archive/2009/09/29/walkthrough-using-httplistener-as-an-ssl-simple-server.aspx) This too is an older blog with useful information.
* [How Do I Set Up A .NET Core HttpSys With SSL?](https://blogs.msdn.microsoft.com/timomta/2016/11/04/how-do-i-set-up-a-net-core-HttpSys-with-ssl/)

Here are some third-party tools that can be easier to use than the netsh.exe command line. These are not provided by or endorsed by Microsoft. The tools run as administrator by default, since netsh.exe itself requires administrator privileges.

* [HttpSysManager](http://httpsysmanager.codeplex.com/) provides UI for listing and configuring SSL certificates and options, prefix reservations, and certificate trust lists. 
* [HttpConfig](http://www.stevestechspot.com/ABetterHttpcfg.aspx) lets you list or configure SSL certificates and URL prefixes. The UI is more refined than HttpSysManager and exposes a few more configuration options, but otherwise it provides similar functionality. It cannot create a new certificate trust list (CTL), but can assign existing ones.

For generating self-signed SSL certificates, Microsoft provides command-line tools: [MakeCert.exe](https://msdn.microsoft.com/library/windows/desktop/aa386968) and the PowerShell cmdlet [New-SelfSignedCertificate](https://technet.microsoft.com/library/hh848633). There are also third-party UI tools that make it easier for you to generate self-signed SSL certificates:

* [SelfCert](https://www.pluralsight.com/blog/software-development/selfcert-create-a-self-signed-certificate-interactively-gui-or-programmatically-in-net)
* [Makecert UI](http://makecertui.codeplex.com/)

## Next steps

For more information, see the following resources:

* [Sample app for this article](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/servers/HttpSys/sample)
* [HttpSys source code](https://github.com/aspnet/HttpSysServer/)
* [Hosting](xref:fundamentals/hosting)
