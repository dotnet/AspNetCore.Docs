---
title: ASP.NET Core Blazor Hybrid static files
author: guardrex
description: Learn how to consume static asset files in Blazor Hybrid apps.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/hybrid/static-files
---
# ASP.NET Core Blazor Hybrid static files

This article describes how to consume static asset files in Blazor Hybrid apps.

In a Blazor Hybrid app, static files are *app resources*, accessed by Razor components using the following approaches:

* [.NET MAUI](#net-maui): [:::no-loc text=".NET MAUI file system helpers":::](/dotnet/maui/platform-integration/storage/file-system-helpers)
* [WPF](#wpf) and [Windows Forms](#windows-forms): <xref:System.Resources.ResourceManager>

When static assets are only used in the Razor components, static assets can be consumed from the web root (`wwwroot` folder) in a similar way to Blazor WebAssembly and Blazor Server apps. For more information, see the [Static assets limited to Razor components](#static-assets-limited-to-razor-components) section.

## .NET MAUI

In .NET MAUI apps, [*raw assets*](/dotnet/maui/fundamentals/single-project#raw-assets) using the `MauiAsset` build action and [:::no-loc text=".NET MAUI file system helpers":::](/dotnet/maui/platform-integration/storage/file-system-helpers) are used for static assets.

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
@using Microsoft.Maui.Storage
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

In scenarios where the app only uses static assets in Razor components, the static assets can be supplied from the app's web root (`wwwroot` folder).

Place assets into the `wwwroot` folder. The example in this section uses a static text file.

`wwwroot/data.txt`:

```text
This is text from a static text file resource.
```

In **Solution Explorer**, select the `data.txt` file. In the file's **Properties**, set **Copy to Output Directory** to **Copy if newer**.

The following Jeep&reg; image is also used in this section's example. You can right-click the following image to save it locally for use in a local test app.

`wwwroot/jeep-yj.png`:

![Jeep YJ&reg;](~/blazor/components/class-libraries/_static/jeep-yj.png)

> [!NOTE]
> For images in `wwwroot`, the **Copy to Output Directory** property uses the default setting of **Do not copy**.

In a Razor component:

* The static text file contents can be read using the following techniques:
  * .NET MAUI: [:::no-loc text=".NET MAUI file system helpers":::](/dotnet/maui/platform-integration/storage/file-system-helpers) (<xref:Microsoft.Maui.Storage.FileSystem.OpenAppPackageFileAsync%2A>)
  * WPF and Windows Forms: <xref:System.IO.StreamReader.ReadToEndAsync%2A?displayProperty=nameWithType>
* The image can be the source attribute (`src`) of an image tag (`<img>`).

`StaticAssetExample2.razor`:

```razor
@page "/static-asset-example-2"
@using Microsoft.Extensions.Logging
@inject ILogger<StaticAssetExample2> Logger

<h1>Static Asset Example 2</h1>

<p>@dataResourceText</p>

<p><img alt="1991 Jeep YJ" src="/jeep-yj.png" /></p>

<p>
    <em>Jeep</em> and <em>Jeep YJ</em> are registered trademarks of 
    <a href="https://www.stellantis.com">FCA US LLC (Stellantis NV)</a>.
</p>

@code {
    public string dataResourceText = "Loading resource ...";

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

## Trademarks

*Jeep* and *Jeep YJ* are registered trademarks of [FCA US LLC (Stellantis NV)](https://www.stellantis.com).

## Additional resources

* <xref:System.Resources.ResourceManager>
* [Create resource files for .NET apps (.NET Fundamentals documentation)](/dotnet/core/extensions/create-resource-files)
* [How to: Use resources in localizable apps (WPF documentation)](/dotnet/desktop/wpf/advanced/how-to-use-resources-in-localizable-applications)
