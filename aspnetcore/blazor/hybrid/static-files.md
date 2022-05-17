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

In a Blazor Hybrid app, static files are deployed into the app as static assets.



XAML resources described in this article are different from app resources, which are generally files added to an app, such as content, data, or embedded files.


WinForms and WPF:


1. Create an asset you'd like to use in your application. For instance, I created a `Resources` directory, and placed `data.txt` within it, containing `This is some text from a text file resource.`.

1. Right click on your project, select `Properties` and then navigate to `Resources > General`.

   IMAGE

1. Select `Create or open assembly resources`

1. Open the `Strings` dropdown, and select `Files`

   IMAGE

1. Select `Add Resource`, and then select `MyAsset.txt` created earlier. You should see the asset reflected in your resources:

IMAGE

1. Go back to your `*.razor` component and paste the following snippet, replacing `INSERT_PROJECT_NAME_HERE` with your project name.

```razor
@using System.Resources

@assetText

@code {
    public string assetText = "Loading asset...";

    protected override void OnInitialized()
    {   
        var resources = new ResourceManager(typeof(WinFormsBlazor.Properties.Resources));
        var assetObject = resources.GetObject("MyAsset");
        if (assetObject is null)
        {
            throw new KeyNotFoundException("'MyAsset' could not be found");
        }

        assetText = (string)assetObject;
    }
}
```

8. Run your application, and you should see the content of your `MyAsset.txt` file:

IMAGE

.NET MAUI:

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


## Additional resources


