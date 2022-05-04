---
title: ASP.NET Core Blazor Hybrid authentication and authorization
author: guardrex
description: Learn about Blazor Hybrid authentication and authorization scenarios.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 05/03/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/hybrid/security/index
---
# ASP.NET Core Blazor Hybrid authentication and authorization

This article describes ASP.NET Core's support for the configuration and management of security in Blazor Hybrid apps.

Authentication in Blazor Hybrid apps is handled by native platform libraries, as they offer enhanced security guarantees that the browser sandbox can't offer.

Follow the external guidance for the identity provider that you've selected for the app and then further integrate identity with Blazor using the guidance in this article.

[!INCLUDE[](~/blazor/includes/blazor-hybrid-preview-notice.md)]

## Integration with identity providers

Authentication of native apps happens via an OS-specific mechanism or via a federated protocol, such as [OpenID Connect (OIDC)](https://openid.net/connect/).

### .NET MAUI

[Xamarin.Essentials: Web Authenticator](/xamarin/essentials/web-authenticator): The `WebAuthenticator` class allows the app to initiate browser-based authentication flows that listen for a callback to a specific URL registered with the app.

### WPF

WPF apps use the [Microsoft identity platform](/azure/active-directory/develop/) to integrate with Azure Active Directory (AAD) and AAD B2C. For guidance and examples, see the following resources:

* [Sign-in a user with the Microsoft Identity Platform in a WPF Desktop application and call an ASP.NET Core Web API](/samples/azure-samples/active-directory-dotnet-native-aspnetcore-v2/1-desktop-app-calls-web-api/)
* [Add authentication to your Windows (WPF) app](/azure/developer/mobile-apps/azure-mobile-apps/quickstarts/wpf/authentication)
* [Tutorial: Sign in users and call Microsoft Graph in Windows Presentation Foundation (WPF) desktop app](/azure/active-directory/develop/tutorial-v2-windows-desktop)
* [Quickstart: Acquire a token and call Microsoft Graph API from a desktop application](/azure/active-directory/develop/desktop-app-quickstart?pivots=devlang-windows-desktop)
* [Quickstart: Set up sign in for a desktop app using Azure Active Directory B2C](/azure/active-directory-b2c/quickstart-native-app-desktop)
* [Configure authentication in a sample WPF desktop app by using Azure AD B2C](/azure/active-directory-b2c/configure-authentication-sample-wpf-desktop-app)

### Windows Forms

<!--

For AAD/B2C with WinForms, I can't find content in Azure docs or per https://docs.microsoft.com/dotnet/desktop/winforms/windows-forms-security.

* []()
* []()

-->

## Integrate authentication

Integrating authentication must achieve the following goals for Razor components and services:

* Use the abstractions in the [`Microsoft.AspNetCore.Components.Authorization`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.Authorization) package, such as <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView>.
* React to changes in the authentication context.
* Access credentials provisioned by the app from the identity provider, such as access tokens to perform authorized API calls.

After authentication is added to a .NET MAUI, WPF, or Windows Forms app and users are able to log in and log out successfully, integrate authentication with Blazor to make the authenticated user available to Razor components and services. Perform the following steps:

* Reference the [`Microsoft.AspNetCore.Components.Authorization`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.Authorization) package.
* Implement a custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider>.
* Register the custom authentication state provider in the dependency injection container.

### Create a custom `AuthenticationStateProvider`

The <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> is the abstraction that Razor components use to access information about the authenticated user and to receive updates when the authentication state changes.

If the app authenticates the user immediately after the app launches and the authenticated user remains the same for the entirety of the app lifetime, user change notifications aren't required, and the app only provides information about the authenticated user. Typically in this scenario, the user logs into the app when the app is opened, and the app displays the login screen again after the user logs out. The following `HybridAuthenticationStateProvider` is an example implementation of a custom <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> for this authentication scenario.

```csharp
public HybridAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly Task<AuthenticationState> authenticationState;

    public HybridAuthenticationStateProvider(AuthenticatedUser user) => 
        authenticationState = Task.FromResult(new AuthenticationState(user.Principal));

    public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
        authenticationState;
}

public class AuthenticatedUser 
{
    public ClaimsPrincipal Principal { get; set; }
}
```

To update the user while the Blazor app is running, call <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider.NotifyAuthenticationStateChanged%2A> within the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> implementation, using ***either*** of the following approaches:

* [Signal an authentication update from outside of the `BlazorWebView`](#signal-an-authentication-update-from-outside-of-the-blazorwebview-option-1))
* [Handle authentication within the `BlazorWebView`](#handle-authentication-within-the-blazorwebview-option-2)

### Signal an authentication update from outside of the `BlazorWebView` (Option 1)

The following example uses a global service to signal an authentication update. We recommend that the service offer an event that the <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> can subscribe to, where the event invokes <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider.NotifyAuthenticationStateChanged%2A>.

> [!NOTE]
> `AuthenticatedUser` in the following example is registered in the dependency injection container later in this article.

```csharp
public HybridAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly AuthenticatedUser authenticatedUser;
    private Task<AuthenticationState> authenticationState;

    public HybridAuthenticationStateProvider(AuthenticatedUser user)
    {
        authenticationState = 
            Task.FromResult(new AuthenticationState(user.Principal));
        authenticatedUser = user;

        authenticatedUser.UserChanged += () => 
        {
            authenticationState = 
                Task.FromResult(new AuthenticationState(user.Principal));
            NotifyAuthenticationStateChanged(authenticatedUser);
        }
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync() => 
        authenticationState;
}

public class AuthenticatedUser 
{
    public ClaimsPrincipal Principal { get; set; }
    public event Action UserChanged;
}
```

Add the Blazor abstractions to the DI container:

```csharp
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, HybridAuthenticationStateProvider>();
builder.Services.AddSingleton<AuthenticatedUser>();
```

From anywhere in the app, we can resolve the `AuthenticatedUser` service after we have authenticated the user and set the principal property to the authenticated user before we start the Blazor application:

```csharp
var authenticatedUser = services.GetRequiredService<AuthenticatedUser>();
authenticatedUser.Principal = currentUser;
```

> [!NOTE]
> Alternatively, set the user's principal on <xref:System.Threading.Thread.CurrentPrincipal?displayProperty=fullName> instead of setting it via a service, which avoids use of the dependency injection container:
>
> ```csharp
> public class CurrentThreadUserAuthenticationStateProvider : AuthenticationStateProvider
> {
>     public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
>         Task.FromResult(
>             new AuthenticationState(Thread.CurrentPrincipal as ClaimsPrincipal ?? 
>                 new ClaimsPrincipal(new ClaimsIdentity())));
> }
> ```
>
> In `MainWindow`'s constructor (`MainWindow.xaml.cs`):
>
> ```csharp
> services.AddScoped<AuthenticationStateProvider, CurrentThreadUserAuthenticationStateProvider>();
> BlazorView.Services = services.BuildServiceProvider();
>
> BlazorView.RootComponents.Add(new Microsoft.AspNetCore.Components.WebView.Wpf.RootComponent()
> {
>     ComponentType = typeof(Main),
>     Selector = "#app"
> });
> ```

### Handle authentication within the `BlazorWebView` (Option 2)

Add additional methods to the `HybridAuthenticationStateProvider` to trigger log in and log out and update the user:

```csharp
public HybridAuthenticationStateProvider : AuthenticationStateProvider
{
    private Task<AuthenticationState> currentUser = 
        Task.FromResult(new ClaimsPrincipal(new ClaimsIdentity()));

    public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
        currentUser;

    public Task LoginAsync()
    {
        var loginTask = CreateLoginTask;

        NotifyAuthenticationStateChanged(loginTask);

        return loginTask;

        Task<AuthenticationState> CreateLoginTask()
        {
            var newUser = await LoginWithExternalProviderAsync();
            currentUser = new AuthenticationState(newUser);

            return currentUser;
        }
    }

    private Task<ClaimsPrincipal> LoginWithExternalProviderAsync()
    {
        /*
            Add developer OpenID/MSAL code to authenticate the user
        */
        return Task.FromResult(new ClaimsPrincipal(new ClaimsIdentity()));
    }
}
```

In the preceding example:

* The call to `CreateLoginTask` triggers the login process.
* The call to <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider.NotifyAuthenticationStateChanged%2A> notifies that an update is in progress, which allows the app to provide a temporary UI during the login process.
* Returning `loginTask` returns the task so that the component that triggered the login can await and react after the task is complete.
* The `LoginWithExternalProviderAsync` method is implemented by the developer to log in the user with the identity provider's SDK. For more information, see the identity provider's documentation.

The following `LoginComponent` component demonstrates how to log in a user. In a typical app, the `LoginComponent` component is only shown in a parent component if the user isn't logged into the app.

`Shared/LoginComponent.razor`:

```razor
@inject AuthenticationStateProvider AuthenticationStateProvider

<button @onclick="Login">Log in</button>

@code
{
    public async Task Login()
    {
        await ((HybridAuthenticationStateProvider)AuthenticationStateProvider)
            .LoginAsync();
    }
}
```

The implementation for logout is similar.

Add the Blazor abstractions to the DI container:

```csharp
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, HybridAuthenticationStateProvider>();
```

## Accessing other authentication information

Blazor doesn't define an abstraction to deal with other credentials, such as access tokens to use for HTTP requests to web APIs. We recommend following the identity provider's guidance to manage the user's credentials with the primitives that the identity provider's SDK provides.

It's common for identity provider SDKs to use a token store for user credentials stored in the device. If the SDK's token store primitive is registered with the DI container, consume the SDK's primitive within the app.

The Blazor framework isn't aware of a user's authentication credentials and doesn't interact with credentials in any way, so the app's code is free to follow whatever approach you deem most convenient. However, follow the general security guidance in the next section, [Other authentication security considerations](#other-authentication-security-considerations), when implementing authentication code in an app.

## Other authentication security considerations

The authentication process is external to Blazor, and we recommend that developers access the identity provider's guidance for additional security guidance.

When implementing authentication:

* Avoid authentication in the context of the :::no-loc text="Web View":::. For example, avoid using a JavaScript OAuth library to perform the authentication flow. In a single-page app, authentication tokens aren't hidden in JavaScript and can be easily discovered by malicious users and used for nefarious purposes. Native apps don't suffer this risk because native apps are only able to obtain tokens outside of the browser context, which means that rogue third-party scripts can't steal the tokens and compromise the app.
* Avoid implementing the authentication workflow yourself. In most cases, platform libraries securely handle the authentication workflow, specifically using the system's browser instead of using a custom :::no-loc text="Web View"::: that can be hijacked.
* Avoid using the platform's :::no-loc text="Web View"::: control to perform authentication. Instead, rely on the system's browser when possible.
* Avoid passing the tokens to the document context (JavaScript). In some situations, a JavaScript library within the document is required to perform an authorized call to an external service. Instead of making the token available to JavaScript via JS interop:
  * Provide a fake token to the library and within the :::no-loc text="Web View":::.
  * Intercept the outgoing network request in code.
  * Replace the fake token with the real token and confirm that the destination of the request is valid.

## Untrusted and unencoded content

Avoid allowing an app render untrusted and unencoded content from a database or other resource, such as user-provided comments, in its rendered UI. Permitting untrusted, unencoded content to render can cause malicious code to execute.

## External content rendered in an `iframe`

When using an [`iframe`](https://developer.mozilla.org/docs/Web/HTML/Element/iframe) to display external content within a Blazor Hybrid page, we recommend that users leverage sandboxing features to ensure that the content is isolated from the parent page containing the app. In the following example, the [`sandbox` attribute](https://developer.mozilla.org/docs/Web/HTML/Element/iframe) is present for the `<iframe>` tag to apply [sandboxing features](https://developer.mozilla.org/docs/Web/HTML/Element/iframe) to the `foo.html` page:

```html
<iframe sandbox src="https://contoso.com/foo.html" />
```

> [!WARNING]
> The [`sandbox` attribute](https://developer.mozilla.org/docs/Web/HTML/Element/iframe) is ***not*** supported in early browser versions. For more information, see [Can I use: `sandbox`](https://caniuse.com/?search=sandbox).

## Links to external URLs

By default, links to URLs outside of the app are opened in an appropriate external app, not loaded within the :::no-loc text="Web View":::. We do ***not*** recommend overriding the default behavior.

The user might be able to indicate that they want the URL to load in the app because it's content that they trust. In that case, see the [Untrusted and unencoded content](#untrusted-and-unencoded-content) section.

## Keep the :::no-loc text="Web View"::: current deployed apps

By default, the [`BlazorWebView`](/maui/user-interface/controls/blazorwebview) control uses the currently-installed, platform-specific native :::no-loc text="Web View":::. Since the native :::no-loc text="Web View"::: is periodically updated with support for new APIs and fixes for security issues, it may be necessary to ensure that an app is using a :::no-loc text="Web View"::: version that meets the app's requirements.

To keep the :::no-loc text="Web View"::: current in deployed apps, check the :::no-loc text="Web View"::: version and prompt the user to take any necessary steps to update it.

<!-- HOLD FOR RC2 AND SWAP FOR THE PRIOR SENTENCE

Use one of the following approaches to keep the :::no-loc text="Web View"::: current in deployed apps:

* **On all platforms**: Check the :::no-loc text="Web View"::: version and prompt the user to take any necessary steps to update it.
* **Only on Windows**: Package a fixed-version :::no-loc text="Web View"::: within the app, using it in place of the system's shared :::no-loc text="Web View":::.

-->

### Android

The Android :::no-loc text="Web View"::: is distributed and updated via the [Google Play Store](https://play.google.com/store/apps/details?id=com.google.android.webview). Check the :::no-loc text="Web View"::: version by reading the [`User-Agent`](https://developer.mozilla.org/docs/Web/HTTP/Headers/User-Agent) string. Read the :::no-loc text="Web View":::'s [`navigator.userAgent`](https://developer.mozilla.org/docs/Web/API/Navigator/userAgent) property using [JavaScript interop](xref:blazor/js-interop/index) and optionally cache the value using a singleton service if the user agent string is required outside of a Razor component context.

### iOS/Mac Catalyst

iOS and Mac Catalyst both use [`WKWebView`](https://developer.apple.com/documentation/webkit/wkwebview), a Safari-based control, which is updated by the operating system. Similar to the [Android](#android) case, determine the :::no-loc text="Web View"::: version by reading the :::no-loc text="Web View":::'s [`User-Agent`](https://developer.mozilla.org/docs/Web/HTTP/Headers/User-Agent) string.

### Windows (.NET MAUI, WPF, Windows Forms)

On Windows, the Chromium-based [Microsoft Edge `WebView2`](/microsoft-edge/webview2/) is required to run Blazor web apps. By default, the newest installed version of `WebView2` (known as the [Evergreen distribution](/microsoft-edge/webview2/concepts/distribution#details-about-the-fixed-version-runtime-distribution-mode)) is used.

<!-- AT RC2, ADD THE FOLLOWING SENTENCE TO THE PRECEDING PARAGRAPH

If you wish to ship a specific version of `WebView2` with the app, use the [Fixed Version distribution mode](/microsoft-edge/webview2/concepts/distribution#details-about-the-fixed-version-runtime-distribution-mode).

-->

For more information on checking the currently-installed `WebView2` version, see the [`WebView2` distribution docs](/microsoft-edge/webview2/concepts/distribution).

## Additional resources

* <xref:blazor/security/index>
