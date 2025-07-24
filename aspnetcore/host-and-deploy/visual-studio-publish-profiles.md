---
title: Visual Studio publish profiles (.pubxml) for ASP.NET Core app deployment
author: tdykstra
description: Learn how to create publish profiles in Visual Studio and use them for managing ASP.NET Core app deployments to various targets.
monikerRange: '>= aspnetcore-2.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 07/28/2020
uid: host-and-deploy/visual-studio-publish-profiles
---
# Visual Studio publish profiles (.pubxml) for ASP.NET Core app deployment

[!INCLUDE[](~/includes/not-latest-version.md)]

By [Sayed Ibrahim Hashimi](https://github.com/sayedihashimi) and [Rick Anderson](https://twitter.com/RickAndMSFT)

This document focuses on using Visual Studio 2022 or later to create and use [publish profiles](/visualstudio/deployment/publish-overview). The publish profiles created with Visual Studio can be used with MSBuild and Visual Studio. For instructions on publishing to Azure, see <xref:tutorials/publish-to-azure-webapp-using-vs>.

For the most current and detailed information on:

* Publishing with Visual studio, see [Overview of Visual Studio Publish](/visualstudio/deployment/publish-overview)
* MSBuild, see [MSBuild](/visualstudio/msbuild/msbuild)
* Publishing with MSBuild, see [Microsoft.NET.Sdk.Publish](https://github.com/dotnet/sdk/tree/main/src/WebSdk#microsoftnetsdkpublish)

The `dotnet new mvc` command produces a project file containing the following root-level [\<Project> element](/visualstudio/msbuild/project-element-msbuild):

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
    <!-- omitted for brevity -->
</Project>
```

The preceding `<Project>` element's `Sdk` attribute imports the MSBuild [properties](/visualstudio/msbuild/msbuild-properties) and [targets](/visualstudio/msbuild/msbuild-targets) from *$(MSBuildSDKsPath)\Microsoft.NET.Sdk.Web\Sdk\Sdk.props* and *$(MSBuildSDKsPath)\Microsoft.NET.Sdk.Web\Sdk\Sdk.targets*, respectively. The default location for `$(MSBuildSDKsPath)` (with Visual Studio 2022) is the *%programfiles%\Microsoft Visual Studio\2022\Preview\MSBuild\Sdks* folder.

`Microsoft.NET.Sdk.Web` ([Web SDK](xref:razor-pages/web-sdk)) depends on other SDKs, including `Microsoft.NET.Sdk` ([.NET Core SDK](/dotnet/core/project-sdk/msbuild-props)) and `Microsoft.NET.Sdk.Razor` ([Razor SDK](xref:razor-pages/sdk)). The MSBuild properties and targets associated with each dependent SDK are imported. Publish targets import the appropriate set of targets based on the publish method used.

When MSBuild or Visual Studio loads a project, the following high-level actions occur:

* Build project
* Compute files to publish
* Publish files to destination

## Compute project items

When the project is loaded, the [MSBuild project items](/visualstudio/msbuild/common-msbuild-project-items) (files) are computed. The item type determines how the file is processed. By default, `.cs` files are included in the `Compile` item list. Files in the `Compile` item list are compiled.

The `Content` item list contains files that are published in addition to the build outputs. By default, files matching the patterns `wwwroot\**`, `**\*.config`, and `**\*.json` are included in the `Content` item list. For example, the `wwwroot\**` [globbing pattern](https://gruntjs.com/configuring-tasks#globbing-patterns) matches all files in the *wwwroot* folder and its subfolders.

:::moniker range=">= aspnetcore-3.0"

The [Web SDK](xref:razor-pages/web-sdk) imports the [Razor SDK](xref:razor-pages/sdk). As a result, files matching the patterns `**\*.cshtml` and `**\*.razor` are also included in the `Content` item list.

:::moniker-end

:::moniker range=">= aspnetcore-2.1 <= aspnetcore-2.2"

The [Web SDK](xref:razor-pages/web-sdk) imports the [Razor SDK](xref:razor-pages/sdk). As a result, files matching the `**\*.cshtml` pattern are also included in the `Content` item list.

:::moniker-end

To explicitly add a file to the publish list, add the file directly in the `.csproj` file as shown in the [Include Files](#include-files) section.

When selecting the **Publish** button in Visual Studio or when publishing from the command line:

* The properties/items are computed (the files that are needed to build).
* **Visual Studio only**: NuGet packages are restored. (Restore needs to be explicit by the user on the CLI.)
* The project builds.
* The publish items are computed (the files that are needed to publish).
* The project is published (the computed files are copied to the publish destination).

When an ASP.NET Core project references `Microsoft.NET.Sdk.Web` in the project file, an `app_offline.htm` file is placed at the root of the web app directory. When the file is present, the ASP.NET Core Module gracefully shuts down the app and serves the `app_offline.htm` file during the deployment. For more information, see the [ASP.NET Core Module configuration reference](xref:host-and-deploy/aspnet-core-module#app_offlinehtm).

## Basic command-line publishing

Command-line publishing works on all .NET Core-supported platforms and doesn't require Visual Studio. In the following examples, the .NET CLI's [dotnet publish](/dotnet/core/tools/dotnet-publish) command is run from the project directory (which contains the `.csproj` file). If the project folder isn't the current working directory, explicitly pass in the project file path. For example:

```dotnetcli
dotnet publish C:\Webs\Web1
```

Run the following commands to create and publish a web app:

```dotnetcli
dotnet new mvc
dotnet publish
```

The `dotnet publish` command produces a variation of the following output:

```console
C:\Webs\Web1>dotnet publish
Microsoft (R) Build Engine version {VERSION} for .NET Core
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 36.81 ms for C:\Webs\Web1\Web1.csproj.
  Web1 -> C:\Webs\Web1\bin\Debug\{TARGET FRAMEWORK MONIKER}\Web1.dll
  Web1 -> C:\Webs\Web1\bin\Debug\{TARGET FRAMEWORK MONIKER}\Web1.Views.dll
  Web1 -> C:\Webs\Web1\bin\Debug\{TARGET FRAMEWORK MONIKER}\publish\
```

The default publish folder format is `bin\Debug\{TARGET FRAMEWORK MONIKER}`. For example, `bin\Release\net9.0\`

The following command specifies a `Release` build and the publishing directory:

```dotnetcli
dotnet publish -c Release -o C:\MyWebs\test
```

The `dotnet publish` command calls MSBuild, which invokes the `Publish` target. Any parameters passed to `dotnet publish` are passed to MSBuild. The `-c` and `-o` parameters map to MSBuild's `Configuration` and `OutputPath` properties, respectively.

[MSBuild properties](/visualstudio/msbuild/msbuild-command-line-reference) can be passed using either of the following formats:

* `-p:<NAME>=<VALUE>`
* `/p:<NAME>=<VALUE>`

For example, the following command publishes a `Release` build to a network share. The network share is specified with forward slashes (*//r8/*) and works on all .NET Core supported platforms.

```dotnetcli
dotnet publish -c Release /p:PublishDir=//r8/release/AdminWeb
```

Confirm that the published app for deployment isn't running. Files in the *publish* folder are locked when the app is running. Deployment can't occur because locked files can't be copied.

See the [Microsoft.NET.Sdk.Publish](https://github.com/dotnet/sdk/tree/main/src/WebSdk#microsoftnetsdkpublish) readme file for more information.

## Publish profiles

This section uses Visual Studio 2022 or later to create a publishing profile. Once the profile is created, publishing from Visual Studio or the command line is available. Publish profiles can simplify the publishing process, and any number of profiles can exist.

Create a publish profile in Visual Studio by choosing one of the following paths:

* Right-click the project in **Solution Explorer** and select **Publish**.
* Select **Publish {PROJECT NAME}** from the **Build** menu.

The **Publish** tab of the app capabilities page is displayed. Several publish targets are available, including:

* Azure
* Docker Container Registry
* Folder
* IIS, FTP, Web Deploy (for any web server)
* Import Profile

To determine the most appropriate publish target, see [What publishing options are right for me](/visualstudio/ide/not-in-toc/web-publish-options).

When the **Folder** publish target is selected, specify a folder path to store the published assets. The default folder path is *bin\\{PROJECT CONFIGURATION}\\{TARGET FRAMEWORK MONIKER}\publish\\*. For example, *bin\Release\netcoreapp2.2\publish\\*. Select the **Create Profile** button to finish.

Once a publish profile is created, the **Publish** tab's content changes. The newly created profile appears in a drop-down list. Below the drop-down list, select **Create new profile** to create another new profile.

Visual Studio's publish tool produces a `Properties/PublishProfiles/{PROFILE NAME}.pubxml` MSBuild file describing the publish profile. The *.pubxml* file:

* Contains publish configuration settings and is consumed by the publishing process.
* Can be modified to customize the build and publish process.

When publishing to an Azure target, the *.pubxml* file:

* Contains the Azure subscription identifier.
* Should not be checked into source control because the subscription identifier is sensitive information.

Sensitive information, for example, the publish password, is encrypted on a per user/machine level. The `Properties/PublishProfiles/{PROFILE NAME}.pubxml.user` file contains the information needed by MSBuild to retrieve the user name and password.

For an overview of how to publish an ASP.NET Core web app, see <xref:host-and-deploy/index>. The MSBuild tasks and targets necessary to publish an ASP.NET Core web app are open-source in the [dotnet/websdk repository](https://github.com/dotnet/sdk/tree/main/src/WebSdk).

`dotnet publish` and `dotnet build`:

* Can use folder, MSDeploy, and [Kudu](https://github.com/projectkudu/kudu/wiki) publish profiles. Because MSDeploy lacks cross-platform support, MSDeploy options are supported only on Windows.
* Support Kudu APIs to publish to Azure from any platform. Visual Studio publish supports the Kudu APIs, but it's supported by WebSDK for cross-platform publish to Azure.

Don't pass `DeployOnBuild` to the `dotnet publish` command.

For more information, see [Microsoft.NET.Sdk.Publish](https://github.com/dotnet/sdk/tree/main/src/WebSdk#microsoftnetsdkpublish).

## Folder publish example

When publishing with a profile named `FolderProfile`, use any of the following commands:

```dotnetcli
dotnet publish /p:Configuration=Release /p:PublishProfile=FolderProfile
```

```dotnetcli
dotnet build /p:DeployOnBuild=true /p:PublishProfile=FolderProfile
```

```bash
msbuild /p:DeployOnBuild=true /p:PublishProfile=FolderProfile
```

The .NET CLI's [dotnet build](/dotnet/core/tools/dotnet-build) command calls `msbuild` to run the build and publish process. The `dotnet build` and `msbuild` commands are equivalent when passing in a folder profile. When calling `msbuild` directly on Windows, the .NET Framework version of MSBuild is used. Calling `dotnet build` on a non-folder profile:

* Invokes `msbuild`, which uses MSDeploy.
* Results in a failure (even when running on Windows). To publish with a non-folder profile, call `msbuild` directly.

The following folder publish profile was created with Visual Studio and publishes to a network share:

[!code-xml[](visual-studio-publish-profiles/samples/FolderProfile.pubxml)]

In the preceding example:

* The `<ExcludeApp_Data>` property is present to satisfy an XML schema requirement. The `<ExcludeApp_Data>` property has no effect on the publish process, even if there's an *App_Data* folder in the project root. The *App_Data* folder doesn't receive special treatment as it does in ASP.NET 4.x projects.
* The `<LastUsedBuildConfiguration>` property is set to `Release`. When publishing from Visual Studio, the value of `<LastUsedBuildConfiguration>` is set using the value when the publish process is started. `<LastUsedBuildConfiguration>` is special and shouldn't be overridden in an imported MSBuild file. This property can, however, be overridden from the command line using one of the following approaches.
  * Using the .NET CLI:

    ```dotnetcli
    dotnet publish /p:Configuration=Release /p:PublishProfile=FolderProfile
    ```

    ```dotnetcli
    dotnet build -c Release /p:DeployOnBuild=true /p:PublishProfile=FolderProfile
    ```

  * Using MSBuild:

    ```bash
    msbuild /p:Configuration=Release /p:DeployOnBuild=true /p:PublishProfile=FolderProfile
    ```

## Publish to an MSDeploy endpoint from the command line

See [Microsoft.NET.Sdk.Publish](https://github.com/dotnet/sdk/tree/main/src/WebSdk#microsoftnetsdkpublish).

<!-- As of Nov 2024 
On the Azure Portal, settings/configuration, enable SCM and FTB basic auth publishing.
Download the publish profile and get the username and password.

Using the default publish profile, the following command publishes to an MSDeploy endpoint:

msbuild /p:Configuration=Release /p:DeployOnBuild=true /p:UserName="<UN> /p:Password="pw"

If testing, delete the app or restore the basic auth settings to disabled.
-->

## Set the environment

Include the `<EnvironmentName>` property in the publish profile (*.pubxml*) or project file to set the app's [environment](xref:fundamentals/environments):

```xml
<PropertyGroup>
  <EnvironmentName>Development</EnvironmentName>
</PropertyGroup>
```

If you require *web.config* transformations (for example, setting environment variables based on the configuration, profile, or environment), see <xref:host-and-deploy/iis/transform-webconfig>.

## Exclude files

When publishing ASP.NET Core web apps, the following assets are included:

* Build artifacts
* Folders and files matching the following globbing patterns:
  * `**\*.config` (for example, *web.config*)
  * `**\*.json` (for example, `appsettings.json`)
  * `wwwroot\**`

MSBuild supports [globbing patterns](https://gruntjs.com/configuring-tasks#globbing-patterns). For example, the following `<Content>` element suppresses the copying of text (*.txt*) files in the *wwwroot\content* folder and its subfolders:

```xml
<ItemGroup>
  <Content Update="wwwroot/content/**/*.txt" CopyToPublishDirectory="Never" />
</ItemGroup>
```

The preceding markup can be added to a publish profile or the `.csproj` file. When added to the `.csproj` file, the rule is added to all publish profiles in the project.

The following `<MsDeploySkipRules>` element excludes all files from the *wwwroot\content* folder:

```xml
<ItemGroup>
  <MsDeploySkipRules Include="CustomSkipFolder">
    <ObjectName>dirPath</ObjectName>
    <AbsolutePath>wwwroot\\content</AbsolutePath>
  </MsDeploySkipRules>
</ItemGroup>
```

`<MsDeploySkipRules>` won't delete the *skip* targets from the deployment site. `<Content>` targeted files and folders are deleted from the deployment site. For example, suppose a deployed web app had the following files:

* `Views/Home/About1.cshtml`
* `Views/Home/About2.cshtml`
* `Views/Home/About3.cshtml`

If the following `<MsDeploySkipRules>` elements are added, those files wouldn't be deleted on the deployment site.

```xml
<ItemGroup>
  <MsDeploySkipRules Include="CustomSkipFile">
    <ObjectName>filePath</ObjectName>
    <AbsolutePath>Views\\Home\\About1.cshtml</AbsolutePath>
  </MsDeploySkipRules>

  <MsDeploySkipRules Include="CustomSkipFile">
    <ObjectName>filePath</ObjectName>
    <AbsolutePath>Views\\Home\\About2.cshtml</AbsolutePath>
  </MsDeploySkipRules>

  <MsDeploySkipRules Include="CustomSkipFile">
    <ObjectName>filePath</ObjectName>
    <AbsolutePath>Views\\Home\\About3.cshtml</AbsolutePath>
  </MsDeploySkipRules>
</ItemGroup>
```

The preceding `<MsDeploySkipRules>` elements prevent the *skipped* files from being deployed. It won't delete those files once they're deployed.

The following `<Content>` element deletes the targeted files at the deployment site:

```xml
<ItemGroup>
  <Content Update="Views/Home/About?.cshtml" CopyToPublishDirectory="Never" />
</ItemGroup>
```

Using command-line deployment with the preceding `<Content>` element yields a variation of the following output:

```console
MSDeployPublish:
  Starting Web deployment task from source: manifest(C:\Webs\Web1\obj\Release\{TARGET FRAMEWORK MONIKER}\PubTmp\Web1.SourceManifest.
  xml) to Destination: auto().
  Deleting file (Web11112\Views\Home\About1.cshtml).
  Deleting file (Web11112\Views\Home\About2.cshtml).
  Deleting file (Web11112\Views\Home\About3.cshtml).
  Updating file (Web11112\web.config).
  Updating file (Web11112\Web1.deps.json).
  Updating file (Web11112\Web1.dll).
  Updating file (Web11112\Web1.pdb).
  Updating file (Web11112\Web1.runtimeconfig.json).
  Successfully executed Web deployment task.
  Publish Succeeded.
Done Building Project "C:\Webs\Web1\Web1.csproj" (default targets).
```

## Include files

The following sections outline different approaches for file inclusion at publish time. The [General file inclusion](#general-file-inclusion) section uses the `DotNetPublishFiles` item, which is provided by a publish targets file in the [Web SDK](xref:razor-pages/web-sdk). The [Selective file inclusion](#selective-file-inclusion) section uses the `ResolvedFileToPublish` item, which is provided by a publish targets file in the [.NET Core SDK](/dotnet/core/project-sdk/msbuild-props). Because the Web SDK depends on the .NET Core SDK, either item can be used in an ASP.NET Core project.

### General file inclusion

The following example's `<ItemGroup>` element demonstrates copying a folder located outside of the project directory to a folder of the published site. Any files added to the following markup's `<ItemGroup>` are included by default.

```xml
<ItemGroup>
  <_CustomFiles Include="$(MSBuildProjectDirectory)/../images/**/*" />
  <DotNetPublishFiles Include="@(_CustomFiles)">
    <DestinationRelativePath>wwwroot/images/%(RecursiveDir)%(Filename)%(Extension)</DestinationRelativePath>
  </DotNetPublishFiles>
</ItemGroup>
```

The preceding markup:

* Can be added to the `.csproj` file or the publish profile. If it's added to the `.csproj` file, it's included in each publish profile in the project.
* Declares a `_CustomFiles` item to store files matching the `Include` attribute's globbing pattern. The *images* folder referenced in the pattern is located outside of the project directory. A [reserved property](/visualstudio/msbuild/msbuild-reserved-and-well-known-properties), named `$(MSBuildProjectDirectory)`, resolves to the project file's absolute path.
* Provides a list of files to the `DotNetPublishFiles` item. By default, the item's `<DestinationRelativePath>` element is empty. The default value is overridden in the markup and uses [well-known item metadata](/visualstudio/msbuild/msbuild-well-known-item-metadata) such as `%(RecursiveDir)`. The inner text represents the *wwwroot/images* folder of the published site.

### Selective file inclusion

The highlighted markup in the following example demonstrates:

* Copying a file located outside of the project into the published site's *wwwroot* folder. The file name of *ReadMe2.md* is maintained.
* Excluding the *wwwroot\Content* folder.
* Excluding *Views\Home\About2.cshtml*.

[!code-xml[](visual-studio-publish-profiles/samples/Web1.pubxml?highlight=20-25)]

The preceding example uses the `ResolvedFileToPublish` item, whose default behavior is to always copy the files provided in the `Include` attribute to the published site. Override the default behavior by including a `<CopyToPublishDirectory>` child element with inner text of either `Never` or `PreserveNewest`. For example:

```xml
<ResolvedFileToPublish Include="..\ReadMe2.md">
  <RelativePath>wwwroot\ReadMe2.md</RelativePath>
  <CopyToPublishDirectory>PreserveNewest</CopyToPublishDirectory>
</ResolvedFileToPublish>
```

For more deployment samples, see the [Web SDK README file](https://github.com/dotnet/sdk/tree/main/src/WebSdk).

## Run a target before or after publishing

The built-in `BeforePublish` and `AfterPublish` targets execute a target before or after the publish target. Add the following elements to the publish profile to log console messages both before and after publishing:

[!code-xml[](visual-studio-publish-profiles/samples/TP_before.pubxml?highlight=30-35)]

## Publish to a server using an untrusted certificate

Add the `<AllowUntrustedCertificate>` property with a value of `True` to the publish profile:

```xml
<PropertyGroup>
  <AllowUntrustedCertificate>True</AllowUntrustedCertificate>
</PropertyGroup>
```

## The Kudu service

To view the files in an Azure App Service web app deployment, use the [Kudu service](https://github.com/projectkudu/kudu/wiki/Accessing-the-kudu-service). Append the `scm` token to the web app name. For example:

| URL                                    | Result       |
| -------------------------------------- | ------------ |
| `http://mysite.azurewebsites.net/`     | Web App      |
| `http://mysite.scm.azurewebsites.net/` | Kudu service |

Select the [Debug Console](https://github.com/projectkudu/kudu/wiki/Kudu-console) menu item to view, edit, delete, or add files.

## Additional resources

* [Web SDK README file](https://github.com/dotnet/sdk/tree/main/src/WebSdk)
* [Web SDK GitHub repository](https://github.com/dotnet/websdk/issues): File issues and request features for deployment.
* [Web Deploy](https://www.iis.net/downloads/microsoft/web-deploy) (MSDeploy) simplifies deployment of web apps and websites to IIS servers.
* <xref:host-and-deploy/iis/transform-webconfig>
