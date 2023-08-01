Throughout this article, the terms **client**/**client-side** and **server**/**server-side** are used to distinguish locations where app code executes:

:::moniker range=">= aspnetcore-8.0"

* **Client**/**client-side**
  * The client of a Blazor Web App. Blazor script start configuration is found in the `App` component (`App.razor`).
  * A Blazor WebAssembly app. Blazor script start configuration is found in the `wwwroot/index.html` file.
* **Server**/**server-side**: The server of a Blazor Web App. Blazor script start configuration is found in the `App` component (`App.razor`).

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

* **Client**/**client-side**
  * The **`Client`** project of a hosted Blazor WebAssembly app.
  * A Blazor WebAssembly app.
  * Blazor script start configuration is found in the `wwwroot/index.html` file.
* **Server**/**server-side**
  * The **`Server`** project of a hosted Blazor WebAssembly app.
  * A Blazor Server app. Blazor script start configuration is found in `Pages/_Host.cshtml`.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

* **Client**/**client-side**
  * The **`Client`** project of a hosted Blazor WebAssembly app.
  * A Blazor WebAssembly app.
  * Blazor script start configuration is found in the `wwwroot/index.html` file.
* **Server**/**server-side**
  * The **`Server`** project of a hosted Blazor WebAssembly app.
  * A Blazor Server app. Blazor script start configuration is found in `Pages/_Layout.cshtml`.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

* **Client**/**client-side**
  * The **`Client`** project of a hosted Blazor WebAssembly app.
  * A Blazor WebAssembly app.
  * Blazor script start configuration is found in the `wwwroot/index.html` file.
* **Server**/**server-side**
  * The **`Server`** project of a hosted Blazor WebAssembly app.
  * A Blazor Server app. Blazor script start configuration is found in `Pages/_Host.cshtml`.

:::moniker-end
