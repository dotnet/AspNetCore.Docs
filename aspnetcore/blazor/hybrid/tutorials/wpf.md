---
title: Build a Windows Presentation Foundation (WPF) Blazor app
author: guardrex
description: Build a Windows Presentation Foundation (WPF) app step-by-step.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 04/07/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/hybrid/tutorials/wpf
---
# Build a Windows Presentation Foundation (WPF) Blazor app

This tutorial shows you how to build and run a WPF Blazor app. You learn how to:

> [!div class="checklist"]
> * Create a WPF Blazor app project
> * Add a Razor component to the project
> * Run the app on Windows

[!INCLUDE[](~/blazor/includes/blazor-hybrid-preview-notice.md)]

## Prerequisites

* [Supported platforms (WPF documentation)](/dotnet/desktop/wpf/overview/)
* [Visual Studio 2022 Preview](https://visualstudio.microsoft.com/vs/preview/) with the **.NET desktop development** workload

## Visual Studio workload

If the **.NET desktop development** workload isn't installed, use the Visual Studio installer to install the workload. For more information, see [Modify Visual Studio workloads, components, and language packs](/visualstudio/install/modify-visual-studio).

:::image type="content" source="wpf/_static/install-workload.png" alt-text="Visual Studio installer workload selection.":::

## Create a WPF Blazor project

Start Visual Studio 2022 Preview.

In the Start Window, select **Create a new project**:

:::image type="content" source="wpf/_static/new-solution.png" alt-text="Create a new solution in Visual Studio.":::

In the **Create a new project** dialog, filter the **Project type** drop-down to **Desktop**. Select the C# project template for **WPF Application** and select the **Next** button:

:::image type="content" source="wpf/_static/create-project.png" alt-text="Create a new project in Visual Studio.":::

In the **Configure your new project** dialog, set the **Project name** to **`WpfBlazor`**, choose a suitable location for the project, and select the **Next** button.

:::image type="content" source="wpf/_static/configure-project.png" alt-text="Configure the project.":::

In the **Additional information** dialog, select the framework version, which must be .NET 6.0 or later. Select the **Create** button:

:::image type="content" source="wpf/_static/additional-information.png" alt-text="The Additional Information dialog for the WPF project.":::

Use [NuGet Package Manager](/nuget/consume-packages/install-use-packages-visual-studio) to install the [`Microsoft.AspNetCore.Components.WebView.Wpf`](https://nuget.org/packages/Microsoft.AspNetCore.Components.WebView.Wpf) preview NuGet package.

In **Solution Explorer**, right-click the `WpfBlazor` project and select **Edit Project File** to open the project file (`WpfBlazor.csproj`).

At the top of the project file, change the SDK to `Microsoft.NET.Sdk.Razor`:

```xml
<Project Sdk="Microsoft.NET.Sdk.Razor">
```

<!-- The following is a workaround for https://github.com/dotnet/wpf/issues/5697 (fixes https://github.com/dotnet/maui/issues/3526) -->

Set the project's namespace, `WpfBlazor` in this tutorial, as the app's root namespace by adding the following property group to the project file:

```xml
<PropertyGroup>
  <RootNameSpace>WpfBlazor</RootNameSpace>
</PropertyGroup>
```

Save the changes to the project file (`WpfBlazor.csproj`).

Add an `_Imports.razor` file to the root of the project with an [`@using`](xref:mvc/views/razor#using) directive for <xref:Microsoft.AspNetCore.Components.Web?displayProperty=fullName>.

`_Imports.razor`:

```razor
@using Microsoft.AspNetCore.Components.Web
```

Add a `wwwroot` folder to the project.

Add an `index.html` file to the `wwwroot` folder with the following markup.

`wwwroot/index.html`:

```html
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>WpfBlazor</title>
    <base href="/" />
    <link href="css/bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link href="css/app.css" rel="stylesheet" />
    <link href="WpfBlazor.styles.css" rel="stylesheet" />
</head>

<body>
    <div id="app">Loading...</div>

    <div id="blazor-error-ui">
        An unhandled error has occurred.
        <a href="" class="reload">Reload</a>
        <a class="dismiss">🗙</a>
    </div>
    <script src="_framework/blazor.webview.js"></script>
</body>

</html>
```

Inside the `wwwroot` folder, create a `css` folder.

Add an `app.css` stylesheet to the `wwwroot/css` folder with the following content.

`wwwroot/css/app.css`:

```css
html, body {
    font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif;
}

.valid.modified:not([type=checkbox]) {
    outline: 1px solid #26b050;
}

.invalid {
    outline: 1px solid red;
}

.validation-message {
    color: red;
}

#blazor-error-ui {
    background: lightyellow;
    bottom: 0;
    box-shadow: 0 -1px 2px rgba(0, 0, 0, 0.2);
    display: none;
    left: 0;
    padding: 0.6rem 1.25rem 0.7rem 1.25rem;
    position: fixed;
    width: 100%;
    z-index: 1000;
}

    #blazor-error-ui .dismiss {
        cursor: pointer;
        position: absolute;
        right: 0.75rem;
        top: 0.5rem;
    }
```

Add the following `Counter` component to the root of the project, which is the default `Counter` component found in Blazor project templates.

`Counter.razor`:

```razor
<h1>Counter</h1>

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }
}
```

If the `MainWindow` designer isn't open, open it by double-clicking the `MainWindow.xaml` file in **Solution Explorer**. In the `MainWindow` designer, replace the XAML code with the following:

```xaml
<Window x:Class="WpfBlazor.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:blazor="clr-namespace:Microsoft.AspNetCore.Components.WebView.Wpf;assembly=Microsoft.AspNetCore.Components.WebView.Wpf"
        xmlns:local="clr-namespace:WpfBlazor"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <blazor:BlazorWebView HostPage="wwwroot\index.html" Services="{DynamicResource services}">
            <blazor:BlazorWebView.RootComponents>
                <blazor:RootComponent Selector="#app" ComponentType="{x:Type local:Counter}" />
            </blazor:BlazorWebView.RootComponents>
        </blazor:BlazorWebView>
    </Grid>
</Window>
```

In **Solution Explorer**, right-click `MainWindow.xaml` and select **View Code**:

:::image type="content" source="wpf/_static/view-mainwindow-code.png" alt-text="View MainWindow code.":::

Add the namespace <xref:Microsoft.Extensions.DependencyInjection?displayProperty=fullName> to the top of the `MainWindow.xaml.cs` file:

```csharp
using Microsoft.Extensions.DependencyInjection;
```

Inside the `MainWindow` constructor, above the `InitializeComponent()` method call, add the following code:

```csharp
var serviceCollection = new ServiceCollection();
serviceCollection.AddWpfBlazorWebView();
Resources.Add("services", serviceCollection.BuildServiceProvider());
```

The final, complete C# code of `MainWindow.xaml.cs`:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Extensions.DependencyInjection;

namespace WpfBlazor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWpfBlazorWebView();
            Resources.Add("services", serviceCollection.BuildServiceProvider());

            InitializeComponent();
        }
    }
}
```

## Run the app

Select the start button in the Visual Studio toolbar:

:::image type="content" source="wpf/_static/start-button.png" alt-text="Start button of the Visual Studio toolbar.":::

The app running on Windows:

:::image type="content" source="wpf/_static/running-app.png" alt-text="The app running on Windows.":::

## Next steps

In this tutorial, you learned how to:

> [!div class="checklist"]
> * Create a WPF Blazor app project
> * Add a Razor component to the project
> * Run the app on Windows

Learn more about Blazor Hybrid apps:

> [!div class="nextstepaction"]
> <xref:blazor/hybrid/index>
