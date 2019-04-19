---
title: Get started with Blazor
author: guardrex
description: Learn how to get started with Blazor.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 04/19/2019
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
   2. Install the latest [Blazor extension](https://go.microsoft.com/fwlink/?linkid=870389) from the Visual Studio Marketplace. This step makes Blazor templates available to Visual Studio.
   3. Enable Visual Studio to use preview SDKs:
   
      a. Open **Tools** > **Options** in the menu bar.
      b. Open the **Projects and Solutions** node. Open the **.NET Core** tab.
      c. Check the box for **Use previews of the .NET Core SDK**. Select **OK**.

   4. Create a new project.
   5. Select **ASP.NET Core Web Application**. Select **Next**.
   6. Provide a name in the **Project name** field. Confirm the **Location** entry is correct or provide a location for the project. Select **Create**.
   7. Make sure **.NET Core** and **ASP.NET Core 3.0** are selected at the top.
   8. For an experience with Blazor client-side, choose the **Blazor (client-side)** template. For an experience with Blazor server-side, choose the **Blazor (server-side)** template. Select **Create**.
   9. Press **F5** to run the app.

   # [Visual Studio Code](#tab/visual-studio-code)
   
   1. Install [Visual Studio Code](https://code.visualstudio.com/).
   2. Install the latest [C# for Visual Studio Code extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp).
   3. For an experience with Blazor client-side, execute the following command from a command shell:

      ```console
      dotnet new blazor -o WebApplication1
      ```

      For an experience with Blazor server-side, execute the following command from a command shell:

      ```console
      dotnet new blazorserverside -o WebApplication1
      ```

      > [!NOTE]
      > Only Blazor client-side is supported on macOS in ASP.NET Core 3.0 Preview 4. For more information, see [Blazor server side: dotnet run fails with InvalidOperationException on MacOS](https://github.com/aspnet/AspNetCore/issues/9402).

   4. Open the *WebApplication1* folder in Visual Studio Code.
   5. When prompted by Visual Studio Code for a Blazor server-side project, add assets to build the project:

      **Required assets to build and debug are missing from 'WebApplication1'. Add them?**

      Select **Yes**.

   6. If using a Blazor server-side app, run the app using the Visual Studio Code debugger. If using a Blazor client-side app, execute `dotnet run` from the app's project folder.

   <!--

   # [Visual Studio for Mac](#tab/visual-studio-mac)

   1. Install [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/). Switch the [Update channel to Preview](/visualstudio/mac/install-preview).
   2. Select **File** > **New Solution** or **New Project**.
   3. In the sidebar, select **.NET Core** > **App**.
   4. For an experience with Blazor server-side, select the **ASP.NET Core Blazor (server-side)** template. For an experience with Blazor server-side, select the **ASP.NET Core Blazor (client-side)** template. Select **Next**.
   5. The **Target Framework** defaults to **.NET Core 3.0**. Select **Next**.
   6. In the **Project Name** field, enter `WebApplication1`. Select **Create**.
   7. Select **Run** > **Run Without Debugging** to run the app *without the debugger*. Running with the debugger isn't supported at this time.

   -->

   # [.NET Core CLI](#tab/netcore-cli/)

   For an experience with Blazor client-side, execute the following commands from a command shell:

   ```console
   dotnet new blazor -o WebApplication1
   cd WebApplication1
   dotnet run
   ```

   For an experience with Blazor server-side, execute the following commands from a command shell:

   ```console
   dotnet new blazorserverside -o WebApplication1
   cd WebApplication1
   dotnet run
   ```

   > [!NOTE]
   > On macOS, use a Blazor client-side app. Blazor server-side isn't supported for macOS on ASP.NET Core 3.0 Preview 4. For more information, see [Blazor server side: dotnet run fails with InvalidOperationException on MacOS](https://github.com/aspnet/AspNetCore/issues/9402).

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

## Additional resources

* <xref:signalr/introduction>
