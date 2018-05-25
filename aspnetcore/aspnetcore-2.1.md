---
title: What's new in ASP.NET Core 2.01
author: isaac2004
description: Learn about the new features in ASP.NET Core 2.1.
manager: wpickett
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.date: 5/29/2018
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: aspnetcore-2.1
---
# What's new in ASP.NET Core 2.1

This article highlights the most significant changes in ASP.NET Core 2.1, with links to relevant documentation.

## SignalR

SignalR has been ported to ASP.NET Core 2.1 to support real-time web scenarios. ASP.NET Core SignalR will also include a number of improvements, including a simplified scale-out model, a new JavaScript client with no jQuery dependency, a new compact binary protocol based on MessagePack, support for custom protocols, a new streaming response model, and support for clients based on bare WebSockets.

For more information, see [ASP.NET Core SignalR](xref:signalr/index)

## Razor class libraries

ASP.NET Core 2.1 makes it easier to build and include Razor-based UI in a library and share it across multiple projects. The new Razor SDK enables building Razor files into a class library project that can be packaged into a NuGet package. Views and pages in libraries are automatically discovered and can be overridden by the application. By integrating Razor compilation into the build:

* The app startup time is significantly faster.
* Fast updates to  Razor views and pages at runtime are still available as part of an iterative development workflow.

For more information, see [ASP.NET Core Razor SDK](xref:mvc/razor-pages/sdk)

## Identity UI library & scaffolding

### Identity as a library

ASP.NET Core Identity provides a framework for setting up authentication and identity concerns for a website, including user registration, managing passwords, two-factor authentication, social logins and much more.

For ASP.NET Core 2.1 a default identity UI implementation as a library will be provided. The default identity UI can be added to an app by enabling it in `Startup`:

[!code-csharp[Main](aspnetcore-2.1/sample/Startup.cs?name=snippet&highlight=15,39)]

### Identity scaffolder

ASP.NET Core 2.1 and later provides [ASP.NET Core Identity](xref:security/authentication/identity) as a [Razor Class Library](xref:mvc/razor-pages/ui-class). Applications that include Identity can apply the scaffolder to selectively add the source code contained in the Identity Razor Class Library (RCL). You might want to generate source code so you can modify the code and change the behavior. For example, you could instruct the scaffolder to generate the code used in registration. Generated code takes precedence over the same code in the Identity RCL.

Applications that do **not** include authentication can apply the scaffolder to add the RCL Identity package. You have the option of selecting Identity code to be generated.

For more information, see [Scaffold Identity in ASP.NET Core projects](xref:security/authentication/scaffold-identity)

## HTTPS

With the increased focus on security and privacy, enabling HTTPS for web apps is more important than ever before. HTTPS enforcement is becoming increasingly strict on the web. Sites that don’t use HTTPS are considered insecure. Browsers are starting to enforce that many new and existing web features must only be used from a secure context (Chromium, Mozilla). GDPR requires the use of HTTPS to protect user privacy. While using HTTPS in production is critical, using HTTPS during development can also help prevent related issues before deployment, like insecure links. For more information see:

