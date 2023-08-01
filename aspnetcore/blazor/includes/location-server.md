:::moniker range=">= aspnetcore-8.0"

This guidance applies to the server of a Blazor Web App. Blazor script start configuration is found in the `App` component (`App.razor`). The `Program` file is `Program.cs` without interactive WebAssembly components or `Program.Server.cs` with interactive WebAssembly components.

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
