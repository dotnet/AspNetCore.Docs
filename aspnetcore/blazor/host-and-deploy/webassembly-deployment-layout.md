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

Some environments block the download and execution of dynamic-link libraries (DLLs) from the network to prevent the potential spread of malware, which can also block downloading Blazor WebAssembly apps. To enable Blazor WebAssembly in these environments, we introduced in .NET 6 new extensibility points that allows developers to customize the published files and packaging of Blazor WebAssembly apps. These customizations can then be packaged as a reusable NuGet package.

There are two main features that make this possible:

* [JavaScript initializers](xref:blazor/js-interop/index#javascript-initializers) that allow customizing the Blazor boot process.
* MSBuild extensibility to transform the list of publish files and define Blazor publish extensions.

## Experimental NuGet package and sample app

The approach described in this article uses the experimental [`Microsoft.AspNetCore.Components.WebAssembly.MultipartBundle`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.MultipartBundle) package, which is available NuGet. For more information, see the `README.md` file of the following experimental sample app:

[Experimental sample code](https://github.com/aspnet/AspLabs/tree/main/src/BlazorWebAssemblyCustomInitialization)

> [!WARNING]
> `Microsoft.AspNetCore.Components.WebAssembly.MultipartBundle` and the `BlazorWebAssemblyCustomInitialization` sample app are unsupported, experimental resources unsuitable for production use.

## JavaScript initializers

[JavaScript (JS) initializers](xref:blazor/js-interop/index#javascript-initializers) are JS modules loaded during the Blazor boot process. These modules can export two functions that get called at specific points early in the lifecycle of the host app:

* `beforeStart`: Invoked by Blazor before the app is started.
* `afterStarted`: Invoked by Blazor after the .NET runtime has started.

In Blazor WebAssembly apps, `beforeStarts` receives two pieces of data:

* Blazor WebAssembly options that can be changed to provide a custom resource loader.
* An extensions object that contains a collection of extensions defined for the app. Each of these extensions is a JS object that contains a list of files relevant to that extension.

## Blazor publish extensions

Blazor publish extensions are files that can be defined as part of the publish process and that provide an alternative representation for the set of files needed to run the published app.

For example, in this post we'll create a Blazor publish extension that produces a multipart bundle with all the app DLLs packed into a single file so they can be downloaded together. We hope this sample will serve as a starting point for people to come up with their own strategies and custom loading processes.

## Customizing the Blazor WebAssembly loading process via a NuGet package

In this example, we're going to pack all the Blazor app resources into a bundle file as a multipart file bundle and load it on the browser via a custom [JavaScript (JS) initializer](xref:blazor/js-interop/index#javascript-initializers). For an app consuming this package, they only need to make sure that the bundle file is being served. Everything else is handled transparently.

There are four things that we need to customize how a published Blazor app loads:

* An MSBuild task to transform the publish files.
* A package with MSBuild targets that hooks into the Blazor publishing process, transforms the output, and defines one or more Blazor publish extension files (in this case, a single bundle).
* A JS initializer to update the Blazor WebAssembly resource loader callback so that it loads the bundle and provides the app with the individual files.
* A small helper on the host server app to ensure we serve the bundle.

## Writing an MSBuild task to customize the list of published files and define new extensions

An MSBuild task is a public C# class that can be imported as part of an MSBuild compilation and that can interact with the build.

Before we write our C# class, we need to do the following:

* We need to create a new class library project.
* Change the target framework to `netstandard2.0`.
* Reference the MSBuild packages.

After that, the csproj file should look something like this:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netstandard2.0</TargetFramework>
    <LangVersion>8.0</LangVersion>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.Build.Framework" Version="16.10.0" />
    <PackageReference Include="Microsoft.Build.Utilities.Core" Version="16.10.0" />
  </ItemGroup>

</Project>
```

Now that our project is created, we can create our MSBuild task. To do so, we create a public class extending <xref:Microsoft.Build.Utilities.Task?displayProperty=fullName> (not <xref:System.Threading.Tasks.Task?displayProperty=fullName>) and declare three properties:

* `PublishBlazorBootStaticWebAsset`: The list of files to publish for the Blazor app.
* `BundlePath`: The path where we need to write the bundle.
* `Extension`: The new publish extensions to include in the build.

The following example provides the starting point for a `BundleBlazorAssets` class. The `Execute` method is further explained with example code in the subsequent paragraphs. At the end of this section, the full `BundleBlazorAssets.cs` class file is shown with its required namespaces.

```csharp
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
          ...
        }
    }
}
```

The remaining piece is to implement the `Execute` method, where we take the files and create the bundle. There are three types of files we are going to deal with:

* JavaScript files (`dotnet.js`)
* WASM files (`dotnet.wasm`)
* App DLLs.

We are going to create a `multipart/form-data` bundle and add each file to the bundle with their respective descriptions via the content disposition header and the content type header. The code can be seen below:

```csharp
var bundle = new MultipartFormDataContent("--0a7e8441d64b4bf89086b85e59523b7d");
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
    content.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);
    bundle.Add(content);
}
```

Now that we've created our bundle, we need to write it to a file:

```csharp
using (var output = File.Open(BundlePath, FileMode.OpenOrCreate))
{
    output.SetLength(0);
    bundle.CopyToAsync(output).ConfigureAwait(false).GetAwaiter().GetResult();
    output.Flush(true);
}
```

Finally, we need to let the build know about our extension. We do so by creating an extension item and adding it to the Extension property. Each extension item contains three pieces of data:

* The path to the extension file.
* The URL path relative to the root of the Blazor WebAssembly app.
* The name of the extension, which groups the files produced by a given extension. We'll use this to refer to the extension later.

In our extension we define the item as follows:

```csharp
var bundleItem = new TaskItem(BundlePath);
bundleItem.SetMetadata("RelativePath", "app.bundle");
bundleItem.SetMetadata("ExtensionName", "multipart");

