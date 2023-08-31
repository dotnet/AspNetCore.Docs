Throughout this article, the terms **client**/**client-side** and **server**/**server-side** are used to distinguish locations where app code executes:

:::moniker range=">= aspnetcore-8.0"

* **Client**/**client-side**
  * Client-side rendering (CSR) and interactivity of a Blazor Web App. The `Program` file is `Program.cs` of the client project (`BlazorWeb-CSharp.Client`). Blazor script start configuration is found in the `App` component (`Components/App.razor`) of the server project (`BlazorWeb-CSharp`).
  * A Blazor WebAssembly app. The `Program` file is `Program.cs`. Blazor script start configuration is found in the `wwwroot/index.html` file.
* **Server**/**server-side**: Server-side rendering (SSR) and interactivity of a Blazor Web App. The `Program` file is `Program.cs` of the server project (`BlazorWeb-CSharp`). Blazor script start configuration is found in the `App` component (`Components/App.razor`).

Routable components with an `@page` directive are placed in the `Components/Pages` folder. Non-routable shared components are placed in the `Components` folder.

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

* **Client**/**client-side**
  * The **`Client`** project of a hosted Blazor WebAssembly app.
  * A Blazor WebAssembly app.
  * Blazor script start configuration is found in the `wwwroot/index.html` file.
  * The `Program` file is `Program.cs`.
* **Server**/**server-side**
  * The **`Server`** project of a hosted Blazor WebAssembly app.
  * A Blazor Server app. Blazor script start configuration is found in `Pages/_Host.cshtml`.
  * The `Program` file is `Program.cs`.

:::moniker-end

:::moniker range="< aspnetcore-7.0"

* **Client**/**client-side**
  * The **`Client`** project of a hosted Blazor WebAssembly app.
  * A Blazor WebAssembly app.
  * Blazor script start configuration is found in the `wwwroot/index.html` file.
  * The `Program` file is `Program.cs`.
* **Server**/**server-side**
  * The **`Server`** project of a hosted Blazor WebAssembly app.
  * A Blazor Server app. Blazor script start configuration is found in `Pages/_Layout.cshtml`.
  * The `Program` file is `Program.cs`.

:::moniker-end
