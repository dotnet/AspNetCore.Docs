---
title: ASP.NET Core Blazor WebAssembly additional security scenarios
author: guardrex
description: 
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 03/09/2020
no-loc: [Blazor, SignalR]
uid: security/blazor/webassembly/additional-scnearios
---
# ASP.NET Core Blazor WebAssembly additional security scenarios

By [Javier Calvarro Nelson](https://github.com/javiercn)

[!INCLUDE[](~/includes/blazorwasm-preview-notice.md)]

[!INCLUDE[](~/includes/blazorwasm-3.2-template-article-notice.md)]

## Handle token request errors

When a single page app authenticates a user using Open ID Connect, the authentication state is kept locally within the single page app and in the Identity Provider in the form of a session cookie that is set as a result of the user introducing their credentials.

The tokens that the Identity Provider emits for the user typically are valid for short periods of time, about one hour normally, so the client app needs to regularly fetch new tokens. Otherwise, you would be logged-out after the tokens granted expired. In the majority of cases Open ID Connect clients are able to provision new tokens without requiring the user to authenticate again thanks to the authentication state or "session" that is kept within the Identity Provider.

There are however, some cases in which the client can't get a token without user interaction, for example, when for some reason the user explicitly logged out from the identity provider. (For example if you visited `https://login.microsoftonline.com` and logged out). In those scenarios, the app doesn't know immediately that the user logged out, and any token that it might have received might no longer be valid or it won't be able to provision a new one without user interaction once the current one expires.

This is not something specific to token based authentication, but it is part of the nature of single page apps. A single page app using cookies would also fail to call a server API if the authentication cookie got removed.

For this reason, when we are performing API calls to protected resources we need to be aware of the fact that provision a new access token to call the API might require the user authenticating again and that, even if we have a token that seems to be valid, the call to the server might fail because the token got revoked by the user.

When we request a token there are two possible outcomes:
* The request succeeds and we have a valid token.
* The request fails and we need to authenticate again to get a new token.

When a token request fails, we need to decide whether we want to save any current state before we perform a redirection. We can do several things with increasing levels of complexity:
* We can store the current page state in session storage and during `OnInitializeAsync` check if it is there to restore before we continue when we return to the current page after a successful authentication.
* We can add a query string parameter and use that as a way to signal the app that it needs to re-hydrate the previously saved state.
* We can add a query string parameter with a unique identifier to store things in session storage without risking collisions with other items.

The example below shows how you can preserve the state before you redirect to the login page and how you recover the previous state afterwards using the second option.

```razor
<EditForm Model="User" @onsubmit="OnSaveAsync">
    <label>User
        <InputText @bind-Value="User.Name" />
    </label>
    <label>Last name
        <InputText @bind-Value="User.LastName" />
    </label>
</EditForm>

@code {
    public class Profile
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }

    public Profile User { get; set; } = new Profile();

    protected async override Task OnInitializedAsync()
    {
        var currentQuery = new Uri(Navigation.Uri).Query;
        if (currentQuery.Contains("state=resumeSavingProfile"))
        {
            User = await JS.InvokeAsync<Profile>("sessionStorage.getState", 
                "resumeSavingProfile");
        }
    }

    public async Task OnSaveAsync()
    {
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(Navigation.BaseUri);

        var resumeUri = Navigation.Uri + $"?state=resumeSavingProfile";

        var tokenResult = await AuthenticationService.RequestAccessToken(
            new AccessTokenRequestOptions
            {
                ReturnUrl = resumeUri
            });

        if (tokenResult.TryGetToken(out var token))
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", 
                $"Bearer {token.Value}");
            await httpClient.PostJsonAsync("Save", User);
        }
        else
        {
            await JS.InvokeVoidAsync("sessionStorage.setState", 
                "resumeSavingProfile", User);
            Navigation.NavigateTo(tokenResult.RedirectUrl);
        }
    }
}
```

## Save app state before an authentication operation

During an authentication operation there are cases where you want to save the app state before the browser gets redirected to the Identity provider. This can be the case when you are using something like a state container and you want to restore the state after the authentication succeeds. In those scenarios, you can use a custom authentication state object to preserve your app specific state or a reference to it and restore that state once the authentication operation completes successfully:

```razor
@page "/authentication/{action}"
@inject JSRuntime JS
@inject StateContainer State
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication

<RemoteAuthenticatorViewCore Action="@Action" 
    AuthenticationState="AuthenticationState" OnLoginSucceded="RestoreState" 
    OnLogoutSucceded="RestoreState" />

@code {
    [Parameter]
    public string Action { get; set; }

    public class ApplicationAuthenticationState : RemoteAuthenticationState
    {
        public string Id { get; set; }
    }

    protected async override Task OnInitializedAsync()
    {
        if (RemoteAuthenticationActions.IsAction(RemoteAuthenticationActions.LogIn, 
            Action))
        {
            AuthenticationState.Id = Guid.NewGuid().ToString();
            await JS.InvokeVoidAsync("sessionStorage.setKey", 
                AuthenticationState.Id, State.Store());
        }
    }

    public async Task RestoreState(ApplicationAuthenticationState state)
    {
        var stored = await JS.InvokeAsync<string>("sessionStorage.getKey", 
            state.Id);
        State.FromStore(stored);
    }

    public ApplicationAuthenticationState AuthenticationState { get; set; } = 
        new ApplicationAuthenticationState();
}
```

## Request additional access tokens

Most apps only require an access token to talk to the protected resources that they work with, but in some scenarios a given app might need more than one token to talk to two or more resources. In these scenarios, the `IAccessTokenProvider.RequestToken` method provides an overload that allows you to provision a token with a given set of scopes.

For example:

```csharp
var tokenResult = await AuthenticationService.RequestAccessToken(
    new AccessTokenRequestOptions
    {
        Scopes = new[] { "https://graph.microsoft.com/Mail.Send", 
            "https://graph.microsoft.com/User.Read" }
    });
```

## Customize app routes

By default, the `Microsoft.AspNetCore.Components.WebAssembly.Authentication` package uses the routes shown in the following table for representing different authentication states.

| Route                            | Purpose |
| -------------------------------- | ------- |
| `authentication/login`           | Triggers a sign-in operation. |
| `authentication/login-callback`  | Handles the result of any sign-in operation. |
| `authentication/login-failed`    | Displays error messages when the sign-in operation fails for some reason. |
| `authentication/logout`          | Triggers a sign-out operation. |
| `authentication/logout-callback` | Handles the result of a sign-out operation. |
| `authentication/logout-failed  ` | Displays error messages when the sign-out operation fails for some reason. |
| `authentication/logged-out`      | Indicates that the user has successfully logout. |
| `authentication/profile`         | Triggers an operation to edit the user profile. |
| `authentication/register`        | Triggers an operation to register a new user. |

All these paths are configurable in `RemoteAuthenticationOptions<TProviderOptions>.AuthenticationPaths` if you want to change the paths your app uses for any of the operations described above, you need to change the path in the options as well as making sure that you have a route that handles that path. For example, you can change all the paths to be prefixed by security instead as shown below:

```razor
@page "/security/{action}"
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication

<RemoteAuthenticatorView Action="@Action" />

@code{
    [Parameter]
    public string Action { get; set; }
}
```

```csharp
builder.Services.AddApiAuthorization(options => { 
    options.AuthenticationPaths.LogInPath = "security/login";
    options.AuthenticationPaths.LogInCallbackPath = "security/login-callback";
    options.AuthenticationPaths.LogInFailedPath = "security/login-failed";
    options.AuthenticationPaths.LogOutPath = "security/logout";
    options.AuthenticationPaths.LogOutCallbackPath = "security/logout-callback";
    options.AuthenticationPaths.LogOutFailedPath = "security/logout-failed";
    options.AuthenticationPaths.LogOutSucceededPath = "security/logged-out";
    options.AuthenticationPaths.ProfilePath = "security/profile";
    options.AuthenticationPaths.RegisterPath = "security/register";
});
```

If you plan to have completely different paths, you can do so as described above and simply render the RemoteAuthenticatorView with an explicit action parameter.

For example:

```razor
@page "/register"

<RemoteAuthenticatorView Action="@RemoteAuthenticationActions.Register" />
```

This also means you can break the UI into different pages if you choose to do so.

## Customize the authentication user interface

`RemoteAuthenticatorView` includes a default set of UI pieces for each authentication state. You can customize each state by passing in your own `RenderFragment`. To customize the text that gets displayed during the initial login process you can change the `RemoteAuthenticatorView` as follows:

```razor
@page "/security/{action}"
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication

<RemoteAuthenticatorView Action="@Action">
    <LoggingIn>
        You are about to be redirected to https://login.microsoftonline.com.
    </LoggingIn>
</RemoteAuthenticatorView>

@code{
    [Parameter]
    public string Action { get; set; }
}
```

The remote authenticator view has one fragment that can be used per authentication route shown in the following table.

| Route                            | Fragment             |
| -------------------------------- | -------------------- |
| `authentication/login`           | `<LoggingIn>`        |
| `authentication/login-callback`  | `<CompletingLogIn>`  |
| `authentication/login-failed`    | `<LogInFailed>`      |
| `authentication/logout`          | `<LoggingOut>`       |
| `authentication/logout-callback` | `<CompletingLogOut>` |
| `authentication/logout-failed`   | `<LogOutFailed>`     |
| `authentication/logged-out`      | `<LogOutSucceeded>`  |
| `authentication/profile`         | `<UserProfile>`      |
| `authentication/register`        | `<Registering>`      |