Extension = new ITaskItem[] { bundleItem };

return true;
```

With that, we've authored an MSBuild task for customizing the Blazor publish output. Blazor will take care of gathering the extensions and making sure that they get copied to the right place in the publish output folder and will apply the same optimizations (compression) it applies to other files.

For clarity, here is the full class in one snippet:

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
            var bundle = new MultipartFormDataContent("--0a7e8441d64b4bf89086b85e59523b7d");
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
                content.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);
                bundle.Add(content);
            }

            using (var output = File.Open(BundlePath, FileMode.OpenOrCreate))
            {
                output.SetLength(0);
                bundle.CopyToAsync(output).ConfigureAwait(false).GetAwaiter().GetResult();
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


## Authoring a NuGet package for automatically transforming the publish output

A good way to create a reusable solution is to generate a NuGet package with MSBuild targets that are automatically included when the package is referenced. For that, the steps are:

* Create a new Razor class library (RCL) project.
* Create a targets file following the NuGet conventions to automatically import it in consuming projects.
* Collect the output from the class library containing the MSBuild task and make sure it gets packed in the right location.
* Make sure all the required files are packed in the right location.
* Add the necessary MSBuild code to attach to the Blazor pipeline and invoke our task to generate the bundle.

First we create an RCL and remove all the content from it.

```xml
<Project Sdk="Microsoft.NET.Sdk.Razor">

  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
  </PropertyGroup>

</Project>
```

Next, we create a file `build\net6.0\{PACKAGE ID}.targets` where `{PACKAGE ID}` is the package identifier of the package. We'll fill in the contents later.

After that, we need to make sure we collect all the DLLs required for the MSBuild task. We can do so by creating a custom target in the package project file. In our target we invoke MSBuild over the project with our task and capture the output in the `_TasksProjectOutputs` item group as follows:

```xml
<Target Name="GetTasksOutputDlls" BeforeTargets="CoreCompile">
  <MSBuild Projects="$(PathToTasksFolder)" Targets="Publish;PublishItemsOutputGroup" Properties="Configuration=Release">
    <Output TaskParameter="TargetOutputs" ItemName="_TasksProjectOutputs" />
  </MSBuild>
</Target>
```

The next step is to make sure that our content is included in the package. To include the targets file we use the following snippet:

```xml
<ItemGroup>
  <None Update="build\**" Pack="true" PackagePath="%(Identity)" />
