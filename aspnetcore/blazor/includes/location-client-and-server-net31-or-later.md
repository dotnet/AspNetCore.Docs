Throughout this article, the terms **client**/**client-side** and **server**/**server-side** are used to distinguish locations where app code executes:

:::moniker range=">= aspnetcore-8.0"

* **Client**/**client-side**
  * Client-side rendering (CSR) of a Blazor Web App.
  * A Blazor WebAssembly app.
* **Server**/**server-side**: Interactive server-side rendering (interactive SSR) of a Blazor Web App.

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

* **Client**/**client-side**
  * The **`Client`** project of a hosted Blazor WebAssembly app.
  * A Blazor WebAssembly app.
* **Server**/**server-side**
  * The **`Server`** project of a hosted Blazor WebAssembly app.
  * A Blazor Server app.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

* **Client**/**client-side**
  * The **`Client`** project of a hosted Blazor WebAssembly app.
  * A Blazor WebAssembly app.
* **Server**/**server-side**
  * The **`Server`** project of a hosted Blazor WebAssembly app.
  * A Blazor Server app.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

* **Client**/**client-side**
  * The **`Client`** project of a hosted Blazor WebAssembly app.
  * A Blazor WebAssembly app.
* **Server**/**server-side**
  * The **`Server`** project of a hosted Blazor WebAssembly app.
  * A Blazor Server app.

:::moniker-end

For guidance on the purpose and locations of files and folders, see <xref:blazor/project-structure>, which also describes the [location of the Blazor start script](xref:blazor/project-structure#location-of-the-blazor-script) and the [location of `<head>` and `<body>` content](xref:blazor/project-structure#location-of-head-and-body-content).

Interactive component examples throughout the documentation don't indicate an interactive render mode. To make the examples interactive, either [inherit an interactive render mode for a child component from a parent component](xref:blazor/components/render-modes#apply-a-render-mode-to-a-component-instance), [apply an interactive render mode to a component definition](xref:blazor/components/render-modes#apply-a-render-mode-to-a-component-definition), or [globally set the render mode for the entire app](xref:blazor/components/render-modes#apply-a-render-mode-to-the-entire-app). The best way to run the demonstration code is to download the `BlazorSample_{PROJECT TYPE}` sample apps from the [`dotnet/blazor-samples` GitHub repository](https://github.com/dotnet/blazor-samples).
