This guidance applies to:

:::moniker range=">= aspnetcore-8.0"

* Client-side rendering (CSR) and interactivity of a Blazor Web App. The `Program` file is `Program.cs` of the client project (`BlazorWeb-CSharp.Client`). Routable components with an `@page` directive are placed in the `Pages` folder. Non-routable shared components are usually placed in a `Shared` folder. Blazor script start configuration is found in the `App` component (`Components/App.razor`) of the server project (`BlazorWeb-CSharp`).
* A Blazor WebAssembly app. The `Program` file is `Program.cs`. Blazor script start configuration is found in the `wwwroot/index.html` file.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* The **`Client`** project of a hosted Blazor WebAssembly solution.
* A Blazor WebAssembly app.

Blazor script start configuration is found in the `wwwroot/index.html` file. The `Program` file is `Program.cs`.

:::moniker-end
