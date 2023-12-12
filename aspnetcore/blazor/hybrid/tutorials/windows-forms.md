---
title: Build a Windows Forms Blazor app
author: guardrex
description: Build a Windows Forms Blazor app step-by-step.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/hybrid/tutorials/windows-forms
---
# Build a Windows Forms Blazor app

[!INCLUDE[](~/includes/not-latest-version.md)]

This tutorial shows you how to build and run a Windows Forms Blazor app. You learn how to:

> [!div class="checklist"]
> * Create a Windows Forms Blazor app project
> * Run the app on Windows

## Prerequisites

* [Supported platforms (Windows Forms documentation)](/dotnet/desktop/winforms/overview/)
* [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) with the **.NET desktop development** workload

## Visual Studio workload

If the **.NET desktop development** workload isn't installed, use the Visual Studio installer to install the workload. For more information, see [Modify Visual Studio workloads, components, and language packs](/visualstudio/install/modify-visual-studio).

:::image type="content" source="windows-forms/_static/install-workload.png" alt-text="Visual Studio installer .NET desktop development workload selection.":::

## Create a Windows Forms Blazor project

Launch Visual Studio. In the **Start Window**, select **Create a new project**:

:::image type="content" source="windows-forms/_static/new-solution.png" alt-text="Create a new solution in Visual Studio.":::

In the **Create a new project** dialog, filter the **Project type** dropdown to **Desktop**. Select the C# project template for **Windows Forms App** and select the **Next** button:

:::image type="content" source="windows-forms/_static/create-project.png" alt-text="Create a new project in Visual Studio.":::

In the **Configure your new project** dialog:

* Set the **Project name** to **:::no-loc text="WinFormsBlazor":::**.
* Choose a suitable location for the project.
* Select the **Next** button.

:::image type="content" source="windows-forms/_static/configure-project.png" alt-text="Configure the project.":::

In the **Additional information** dialog, select the framework version with the **Framework** dropdown list. Select the **Create** button:

:::image type="content" source="windows-forms/_static/additional-information.png" alt-text="The Additional Information dialog.":::

