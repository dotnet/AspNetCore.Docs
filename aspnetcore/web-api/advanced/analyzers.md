---
title: Use web API analyzers
author: pranavkm
description: Learn about the ASP.NET Core MVC web API analyzers package.
monikerRange: '>= aspnetcore-2.2'
ms.author: prkrishn
ms.custom: mvc
ms.date: 09/05/2019
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: web-api/advanced/analyzers
---
# Use web API analyzers

ASP.NET Core 2.2 and later provides an MVC analyzers package intended for use with web API projects. The analyzers work with controllers annotated with <xref:Microsoft.AspNetCore.Mvc.ApiControllerAttribute>, while building on [web API conventions](xref:web-api/advanced/conventions).

The analyzers package notifies you of any controller action that:

* Returns an undeclared status code.
* Returns an undeclared success result.
* Documents a status code that isn't returned.
* Includes an explicit model validation check.

::: moniker range=">= aspnetcore-3.0"

## Reference the analyzer package

In ASP.NET Core 3.0 or later, the analyzers are included in the .NET Core SDK. To enable the analyzer in your project, include the `IncludeOpenAPIAnalyzers` property in the project file:

```xml
<PropertyGroup>
 <IncludeOpenAPIAnalyzers>true</IncludeOpenAPIAnalyzers>
</PropertyGroup>
```

::: moniker-end

::: moniker range="= aspnetcore-2.2"

## Package installation

Install the [Microsoft.AspNetCore.Mvc.Api.Analyzers](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Api.Analyzers) NuGet package with one of the following approaches:

### [Visual Studio](#tab/visual-studio)

From the **Package Manager Console** window:
  * Go to **View** > **Other Windows** > **Package Manager Console**.
  * Navigate to the directory in which the *ApiConventions.csproj* file exists.
  * Execute the following command:

    ```powershell
    Install-Package Microsoft.AspNetCore.Mvc.Api.Analyzers
    ```

### [Visual Studio for Mac](#tab/visual-studio-mac)

* Right-click the *Packages* folder in **Solution Pad** > **Add Packages...**.
* Set the **Add Packages** window's **Source** drop-down to "nuget.org".
* Enter "Microsoft.AspNetCore.Mvc.Api.Analyzers" in the search box.
* Select the "Microsoft.AspNetCore.Mvc.Api.Analyzers" package from the results pane and click **Add Package**.

### [Visual Studio Code](#tab/visual-studio-code)

Run the following command from the **Integrated Terminal**:

```dotnetcli
dotnet add ApiConventions.csproj package Microsoft.AspNetCore.Mvc.Api.Analyzers
```

### [.NET Core CLI](#tab/netcore-cli)

Run the following command:

```dotnetcli
dotnet add ApiConventions.csproj package Microsoft.AspNetCore.Mvc.Api.Analyzers
```

---

::: moniker-end

## Analyzers for web API conventions

OpenAPI documents contain status codes and response types that an action may return. In ASP.NET Core MVC, attributes such as <xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute> and <xref:Microsoft.AspNetCore.Mvc.ProducesAttribute> are used to document an action. <xref:tutorials/web-api-help-pages-using-swagger> goes into further detail on documenting your web API.

One of the analyzers in the package inspects controllers annotated with <xref:Microsoft.AspNetCore.Mvc.ApiControllerAttribute> and identifies actions that don't entirely document their responses. Consider the following example:

[!code-csharp[](conventions/sample/Controllers/ContactsController.cs?name=missing404docs&highlight=10)]

The preceding action documents the HTTP 200 success return type but doesn't document the HTTP 404 failure status code. The analyzer reports the missing documentation for the HTTP 404 status code as a warning. An option to fix the problem is provided.

![analyzer reporting a warning](conventions/_static/Analyzer.gif)

## Additional resources

* <xref:web-api/advanced/conventions>
* <xref:tutorials/web-api-help-pages-using-swagger>
* <xref:web-api/index>