* [HTTP Strict Transport Security Protocol (HSTS)](xref:security/enforcing-ssl#http-strict-transport-security-protocol-hsts)
* [Require HTTPS](xref:security/enforcing-ssl#require-https)

### On by default

To facilitate secure website development, HTTPS in ASP.NET Core 2.1 is now enabled by default. Starting in 2.1, Kestrel will listen on https://localhost:5001 when a local development certificate is present. A certificate will be created:

* When the .NET Core SDK is installed.  Run `dotnet dev-certs https --trust`.
* By manually set up using the new `dev-certs` tool. 

The project templates have updated to:

* [Require HTTPS](xref:security/enforcing-ssl#require-https) by default.
* Include HTTPS redirection and [HTTP Strict Transport Security Protocol (HSTS)](xref:security/enforcing-ssl#http-strict-transport-security-protocol-hsts).

### HTTPS redirection and enforcement

Web apps typically need to listen on both HTTP and HTTPS, but then redirect all HTTP traffic to HTTPS. ASP.NET Core 2.0 has URL rewrite middleware that can be used for this purpose, but there are challenges to configure this redirection. In 2.1, specialized HTTPS redirection middleware that intelligently redirects based on the presence of configuration or bound server ports has been introduced.

Use of HTTPS can be further enforced using [HTTP Strict Transport Security Protocol (HSTS)](xref:security/enforcing-ssl#http-strict-transport-security-protocol-hsts). HSTS  instructs browsers to always access the site via HTTPS. ASP.NET Core 2.1 adds HSTS middleware that supports options for max age, subdomains, and the HSTS preload list.

### Configuration for production

In production, HTTPS must be explicitly configured. In 2.1 default configuration schema for configuring HTTPS for Kestrel has been added. Applications can be configured to use:

* Multiple endpoints including the URLs.
* The certificate to use for HTTPS either from a file on disk or from a certificate store.

## GDPR

ASP.NET Core provides APIs and templates to help meet some of the [UE General Data Protection Regulation (GDPR)](https://www.eugdpr.org/) requirements:

* The project templates include extension points and stubbed markup you can replace with your privacy and cookie use policy.
* A cookie consent feature allows you to ask for (and track) consent from your users for storing personal information. If a user has not consented to data collection and the app is set with [CheckConsentNeeded](/dotnet/api/microsoft.aspnetcore.builder.cookiepolicyoptions.checkconsentneeded?view=aspnetcore-2.1#Microsoft_AspNetCore_Builder_CookiePolicyOptions_CheckConsentNeeded) to `true`, non-essential cookies will not be sent to the browser.
* Cookies can be marked as essential. Essential cookies are sent to the browser even when the user has not consented and tracking is disabled.
* [TempData and Session cookies](xref:security/gdpr#tempdata) are not functional when tracking is disabled.
* The [Identity manage](xref:security/gdpr#pd) page provides a link to download and delete user data.

A [sample app](https://github.com/aspnet/Docs/tree/live/aspnetcore/security/gdpr/sample) lets you test most of the GDPR extension points and APIs added to the ASP.NET Core 2.1 templates. See the [ReadMe](https://github.com/aspnet/Docs/tree/live/aspnetcore/security/gdpr/sample) file for testing instructions.

For more information, see [EU General Data Protection Regulation (GDPR) support in ASP.NET Core](xref:security/gdpr)

## MVC functional testing

In ASP.NET Core 2.1, a text fixture has been provided to better handle the complexity of performing functional tests against an MVC app using [TestServer](xref:testing/integration-testing), such as:

* Copying the .deps file from your project into the test assembly bin folder.
* Setting the content root the application's project root so that static files and views can be found.
* Setting up the application on TestServer

An implementation of the new test fixture with [xUnit](https://xunit.github.io/) would look like this

```csharp
using Xunit;
namespace MyApplication.FunctionalTests
{
    public class MyApplicationFunctionalTests : IClassFixture<WebApplicationTestFixture<Startup>>
    {
        public MyApplicationFunctionalTests(WebApplicationTestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task GetHomePage()
        {
            // Arrange & Act
            var response = await Client.GetAsync("/");
            // Assert
            Assert.Equal(HttpStatusCodes.OK, response.StatusCode);
        }
    }
}
```

For more information, see the [Announcement on GitHub](https://github.com/aspnet/announcements/issues/275)

## [ApiController], ActionResult

In ASP.NET Core 2.1, improved support for OpenAPI specification(previously known as **Swagger**)) has been added to Web API. `ActionResult<T>` is a new type added to allow an application to return either a response type or any other action result (similar to IActionResult), while still indicating the response type. The `[ApiController] attribute has also been added as the way to opt-in to Web API-specific conventions and behaviors.

For more information, see [Build wbe APIs with ASP.NET Core](xref:web-api)

## IHttpClientFactory

The new `HttpClientFactory` type can be registered and used to configure and consume instances of HttpClient in applications. HttpClient already has the concept of delegating handlers that could be linked together for outgoing HTTP requests. The factory will make registering of these per named client more intuitive as well as implement a Polly handler that allows Polly policies to be used for Retry, CircuitBreakers, etc.

For more information, see [Initiate HTTP Requests](xref:fundamentals/http-requests)

## Kestrel on Sockets

In ASP.NET Core 2.1, a new socket transport has been added to Kestrel. An application can be configured to use this new transport by adding the `.UseSockets()` extension to the `HostBuilder`

```csharp
public static IWebHost BuildWebHost(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
    .UseSockets()
    .UseStartup<Startup>()
 ```

## Generic host builder

In ASP.NET Core 2.1, the Generic Host Builder (`HostBuilder`) has been introduced. This Builder can be used for applications that do not process HTTP requests (Messaging, background tasks, etc).

For more information, see [.NET Generic Host](xref:fundamentals/host/generic)

## Updated SPA templates

In ASP.NET Core 2.1, the Single Page Application Templates for Angular, React, and React with Redux have been updated to account for changes in the architecture of each framework. 
For more information, see [Use the Single Page Application templates with ASP.NET Core](xref:spa)

## Microsoft.AspNetCore.App package

ASP.NET Core 2.1 introduces a new `Microsoft.AspNetCore.App` meta-package. The new meta-package differs from the existing meta-package in that it reduces the number of dependencies of packages not owned or supported by the ASP.NET or .NET teams to just those deemed necessary to ensure the major framework features function. For more information, see [Microsoft.AspNetCore.App metapackage for ASP.NET Core 2.1](fundamentals/metapackage-app).

The `existing Microsoft.AspNetCore.All` meta-package will continue to be made available throughout the 2.x lifecycle. For additional details, see https://github.com/aspnet/Announcements/issues/287.

## Potentially breaking changes

See [SetCompatibilityVersion](xref:fundamentals/startup#setcompatibilityversion-for-asp.net-core-mvc). The [MvcOptions](https://github.com/aspnet/Mvc/blob/dev/src/Microsoft.AspNetCore.Mvc.Core/MvcOptions.cs) class source comments have a good explanation of the potential breaking changes and why the changes are an improvement for most users.

## Other documentation updates for 2.0

* TO DO add more

## Migrate from 2.0 to 2.1

See [Migrate from ASP.NET Core 2.0 to 2.1](xref:migration/20-to-21).

## Additional Information

For the complete list of changes, see the [ASP.NET Core 2.0 Release Notes](https://github.com/aspnet/Home/releases/tag/2.0.0).

To connect with the ASP.NET Core development team's progress and plans, tune in to the [ASP.NET Community Standup](https://live.asp.net/).