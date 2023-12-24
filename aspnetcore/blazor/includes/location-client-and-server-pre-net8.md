Throughout this article, the terms **server**/**server-side** and **client**/**client-side** are used to distinguish locations where app code executes:

:::moniker range=">= aspnetcore-8.0"

* **Server**/**server-side**: Interactive server-side rendering (interactive SSR) of a Blazor Web App.
* **Client**/**client-side**
  * Client-side rendering (CSR) of a Blazor Web App.
  * A Blazor WebAssembly app.

Documentation component examples usually don't configure an interactive render mode with an `@rendermode` directive in the component's definition file (`.razor`):

* In a Blazor Web App, the component must have an interactive render mode applied, either in the component's definition file or inherited from a parent component. For more information, see <xref:blazor/components/render-modes>.

* In a standalone Blazor WebAssembly app, the components function as shown and don't require a render mode because components always run interactively on WebAssembly in a Blazor WebAssembly app.

When using the Interactive WebAssembly or Interactive Auto render modes, component code sent to the client can be decompiled and inspected. Don't place private code, app secrets, or other sensitive information in client-rendered components.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* **Server**/**server-side**
  * The **`Server`** project of a hosted Blazor WebAssembly app.
  * A Blazor Server app.
* **Client**/**client-side**
  * The **`Client`** project of a hosted Blazor WebAssembly app.
  * A Blazor WebAssembly app.

:::moniker-end

For guidance on the purpose and locations of files and folders, see <xref:blazor/project-structure>, which also describes the [location of the Blazor start script](xref:blazor/project-structure#location-of-the-blazor-script) and the [location of `<head>` and `<body>` content](xref:blazor/project-structure#location-of-head-and-body-content).

The best way to run the demonstration code is to download the `BlazorSample_{PROJECT TYPE}` sample apps from the [`dotnet/blazor-samples` GitHub repository](https://github.com/dotnet/blazor-samples) that matches the version of .NET that you're targeting. Not all of the documentation examples are currently in the sample apps, but an effort is currently underway to move most of the .NET 8 article examples into the .NET 8 sample apps. This work will be completed in the first quarter of 2024.
