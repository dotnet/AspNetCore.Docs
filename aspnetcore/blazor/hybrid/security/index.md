---
title: ASP.NET Core Blazor Hybrid authentication and authorization
author: guardrex
description: Learn about Blazor Hybrid authentication and authorization scenarios.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/hybrid/security/index
zone_pivot_groups: blazor-hybrid-frameworks
---
# ASP.NET Core Blazor Hybrid authentication and authorization

[!INCLUDE[](~/includes/not-latest-version.md)]

This article describes ASP.NET Core's support for the configuration and management of security and ASP.NET Core Identity in Blazor Hybrid apps.

::: moniker range=">= aspnetcore-7.0"

Authentication in Blazor Hybrid apps is handled by native platform libraries, as they offer enhanced security guarantees that the browser sandbox can't offer. Authentication of native apps uses an OS-specific mechanism or via a federated protocol, such as [OpenID Connect (OIDC)](https://openid.net/connect/). Follow the guidance for the identity provider that you've selected for the app and then further integrate identity with Blazor using the guidance in this article.

Integrating authentication must achieve the following goals for Razor components and services:

* Use the abstractions in the [`Microsoft.AspNetCore.Components.Authorization`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.Authorization) package, such as <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView>.
* React to changes in the authentication context.
* Access credentials provisioned by the app from the identity provider, such as access tokens to perform authorized API calls.

After authentication is added to a .NET MAUI, WPF, or Windows Forms app and users are able to log in and log out successfully, integrate authentication with Blazor to make the authenticated user available to Razor components and services. Perform the following steps:

* Reference the [`Microsoft.AspNetCore.Components.Authorization`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.Authorization) package.

  [!INCLUDE[](~/includes/package-reference.md)]

* Implement a custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider>, which is the abstraction that Razor components use to access information about the authenticated user and to receive updates when the authentication state changes.
* Register the custom authentication state provider in the dependency injection container.

:::zone pivot="maui"

.NET MAUI apps use [Xamarin.Essentials: Web Authenticator](/xamarin/essentials/web-authenticator): The `WebAuthenticator` class allows the app to initiate browser-based authentication flows that listen for a callback to a specific URL registered with the app.

For additional guidance, see the following resources:

