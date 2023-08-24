:::moniker range=">= aspnetcore-8.0"

This guidance applies to server-side rendering (SSR) and interactivity of a Blazor Web App. The `Program` file is `Program.cs` of the server project (`BlazorWeb-CSharp`). Blazor script start configuration is found in the `App` component (`Components/App.razor`).

Routable components with an `@page` directive are placed in the `Components/Pages` folder. Non-routable shared components are placed in the `Components` folder.

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

This guidance applies to:

* The **`Server`** project of a hosted Blazor WebAssembly solution.
* A Blazor Server app. Blazor script start configuration is found in `Pages/_Host.cshtml`.

The `Program` file is `Program.cs`.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

This guidance applies to:

* The **`Server`** project of a hosted Blazor WebAssembly solution.
* A Blazor Server app. Blazor script start configuration is found in `Pages/_Layout.cshtml`.

The `Program` file is `Program.cs`.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

This guidance applies to:

* The **`Server`** project of a hosted Blazor WebAssembly solution.
* A Blazor Server app. Blazor script start configuration is found in `Pages/_Host.cshtml`.

The `Program` file is `Program.cs`.

:::moniker-end
