This guidance applies to:

:::moniker range=">= aspnetcore-8.0"

* Interactive client rendering of a Blazor Web App. The `Program` file is `Program.cs` of the client project (`.Client`). Blazor script start configuration is found in the `App` component (`Components/App.razor`) of the server project. WebAssembly or Auto render mode components that are routable with an `@page` directive are placed in the client project's `Pages` folder. Place non-routable shared components at the root of the `.Client` project or in custom folders for components with related functionality that suit your taste.
* A Blazor WebAssembly app. The `Program` file is `Program.cs`. Blazor script start configuration is found in the `wwwroot/index.html` file.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* The **`Client`** project of a hosted Blazor WebAssembly solution.
* A Blazor WebAssembly app.

Blazor script start configuration is found in the `wwwroot/index.html` file. The `Program` file is `Program.cs`.

:::moniker-end