</ItemGroup>
```

This tells NuGet to pack the file and place it on the same path in the package.

We add the task DLLs as content after we've invoked the MSBuild task inside the `tasks` subfolder.

```xml
<Target Name="GetTasksOutputDlls" BeforeTargets="CoreCompile">
  ...
  <ItemGroup>
    <Content Include="@(_TasksProjectOutputs)" Condition="'%(_TasksProjectOutputs.Extension)' == '.dll'" Pack="true" PackagePath="tasks\%(_TasksProjectOutputs.TargetPath)" KeepMetadata="Pack;PackagePath" />
  </ItemGroup>
</Target>
```

Finally, we need to setup some properties to keep NuGet happy, since this doesn't include a library DLL like most packages do (we are only using it as a mechanism to deliver our targets and content).

The finished project file is displayed below:

```xml
<Project Sdk="Microsoft.NET.Sdk.Razor">

  <PropertyGroup>
    <NoWarn>NU5100</NoWarn>
    <TargetFramework>net6.0</TargetFramework>
    <IncludeBuildOutput>false</IncludeBuildOutput>
  </PropertyGroup>

  <ItemGroup>
    <None Update="build\**" Pack="true" PackagePath="%(Identity)" />
    <Content Include="_._" Pack="true" PackagePath="lib\net6.0\_._" />
  </ItemGroup>

  <Target Name="GetTasksOutputDlls" BeforeTargets="CoreCompile">
    <MSBuild Projects="..\Microsoft.AspNetCore.Components.WebAssembly.MultipartBundle.Tasks\Microsoft.AspNetCore.Components.WebAssembly.MultipartBundle.Tasks.csproj" Targets="Publish;PublishItemsOutputGroup" Properties="Configuration=Release">
      <Output TaskParameter="TargetOutputs" ItemName="_TasksProjectOutputs" />
    </MSBuild>
    <ItemGroup>
      <Content Include="@(_TasksProjectOutputs)" Condition="'%(_TasksProjectOutputs.Extension)' == '.dll'" Pack="true" PackagePath="tasks\%(_TasksProjectOutputs.TargetPath)" KeepMetadata="Pack;PackagePath" />
    </ItemGroup>
  </Target>

</Project>
```

> [!NOTE]
> The `<NoWarn>NU5100</NoWarn>` property in the preceding example suppresses the warning about the assemblies placed in the `tasks` folder. For more information, see [NuGet Warning NU5100](/nuget/reference/errors-and-warnings/nu5100).

All that remains now is to add a `.targets` file to wire up our task to the build pipeline. In this file we need to do the following:

* Import our task into the build process.
* Attach a custom target to the Blazor WebAssembly build pipeline.
* Invoke our task in the target to produce the results.

We start by defining an empty project on the file

```xml
<Project>
</Project>
```

Next, we import our task. Note that the path to the DLL is relative to where this file will be in the package:

```xml
<UsingTask 
  TaskName="Microsoft.AspNetCore.Components.WebAssembly.MultipartBundle.Tasks.BundleBlazorAssets" 
  AssemblyFile="$(MSBuildThisProjectFileDirectory)..\..\tasks\Microsoft.AspNetCore.Components.WebAssembly.MultipartBundle.Tasks.dll" />
```

We define a target that invokes our bundling task:

```xml
<Target Name="_BundleBlazorDlls">
  <BundleBlazorAssets
    PublishBlazorBootStaticWebAsset="@(PublishBlazorBootStaticWebAsset)"
    BundlePath="$(IntermediateOutputPath)bundle.multipart"
  >
    <Output TaskParameter="Extension" ItemName="BlazorPublishExtension"/>
  </BundleBlazorAssets>
</Target>
```

The list of published files is provided by the Blazor WebAssembly pipeline in the `PublishBlazorBootStaticWebAsset` item group.

We define the bundle path using the `IntermediateOutputPath` (typically inside the `obj` folder). The bundle will later get copied automatically to the right location in the publish output folder.

Finally, we capture the `Extension` property on the task output and add it to `BlazorPublishExtension` to tell Blazor about the extension.

We can now attach our custom target to the Blazor WebAssembly pipeline:

```xml
<PropertyGroup>
  <ComputeBlazorExtensionsDependsOn>$(ComputeBlazorExtensionsDependsOn);_BundleBlazorDlls</ComputeBlazorExtensionsDependsOn>
