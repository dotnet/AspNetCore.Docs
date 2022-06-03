---
title: Transform web.config
author: rick-anderson
description: Learn how to transform the web.config file when publishing an ASP.NET Core app.
monikerRange: '>= aspnetcore-2.2'
ms.author: riande
ms.custom: mvc
ms.date: 01/13/2020
uid: host-and-deploy/iis/transform-webconfig
---
# Transform web.config

By [Vijay Ramakrishnan](https://github.com/vijayrkn)

Transformations to the *web.config* file can be applied automatically when an app is published based on:

* [Build configuration](#build-configuration)
* [Profile](#profile)
* [Environment](#environment)
* [Custom](#custom)

These transformations occur for either of the following *web.config* generation scenarios:

* Generated automatically by the `Microsoft.NET.Sdk.Web` SDK.
* Provided by the developer in the [content root](xref:fundamentals/index#content-root) of the app.

## Build configuration

Build configuration transforms are run first.

Include a *web.{CONFIGURATION}.config* file for each [build configuration (Debug|Release)](/dotnet/core/tools/dotnet-publish#options) requiring a *web.config* transformation.

In the following example, a configuration-specific environment variable is set in *web.Release.config*:

```xml
<?xml version="1.0"?>
<configuration xmlns:xdt="http://schemas.microsoft.com/XML-Document-Transform">
  <location>
    <system.webServer>
      <aspNetCore>
        <environmentVariables xdt:Transform="InsertIfMissing">
          <environmentVariable name="Configuration_Specific" 
                               value="Configuration_Specific_Value" 
                               xdt:Locator="Match(name)" 
                               xdt:Transform="InsertIfMissing" />
        </environmentVariables>
      </aspNetCore>
    </system.webServer>
  </location>
</configuration>
```

The transform is applied when the configuration is set to *Release*:

```dotnetcli
dotnet publish --configuration Release
```

The MSBuild property for the configuration is `$(Configuration)`.

## Profile

Profile transformations are run second, after [Build configuration](#build-configuration) transforms.

Include a *web.{PROFILE}.config* file for each profile configuration requiring a *web.config* transformation.

In the following example, a profile-specific environment variable is set in *web.FolderProfile.config* for a folder publish profile:

```xml
<?xml version="1.0"?>
<configuration xmlns:xdt="http://schemas.microsoft.com/XML-Document-Transform">
  <location>
    <system.webServer>
      <aspNetCore>
        <environmentVariables xdt:Transform="InsertIfMissing">
          <environmentVariable name="Profile_Specific" 
                               value="Profile_Specific_Value" 
                               xdt:Locator="Match(name)" 
                               xdt:Transform="InsertIfMissing" />
        </environmentVariables>
      </aspNetCore>
    </system.webServer>
  </location>
</configuration>
```

The transform is applied when the profile is *FolderProfile*:

```dotnetcli
dotnet publish --configuration Release /p:PublishProfile=FolderProfile
```

The MSBuild property for the profile name is `$(PublishProfile)`.

If no profile is passed, the default profile name is **FileSystem** and *web.FileSystem.config* is applied if the file is present in the app's content root.

## Environment

Environment transformations are run third, after [Build configuration](#build-configuration) and [Profile](#profile) transforms.

Include a *web.{ENVIRONMENT}.config* file for each [environment](xref:fundamentals/environments) requiring a *web.config* transformation.

In the following example, an environment-specific environment variable is set in *web.Production.config* for the Production environment:

```xml
<?xml version="1.0"?>
<configuration xmlns:xdt="http://schemas.microsoft.com/XML-Document-Transform">
  <location>
    <system.webServer>
      <aspNetCore>
        <environmentVariables xdt:Transform="InsertIfMissing">
          <environmentVariable name="Environment_Specific" 
                               value="Environment_Specific_Value" 
                               xdt:Locator="Match(name)" 
                               xdt:Transform="InsertIfMissing" />
        </environmentVariables>
      </aspNetCore>
    </system.webServer>
  </location>
</configuration>
```

The transform is applied when the environment is *Production*:

```dotnetcli
dotnet publish --configuration Release /p:EnvironmentName=Production
```

The MSBuild property for the environment is `$(EnvironmentName)`.

When publishing from Visual Studio and using a publish profile, see <xref:host-and-deploy/visual-studio-publish-profiles#set-the-environment>.

The `ASPNETCORE_ENVIRONMENT` environment variable is automatically added to the *web.config* file when the environment name is specified.

## Custom

Custom transformations are run last, after [Build configuration](#build-configuration), [Profile](#profile), and [Environment](#environment) transforms.

Include a *{CUSTOM_NAME}.transform* file for each custom configuration requiring a *web.config* transformation.

In the following example, a custom transform environment variable is set in *custom.transform*:

```xml
<?xml version="1.0"?>
<configuration xmlns:xdt="http://schemas.microsoft.com/XML-Document-Transform">
  <location>
    <system.webServer>
      <aspNetCore>
        <environmentVariables xdt:Transform="InsertIfMissing">
          <environmentVariable name="Custom_Specific" 
                               value="Custom_Specific_Value" 
                               xdt:Locator="Match(name)" 
                               xdt:Transform="InsertIfMissing" />
        </environmentVariables>
      </aspNetCore>
    </system.webServer>
  </location>
</configuration>
```

The transform is applied when the `CustomTransformFileName` property is passed to the [dotnet publish](/dotnet/core/tools/dotnet-publish) command:

```dotnetcli
dotnet publish --configuration Release /p:CustomTransformFileName=custom.transform
```

The MSBuild property for the profile name is `$(CustomTransformFileName)`.

## Prevent web.config transformation

To prevent transformations of the *web.config* file, set the MSBuild property `$(IsWebConfigTransformDisabled)`:

```dotnetcli
dotnet publish /p:IsWebConfigTransformDisabled=true
```

## Additional resources

* [Web.config Transformation Syntax for Web Application Project Deployment](/previous-versions/dd465326(v=vs.100))
* [Web.config Transformation Syntax for Web Project Deployment Using Visual Studio](/previous-versions/aspnet/dd465326(v=vs.110))
