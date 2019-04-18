---
title: Get started with Blazor
author: guardrex
description: Learn how to get started with Blazor.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 04/18/2019
uid: blazor/get-started
---
# Get started with Blazor

By [Daniel Roth](https://github.com/danroth27) and [Luke Latham](https://github.com/guardrex)

In a few steps, get started with Blazor:

1. Install the latest [.NET Core 3.0 Preview SDK](https://dotnet.microsoft.com/download/dotnet-core/3.0) release.

1. Install the Blazor templates by running the following command in a command shell:

   ```console
   dotnet new -i Microsoft.AspNetCore.Blazor.Templates::3.0.0-preview4-19216-03
   ```

1. Follow the guidance for your choice of tooling:

   # [Visual Studio](#tab/visual-studio)
   
   1. Install the latest preview of [Visual Studio 2019](https://visualstudio.com/preview) with the **ASP.NET and web development** workload.
   1. Install the latest [Blazor extension](https://go.microsoft.com/fwlink/?linkid=870389) from the Visual Studio Marketplace. This step makes Blazor templates available to Visual Studio.
   1. Enable Visual Studio to use preview SDKs:
      1. Open **Tools** > **Options** in the menu bar.
      1. Open the **Projects and Solutions** node. Open the **.NET Core** tab.
      1. Check the box for **Use previews of the .NET Core SDK**. Select **OK**.
   1. Create a new project.
   1. Select **ASP.NET Core Web Application**. Select **Next**.
   1. Provide a name in the **Project name** field. Confirm the **Location** entry is correct or provide a location for the project. Select **Create**.
   1. Make sure **.NET Core** and **ASP.NET Core 3.0** are selected at the top.
   1. For an experience with Blazor server-side, choose the **Razor Components** template. The template will be renamed "Blazor (server-side)" in a future preview. For an experience with Blazor client-side, choose the **Blazor** template. Select **Create**.
   1. Press **F5** to run the app.
   
   # [Visual Studio Code](#tab/visual-studio-code)
   
   1. Install [Visual Studio Code](https://code.visualstudio.com/).
   1. Install the latest [C# for Visual Studio Code extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp).
   1. For an experience with Blazor server-side, execute the following command from a command shell:
   
      ```console
      dotnet new blazorserverside -o WebApplication1
      ```
   
      For an experience with Blazor client-side, execute the following command from a command shell:
   
      ```console
      dotnet new blazor -o WebApplication1
      ```
   
   1. Open the *WebApplication1* folder.
   1. When prompted by Visual Studio Code, add assets to build and debug the project:
   
      **Required assets to build and debug are missing from 'WebApplication1'. Add them?**
   
      Select **Yes**.
   
   1. Run the app using the Visual Studio Code debugger.
   
   <!--
   
   # [Visual Studio for Mac](#tab/visual-studio-mac)
   
   .NET Core 3.0 will be supported with Visual Studio for Mac version 8.0 or later. Visual Studio for Mac version 8.0 Preview isn't available at this time.
   
   Use the [.NET Core CLI version of this topic](xref:blazor/get-started?tabs=netcore-cli) on macOS.
   
   [!INCLUDE[](~/includes/net-core-prereqs-mac-3.0.md)]
   
   To create your first project Blazor (server-side) project in Visual Studio for Mac:
   
   1. Select **File** > **New Solution** or **New Project**.
   1. In the sidebar, select **.NET Core** > **App**.
   1. Select **ASP.NET Core Blazor (server-side)** and select **Next**.
   1. The **Target Framework** defaults to **.NET Core 3.0**. Select **Next**.
   1. In the **Project Name** field, enter `WebApplication1`. Select **Create**.
   1. Select **Run** > **Run Without Debugging** to run the app *without the debugger*. Running with the debugger isn't supported at this time.
   
   -->
   
   # [.NET Core CLI](#tab/netcore-cli/)
   
   For an experience with Blazor server-side, execute the following commands from a command shell:
   
   ```console
   dotnet new blazorserverside -o WebApplication1
   cd WebApplication1
   dotnet run
   ```
   
   For an experience with Blazor client-side, execute the following commands from a command shell:
   
   ```console
   dotnet new blazor -o WebApplication1
   cd WebApplication1
   dotnet run
   ```
  
   ---

In a browser, navigate to `https://localhost:5001`.

Multiple pages are available from tabs in the sidebar:

* Home
* Counter
* Fetch data

On the Counter page, select the **Click me** button to increment the counter without a page refresh. Incrementing a counter in a webpage normally requires writing JavaScript, but Razor components provide a better approach using C#.

*Pages/Counter.razor*:

[!code-cshtml[](get-started/samples_snapshot/3.x/Counter1.razor)]

A request for `/counter` in the browser, as specified by the `@page` directive at the top, causes the Counter component to render its content. Components render into an in-memory representation of the render tree that can then be used to update the UI in a flexible and efficient way.

Each time the **Click me** button is selected:

* The `onclick` event is fired.
* The `IncrementCount` method is called.
* The `currentCount` is incremented.
* The component is rendered again.

The runtime compares the new content to the previous content and only applies the changed content to the Document Object Model (DOM).

Add a component to another component using an HTML-like syntax. Component parameters are specified using attributes or child content. For example, a Counter component can be added to the app's homepage by adding a `<Counter />` element to the Index component.

*Pages/Index.razor*:

[!code-cshtml[](get-started/samples_snapshot/3.x/Index1.razor?highlight=7)]

Run the app. The homepage has its own counter.

To add a parameter to the Counter component, update the component's `@functions` block:

* Add a property for `IncrementAmount` decorated with the `[Parameter]` attribute.
* Change the `IncrementCount` method to use the `IncrementAmount` when increasing the value of `currentCount`.

*Pages/Counter.razor*:

[!code-cshtml[](get-started/samples_snapshot/3.x/Counter2.razor?highlight=4-5,9)]

Specify an `IncrementAmount` parameter in the Home component's `<Counter>` element using an attribute.

*Pages/Index.razor*:

[!code-cshtml[](get-started/samples_snapshot/3.x/Index2.razor)]

Run the app. The homepage has its own counter that increments by ten each time the **Click me** button is selected.

## Next steps

<xref:tutorials/first-blazor-app>
