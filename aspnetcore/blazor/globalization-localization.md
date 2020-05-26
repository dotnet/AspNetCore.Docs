---
title: ASP.NET Core Blazor globalization and localization
author: guardrex
description: Learn how to make Razor components accessible to users in multiple cultures and languages.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 04/14/2020
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/globalization-localization
---
# ASP.NET Core Blazor globalization and localization

By [Luke Latham](https://github.com/guardrex) and [Daniel Roth](https://github.com/danroth27)

Razor components can be made accessible to users in multiple cultures and languages. The following .NET globalization and localization scenarios are available:

* .NET's resources system
* Culture-specific number and date formatting

A limited set of ASP.NET Core's localization scenarios are currently supported:

* <xref:Microsoft.Extensions.Localization.IStringLocalizer> and <xref:Microsoft.Extensions.Localization.IStringLocalizer%601> *are supported* in Blazor apps.
* <xref:Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer>, <xref:Microsoft.AspNetCore.Mvc.Localization.IViewLocalizer>, and Data Annotations localization are ASP.NET Core MVC scenarios and **not supported** in Blazor apps.

For more information, see <xref:fundamentals/localization>.

## Globalization

Blazor's [`@bind`](xref:mvc/views/razor#bind) functionality performs formats and parses values for display based on the user's current culture.

The current culture can be accessed from the <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=fullName> property.

<xref:System.Globalization.CultureInfo.InvariantCulture?displayProperty=nameWithType> is used for the following field types (`<input type="{TYPE}" />`):

* `date`
* `number`

The preceding field types:

* Are displayed using their appropriate browser-based formatting rules.
* Can't contain free-form text.
* Provide user interaction characteristics based on the browser's implementation.

The following field types have specific formatting requirements and aren't currently supported by Blazor because they aren't supported by all major browsers:

* `datetime-local`
* `month`
* `week`

[`@bind`](xref:mvc/views/razor#bind) supports the `@bind:culture` parameter to provide a <xref:System.Globalization.CultureInfo?displayProperty=fullName> for parsing and formatting a value. Specifying a culture isn't recommended when using the `date` and `number` field types. `date` and `number` have built-in Blazor support that provides the required culture.

## Localization

### Blazor WebAssembly

Blazor WebAssembly apps set the culture using the user's [language preference](https://developer.mozilla.org/docs/Web/API/NavigatorLanguage/languages).

To explicitly configure the culture, set <xref:System.Globalization.CultureInfo.DefaultThreadCurrentCulture?displayProperty=nameWithType> and <xref:System.Globalization.CultureInfo.DefaultThreadCurrentUICulture?displayProperty=nameWithType> in `Program.Main`.

By default, Blazor's linker configuration for Blazor WebAssembly apps strips out internationalization information except for locales explicitly requested. For more information and guidance on controlling the linker's behavior, see <xref:host-and-deploy/blazor/configure-linker#configure-the-linker-for-internationalization>.

While the culture that Blazor selects by default might be sufficient for most users, consider offering a way for users to specify their preferred locale. For a Blazor WebAssembly sample app with a culture picker, see the [LocSample](https://github.com/pranavkm/LocSample) localization sample app.

### Blazor Server

Blazor Server apps are localized using [Localization Middleware](xref:fundamentals/localization#localization-middleware). The middleware selects the appropriate culture for users requesting resources from the app.

The culture can be set using one of the following approaches:

* [Cookies](#cookies)
* [Provide UI to choose the culture](#provide-ui-to-choose-the-culture)

For more information and examples, see <xref:fundamentals/localization>.

#### Cookies

A localization culture cookie can persist the user's culture. The cookie is created by the `OnGet` method of the app's host page (*Pages/Host.cshtml.cs*). The Localization Middleware reads the cookie on subsequent requests to set the user's culture. 

Use of a cookie ensures that the WebSocket connection can correctly propagate the culture. If localization schemes are based on the URL path or query string, the scheme might not be able to work with WebSockets, thus fail to persist the culture. Therefore, use of a localization culture cookie is the recommended approach.

Any technique can be used to assign a culture if the culture is persisted in a localization cookie. If the app already has an established localization scheme for server-side ASP.NET Core, continue to use the app's existing localization infrastructure and set the localization culture cookie within the app's scheme.

The following example shows how to set the current culture in a cookie that can be read by the Localization Middleware. Create a *Pages/_Host.cshtml.cs* file with the following contents in the Blazor Server app:

```csharp
public class HostModel : PageModel
{
    public void OnGet()
    {
        HttpContext.Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(
                new RequestCulture(
                    CultureInfo.CurrentCulture,
                    CultureInfo.CurrentUICulture)));
    }
}
```

Localization is handled by the app in the following sequence of events:

1. The browser sends an initial HTTP request to the app.
1. The culture is assigned by the Localization Middleware.
1. The `OnGet` method in *_Host.cshtml.cs* persists the culture in a cookie as part of the response.
1. The browser opens a WebSocket connection to create an interactive Blazor Server session.
1. The Localization Middleware reads the cookie and assigns the culture.
1. The Blazor Server session begins with the correct culture.

#### Provide UI to choose the culture

To provide UI to allow a user to select a culture, a *redirect-based approach* is recommended. The process is similar to what happens in a web app when a user attempts to access a secure resource. The user is redirected to a sign-in page and then redirected back to the original resource. 

The app persists the user's selected culture via a redirect to a controller. The controller sets the user's selected culture into a cookie and redirects the user back to the original URI.

Establish an HTTP endpoint on the server to set the user's selected culture in a cookie and perform the redirect back to the original URI:

```csharp
[Route("[controller]/[action]")]
public class CultureController : Controller
{
    public IActionResult SetCulture(string culture, string redirectUri)
    {
        if (culture != null)
        {
            HttpContext.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(
                    new RequestCulture(culture)));
        }

        return LocalRedirect(redirectUri);
    }
}
```

> [!WARNING]
> Use the <xref:Microsoft.AspNetCore.Mvc.ControllerBase.LocalRedirect%2A> action result to prevent open redirect attacks. For more information, see <xref:security/preventing-open-redirects>.

The following component shows an example of how to perform the initial redirection when the user selects a culture:

```razor
@inject NavigationManager NavigationManager

<h3>Select your language</h3>

<select @onchange="OnSelected">
    <option>Select...</option>
    <option value="en-US">English</option>
    <option value="fr-FR">Français</option>
</select>

@code {
    private void OnSelected(ChangeEventArgs e)
    {
        var culture = (string)e.Value;
        var uri = new Uri(NavigationManager.Uri)
            .GetComponents(UriComponents.PathAndQuery, UriFormat.Unescaped);
        var query = $"?culture={Uri.EscapeDataString(culture)}&" +
            $"redirectUri={Uri.EscapeDataString(uri)}";

        NavigationManager.NavigateTo("/Culture/SetCulture" + query, forceLoad: true);
    }
}
```

## Additional resources

* <xref:fundamentals/localization>
