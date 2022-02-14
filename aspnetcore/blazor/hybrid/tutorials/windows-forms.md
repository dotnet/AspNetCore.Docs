---
title: Build a Windows Forms Blazor app
author: guardrex
description: Build a Windows Forms Blazor app step-by-step.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 02/14/2022
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/hybrid/tutorials/windows-forms
---
# Build a Windows Forms Blazor app

This tutorial shows you how to build and run a Windows Forms Blazor app. You learn how to:

> [!div class="checklist"]
> * Create a Windows Forms Blazor app project
> * Run the app on Windows

## Prerequisites

* [Supported platforms (Windows Forms documentation)](/dotnet/desktop/winforms/overview/)
* [Visual Studio 2022 Preview](https://visualstudio.microsoft.com/vs/preview/) with the **.NET desktop development** workload

## Visual Studio workload

If the **.NET desktop development** workload isn't installed, use the Visual Studio installer to install the workload:

:::image type="content" source="windows-forms/_static/install-workload.png" alt-text="Visual Studio installer .NET desktop development workload selection.":::

## Create Blazor projects to obtain assets

Using the .NET CLI, create a pair of Blazor projects. These donor Blazor projects are used later in the tutorial to supply assets to the Windows Forms project. Both donor Blazor projects are created with the name `WinFormsBlazor`. Later in the tutorial, the Windows Forms project is also created with the project name, `WinFormsBlazor`. By using the same name for the donor projects and the Windows Forms project, the namespaces match among the projects, which makes it possible to import donor assets into the Windows Forms project without the need to update namespaces.

Create two folders to hold Blazor projects for donating assets to the Windows Forms project:

* `BlazorServerDonor`
* `BlazorWebAssemblyDonor`

In a command shell open to the **`BlazorServerDonor` folder**, execute the following command. The command creates a folder named `WinFormsBlazor` with the `-n|--name` option and provides the project with the same project name:

```dotnetcli
dotnet new blazorserver -n WinFormsBlazor
```

In a command shell open to the **`BlazorWebAssemblyDonor` folder**, execute the following command. The command creates a folder named `WinFormsBlazor` with the `-n|--name` option and provides the project with the same project name:

```dotnetcli
dotnet new blazorwasm -o WinFormsBlazor
```

## Create a Windows Forms Blazor project

Start Visual Studio 2022 Preview. Select **Create a new project**.

In the **Create a new project** dialog, select the C# project template **Windows Forms App** and select the **Next** button:

:::image type="content" source="windows-forms/_static/create-project.png" alt-text="Create a new project in Visual Studio.":::

In the **Configure your new project** dialog, set the **Project name** to **`WinFormsBlazor`**, choose a suitable location for the project, and select the **Next** button. Using `WinFormsBlazor` as the project name matches the donor Blazor project names created in the preceding section, which aligns the namespaces of the three projects.

:::image type="content" source="windows-forms/_static/configure-project.png" alt-text="Configure the project.":::

In the **Additional information** dialog, select the framework version, which must be .NET 6.0 or later. Select the **Create** button.

In **Solution Explorer**, right-click the project's name, `WinFormsBlazor` and select **Edit Project File** to open the project file (`WinFormsBlazor.csproj`).

Make the following changes to the project file:

* Change the SDK to `Microsoft.NET.Sdk.Razor`:

  ```xml
  <Project Sdk="Microsoft.NET.Sdk.Razor">
  ```

* Add the following configuration inside of the closing `</Project>` tag. 

  ```xml
  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.Components.WebView.WindowsForms" Version="6.0.200-preview.12.2441" />
  </ItemGroup>

  <ItemGroup>
    <Content Update="wwwroot\**">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </Content>
  </ItemGroup>
  ```

Add a `Pages` folder to the Windows Forms project.

Add the following imports file to the root of the Windows Forms project.

`_Imports.razor`:

```razor
@using System.Net.Http
@using System.Net.Http.Json
@using Microsoft.AspNetCore.Components.Forms
@using Microsoft.AspNetCore.Components.Routing
@using Microsoft.AspNetCore.Components.Web
@using Microsoft.AspNetCore.Components.Web.Virtualization
@using Microsoft.JSInterop
@using WinFormsBlazor
@using WinFormsBlazor.Data
@using WinFormsBlazor.Shared
```

From the `BlazorWebAssemblyDonor` folder project, import the following folders into the root of the Windows Forms project:

* `Shared`
* `wwwroot`

In the Windows Forms project, delete the `wwwroot/sample-data` folder, which isn't used.

Open the `wwwroot/index.html` file in the Windows Forms project and change the Blazor script to the following:

```html
<script src="_framework/blazor.webview.js"></script>
```

From the `BlazorServerDonor` folder project:

* Import the `Data` folder into the root of the Windows Forms project.
* From the donor project's `Pages` folder, import the following components into the Windows Forms project's `Pages` folder:
  * `Counter.razor`
  * `FetchData.razor`
  * `Index.razor`

Add the following `Main` component to the Windows Forms project's `Pages` folder.

`Pages/Main.razor`:

```razor
<Router AppAssembly="@typeof(Program).Assembly" PreferExactMatches="@true">
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
    </Found>
    <NotFound>
        <LayoutView Layout="@typeof(MainLayout)">
            <p>Sorry, there's nothing at this address.</p>
        </LayoutView>
    </NotFound>
</Router>
```

Open the `Form1.Designer.cs` file from **Solution Explorer**:

:::image type="content" source="windows-forms/_static/solution-explorer-1.png" alt-text="The Form1.Designer.cs file in Solution Explorer.":::

Replace the contents of the file with the following code:

```csharp
namespace WinFormsBlazor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
    }
}
```

In **Solution Explorer**, right-click the `Form1.cs` file and select **View Code**:

:::image type="content" source="windows-forms/_static/solution-explorer-2.png" alt-text="The Form1.cs file in Solution Explorer.":::

Replace the contents of the file with the following code:

```csharp
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using WinFormsBlazor.Data;
using WinFormsBlazor.Pages;

namespace WinFormsBlazor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddBlazorWebView();
            serviceCollection.AddSingleton<WeatherForecastService>();

            var blazor = new BlazorWebView()
            {
                Dock = DockStyle.Fill,
                HostPage = "wwwroot/index.html",
                Services = serviceCollection.BuildServiceProvider(),
            };
            blazor.RootComponents.Add<Main>("#app");
            Controls.Add(blazor);
        }

    }
}
```

In the `Program.cs` file, replace the code in the `Main` method with the following:

```csharp
Application.SetHighDpiMode(HighDpiMode.SystemAware);
Application.EnableVisualStyles();
Application.SetCompatibleTextRenderingDefault(false);
Application.Run(new Form1());
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
