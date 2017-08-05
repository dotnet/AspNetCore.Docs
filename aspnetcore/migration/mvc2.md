# Migrating From ASP.NET to ASP.NET Core 2.0

By [Isaac Levin](https://isaaclevin.com)

This article acts as a reference guide for migrating ASP.NET Framework Applications (MVC or Web Api) to ASP.Net Core 2.0 (MVC or Web Api). Here you will find initial instructions helpful in moving your .Net proper applications to Core 2.0. Additional articles cover migrating configuration and identity code found in many ASP.NET MVC projects.

> [!IMPORTANT]
> This topic uses a Preview Version of Visual Studio in order to complete it's steps. Please ensure that you have installed [Visual Studio 2017 Preview version 15.3](https://www.visualstudio.com/vs/preview/) before preceeding.

## Useful Links
* [Porting Libraries to .Net Core](https://docs.microsoft.com/en-us/dotnet/core/porting/libraries)

## Key package changes
* Common assemblies and core equivalent (table or mapping diagram)
* Assemblies not supported in Core


## Net Standard
* Introduction to .Net Standard and what it looks like

## Project structure differences
* Changes to .csproj
* Middleware (App_Start/Global.asax vs Startup.cs)

## Storing Configurations
* Using appsettings.json vs Web.config sections

## DI first class citizen
One very important factor in building large, scalable applications is to have loosely coupled components and services. The Dependency Injection Pattern is one that takes away the inner dependency that one class my have on another (an MVC Controller relationship with an Entity Framework Context is an often used used example. Dependency Injection is also very useful because it allows a developer to better test units of work in a manner that is easy to comprehend. There are more reasons to implement Dependency Injection in your applications, and now Dependency Injection is included when building .Net Core 2.0 Applications.

In .Net Framework Applications, developers often rely on an external package to configure Dependecy Injection, one notable package being [Unity](https://github.com/unitycontainer/unity), provided by Microsoft Patterns & Practices. 

One example of setting up Dependency Injection with Unity is implementing IDependencyResolver that wraps a Unity Container

[!code-csharp[Main](../../aspnet/web-api/overview/advanced/dependency-injection/samples/sample8.cs)]

Then you create an instance of your UnityContainer, register your service and set the dependency resolver of HttpConfiguration to new instance of UnityResolver for your container

[!code-csharp[Main](../../aspnet/web-api/overview/advanced/dependency-injection/samples/sample9.cs)]

Now you can inject IProductRepository anywhere you need to

[!code-csharp[Main](../../aspnet/web-api/overview/advanced/dependency-injection/samples/sample5.cs)]

It isn't much work, but it is work regardless. Now that Dependency Injection is included with .Net Core, all that is required is adding your service in the `ConfigureServices` section of `Startup.cs`

[!code-csharp[Main](samples/sample.cs)]

That is it, you now can inject your repository anywhere like before. This process is now streamlined and reduces complexity as well as dependencies on external packages.
> [!NOTE]
> For a more in-depth reference to .Net Core and Dependecy Injection, please read Steve Smith and Scott Addie's article on Dependecy [Injection in ASP.Net Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection#replacing-the-default-services-container)

## Static file / wwwroot
* Adding assets and publishing through wwwroot
