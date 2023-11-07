---
title: Secure ASP.NET Core Blazor WebAssembly with ASP.NET Core Identity
author: guardrex
description: Learn how to secure Blazor WebAssembly apps with ASP.NET Core Identity.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/06/2023
uid: blazor/security/webassembly/standalone-with-identity
---
# Secure ASP.NET Core Blazor WebAssembly with ASP.NET Core Identity

<!-- UPDATE 9.0

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

Standalone Blazor WebAssembly apps can be secured with ASP.NET Core Identity by following the guidance in this article.

## Sample apps

In this article, sample apps serve as a reference for standalone Blazor WebAssembly apps that access ASP.NET Core Identity through a backend web API. The demonstration includes two apps:

* `Backend`: A backend web API app that maintains a user identity store for ASP.NET Core Identity.
* `BlazorWasmAuth`: A standalone Blazor WebAssembly frontend app with user authentication.

Access the sample apps through the latest version folder from the repository's root with the following link. The samples are provided for .NET 8 or later. See the `README` file in the `BlazorWebAssemblyStandaloneWithIdentity` folder for steps on how to run the sample apps.

[View or download sample code](https://github.com/dotnet/blazor-samples) ([how to download](xref:index#how-to-download-a-sample))

## Backend web API app

The backend web API app maintains a user identity store for ASP.NET Core Identity.

### Packages

The app uses the following NuGet packages:

* [`Microsoft.AspNetCore.Identity`](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity)
* [`Microsoft.AspNetCore.Identity.EntityFrameworkCore`](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.EntityFrameworkCore)
* [`Microsoft.EntityFrameworkCore.InMemory`](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.InMemory)
* [`Microsoft.AspNetCore.OpenApi`](https://www.nuget.org/packages/Microsoft.AspNetCore.OpenApi)
* [`Swashbuckle.AspNetCore`](https://www.nuget.org/packages/Swashbuckle.AspNetCore)

If your app is to use a different EF Core database provider than the in-memory provider, don't create a package reference in your app for `Microsoft.EntityFrameworkCore.InMemory`.

If your app won't adopt [Swagger/OpenAPI](xref:tutorials/web-api-help-pages-using-swagger), don't create package references for `Microsoft.AspNetCore.OpenApi` and `Swashbuckle.AspNetCore`.

In the app's project file (`.csproj`), [invariant globalization](xref:blazor/globalization-localization#invariant-globalization) is configured.

### Sample app code

[App settings](https://github.com/dotnet/blazor-samples/blob/main/8.0/BlazorWebAssemblyStandaloneWithIdentity/Backend/appsettings.json) configure backend and frontend URLs:

* `Backend` app (`BackendUrl`): `https://localhost:7211`
* `BlazorWasmAuth` app (`FrontendUrl`): `https://localhost:7171`

The [`Backend.http` file](https://github.com/dotnet/blazor-samples/blob/main/8.0/BlazorWebAssemblyStandaloneWithIdentity/Backend/Backend.http) can be used for testing the weather data request. Note that the `BlazorWasmAuth` app must be running to test the endpoint, and the endpoint is hardcoded into the file. For more information, see <xref:test/http-files>.

The following setup and configruation is found in the app's [`Program` file](https://github.com/dotnet/blazor-samples/blob/main/8.0/BlazorWebAssemblyStandaloneWithIdentity/Backend/Program.cs). 

Only recommended for demonstrations, the backend web API of the `Backend` sample app uses the [EF Core in-memory database provider](/ef/core/providers/in-memory/) for user identity with cookie authentication.

A [Cross-Origin Resource Sharing (CORS)](xref:security/cors) policy is established to permit requests from the frontend and backend apps. Fallback URLs are configured for the CORS policy if app settings don't provide them:

* `Backend` app (`BackendUrl`): `https://localhost:5001`
* `BlazorWasmAuth` app (`FrontendUrl`): `https://localhost:5002`

Services and endpoints for [Swagger/OpenAPI](xref:tutorials/web-api-help-pages-using-swagger) are included for web API documentation and development testing.

A logout endpoint (`/Logout`) is configured in the middleware pipeline to sign users out.

For more information on basic patterns for initialization and configuration of a <xref:Microsoft.EntityFrameworkCore.DbContext> instance, see
[DbContext Lifetime, Configuration, and Initialization](/ef/core/dbcontext-configuration/) in the EF Core documentation.

## Frontend standalone Blazor WebAssembly app

A standalone Blazor WebAssembly frontend app demonstrates user authentication and authorization to access a private webpage.

### Packages

The app uses the following NuGet packages:

* [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication)
* [`Microsoft.Extensions.Http`](https://www.nuget.org/packages/Microsoft.Extensions.Http)
* [`Microsoft.AspNetCore.Components.WebAssembly`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly)
* [`Microsoft.AspNetCore.Components.WebAssembly.DevServer`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.DevServer)

### Sample app code

The `Models` folder contains the app's models:

* [`FormResult` (`Identity/Models/FormResult.cs`)](https://github.com/dotnet/blazor-samples/blob/main/8.0/BlazorWebAssemblyStandaloneWithIdentity/BlazorWasmAuth/Identity/Models/FormResult.cs): Response for login and registration.
* [`UserBasic` (`Identity/Models/UserBasic.cs`)](https://github.com/dotnet/blazor-samples/blob/main/8.0/BlazorWebAssemblyStandaloneWithIdentity/BlazorWasmAuth/Identity/Models/UserBasic.cs): Basic user information to register and login.
* [`UserInfo` (`Identity/Models/UserInfo.cs`)](https://github.com/dotnet/blazor-samples/blob/main/8.0/BlazorWebAssemblyStandaloneWithIdentity/BlazorWasmAuth/Identity/Models/UserInfo.cs): User info from identity endpoint to establish claims.

The [`IAccountManagement` interface (`Identity/CookieHandler.cs`)](https://github.com/dotnet/blazor-samples/blob/main/8.0/BlazorWebAssemblyStandaloneWithIdentity/BlazorWasmAuth/Identity/IAccountManagement.cs) provides account management services.

The [`CookieAuthenticationStateProvider` class (`Identity/CookieAuthenticationStateProvider.cs`)](https://github.com/dotnet/blazor-samples/blob/main/8.0/BlazorWebAssemblyStandaloneWithIdentity/BlazorWasmAuth/Identity/CookieAuthenticationStateProvider.cs) handles state for cookie-based authentication and provides account management service implementations described by the `IAccountManagement` interface. For more information, see <xref:blazor/security/index#authenticationstateprovider-service>.

The [`CookieHandler` class (`Identity/CookieHandler.cs`)](https://github.com/dotnet/blazor-samples/blob/main/8.0/BlazorWebAssemblyStandaloneWithIdentity/BlazorWasmAuth/Identity/CookieHandler.cs) ensures cookie credentials are sent with each request to the backend web API, which handles Identity and maintains the Identity data store.

The [`wwwroot/appsettings.file`](https://github.com/dotnet/blazor-samples/blob/main/8.0/BlazorWebAssemblyStandaloneWithIdentity/BlazorWasmAuth/wwwroot/appsettings.json) provides backend and frontend URL endpoints.

The [`App` component](https://github.com/dotnet/blazor-samples/blob/main/8.0/BlazorWebAssemblyStandaloneWithIdentity/BlazorWasmAuth/Components/App.razor) exposes the authentication state as a cascading parameter. For more information, see <xref:blazor/security/index#expose-the-authentication-state-as-a-cascading-parameter>.

The [`MainLayout` component](https://github.com/dotnet/blazor-samples/blob/main/8.0/BlazorWebAssemblyStandaloneWithIdentity/BlazorWasmAuth/Components/Layout/MainLayout.razor) and [`NavMenu` component](https://github.com/dotnet/blazor-samples/blob/main/8.0/BlazorWebAssemblyStandaloneWithIdentity/BlazorWasmAuth/Components/Layout/NavMenu.razor) use the [`AuthorizeView` component](xref:blazor/security/identity#authorizeview-component) to selectively display content based on the user's authentication status.

The following components handle common user authentication tasks, making use of `IAccountManagement` services:

* [`Register` component (`Components/Identity/Register.razor`)](https://github.com/dotnet/blazor-samples/blob/main/8.0/BlazorWebAssemblyStandaloneWithIdentity/BlazorWasmAuth/Components/Identity/Register.razor)
* [`Login` component (`Components/Identity/Login.razor`)](https://github.com/dotnet/blazor-samples/blob/main/8.0/BlazorWebAssemblyStandaloneWithIdentity/BlazorWasmAuth/Components/Identity/Login.razor)
* [`Logout` component (`Components/Identity/Logout.razor`)](https://github.com/dotnet/blazor-samples/blob/main/8.0/BlazorWebAssemblyStandaloneWithIdentity/BlazorWasmAuth/Components/Identity/Logout.razor)

The [`PrivatePage` component (`Components/Pages/PrivatePage.razor`)](https://github.com/dotnet/blazor-samples/blob/main/8.0/BlazorWebAssemblyStandaloneWithIdentity/BlazorWasmAuth/Components/Pages/PrivatePage.razor) requires authentication and shows the user's claims.

Services and configuration is provided in the [`Program` file (`Program.cs`)](https://github.com/dotnet/blazor-samples/blob/main/8.0/BlazorWebAssemblyStandaloneWithIdentity/BlazorWasmAuth/Program.cs):

* The cookie handler is registered as a scoped service.
* Authorization services are registered.
* The custom authentication state provider is registered as a scoped service.
* The account management interface (`IAccountManagement`) is registered.
* The base host URL is configured for a registered HTTP client instance.
* The base backend URL is configured for a registered HTTP client instance that's used for auth interactions with the backend web API. The HTTP client uses the cookie handler to ensure that cookie credentials are sent with each request.
