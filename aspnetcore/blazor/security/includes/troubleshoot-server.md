### Logging

The server app is a standard ASP.NET Core app. See the [ASP.NET Core logging guidance](xref:fundamentals/logging/index) to enable a lower logging level in the server app.

To enable debug or trace logging for Blazor WebAssembly authentication, see the *Client-side authentication logging* section of <xref:blazor/fundamentals/logging> with the article version selector set to ASP.NET Core 7.0 or later.

### Common errors

* Misconfiguration of the app or Identity Provider (IP)

  The most common errors are caused by incorrect configuration. The following are a few examples:
  
  * Depending on the requirements of the scenario, a missing or incorrect Authority, Instance, Tenant ID, Tenant domain, Client ID, or Redirect URI prevents an app from authenticating clients.
  * Incorrect request scopes prevent clients from accessing server web API endpoints.
  * Incorrect or missing server API permissions prevent clients from accessing server web API endpoints.
  * Running the app at a different port than is configured in the Redirect URI of the IP's app registration. Note that a port isn't required for Microsoft Entra ID and an app running at a `localhost` development testing address, but the app's port configuration and the port where the app is running must match for non-`localhost` addresses.
  
  Configuration coverage in this article shows examples of the correct configuration. Carefully check the configuration looking for app and IP misconfiguration.
  
  If the configuration appears correct:
  
  * Analyze application logs.
  * Examine the network traffic between the client app and the IP or server app with the browser's developer tools. Often, an exact error message or a message with a clue to what's causing the problem is returned to the client by the IP or server app after making a request. Developer tools guidance is found in the following articles:

    * [Google Chrome](https://developers.google.com/web/tools/chrome-devtools/network) (Google documentation)
    * [Microsoft Edge](/microsoft-edge/devtools-guide-chromium/network/)
    * [Mozilla Firefox](https://firefox-source-docs.mozilla.org/devtools-user/network_monitor/index.html) (Mozilla documentation)
  
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
    * Google Chrome: Use `--incognito --new-window {URL}`, where the `{URL}` placeholder is the URL to open (for example, `https://localhost:5001`).
    * Mozilla Firefox: Use `-private -url {URL}`, where the `{URL}` placeholder is the URL to open (for example, `https://localhost:5001`).
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

### Run the server app

When testing and troubleshooting Blazor Web App, make sure that you're running the app from the server project.

### Inspect the user

The following `UserClaims` component can be used directly in apps or serve as the basis for further customization.

`UserClaims.razor`:

```razor
@page "/user-claims"
@using System.Security.Claims
@using Microsoft.AspNetCore.Authorization
@attribute [Authorize]

<PageTitle>User Claims</PageTitle>

<h1>User Claims</h1>

@if (claims.Count() > 0)
{
    <ul>
        @foreach (var claim in claims)
        {
            <li><b>@claim.Type:</b> @claim.Value</li>
        }
    </ul>
}

@code {
    private IEnumerable<Claim> claims = Enumerable.Empty<Claim>();

    [CascadingParameter]
    private Task<AuthenticationState>? AuthState { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (AuthState == null)
        {
            return;
        }

        var authState = await AuthState;
        claims = authState.User.Claims;
    }
}
```
