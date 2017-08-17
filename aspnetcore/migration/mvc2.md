# Migrating From ASP.NET to ASP.NET Core 2.0

By [Isaac Levin](https://isaaclevin.com)

This article serves as a reference guide for migrating ASP.NET applications (MVC or Web API) to ASP.NET Core 2.0 (MVC or Web Api). Here you will find initial instructions helpful in moving your ASP>NET applications to ASP.NET Core 2.0. Additional articles cover migrating configuration and Identity code found in many ASP.NET MVC projects.

> [!IMPORTANT]
> This topic uses Visual Studio 2017 15.3 in order to complete it's steps. Please ensure that you have installed [Visual Studio 2017 15.3](https://www.visualstudio.com/vs/) before preceeding.

## Additional Resources
* [Porting Libraries to .NET Core](https://docs.microsoft.com/en-us/dotnet/core/porting/libraries)

## Key package changes
* Common assemblies and core equivalent (table or mapping diagram)
* Assemblies not supported in Core


## Target Frameworks

ASP.NET Core 2.0 applications give developers the benefit of being able to target .NET Core, .NET Framework, or a mix if needed. When targeting .NET Framework, the experience is similar to developing traditional .NET Framework Applications, with the added benefits that .NET Core provides (mentioned later in this document). Developers will still need to reference individual packages that are needed for thier development.

When targeting .NET Core, developers are able to leverage the ASP.NET Core metapackage, `Microsoft.AspNetCore.All`. `Microsoft.AspNetCore.All` is a nuget package that acts as a reference to multiple packages, including:
- All supported packages by the ASP.NET Core team (MVC, Razor, Identity, etc) 
- All supported packages by the Entity Framework Core team (CoreIdentity, SQLite, SQL Server, etc)
- Internal and 3rd-party dependencies used by ASP.NET Core and Entity Framework

Referencing .NET Core allows you to no longer reference each invidual package that is needed for your application, the metapackage handles that. The metapackage also leverages the .NET Core Runtime Sore, which contains all the needed assets to run ASP.NET 2.x applications. When the metapackage is used, no packages referenced in the metapackge are deployed with the application, because the Runtime Store has these assets precompiled to improve performance.

In previous versions of .NET Framework we would use [Portable Class Libraries](https://docs.microsoft.com/en-us/dotnet/standard/cross-platform/cross-platform-development-with-the-portable-class-library) to make applications cross-platform compatible. .NET Standard is the new thinking to the PCL concept, and ASP.NET Core uses .NET Standard to obtain it's standard set of Apis. With every new version of .NET Standard, more Apis will be added to the fold. The major benefit to this for ASP.NET Core, is the inclusion of the [NETStandard.Library](https://github.com/dotnet/standard/blob/master/netstandard/pkg/NETStandard.Library.dependencies.props) metapackage that will be referenced in `.csproj` upon creation of the project. So in the past when your `.csproj` would have multiple references to essential components of the Framework, when creating a new project in ASP.NET Core, the `.csproj` will only have one reference

```xml
  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.All" Version="2.0.0-preview2-final" />
  </ItemGroup>
  ```
  
  This package contains many commonly-used assemblies that would otherwise need to be referenced individually.
> [!NOTE]
> For a more in-depth reference to .NET Standard, read [.NET Standard](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)

## Project structure differences
The .csproj file structure has changed in ASP.NET Core. Some of the most notable changes include: M
- Most notably we no longer have to include files within the *.csproj* for them to be considered part of the project. This reduces the risk of merge conflicts when working on large teams as different features may been to add different files and conflict resolution isn't that great with XML.
- There are no more references to other projects using Guids, which adds more readability to the file in general. 
- Another interesting change is that we can now edit the `.csproj` without unloading it in Visual Studio

![Edit CSPROJ in VS 2017](static/EditProjectVs2017.png)

## Global.asax File Replacement ##
ASP.NET Core introduced a new mechanism for bootstrapping your application. The entry point for ASP.NET applications is the Global.asax file, in which tasks such as route configuration and filter and area registrations were handled.

[!code-csharp[Main](samples/sample6.cs)]

This approach couples our application and the server it is deployed to in a way that interferes with our implementation. In an effort to decouple, [OWIN](http://owin.org/) was introduced to provide a cleaner way to use multiple frameworks together. This framework provides a pipeline so we can add a la cart modules to our pipeline at our leisure and needs. The hosting environment takes a `Startup` function to set up everything. That function registers a set of middleware with the application. For each request, the application calls each of the the middleware components with the head pointer of a linked list to an existing set of handlers. Each middleware can add one or more handlers to the request handling pipeline by returning a reference to the handler that will be the new head of the list. Each handler is responsible for remembering and invoking the next handler in the list. Now the entry point to your application is `Startup`, and you no longer have a dependency on `Global.asax`. When using OWIN with .NET Framework, you could have something like this as a pipeline.

[!code-csharp[Main](samples/sample7.cs)]

This configures your default routes, and defaults to XmlSerialization over Json. From here you could continue to add other Middleware to this pipeline as you see fit to satisfy your application's needs (loading services, configuration settings, static files, etc).

.NET Core uses a similar approach but no longer relies on OWIN to handle the entry. Instead that is done through *Program.cs* `Main` method (similar to Console Applcations) and Startup is loaded through there.

[!code-csharp[Main](samples/sample8.cs)]

`Startup` must include a `Configure` method and inside Configure we can add whatever middleware to the pipeline we need. In the following example from the default web site template, several extension methods are used to configure the pipeline with support for [BrowserLink](http://vswebessentials.com/features/browserlink), error pages, static files, ASP.NET MVC, and Identity.

[!code-csharp[Main](../common/samples/WebApplication1/Startup.cs?highlight=8,9,10,14,17,19,21&start=58&end=84)]

Now we have a decoupled relationship between our host and our application which gives us the flexibility to move to a differnet platform in the future (one of the strengths of using Dot NET Core)

> [!NOTE]
> For a more in-depth reference to .NET Core Startup and Middleware, please read [Startup in ASP.NET Core](xref:fundamentals/startup)

## Storing Configurations
Since the earliest versions of .NET Framework, developers have needed to store settings which could change depending upon factors such as the environment to which they were deployed. The most common practice was to store all AppSettings in a section of your *Web.config* file called `<appSettings>`. 

[!code-csharp[Main](samples/sample1.cs)]

You would read those settings using the `ConfigurationManager.AppSettings` collection in the `System.Configuration` namespace:

[!code-csharp[Main](samples/sample2.cs)]

In ASP.NET Core, we hold configurations for our applications in any file and load them as part of middleware bootstrapping. The default file for this is `appSettings.json`

[!code-csharp[Main](samples/sample4.cs)]

Loading this file into an instance of `IConfigurationRoot` inside your application is done in *Startup.cs*:

[!code-csharp[Main](samples/sample3.cs)]

Then you read from `Configuration` to get the values of your settings:

[!code-csharp[Main](samples/sample5.cs)]

There are extensions to this approach to make the process more robust, such as using Dependency Injection to load a service with these values, which would give you a strongly-typed set of Configurations.

````
//Assume AppConfiguration is a class representing a Strongly-Typed Version of AppConfiguration section
 services.Configure<AppConfiguration>(Configuration.GetSection("AppConfiguration"));
````

> [!NOTE]
> For a more in-depth reference to ASP .NET Core Configuration, please read [Configuration in ASP.NET Core](xref:fundamentals/configuration)

## DI first class citizen
One very important factor in building large, scalable applications is to have loosely-coupled components and services. The Dependency Injection Pattern is one that takes away the inner dependency that one class may have on another (an MVC Controller relationship with an Entity Framework Context is a common example). Dependency Injection is also very useful because it allows a developer to better test units of work in a manner that is easy to comprehend. There are more reasons to implement Dependency Injection in your applications,and now Dependency Injection is a native component of ASP.NET Core.

In .NET Framework Applications, developers often rely on an external package to configure Dependecy Injection, one notable package being [Unity](https://github.com/unitycontainer/unity), provided by Microsoft Patterns & Practices. 

One example of setting up Dependency Injection with Unity is implementing `IDependencyResolver` that wraps a Unity Container:

[!code-csharp[Main](../../aspnet/web-api/overview/advanced/dependency-injection/samples/sample8.cs)]

Then you create an instance of your UnityContainer, register your service and set the dependency resolver of `HttpConfiguration` to new instance of `UnityResolver` for your container:

[!code-csharp[Main](../../aspnet/web-api/overview/advanced/dependency-injection/samples/sample9.cs)]

Now you can inject `IProductRepository` anywhere you need to:

[!code-csharp[Main](../../aspnet/web-api/overview/advanced/dependency-injection/samples/sample5.cs)]

Now that Dependency Injection is included with .Net Core, all that is required is adding your service in the `ConfigureServices` section of *Startup.cs*:

[!code-csharp[Main](samples/sample.cs)]

You now can inject your repository anywhere like before. This process is now streamlined and reduces complexity as well as dependencies on external packages.
> [!NOTE]
> For a more in-depth reference to .NET Core and Dependency Injection, please read the article on Dependecy [Dependency Injection in ASP.NET Core](xref:/fundamentals/dependency-injection#replacing-the-default-services-container)

## Static file / wwwroot
One essential part of web development is the ability to serve static, client-side assets. The most common examples of static files are HTML, CSS, Javascript and images and they are used by every website on the Internet. We need to be able to save these files in the published location of our application (or CDN) and reference these files to load into the browser. This process has changed in .NET CORE, whereas in previous versions of the .NET Framework, you could store your static files basically anywhere, and reference them in your view like regular HTML (with the path to the asset provided). 

In Dot Net Core, we store our static files in web root (<content root>/wwwroot) and loading them into the pipeline using the `UseStaticFiles` extension from `Statup.Configure`. Be sure to include the NuGet package `Microsoft.AspNetCore.StaticFiles` in your application.

[!code-csharp[Main](../fundamentals/static-files/sample/StartupStaticFiles.cs?highlight=3&name=snippet1)]

Doing this allows all your assets in the *wwwroot* folder accessible to the browser at a location such as

`http://<app>/images/<imageFileName>` (This example has an image folder in *wwwroot* and that folder has images in it)

> [!NOTE]
> For a more in-depth reference to .NET Core and serving Static Files, please read [Introduction to working with static files in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/static-files)
