:::moniker range=">= aspnetcore-8.0"

This guidance applies to components that adopt interactive server-side rendering (interactive SSR) in a Blazor Web App, which operates over a SignalR connection with the client.

Documentation component examples usually don't configure an interactive render mode with an `@rendermode` directive in the component's definition file (`.razor`), but the component must have the Interactive Server render mode applied (`@rendermode InteractiveServer`), either in the component's definition file or inherited from a parent component. For more information, see <xref:blazor/components/render-modes>.

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

This guidance applies to:

* The **`Server`** project of a hosted Blazor WebAssembly solution.
* A Blazor Server app.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

This guidance applies to:

* The **`Server`** project of a hosted Blazor WebAssembly solution.
* A Blazor Server app.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

This guidance applies to:

* The **`Server`** project of a hosted Blazor WebAssembly solution.
* A Blazor Server app.

:::moniker-end

For guidance on the purpose and locations of files and folders, see <xref:blazor/project-structure>, which also describes the [location of the Blazor start script](xref:blazor/project-structure#location-of-the-blazor-script) and the [location of `<head>` and `<body>` content](xref:blazor/project-structure#location-of-head-and-body-content).

The best way to run the demonstration code is to download the `BlazorSample_{PROJECT TYPE}` sample apps from the [`dotnet/blazor-samples` GitHub repository](https://github.com/dotnet/blazor-samples) that matches the version of .NET that you're targeting. Not all of the documentation examples are currently in the sample apps, but an effort is currently underway to move most of the .NET 8 article examples into the sample apps. This work will be completed in the first quarter of 2024.
