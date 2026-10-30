---
title: Host and deploy ASP.NET Core
description: Learn how to set up hosting environments and deploy ASP.NET Core apps.
monikerRange: '>= aspnetcore-2.1'
ms.date: 04/22/2026
---
# Host and deploy ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-2.2"

In general, to deploy an ASP.NET Core app to a hosting environment:

* Deploy the published app to a folder on the hosting server.
* Set up a process manager that starts the app when requests arrive and restarts the app after it crashes or the server reboots.
* For configuration of a reverse proxy, set up a reverse proxy to forward requests to the app.

For Blazor host and deploy guidance, which adds to or supersedes the guidance in this node, see <xref:blazor/host-and-deploy/index>.

## Publish to a folder

The [dotnet publish](/dotnet/core/tools/dotnet-publish) command compiles app code and copies the files required to run the app into a *publish* folder. When deploying from Visual Studio, the `dotnet publish` step occurs automatically before the files are copied to the deployment destination.

### Run the published app locally

To run the published app locally, run `dotnet <ApplicationName>.dll` from the *publish* folder.

## Publish settings files

`*.json` files are published by default. To publish other settings files, specify them in an [`<ItemGroup><Content Include= ... />`](/visualstudio/msbuild/common-msbuild-project-items#content) element in the project file. The following example publishes XML files:

```xml
<ItemGroup>
  <Content Include="**\*.xml" Exclude="bin\**\*;obj\**\*"
    CopyToOutputDirectory="PreserveNewest" />
</ItemGroup>
```

### Folder contents

The *publish* folder contains one or more app assembly files, dependencies, and optionally the .NET runtime.

A .NET Core app can be published as *self-contained deployment* or *framework-dependent deployment*. If the app is self-contained, the assembly files that contain the .NET runtime are included in the *publish* folder. If the app is framework-dependent, the .NET runtime files aren't included because the app has a reference to a version of .NET that's installed on the server. The default deployment model is framework-dependent. For more information, see [.NET Core application deployment](/dotnet/core/deploying/).

In addition to *.exe* and *.dll* files, the *publish* folder for an ASP.NET Core app typically contains configuration files, static assets, and MVC views. For more information, see [ASP.NET Core directory structure](directory-structure.md).

## Set up a process manager

An ASP.NET Core app is a console app that must be started when a server boots and restarted if it crashes. To automate starts and restarts, a process manager is required. The most common process managers for ASP.NET Core are:

* Linux
  * [Nginx](linux-nginx.md)
* Windows
  * [IIS](iis/index.md)
  * [Windows Service](windows-service.md)

## Set up a reverse proxy

If the app uses the [Kestrel](../fundamentals/servers/kestrel.md) server, [Nginx](linux-nginx.md), or [IIS](iis/index.md) can be used as a reverse proxy server. A reverse proxy server receives HTTP requests from the Internet and forwards them to Kestrel.

:::moniker-end 

:::moniker range=">= aspnetcore-5.0"
Either configuration&mdash;with or without a reverse proxy server&mdash;is a supported hosting configuration. For more information, see [When to use Kestrel with a reverse proxy](../fundamentals/servers/kestrel/when-to-use-a-reverse-proxy.md).
:::moniker-end

:::moniker range=">= aspnetcore-2.2 < aspnetcore-5.0"
Either configuration&mdash;with or without a reverse proxy server&mdash;is a supported hosting configuration. For more information, see [When to use Kestrel with a reverse proxy](../fundamentals/servers/kestrel.md#when-to-use-kestrel-with-a-reverse-proxy).
:::moniker-end

:::moniker range=">= aspnetcore-2.2"

## Proxy server and load balancer scenarios

Additional configuration might be required for apps hosted behind proxy servers and load balancers. Without additional configuration, an app might not have access to the scheme (HTTP/HTTPS) and the remote IP address where a request originated. For more information, see [Configure ASP.NET Core to work with proxy servers and load balancers](proxy-load-balancer.md).

## Use Visual Studio and MSBuild to automate deployments

Deployment often requires additional tasks besides copying the output from [dotnet publish](/dotnet/core/tools/dotnet-publish) to a server. For example, extra files might be required or excluded from the *publish* folder. Visual Studio uses [MSBuild](/visualstudio/msbuild/msbuild) for web deployment, and MSBuild can be customized to do many other tasks during deployment. For more information, see [Visual Studio publish profiles (.pubxml) for ASP.NET Core app deployment](visual-studio-publish-profiles.md) and the [Using MSBuild and Team Foundation Build](https://www.microsoftpressstore.com/store/inside-the-microsoft-build-engine-using-msbuild-and-9780735645240) book.

By using [the Publish Web feature](xref:tutorials/publish-to-azure-webapp-using-vs), apps can be deployed directly from Visual Studio to the Azure App Service. Azure DevOps Services supports [continuous deployment to Azure App Service](/azure/devops/pipelines/targets/webapp). For more information, see [DevOps for ASP.NET Core Developers](/dotnet/architecture/devops-for-aspnet-developers).

## Publish to Azure

See <xref:tutorials/publish-to-azure-webapp-using-vs> for instructions on how to publish an app to Azure using Visual Studio. An additional example is provided by [Create an ASP.NET Core web app in Azure](/azure/app-service/app-service-web-get-started-dotnet).

## Publish with MSDeploy on Windows

See [Visual Studio publish profiles (.pubxml) for ASP.NET Core app deployment](visual-studio-publish-profiles.md) for instructions on how to publish an app with a Visual Studio publish profile, including from a Windows command prompt using the [dotnet msbuild](/dotnet/core/tools/dotnet-msbuild) command.

## Internet Information Services (IIS)

For deployments to Internet Information Services (IIS) with configuration provided by the *web.config* file, see the articles under [Host ASP.NET Core on Windows with IIS](iis/index.md).

## Host in a web farm

For information on configuration for hosting ASP.NET Core apps in a web farm environment (for example, deployment of multiple instances of your app for scalability), see [Host ASP.NET Core in a web farm](web-farm.md).

## Host on Docker

For more information, see [Host ASP.NET Core in Docker containers](docker/index.md).

## Perform health checks

Use health checks middleware to perform health checks on an app and its dependencies. For more information, see [Health checks in ASP.NET Core](health-checks.md).

## Additional resources

* [.NET application publishing overview](/dotnet/core/deploying)
* <xref:test/troubleshoot>
* [ASP.NET Hosting](https://dotnet.microsoft.com/apps/aspnet/hosting)

:::moniker-end

:::moniker range="< aspnetcore-2.2"

In general, to deploy an ASP.NET Core app to a hosting environment:

* Deploy the published app to a folder on the hosting server.
* Set up a process manager that starts the app when requests arrive and restarts the app after it crashes or the server reboots.
* For configuration of a reverse proxy, set up a reverse proxy to forward requests to the app.

## Publish to a folder

The [dotnet publish](/dotnet/core/tools/dotnet-publish) command compiles app code and copies the files required to run the app into a *publish* folder. When deploying from Visual Studio, the `dotnet publish` step occurs automatically before the files are copied to the deployment destination.

### Folder contents

The *publish* folder contains one or more app assembly files, dependencies, and optionally the .NET runtime.

A .NET Core app can be published as *self-contained deployment* or *framework-dependent deployment*. If the app is self-contained, the assembly files that contain the .NET runtime are included in the *publish* folder. If the app is framework-dependent, the .NET runtime files aren't included because the app has a reference to a version of .NET that's installed on the server. The default deployment model is framework-dependent. For more information, see [.NET Core application deployment](/dotnet/core/deploying/).

In addition to *.exe* and *.dll* files, the *publish* folder for an ASP.NET Core app typically contains configuration files, static assets, and MVC views. For more information, see [ASP.NET Core directory structure](directory-structure.md).

## Set up a process manager

An ASP.NET Core app is a console app that must be started when a server boots and restarted if it crashes. To automate starts and restarts, a process manager is required. The most common process managers for ASP.NET Core are:

* Linux
  * [Nginx](linux-nginx.md)
* Windows
  * [IIS](iis/index.md)
  * [Windows Service](windows-service.md)

## Set up a reverse proxy

If the app uses the [Kestrel](../fundamentals/servers/kestrel.md) server, [Nginx](linux-nginx.md), or [IIS](iis/index.md) can be used as a reverse proxy server. A reverse proxy server receives HTTP requests from the Internet and forwards them to Kestrel.

Either configuration&mdash;with or without a reverse proxy server&mdash;is a supported hosting configuration. For more information, see [When to use Kestrel with a reverse proxy](../fundamentals/servers/kestrel.md#when-to-use-kestrel-with-a-reverse-proxy).

## Proxy server and load balancer scenarios

Additional configuration might be required for apps hosted behind proxy servers and load balancers. Without additional configuration, an app might not have access to the scheme (HTTP/HTTPS) and the remote IP address where a request originated. For more information, see [Configure ASP.NET Core to work with proxy servers and load balancers](proxy-load-balancer.md).

## Use Visual Studio and MSBuild to automate deployments

Deployment often requires additional tasks besides copying the output from [dotnet publish](/dotnet/core/tools/dotnet-publish) to a server. For example, extra files might be required or excluded from the *publish* folder. Visual Studio uses MSBuild for web deployment, and MSBuild can be customized to do many other tasks during deployment. For more information, see [Visual Studio publish profiles (.pubxml) for ASP.NET Core app deployment](visual-studio-publish-profiles.md) and the [Using MSBuild and Team Foundation Build](https://www.microsoftpressstore.com/store/inside-the-microsoft-build-engine-using-msbuild-and-9780735645240) book.

By using [the Publish Web feature](xref:tutorials/publish-to-azure-webapp-using-vs), apps can be deployed directly from Visual Studio to the Azure App Service. Azure DevOps Services supports [continuous deployment to Azure App Service](/azure/devops/pipelines/targets/webapp). For more information, see [DevOps for ASP.NET Core Developers](/dotnet/architecture/devops-for-aspnet-developers).

## Publish to Azure

See <xref:tutorials/publish-to-azure-webapp-using-vs> for instructions on how to publish an app to Azure using Visual Studio. An additional example is provided by [Create an ASP.NET Core web app in Azure](/azure/app-service/app-service-web-get-started-dotnet).

## Publish with MSDeploy on Windows

See [Visual Studio publish profiles (.pubxml) for ASP.NET Core app deployment](visual-studio-publish-profiles.md) for instructions on how to publish an app with a Visual Studio publish profile, including from a Windows command prompt using the [dotnet msbuild](/dotnet/core/tools/dotnet-msbuild) command.

## Internet Information Services (IIS)

For deployments to Internet Information Services (IIS) with configuration provided by the *web.config* file, see the articles under [Host ASP.NET Core on Windows with IIS](iis/index.md).

## Host in a web farm

For information on configuration for hosting ASP.NET Core apps in a web farm environment (for example, deployment of multiple instances of your app for scalability), see [Host ASP.NET Core in a web farm](web-farm.md).

## Host on Docker

For more information, see [Host ASP.NET Core in Docker containers](docker/index.md).

## Additional resources

* [.NET application publishing overview](/dotnet/core/deploying)
* <xref:test/troubleshoot>
* [ASP.NET Hosting](https://dotnet.microsoft.com/apps/aspnet/hosting)

:::moniker-end
