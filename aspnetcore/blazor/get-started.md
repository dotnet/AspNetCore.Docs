---
title: Get started with ASP.NET Core Blazor
author: guardrex
description: Get started with Blazor by building a Blazor app with the tooling of your choice.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 03/26/2020
no-loc: [Blazor, SignalR]
uid: blazor/get-started
---
# Get started with ASP.NET Core Blazor

By [Daniel Roth](https://github.com/danroth27) and [Luke Latham](https://github.com/guardrex)

[!INCLUDE[](~/includes/blazorwasm-preview-notice.md)]

To get started with Blazor, follow the guidance for your choice of tooling:

# [Visual Studio](#tab/visual-studio)

1. To create Blazor Server apps, install [Visual Studio 2019 version 16.4 or later](https://visualstudio.microsoft.com/vs/preview/) with the **ASP.NET and web development** workload.

   To create Blazor Server and Blazor WebAssembly apps, install Visual Studio 2019 16.6 Preview 2 or later with the **ASP.NET and web development** workload.

   For information on the two Blazor hosting models, *Blazor WebAssembly* and *Blazor Server*, see <xref:blazor/hosting-models>.

1. Create a new project.

1. Select **Blazor App**. Select **Next**.

1. Provide a project name in the **Project name** field or accept the default project name. Confirm the **Location** entry is correct or provide a location for the project. Select **Create**.

1. For a Blazor WebAssembly experience (Visual Studio 16.6 Preview 2 or later), choose the **Blazor WebAssembly App** template. For a Blazor Server experience (Visual Studio 16.4 or later), choose the **Blazor Server App** template. Select **Create**.

1. Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> to run the app.

# [Visual Studio Code](#tab/visual-studio-code)

1. Install the [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1).

1. Optionally install the [Blazor WebAssembly](xref:blazor/hosting-models#blazor-webassembly) preview template by running the following command:

   ```dotnetcli
   dotnet new -i Microsoft.AspNetCore.Components.WebAssembly.Templates::3.2.0-preview3.20168.3
   ```

   > [!NOTE]
   > The [.NET Core SDK version 3.1.201 or later](https://dotnet.microsoft.com/download/dotnet-core/3.1) is **required** to use the 3.2 Preview 3 Blazor WebAssembly template. Confirm the installed .NET Core SDK version by running `dotnet --version` in a command shell.

1. Install [Visual Studio Code](https://code.visualstudio.com/).

1. Install the latest [C# for Visual Studio Code extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) and the [JavaScript Debugger (Nightly)](https://marketplace.visualstudio.com/items?itemName=ms-vscode.js-debug-nightly) extension with `debug.javascript.usePreview` set to `true`.

1. For a Blazor Server experience, execute the following command in a command shell:

   ```dotnetcli
   dotnet new blazorserver -o WebApplication1
   ```

   For a Blazor WebAssembly experience, execute the following command in a command shell:

   ```dotnetcli
   dotnet new blazorwasm -o WebApplication1
   ```

   For information on the two Blazor hosting models, *Blazor Server* and *Blazor WebAssembly*, see <xref:blazor/hosting-models>.

1. Open the *WebApplication1* folder in Visual Studio Code.

1. The IDE requests that you add assets to build and debug the project. Select **Yes**.

1. Run the app using the Visual Studio Code debugger.

1. In a browser, navigate to `https://localhost:5001`.

# [Visual Studio for Mac](#tab/visual-studio-mac)

Blazor Server is supported in Visual Studio for Mac. Blazor WebAssembly isn't supported at this time. To build Blazor WebAssembly apps on macOS, follow the guidance on the **.NET Core CLI** tab.

1. Install [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/).

1. Select **File** > **New Solution** or create a **New Project**.

1. In the sidebar, select **.NET Core** > **App**.

1. Select the **Blazor Server App** template. Select **Create**.

   For information on the Blazor Server hosting model, see <xref:blazor/hosting-models>.

1. Set the **Target Framework** to **.NET Core 3.1** and select **Next**.

1. In the **Project Name** field, name the app `WebApplication1`. Select **Create**.

1. Select **Run** > **Run Without Debugging** to run the app *without the debugger*. Run the app with **Start Debugging** to run the app *with the debugger*.

If a prompt appears to trust the development certificate, trust the certificate and continue.

# [.NET Core CLI](#tab/netcore-cli/)

1. Install the [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1).

1. Optionally install the [Blazor WebAssembly](xref:blazor/hosting-models#blazor-webassembly) preview template by running the following command:

   ```dotnetcli
   dotnet new -i Microsoft.AspNetCore.Components.WebAssembly.Templates::3.2.0-preview3.20168.3
   ```

   > [!NOTE]
   > The [.NET Core SDK version 3.1.201 or later](https://dotnet.microsoft.com/download/dotnet-core/3.1) is **required** to use the 3.2 Preview 3 Blazor WebAssembly template. Confirm the installed .NET Core SDK version by running `dotnet --version` in a command shell.

1. For a Blazor Server experience, execute the following commands in a command shell:

   ```dotnetcli
   dotnet new blazorserver -o WebApplication1
   cd WebApplication1
   dotnet run
   ```

   For a Blazor WebAssembly experience, execute the following commands in a command shell:

   ```dotnetcli
   dotnet new blazorwasm -o WebApplication1
   cd WebApplication1
   dotnet run
   ```

   For information on the two Blazor hosting models, *Blazor Server* and *Blazor WebAssembly*, see <xref:blazor/hosting-models>.

1. In a browser, navigate to `https://localhost:5001`.

---

Multiple pages are available from tabs in the sidebar:

* Home
* Counter
* Fetch data

On the Counter page, select the **Click me** button to increment the counter without a page refresh. Incrementing a counter in a webpage normally requires writing JavaScript, but with Blazor you can use C#.

*Pages/Counter.razor*:

[!code-razor[](get-started/samples_snapshot/3.x/Counter1.razor?highlight=7,12-15)]

A request for `/counter` in the browser, as specified by the `@page` directive at the top, causes the `Counter` component to render its content. Components render into an in-memory representation of the render tree that can then be used to update the UI in a flexible and efficient way.

Each time the **Click me** button is selected:

* The `onclick` event is fired.
* The `IncrementCount` method is called.
* The `currentCount` is incremented.
* The component is rendered again.

The runtime compares the new content to the previous content and only applies the changed content to the Document Object Model (DOM).

Add a component to another component using HTML syntax. For example, add the `Counter` component to the app's homepage by adding a `<Counter />` element to the `Index` component.

*Pages/Index.razor*:

[!code-razor[](get-started/samples_snapshot/3.x/Index1.razor?highlight=7)]

Run the app. The homepage has its own counter provided by the `Counter` component.

Component parameters are specified using attributes or [child content](xref:blazor/components#child-content), which allow you to set properties on the child component. To add a parameter to the `Counter` component, update the component's `@code` block:

* Add a public property for `IncrementAmount` with a `[Parameter]` attribute.
* Change the `IncrementCount` method to use the `IncrementAmount` when increasing the value of `currentCount`.

*Pages/Counter.razor*:

[!code-razor[](get-started/samples_snapshot/3.x/Counter2.razor?highlight=12-13,17)]

Specify the `IncrementAmount` in the `Index` component's `<Counter>` element using an attribute.

*Pages/Index.razor*:

[!code-razor[](get-started/samples_snapshot/3.x/Index2.razor?highlight=7)]

Run the app. The `Index` component has its own counter that increments by ten each time the **Click me** button is selected. The `Counter` component (*Counter.razor*) at `/counter` continues to increment by one.

## Next steps

<xref:tutorials/first-blazor-app>

## Additional resources

* <xref:blazor/templates>
* <xref:signalr/introduction>
