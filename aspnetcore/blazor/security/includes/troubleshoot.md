### Logging

*This section applies to ASP.NET Core 7.0 or later.*

To enable debug or trace logging for Blazor WebAssembly authentication, see <xref:blazor/fundamentals/logging>.

### Common errors

* Misconfiguration of the app or Identity Provider (IP)

  The most common errors are caused by incorrect configuration. The following are a few examples:
  
  * Depending on the requirements of the scenario, a missing or incorrect Authority, Instance, Tenant ID, Tenant domain, Client ID, or Redirect URI prevents an app from authenticating clients.
  * An incorrect access token scope prevents clients from accessing server web API endpoints.
  * Incorrect or missing server API permissions prevent clients from accessing server web API endpoints.
  * Running the app at a different port than is configured in the Redirect URI of the Identity Provider's app registration.
  
  Configuration sections of this article's guidance show examples of the correct configuration. Carefully check each section of the article looking for app and IP misconfiguration.
  
  If the configuration appears correct:
  
  * Analyze application logs.
  * Examine the network traffic between the client app and the IP or server app with the browser's developer tools. Often, an exact error message or a message with a clue to what's causing the problem is returned to the client by the IP or server app after making a request. Developer tools guidance is found in the following articles:

    * [Google Chrome](https://developers.google.com/web/tools/chrome-devtools/network) (Google documentation)
    * [Microsoft Edge](/microsoft-edge/devtools-guide-chromium/network/)
    * [Mozilla Firefox](https://developer.mozilla.org/docs/Tools/Network_Monitor) (Mozilla documentation)

  * Decode the contents of a JSON Web Token (JWT) used for authenticating a client or accessing a server web API, depending on where the problem is occurring. For more information, see [Inspect the content of a JSON Web Token (JWT)](#inspect-the-content-of-a-json-web-token-jwt).
  
  The documentation team responds to document feedback and bugs in articles (open an issue from the **This page** feedback section) but is unable to provide product support. Several public support forums are available to assist with troubleshooting an app. We recommend the following:
  
  * [Stack Overflow (tag: `blazor`)](https://stackoverflow.com/questions/tagged/blazor)
  * [ASP.NET Core Slack Team](https://join.slack.com/t/aspnetcore/shared_invite/zt-1mv5487zb-EOZxJ1iqb0A0ajowEbxByQ)
  * [Blazor Gitter](https://gitter.im/aspnet/Blazor)
  
  *The preceding forums are not owned or controlled by Microsoft.*
  
  For non-security, non-sensitive, and non-confidential reproducible framework bug reports, [open an issue with the ASP.NET Core product unit](https://github.com/dotnet/aspnetcore/issues). Don't open an issue with the product unit until you've thoroughly investigated the cause of a problem and can't resolve it on your own and with the help of the community on a public support forum. The product unit isn't able to troubleshoot individual apps that are broken due to simple misconfiguration or use cases involving third-party services. If a report is sensitive or confidential in nature or describes a potential security flaw in the product that attackers may exploit, see [Reporting security issues and bugs (`dotnet/aspnetcore` GitHub repository)](https://github.com/dotnet/aspnetcore/blob/main/CONTRIBUTING.md#reporting-security-issues-and-bugs).

* Unauthorized client for ME-ID

  > info: Microsoft.AspNetCore.Authorization.DefaultAuthorizationService[2]
  > Authorization failed. These requirements were not met:
  > DenyAnonymousAuthorizationRequirement: Requires an authenticated user.

  Login callback error from ME-ID:

  * Error: `unauthorized_client`
  * Description: `AADB2C90058: The provided application is not configured to allow public clients.`

  To resolve the error:

  1. In the Azure portal, access the [app's manifest](/entra/identity-platform/reference-app-manifest).
  1. Set the [`allowPublicClient` attribute](/entra/identity-platform/reference-app-manifest#allowpublicclient-attribute) to `null` or `true`.

### Cookies and site data

Cookies and site data can persist across app updates and interfere with testing and troubleshooting. Clear the following when making app code changes, user account changes with the provider, or provider app configuration changes:

* User sign-in cookies
* App cookies
* Cached and stored site data

One approach to prevent lingering cookies and site data from interfering with testing and troubleshooting is to:

* Configure a browser
  * Use a browser for testing that you can configure to delete all cookie and site data each time the browser is closed.
  * Make sure that the browser is closed manually or by the IDE for any change to the app, test user, or provider configuration.
* Use a custom command to open a browser in InPrivate or Incognito mode in Visual Studio:
  * Open **Browse With** dialog box from Visual Studio's **Run** button.
  * Select the **Add** button.
  * Provide the path to your browser in the **Program** field. The following executable paths are typical installation locations for Windows 10. If your browser is installed in a different location or you aren't using Windows 10, provide the path to the browser's executable.
    * Microsoft Edge: `C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe`
    * Google Chrome: `C:\Program Files (x86)\Google\Chrome\Application\chrome.exe`
    * Mozilla Firefox: `C:\Program Files\Mozilla Firefox\firefox.exe`
  * In the **Arguments** field, provide the command-line option that the browser uses to open in InPrivate or Incognito mode. Some browsers require the URL of the app.
    * Microsoft Edge: Use `-inprivate`.
    * Google Chrome: Use `--incognito --new-window {URL}`, where the placeholder `{URL}` is the URL to open (for example, `https://localhost:5001`).
    * Mozilla Firefox: Use `-private -url {URL}`, where the placeholder `{URL}` is the URL to open (for example, `https://localhost:5001`).
  * Provide a name in the **Friendly name** field. For example, `Firefox Auth Testing`.
  * Select the **OK** button.
  * To avoid having to select the browser profile for each iteration of testing with an app, set the profile as the default with the **Set as Default** button.
  * Make sure that the browser is closed by the IDE for any change to the app, test user, or provider configuration.

### App upgrades

A functioning app may fail immediately after upgrading either the .NET Core SDK on the development machine or changing package versions within the app. In some cases, incoherent packages may break an app when performing major upgrades. Most of these issues can be fixed by following these instructions:

1. Clear the local system's NuGet package caches by executing [`dotnet nuget locals all --clear`](/dotnet/core/tools/dotnet-nuget-locals) from a command shell.
1. Delete the project's `bin` and `obj` folders.
1. Restore and rebuild the project.
1. Delete all of the files in the deployment folder on the server prior to redeploying the app.

> [!NOTE]
> Use of package versions incompatible with the app's target framework isn't supported. For information on a package, use the [NuGet Gallery](https://www.nuget.org) or [FuGet Package Explorer](https://www.fuget.org).

:::moniker range="< aspnetcore-8.0"

### Run the `Server` app

When testing and troubleshooting a hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln), make sure that you're running the app from the **`Server`** project.

:::moniker-end

### Inspect the user

The following `User` component can be used directly in apps or serve as the basis for further customization.

`User.razor`:

```razor
@page "/user"
@attribute [Authorize]
@using System.Text.Json
@using System.Security.Claims
@inject IAccessTokenProvider AuthorizationService

<h1>@AuthenticatedUser?.Identity?.Name</h1>

<h2>Claims</h2>

@foreach (var claim in AuthenticatedUser?.Claims ?? Array.Empty<Claim>())
{
    <p class="claim">@(claim.Type): @claim.Value</p>
}

<h2>Access token</h2>

<p id="access-token">@AccessToken?.Value</p>

<h2>Access token claims</h2>

@foreach (var claim in GetAccessTokenClaims())
{
    <p>@(claim.Key): @claim.Value.ToString()</p>
}

@if (AccessToken != null)
{
    <h2>Access token expires</h2>

    <p>Current time: <span id="current-time">@DateTimeOffset.Now</span></p>
    <p id="access-token-expires">@AccessToken.Expires</p>

    <h2>Access token granted scopes (as reported by the API)</h2>

    @foreach (var scope in AccessToken.GrantedScopes)
    {
        <p>Scope: @scope</p>
    }
}

@code {
    [CascadingParameter]
    private Task<AuthenticationState> AuthenticationState { get; set; }

    public ClaimsPrincipal AuthenticatedUser { get; set; }
    public AccessToken AccessToken { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        var state = await AuthenticationState;
        var accessTokenResult = await AuthorizationService.RequestAccessToken();

        if (!accessTokenResult.TryGetToken(out var token))
        {
            throw new InvalidOperationException(
                "Failed to provision the access token.");
        }

        AccessToken = token;

        AuthenticatedUser = state.User;
    }

    protected IDictionary<string, object> GetAccessTokenClaims()
    {
        if (AccessToken == null)
        {
            return new Dictionary<string, object>();
        }

        // header.payload.signature
        var payload = AccessToken.Value.Split(".")[1];
        var base64Payload = payload.Replace('-', '+').Replace('_', '/')
            .PadRight(payload.Length + (4 - payload.Length % 4) % 4, '=');

        return JsonSerializer.Deserialize<IDictionary<string, object>>(
            Convert.FromBase64String(base64Payload));
    }
}
```

### Inspect the content of a JSON Web Token (JWT)

To decode a JSON Web Token (JWT), use Microsoft's [jwt.ms](https://jwt.ms/) tool. Values in the UI never leave your browser.

Example encoded JWT (shortened for display):

> eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6Ilg1ZVhrNHh5b2pORnVtMWtsMll0djhkbE5QNC1j ... bQdHBHGcQQRbW7Wmo6SWYG4V_bU55Ug_PW4pLPr20tTS8Ct7_uwy9DWrzCMzpD-EiwT5IjXwlGX3IXVjHIlX50IVIydBoPQtadvT7saKo1G5Jmutgq41o-dmz6-yBMKV2_nXA25Q

Example JWT decoded by the tool for an app that authenticates against Azure AAD B2C:

```json
{
  "typ": "JWT",
  "alg": "RS256",
  "kid": "X5eXk4xyojNFum1kl2Ytv8dlNP4-c57dO6QGTVBwaNk"
}.{
  "exp": 1610059429,
  "nbf": 1610055829,
  "ver": "1.0",
  "iss": "https://mysiteb2c.b2clogin.com/5cc15ea8-a296-4aa3-97e4-226dcc9ad298/v2.0/",
  "sub": "5ee963fb-24d6-4d72-a1b6-889c6e2c7438",
  "aud": "70bde375-fce3-4b82-984a-b247d823a03f",
  "nonce": "b2641f54-8dc4-42ca-97ea-7f12ff4af871",
  "iat": 1610055829,
  "auth_time": 1610055822,
  "idp": "idp.com",
  "tfp": "B2C_1_signupsignin"
}.[Signature]
```
