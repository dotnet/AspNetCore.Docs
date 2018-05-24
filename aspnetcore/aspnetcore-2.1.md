---
title: What's new in ASP.NET Core 2.01
author: isaac2004
description: Learn about the new features in ASP.NET Core 2.1.
manager: wpickett
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.date: 07/10/2017
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: aspnetcore-2.1
---
# What's new in ASP.NET Core 2.1

This article highlights the most significant changes in ASP.NET Core 2.0, with links to relevant documentation.

## SignalR

SignalR has been ported to ASP.NET Core 2.1 to support real-time web scenarios. ASP.NET Core SignalR will also include a number of improvements, including a simplified scale-out model, a new JavaScript client with no jQuery dependency, a new compact binary protocol based on MessagePack, support for custom protocols, a new streaming response model, and support for clients based on bare WebSockets.

For more information, see [ASP.NET Core SignalR](xref:signalr/index)

## Razor class libraries

ASP.NET Core 2.1 will make it easier to build and include Razor based UI in a library and share it across multiple projects. A new Razor SDK will enable building Razor files into a class library project that can then be packaged into a NuGet package. Views and pages in libraries will automatically be discovered and can be overridden by the application. By integrating Razor compilation into the build, the app startup time is also significantly faster, while still allowing for fast updates to your Razor views and pages at runtime as part of an iterative development workflow.

For more information, see [ASP.NET Core Razor SDK](xref:mvc/razor-pages/sdk)

## Identity UI library & scaffolding

### Identity as a library

ASP.NET Core Identity provides a framework for setting up authentication and identity concerns for a website, including user registration, managing passwords, two-factor authentication, social logins and much more.

For ASP.NET Core 2.1 a default identity UI implementation as a library will be provided. The default identity UI can be added to an application by installing a NuGet package and then enable it in **Startup**

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<IdentityDbContext>(options =>
        options.UseSqlite(
            Configuration.GetConnectionString("DefaultConnection"),
            sqlOptions => sqlOptions.MigrationsAssembly("WebApplication1")));

    services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<IdentityDbContext>()
        .AddDefaultUI()
        .AddDefaultTokenProviders();

    services.AddMvc()
        .AddRazorPagesOptions(options =>
        {
            options.Conventions.AuthorizeFolder("/Account/Manage");
            options.Conventions.AuthorizePage("/Account/Logout");
        });
}
```

### Identity scaffolder

The Identity scaffolder allows the packaging of identity code and the ability to change it to the needs of the application. The scaffolded identity code is generated in an identity specific area folder.

For more information, see [Scaffold Identity in ASP.NET Core projects](xref:security/authentication/scaffold-identity)

## HTTPS

With the increased focus on security and privacy, enabling HTTPS for web apps is more important than ever before. HTTPS enforcement is becoming increasingly strict on the web, and sites that don’t use it are considered, and increasingly labeled as, not secure. Browsers are starting to enforce that many new and existing web features must only be used from a secure context (Chromium, Mozilla). GDPR requires the use of HTTPS to protect user privacy. While using HTTPS in production is critical, using HTTPS during development can also help prevent related issues before deployment, like insecure links.

### On by default

To facilitate secure website development, HTTPS in ASP.NET Core 2.1 is now enabled by default. Starting in 2.1, in addition to listing on http://localhost:5000, Kestrel will listen on https://localhost:5001 when a local development certificate is present. A suitable certificate will be created when the .NET Core SDK is installed or can be manually setup using the new `dev-certs` tool. The project templates are also updated to run on HTTPS by default and include HTTPS redirection and HSTS support.

### HTTPS redirection and enforcement

Web apps typically need to listen on both HTTP and HTTPS, but then redirect all HTTP traffic to HTTPS. ASP.NET Core 2.0 has URL rewrite middleware that can be used for this purpose, but there are challenges to configure. In 2.1, specialized HTTPS redirection middleware that intelligently redirects based on the presence of configuration or bound server ports has been introduced.

Use of HTTPS can be further enforced using HTTP Strict Transport Security Protocol (HSTS), which instructs browsers to always access the site via HTTPS. ASP.NET Core 2.1 adds HSTS middleware that supports options for max age, subdomains, and the HSTS preload list.

### Configuration for production

In production, HTTPS must be explicitly configured. In 2.1 default configuration schema for configuring HTTPS for Kestrel have been introduced. Applications can be configured to use multiple endpoints including the URLs and the certificate to use for HTTPS either from a file on disk or from a certificate store

For more information, see [Enforce HTTPS in ASP.NET Core](xref:security/enforcing-ssl)

## GDPR

The ASP.NET Core 2.1 project templates include some extension points to help meet some UE General Data Protection Regulation (GDPR) requirements.

A new cookie consent feature will asks for (and track) consent from users for storing personal information. This can be combined with a new cookie feature where cookies can be marked as essential or non-essential. If a user has not consented to data collection, non-essential cookies will not be sent to the browser. Wording may need to be added on the UI prompt and a suitable privacy policy which matches the GDPR analysis performed, along with implementing the logic for determining under what conditions a given user should be asked for consent before writing non-essential cookies (the templates simply default to asking all users).

The ASP.NET Core Identity templates for individual authentication now have a UI to allow users to download personal data, along with the ability to delete account entirely. By default, these UI areas only return personal information from ASP.NET Core identity, and perform a delete on the identity tables. Any additional extensions to the identity schema will need to be configured to adhere to GDPR requirements.

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

In ASP.NET Core 2.1, improved support for OpenAPI specification(previously known as **Swaggger**)) has been added to Web API. `ActionResult<T>` is a new type added to allow an application to return either a response type or any other action result (similar to IActionResult), while still indicating the response type. The `[ApiController] attribute has also been added as the way to opt-in to Web API specific conventions and behaviors.

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

