---
title: Get started with ASP.NET Core Blazor
author: guardrex
description: Get started with Blazor by building a Blazor app with the tooling of your choice.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 09/05/2019
uid: blazor/get-started
---
# Get started with ASP.NET Core Blazor

By [Daniel Roth](https://github.com/danroth27) and [Luke Latham](https://github.com/guardrex)

Get started with Blazor:

1. Install the latest [.NET Core 3.0 Preview SDK](https://dotnet.microsoft.com/download/dotnet-core/3.0) release.

1. Install the Blazor templates by running the following command in a command shell:

   ```dotnetcli
   dotnet new -i Microsoft.AspNetCore.Blazor.Templates::3.0.0-preview9.19457.4
   ```

1. Follow the guidance for your choice of tooling:

   # [Visual Studio](#tab/visual-studio)

   1\. Install the latest [Visual Studio preview](https://visualstudio.com/vs/preview) with the **ASP.NET and web development** workload.

   2\. Create a new project.

   3\. Select **Blazor App**. Select **Next**.

   4\. Provide a project name in the **Project name** field or accept the default project name. Confirm the **Location** entry is correct or provide a location for the project. Select **Create**.

   5\. For a Blazor WebAssembly experience, choose the **Blazor WebAssembly App** template. For a Blazor Server experience, choose the **Blazor Server App** template. Select **Create**. For information on the two Blazor hosting models, *Blazor Server* and *Blazor WebAssembly*, see <xref:blazor/hosting-models>.

   6\. Press **F5** to run the app.

   > [!NOTE]
   > If you installed the Blazor Visual Studio extension for a prior preview release of ASP.NET Core Blazor (Preview 6 or earlier), you can uninstall the extension. Installing the Blazor templates in a command shell is now sufficient to surface the templates in Visual Studio.

   # [Visual Studio Code](#tab/visual-studio-code)

   1\. Install [Visual Studio Code](https://code.visualstudio.com/).

   2\. Install the latest [C# for Visual Studio Code extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp).

   3\. For a Blazor WebAssembly experience, execute the following command in a command shell:

      ```dotnetcli
      dotnet new blazorwasm -o WebApplication1
      ```

      For a Blazor Server experience, execute the following command in a command shell:

      ```dotnetcli
      dotnet new blazorserver -o WebApplication1
      ```

      For information on the two Blazor hosting models, *Blazor Server* and *Blazor WebAssembly*, see <xref:blazor/hosting-models>.

   4\. Open the *WebApplication1* folder in Visual Studio Code.

   5\. For a Blazor Server project, the IDE requests that you add assets to build and debug the project. Select **Yes**.

   6\. If using a Blazor Server app, run the app using the Visual Studio Code debugger. If using a Blazor WebAssembly app, execute `dotnet run` from the app's project folder.

   7\. In a browser, navigate to `https://localhost:5001`.

   <!--

   # [Visual Studio for Mac](#tab/visual-studio-mac)

   1\. Install [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/). Switch the [Update channel to Preview](/visualstudio/mac/install-preview).

   2\. Select **File** > **New Solution** or **New Project**.

   3\. In the sidebar, select **.NET Core** > **App**.

   4\. For a Blazor Server experience, select the **Blazor Server App** template. For a Blazor WebAssembly experience, select the **Blazor WebAssembly App** template. Select **Next**. For information on the two Blazor hosting models, *Blazor Server* and *Blazor WebAssembly*, see <xref:blazor/hosting-models>.

   5\. The **Target Framework** defaults to **.NET Core 3.0**. Select **Next**.

   6\. In the **Project Name** field, enter `WebApplication1`. Select **Create**.

   7\. Select **Run** > **Run Without Debugging** to run the app *without the debugger*. Running with the debugger isn't supported at this time.

   -->

   # [.NET Core CLI](#tab/netcore-cli/)

   For a Blazor WebAssembly experience, execute the following commands in a command shell:

   ```dotnetcli
   dotnet new blazorwasm -o WebApplication1
   cd WebApplication1
   dotnet run
   ```

   For a Blazor Server experience, execute the following commands in a command shell:

   ```dotnetcli
   dotnet new blazorserver -o WebApplication1
   cd WebApplication1
   dotnet run
   ```

   For information on the two Blazor hosting models, *Blazor Server* and *Blazor WebAssembly*, see <xref:blazor/hosting-models>.

   In a browser, navigate to `https://localhost:5001`.

   ---

Multiple pages are available from tabs in the sidebar:

* Home
* Counter
* Fetch data

On the Counter page, select the **Click me** button to increment the counter without a page refresh. Incrementing a counter in a webpage normally requires writing JavaScript, but Razor components provide a better approach using C#.

*Pages/Counter.razor*:

[!code-cshtml[](get-started/samples_snapshot/3.x/Counter1.razor?highlight=7,12-15)]

A request for `/counter` in the browser, as specified by the `@page` directive at the top, causes the `Counter` component to render its content. Components render into an in-memory representation of the render tree that can then be used to update the UI in a flexible and efficient way.

Each time the **Click me** button is selected:

* The `onclick` event is fired.
* The `IncrementCount` method is called.
* The `currentCount` is incremented.
* The component is rendered again.

The runtime compares the new content to the previous content and only applies the changed content to the Document Object Model (DOM).

Add a component to another component using HTML syntax. For example, add the `Counter` component to the app's homepage by adding a `<Counter />` element to the `Index` component.

*Pages/Index.razor*:

[!code-cshtml[](get-started/samples_snapshot/3.x/Index1.razor?highlight=7)]

Run the app. The homepage has its own counter provided by the `Counter` component.

Component parameters are specified using attributes or [child content](xref:blazor/components#child-content), which allow you to set properties on the child component. To add a parameter to the `Counter` component, update the component's `@code` block:

* Add a public property for `IncrementAmount` with a `[Parameter]` attribute.
* Change the `IncrementCount` method to use the `IncrementAmount` when increasing the value of `currentCount`.

*Pages/Counter.razor*:

[!code-cshtml[](get-started/samples_snapshot/3.x/Counter2.razor?highlight=12-13,17)]

Specify the `IncrementAmount` in the `Index` component's `<Counter>` element using an attribute.

*Pages/Index.razor*:

[!code-cshtml[](get-started/samples_snapshot/3.x/Index2.razor?highlight=7)]

Run the app. The `Index` component has its own counter that increments by ten each time the **Click me** button is selected. The `Counter` component (*Counter.razor*) at `/counter` continues to increment by one.

## Next steps

<xref:tutorials/first-blazor-app>

## Additional resources

* <xref:signalr/introduction>
