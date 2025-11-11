---
title: .NET MAUI Blazor Hybrid and Web App with ASP.NET Core Identity
author: guardrex
description: Learn how to build a .NET MAUI Blazor Hybrid app with a Blazor Web App that manages authentication with ASP.NET Core Identity.
monikerRange: '>= aspnetcore-9.0'
ms.author: wpickett
ms.custom: mvc
ms.date: 11/11/2025
uid: blazor/hybrid/security/maui-blazor-web-identity
---
# .NET MAUI Blazor Hybrid and Web App with ASP.NET Core Identity

[!INCLUDE[](~/includes/not-latest-version.md)]

This sample app demonstrates how to build a .NET MAUI Blazor Hybrid app with a Blazor Web App that uses ASP.NET Core Identity. It shows how to share common UI and authenticate with ASP.NET Core Identity local accounts. Although ASP.NET Core Identity is used, you can use this pattern for any authentication provider from a MAUI Blazor Hybrid client.

The sample:	

* Sets up the UI to show or hide pages based on user authentication.
* Sets up ASP.NET Core Identity endpoints for remote clients.
* Logs users in, logs users out, and refreshes tokens from the MAUI client.
* Saves and retrieves tokens in secure device storage.
* Calls a secure endpoint (`/api/weather`) from the client for weather data.

## Prerequisites and preliminary steps

For prerequisites and preliminary steps, see <xref:blazor/hybrid/tutorials/maui>. We recommend using the MAUI Blazor Hybrid tutorial to set up your local system for MAUI development before using the guidance in this article and the sample app.

## Sample app