Use [NuGet Package Manager](/nuget/consume-packages/install-use-packages-visual-studio) to install the [`Microsoft.AspNetCore.Components.WebView.WindowsForms`](https://nuget.org/packages/Microsoft.AspNetCore.Components.WebView.WindowsForms) NuGet package:

:::image type="content" source="windows-forms/_static/nuget-package-manager.png" alt-text="Use Nuget Package Manager in Visual Studio to install the Microsoft.AspNetCore.Components.WebView.WindowsForms NuGet package.":::

In **Solution Explorer**, right-click the project's name, **:::no-loc text="WinFormsBlazor":::**, and select **Edit Project File** to open the project file (`WinFormsBlazor.csproj`).

At the top of the project file, change the SDK to `Microsoft.NET.Sdk.Razor`:

```xml
<Project Sdk="Microsoft.NET.Sdk.Razor">
```

Save the changes to the project file (`WinFormsBlazor.csproj`).

Add an `_Imports.razor` file to the root of the project with an [`@using`](xref:mvc/views/razor#using) directive for <xref:Microsoft.AspNetCore.Components.Web?displayProperty=fullName>.

`_Imports.razor`:

```razor
@using Microsoft.AspNetCore.Components.Web
```

Save the `_Imports.razor` file.

Add a `wwwroot` folder to the project.

Add an `index.html` file to the `wwwroot` folder with the following markup.

`wwwroot/index.html`:

```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>WinFormsBlazor</title>
    <base href="/" />
    <link href="css/app.css" rel="stylesheet" />
    <link href="WinFormsBlazor.styles.css" rel="stylesheet" />
</head>

<body>

    <div id="app">Loading...</div>

    <div id="blazor-error-ui" data-nosnippet>
        An unhandled error has occurred.
        <a href="" class="reload">Reload</a>
        <a class="dismiss">🗙</a>
    </div>

    <script src="_framework/blazor.webview.js"></script>

</body>

</html>
```

Inside the `wwwroot` folder, create a `css` folder to hold stylesheets.

Add an `app.css` stylesheet to the `wwwroot/css` folder with the following content.

`wwwroot/css/app.css`:

```css
html, body {
    font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif;
}

h1:focus {
    outline: none;
}

a, .btn-link {
    color: #0071c1;
}

.btn-primary {
    color: #fff;
    background-color: #1b6ec2;
    border-color: #1861ac;
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

Save the `Counter` component (`Counter.razor`).

In **Solution Explorer**, double-click on the `Form1.cs` file to open the designer:

:::image type="content" source="windows-forms/_static/solution-explorer-1.png" alt-text="The Form1.cs file in Solution Explorer.":::

Open the **Toolbox** by either selecting the **Toolbox** button along the left edge of the Visual Studio window or selecting the **View** > **Toolbox** menu command.

Locate the **`BlazorWebView`** control under **`Microsoft.AspNetCore.Components.WebView.WindowsForms`**. Drag the <xref:Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView> from the **Toolbox** into the `Form1` designer. Be careful not to accidentally drag a **`WebView2`** control into the form.

:::image type="content" source="windows-forms/_static/toolbox.png" alt-text="BlazorWebView in the Toolbox.":::

Visual Studio shows the <xref:Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView> control in the form designer as `WebView2` and automatically names the control `blazorWebView1`:

:::image type="content" source="windows-forms/_static/form1.png" alt-text="BlazorWebView in the Form1 designer.":::

In `Form1`, select the <xref:Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView> (`WebView2`) with a single click.

In the <xref:Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView>'s **Properties**, confirm that the control is named `blazorWebView1`. If the name isn't `blazorWebView1`, the wrong control was dragged from the **Toolbox**. Delete the `WebView2` control in `Form1` and drag the **`BlazorWebView` control** into the form.

:::image type="content" source="windows-forms/_static/control-properties.png" alt-text="The BlazorWebView is automatically named 'blazorWebView1' by Visual Studio.":::

In the control's properties, change the <xref:Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView>'s **Dock** value to **Fill**:

:::image type="content" source="windows-forms/_static/properties.png" alt-text="BlazorWebView properties with Dock set to Fill.":::

In the `Form1` designer, right-click `Form1` and select **View Code**.

Add namespaces for <xref:Microsoft.AspNetCore.Components.WebView.WindowsForms?displayProperty=fullName> and <xref:Microsoft.Extensions.DependencyInjection?displayProperty=fullName> to the top of the `Form1.cs` file:

```csharp
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
```

Inside the `Form1` constructor, after the `InitializeComponent` method call, add the following code:

```csharp
var services = new ServiceCollection();
services.AddWindowsFormsBlazorWebView();
blazorWebView1.HostPage = "wwwroot\\index.html";
blazorWebView1.Services = services.BuildServiceProvider();
blazorWebView1.RootComponents.Add<Counter>("#app");
```

> [!NOTE]
> The `InitializeComponent` method is generated by a source generator at app build time and added to the compilation object for the calling class.

The final, complete C# code of `Form1.cs` with a [file-scoped namespace](/dotnet/csharp/language-reference/keywords/namespace):

```csharp
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;

namespace WinFormsBlazor;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        var services = new ServiceCollection();
        services.AddWindowsFormsBlazorWebView();
        blazorWebView1.HostPage = "wwwroot\\index.html";
        blazorWebView1.Services = services.BuildServiceProvider();
        blazorWebView1.RootComponents.Add<Counter>("#app");
    }
}
```

## Run the app

Select the start button in the Visual Studio toolbar:

:::image type="content" source="windows-forms/_static/start-button.png" alt-text="Start button of the Visual Studio toolbar.":::

The app running on Windows:

:::image type="content" source="windows-forms/_static/running-app.png" alt-text="The app running on Windows.":::

## Next steps

In this tutorial, you learned how to:

> [!div class="checklist"]
> * Create a Windows Forms Blazor app project
> * Run the app on Windows

Learn more about Blazor Hybrid apps:

> [!div class="nextstepaction"]
> <xref:blazor/hybrid/index>