ASP.NET Core 2.1 will introduce a new meta-package for use by applications: `Microsoft.AspNetCore.App`. The new meta-package differs from the existing meta-package in that it reduces the number of dependencies of packages not owned or supported by the ASP.NET or .NET teams to just those deemed necessary to ensure the major framework features function. The `existing Microsoft.AspNetCore.All` meta-package will continue to be made available throughout the 2.x lifecycle. For additional details see https://github.com/aspnet/Announcements/issues/287.

## Other documentation updates for 2.0

* Should I put links here for other docs?

## Migration Guidance

To migrate an existing ASP.NET Core 2.0.x project to 2.1.0-rc1:

1. Open the project’s .csproj file and change the value of the `<TargetFramework>` element to `netcoreapp2.1` 
    * Projects targeting .NET Framework rather than .NET Core, e.g. `net471`, don’t need to do this
2. In the same file, update the versions of the various `<PackageReference>` elements for any `Microsoft.AspNetCore`, `Microsoft.Extensions`, and `Microsoft.EntityFrameworkCore` packages to `2.1.0`
3. In the same file, remove any references to `<DotNetCliToolReference>` elements for any `Microsoft.AspNetCore`, `Microsoft.VisualStudio`, and `Microsoft.EntityFrameworkCore` packages. These tools are now deprecated and are replaced by global tools.
4. In the same file, remove the `<DotNetCliToolReference>` elements for any `Microsoft.AspNetCore` packages. These have been replaced by global tools.

That should be enough to get the project building and running against 2.1. The following steps will change your project to use new code-based idioms that are recommended in 2.1

1. Open the *Program.cs* file
2. Rename the `BuildWebHost` method to `CreateWebHostBuilder`, change its return type to `IWebHostBuilder`, and remove the call to `.Build()` in its body
3. Update the call in Main to call the renamed `CreateWebHostBuilder` method like so: 

```csharp
CreateWebHostBuilder(args).Build().Run();
```

4. Open the *Startup.cs* file
5. In the `ConfigureServices` method, change the call to add MVC services to set the compatibility version to 2.1 like so:

```csharp
services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
```

6. In the `Configure` method, add a call to add the HSTS middleware after the exception handler middleware: 
```csharp
app.UseHsts();
```
7. Staying in the `Configure` method, add a call to add the HTTPS redirection middleware before the static files middleware:
```csharp
app.UseHttpsRedirection();
```
8. Open the project property pages (right-mouse click on project in Visual Studio Solution Explorer and select **Properties**)
9. Open the **Debug** tab and in the IIS Express profile, check the **Enable SSL** checkbox and save the changes
10. In you project file change any package reference to `Microsoft.AspNetCore.All` package to `Microsoft.AspNetCore.App` and add additional packages as needed to restore the your required dependency graph

> [!NOTE]
> Some projects might require more steps depending on the options selected when the project was created and modifications made to the project.

## Additional Information

For the complete list of changes, see the [ASP.NET Core 2.0 Release Notes](https://github.com/aspnet/Home/releases/tag/2.0.0).

To connect with the ASP.NET Core development team's progress and plans, tune in to the [ASP.NET Community Standup](https://live.asp.net/).
