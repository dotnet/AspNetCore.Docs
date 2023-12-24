This guidance applies to:

:::moniker range=">= aspnetcore-8.0"

* Interactive WebAssembly rendering in a Blazor Web App.
* A Blazor WebAssembly app.

Documentation component examples usually don't configure an interactive render mode with an `@rendermode` directive in the component's definition file (`.razor`):

* In a Blazor Web App, the component must have an interactive render mode applied, either in the component's definition file or inherited from a parent component. For more information, see <xref:blazor/components/render-modes>.

* In a standalone Blazor WebAssembly app, the components function as shown and don't require a render mode because components always run interactively on WebAssembly in a Blazor WebAssembly app.

When using the Interactive WebAssembly or Interactive Auto render modes, keep in mind that all of the component code is compiled and sent to the client, where users can decompile and inspect it. Don't place private code, app secrets, or other sensitive information in client-rendered components.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* The **`Client`** project of a hosted Blazor WebAssembly solution.
* A Blazor WebAssembly app.

:::moniker-end

For guidance on the purpose and locations of files and folders, see <xref:blazor/project-structure>, which also describes the [location of the Blazor start script](xref:blazor/project-structure#location-of-the-blazor-script) and the [location of `<head>` and `<body>` content](xref:blazor/project-structure#location-of-head-and-body-content).

The best way to run the demonstration code is to download the `BlazorSample_{PROJECT TYPE}` sample apps from the [`dotnet/blazor-samples` GitHub repository](https://github.com/dotnet/blazor-samples) that matches the version of .NET that you're targeting. Not all of the documentation examples are currently in the sample apps, but an effort is currently underway to move most of the .NET 8 article examples into the sample apps. This work will be completed in the first quarter of 2024.
