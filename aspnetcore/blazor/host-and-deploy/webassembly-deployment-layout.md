---
title: Deployment layout for ASP.NET Core Blazor WebAssembly apps
author: guardrex
description: Learn how to enable Blazor WebAssembly deployments in environments that block the download and execution of dynamic-link library (DLL) files.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 10/01/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/host-and-deploy/webassembly-deployment-layout
---
# Deployment layout for ASP.NET Core Blazor WebAssembly apps

Some environments block the download and execution of dynamic-link libraries (DLLs) from the network to prevent the potential spread of malware, which can also block downloading Blazor WebAssembly apps. To enable Blazor WebAssembly in these environments, this article explains how to customize the published files and packaging of Blazor WebAssembly apps using the following features:

* [JavaScript initializers](xref:blazor/js-interop/index#javascript-initializers) that allow customizing the Blazor boot process.
* MSBuild extensibility to transform the list of publish files and define Blazor publish extensions.

## Experimental NuGet package and sample app

The approach described in this article uses the experimental [`Microsoft.AspNetCore.Components.WebAssembly.MultipartBundle` package (NuGet.org)](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.MultipartBundle). The package contains MSBuild targets to customize the Blazor publish output and a [JavaScript initializer](xref:blazor/js-interop/index#javascript-initializers) to use a custom [boot resource loader](xref:blazor/fundamentals/startup#load-boot-resources).

[Experimental code (includes the NuGet package reference source and `CustomPackagedApp` sample app)](https://github.com/aspnet/AspLabs/tree/main/src/BlazorWebAssemblyCustomInitialization)

> [!WARNING]
> `Microsoft.AspNetCore.Components.WebAssembly.MultipartBundle` and the `CustomPackagedApp` sample app are unsupported, experimental resources not intended for for production use. For more information and to provide feedback to the ASP.NET Core product unit, see [Consider releasing a supported version of Microsoft.AspNetCore.Components.WebAssembly.MultipartBundle (dotnet/aspnetcore #36978)](https://github.com/dotnet/aspnetcore/issues/36978).

## JavaScript initializers

[JavaScript (JS) initializers](xref:blazor/js-interop/index#javascript-initializers) are JS modules loaded during the Blazor boot process. These modules can export two functions that get called at specific points early in the lifecycle of the host app:

* `beforeStart`: Invoked by Blazor before the app is started.
* `afterStarted`: Invoked by Blazor after the .NET runtime has started.

In Blazor WebAssembly apps, `beforeStart` receives two pieces of data:

* Blazor WebAssembly options that can be changed to provide a custom [boot resource loader](xref:blazor/fundamentals/startup#load-boot-resources).
* An extensions object that contains a collection of extensions defined for the app. Each extension is a JS object that contains a list of files relevant to the extension.

## Blazor publish extensions

Blazor publish extensions are files that can be defined as part of the publish process and that provide an alternative representation for the set of files required to run the published app.

In this article, Blazor publish extension is created that produces a multipart bundle with all of the app's DLLs packed into a single file so that the DLLs can be downloaded together. The approach demonstrated in this article serves as a starting point for developers to devise their own strategies and custom loading processes.

## Customize the Blazor WebAssembly loading process via a NuGet package

Blazor app resources are packed into a bundle file as a multipart file bundle and loaded by the browser via a custom [JavaScript (JS) initializer](xref:blazor/js-interop/index#javascript-initializers). For an app consuming the package with the JS initializer, the app only requires that the bundle file is served when requested. All of the other aspects of this approach are handled transparently.

Four customizations are required for how a published Blazor app loads:

* An MSBuild task to transform the publish files.
* A package with MSBuild targets that hooks into the Blazor publishing process, transforms the output, and defines one or more Blazor publish extension files (in this case, a single bundle).
* A JS initializer to update the Blazor WebAssembly resource loader callback so that it loads the bundle and provides the app with the individual files.
* A helper on the host **`Server`** app to ensure that the bundle is served to clients on request.

## Create an MSBuild task to customize the list of published files and define new extensions

Create an MSBuild task as a public C# class that can be imported as part of an MSBuild compilation and that can interact with the build.

The following are required for the C# class:

* A new class library project.
* Change the target framework of the project to `netstandard2.0`.
* Reference the MSBuild packages.

Example class library project file (`.csproj`):

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netstandard2.0</TargetFramework>
    <LangVersion>8.0</LangVersion>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.Build.Framework" Version="{VERSION}" />
    <PackageReference Include="Microsoft.Build.Utilities.Core" Version="{VERSION}" />
  </ItemGroup>

</Project>
```

The latest preview and release package versions for the `{VERSION}` placeholders in the preceding project file can be found at Nuget.org:

* [`Microsoft.Build.Framework`](https://www.nuget.org/packages/Microsoft.Build.Framework)
* [`Microsoft.Build.Utilities.Core`](https://www.nuget.org/packages/Microsoft.Build.Utilities.Core)

To create the MSBuild task, create a public C# class extending <xref:Microsoft.Build.Utilities.Task?displayProperty=fullName> (not <xref:System.Threading.Tasks.Task?displayProperty=fullName>) and declare three properties:

* `PublishBlazorBootStaticWebAsset`: The list of files to publish for the Blazor app.
* `BundlePath`: The path where the bundle is written.
* `Extension`: The new publish extensions to include in the build.

The following example `BundleBlazorAssets` class is a starting point for further customization:

* The `Execute` method, where we take the files and create the bundle. There are three types of files we are going to deal with:
  * JavaScript files (`dotnet.js`)
  * WASM files (`dotnet.wasm`)
  * App DLLs.
* A `multipart/form-data` bundle is created. Each file is added to the bundle with its respective descriptions via the content disposition header and the content type header.
* After the bundle is created, the bundle is written to a file.
* Finally, build is configured for the extension. The following code creates an extension item and adds it to the `Extension` property. Each extension item contains three pieces of data:
  * The path to the extension file.
  * The URL path relative to the root of the Blazor WebAssembly app.
  * The name of the extension, which groups the files produced by a given extension. The name is used to refer to the extension later.

After accomplishing the preceding goals, the MSBuild task is created for customizing the Blazor publish output. Blazor takes care of gathering the extensions and making sure that the extensions are copied to the correct location in the publish output folder. The same optimizations (for example, compression) are applied as Blazor applies to other files.

`BundleBlazorAssets.cs`:

```csharp
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Microsoft.AspNetCore.Components.WebAssembly.MultipartBundle.Tasks
{
    public class BundleBlazorAssets : Task
    {
        [Required]
        public ITaskItem[] PublishBlazorBootStaticWebAsset { get; set; }

        [Required]
        public string BundlePath { get; set; }

        [Output]
        public ITaskItem[] Extension { get; set; }

        public override bool Execute()
        {
            var bundle = new MultipartFormDataContent(
                "--0a7e8441d64b4bf89086b85e59523b7d");

            foreach (var asset in PublishBlazorBootStaticWebAsset)
            {
                var name = Path.GetFileName(asset.GetMetadata("RelativePath"));
                var fileContents = File.OpenRead(asset.ItemSpec);
                var content = new StreamContent(fileContents);
                var disposition = new ContentDispositionHeaderValue("form-data");
                disposition.Name = name;
                disposition.FileName = name;
                content.Headers.ContentDisposition = disposition;
                var contentType = Path.GetExtension(name) switch
                {
                    ".js" => "text/javascript",
                    ".wasm" => "application/wasm",
                    _ => "application/octet-stream"
                };
                content.Headers.ContentType = 
                    MediaTypeHeaderValue.Parse(contentType);
                bundle.Add(content);
            }

            using (var output = File.Open(BundlePath, FileMode.OpenOrCreate))
            {
                output.SetLength(0);
                bundle.CopyToAsync(output).ConfigureAwait(false).GetAwaiter()
                    .GetResult();
                output.Flush(true);
            }

            var bundleItem = new TaskItem(BundlePath);
            bundleItem.SetMetadata("RelativePath", "app.bundle");
            bundleItem.SetMetadata("ExtensionName", "multipart");

            Extension = new ITaskItem[] { bundleItem };

            return true;
        }
    }
}
```

Now that we have an MSBuild task capable of transforming the publish output, we need a bit of plumbing code to hook it to the MSBuild pipeline.

## Author a NuGet package to automatically transform the publish output

A valid approach for creating a reusable solution is to generate a NuGet package with MSBuild targets that are automatically included when the package is referenced:

* Create a new Razor class library (RCL) project.
* Create a targets file (for example, `build\net6.0\{PACKAGE ID}.targets`, where `{PACKAGE ID}` is the package identifier of the package) following the NuGet conventions to automatically import the package in consuming projects.
* Collect the output from the class library containing the MSBuild task and confirm the output is packed in the right location.
* Make sure that all of the required files are packed in the right location.
* Add the necessary MSBuild code to attach to the Blazor pipeline and invoke the MSBuild task to generate the bundle.

The approach described in this section only uses the package to deliver targets and content, which is different from most packages where the package includes a library DLL.

XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

```xml
<Project Sdk="Microsoft.NET.Sdk.Razor">

  <PropertyGroup>
    <NoWarn>NU5100</NoWarn>
    <TargetFramework>net6.0</TargetFramework>
    <IncludeBuildOutput>false</IncludeBuildOutput>
  </PropertyGroup>

  <ItemGroup>
    <None Update="build\**" Pack="true" 
          PackagePath="%(Identity)" />
    <Content Include="_._" 
             Pack="true" 
             PackagePath="lib\net6.0\_._" />
  </ItemGroup>

  <Target Name="GetTasksOutputDlls" 
          BeforeTargets="CoreCompile">
    <MSBuild Projects="..\Microsoft.AspNetCore.Components.WebAssembly.MultipartBundle.Tasks\Microsoft.AspNetCore.Components.WebAssembly.MultipartBundle.Tasks.csproj" 
             Targets="Publish;PublishItemsOutputGroup" 
             Properties="Configuration=Release">
      <Output TaskParameter="TargetOutputs" 
              ItemName="_TasksProjectOutputs" />
    </MSBuild>
    <ItemGroup>
      <Content Include="@(_TasksProjectOutputs)" 
               Condition="'%(_TasksProjectOutputs.Extension)' == '.dll'" 
               Pack="true" 
               PackagePath="tasks\%(_TasksProjectOutputs.TargetPath)" 
               KeepMetadata="Pack;PackagePath" />
    </ItemGroup>
  </Target>

</Project>
```

> [!NOTE]
> The `<NoWarn>NU5100</NoWarn>` property in the preceding example suppresses the warning about the assemblies placed in the `tasks` folder. For more information, see [NuGet Warning NU5100](/nuget/reference/errors-and-warnings/nu5100).

Add a `.targets` file to wire up the MSBuild task to the build pipeline. In this file, the following goals are accomplished:

* Import the task into the build process. Note that the path to the DLL is relative to where this file will be in the package.
* Attach a custom target to the Blazor WebAssembly build pipeline.
* Invoke the task in the target to produce the results.

XXXXXXXXXXX

```xml
<UsingTask 
  TaskName="Microsoft.AspNetCore.Components.WebAssembly.MultipartBundle.Tasks.BundleBlazorAssets" 
  AssemblyFile="$(MSBuildThisProjectFileDirectory)..\..\tasks\Microsoft.AspNetCore.Components.WebAssembly.MultipartBundle.Tasks.dll" />
```

XXXXXXXXXXX

```xml
<Target Name="_BundleBlazorDlls">
  <BundleBlazorAssets
    PublishBlazorBootStaticWebAsset="@(PublishBlazorBootStaticWebAsset)"
    BundlePath="$(IntermediateOutputPath)bundle.multipart"
  >
    <Output TaskParameter="Extension" 
            ItemName="BlazorPublishExtension"/>
  </BundleBlazorAssets>
</Target>
```

The list of published files is provided by the Blazor WebAssembly pipeline in the `PublishBlazorBootStaticWebAsset` item group.

Define the bundle path using the `IntermediateOutputPath` (typically inside the `obj` folder). Ultimately, the bundle is copied automatically to the correct location in the publish output folder.

Capture the `Extension` property on the task output and add it to `BlazorPublishExtension` to tell Blazor about the extension.

Attach the custom target to the Blazor WebAssembly pipeline:

```xml
<PropertyGroup>
  <ComputeBlazorExtensionsDependsOn>
    $(ComputeBlazorExtensionsDependsOn);_BundleBlazorDlls
  </ComputeBlazorExtensionsDependsOn>
</PropertyGroup>
```

When the package is referenced, it generates a bundle of the Blazor files during publish.

## Automatically bootstrap Blazor from the bundle

The app leverages [JavaScript (JS) initializers](xref:blazor/js-interop/index#javascript-initializers) to automatically bootstrap a Blazor WebAssembly app from the bundle instead of using the DLLs. JS initializers are used to change the Blazor [boot resource loader](xref:blazor/fundamentals/startup#load-boot-resources) and use the bundle.

To create a JS initializer, add a JS file with the name `{NAME}.lib.module.js` to the `wwwroot` folder of the package project, where the `{NAME}` placeholder is the package identifier. The exported functions `beforeStart` and `afterStarted` handle loading.

The approach that we're going to follow is:

* Detect if our extension is available by checking for `extensions.multipart`, which is the extension name (`ExtensionName`) provided in the [Create an MSBuild task to customize the list of published files and define new extensions](#create-an-msbuild-task-to-customize-the-list-of-published-files-and-define-new-extensions) section.
* Download the bundle and parse the contents into a resources map using object URLs.
* Update the [boot resource loader (`options.loadBootResource`)](xref:blazor/fundamentals/startup#load-boot-resources) with our own function that resolves the resources using object URLs.
* After the app has started, revoke the object URLs to release memory in the `afterStarted` function.

XXXXXXXXXXXXXX

```javascript
const resources = new Map();

export async function beforeStart(options, extensions) {
  if (!extensions || !extensions.multipart) {
    return;
  }

  try {
    const integrity = extensions.multipart['app.bundle'];
    const bundleResponse = 
      await fetch('app.bundle', { integrity: integrity, cache: 'no-cache' });
    const bundleFromData = await bundleResponse.formData();
    for (let value of bundleFromData.values()) {
      resources.set(value, URL.createObjectURL(value));
    }
    options.loadBootResource = function (type, name, defaultUri, integrity) {
      return resources.get(name) ?? null;
    }
  } catch (error) {
    console.log(error);
  }
}

export async function afterStarted(blazor) {
  for (const [_, url] of resources) {
    URL.revokeObjectURL(url);
  }
}
```

## Serve the bundle from the host server app

ASP.NET Core doesn't serve the `app.bundle` file by default for security reasons. A helper is provided to serve the file.

> [!NOTE]
> Since the same optimizations are transparently applied to the extensions as are applied to the app's files, the `app.bundle.gz` and `app.bundle.br` compressed asset files are produced.

In `Program.cs`:

```csharp
app.MapGet("app.bundle", (HttpContext context) =>
{
    string? contentEncoding = null;
    var contentType = 
        "multipart/form-data; boundary=\"--0a7e8441d64b4bf89086b85e59523b7d\"";
    var fileName = "app.bundle";

    if (context.Request.Headers.AcceptEncoding.Contains("br"))
    {
        contentEncoding = "br";
        fileName += ".br";
    }
    else if (context.Request.Headers.AcceptEncoding.Contains("gzip"))
    {
        contentEncoding = "gzip";
        fileName += ".gz";
    }

    if (contentEncoding != null)
    {
        context.Response.Headers.ContentEncoding = contentEncoding;
    }

    return Results.File(
        app.Environment.WebRootFileProvider.GetFileInfo(fileName)
            .CreateReadStream(), contentType);
});
```

The content type matches the one defined earlier in the build task. The endpoint checks for the content encodings accepted by the browser and serves the optimal file.

The following **Network** tools tab of browser developer tools shows the DLLs loaded by the browser. The DLLS are blobs that have a GUID name specified by the app's bundle file (`app.bundle`):

![Network tools tab of browser developer tools](~/blazor/host-and-deploy/webassembly-deployment-layout/_static/browser-tools-network-tab.png)