[Obtain the sample app](xref:blazor/fundamentals/index#sample-apps) in the `MauiBlazorWebIdentity` folder of the [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples) (.NET 9 or later).

The sample app is a starter solution that contains a native, cross-platform MAUI Blazor Hybrid app, a Blazor Web App, and a Razor class library (RCL) that contains the shared UI (Razor components) used by the native and web apps.

1. Clone this repository or download a ZIP archive of the repository. For more information, see [How to download a sample](xref:fundamentals/index#how-to-download-a-sample).
1. Make sure you have [.NET 9 and the MAUI workload installed (.NET MAUI documentation)](/dotnet/maui/get-started/installation).
1. Open the solution in Visual Studio (2022 or later) or VS Code with the .NET MAUI extension installed.
1. Set the `MauiBlazorWeb` MAUI project as the startup project. In Visual Studio, right-click the project and select **Set as Startup Project**.
1. Start the `MauiBlazorWeb.Web` project without debugging. In Visual Studio, right-click on the project and select **Debug** > **Start without Debugging**.
1. Inspect the Identity endpoints via [OpenAPI documentation](xref:fundamentals/openapi/overview). You can add a third-party OpenAPI-compliant visual UI/endpoint tester.
1. Navigate to `https://localhost:7157/account/register` to register a user in the Blazor Web App. Immediately after the user is registered, use the **Click here to confirm your account** link in the UI to confirm the user's email address because a real email sender isn't registered for account confirmation.
1. Start (`F5`) the `MauiBlazorWeb` MAUI project. You can set the debug target to either **Windows** or an Android emulator.
1. Notice you can only see the `Home` and `Login` pages.
1. Log in with the user that you registered.
1. Notice you can now see the shared `Counter` and `Weather` pages.
1. Log out and notice you can only see the `Home` and `Login` pages again.
1. Navigate to `https://localhost:7157/` in a browser and the web app behaves the same.

## Shared UI

The shared UI is in the `MauiBlazorWeb.Shared` project. This project contains the Razor components that are shared between the MAUI and Blazor Web App projects (Home, Counter and Weather pages). The `Counter` component and `Weather` component are protected by [`[Authorize]` attributes](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute), so users can't navigate to them unless they're logged into the app.

In the [Razor directives](xref:blazor/components/index#razor-syntax) at the tops of the `Counter` component (`MauiBlazorWeb.Shared/Pages/Counter.razor`) and `Weather` component (`MauiBlazorWeb.Shared/Pages/Weather.razor`) files:

```razor
@using Microsoft.AspNetCore.Authorization
@attribute [Authorize]
```

## MAUI app and Blazor Web App routing

The `Routes` component uses an <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeRouteView> to route users based on their authentication status. If a user isn't authenticated, they're redirected to the `Login` page. For more information, see <xref:blazor/security/index#customize-unauthorized-content-with-the-router-component>.

In `MauiBlazorWeb.Web/Components/Routes.razor`:

```razor
<AuthorizeRouteView ...>
    <Authorizing>
        Authorizing...
    </Authorizing>
    <NotAuthorized>
        <Login />
    </NotAuthorized>
</AuthorizeRouteView>   
```

The [`NavMenu` component](xref:blazor/project-structure#blazor-web-app) contains the navigation menu that uses an [`AuthorizeView` component](xref:blazor/security/index#authorizeview-component) to show or hide links based on the user's authentication status.

In `MauiBlazorWeb.Web/Components/Layout/NavMenu.razor`:

```razor
<AuthorizeView>
    <NotAuthorized>
       ...
    </NotAuthorized>
    <Authorized>
        ...
    </Authorized>
</AuthorizeView>
```

### Server project

The Blazor Web App project (`MauiBlazorWeb.Web`) of the sample app contains the ASP.NET Core Identity pages and uses the <xref:Microsoft.AspNetCore.Identity.SignInManager%601> framework class to manage logins and users on the server. In order for the MAUI client (or any external client) to authenticate, the Identity endpoints must be registered and exposed. In the `Program` file, Identity endpoints are set up with the calls to:

* <xref:Microsoft.Extensions.DependencyInjection.IdentityServiceCollectionExtensions.AddIdentityApiEndpoints%2A>
* <xref:Microsoft.AspNetCore.Routing.IdentityApiEndpointRouteBuilderExtensions.MapIdentityApi%2A>
* `MapAdditionalIdentityEndpoints` (`MauiBlazorWeb.Web/Components/Account/IdentityComponentsEndpointRouteBuilderExtensions.cs`).

In `MauiBlazorWeb.Web/Program.cs`:

```csharp
builder.Services.AddIdentityApiEndpoints<ApplicationUser>(...)
    .AddEntityFrameworkStores<ApplicationDbContext>();

...

app.MapGroup("/identity").MapIdentityApi<ApplicationUser>();

...

app.MapAdditionalIdentityEndpoints();
```

> [!IMPORTANT]
> ASP.NET Core Identity pages and the implementation of the <xref:Microsoft.AspNetCore.Identity.SignInManager%601> framework class to manage logins and users is generated automatically when you create a project from the Blazor Web App project template with **Individual Accounts**.
>
> This article focuses on using the provided sample app; but when creating a new project from the Blazor Web App template, you must remove the generated call to <xref:Microsoft.AspNetCore.Identity.IdentityCookieAuthenticationBuilderExtensions.AddIdentityCookies%2A> on <xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication%2A>. The call isn't necessary when implementing API such as `MapAdditionalIdentityEndpoints` in the sample app and results in an error if left in the app.

### Log in from the MAUI client

The `Login` component (`/identity/login` endpoint) is where the user logs in. The component injects the `MauiAuthenticationStateProvider` (`MauiBlazorWeb/Services/MauiAuthenticationStateProvider.cs`) and uses the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> to authenticate the user and redirect them to the homepage if successful. When the state changes, the [`AuthorizeView` component](xref:blazor/security/index#authorizeview-component) shows the appropriate links based on the user's authentication status.

In `MauiBlazorWeb/Components/Pages/Login.razor`:

```csharp
private async Task LoginUser()
{
    await AuthStateProvider.LogInAsync(LoginModel);

    if (AuthStateProvider.LoginStatus != LoginStatus.Success)
    {
        loginFailureHidden = false;
        return;
    }

    Navigation.NavigateTo("");
}
```

> [!NOTE]
> This sample only implements Login and Logout pages on the MAUI client, but you can build Register and other management pages against the exposed Identity endpoints for more functionality. For more information on Identity endpoints, see <xref:security/authentication/identity/spa>.

### MAUI Authentication State Provider (`MauiAuthenticationStateProvider`)

The `MauiAuthenticationStateProvider` class is responsible for managing the user's authentication state and providing the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationState> to the app. The `MauiAuthenticationStateProvider` class uses an <xref:System.Net.Http.HttpClient> to make requests to the server to authenticate the user. For more information, see <xref:blazor/hybrid/security/index?pivots=maui>.

In `MauiBlazorWeb/Services/MauiAuthenticationStateProvider.cs`:

```csharp
 private async Task<ClaimsPrincipal> LoginWithProviderAsync(LoginRequest loginModel)
 {
    var authenticatedUser = _defaultUser;
    LoginStatus = LoginStatus.None;

    try
    {
        // Call the Login endpoint and pass the email and password
        var httpClient = HttpClientHelper.GetHttpClient();
        var loginData = new { loginModel.Email, loginModel.Password };
        using var response = await httpClient.PostAsJsonAsync(HttpClientHelper.LoginUrl, 
            loginData);

        LoginStatus = 
            response.IsSuccessStatusCode ? LoginStatus.Success : LoginStatus.Failed;

        if (LoginStatus == LoginStatus.Success)
        {
            // Save token to secure storage so the user doesn't have to login 
            // every time
            var token = await response.Content.ReadAsStringAsync();
            _accessToken = await TokenStorage.SaveTokenToSecureStorageAsync(token, 
                loginModel.Email);

            authenticatedUser = CreateAuthenticatedUser(loginModel.Email);
            LoginStatus = LoginStatus.Success;
        }
        else
        {
            LoginFailureMessage = "Invalid Email or Password. Please try again.";
            LoginStatus = LoginStatus.Failed;
        }
    }
    catch (Exception ex)
    {
        Debug.WriteLine($"Error logging in: {ex}");
        LoginFailureMessage = "Server error.";
        LoginStatus = LoginStatus.Failed;
    }

    return authenticatedUser;
}
```

The `MauiAuthenticationStateProvider` class uses the `HttpClientHelper` (`MauiBlazorWeb/Services/HttpClientHelper.cs`) to handle calling localhost via the emulators and simulators for testing. For more information on calling local services from emulators and simulators, see [Connect to local web services from Android emulators and iOS simulators (.NET MAUI documentation)](/dotnet/maui/data-cloud/local-web-services).

The MAUI Authentication State Provider also uses the `TokenStorage` class (`MauiBlazorWeb/Services/TokenStorage.cs`) that uses [`SecureStorage` API (.NET MAUI documentation)](/dotnet/maui/platform-integration/storage/secure-storage) to store the user's token securely on the device. It refreshes the token near token expiration to avoid user logins.

### MAUI `MauiProgram` file

The MAUI project's `MauiProgram` file (`MauiProgram.cs`) is where the `MauiAuthenticationStateProvider` is registered in the DI container. Authorization core components are also registered, where API such as [`AuthorizeView` component](xref:blazor/security/index#authorizeview-component) are defined.

In `MauiBlazorWeb/MauiProgram.cs`, core functionality is added by calling <xref:Microsoft.Extensions.DependencyInjection.AuthorizationServiceCollectionExtensions.AddAuthorizationCore%2A>:

```csharp
builder.Services.AddAuthorizationCore();
```

The app's custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> (`MauiAuthenticationStateProvider`) is registered in `MauiProgram.cs`:

```csharp
builder.Services.AddScoped<MauiAuthenticationStateProvider>();
```

Use the `MauiAuthenticationStateProvider` when the app requires an <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider>:

```csharp
builder.Services.AddScoped<AuthenticationStateProvider>(s => 
    (MauiAuthenticationStateProvider)
        s.GetRequiredService<MauiAuthenticationStateProvider>());
```
