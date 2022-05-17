---
title: ASP.NET Core Blazor Hybrid static files
author: guardrex
description: Learn how to configure and manage static files for Blazor Hybrid apps.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 05/18/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/hybrid/static-files
---
# ASP.NET Core Blazor Hybrid static files

This article describes the configuration for serving static files in Blazor Hybrid apps.

[!INCLUDE[](~/blazor/includes/blazor-hybrid-preview-notice.md)]

In a Blazor Hybrid app, static files are *app resources*, accessed by Razor components using the following approaches:

* .NET MAUI: <xref:Xamarin.Essentials.FileSystem.OpenAppPackageFileAsync%2A?displayProperty=fullName> 
* WPF and Windows Forms: <xref:System.Resources.ResourceManager>

  > [!WARNING]
  > Never use <xref:System.Resources.ResourceManager> methods with untrusted data.

## .NET MAUI

For Blazor Hybrid MAUI, we'll be using the `MauiAsset` Build Action, as detailed [here](https://github.com/dotnet/maui/pull/4367), I'm confirming whether MAUI already has / will have official docs for this. If so, we'll just do some cross-linking. 

Here's the Blazor Hybrid specific sample:

```razor
@using System.IO
@using Microsoft.Maui.Storage

<button @onclick="LoadMauiAsset">Load Asset</button>

<br />


@Contents

@code {
    public string Contents = "Press 'Load Asset' to get started";
    async Task LoadMauiAsset()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("AboutAssets.txt");
        using var reader = new StreamReader(stream);

        Contents = reader.ReadToEnd();
    }
}
```

This reads the default `Resources/Raw/AboutAssets.txt` file part of the `maui-blazor` template. I've confirmed this works in MacOS, iOS, Windows & Android.

Complete instructions in how to use `MauiAsset` are summarized in [this table](https://github.com/dotnet/maui/pull/4367#issue-1116915145) and should be part of the MAUI general documentation (ie. not repeated in Blazor Hybrid docs). 

## WPF

Place the asset into a folder of the app, typically at the project's root, such as a `Resources` folder. The example in this section uses a static text file. For example, place a static text file into the folder with the following string content.

`Resources/Data.txt`:

```text
This is some text from a static text file resource.
```

If a `Properties` folder doesn't exist in the app, create a `Properties` folder in the root of the app.

If the `Properties` folder doesn't contain a resources file (`Resources.resx`), create the file in **Solution Explorer** with the **Add** > **New Item** contextual menu item for the `Properties`.

Double-click the `Resource.resx` file to open it.

Select **Strings** > **Files** from the dropdown list.

Select **Add Resource** > **Add Existing File**. If prompted by Visual Studio to confirm that you want to edit the file, select **Yes**. Navigate to the `Resources` folder, select the `Data.txt` file, and select **Open**.

In the following example component, <xref:System.Resources.ResourceManager.GetString%2A?displayProperty=nameWithType> obtains the string resource's text for display.

`StaticFileExample.razor`:

```razor
@using System.Resources

<p>@@dataResourceText: @dataResourceText</p>

@code {
    public string dataResourceText = "Loading resource ...";

    protected override void OnInitialized()
    {   
        var resources = 
            new ResourceManager(typeof(WpfBlazor.Properties.Resources));
        dataResourceText = resources.GetString("Data") ?? "'Data' not found";
    }
}
```

## Windows Forms

Place the asset into a folder of the app, typically at the project's root, such as a `Resources` folder. The example in this section uses a static text file. For example, place a static text file into the folder with the following string content.

`Resources/Data.txt`:

```text
This is some text from a static text file resource.
```

Examine the files for `Form1` in **Solution Explorer**. If `Form1` doesn't have a resource file (`.resx`) create a `Form1.resx` file.

Double-click `Form1.resx` to open the resource file.

Select **Strings** > **Files** from the dropdown list.

Select **Add Resource** > **Add Existing File**. If prompted by Visual Studio to confirm that you want to edit the file, select **Yes**. Navigate to the `Resources` folder, select the `Data.txt` file, and select **Open**.

In the following example component:

* The app's assembly name is `WinFormsBlazor`. The <xref:System.Resources.ResourceManager>'s base name is set to assembly name of `Form1` ( `WinFormsBlazor.Form1`). Modify the type reference to match your component's form.
* <xref:System.Resources.ResourceManager.GetString%2A?displayProperty=nameWithType> obtains the string resource's text for display.

```razor
@using System.Resources

<p>@@dataResourceText: @dataResourceText</p>

@code {
    public string dataResourceText = "Loading resource ...";

    protected override async Task OnInitializedAsync()
    {   
        var resources = 
            new ResourceManager("WinFormsBlazor.Form1", this.GetType().Assembly);
        dataResourceText = resources.GetString("Data") ?? "'Data' not found";
    }
}
```

## Additional resources

* <xref:System.Resources.ResourceManager>
* [Create resource files for .NET apps (.NET Fundamentals documentation)](/dotnet/core/extensions/create-resource-files)
* [How to: Use resources in localizable apps (WPF documentation)](/dotnet/desktop/wpf/advanced/how-to-use-resources-in-localizable-applications)