</PropertyGroup>
```

With this, we have a package that when referenced will generate a bundle of the Blazor files during publish. However, we haven't yet seen how to automatically bootstrap a Blazor WebAssembly app from that bundle instead of using the DLLs. We'll tackle that next.

## Automatically bootstrap Blazor from the bundle

This is where the app leverages [JavaScript (JS) initializers](xref:blazor/js-interop/index#javascript-initializers). JS initializers are used to change the Blazor boot resource loader and use the bundle instead.

To create a JS initializer, add a JS file with the name `{NAME}.lib.module.js` to the `wwwroot` folder of the package project, where the `{NAME}` placeholder is the package identifier. Export two functions to handle the loading:

```javascript
export async function beforeStart(options, extensions) {
    ...
}

export async function afterStarted(blazor) {
    ...
}
```

The approach that we're going to follow is:

* Detect if our extension is available.
* Download the bundle
* Parse the contents and create a map of resources using object URLs.
* Update the `options.loadBootResource` with our own function that resolves the resources using object URLs.
* After the app has started, revoke the object URLs to release memory.

Most of the steps happen inside `beforeStart` with only the last happening in `afterStarted`.

To detect if our extension is available, which is a simple approach of detecting if WebAssembly client-side code is executing, we check the `extensions` argument:

```javascript
if (!extensions || !extensions.multipart) {
    return;
}
```

Remember that multipart bit that we added in the extension definition inside the `Task`? It shows up here.

Next, we're going to download the bundle and parse its contents into a resources map. The resources map is defined locally at the top of the file.

```javascript
try {
    const integrity = extensions.multipart['app.bundle'];
    const bundleResponse = await fetch('app.bundle', { integrity: integrity, cache: 'no-cache' });
    const bundleFromData = await bundleResponse.formData();
    for (let value of bundleFromData.values()) {
        resources.set(value, URL.createObjectURL(value));
    }
} catch (error) {
    console.log(error);
}
```

After that, we customize the options to use our custom boot resource loader. We do this after we've created the object URLs:

```javascript
options.loadBootResource = function (type, name, defaultUri, integrity) {
    return resources.get(name) ?? null;
}
```

Finally, we release all the object URLs after the app has started within the `afterStarted` function:

```javascript
for (const [_, url] of resources) {
    URL.revokeObjectURL(url);
}
```

Here is all the code for handling the loading in one snippet:

```javascript
const resources = new Map();

export async function beforeStart(options, extensions) {
    if (!extensions || !extensions.multipart) {
        return;
    }

    try {
        const integrity = extensions.multipart['app.bundle'];
        const bundleResponse = await fetch('app.bundle', { integrity: integrity, cache: 'no-cache' });
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

## Serving the bundle from the host server app

We have our `app.bundle` file (and `app.bundle.gz` and `app.bundle.br`, since we transparently apply the same optimizations to the extensions that we do for the app files) but ASP.NET Core doesn't know how to serve it (and won't do so by default for security reasons) so we need a small helper to make that happen. Thankfully, we can do this in a few lines of code using minimal APIs.

Add an endpoint for serving `app.bundle` in `Program.cs`:

```csharp
app.MapGet("app.bundle", (HttpContext context) =>
{
    string? contentEncoding = null;
    var contentType = "multipart/form-data; boundary=\"--0a7e8441d64b4bf89086b85e59523b7d\"";
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
        app.Environment.WebRootFileProvider.GetFileInfo(fileName).CreateReadStream(),
        contentType);
});
```

Notice the content type matches the one we defined in the build task. The endpoint checks for the content encodings accepted by the browser and serves the most optimal file.

And that's a wrap! We can now reference our NuGet package from an app, add a small helper to our server host and completely change how the Blazor WebAssembly app loads.

![Network tools tab of browser developer tools showing DLLs loaded by the browser as blobs that have a GUID name and that are specified by the app's bundle file (app.bundle).](~/blazor/host-and-deploy/webassembly-deployment-layout/_static/browser-tools-network-tab.png)