* [Web authenticator (.NET MAUI documentation](/dotnet/maui/platform-integration/communication/authentication)
* [`Sample.Server.WebAuthenticator` sample app](https://github.com/dotnet/maui/tree/main/src/Essentials/samples/Sample.Server.WebAuthenticator)

:::zone-end

:::zone pivot="wpf"

WPF apps use the [Microsoft identity platform](/azure/active-directory/develop/) to integrate with Microsoft Entra (ME-ID) and AAD B2C. For guidance and examples, see the following resources:

* [Overview of the Microsoft Authentication Library (MSAL)](/azure/active-directory/develop/msal-overview)
* [Sign-in a user with the Microsoft Identity Platform in a WPF Desktop application and call an ASP.NET Core Web API](/samples/azure-samples/active-directory-dotnet-native-aspnetcore-v2/1-desktop-app-calls-web-api/)
* [Add authentication to your Windows (WPF) app](/azure/developer/mobile-apps/azure-mobile-apps/quickstarts/wpf/authentication)
* [Tutorial: Sign in users and call Microsoft Graph in Windows Presentation Foundation (WPF) desktop app](/azure/active-directory/develop/tutorial-v2-windows-desktop)
* [Quickstart: Acquire a token and call Microsoft Graph API from a desktop application](/azure/active-directory/develop/desktop-app-quickstart?pivots=devlang-windows-desktop)
* [Quickstart: Set up sign in for a desktop app using Azure Active Directory B2C](/azure/active-directory-b2c/quickstart-native-app-desktop)
* [Configure authentication in a sample WPF desktop app by using Azure AD B2C](/azure/active-directory-b2c/configure-authentication-sample-wpf-desktop-app)

:::zone-end

:::zone pivot="winforms"

Windows Forms apps use the [Microsoft identity platform](/azure/active-directory/develop/) to integrate with Microsoft Entra (ME-ID) and AAD B2C. For more information, see [Overview of the Microsoft Authentication Library (MSAL)](/azure/active-directory/develop/msal-overview).

:::zone-end

## Create a custom `AuthenticationStateProvider` without user change updates

If the app authenticates the user immediately after the app launches and the authenticated user remains the same for the entirety of the app lifetime, user change notifications aren't required, and the app only provides information about the authenticated user. In this scenario, the user logs into the app when the app is opened, and the app displays the login screen again after the user logs out. The following `ExternalAuthStateProvider` is an example implementation of a custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> for this authentication scenario.

> [!NOTE]
> The following custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> doesn't declare a namespace in order to make the code example applicable to any Blazor Hybrid app. However, a best practice is to provide your app's namespace when you implement the example in a production app.

`ExternalAuthStateProvider.cs`:

```csharp
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

public class ExternalAuthStateProvider : AuthenticationStateProvider
{
    private readonly Task<AuthenticationState> authenticationState;

    public ExternalAuthStateProvider(AuthenticatedUser user) => 
        authenticationState = Task.FromResult(new AuthenticationState(user.Principal));

    public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
        authenticationState;
}

public class AuthenticatedUser
{
    public ClaimsPrincipal Principal { get; set; } = new();
}
```

:::zone pivot="maui"

The following steps describe how to:

* Add required namespaces.
* Add the authorization services and Blazor abstractions to the service collection.
* Build the service collection.
* Resolve the `AuthenticatedUser` service to set the authenticated user's claims principal. See your identity provider's documentation for details.
* Return the built host.

In the `MauiProgram.CreateMauiApp` method of `MauiProgram.cs`, add namespaces for <xref:Microsoft.AspNetCore.Components.Authorization?displayProperty=fullName> and <xref:System.Security.Claims?displayProperty=fullName>:

```csharp
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
```

Remove the following line of code that returns a built <xref:Microsoft.Maui.Hosting.MauiApp?displayProperty=fullName>:

```diff
- return builder.Build();
```

Replace the preceding line of code with the following code. Add OpenID/MSAL code to authenticate the user. See your identity provider's documentation for details.

```csharp
builder.Services.AddAuthorizationCore();
builder.Services.TryAddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();
builder.Services.AddSingleton<AuthenticatedUser>();
var host = builder.Build();

var authenticatedUser = host.Services.GetRequiredService<AuthenticatedUser>();

/*
Provide OpenID/MSAL code to authenticate the user. See your identity provider's 
documentation for details.

The user is represented by a new ClaimsPrincipal based on a new ClaimsIdentity.
*/
var user = new ClaimsPrincipal(new ClaimsIdentity());

authenticatedUser.Principal = user;

return host;
```

:::zone-end

:::zone pivot="wpf"

The following steps describe how to:

* Add required namespaces.
* Add the authorization services and Blazor abstractions to the service collection.
* Build the service collection and add the built service collection as a resource to the app's `ResourceDictionary`.
* Resolve the `AuthenticatedUser` service to set the authenticated user's claims principal. See your identity provider's documentation for details.
* Return the built host.

In the `MainWindow`'s constructor (`MainWindow.xaml.cs`), add namespaces for <xref:Microsoft.AspNetCore.Components.Authorization?displayProperty=fullName> and <xref:System.Security.Claims?displayProperty=fullName>:

```csharp
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
```

Remove the following line of code that adds the built service collection as a resource to the app's `ResourceDictionary`:

```diff
- Resources.Add("services", serviceCollection.BuildServiceProvider());
```

Replace the preceding line of code with the following code. Add OpenID/MSAL code to authenticate the user. See your identity provider's documentation for details.

```csharp
serviceCollection.AddAuthorizationCore();
serviceCollection.TryAddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();
serviceCollection.AddSingleton<AuthenticatedUser>();
var services = serviceCollection.BuildServiceProvider();
Resources.Add("services", services);

var authenticatedUser = services.GetRequiredService<AuthenticatedUser>();

/*
Provide OpenID/MSAL code to authenticate the user. See your identity provider's 
documentation for details.

The user is represented by a new ClaimsPrincipal based on a new ClaimsIdentity.
*/
var user = new ClaimsPrincipal(new ClaimsIdentity());

authenticatedUser.Principal = user;
```

:::zone-end

:::zone pivot="winforms"

The following steps describe how to:

* Add required namespaces.
* Add the authorization services and Blazor abstractions to the service collection.
* Build the service collection and add the built service collection to the app's service provider.
* Resolve the `AuthenticatedUser` service to set the authenticated user's claims principal. See your identity provider's documentation for details.

In the `Form1`'s constructor (`Form1.cs`), add namespaces for <xref:Microsoft.AspNetCore.Components.Authorization?displayProperty=fullName> and <xref:System.Security.Claims?displayProperty=fullName>:

```csharp
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
```

Remove the following line of code that sets the built service collection to the app's service provider:

```diff
- blazorWebView1.Services = services.BuildServiceProvider();
```

Replace the preceding line of code with the following code. Add OpenID/MSAL code to authenticate the user. See your identity provider's documentation for details.

```csharp
services.AddAuthorizationCore();
services.TryAddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();
services.AddSingleton<AuthenticatedUser>();
var serviceCollection = services.BuildServiceProvider();
blazorWebView1.Services = serviceCollection;

var authenticatedUser = serviceCollection.GetRequiredService<AuthenticatedUser>();

/*
Provide OpenID/MSAL code to authenticate the user. See your identity provider's 
documentation for details.

The user is represented by a new ClaimsPrincipal based on a new ClaimsIdentity.
*/
var user = new ClaimsPrincipal(new ClaimsIdentity());

authenticatedUser.Principal = user;
```

:::zone-end

## Create a custom `AuthenticationStateProvider` with user change updates

To update the user while the Blazor app is running, call <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider.NotifyAuthenticationStateChanged%2A> within the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> implementation using ***either*** of the following approaches:

* [Signal an authentication update from outside of the `BlazorWebView`](#signal-an-authentication-update-from-outside-of-the-blazorwebview-option-1))
* [Handle authentication within the `BlazorWebView`](#handle-authentication-within-the-blazorwebview-option-2)

### Signal an authentication update from outside of the `BlazorWebView` (Option 1)

A custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> can use a global service to signal an authentication update. We recommend that the service offer an event that the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> can subscribe to, where the event invokes <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider.NotifyAuthenticationStateChanged%2A>.

> [!NOTE]
> The following custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> doesn't declare a namespace in order to make the code example applicable to any Blazor Hybrid app. However, a best practice is to provide your app's namespace when you implement the example in a production app.

`ExternalAuthStateProvider.cs`:

```csharp
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

public class ExternalAuthStateProvider : AuthenticationStateProvider
{
    private AuthenticationState currentUser;

    public ExternalAuthStateProvider(ExternalAuthService service)
    {
        currentUser = new AuthenticationState(service.CurrentUser);

        service.UserChanged += (newUser) =>
        {
            currentUser = new AuthenticationState(newUser);
            NotifyAuthenticationStateChanged(Task.FromResult(currentUser));
        };
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
        Task.FromResult(currentUser);
}

public class ExternalAuthService
{
    public event Action<ClaimsPrincipal>? UserChanged;
    private ClaimsPrincipal? currentUser;

    public ClaimsPrincipal CurrentUser
    {
        get { return currentUser ?? new(); }
        set
        {
            currentUser = value;

            if (UserChanged is not null)
            {
                UserChanged(currentUser);
            }
        }
    }
}
```

:::zone pivot="maui"

In the `MauiProgram.CreateMauiApp` method of `MauiProgram.cs`, add a namespace for <xref:Microsoft.AspNetCore.Components.Authorization?displayProperty=fullName>:

```csharp
using Microsoft.AspNetCore.Components.Authorization;
```

Add the authorization services and Blazor abstractions to the service collection:

```csharp
builder.Services.AddAuthorizationCore();
builder.Services.TryAddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();
builder.Services.AddSingleton<ExternalAuthService>();
```

:::zone-end

:::zone pivot="wpf"

In the `MainWindow`'s constructor (`MainWindow.xaml.cs`), add a namespace for <xref:Microsoft.AspNetCore.Components.Authorization?displayProperty=fullName>:

```csharp
using Microsoft.AspNetCore.Components.Authorization;
```

Add the authorization services and the Blazor abstractions to the service collection:

```csharp
serviceCollection.AddAuthorizationCore();
serviceCollection.TryAddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();
serviceCollection.AddSingleton<ExternalAuthService>();
```

:::zone-end

:::zone pivot="winforms"

In the `Form1`'s constructor (`Form1.cs`), add a namespace for <xref:Microsoft.AspNetCore.Components.Authorization?displayProperty=fullName>:

```csharp
using Microsoft.AspNetCore.Components.Authorization;
```

Add the authorization services and Blazor abstractions to the service collection:

```csharp
services.AddAuthorizationCore();
services.TryAddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();
services.AddSingleton<ExternalAuthService>();
```

:::zone-end

Wherever the app authenticates a user, resolve the `ExternalAuthService` service:

```csharp
var authService = host.Services.GetRequiredService<ExternalAuthService>();
```

Execute your custom OpenID/MSAL code to authenticate the user. See your identity provider's documentation for details. The authenticated user (`authenticatedUser` in the following example) is a new <xref:System.Security.Claims.ClaimsPrincipal> based on a new <xref:System.Security.Claims.ClaimsIdentity>.

Set the current user to the authenticated user:

```csharp
authService.CurrentUser = authenticatedUser;
```

An alternative to the preceding approach is to set the user's principal on <xref:System.Threading.Thread.CurrentPrincipal?displayProperty=fullName> instead of setting it via a service, which avoids use of the dependency injection container:

```csharp
public class CurrentThreadUserAuthenticationStateProvider : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
        Task.FromResult(
            new AuthenticationState(Thread.CurrentPrincipal as ClaimsPrincipal ?? 
                new ClaimsPrincipal(new ClaimsIdentity())));
}
```

Using the alternative approach, only authorization services (<xref:Microsoft.Extensions.DependencyInjection.AuthorizationServiceCollectionExtensions.AddAuthorizationCore%2A>) and `CurrentThreadUserAuthenticationStateProvider` (`.TryAddScoped<AuthenticationStateProvider, CurrentThreadUserAuthenticationStateProvider>()`) are added to the service collection.

### Handle authentication within the `BlazorWebView` (Option 2)

A custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> can include additional methods to trigger log in and log out and update the user.

> [!NOTE]
> The following custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> doesn't declare a namespace in order to make the code example applicable to any Blazor Hybrid app. However, a best practice is to provide your app's namespace when you implement the example in a production app.

`ExternalAuthStateProvider.cs`:

```csharp
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

public class ExternalAuthStateProvider : AuthenticationStateProvider
{
    private ClaimsPrincipal currentUser = new ClaimsPrincipal(new ClaimsIdentity());

    public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
        Task.FromResult(new AuthenticationState(currentUser));

    public Task LogInAsync()
    {
        var loginTask = LogInAsyncCore();
        NotifyAuthenticationStateChanged(loginTask);

        return loginTask;

        async Task<AuthenticationState> LogInAsyncCore()
        {
            var user = await LoginWithExternalProviderAsync();
            currentUser = user;

            return new AuthenticationState(currentUser);
        }
    }

    private Task<ClaimsPrincipal> LoginWithExternalProviderAsync()
    {
        /*
            Provide OpenID/MSAL code to authenticate the user. See your identity 
            provider's documentation for details.

            Return a new ClaimsPrincipal based on a new ClaimsIdentity.
        */
        var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity());

        return Task.FromResult(authenticatedUser);
    }

    public void Logout()
    {
        currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(
            Task.FromResult(new AuthenticationState(currentUser)));
    }
}
```

In the preceding example:

* The call to `LogInAsyncCore` triggers the login process.
* The call to <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider.NotifyAuthenticationStateChanged%2A> notifies that an update is in progress, which allows the app to provide a temporary UI during the login or logout process.
* Returning `loginTask` returns the task so that the component that triggered the login can await and react after the task is complete.
* The `LoginWithExternalProviderAsync` method is implemented by the developer to log in the user with the identity provider's SDK. For more information, see your identity provider's documentation. The authenticated user (`authenticatedUser`) is a new <xref:System.Security.Claims.ClaimsPrincipal> based on a new <xref:System.Security.Claims.ClaimsIdentity>.

:::zone pivot="maui"

In the `MauiProgram.CreateMauiApp` method of `MauiProgram.cs`, add the authorization services and the Blazor abstraction to the service collection:

```csharp
builder.Services.AddAuthorizationCore();
builder.Services.TryAddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();
```

:::zone-end

:::zone pivot="wpf"

In the `MainWindow`'s constructor (`MainWindow.xaml.cs`), add the authorization services and the Blazor abstraction to the service collection:

```csharp
serviceCollection.AddAuthorizationCore();
serviceCollection.TryAddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();
```

:::zone-end

:::zone pivot="winforms"

In the `Form1`'s constructor (`Form1.cs`), add the authorization services and the Blazor abstraction to the service collection:

```csharp
services.AddAuthorizationCore();
services.TryAddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();
```

:::zone-end

The following `LoginComponent` component demonstrates how to log in a user. In a typical app, the `LoginComponent` component is only shown in a parent component if the user isn't logged into the app.

`Shared/LoginComponent.razor`:

```razor
@inject AuthenticationStateProvider AuthenticationStateProvider

<button @onclick="Login">Log in</button>

@code
{
    public async Task Login()
    {
        await ((ExternalAuthStateProvider)AuthenticationStateProvider)
            .LogInAsync();
    }
}
```

The following `LogoutComponent` component demonstrates how to log out a user. In a typical app, the `LogoutComponent` component is only shown in a parent component if the user is logged into the app.

`Shared/LogoutComponent.razor`:

```razor
@inject AuthenticationStateProvider AuthenticationStateProvider

<button @onclick="Logout">Log out</button>

@code
{
    public async Task Logout()
    {
        await ((ExternalAuthStateProvider)AuthenticationStateProvider)
            .Logout();
    }
}
```

## Accessing other authentication information

Blazor doesn't define an abstraction to deal with other credentials, such as access tokens to use for HTTP requests to web APIs. We recommend following the identity provider's guidance to manage the user's credentials with the primitives that the identity provider's SDK provides.

It's common for identity provider SDKs to use a token store for user credentials stored in the device. If the SDK's token store primitive is added to the service container, consume the SDK's primitive within the app.

The Blazor framework isn't aware of a user's authentication credentials and doesn't interact with credentials in any way, so the app's code is free to follow whatever approach you deem most convenient. However, follow the general security guidance in the next section, [Other authentication security considerations](#other-authentication-security-considerations), when implementing authentication code in an app.

## Other authentication security considerations

The authentication process is external to Blazor, and we recommend that developers access the identity provider's guidance for additional security guidance.

When implementing authentication:

* Avoid authentication in the context of the Web View. For example, avoid using a JavaScript OAuth library to perform the authentication flow. In a single-page app, authentication tokens aren't hidden in JavaScript and can be easily discovered by malicious users and used for nefarious purposes. Native apps don't suffer this risk because native apps are only able to obtain tokens outside of the browser context, which means that rogue third-party scripts can't steal the tokens and compromise the app.
* Avoid implementing the authentication workflow yourself. In most cases, platform libraries securely handle the authentication workflow, using the system's browser instead of using a custom Web View that can be hijacked.
* Avoid using the platform's Web View control to perform authentication. Instead, rely on the system's browser when possible.
* Avoid passing the tokens to the document context (JavaScript). In some situations, a JavaScript library within the document is required to perform an authorized call to an external service. Instead of making the token available to JavaScript via JS interop:
  * Provide a generated temporary token to the library and within the Web View.
  * Intercept the outgoing network request in code.
  * Replace the temporary token with the real token and confirm that the destination of the request is valid.

## Additional resources

* <xref:blazor/security/index>
* <xref:blazor/hybrid/security/security-considerations>

::: moniker-end

::: moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

Authentication in Blazor Hybrid apps is handled by native platform libraries, as they offer enhanced security guarantees that the browser sandbox can't offer. Authentication of native apps uses an OS-specific mechanism or via a federated protocol, such as [OpenID Connect (OIDC)](https://openid.net/connect/). Follow the guidance for the identity provider that you've selected for the app and then further integrate identity with Blazor using the guidance in this article.

Integrating authentication must achieve the following goals for Razor components and services:

* Use the abstractions in the [`Microsoft.AspNetCore.Components.Authorization`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.Authorization) package, such as <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView>.
* React to changes in the authentication context.
* Access credentials provisioned by the app from the identity provider, such as access tokens to perform authorized API calls.

After authentication is added to a .NET MAUI, WPF, or Windows Forms app and users are able to log in and log out successfully, integrate authentication with Blazor to make the authenticated user available to Razor components and services. Perform the following steps:

* Reference the [`Microsoft.AspNetCore.Components.Authorization`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.Authorization) package.

  [!INCLUDE[](~/includes/package-reference.md)]

* Implement a custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider>, which is the abstraction that Razor components use to access information about the authenticated user and to receive updates when the authentication state changes.
* Register the custom authentication state provider in the dependency injection container.

:::zone pivot="maui"

.NET MAUI apps use [Xamarin.Essentials: Web Authenticator](/xamarin/essentials/web-authenticator): The `WebAuthenticator` class allows the app to initiate browser-based authentication flows that listen for a callback to a specific URL registered with the app.

For additional guidance, see the following resources:

* [Web authenticator (.NET MAUI documentation](/dotnet/maui/platform-integration/communication/authentication)
* [`Sample.Server.WebAuthenticator` sample app](https://github.com/dotnet/maui/tree/main/src/Essentials/samples/Sample.Server.WebAuthenticator)

:::zone-end

:::zone pivot="wpf"

WPF apps use the [Microsoft identity platform](/azure/active-directory/develop/) to integrate with Microsoft Entra (ME-ID) and AAD B2C. For guidance and examples, see the following resources:

* [Overview of the Microsoft Authentication Library (MSAL)](/azure/active-directory/develop/msal-overview)
* [Sign-in a user with the Microsoft Identity Platform in a WPF Desktop application and call an ASP.NET Core Web API](/samples/azure-samples/active-directory-dotnet-native-aspnetcore-v2/1-desktop-app-calls-web-api/)
* [Add authentication to your Windows (WPF) app](/azure/developer/mobile-apps/azure-mobile-apps/quickstarts/wpf/authentication)
* [Tutorial: Sign in users and call Microsoft Graph in Windows Presentation Foundation (WPF) desktop app](/azure/active-directory/develop/tutorial-v2-windows-desktop)
* [Quickstart: Acquire a token and call Microsoft Graph API from a desktop application](/azure/active-directory/develop/desktop-app-quickstart?pivots=devlang-windows-desktop)
* [Quickstart: Set up sign in for a desktop app using Azure Active Directory B2C](/azure/active-directory-b2c/quickstart-native-app-desktop)
* [Configure authentication in a sample WPF desktop app by using Azure AD B2C](/azure/active-directory-b2c/configure-authentication-sample-wpf-desktop-app)

:::zone-end

:::zone pivot="winforms"

Windows Forms apps use the [Microsoft identity platform](/azure/active-directory/develop/) to integrate with Microsoft Entra (ME-ID) and AAD B2C. For more information, see [Overview of the Microsoft Authentication Library (MSAL)](/azure/active-directory/develop/msal-overview).

:::zone-end

## Create a custom `AuthenticationStateProvider` without user change updates

If the app authenticates the user immediately after the app launches and the authenticated user remains the same for the entirety of the app lifetime, user change notifications aren't required, and the app only provides information about the authenticated user. In this scenario, the user logs into the app when the app is opened, and the app displays the login screen again after the user logs out. The following `ExternalAuthStateProvider` is an example implementation of a custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> for this authentication scenario.

> [!NOTE]
> The following custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> doesn't declare a namespace in order to make the code example applicable to any Blazor Hybrid app. However, a best practice is to provide your app's namespace when you implement the example in a production app.

`ExternalAuthStateProvider.cs`:

```csharp
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

public class ExternalAuthStateProvider : AuthenticationStateProvider
{
    private readonly Task<AuthenticationState> authenticationState;

    public ExternalAuthStateProvider(AuthenticatedUser user) => 
        authenticationState = Task.FromResult(new AuthenticationState(user.Principal));

    public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
        authenticationState;
}

public class AuthenticatedUser
{
    public ClaimsPrincipal Principal { get; set; } = new();
}
```

:::zone pivot="maui"

The following steps describe how to:

* Add required namespaces.
* Add the authorization services and Blazor abstractions to the service collection.
* Build the service collection.
* Resolve the `AuthenticatedUser` service to set the authenticated user's claims principal. See your identity provider's documentation for details.
* Return the built host.

In the `MauiProgram.CreateMauiApp` method of `MauiProgram.cs`, add namespaces for <xref:Microsoft.AspNetCore.Components.Authorization?displayProperty=fullName> and <xref:System.Security.Claims?displayProperty=fullName>:

```csharp
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
```

Remove the following line of code that returns a built <xref:Microsoft.Maui.Hosting.MauiApp?displayProperty=fullName>:

```diff
- return builder.Build();
```

Replace the preceding line of code with the following code. Add OpenID/MSAL code to authenticate the user. See your identity provider's documentation for details.

```csharp
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();
builder.Services.AddSingleton<AuthenticatedUser>();
var host = builder.Build();

var authenticatedUser = host.Services.GetRequiredService<AuthenticatedUser>();

/*
Provide OpenID/MSAL code to authenticate the user. See your identity provider's 
documentation for details.

The user is represented by a new ClaimsPrincipal based on a new ClaimsIdentity.
*/
var user = new ClaimsPrincipal(new ClaimsIdentity());

authenticatedUser.Principal = user;

return host;
```

:::zone-end

:::zone pivot="wpf"

The following steps describe how to:

* Add required namespaces.
* Add the authorization services and Blazor abstractions to the service collection.
* Build the service collection and add the built service collection as a resource to the app's `ResourceDictionary`.
* Resolve the `AuthenticatedUser` service to set the authenticated user's claims principal. See your identity provider's documentation for details.
* Return the built host.

In the `MainWindow`'s constructor (`MainWindow.xaml.cs`), add namespaces for <xref:Microsoft.AspNetCore.Components.Authorization?displayProperty=fullName> and <xref:System.Security.Claims?displayProperty=fullName>:

```csharp
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
```

Remove the following line of code that adds the built service collection as a resource to the app's `ResourceDictionary`:

```diff
- Resources.Add("services", serviceCollection.BuildServiceProvider());
```

Replace the preceding line of code with the following code. Add OpenID/MSAL code to authenticate the user. See your identity provider's documentation for details.

```csharp
serviceCollection.AddAuthorizationCore();
serviceCollection.AddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();
serviceCollection.AddSingleton<AuthenticatedUser>();
var services = serviceCollection.BuildServiceProvider();
Resources.Add("services", services);

var authenticatedUser = services.GetRequiredService<AuthenticatedUser>();

/*
Provide OpenID/MSAL code to authenticate the user. See your identity provider's 
documentation for details.

The user is represented by a new ClaimsPrincipal based on a new ClaimsIdentity.
*/
var user = new ClaimsPrincipal(new ClaimsIdentity());

authenticatedUser.Principal = user;
```

:::zone-end

:::zone pivot="winforms"

The following steps describe how to:

* Add required namespaces.
* Add the authorization services and Blazor abstractions to the service collection.
* Build the service collection and add the built service collection to the app's service provider.
* Resolve the `AuthenticatedUser` service to set the authenticated user's claims principal. See your identity provider's documentation for details.

In the `Form1`'s constructor (`Form1.cs`), add namespaces for <xref:Microsoft.AspNetCore.Components.Authorization?displayProperty=fullName> and <xref:System.Security.Claims?displayProperty=fullName>:

```csharp
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
```

Remove the following line of code that sets the built service collection to the app's service provider:

```diff
- blazorWebView1.Services = services.BuildServiceProvider();
```

Replace the preceding line of code with the following code. Add OpenID/MSAL code to authenticate the user. See your identity provider's documentation for details.

```csharp
services.AddAuthorizationCore();
services.AddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();
services.AddSingleton<AuthenticatedUser>();
var serviceCollection = services.BuildServiceProvider();
blazorWebView1.Services = serviceCollection;

var authenticatedUser = serviceCollection.GetRequiredService<AuthenticatedUser>();

/*
Provide OpenID/MSAL code to authenticate the user. See your identity provider's 
documentation for details.

The user is represented by a new ClaimsPrincipal based on a new ClaimsIdentity.
*/
var user = new ClaimsPrincipal(new ClaimsIdentity());

authenticatedUser.Principal = user;
```

:::zone-end

## Create a custom `AuthenticationStateProvider` with user change updates

To update the user while the Blazor app is running, call <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider.NotifyAuthenticationStateChanged%2A> within the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> implementation using ***either*** of the following approaches:

* [Signal an authentication update from outside of the `BlazorWebView`](#signal-an-authentication-update-from-outside-of-the-blazorwebview-option-1))
* [Handle authentication within the `BlazorWebView`](#handle-authentication-within-the-blazorwebview-option-2)

### Signal an authentication update from outside of the `BlazorWebView` (Option 1)

A custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> can use a global service to signal an authentication update. We recommend that the service offer an event that the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> can subscribe to, where the event invokes <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider.NotifyAuthenticationStateChanged%2A>.

> [!NOTE]
> The following custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> doesn't declare a namespace in order to make the code example applicable to any Blazor Hybrid app. However, a best practice is to provide your app's namespace when you implement the example in a production app.

`ExternalAuthStateProvider.cs`:

```csharp
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

public class ExternalAuthStateProvider : AuthenticationStateProvider
{
    private AuthenticationState currentUser;

    public ExternalAuthStateProvider(ExternalAuthService service)
    {
        currentUser = new AuthenticationState(service.CurrentUser);

        service.UserChanged += (newUser) =>
        {
            currentUser = new AuthenticationState(newUser);
            NotifyAuthenticationStateChanged(Task.FromResult(currentUser));
        };
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
        Task.FromResult(currentUser);
}

public class ExternalAuthService
{
    public event Action<ClaimsPrincipal>? UserChanged;
    private ClaimsPrincipal? currentUser;

    public ClaimsPrincipal CurrentUser
    {
        get { return currentUser ?? new(); }
        set
        {
            currentUser = value;

            if (UserChanged is not null)
            {
                UserChanged(currentUser);
            }
        }
    }
}
```

:::zone pivot="maui"

In the `MauiProgram.CreateMauiApp` method of `MauiProgram.cs`, add a namespace for <xref:Microsoft.AspNetCore.Components.Authorization?displayProperty=fullName>:

```csharp
using Microsoft.AspNetCore.Components.Authorization;
```

Add the authorization services and Blazor abstractions to the service collection:

```csharp
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();
builder.Services.AddSingleton<ExternalAuthService>();
```

:::zone-end

:::zone pivot="wpf"

In the `MainWindow`'s constructor (`MainWindow.xaml.cs`), add a namespace for <xref:Microsoft.AspNetCore.Components.Authorization?displayProperty=fullName>:

```csharp
using Microsoft.AspNetCore.Components.Authorization;
```

Add the authorization services and the Blazor abstractions to the service collection:

```csharp
serviceCollection.AddAuthorizationCore();
serviceCollection.AddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();
serviceCollection.AddSingleton<ExternalAuthService>();
```

:::zone-end

:::zone pivot="winforms"

In the `Form1`'s constructor (`Form1.cs`), add a namespace for <xref:Microsoft.AspNetCore.Components.Authorization?displayProperty=fullName>:

```csharp
using Microsoft.AspNetCore.Components.Authorization;
```

Add the authorization services and Blazor abstractions to the service collection:

```csharp
services.AddAuthorizationCore();
services.AddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();
services.AddSingleton<ExternalAuthService>();
```

:::zone-end

Wherever the app authenticates a user, resolve the `ExternalAuthService` service:

```csharp
var authService = host.Services.GetRequiredService<ExternalAuthService>();
```

Execute your custom OpenID/MSAL code to authenticate the user. See your identity provider's documentation for details. The authenticated user (`authenticatedUser` in the following example) is a new <xref:System.Security.Claims.ClaimsPrincipal> based on a new <xref:System.Security.Claims.ClaimsIdentity>.

Set the current user to the authenticated user:

```csharp
authService.CurrentUser = authenticatedUser;
```

An alternative to the preceding approach is to set the user's principal on <xref:System.Threading.Thread.CurrentPrincipal?displayProperty=fullName> instead of setting it via a service, which avoids use of the dependency injection container:

```csharp
public class CurrentThreadUserAuthenticationStateProvider : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
        Task.FromResult(
            new AuthenticationState(Thread.CurrentPrincipal as ClaimsPrincipal ?? 
                new ClaimsPrincipal(new ClaimsIdentity())));
}
```

Using the alternative approach, only authorization services (<xref:Microsoft.Extensions.DependencyInjection.AuthorizationServiceCollectionExtensions.AddAuthorizationCore%2A>) and `CurrentThreadUserAuthenticationStateProvider` (`.AddScoped<AuthenticationStateProvider, CurrentThreadUserAuthenticationStateProvider>()`) are added to the service collection.

### Handle authentication within the `BlazorWebView` (Option 2)

A custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> can include additional methods to trigger log in and log out and update the user.

> [!NOTE]
> The following custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> doesn't declare a namespace in order to make the code example applicable to any Blazor Hybrid app. However, a best practice is to provide your app's namespace when you implement the example in a production app.

`ExternalAuthStateProvider.cs`:

```csharp
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

public class ExternalAuthStateProvider : AuthenticationStateProvider
{
    private ClaimsPrincipal currentUser = new ClaimsPrincipal(new ClaimsIdentity());

    public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
        Task.FromResult(new AuthenticationState(currentUser));

    public Task LogInAsync()
    {
        var loginTask = LogInAsyncCore();
        NotifyAuthenticationStateChanged(loginTask);

        return loginTask;

        async Task<AuthenticationState> LogInAsyncCore()
        {
            var user = await LoginWithExternalProviderAsync();
            currentUser = user;

            return new AuthenticationState(currentUser);
        }
    }

    private Task<ClaimsPrincipal> LoginWithExternalProviderAsync()
    {
        /*
            Provide OpenID/MSAL code to authenticate the user. See your identity 
            provider's documentation for details.

            Return a new ClaimsPrincipal based on a new ClaimsIdentity.
        */
        var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity());

        return Task.FromResult(authenticatedUser);
    }

    public void Logout()
    {
        currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(
            Task.FromResult(new AuthenticationState(currentUser)));
    }
}
```

In the preceding example:

* The call to `LogInAsyncCore` triggers the login process.
* The call to <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider.NotifyAuthenticationStateChanged%2A> notifies that an update is in progress, which allows the app to provide a temporary UI during the login or logout process.
* Returning `loginTask` returns the task so that the component that triggered the login can await and react after the task is complete.
* The `LoginWithExternalProviderAsync` method is implemented by the developer to log in the user with the identity provider's SDK. For more information, see your identity provider's documentation. The authenticated user (`authenticatedUser`) is a new <xref:System.Security.Claims.ClaimsPrincipal> based on a new <xref:System.Security.Claims.ClaimsIdentity>.

:::zone pivot="maui"

In the `MauiProgram.CreateMauiApp` method of `MauiProgram.cs`, add the authorization services and the Blazor abstraction to the service collection:

```csharp
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();
```

:::zone-end

:::zone pivot="wpf"

In the `MainWindow`'s constructor (`MainWindow.xaml.cs`), add the authorization services and the Blazor abstraction to the service collection:

```csharp
serviceCollection.AddAuthorizationCore();
serviceCollection.AddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();
```

:::zone-end

:::zone pivot="winforms"

In the `Form1`'s constructor (`Form1.cs`), add the authorization services and the Blazor abstraction to the service collection:

```csharp
services.AddAuthorizationCore();
services.AddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();
```

:::zone-end

The following `LoginComponent` component demonstrates how to log in a user. In a typical app, the `LoginComponent` component is only shown in a parent component if the user isn't logged into the app.

`Shared/LoginComponent.razor`:

```razor
@inject AuthenticationStateProvider AuthenticationStateProvider

<button @onclick="Login">Log in</button>

@code
{
    public async Task Login()
    {
        await ((ExternalAuthStateProvider)AuthenticationStateProvider)
            .LogInAsync();
    }
}
```

The following `LogoutComponent` component demonstrates how to log out a user. In a typical app, the `LogoutComponent` component is only shown in a parent component if the user is logged into the app.

`Shared/LogoutComponent.razor`:

```razor
@inject AuthenticationStateProvider AuthenticationStateProvider

<button @onclick="Logout">Log out</button>

@code
{
    public async Task Logout()
    {
        await ((ExternalAuthStateProvider)AuthenticationStateProvider)
            .Logout();
    }
}
```

## Accessing other authentication information

Blazor doesn't define an abstraction to deal with other credentials, such as access tokens to use for HTTP requests to web APIs. We recommend following the identity provider's guidance to manage the user's credentials with the primitives that the identity provider's SDK provides.

It's common for identity provider SDKs to use a token store for user credentials stored in the device. If the SDK's token store primitive is added to the service container, consume the SDK's primitive within the app.

The Blazor framework isn't aware of a user's authentication credentials and doesn't interact with credentials in any way, so the app's code is free to follow whatever approach you deem most convenient. However, follow the general security guidance in the next section, [Other authentication security considerations](#other-authentication-security-considerations), when implementing authentication code in an app.

## Other authentication security considerations

The authentication process is external to Blazor, and we recommend that developers access the identity provider's guidance for additional security guidance.

When implementing authentication:

* Avoid authentication in the context of the Web View. For example, avoid using a JavaScript OAuth library to perform the authentication flow. In a single-page app, authentication tokens aren't hidden in JavaScript and can be easily discovered by malicious users and used for nefarious purposes. Native apps don't suffer this risk because native apps are only able to obtain tokens outside of the browser context, which means that rogue third-party scripts can't steal the tokens and compromise the app.
* Avoid implementing the authentication workflow yourself. In most cases, platform libraries securely handle the authentication workflow, using the system's browser instead of using a custom Web View that can be hijacked.
* Avoid using the platform's Web View control to perform authentication. Instead, rely on the system's browser when possible.
* Avoid passing the tokens to the document context (JavaScript). In some situations, a JavaScript library within the document is required to perform an authorized call to an external service. Instead of making the token available to JavaScript via JS interop:
  * Provide a generated temporary token to the library and within the Web View.
  * Intercept the outgoing network request in code.
  * Replace the temporary token with the real token and confirm that the destination of the request is valid.

## Additional resources

* <xref:blazor/security/index>
* <xref:blazor/hybrid/security/security-considerations>

::: moniker-end
