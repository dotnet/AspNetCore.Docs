::: moniker range=">= aspnetcore-5.0"

> [!NOTE]
> If the app throws an unhandled exception when it receives a *401 Unauthorized* response from the API, inspecting the token error may reveal that the access token's audience isn't correct. This scenario is most likely to occur when the App ID URI of your *`Server`* app isn't `api://{SERVER API APP CLIENT ID OR CUSTOM VALUE}` but instead is in the format `https://{TENANT}.onmicrosoft.com/{SERVER API APP CLIENT ID OR CUSTOM VALUE}`. If that's the case, the default access token scope in `Program.Main` (`Program.cs`) of the *`Client`* app appears similar to the following after the solution is created from the Blazor Hosted template:
>
> ```csharp
> options.ProviderOptions.DefaultAccessTokenScopes
>     .Add("https://{TENANT}.onmicrosoft.com/{SERVER API APP CLIENT ID OR CUSTOM VALUE}/{DEFAULT SCOPE}");
> ```
>
> To configure the *`Server`* app's audience, set the `Audience` in the *`Server`* app's app settings file (`appsettings.json`) to match the audience provided by the Azure portal's app registration and the value in the *`Client`* app's default access token scope URI:
>
> ```json
> {
>   "AzureAd": {
>     "Authority": "https://login.microsoftonline.com/{TENANT ID}",
>     "ClientId": "{SERVER API APP CLIENT ID}",
>     "ValidateAuthority": true,
>     "Audience": "https://{TENANT}.onmicrosoft.com/{SERVER API APP CLIENT ID OR CUSTOM VALUE}"
>   }
> }
> ```
>
> In the preceding configuration, the end of the `Audience` value does **not** include the default scope `/{DEFAULT SCOPE}`. When an app is registered in the Azure portal, the default `{API CLIENT ID}` 
>
> Examples:
>
> `Program.Main` (`Program.cs`) of the *`Client`* app indicates the following after the project is created from the Blazor Hosted template:
>
> ```csharp
> options.ProviderOptions.DefaultAccessTokenScopes
>     .Add("https://contoso.onmicrosoft.com/41451fa7-82d9-4673-8fa5-69eff5a761fd/API.Access");
> ```
>
> Configure the *`Server`* app's app settings file (`appsettings.json`) with a matching audience (`Audience`):
>
> ```json
> {
>   "AzureAd": {
>     "Authority": "https://login.microsoftonline.com/e86c78e2-...-918e0565a45e",
>     "ClientId": "41451fa7-82d9-4673-8fa5-69eff5a761fd",
>     "ValidateAuthority": true,
>     "Audience": "https://contoso.onmicrosoft.com/41451fa7-82d9-4673-8fa5-69eff5a761fd"
>   }
> }
> ```
>
> In the preceding example, the end of the `Audience` value does **not** include the default scope `/API.Access`.

::: moniker-end

::: moniker range="< aspnetcore-5.0"

> [!NOTE]
> If the Azure portal provides the scope URI for the app and the app throws an unhandled exception when it receives a *401 Unauthorized* response from the API, try using a scope URI that doesn't include the scheme and host. For example, the Azure portal may provide one of the following scope URI formats:
>
> * `https://{TENANT}.onmicrosoft.com/{API CLIENT ID OR CUSTOM VALUE}/{SCOPE NAME}`
> * `api://{SERVER API APP CLIENT ID OR CUSTOM VALUE}/{SCOPE NAME}`
>
> Try supplying the scope URI without the scheme and host:
>
> ```csharp
> options.ProviderOptions.DefaultAccessTokenScopes.Add(
>     "{SERVER API APP CLIENT ID OR CUSTOM VALUE}/{SCOPE NAME}");
> ```
>
> For example:
>
> ```csharp
> options.ProviderOptions.DefaultAccessTokenScopes.Add(
>     "41451fa7-82d9-4673-8fa5-69eff5a761fd/API.Access");
> ```

::: moniker-end
