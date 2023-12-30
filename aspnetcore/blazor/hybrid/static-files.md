---
title: ASP.NET Core Blazor Hybrid static files
author: guardrex
description: Learn how to consume static asset files in Blazor Hybrid apps.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/hybrid/static-files
---
# ASP.NET Core Blazor Hybrid static files

[!INCLUDE[](~/includes/not-latest-version.md)]

This article describes how to consume static asset files in Blazor Hybrid apps.

In a Blazor Hybrid app, static files are *app resources*, accessed by Razor components using the following approaches:

* [.NET MAUI](#net-maui): [:::no-loc text=".NET MAUI file system helpers":::](/dotnet/maui/platform-integration/storage/file-system-helpers)
* [WPF](#wpf) and [Windows Forms](#windows-forms): <xref:System.Resources.ResourceManager>

When static assets are only used in the Razor components, static assets can be consumed from the web root (`wwwroot` folder) in a similar way to Blazor WebAssembly and Blazor Server apps. For more information, see the [Static assets limited to Razor components](#static-assets-limited-to-razor-components) section.

## .NET MAUI

In .NET MAUI apps, [*raw assets*](/dotnet/maui/fundamentals/single-project#raw-assets) using the `MauiAsset` build action and [:::no-loc text=".NET MAUI file system helpers":::](/dotnet/maui/platform-integration/storage/file-system-helpers) are used for static assets.

> [!NOTE]
> Interfaces, classes, and supporting types to work with storage on devices across all supported platforms for features such as choosing a file, saving preferences, and using secure storage are in the <xref:Microsoft.Maui.Storage> namespace. The namespace is available throughout a MAUI Blazor Hybrid app, so there's no need to specify a `using` statement in a class file or an `@using` Razor directive in a Razor component for the namespace.

Place raw assets into the `Resources/Raw` folder of the app. The example in this section uses a static text file.

`Resources/Raw/Data.txt`:

```text
This is text from a static text file resource.
```

The following Razor component:

* Calls <xref:Microsoft.Maui.Storage.FileSystem.OpenAppPackageFileAsync%2A> to obtain a <xref:System.IO.Stream> for the resource.
* Reads the <xref:System.IO.Stream> with a <xref:System.IO.StreamReader>.
* Calls <xref:System.IO.StreamReader.ReadToEndAsync%2A?displayProperty=nameWithType> to read the file.

`Pages/StaticAssetExample.razor`:

```razor
@page "/static-asset-example"
@using System.IO
@using Microsoft.Extensions.Logging
@inject ILogger<StaticAssetExample> Logger

<h1>Static Asset Example</h1>

<p>@dataResourceText</p>

@code {
    public string dataResourceText = "Loading resource ...";

    protected override async Task OnInitializedAsync()
    {
        try
        {
            using var stream = 
                await FileSystem.OpenAppPackageFileAsync("Data.txt");
            using var reader = new StreamReader(stream);

            dataResourceText = await reader.ReadToEndAsync();
        }
        catch (FileNotFoundException ex)
        {
            dataResourceText = "Data file not found.";
            Logger.LogError(ex, "'Resource/Raw/Data.txt' not found.");
        }
    }
}
```

For more information, see the following resources:

* [Target multiple platforms from .NET MAUI single project (.NET MAUI documentation)](/dotnet/maui/fundamentals/single-project)
* [Improve consistency with resizetizer (dotnet/maui #4367)](https://github.com/dotnet/maui/pull/4367)

## WPF

Place the asset into a folder of the app, typically at the project's root, such as a `Resources` folder. The example in this section uses a static text file.

`Resources/Data.txt`:

```text
This is text from a static text file resource.
```

If a `Properties` folder doesn't exist in the app, create a `Properties` folder in the root of the app.

If the `Properties` folder doesn't contain a resources file (`Resources.resx`), create the file in **Solution Explorer** with the **Add** > **New Item** contextual menu command.

Double-click the `Resource.resx` file.

Select **Strings** > **Files** from the dropdown list.

Select **Add Resource** > **Add Existing File**. If prompted by Visual Studio to confirm editing the file, select **Yes**. Navigate to the `Resources` folder, select the `Data.txt` file, and select **Open**.

In the following example component, <xref:System.Resources.ResourceManager.GetString%2A?displayProperty=nameWithType> obtains the string resource's text for display.

> [!WARNING]
> Never use <xref:System.Resources.ResourceManager> methods with untrusted data.

`StaticAssetExample.razor`:

```razor
@page "/static-asset-example"
@using System.Resources

<h1>Static Asset Example</h1>

<p>@dataResourceText</p>

@code {
    public string dataResourceText = "Loading resource ...";

    protected override void OnInitialized()
    {
        var resources = 
            new ResourceManager(typeof(WpfBlazor.Properties.Resources));

        dataResourceText = resources.GetString("Data") ?? "'Data' not found.";
    }
}
```

## Windows Forms

Place the asset into a folder of the app, typically at the project's root, such as a `Resources` folder. The example in this section uses a static text file.

`Resources/Data.txt`:

```text
This is text from a static text file resource.
```

Examine the files associated with `Form1` in **Solution Explorer**. If `Form1` doesn't have a resource file (`.resx`), add a `Form1.resx` file with the **Add** > **New Item** contextual menu command.

Double-click the `Form1.resx` file.

Select **Strings** > **Files** from the dropdown list.

Select **Add Resource** > **Add Existing File**. If prompted by Visual Studio to confirm editing the file, select **Yes**. Navigate to the `Resources` folder, select the `Data.txt` file, and select **Open**.

In the following example component:

* The app's assembly name is `WinFormsBlazor`. The <xref:System.Resources.ResourceManager>'s base name is set to the assembly name of `Form1` ( `WinFormsBlazor.Form1`).
* <xref:System.Resources.ResourceManager.GetString%2A?displayProperty=nameWithType> obtains the string resource's text for display.

> [!WARNING]
> Never use <xref:System.Resources.ResourceManager> methods with untrusted data.

`StaticAssetExample.razor`:

```razor
@page "/static-asset-example"
@using System.Resources

<h1>Static Asset Example</h1>

<p>@dataResourceText</p>

@code {
    public string dataResourceText = "Loading resource ...";

    protected override async Task OnInitializedAsync()
    {   
        var resources = 
            new ResourceManager("WinFormsBlazor.Form1", this.GetType().Assembly);

        dataResourceText = resources.GetString("Data") ?? "'Data' not found.";
    }
}
```

## Static assets limited to Razor components

A `BlazorWebView` control has a configured host file (:::no-loc text="HostPage":::), typically `wwwroot/index.html`. The :::no-loc text="HostPage"::: path is relative to the project. All static web assets (scripts, CSS files, images, and other files) that are referenced from a `BlazorWebView` are relative to its configured :::no-loc text="HostPage":::.

Static web assets from a [Razor class library (RCL)](xref:razor-pages/ui-class) use special paths: `_content/{PACKAGE ID}/{PATH AND FILE NAME}`. The `{PACKAGE ID}` placeholder is the library's [package ID](/nuget/create-packages/creating-a-package-msbuild#set-properties). The package ID defaults to the project's assembly name if `<PackageId>` isn't specified in the project file. The `{PATH AND FILE NAME}` placeholder is path and file name under `wwwroot`. These paths are logically subpaths of the app's `wwwroot` folder, although they're actually coming from other packages or projects. Component-specific CSS style bundles are also built at the root of the `wwwroot` folder.

The web root of the :::no-loc text="HostPage"::: determines which subset of static assets are available:

* `wwwroot/index.html` (*recommended*): All assets in the app's `wwwroot` folder are available (for example: `wwwroot/image.png` is available from `/image.png`), including subfolders (for example: `wwwroot/subfolder/image.png` is available from `/subfolder/image.png`). RCL static assets in the RCL's `wwwroot` folder are available (for example: `wwwroot/image.png` is available from the path `_content/{PACKAGE ID}/image.png`), including subfolders (for example: `wwwroot/subfolder/image.png` is available from the path `_content/{PACKAGE ID}/subfolder/image.png`).
* `wwwroot/{PATH}/index.html`: All assets in the app's `wwwroot/{PATH}` folder are available using app web root relative paths. RCL static assets in `wwwroot/{PATH}` are ***not available*** because they would be in a non-existent theoretical location, such as `../../_content/{PACKAGE ID}/{PATH}`, which is ***not a supported relative path***.
* `wwwroot/_content/{PACKAGE ID}/index.html`: All assets in the RCL's `wwwroot/{PATH}` folder are available using RCL web root relative paths. The app's static assets in `wwwroot/{PATH}` are ***not available*** because they would be in a non-existent theoretical location, such as `../../{PATH}`, which is ***not a supported relative path***.

For most apps, we recommend placing the :::no-loc text="HostPage"::: at the root of the `wwwroot` folder of the app, which provides the greatest flexibility for supplying static assets from the app, RCLs, and via subfolders of the app and RCLs.

The following examples demonstrate referencing static assets from the app's web root (`wwwroot` folder) with a :::no-loc text="HostPage"::: rooted in the `wwwroot` folder.

`wwwroot/data.txt`:

```text
This is text from a static text file resource.
```

`wwwroot/scripts.js`:

```javascript
export function showPrompt(message) {
  return prompt(message, 'Type anything here');
}
```

The following Jeep&reg; image is also used in this section's example. You can right-click the following image to save it locally for use in a local test app.

`wwwroot/jeep-yj.png`:

![Jeep YJ&reg;](~/blazor/components/class-libraries/_static/jeep-yj.png)

In a Razor component:

* The static text file contents can be read using the following techniques:
  * .NET MAUI: [:::no-loc text=".NET MAUI file system helpers":::](/dotnet/maui/platform-integration/storage/file-system-helpers) (<xref:Microsoft.Maui.Storage.FileSystem.OpenAppPackageFileAsync%2A>)
  * WPF and Windows Forms: <xref:System.IO.StreamReader.ReadToEndAsync%2A?displayProperty=nameWithType>
* JavaScript files are available at logical subpaths of `wwwroot` using `./` paths.
* The image can be the source attribute (`src`) of an image tag (`<img>`).

`StaticAssetExample2.razor`:

```razor
@page "/static-asset-example-2"
@using Microsoft.Extensions.Logging
@implements IAsyncDisposable
@inject IJSRuntime JS
@inject ILogger<StaticAssetExample2> Logger

<h1>Static Asset Example 2</h1>

<h2>Read a file</h2>

<p>@dataResourceText</p>

<h2>Call JavaScript</h2>

<p>
    <button @onclick="TriggerPrompt">Trigger browser window prompt</button>
</p>

<p>@result</p>

<h2>Show an image</h2>

<p><img alt="1991 Jeep YJ" src="/jeep-yj.png" /></p>

<p>
    <em>Jeep</em> and <em>Jeep YJ</em> are registered trademarks of 
    <a href="https://www.stellantis.com">FCA US LLC (Stellantis NV)</a>.
</p>

@code {
    private string dataResourceText = "Loading resource ...";
    private IJSObjectReference? module;
    private string result;

    protected override async Task OnInitializedAsync()
    {   
        try
        {
            dataResourceText = await ReadData();
        }
        catch (FileNotFoundException ex)
        {
            dataResourceText = "Data file not found.";
            Logger.LogError(ex, "'wwwroot/data.txt' not found.");
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            module = await JS.InvokeAsync<IJSObjectReference>("import",
                "./scripts.js");
        }
    }

    private async Task TriggerPrompt()
    {
        result = await Prompt("Provide some text");
    }

    public async ValueTask<string> Prompt(string message) =>
        module is not null ?
            await module.InvokeAsync<string>("showPrompt", message) : null;

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        if (module is not null)
        {
            await module.DisposeAsync();
        }
    }
}
```

In .NET MAUI apps, add the following `ReadData` method to the `@code` block of the preceding component:

```csharp
private async Task<string> ReadData()
{
    using var stream = await FileSystem.OpenAppPackageFileAsync("wwwroot/data.txt");
    using var reader = new StreamReader(stream);

    return await reader.ReadToEndAsync();
}
```

In WPF and Windows Forms apps, add the following `ReadData` method to the `@code` block of the preceding component:

```csharp
private async Task<string> ReadData()
{
    using var reader = new StreamReader("wwwroot/data.txt");

    return await reader.ReadToEndAsync();
}
```

[Collocated JavaScript files](xref:blazor/js-interop/index#load-a-script-from-an-external-javascript-file-js-collocated-with-a-component) are also accessible at logical subpaths of `wwwroot`. Instead of using the script described earlier for the `showPrompt` function in `wwwroot/scripts.js`, the following collocated JavaScript file for the `StaticAssetExample2` component also makes the function available.

`Pages/StaticAssetExample2.razor.js`:

```javascript
export function showPrompt(message) {
  return prompt(message, 'Type anything here');
}
```

Modify the module object reference in the `StaticAssetExample2` component to use the collocated JavaScript file path (`./Pages/StaticAssetExample2.razor.js`):

```csharp
module = await JS.InvokeAsync<IJSObjectReference>("import", 
    "./Pages/StaticAssetExample2.razor.js");
```

## Trademarks

*Jeep* and *Jeep YJ* are registered trademarks of [FCA US LLC (Stellantis NV)](https://www.stellantis.com).

## Additional resources

* <xref:System.Resources.ResourceManager>
* [Create resource files for .NET apps (.NET Fundamentals documentation)](/dotnet/core/extensions/create-resource-files)
* [How to: Use resources in localizable apps (WPF documentation)](/dotnet/desktop/wpf/advanced/how-to-use-resources-in-localizable-applications)
