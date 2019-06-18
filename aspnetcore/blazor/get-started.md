---
title: Get started with ASP.NET Core Blazor
author: guardrex
description: Get started with Blazor by building a Blazor app with the tooling of your choice.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 06/14/2019
uid: blazor/get-started
---
# Get started with ASP.NET Core Blazor

By [Daniel Roth](https://github.com/danroth27) and [Luke Latham](https://github.com/guardrex)

Get started with Blazor:

1. Install the latest [.NET Core 3.0 Preview SDK](https://dotnet.microsoft.com/download/dotnet-core/3.0) release.

1. Install the Blazor templates by running the following command in a command shell:

   ```console
   dotnet new -i Microsoft.AspNetCore.Blazor.Templates::3.0.0-preview6.19307.2
   ```

1. Follow the guidance for your choice of tooling:

   # [Visual Studio](#tab/visual-studio)

   1\. Install the latest [Visual Studio preview](https://visualstudio.com/preview) with the **ASP.NET and web development** workload.

   2\. Install the latest [Blazor extension](https://go.microsoft.com/fwlink/?linkid=870389) from the Visual Studio Marketplace. This step makes Blazor templates available to Visual Studio.

   3\. Create a new project.

   4\. Select **ASP.NET Core Web Application**. Select **Next**.

   5\. Provide a project name in the **Project name** field or accept the default project name. Confirm the **Location** entry is correct or provide a location for the project. Select **Create**.

   6\. In the **Create a new ASP.NET Core Web Application** dialog, confirm that **.NET Core** and **ASP.NET Core 3.0** are selected.

   7\. For a Blazor client-side experience, choose the **Blazor (client-side)** template. For a Blazor server-side experience, choose the **Blazor (server-side)** template. Select **Create**. For information on the two Blazor hosting models, server-side and client-side, see <xref:blazor/hosting-models>.

   8\. Press **F5** to run the app.

   # [Visual Studio Code](#tab/visual-studio-code)
   
   1\. Install [Visual Studio Code](https://code.visualstudio.com/).

   2\. Install the latest [C# for Visual Studio Code extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp).

   3\. For a Blazor client-side experience, execute the following command from a command shell:

      ```console
      dotnet new blazor -o WebApplication1
      ```

      For a Blazor server-side experience, execute the following command from a command shell:

      ```console
      dotnet new blazorserverside -o WebApplication1
      ```

      For information on the two Blazor hosting models, server-side and client-side, see <xref:blazor/hosting-models>.

   4\. Open the *WebApplication1* folder in Visual Studio Code.

   5\. For a Blazor server-side project, the IDE requests that you add assets to build and debug the project. Select **Yes**.

   6\. If using a Blazor server-side app, run the app using the Visual Studio Code debugger. If using a Blazor client-side app, execute `dotnet run` from the app's project folder.

   7\. In a browser, navigate to `https://localhost:5001`.

   <!--

   # [Visual Studio for Mac](#tab/visual-studio-mac)

   1\. Install [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/). Switch the [Update channel to Preview](/visualstudio/mac/install-preview).

   2\. Select **File** > **New Solution** or **New Project**.

   3\. In the sidebar, select **.NET Core** > **App**.

   4\. For a Blazor server-side experience, select the **ASP.NET Core Blazor (server-side)** template. For a Blazor client-side experience, select the **ASP.NET Core Blazor (client-side)** template. Select **Next**. For information on the two Blazor hosting models, server-side and client-side, see <xref:blazor/hosting-models>.

   5\. The **Target Framework** defaults to **.NET Core 3.0**. Select **Next**.

   6\. In the **Project Name** field, enter `WebApplication1`. Select **Create**.

   7\. Select **Run** > **Run Without Debugging** to run the app *without the debugger*. Running with the debugger isn't supported at this time.

   -->

   # [.NET Core CLI](#tab/netcore-cli/)

   For a Blazor client-side experience, execute the following commands from a command shell:

   ```console
   dotnet new blazor -o WebApplication1
   cd WebApplication1
   dotnet run
   ```

   For a Blazor server-side experience, execute the following commands from a command shell:

   ```console
   dotnet new blazorserverside -o WebApplication1
   cd WebApplication1
   dotnet run
   ```

   For information on the two Blazor hosting models, server-side and client-side, see <xref:blazor/hosting-models>.

   In a browser, navigate to `https://localhost:5001`.

   ---

Multiple pages are available from tabs in the sidebar:

* Home
* Counter
* Fetch data

On the Counter page, select the **Click me** button to increment the counter without a page refresh. Incrementing a counter in a webpage normally requires writing JavaScript, but Razor components provide a better approach using C#.

*Pages/Counter.razor*:

[!code-cshtml[](get-started/samples_snapshot/3.x/Counter1.razor?highlight=7,12-15)]

A request for `/counter` in the browser, as specified by the `@page` directive at the top, causes the Counter component to render its content. Components render into an in-memory representation of the render tree that can then be used to update the UI in a flexible and efficient way.

Each time the **Click me** button is selected:

* The `onclick` event is fired.
* The `IncrementCount` method is called.
* The `currentCount` is incremented.
* The component is rendered again.

The runtime compares the new content to the previous content and only applies the changed content to the Document Object Model (DOM).

Add a component to another component using HTML syntax. For example, add the Counter component to the app's homepage by adding a `<Counter />` element to the Index component.

*Pages/Index.razor*:

[!code-cshtml[](get-started/samples_snapshot/3.x/Index1.razor?highlight=7)]

Run the app. The homepage has its own counter provided by the Counter component.

Component parameters are specified using attributes or [child content](xref:blazor/components#child-content), which allow you to set properties on the child component. To add a parameter to the Counter component, update the component's `@code` block:

* Add a property for `IncrementAmount` with a `[Parameter]` attribute.
* Change the `IncrementCount` method to use the `IncrementAmount` when increasing the value of `currentCount`.

*Pages/Counter.razor*:

[!code-cshtml[](get-started/samples_snapshot/3.x/Counter2.razor?highlight=12-13,17)]

Specify the `IncrementAmount` in the Index component's `<Counter>` element using an attribute.

*Pages/Index.razor*:

[!code-cshtml[](get-started/samples_snapshot/3.x/Index2.razor?highlight=7)]

Run the app. The Index component has its own counter that increments by ten each time the **Click me** button is selected. The Counter component (*Counter.razor*) at `/counter` continues to increment by one.

## Next steps

<xref:tutorials/first-blazor-app>

## Additional resources

* <xref:signalr/introduction>
