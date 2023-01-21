The `FetchData` component shows how to:

* Provision an access token.
* Use the access token to call a protected resource API in the *Server* app.

The [`@attribute [Authorize]`](xref:mvc/views/razor#attribute) directive indicates to the Blazor WebAssembly authorization system that the user must be authorized in order to visit this component. The presence of the attribute in the **`Client`** app doesn't prevent the API on the server from being called without proper credentials. The **`Server`** app also must use `[Authorize]` on the appropriate endpoints to correctly protect them.

<xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.IAccessTokenProvider.RequestAccessToken%2A?displayProperty=nameWithType> takes care of requesting an access token that can be added to the request to call the API. If the token is cached or the service is able to provision a new access token without user interaction, the token request succeeds. Otherwise, the token request fails with an <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenNotAvailableException>, which is caught in a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement.

In order to obtain the actual token to include in the request, the app must check that the request succeeded by calling [`tokenResult.TryGetToken(out var token)`](xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessTokenResult.TryGetToken%2A).

If the request was successful, the token variable is populated with the access token. The <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccessToken.Value?displayProperty=nameWithType> property of the token exposes the literal string to include in the `Authorization` request header.

If the request failed because the token couldn't be provisioned without user interaction:

* ASP.NET Core 7.0 or later: The app navigates to `AccessTokenResult.InteractiveRequestUrl` using the given `AccessTokenResult.InteractionOptions` to allow refreshing the access token.
* ASP.NET Core 6.0 or earlier: The token result contains a redirect URL. Navigating to this URL takes the user to the login page and back to the current page after a successful authentication.

```razor
@page "/fetchdata"
@using Microsoft.AspNetCore.Authorization
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@using {APP NAMESPACE}.Shared
@attribute [Authorize]
@inject HttpClient Http

...

@code {
    private WeatherForecast[] forecasts;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
        }
        catch (AccessTokenNotAvailableException exception)
        {
            exception.Redirect();
        }
    }
}
```
