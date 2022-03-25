---
title: ASP.NET Core Blazor globalization and localization
author: guardrex
description: Learn how to render globalized and localized content to users in different cultures and languages.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/globalization-localization
zone_pivot_groups: blazor-hosting-models
---
# ASP.NET Core Blazor globalization and localization

This article explains how to render globalized and localized content to users in different cultures and languages.

:::moniker range=">= aspnetcore-6.0"

For [globalization](/dotnet/standard/globalization-localization/globalization), Blazor provides number and date formatting. For [localization](/dotnet/standard/globalization-localization/localization), Blazor renders content using the [.NET Resources system](/dotnet/framework/resources/).

A limited set of ASP.NET Core's localization features are supported:

✔️ <xref:Microsoft.Extensions.Localization.IStringLocalizer> and <xref:Microsoft.Extensions.Localization.IStringLocalizer%601> are supported in Blazor apps.

❌ <xref:Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer>, <xref:Microsoft.AspNetCore.Mvc.Localization.IViewLocalizer>, and [Data Annotations localization](xref:fundamentals/localization#dataannotations-localization) are ASP.NET Core MVC features and *not supported* in Blazor apps.

This article describes how to use Blazor's globalization and localization features based on:

* The [`Accept-Language` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Accept-Language), which is set by the browser based on a user's language preferences in browser settings.
* A culture set by the app not based on the value of the [`Accept-Language` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Accept-Language). The setting can be static for all users or dynamic based on app logic. When the setting is based on the user's preference, the setting is usually saved for reload on future visits.

For additional general information, see <xref:fundamentals/localization>.

> [!NOTE]
> Often, the terms *language* and *culture* are used interchangeably when dealing with globalization and localization concepts.
>
> In this article, *language* refers to selections made by a user in their browser's settings. The user's language selections are submitted in browser requests in the [`Accept-Language` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Accept-Language). Browser settings usually use the word "language" in the UI.
>
> *Culture* pertains to members of .NET and Blazor API. For example, a user's request can include the [`Accept-Language` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Accept-Language) specifying a *language* from the user's perspective, but the app ultimately sets the <xref:System.Globalization.CultureInfo.CurrentCulture> ("culture") property from the language that the user requested. API usually uses the word "culture" in its member names.

## Globalization

The [`@bind`](xref:mvc/views/razor#bind) attribute directive applies formats and parses values for display based on the user's first [preferred language](https://developer.mozilla.org/docs/Web/API/NavigatorLanguage/languages) that the app supports. [`@bind`](xref:mvc/views/razor#bind) supports the [`@bind:culture`](xref:mvc/views/razor#bindculture) parameter to provide a <xref:System.Globalization.CultureInfo?displayProperty=fullName> for parsing and formatting a value.

The current culture can be accessed from the <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=fullName> property.

<xref:System.Globalization.CultureInfo.InvariantCulture?displayProperty=nameWithType> is used for the following field types (`<input type="{TYPE}" />`, where the `{TYPE}` placeholder is the type):

* `date`
* `number`

The preceding field types:

* Are displayed using their appropriate browser-based formatting rules.
* Can't contain free-form text.
* Provide user interaction characteristics based on the browser's implementation.

When using the `date` and `number` field types, specifying a culture with [`@bind:culture`](xref:mvc/views/razor#bindculture) isn't recommended because Blazor provides built-in support to render values in the current culture.

The following field types have specific formatting requirements and aren't currently supported by Blazor because they aren't supported by all of the major browsers:

* `datetime-local`
* `month`
* `week`

For current browser support of the preceding types, see [Can I use](https://caniuse.com).

## Invariant globalization

If the app doesn't require localization, configure the app to support the invariant culture, which is generally based on United States English (`en-US`). Set the `InvariantGlobalization` property to `true` in the app's project file (`.csproj`):

```xml
<PropertyGroup>
  <InvariantGlobalization>true</InvariantGlobalization>
</PropertyGroup>
```

Alternatively, configure invariant globalization with the following approaches:

* In `runtimeconfig.json`:

  ```json
  {
    "runtimeOptions": {
      "configProperties": {
        "System.Globalization.Invariant": true
      }
    }
  }
  ```

* With an environment variable:

  * Key: `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT`
  * Value: `true` or `1`

For more information, see [Runtime configuration options for globalization (.NET documentation)](/dotnet/core/run-time-config/globalization).

## Demonstration component

The following `CultureExample1` component can be used to demonstrate Blazor globalization and localization concepts covered by this article.

`Pages/CultureExample1.razor`:

```razor
@page "/culture-example-1"
@using System.Globalization

<h1>Culture Example 1</h1>

<p>
    <b>CurrentCulture</b>: @CultureInfo.CurrentCulture
</p>

<h2>Rendered values</h2>

<ul>
    <li><b>Date</b>: @dt</li>
    <li><b>Number</b>: @number.ToString("N2")</li>
</ul>

<h2><code>&lt;input&gt;</code> elements that don't set a <code>type</code></h2>

<p>
    The following <code>&lt;input&gt;</code> elements use
    <code>CultureInfo.CurrentCulture</code>.
</p>

<ul>
    <li><label><b>Date:</b> <input @bind="dt" /></label></li>
    <li><label><b>Number:</b> <input @bind="number" /></label></li>
</ul>

<h2><code>&lt;input&gt;</code> elements that set a <code>type</code></h2>

<p>
    The following <code>&lt;input&gt;</code> elements use
    <code>CultureInfo.InvariantCulture</code>.
</p>

<ul>
    <li><label><b>Date:</b> <input type="date" @bind="dt" /></label></li>
    <li><label><b>Number:</b> <input type="number" @bind="number" /></label></li>
</ul>

@code {
    private DateTime dt = DateTime.Now;
    private double number = 1999.69;
}
```

The number string format (`N2`) in the preceding example (`.ToString("N2")`) is a [standard .NET numeric format specifier](/dotnet/standard/base-types/standard-numeric-format-strings#numeric-format-specifier-n). The `N2` format is supported for all numeric types, includes a group separator, and renders up to two decimal places.

Optionally, add a menu item to the navigation in `Shared/NavMenu.razor` for the `CultureExample1` component.

## Dynamically set the culture from the `Accept-Language` header

The [`Accept-Language` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Accept-Language) is set by the browser and controlled by the user's language preferences in browser settings. In browser settings, a user sets one or more preferred languages in order of preference. The order of preference is used by the browser to set quality values (`q`, 0-1) for each language in the header. The following example specifies United States English, English, and Chilean Spanish with a preference for United States English or English:

**Accept-Language**: en-US,en;q=0.9,es-CL;q=0.8

The app's culture is set by matching the first requested language that matches a supported culture of the app.

:::zone pivot="webassembly"

Set the `BlazorWebAssemblyLoadAllGlobalizationData` property to `true` in the app's project file (`.csproj`):

```xml
<PropertyGroup>
  <BlazorWebAssemblyLoadAllGlobalizationData>true</BlazorWebAssemblyLoadAllGlobalizationData>
</PropertyGroup>
```

:::zone-end

:::zone pivot="server"

Blazor Server apps are localized using [Localization Middleware](xref:fundamentals/localization#localization-middleware). Add localization services to the app with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A>.

In `Program.cs`:

```csharp
builder.Services.AddLocalization();
```

Specify the app's supported cultures in `Program.cs` immediately after Routing Middleware is added to the processing pipeline. The following example configures supported cultures for United States English and Chilean Spanish:

```csharp
app.UseRequestLocalization(new RequestLocalizationOptions()
    .AddSupportedCultures(new[] { "en-US", "es-CL" })
    .AddSupportedUICultures(new[] { "en-US", "es-CL" }));
```

For information on ordering the Localization Middleware in the middleware pipeline of `Program.cs`, see <xref:fundamentals/middleware/index#middleware-order>.

:::zone-end

Use the `CultureExample1` component shown in the [Demonstration component](#demonstration-component) section to study how globalization works. Issue a request with United States English (`en-US`). Switch to Chilean Spanish (`es-CL`) in the browser's language settings. Request the webpage again.

> [!NOTE]
> Some browsers force you to use the default language setting for both requests and the browser's own UI settings. This can make changing the language back to one that you understand difficult because all of the setting UI screens might end up in a language that you can't read. A browser such as [Opera](https://www.opera.com/download) is a good choice for testing because it permits you to set a default language for webpage requests but leave the browser's settings UI in your language.

When the culture is United States English (`en-US`), the rendered component uses month/day date formatting (`6/7`), 12-hour time (`AM`/`PM`), and comma separators in numbers with a dot for the decimal value (`1,999.69`):

* **Date**: 6/7/2021 6:45:22 AM
* **Number**: 1,999.69

When the culture is Chilean Spanish (`es-CL`), the rendered component uses day/month date formatting (`7/6`), 24-hour time, and period separators in numbers with a comma for the decimal value (`1.999,69`):

* **Date**: 7/6/2021 6:49:38
* **Number**: 1.999,69

## Statically set the culture

:::zone pivot="webassembly"

Set the `BlazorWebAssemblyLoadAllGlobalizationData` property to `true` in the app's project file (`.csproj`):

```xml
<PropertyGroup>
  <BlazorWebAssemblyLoadAllGlobalizationData>true</BlazorWebAssemblyLoadAllGlobalizationData>
</PropertyGroup>
```

The app's culture can be set in JavaScript when Blazor starts with the `applicationCulture` Blazor start option. The following example configures the app to launch using the United States English (`en-US`) culture.

* In `wwwroot/index.html`, prevent Blazor autostart by adding `autostart="false"` to Blazor's `<script>` tag:

  ```html
  <script src="_framework/blazor.webassembly.js" autostart="false"></script>
  ```

* Add the following `<script>` block after Blazor's `<script>` tag and before the closing `</body>` tag:

  ```html
  <script>
    Blazor.start({
      applicationCulture: 'en-US'
    });
  </script>
  ```

The value for `applicationCulture` must conform to the [BCP-47 language tag format](https://www.rfc-editor.org/info/bcp47). For more information on Blazor startup, see <xref:blazor/fundamentals/startup>.

An alternative to setting the culture Blazor's start option is to set the culture in C# code. Set <xref:System.Globalization.CultureInfo.DefaultThreadCurrentCulture?displayProperty=nameWithType> and <xref:System.Globalization.CultureInfo.DefaultThreadCurrentUICulture?displayProperty=nameWithType> in `Program.cs` to the same culture.

Add the <xref:System.Globalization?displayProperty=fullName> namespace to `Program.cs`:

```csharp
using System.Globalization;
```

Add the culture settings before the line that builds and runs the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder> (`await builder.Build().RunAsync();`):

```csharp
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");
```

> [!IMPORTANT]
> Always set <xref:System.Globalization.CultureInfo.DefaultThreadCurrentCulture> and <xref:System.Globalization.CultureInfo.DefaultThreadCurrentUICulture> to the same culture in order to use <xref:Microsoft.Extensions.Localization.IStringLocalizer> and <xref:Microsoft.Extensions.Localization.IStringLocalizer%601>.

:::zone-end

:::zone pivot="server"

Blazor Server apps are localized using [Localization Middleware](xref:fundamentals/localization#localization-middleware). Add localization services to the app with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A>.

In `Program.cs`:

```csharp
builder.Services.AddLocalization();
```

Specify the static culture in `Program.cs` immediately after Routing Middleware is added to the processing pipeline. The following example configures United States English:

```csharp
app.UseRequestLocalization("en-US");
```

The culture value for <xref:Microsoft.AspNetCore.Builder.ApplicationBuilderExtensions.UseRequestLocalization%2A> must conform to the [BCP-47 language tag format](https://www.rfc-editor.org/info/bcp47).

For information on ordering the Localization Middleware in the middleware pipeline of `Program.cs`, see <xref:fundamentals/middleware/index#middleware-order>.

:::zone-end

Use the `CultureExample1` component shown in the [Demonstration component](#demonstration-component) section to study how globalization works. Issue a request with United States English (`en-US`). Switch to Chilean Spanish (`es-CL`) in the browser's language settings. Request the webpage again. When the requested language is Chilean Spanish, the app's culture remains United States English (`en-US`).

## Dynamically set the culture by user preference

:::zone pivot="webassembly"

Examples of locations where an app might store a user's preference include in [browser local storage](https://developer.mozilla.org/docs/Web/API/Window/localStorage) (common in Blazor WebAssembly apps), in a localization cookie or database (common in Blazor Server apps), or in an external service attached to an external database and accessed by a [web API](xref:blazor/call-web-api). The following example demonstrates how to use browser local storage.

Add the [`Microsoft.Extensions.Localization`](https://www.nuget.org/packages/Microsoft.Extensions.Localization) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

Set the `BlazorWebAssemblyLoadAllGlobalizationData` property to `true` in the project file:

```xml
<PropertyGroup>
  <BlazorWebAssemblyLoadAllGlobalizationData>true</BlazorWebAssemblyLoadAllGlobalizationData>
</PropertyGroup>
```

The app's culture in a Blazor WebAssembly app is set using the Blazor framework's API. A user's culture selection can be persisted in browser local storage.

In the `wwwroot/index.html` file after Blazor's `<script>` tag and before the closing `</body>` tag, provide JS functions to get and set the user's culture selection with browser local storage:

```html
<script>
  window.blazorCulture = {
    get: () => window.localStorage['BlazorCulture'],
    set: (value) => window.localStorage['BlazorCulture'] = value
  };
</script>
```

> [!NOTE]
> The preceding example pollutes the client with global methods. For a better approach in production apps, see [JavaScript isolation in JavaScript modules](xref:blazor/js-interop/call-javascript-from-dotnet#javascript-isolation-in-javascript-modules).
>
> Example:
>
> ```javascript
> export function getBlazorCulture() {
>   return window.localStorage['BlazorCulture'];
> };
> export function setBlazorCulture(value) {
>   window.localStorage['BlazorCulture'] = value;
> };
> ```
>
> If you use the preceding functions, change the JS interop calls in this section from `blazorCulture.get` to `getBlazorCulture` and from `blazorCulture.set` to `setBlazorCulture`.

Add the namespaces for <xref:System.Globalization?displayProperty=fullName> and <xref:Microsoft.JSInterop?displayProperty=fullName> to the top of `Program.cs`:

```csharp
using System.Globalization;
using Microsoft.JSInterop;
```

Remove the following line from `Program.cs`:

```diff
- await builder.Build().RunAsync();
```

Replace the preceding line with the following code. The code adds Blazor's localization service to the app's service collection with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A> and uses [JS interop](xref:blazor/js-interop/call-javascript-from-dotnet) to call into JS and retrieve the user's culture selection from local storage. If local storage doesn't contain a culture for the user, the code sets a default value of United States English (`en-US`).

```csharp
builder.Services.AddLocalization();

var host = builder.Build();

CultureInfo culture;
var js = host.Services.GetRequiredService<IJSRuntime>();
var result = await js.InvokeAsync<string>("blazorCulture.get");

if (result != null)
{
    culture = new CultureInfo(result);
}
else
{
    culture = new CultureInfo("en-US");
    await js.InvokeVoidAsync("blazorCulture.set", "en-US");
}

CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

await host.RunAsync();
```

> [!IMPORTANT]
> Always set <xref:System.Globalization.CultureInfo.DefaultThreadCurrentCulture> and <xref:System.Globalization.CultureInfo.DefaultThreadCurrentUICulture> to the same culture in order to use <xref:Microsoft.Extensions.Localization.IStringLocalizer> and <xref:Microsoft.Extensions.Localization.IStringLocalizer%601>.

The following `CultureSelector` component shows how to perform the following actions:

* Set the user's culture selection into browser local storage via JS interop.
* Reload the component that they requested (`forceLoad: true`), which uses the updated culture.

The `CultureSelector` component is placed in the `Shared` folder for use throughout the app.

`Shared/CultureSelector.razor`:

```razor
@using  System.Globalization
@inject IJSRuntime JSRuntime
@inject NavigationManager Nav

<p>
    <label>
        Select your locale:
        <select @bind="Culture">
            @foreach (var culture in supportedCultures)
            {
                <option value="@culture">@culture.DisplayName</option>
            }
        </select>
    </label>
</p>

@code
{
    private CultureInfo[] supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("es-CL"),
    };

    private CultureInfo Culture
    {
        get => CultureInfo.CurrentCulture;
        set
        {
            if (CultureInfo.CurrentCulture != value)
            {
                var js = (IJSInProcessRuntime)JSRuntime;
                js.InvokeVoid("blazorCulture.set", value.Name);

                Nav.NavigateTo(Nav.Uri, forceLoad: true);
            }
        }
    }
}
```

Inside the closing tag of the `<main>` element in `Shared/MainLayout.razor`, add the `CultureSelector` component:

```razor
<div class="bottom-row px-4">
    <CultureSelector />
</div>
```

:::zone-end

:::zone pivot="server"

Examples of locations where an app might store a user's preference include in [browser local storage](https://developer.mozilla.org/docs/Web/API/Window/localStorage) (common in Blazor WebAssembly apps), in a localization cookie or database (common in Blazor Server apps), or in an external service attached to an external database and accessed by a [web API](xref:blazor/call-web-api). The following example demonstrates how to use a localization cookie.

Add the [`Microsoft.Extensions.Localization`](https://www.nuget.org/packages/Microsoft.Extensions.Localization) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

Blazor Server apps are localized using [Localization Middleware](xref:fundamentals/localization#localization-middleware). Add localization services to the app with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A>.

In `Program.cs`:

```csharp
builder.Services.AddLocalization();
```

Set the app's default and supported cultures with <xref:Microsoft.AspNetCore.Builder.RequestLocalizationOptions.SetDefaultCulture%2A?displayProperty=nameWithType>.

In `Program.cs` immediately after Routing Middleware is added to the processing pipeline:

```csharp
var supportedCultures = new[] { "en-US", "es-CL" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);
```

For information on ordering the Localization Middleware in the middleware pipeline of `Program.cs`, see <xref:fundamentals/middleware/index#middleware-order>.

The following example shows how to set the current culture in a cookie that can be read by the Localization Middleware.

Modifications to the `Pages/_Host.cshtml` file require the following namespaces:

* <xref:System.Globalization?displayProperty=fullName>
* <xref:Microsoft.AspNetCore.Localization?displayProperty=fullName>

`Pages/_Host.cshtml`:

```cshtml
@page "/"
@namespace {NAMESPACE}.Pages
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
@using System.Globalization
@using Microsoft.AspNetCore.Localization
@{
    Layout = "_Layout";
    this.HttpContext.Response.Cookies.Append(
        CookieRequestCultureProvider.DefaultCookieName,
        CookieRequestCultureProvider.MakeCookieValue(
            new RequestCulture(
                CultureInfo.CurrentCulture,
                CultureInfo.CurrentUICulture)));
}

<component type="typeof(App)" render-mode="ServerPrerendered" />
```

In the preceding example, the `{NAMESPACE}` placeholder is the app's assembly name.

For information on ordering the Localization Middleware in the middleware pipeline of `Program.cs`, see <xref:fundamentals/middleware/index#middleware-order>.

If the app isn't configured to process controller actions:

* Add MVC services by calling <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllers%2A> on the service collection in `Program.cs`:

  ```csharp
  builder.Services.AddControllers();
  ```

* Add controller endpoint routing in `Program.cs` by calling <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllers%2A> on the <xref:Microsoft.AspNetCore.Routing.IEndpointRouteBuilder>:

  ```csharp
  app.MapControllers();
  ```

  The following example shows the call to <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A> after the line is added:

  ```csharp
  app.MapControllers();
  app.MapBlazorHub();
  app.MapFallbackToPage("/_Host");
  ```

To provide UI to allow a user to select a culture, use a *redirect-based approach* with a localization cookie. The app persists the user's selected culture via a redirect to a controller. The controller sets the user's selected culture into a cookie and redirects the user back to the original URI. The process is similar to what happens in a web app when a user attempts to access a secure resource, where the user is redirected to a sign-in page and then redirected back to the original resource.

`Controllers/CultureController.cs`:

```csharp
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]/[action]")]
public class CultureController : Controller
{
    public IActionResult Set(string culture, string redirectUri)
    {
        if (culture != null)
        {
            HttpContext.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(
                    new RequestCulture(culture, culture)));
        }

        return LocalRedirect(redirectUri);
    }
}
```

> [!WARNING]
> Use the <xref:Microsoft.AspNetCore.Mvc.ControllerBase.LocalRedirect%2A> action result to prevent open redirect attacks. For more information, see <xref:security/preventing-open-redirects>.

The following `CultureSelector` component shows how to call the `Set` method of the `CultureController` with the new culture. The component is placed in the `Shared` folder for use throughout the app.

`Shared/CultureSelector.razor`:

```razor
@using  System.Globalization
@inject NavigationManager Nav

<p>
    <label>
        Select your locale:
        <select @bind="Culture">
            @foreach (var culture in supportedCultures)
            {
                <option value="@culture">@culture.DisplayName</option>
            }
        </select>
    </label>
</p>

@code
{
    private CultureInfo[] supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("es-CL"),
    };

    protected override void OnInitialized()
    {
        Culture = CultureInfo.CurrentCulture;
    }

    private CultureInfo Culture
    {
        get => CultureInfo.CurrentCulture;
        set
        {
            if (CultureInfo.CurrentCulture != value)
            {
                var uri = new Uri(Nav.Uri)
                    .GetComponents(UriComponents.PathAndQuery, UriFormat.Unescaped);
                var cultureEscaped = Uri.EscapeDataString(value.Name);
                var uriEscaped = Uri.EscapeDataString(uri);

                Nav.NavigateTo(
                    $"Culture/Set?culture={cultureEscaped}&redirectUri={uriEscaped}",
                    forceLoad: true);
            }
        }
    }
}
```

Inside the closing `</div>` tag of the `<div class="main">` element in `Shared/MainLayout.razor`, add the `CultureSelector` component:

```razor
<div class="bottom-row px-4">
    <CultureSelector />
</div>
```

:::zone-end

Use the `CultureExample1` component shown in the [Demonstration component](#demonstration-component) section to study how the preceding example works.

## Localization

If the app doesn't already support culture selection per the [Dynamically set the culture by user preference](#dynamically-set-the-culture-by-user-preference) section of this article, add the [`Microsoft.Extensions.Localization`](https://www.nuget.org/packages/Microsoft.Extensions.Localization) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

:::zone pivot="webassembly"

Set the `BlazorWebAssemblyLoadAllGlobalizationData` property to `true` in the app's project file (`.csproj`):

```xml
<PropertyGroup>
  <BlazorWebAssemblyLoadAllGlobalizationData>true</BlazorWebAssemblyLoadAllGlobalizationData>
</PropertyGroup>
```

In `Program.cs`, add namespace the namespace for <xref:System.Globalization?displayProperty=fullName> to the top of the file:

```csharp
using System.Globalization;
```

Add Blazor's localization service to the app's service collection with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A> in `Program.cs`:

```csharp
builder.Services.AddLocalization();
```

:::zone-end

:::zone pivot="server"

Use [Localization Middleware](xref:fundamentals/localization#localization-middleware) to set the app's culture.

If the app doesn't already support culture selection per the [Dynamically set the culture by user preference](#dynamically-set-the-culture-by-user-preference) section of this article:

* Add localization services to the app with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A>.
* Specify the app's default and supported cultures in `Program.cs`. The following example configures supported cultures for United States English and Chilean Spanish.

In `Program.cs`:

```csharp
builder.Services.AddLocalization();
```

In `Program.cs` immediately after Routing Middleware is added to the processing pipeline:

```csharp
var supportedCultures = new[] { "en-US", "es-CL" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);
```

For information on ordering the Localization Middleware in the middleware pipeline of `Program.cs`, see <xref:fundamentals/middleware/index#middleware-order>.

If the app should localize resources based on storing a user's culture setting, use a localization culture cookie. Use of a cookie ensures that the WebSocket connection can correctly propagate the culture. If localization schemes are based on the URL path or query string, the scheme might not be able to work with [WebSockets](xref:fundamentals/websockets), thus fail to persist the culture. Therefore, the recommended approach is to use a localization culture cookie. See the [Dynamically set the culture by user preference](#dynamically-set-the-culture-by-user-preference) section of this article to see an example Razor expression for the `Pages/_Layout.cshtml` file that persists the user's culture selection.

:::zone-end

The example of localized resources in this section works with the prior examples in this article where the app's supported cultures are English (`en`) as a default locale and Spanish (`es`) as a user-selectable or browser-specified alternate locale.

Create resources for each locale. In the following example, resources are created for a default `Greeting` string:

* English: `Hello, World!`
* Spanish (`es`): `¡Hola, Mundo!`

> [!NOTE]
> The following resource file can be added in Visual Studio by right-clicking the project's `Pages` folder and selecting **Add** > **New Item** > **Resources File**. Name the file `CultureExample2.resx`. When the editor appears, provide data for a new entry. Set the **Name** to `Greeting` and **Value** to `Hello, World!`. Save the file.

`Pages/CultureExample2.resx`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<root>
  <xsd:schema id="root" xmlns="" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
    <xsd:import namespace="http://www.w3.org/XML/1998/namespace" />
    <xsd:element name="root" msdata:IsDataSet="true">
      <xsd:complexType>
        <xsd:choice maxOccurs="unbounded">
          <xsd:element name="metadata">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" />
              </xsd:sequence>
              <xsd:attribute name="name" use="required" type="xsd:string" />
              <xsd:attribute name="type" type="xsd:string" />
              <xsd:attribute name="mimetype" type="xsd:string" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="assembly">
            <xsd:complexType>
              <xsd:attribute name="alias" type="xsd:string" />
              <xsd:attribute name="name" type="xsd:string" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="data">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
                <xsd:element name="comment" type="xsd:string" minOccurs="0" msdata:Ordinal="2" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" msdata:Ordinal="1" />
              <xsd:attribute name="type" type="xsd:string" msdata:Ordinal="3" />
              <xsd:attribute name="mimetype" type="xsd:string" msdata:Ordinal="4" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="resheader">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" />
            </xsd:complexType>
          </xsd:element>
        </xsd:choice>
      </xsd:complexType>
    </xsd:element>
  </xsd:schema>
  <resheader name="resmimetype">
    <value>text/microsoft-resx</value>
  </resheader>
  <resheader name="version">
    <value>2.0</value>
  </resheader>
  <resheader name="reader">
    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <resheader name="writer">
    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <data name="Greeting" xml:space="preserve">
    <value>Hello, World!</value>
  </data>
</root>
```

> [!NOTE]
> The following resource file can be added in Visual Studio by right-clicking the project's `Pages` folder and selecting **Add** > **New Item** > **Resources File**. Name the file `CultureExample2.es.resx`. When the editor appears, provide data for a new entry. Set the **Name** to `Greeting` and **Value** to `¡Hola, Mundo!`. Save the file.

`Pages/CultureExample2.es.resx`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<root>
  <xsd:schema id="root" xmlns="" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
    <xsd:import namespace="http://www.w3.org/XML/1998/namespace" />
    <xsd:element name="root" msdata:IsDataSet="true">
      <xsd:complexType>
        <xsd:choice maxOccurs="unbounded">
          <xsd:element name="metadata">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" />
              </xsd:sequence>
              <xsd:attribute name="name" use="required" type="xsd:string" />
              <xsd:attribute name="type" type="xsd:string" />
              <xsd:attribute name="mimetype" type="xsd:string" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="assembly">
            <xsd:complexType>
              <xsd:attribute name="alias" type="xsd:string" />
              <xsd:attribute name="name" type="xsd:string" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="data">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
                <xsd:element name="comment" type="xsd:string" minOccurs="0" msdata:Ordinal="2" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" msdata:Ordinal="1" />
              <xsd:attribute name="type" type="xsd:string" msdata:Ordinal="3" />
              <xsd:attribute name="mimetype" type="xsd:string" msdata:Ordinal="4" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="resheader">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" />
            </xsd:complexType>
          </xsd:element>
        </xsd:choice>
      </xsd:complexType>
    </xsd:element>
  </xsd:schema>
  <resheader name="resmimetype">
    <value>text/microsoft-resx</value>
  </resheader>
  <resheader name="version">
    <value>2.0</value>
  </resheader>
  <resheader name="reader">
    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <resheader name="writer">
    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <data name="Greeting" xml:space="preserve">
    <value>¡Hola, Mundo!</value>
  </data>
</root>
```

The following component demonstrates the use of the localized `Greeting` string with <xref:Microsoft.Extensions.Localization.IStringLocalizer%601>. The Razor markup `@Loc["Greeting"]` in the following example localizes the string keyed to the `Greeting` value, which is set in the preceding resource files.

Add the namespace for <xref:Microsoft.Extensions.Localization?displayProperty=fullName> to the app's `_Imports.razor` file:

```razor
@using Microsoft.Extensions.Localization
```

`Pages/CultureExample2.razor`:

```razor
@page "/culture-example-2"
@using System.Globalization
@inject IStringLocalizer<CultureExample2> Loc

<h1>Culture Example 2</h1>

<p>
    <b>CurrentCulture</b>: @CultureInfo.CurrentCulture
</p>

<h2>Greeting</h2>

<p>
    @Loc["Greeting"]
</p>

<p>
    @greeting
</p>

@code {
    private string? greeting;

    protected override void OnInitialized()
    {
        greeting = Loc["Greeting"];
    }
}
```

Optionally, add a menu item to the navigation in `Shared/NavMenu.razor` for the `CultureExample2` component.

:::zone pivot="webassembly"

## Culture provider reference source

To further understand how the Blazor framework processes localization, see the [`WebAssemblyCultureProvider` class](https://github.com/dotnet/aspnetcore/blob/main/src/Components/WebAssembly/WebAssembly/src/Hosting/WebAssemblyCultureProvider.cs) in the ASP.NET Core reference source.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

:::zone-end

## Additional resources

* [Set the app base path](xref:blazor/host-and-deploy/index#app-base-path)
* <xref:fundamentals/localization>
* [Globalizing and localizing .NET applications](/dotnet/standard/globalization-localization/index)
* [Resources in .resx Files](/dotnet/framework/resources/working-with-resx-files-programmatically)
* [Microsoft Multilingual App Toolkit](https://marketplace.visualstudio.com/items?itemName=MultilingualAppToolkit.MultilingualAppToolkit-18308)
* [Localization & Generics](http://hishambinateya.com/localization-and-generics)

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

For [globalization](/dotnet/standard/globalization-localization/globalization), Blazor provides number and date formatting. For [localization](/dotnet/standard/globalization-localization/localization), Blazor renders content using the [.NET Resources system](/dotnet/framework/resources/).

A limited set of ASP.NET Core's localization features are supported:

✔️ <xref:Microsoft.Extensions.Localization.IStringLocalizer> and <xref:Microsoft.Extensions.Localization.IStringLocalizer%601> are supported in Blazor apps.

❌ <xref:Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer>, <xref:Microsoft.AspNetCore.Mvc.Localization.IViewLocalizer>, and [Data Annotations localization](xref:fundamentals/localization#dataannotations-localization) are ASP.NET Core MVC features and *not supported* in Blazor apps.

This article describes how to use Blazor's globalization and localization features based on:

* The [`Accept-Language` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Accept-Language), which is set by the browser based on a user's language preferences in browser settings.
* A culture set by the app not based on the value of the [`Accept-Language` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Accept-Language). The setting can be static for all users or dynamic based on app logic. When the setting is based on the user's preference, the setting is usually saved for reload on future visits.

For additional general information, see <xref:fundamentals/localization>.

> [!NOTE]
> Often, the terms *language* and *culture* are used interchangeably when dealing with globalization and localization concepts.
>
> In this article, *language* refers to selections made by a user in their browser's settings. The user's language selections are submitted in browser requests in the [`Accept-Language` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Accept-Language). Browser settings usually use the word "language" in the UI.
>
> *Culture* pertains to members of .NET and Blazor API. For example, a user's request can include the [`Accept-Language` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Accept-Language) specifying a *language* from the user's perspective, but the app ultimately sets the <xref:System.Globalization.CultureInfo.CurrentCulture> ("culture") property from the language that the user requested. API usually uses the word "culture" in its member names.

## Globalization

The [`@bind`](xref:mvc/views/razor#bind) attribute directive applies formats and parses values for display based on the user's first [preferred language](https://developer.mozilla.org/docs/Web/API/NavigatorLanguage/languages) that the app supports. [`@bind`](xref:mvc/views/razor#bind) supports the [`@bind:culture`](xref:mvc/views/razor#bindculture) parameter to provide a <xref:System.Globalization.CultureInfo?displayProperty=fullName> for parsing and formatting a value.

The current culture can be accessed from the <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=fullName> property.

<xref:System.Globalization.CultureInfo.InvariantCulture?displayProperty=nameWithType> is used for the following field types (`<input type="{TYPE}" />`, where the `{TYPE}` placeholder is the type):

* `date`
* `number`

The preceding field types:

* Are displayed using their appropriate browser-based formatting rules.
* Can't contain free-form text.
* Provide user interaction characteristics based on the browser's implementation.

When using the `date` and `number` field types, specifying a culture with [`@bind:culture`](xref:mvc/views/razor#bindculture) isn't recommended because Blazor provides built-in support to render values in the current culture.

The following field types have specific formatting requirements and aren't currently supported by Blazor because they aren't supported by all of the major browsers:

* `datetime-local`
* `month`
* `week`

For current browser support of the preceding types, see [Can I use](https://caniuse.com).

## Invariant globalization

If the app doesn't require localization, configure the app to support the invariant culture, which is generally based on United States English (`en-US`). Set the `InvariantGlobalization` property to `true` in the app's project file (`.csproj`):

```xml
<PropertyGroup>
  <InvariantGlobalization>true</InvariantGlobalization>
</PropertyGroup>
```

Alternatively, configure invariant globalization with the following approaches:

* In `runtimeconfig.json`:

  ```json
  {
    "runtimeOptions": {
      "configProperties": {
        "System.Globalization.Invariant": true
      }
    }
  }
  ```

* With an environment variable:

  * Key: `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT`
  * Value: `true` or `1`

For more information, see [Runtime configuration options for globalization (.NET documentation)](/dotnet/core/run-time-config/globalization).

## Demonstration component

The following `CultureExample1` component can be used to demonstrate Blazor globalization and localization concepts covered by this article.

`Pages/CultureExample1.razor`:

```razor
@page "/culture-example-1"
@using System.Globalization

<h1>Culture Example 1</h1>

<p>
    <b>CurrentCulture</b>: @CultureInfo.CurrentCulture
</p>

<h2>Rendered values</h2>

<ul>
    <li><b>Date</b>: @dt</li>
    <li><b>Number</b>: @number.ToString("N2")</li>
</ul>

<h2><code>&lt;input&gt;</code> elements that don't set a <code>type</code></h2>

<p>
    The following <code>&lt;input&gt;</code> elements use
    <code>CultureInfo.CurrentCulture</code>.
</p>

<ul>
    <li><label><b>Date:</b> <input @bind="dt" /></label></li>
    <li><label><b>Number:</b> <input @bind="number" /></label></li>
</ul>

<h2><code>&lt;input&gt;</code> elements that set a <code>type</code></h2>

<p>
    The following <code>&lt;input&gt;</code> elements use
    <code>CultureInfo.InvariantCulture</code>.
</p>

<ul>
    <li><label><b>Date:</b> <input type="date" @bind="dt" /></label></li>
    <li><label><b>Number:</b> <input type="number" @bind="number" /></label></li>
</ul>

@code {
    private DateTime dt = DateTime.Now;
    private double number = 1999.69;
}
```

The number string format (`N2`) in the preceding example (`.ToString("N2")`) is a [standard .NET numeric format specifier](/dotnet/standard/base-types/standard-numeric-format-strings#numeric-format-specifier-n). The `N2` format is supported for all numeric types, includes a group separator, and renders up to two decimal places.

Optionally, add a menu item to the navigation in `Shared/NavMenu.razor` for the `CultureExample1` component.

## Dynamically set the culture from the `Accept-Language` header

The [`Accept-Language` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Accept-Language) is set by the browser and controlled by the user's language preferences in browser settings. In browser settings, a user sets one or more preferred languages in order of preference. The order of preference is used by the browser to set quality values (`q`, 0-1) for each language in the header. The following example specifies United States English, English, and Chilean Spanish with a preference for United States English or English:

**Accept-Language**: en-US,en;q=0.9,es-CL;q=0.8

The app's culture is set by matching the first requested language that matches a supported culture of the app.

:::zone pivot="webassembly"

Set the `BlazorWebAssemblyLoadAllGlobalizationData` property to `true` in the app's project file (`.csproj`):

```xml
<PropertyGroup>
  <BlazorWebAssemblyLoadAllGlobalizationData>true</BlazorWebAssemblyLoadAllGlobalizationData>
</PropertyGroup>
```

:::zone-end

:::zone pivot="server"

Blazor Server apps are localized using [Localization Middleware](xref:fundamentals/localization#localization-middleware). Add localization services to the app with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A>.

In `Startup.ConfigureServices` (`Startup.cs`):

```csharp
services.AddLocalization();
```

Specify the app's supported cultures in `Startup.Configure` (`Startup.cs`) immediately after Routing Middleware is added to the processing pipeline. The following example configures supported cultures for United States English and Chilean Spanish:

```csharp
app.UseRequestLocalization(new RequestLocalizationOptions()
    .AddSupportedCultures(new[] { "en-US", "es-CL" })
    .AddSupportedUICultures(new[] { "en-US", "es-CL" }));
```

For information on ordering the Localization Middleware in the middleware pipeline of `Startup.Configure`, see <xref:fundamentals/middleware/index#middleware-order>.

:::zone-end

Use the `CultureExample1` component shown in the [Demonstration component](#demonstration-component) section to study how globalization works. Issue a request with United States English (`en-US`). Switch to Chilean Spanish (`es-CL`) in the browser's language settings. Request the webpage again.

> [!NOTE]
> Some browsers force you to use the default language setting for both requests and the browser's own UI settings. This can make changing the language back to one that you understand difficult because all of the setting UI screens might end up in a language that you can't read. A browser such as [Opera](https://www.opera.com/download) is a good choice for testing because it permits you to set a default language for webpage requests but leave the browser's settings UI in your language.

When the culture is United States English (`en-US`), the rendered component uses month/day date formatting (`6/7`), 12-hour time (`AM`/`PM`), and comma separators in numbers with a dot for the decimal value (`1,999.69`):

* **Date**: 6/7/2021 6:45:22 AM
* **Number**: 1,999.69

When the culture is Chilean Spanish (`es-CL`), the rendered component uses day/month date formatting (`7/6`), 24-hour time, and period separators in numbers with a comma for the decimal value (`1.999,69`):

* **Date**: 7/6/2021 6:49:38
* **Number**: 1.999,69

## Statically set the culture

:::zone pivot="webassembly"

Set the `BlazorWebAssemblyLoadAllGlobalizationData` property to `true` in the app's project file (`.csproj`):

```xml
<PropertyGroup>
  <BlazorWebAssemblyLoadAllGlobalizationData>true</BlazorWebAssemblyLoadAllGlobalizationData>
</PropertyGroup>
```

The app's culture can be set in JavaScript when Blazor starts with the `applicationCulture` Blazor start option. The following example configures the app to launch using the United States English (`en-US`) culture.

* In `wwwroot/index.html`, prevent Blazor autostart by adding `autostart="false"` to Blazor's `<script>` tag:

  ```html
  <script src="_framework/blazor.webassembly.js" autostart="false"></script>
  ```

* Add the following `<script>` block after Blazor's `<script>` tag and before the closing `</body>` tag:

  ```html
  <script>
    Blazor.start({
      applicationCulture: 'en-US'
    });
  </script>
  ```

The value for `applicationCulture` must conform to the [BCP-47 language tag format](https://www.rfc-editor.org/info/bcp47). For more information on Blazor startup, see <xref:blazor/fundamentals/startup>.

An alternative to setting the culture Blazor's start option is to set the culture in C# code. Set <xref:System.Globalization.CultureInfo.DefaultThreadCurrentCulture?displayProperty=nameWithType> and <xref:System.Globalization.CultureInfo.DefaultThreadCurrentUICulture?displayProperty=nameWithType> in `Program.cs` to the same culture.

Add the <xref:System.Globalization?displayProperty=fullName> namespace to `Program.cs`:

```csharp
using System.Globalization;
```

Add the culture settings before the line that builds and runs the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder> (`await builder.Build().RunAsync();`):

```csharp
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");
```

> [!IMPORTANT]
> Always set <xref:System.Globalization.CultureInfo.DefaultThreadCurrentCulture> and <xref:System.Globalization.CultureInfo.DefaultThreadCurrentUICulture> to the same culture in order to use <xref:Microsoft.Extensions.Localization.IStringLocalizer> and <xref:Microsoft.Extensions.Localization.IStringLocalizer%601>.

:::zone-end

:::zone pivot="server"

Blazor Server apps are localized using [Localization Middleware](xref:fundamentals/localization#localization-middleware). Add localization services to the app with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A>.

In `Startup.ConfigureServices` (`Startup.cs`):

```csharp
services.AddLocalization();
```

Specify the static culture in `Startup.Configure` (`Startup.cs`) immediately after Routing Middleware is added to the processing pipeline. The following example configures United States English:

```csharp
app.UseRequestLocalization("en-US");
```

The culture value for <xref:Microsoft.AspNetCore.Builder.ApplicationBuilderExtensions.UseRequestLocalization%2A> must conform to the [BCP-47 language tag format](https://www.rfc-editor.org/info/bcp47).

For information on ordering the Localization Middleware in the middleware pipeline of `Startup.Configure`, see <xref:fundamentals/middleware/index#middleware-order>.

:::zone-end

Use the `CultureExample1` component shown in the [Demonstration component](#demonstration-component) section to study how globalization works. Issue a request with United States English (`en-US`). Switch to Chilean Spanish (`es-CL`) in the browser's language settings. Request the webpage again. When the requested language is Chilean Spanish, the app's culture remains United States English (`en-US`).

## Dynamically set the culture by user preference

:::zone pivot="webassembly"

Examples of locations where an app might store a user's preference include in [browser local storage](https://developer.mozilla.org/docs/Web/API/Window/localStorage) (common in Blazor WebAssembly apps), in a localization cookie or database (common in Blazor Server apps), or in an external service attached to an external database and accessed by a [web API](xref:blazor/call-web-api). The following example demonstrates how to use browser local storage.

Add the [`Microsoft.Extensions.Localization`](https://www.nuget.org/packages/Microsoft.Extensions.Localization) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

Set the `BlazorWebAssemblyLoadAllGlobalizationData` property to `true` in the project file:

```xml
<PropertyGroup>
  <BlazorWebAssemblyLoadAllGlobalizationData>true</BlazorWebAssemblyLoadAllGlobalizationData>
</PropertyGroup>
```

The app's culture in a Blazor WebAssembly app is set using the Blazor framework's API. A user's culture selection can be persisted in browser local storage.

In the `wwwroot/index.html` file after Blazor's `<script>` tag and before the closing `</body>` tag, provide JS functions to get and set the user's culture selection with browser local storage:

```html
<script>
  window.blazorCulture = {
    get: () => window.localStorage['BlazorCulture'],
    set: (value) => window.localStorage['BlazorCulture'] = value
  };
</script>
```

> [!NOTE]
> The preceding example pollutes the client with global methods. For a better approach in production apps, see [JavaScript isolation in JavaScript modules](xref:blazor/js-interop/call-javascript-from-dotnet#javascript-isolation-in-javascript-modules).
>
> Example:
>
> ```javascript
> export function getBlazorCulture() {
>   return window.localStorage['BlazorCulture'];
> };
> export function setBlazorCulture(value) {
>   window.localStorage['BlazorCulture'] = value;
> };
> ```
>
> If you use the preceding functions, change the JS interop calls in this section from `blazorCulture.get` to `getBlazorCulture` and from `blazorCulture.set` to `setBlazorCulture`.

Add the namespaces for <xref:System.Globalization?displayProperty=fullName> and <xref:Microsoft.JSInterop?displayProperty=fullName> to the top of `Program.cs`:

```csharp
using System.Globalization;
using Microsoft.JSInterop;
```

Remove the following line from `Program.cs`:

```diff
- await builder.Build().RunAsync();
```

Replace the preceding line with the following code. The code adds Blazor's localization service to the app's service collection with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A> and uses [JS interop](xref:blazor/js-interop/call-javascript-from-dotnet) to call into JS and retrieve the user's culture selection from local storage. If local storage doesn't contain a culture for the user, the code sets a default value of United States English (`en-US`).

```csharp
builder.Services.AddLocalization();

var host = builder.Build();

CultureInfo culture;
var js = host.Services.GetRequiredService<IJSRuntime>();
var result = await js.InvokeAsync<string>("blazorCulture.get");

if (result != null)
{
    culture = new CultureInfo(result);
}
else
{
    culture = new CultureInfo("en-US");
    await js.InvokeVoidAsync("blazorCulture.set", "en-US");
}

CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

await host.RunAsync();
```

> [!IMPORTANT]
> Always set <xref:System.Globalization.CultureInfo.DefaultThreadCurrentCulture> and <xref:System.Globalization.CultureInfo.DefaultThreadCurrentUICulture> to the same culture in order to use <xref:Microsoft.Extensions.Localization.IStringLocalizer> and <xref:Microsoft.Extensions.Localization.IStringLocalizer%601>.

The following `CultureSelector` component shows how to set the user's culture selection into browser local storage via JS interop. The component is placed in the `Shared` folder for use throughout the app.

`Shared/CultureSelector.razor`:

```razor
@using  System.Globalization
@inject IJSRuntime JSRuntime
@inject NavigationManager Nav

<p>
    <label>
        Select your locale:
        <select @bind="Culture">
            @foreach (var culture in supportedCultures)
            {
                <option value="@culture">@culture.DisplayName</option>
            }
        </select>
    </label>
</p>

@code
{
    private CultureInfo[] supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("es-CL"),
    };

    private CultureInfo Culture
    {
        get => CultureInfo.CurrentCulture;
        set
        {
            if (CultureInfo.CurrentCulture != value)
            {
                var js = (IJSInProcessRuntime)JSRuntime;
                js.InvokeVoid("blazorCulture.set", value.Name);

                Nav.NavigateTo(Nav.Uri, forceLoad: true);
            }
        }
    }
}
```

Inside the closing `</div>` tag of the `<div class="main">` element in `Shared/MainLayout.razor`, add the `CultureSelector` component:

```razor
<div class="bottom-row px-4">
    <CultureSelector />
</div>
```

:::zone-end

:::zone pivot="server"

Examples of locations where an app might store a user's preference include in [browser local storage](https://developer.mozilla.org/docs/Web/API/Window/localStorage) (common in Blazor WebAssembly apps), in a localization cookie or database (common in Blazor Server apps), or in an external service attached to an external database and accessed by a [web API](xref:blazor/call-web-api). The following example demonstrates how to use a localization cookie.

Add the [`Microsoft.Extensions.Localization`](https://www.nuget.org/packages/Microsoft.Extensions.Localization) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

Blazor Server apps are localized using [Localization Middleware](xref:fundamentals/localization#localization-middleware). Add localization services to the app with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A>.

In `Startup.ConfigureServices` (`Startup.cs`):

```csharp
services.AddLocalization();
```

Set the app's default and supported cultures with <xref:Microsoft.AspNetCore.Builder.RequestLocalizationOptions.SetDefaultCulture%2A?displayProperty=nameWithType>.

In `Startup.Configure` immediately after Routing Middleware is added to the processing pipeline:

```csharp
var supportedCultures = new[] { "en-US", "es-CL" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);
```

For information on ordering the Localization Middleware in the middleware pipeline of `Startup.Configure`, see <xref:fundamentals/middleware/index#middleware-order>.

The following example shows how to set the current culture in a cookie that can be read by the Localization Middleware.

Add the following namespaces to the top of the `Pages/_Host.cshtml` file:

```csharp
@using System.Globalization
@using Microsoft.AspNetCore.Localization
```

Immediately after the opening `<body>` tag of `Pages/_Host.cshtml`, add the following Razor expression:

```cshtml
@{
    this.HttpContext.Response.Cookies.Append(
        CookieRequestCultureProvider.DefaultCookieName,
        CookieRequestCultureProvider.MakeCookieValue(
            new RequestCulture(
                CultureInfo.CurrentCulture,
                CultureInfo.CurrentUICulture)));
}
```

For information on ordering the Localization Middleware in the middleware pipeline of `Startup.Configure`, see <xref:fundamentals/middleware/index#middleware-order>.

If the app isn't configured to process controller actions:

* Add MVC services by calling <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllers%2A> on the service collection in `Startup.ConfigureServices`:

  ```csharp
  services.AddControllers();
  ```

* Add controller endpoint routing in `Startup.Configure` by calling <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllers%2A> on the <xref:Microsoft.AspNetCore.Routing.IEndpointRouteBuilder>:

  ```csharp
  endpoints.MapControllers();
  ```

  The following example shows the call to <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A> after the line is added:

  ```diff
  app.UseEndpoints(endpoints =>
  {
  +   endpoints.MapControllers();
      endpoints.MapBlazorHub();
      endpoints.MapFallbackToPage("/_Host");
  });
  ```

To provide UI to allow a user to select a culture, use a *redirect-based approach* with a localization cookie. The app persists the user's selected culture via a redirect to a controller. The controller sets the user's selected culture into a cookie and redirects the user back to the original URI. The process is similar to what happens in a web app when a user attempts to access a secure resource, where the user is redirected to a sign-in page and then redirected back to the original resource.

`Controllers/CultureController.cs`:

```csharp
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]/[action]")]
public class CultureController : Controller
{
    public IActionResult Set(string culture, string redirectUri)
    {
        if (culture != null)
        {
            HttpContext.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(
                    new RequestCulture(culture, culture)));
        }

        return LocalRedirect(redirectUri);
    }
}
```

> [!WARNING]
> Use the <xref:Microsoft.AspNetCore.Mvc.ControllerBase.LocalRedirect%2A> action result to prevent open redirect attacks. For more information, see <xref:security/preventing-open-redirects>.

The following `CultureSelector` component shows how to perform the initial redirection when the user selects a culture. The component is placed in the `Shared` folder for use throughout the app.

`Shared/CultureSelector.razor`:

```razor
@using  System.Globalization
@inject NavigationManager Nav

<p>
    <label>
        Select your locale:
        <select @bind="Culture">
            @foreach (var culture in supportedCultures)
            {
                <option value="@culture">@culture.DisplayName</option>
            }
        </select>
    </label>
</p>

@code
{
    private CultureInfo[] supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("es-CL"),
    };

    protected override void OnInitialized()
    {
        Culture = CultureInfo.CurrentCulture;
    }

    private CultureInfo Culture
    {
        get => CultureInfo.CurrentCulture;
        set
        {
            if (CultureInfo.CurrentCulture != value)
            {
                var uri = new Uri(Nav.Uri)
                    .GetComponents(UriComponents.PathAndQuery, UriFormat.Unescaped);
                var cultureEscaped = Uri.EscapeDataString(value.Name);
                var uriEscaped = Uri.EscapeDataString(uri);

                Nav.NavigateTo(
                    $"Culture/Set?culture={cultureEscaped}&redirectUri={uriEscaped}",
                    forceLoad: true);
            }
        }
    }
}
```

Inside the closing `</div>` tag of the `<div class="main">` element in `Shared/MainLayout.razor`, add the `CultureSelector` component:

```razor
<div class="bottom-row px-4">
    <CultureSelector />
</div>
```

:::zone-end

Use the `CultureExample1` component shown in the [Demonstration component](#demonstration-component) section to study how the preceding example works.

## Localization

If the app doesn't already support culture selection per the [Dynamically set the culture by user preference](#dynamically-set-the-culture-by-user-preference) section of this article, add the [`Microsoft.Extensions.Localization`](https://www.nuget.org/packages/Microsoft.Extensions.Localization) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

:::zone pivot="webassembly"

Set the `BlazorWebAssemblyLoadAllGlobalizationData` property to `true` in the app's project file (`.csproj`):

```xml
<PropertyGroup>
  <BlazorWebAssemblyLoadAllGlobalizationData>true</BlazorWebAssemblyLoadAllGlobalizationData>
</PropertyGroup>
```

In `Program.cs`, add namespace the namespace for <xref:System.Globalization?displayProperty=fullName> to the top of the file:

```csharp
using System.Globalization;
```

Add Blazor's localization service to the app's service collection with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A> in `Program.cs`:

```csharp
builder.Services.AddLocalization();
```

:::zone-end

:::zone pivot="server"

Use [Localization Middleware](xref:fundamentals/localization#localization-middleware) to set the app's culture.

If the app doesn't already support culture selection per the [Dynamically set the culture by user preference](#dynamically-set-the-culture-by-user-preference) section of this article:

* Add localization services to the app with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A>.
* Specify the app's default and supported cultures in `Startup.Configure` (`Startup.cs`). The following example configures supported cultures for United States English and Chilean Spanish.

In `Startup.ConfigureServices` (`Startup.cs`):

```csharp
services.AddLocalization();
```

In `Startup.Configure` immediately after Routing Middleware is added to the processing pipeline:

```csharp
var supportedCultures = new[] { "en-US", "es-CL" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);
```

For information on ordering the Localization Middleware in the middleware pipeline of `Startup.Configure`, see <xref:fundamentals/middleware/index#middleware-order>.

If the app should localize resources based on storing a user's culture setting, use a localization culture cookie. Use of a cookie ensures that the WebSocket connection can correctly propagate the culture. If localization schemes are based on the URL path or query string, the scheme might not be able to work with [WebSockets](xref:fundamentals/websockets), thus fail to persist the culture. Therefore, the recommended approach is to use a localization culture cookie. See the [Dynamically set the culture by user preference](#dynamically-set-the-culture-by-user-preference) section of this article to see an example Razor expression for the `Pages/_Host.cshtml` file that persists the user's culture selection.

:::zone-end

The example of localized resources in this section works with the prior examples in this article where the app's supported cultures are English (`en`) as a default locale and Spanish (`es`) as a user-selectable or browser-specified alternate locale.

Create resources for each locale. In the following example, resources are created for a default `Greeting` string:

* English: `Hello, World!`
* Spanish (`es`): `¡Hola, Mundo!`

> [!NOTE]
> The following resource file can be added in Visual Studio by right-clicking the project's `Pages` folder and selecting **Add** > **New Item** > **Resources File**. Name the file `CultureExample2.resx`. When the editor appears, provide data for a new entry. Set the **Name** to `Greeting` and **Value** to `Hello, World!`. Save the file.

`Pages/CultureExample2.resx`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<root>
  <xsd:schema id="root" xmlns="" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
    <xsd:import namespace="http://www.w3.org/XML/1998/namespace" />
    <xsd:element name="root" msdata:IsDataSet="true">
      <xsd:complexType>
        <xsd:choice maxOccurs="unbounded">
          <xsd:element name="metadata">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" />
              </xsd:sequence>
              <xsd:attribute name="name" use="required" type="xsd:string" />
              <xsd:attribute name="type" type="xsd:string" />
              <xsd:attribute name="mimetype" type="xsd:string" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="assembly">
            <xsd:complexType>
              <xsd:attribute name="alias" type="xsd:string" />
              <xsd:attribute name="name" type="xsd:string" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="data">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
                <xsd:element name="comment" type="xsd:string" minOccurs="0" msdata:Ordinal="2" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" msdata:Ordinal="1" />
              <xsd:attribute name="type" type="xsd:string" msdata:Ordinal="3" />
              <xsd:attribute name="mimetype" type="xsd:string" msdata:Ordinal="4" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="resheader">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" />
            </xsd:complexType>
          </xsd:element>
        </xsd:choice>
      </xsd:complexType>
    </xsd:element>
  </xsd:schema>
  <resheader name="resmimetype">
    <value>text/microsoft-resx</value>
  </resheader>
  <resheader name="version">
    <value>2.0</value>
  </resheader>
  <resheader name="reader">
    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <resheader name="writer">
    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <data name="Greeting" xml:space="preserve">
    <value>Hello, World!</value>
  </data>
</root>
```

> [!NOTE]
> The following resource file can be added in Visual Studio by right-clicking the project's `Pages` folder and selecting **Add** > **New Item** > **Resources File**. Name the file `CultureExample2.es.resx`. When the editor appears, provide data for a new entry. Set the **Name** to `Greeting` and **Value** to `¡Hola, Mundo!`. Save the file.

`Pages/CultureExample2.es.resx`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<root>
  <xsd:schema id="root" xmlns="" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
    <xsd:import namespace="http://www.w3.org/XML/1998/namespace" />
    <xsd:element name="root" msdata:IsDataSet="true">
      <xsd:complexType>
        <xsd:choice maxOccurs="unbounded">
          <xsd:element name="metadata">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" />
              </xsd:sequence>
              <xsd:attribute name="name" use="required" type="xsd:string" />
              <xsd:attribute name="type" type="xsd:string" />
              <xsd:attribute name="mimetype" type="xsd:string" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="assembly">
            <xsd:complexType>
              <xsd:attribute name="alias" type="xsd:string" />
              <xsd:attribute name="name" type="xsd:string" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="data">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
                <xsd:element name="comment" type="xsd:string" minOccurs="0" msdata:Ordinal="2" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" msdata:Ordinal="1" />
              <xsd:attribute name="type" type="xsd:string" msdata:Ordinal="3" />
              <xsd:attribute name="mimetype" type="xsd:string" msdata:Ordinal="4" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="resheader">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" />
            </xsd:complexType>
          </xsd:element>
        </xsd:choice>
      </xsd:complexType>
    </xsd:element>
  </xsd:schema>
  <resheader name="resmimetype">
    <value>text/microsoft-resx</value>
  </resheader>
  <resheader name="version">
    <value>2.0</value>
  </resheader>
  <resheader name="reader">
    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <resheader name="writer">
    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <data name="Greeting" xml:space="preserve">
    <value>¡Hola, Mundo!</value>
  </data>
</root>
```

The following component demonstrates the use of the localized `Greeting` string with <xref:Microsoft.Extensions.Localization.IStringLocalizer%601>. The Razor markup `@Loc["Greeting"]` in the following example localizes the string keyed to the `Greeting` value, which is set in the preceding resource files.

Add the namespace for <xref:Microsoft.Extensions.Localization?displayProperty=fullName> to the app's `_Imports.razor` file:

```razor
@using Microsoft.Extensions.Localization
```

`Pages/CultureExample2.razor`:

```razor
@page "/culture-example-2"
@using System.Globalization
@inject IStringLocalizer<CultureExample2> Loc

<h1>Culture Example 2</h1>

<p>
    <b>CurrentCulture</b>: @CultureInfo.CurrentCulture
</p>

<h2>Greeting</h2>

<p>
    @Loc["Greeting"]
</p>

<p>
    @greeting
</p>

@code {
    private string greeting;

    protected override void OnInitialized()
    {
        greeting = Loc["Greeting"];
    }
}
```

Optionally, add a menu item to the navigation in `Shared/NavMenu.razor` for the `CultureExample2` component.

:::zone pivot="webassembly"

## Culture provider reference source

To further understand how the Blazor framework processes localization, see the [`WebAssemblyCultureProvider` class](https://github.com/dotnet/aspnetcore/blob/main/src/Components/WebAssembly/WebAssembly/src/Hosting/WebAssemblyCultureProvider.cs) in the ASP.NET Core reference source.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

:::zone-end

## Additional resources

* [Set the app base path](xref:blazor/host-and-deploy/index#app-base-path)
* <xref:fundamentals/localization>
* [Globalizing and localizing .NET applications](/dotnet/standard/globalization-localization/index)
* [Resources in .resx Files](/dotnet/framework/resources/working-with-resx-files-programmatically)
* [Microsoft Multilingual App Toolkit](https://marketplace.visualstudio.com/items?itemName=MultilingualAppToolkit.MultilingualAppToolkit-18308)
* [Localization & Generics](http://hishambinateya.com/localization-and-generics)

:::moniker-end

:::moniker range="< aspnetcore-5.0"

For [globalization](/dotnet/standard/globalization-localization/globalization), Blazor provides number and date formatting. For [localization](/dotnet/standard/globalization-localization/localization), Blazor renders content using the [.NET Resources system](/dotnet/framework/resources/).

A limited set of ASP.NET Core's localization features are supported:

✔️ <xref:Microsoft.Extensions.Localization.IStringLocalizer> and <xref:Microsoft.Extensions.Localization.IStringLocalizer%601> are supported in Blazor apps.

❌ <xref:Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer>, <xref:Microsoft.AspNetCore.Mvc.Localization.IViewLocalizer>, and [Data Annotations localization](xref:fundamentals/localization#dataannotations-localization) are ASP.NET Core MVC features and *not supported* in Blazor apps.

This article describes how to use Blazor's globalization and localization features based on:

* The [`Accept-Language` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Accept-Language), which is set by the browser based on a user's language preferences in browser settings.
* A culture set by the app not based on the value of the [`Accept-Language` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Accept-Language). The setting can be static for all users or dynamic based on app logic. When the setting is based on the user's preference, the setting is usually saved for reload on future visits.

For additional general information, see <xref:fundamentals/localization>.

> [!NOTE]
> Often, the terms *language* and *culture* are used interchangeably when dealing with globalization and localization concepts.
>
> In this article, *language* refers to selections made by a user in their browser's settings. The user's language selections are submitted in browser requests in the [`Accept-Language` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Accept-Language). Browser settings usually use the word "language" in the UI.
>
> *Culture* pertains to members of .NET and Blazor API. For example, a user's request can include the [`Accept-Language` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Accept-Language) specifying a *language* from the user's perspective, but the app ultimately sets the <xref:System.Globalization.CultureInfo.CurrentCulture> ("culture") property from the language that the user requested. API usually uses the word "culture" in its member names.

## Globalization

The [`@bind`](xref:mvc/views/razor#bind) attribute directive applies formats and parses values for display based on the user's first [preferred language](https://developer.mozilla.org/docs/Web/API/NavigatorLanguage/languages) that the app supports. [`@bind`](xref:mvc/views/razor#bind) supports the [`@bind:culture`](xref:mvc/views/razor#bindculture) parameter to provide a <xref:System.Globalization.CultureInfo?displayProperty=fullName> for parsing and formatting a value.

The current culture can be accessed from the <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=fullName> property.

<xref:System.Globalization.CultureInfo.InvariantCulture?displayProperty=nameWithType> is used for the following field types (`<input type="{TYPE}" />`, where the `{TYPE}` placeholder is the type):

* `date`
* `number`

The preceding field types:

* Are displayed using their appropriate browser-based formatting rules.
* Can't contain free-form text.
* Provide user interaction characteristics based on the browser's implementation.

When using the `date` and `number` field types, specifying a culture with [`@bind:culture`](xref:mvc/views/razor#bindculture) isn't recommended because Blazor provides built-in support to render values in the current culture.

The following field types have specific formatting requirements and aren't currently supported by Blazor because they aren't supported by all of the major browsers:

* `datetime-local`
* `month`
* `week`

For current browser support of the preceding types, see [Can I use](https://caniuse.com).

## Invariant globalization

If the app doesn't require localization, configure the app to support the invariant culture, which is generally based on United States English (`en-US`). Set the `InvariantGlobalization` property to `true` in the app's project file (`.csproj`):

```xml
<PropertyGroup>
  <InvariantGlobalization>true</InvariantGlobalization>
</PropertyGroup>
```

Alternatively, configure invariant globalization with the following approaches:

* In `runtimeconfig.json`:

  ```json
  {
    "runtimeOptions": {
      "configProperties": {
        "System.Globalization.Invariant": true
      }
    }
  }
  ```

* With an environment variable:

  * Key: `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT`
  * Value: `true` or `1`

For more information, see [Runtime configuration options for globalization (.NET documentation)](/dotnet/core/run-time-config/globalization).

## Demonstration component

The following `CultureExample1` component can be used to demonstrate Blazor globalization and localization concepts covered by this article.

`Pages/CultureExample1.razor`:

```razor
@page "/culture-example-1"
@using System.Globalization

<h1>Culture Example 1</h1>

<p>
    <b>CurrentCulture</b>: @CultureInfo.CurrentCulture
</p>

<h2>Rendered values</h2>

<ul>
    <li><b>Date</b>: @dt</li>
    <li><b>Number</b>: @number.ToString("N2")</li>
</ul>

<h2><code>&lt;input&gt;</code> elements that don't set a <code>type</code></h2>

<p>
    The following <code>&lt;input&gt;</code> elements use
    <code>CultureInfo.CurrentCulture</code>.
</p>

<ul>
    <li><label><b>Date:</b> <input @bind="dt" /></label></li>
    <li><label><b>Number:</b> <input @bind="number" /></label></li>
</ul>

<h2><code>&lt;input&gt;</code> elements that set a <code>type</code></h2>

<p>
    The following <code>&lt;input&gt;</code> elements use
    <code>CultureInfo.InvariantCulture</code>.
</p>

<ul>
    <li><label><b>Date:</b> <input type="date" @bind="dt" /></label></li>
    <li><label><b>Number:</b> <input type="number" @bind="number" /></label></li>
</ul>

@code {
    private DateTime dt = DateTime.Now;
    private double number = 1999.69;
}
```

The number string format (`N2`) in the preceding example (`.ToString("N2")`) is a [standard .NET numeric format specifier](/dotnet/standard/base-types/standard-numeric-format-strings#numeric-format-specifier-n). The `N2` format is supported for all numeric types, includes a group separator, and renders up to two decimal places.

Optionally, add a menu item to the navigation in `Shared/NavMenu.razor` for the `CultureExample1` component.

## Dynamically set the culture from the `Accept-Language` header

The [`Accept-Language` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Accept-Language) is set by the browser and controlled by the user's language preferences in browser settings. In browser settings, a user sets one or more preferred languages in order of preference. The order of preference is used by the browser to set quality values (`q`, 0-1) for each language in the header. The following example specifies United States English, English, and Chilean Spanish with a preference for United States English or English:

**Accept-Language**: en-US,en;q=0.9,es-CL;q=0.8

The app's culture is set by matching the first requested language that matches a supported culture of the app.

:::zone pivot="server"

Blazor Server apps are localized using [Localization Middleware](xref:fundamentals/localization#localization-middleware). Add localization services to the app with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A>.

In `Startup.ConfigureServices` (`Startup.cs`):

```csharp
services.AddLocalization();
```

Specify the app's supported cultures in `Startup.Configure` (`Startup.cs`) immediately after Routing Middleware is added to the processing pipeline. The following example configures supported cultures for United States English and Chilean Spanish:

```csharp
app.UseRequestLocalization(new RequestLocalizationOptions()
    .AddSupportedCultures(new[] { "en-US", "es-CL" })
    .AddSupportedUICultures(new[] { "en-US", "es-CL" }));
```

For information on ordering the Localization Middleware in the middleware pipeline of `Startup.Configure`, see <xref:fundamentals/middleware/index#middleware-order>.

:::zone-end

Use the `CultureExample1` component shown in the [Demonstration component](#demonstration-component) section to study how globalization works. Issue a request with United States English (`en-US`). Switch to Chilean Spanish (`es-CL`) in the browser's language settings. Request the webpage again.

> [!NOTE]
> Some browsers force you to use the default language setting for both requests and the browser's own UI settings. This can make changing the language back to one that you understand difficult because all of the setting UI screens might end up in a language that you can't read. A browser such as [Opera](https://www.opera.com/download) is a good choice for testing because it permits you to set a default language for webpage requests but leave the browser's settings UI in your language.

When the culture is United States English (`en-US`), the rendered component uses month/day date formatting (`6/7`), 12-hour time (`AM`/`PM`), and comma separators in numbers with a dot for the decimal value (`1,999.69`):

* **Date**: 6/7/2021 6:45:22 AM
* **Number**: 1,999.69

When the culture is Chilean Spanish (`es-CL`), the rendered component uses day/month date formatting (`7/6`), 24-hour time, and period separators in numbers with a comma for the decimal value (`1.999,69`):

* **Date**: 7/6/2021 6:49:38
* **Number**: 1.999,69

## Statically set the culture

:::zone pivot="webassembly"

By default, the Intermediate Language (IL) Linker configuration for Blazor WebAssembly apps strips out internationalization information except for locales explicitly requested. For more information, see <xref:blazor/host-and-deploy/configure-linker#configure-the-linker-for-internationalization>.

:::zone-end

:::zone pivot="server"

Blazor Server apps are localized using [Localization Middleware](xref:fundamentals/localization#localization-middleware). Add localization services to the app with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A>.

In `Startup.ConfigureServices` (`Startup.cs`):

```csharp
services.AddLocalization();
```

Specify the static culture in `Startup.Configure` (`Startup.cs`) immediately after Routing Middleware is added to the processing pipeline. The following example configures United States English:

```csharp
app.UseRequestLocalization("en-US");
```

The culture value for <xref:Microsoft.AspNetCore.Builder.ApplicationBuilderExtensions.UseRequestLocalization%2A> must conform to the [BCP-47 language tag format](https://www.rfc-editor.org/info/bcp47).

For information on ordering the Localization Middleware in the middleware pipeline of `Startup.Configure`, see <xref:fundamentals/middleware/index#middleware-order>.

:::zone-end

Use the `CultureExample1` component shown in the [Demonstration component](#demonstration-component) section to study how globalization works. Issue a request with United States English (`en-US`). Switch to Chilean Spanish (`es-CL`) in the browser's language settings. Request the webpage again. When the requested language is Chilean Spanish, the app's culture remains United States English (`en-US`).

## Dynamically set the culture by user preference

:::zone pivot="webassembly"

Examples of locations where an app might store a user's preference include in [browser local storage](https://developer.mozilla.org/docs/Web/API/Window/localStorage) (common in Blazor WebAssembly apps), in a localization cookie or database (common in Blazor Server apps), or in an external service attached to an external database and accessed by a [web API](xref:blazor/call-web-api). The following example demonstrates how to use browser local storage.

Add the [`Microsoft.Extensions.Localization`](https://www.nuget.org/packages/Microsoft.Extensions.Localization) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

The app's culture in a Blazor WebAssembly app is set using the Blazor framework's API. A user's culture selection can be persisted in browser local storage.

In the `wwwroot/index.html` file after Blazor's `<script>` tag and before the closing `</body>` tag, provide JS functions to get and set the user's culture selection with browser local storage:

```html
<script>
  window.blazorCulture = {
    get: () => window.localStorage['BlazorCulture'],
    set: (value) => window.localStorage['BlazorCulture'] = value
  };
</script>
```

Add the namespaces for <xref:System.Globalization?displayProperty=fullName> and <xref:Microsoft.JSInterop?displayProperty=fullName> to the top of `Program.cs`:

```csharp
using System.Globalization;
using Microsoft.JSInterop;
```

Remove the following line from `Program.cs`:

```diff
-await builder.Build().RunAsync();
```

Replace the preceding line with the following code. The code adds Blazor's localization service to the app's service collection with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A> and uses [JS interop](xref:blazor/js-interop/call-javascript-from-dotnet) to call into JS and retrieve the user's culture selection from local storage. If local storage doesn't contain a culture for the user, the code sets a default value of United States English (`en-US`).

```csharp
builder.Services.AddLocalization();

var host = builder.Build();

CultureInfo culture;
var js = host.Services.GetRequiredService<IJSRuntime>();
var result = await js.InvokeAsync<string>("blazorCulture.get");

if (result != null)
{
    culture = new CultureInfo(result);
}
else
{
    culture = new CultureInfo("en-US");
    await js.InvokeVoidAsync("blazorCulture.set", "en-US");
}

CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

await host.RunAsync();
```

> [!IMPORTANT]
> Always set <xref:System.Globalization.CultureInfo.DefaultThreadCurrentCulture> and <xref:System.Globalization.CultureInfo.DefaultThreadCurrentUICulture> to the same culture in order to use <xref:Microsoft.Extensions.Localization.IStringLocalizer> and <xref:Microsoft.Extensions.Localization.IStringLocalizer%601>.

The following `CultureSelector` component shows how to set the user's culture selection into browser local storage via JS interop. The component is placed in the `Shared` folder for use throughout the app.

`Shared/CultureSelector.razor`:

```razor
@using  System.Globalization
@inject IJSRuntime JSRuntime
@inject NavigationManager Nav

<p>
    <label>
        Select your locale:
        <select @bind="Culture">
            @foreach (var culture in supportedCultures)
            {
                <option value="@culture">@culture.DisplayName</option>
            }
        </select>
    </label>
</p>

@code
{
    private CultureInfo[] supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("es-CL"),
    };

    private CultureInfo Culture
    {
        get => CultureInfo.CurrentCulture;
        set
        {
            if (CultureInfo.CurrentCulture != value)
            {
                var js = (IJSInProcessRuntime)JSRuntime;
                js.InvokeVoid("blazorCulture.set", value.Name);

                Nav.NavigateTo(Nav.Uri, forceLoad: true);
            }
        }
    }
}
```

Inside the closing `</div>` tag of the `<div class="main">` element in `Shared/MainLayout.razor`, add the `CultureSelector` component:

```razor
<div class="bottom-row px-4">
    <CultureSelector />
</div>
```

:::zone-end

:::zone pivot="server"

Examples of locations where an app might store a user's preference include in [browser local storage](https://developer.mozilla.org/docs/Web/API/Window/localStorage) (common in Blazor WebAssembly apps), in a localization cookie or database (common in Blazor Server apps), or in an external service attached to an external database and accessed by a [web API](xref:blazor/call-web-api). The following example demonstrates how to use a localization cookie.

Add the [`Microsoft.Extensions.Localization`](https://www.nuget.org/packages/Microsoft.Extensions.Localization) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

Blazor Server apps are localized using [Localization Middleware](xref:fundamentals/localization#localization-middleware). Add localization services to the app with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A>.

In `Startup.ConfigureServices` (`Startup.cs`):

```csharp
services.AddLocalization();
```

Set the app's default and supported cultures with <xref:Microsoft.AspNetCore.Builder.RequestLocalizationOptions.SetDefaultCulture%2A?displayProperty=nameWithType>.

In `Startup.Configure` immediately after Routing Middleware is added to the processing pipeline:

```csharp
var supportedCultures = new[] { "en-US", "es-CL" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);
```

For information on ordering the Localization Middleware in the middleware pipeline of `Startup.Configure`, see <xref:fundamentals/middleware/index#middleware-order>.

The following example shows how to set the current culture in a cookie that can be read by the Localization Middleware.

Add the following namespaces to the top of the `Pages/_Host.cshtml` file:

```csharp
@using System.Globalization
@using Microsoft.AspNetCore.Localization
```

Immediately after the opening `<body>` tag of `Pages/_Host.cshtml`, add the following Razor expression:

```cshtml
@{
    this.HttpContext.Response.Cookies.Append(
        CookieRequestCultureProvider.DefaultCookieName,
        CookieRequestCultureProvider.MakeCookieValue(
            new RequestCulture(
                CultureInfo.CurrentCulture,
                CultureInfo.CurrentUICulture)));
}
```

For information on ordering the Localization Middleware in the middleware pipeline of `Startup.Configure`, see <xref:fundamentals/middleware/index#middleware-order>.

If the app isn't configured to process controller actions:

* Add MVC services by calling <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllers%2A> on the service collection in `Startup.ConfigureServices`:

  ```csharp
  services.AddControllers();
  ```

* Add controller endpoint routing in `Startup.Configure` by calling <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllers%2A> on the <xref:Microsoft.AspNetCore.Routing.IEndpointRouteBuilder>:

  ```csharp
  endpoints.MapControllers();
  ```

  The following example shows the call to <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A> after the line is added:

  ```diff
  app.UseEndpoints(endpoints =>
  {
  +   endpoints.MapControllers();
      endpoints.MapBlazorHub();
      endpoints.MapFallbackToPage("/_Host");
  });
  ```

To provide UI to allow a user to select a culture, use a *redirect-based approach* with a localization cookie. The app persists the user's selected culture via a redirect to a controller. The controller sets the user's selected culture into a cookie and redirects the user back to the original URI. The process is similar to what happens in a web app when a user attempts to access a secure resource, where the user is redirected to a sign-in page and then redirected back to the original resource.

`Controllers/CultureController.cs`:

```csharp
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]/[action]")]
public class CultureController : Controller
{
    public IActionResult Set(string culture, string redirectUri)
    {
        if (culture != null)
        {
            HttpContext.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(
                    new RequestCulture(culture, culture)));
        }

        return LocalRedirect(redirectUri);
    }
}
```

> [!WARNING]
> Use the <xref:Microsoft.AspNetCore.Mvc.ControllerBase.LocalRedirect%2A> action result to prevent open redirect attacks. For more information, see <xref:security/preventing-open-redirects>.

The following `CultureSelector` component shows how to perform the initial redirection when the user selects a culture. The component is placed in the `Shared` folder for use throughout the app.

`Shared/CultureSelector.razor`:

```razor
@using  System.Globalization
@inject NavigationManager Nav

<p>
    <label>
        Select your locale:
        <select @bind="Culture">
            @foreach (var culture in supportedCultures)
            {
                <option value="@culture">@culture.DisplayName</option>
            }
        </select>
    </label>
</p>

@code
{
    private CultureInfo[] supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("es-CL"),
    };

    protected override void OnInitialized()
    {
        Culture = CultureInfo.CurrentCulture;
    }

    private CultureInfo Culture
    {
        get => CultureInfo.CurrentCulture;
        set
        {
            if (CultureInfo.CurrentCulture != value)
            {
                var uri = new Uri(Nav.Uri)
                    .GetComponents(UriComponents.PathAndQuery, UriFormat.Unescaped);
                var cultureEscaped = Uri.EscapeDataString(value.Name);
                var uriEscaped = Uri.EscapeDataString(uri);

                Nav.NavigateTo(
                    $"Culture/Set?culture={cultureEscaped}&redirectUri={uriEscaped}",
                    forceLoad: true);
            }
        }
    }
}
```

Inside the closing `</div>` tag of the `<div class="main">` element in `Shared/MainLayout.razor`, add the `CultureSelector` component:

```razor
<div class="bottom-row px-4">
    <CultureSelector />
</div>
```

:::zone-end

Use the `CultureExample1` component shown in the [Demonstration component](#demonstration-component) section to study how the preceding example works.

## Localization

If the app doesn't already support culture selection per the [Dynamically set the culture by user preference](#dynamically-set-the-culture-by-user-preference) section of this article, add the [`Microsoft.Extensions.Localization`](https://www.nuget.org/packages/Microsoft.Extensions.Localization) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

:::zone pivot="webassembly"

By default, the Intermediate Language (IL) Linker configuration for Blazor WebAssembly apps strips out internationalization information except for locales explicitly requested. For more information, see <xref:blazor/host-and-deploy/configure-linker#configure-the-linker-for-internationalization>.

In `Program.cs`, add namespace the namespace for <xref:System.Globalization?displayProperty=fullName> to the top of the file:

```csharp
using System.Globalization;
```

Add Blazor's localization service to the app's service collection with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A> in `Program.cs`:

```csharp
builder.Services.AddLocalization();
```

:::zone-end

:::zone pivot="server"

Use [Localization Middleware](xref:fundamentals/localization#localization-middleware) to set the app's culture.

If the app doesn't already support culture selection per the [Dynamically set the culture by user preference](#dynamically-set-the-culture-by-user-preference) section of this article:

* Add localization services to the app with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A>.
* Specify the app's default and supported cultures in `Startup.Configure` (`Startup.cs`). The following example configures supported cultures for United States English and Chilean Spanish.

In `Startup.ConfigureServices` (`Startup.cs`):

```csharp
services.AddLocalization();
```

In `Startup.Configure` immediately after Routing Middleware is added to the processing pipeline:

```csharp
var supportedCultures = new[] { "en-US", "es-CL" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);
```

For information on ordering the Localization Middleware in the middleware pipeline of `Startup.Configure`, see <xref:fundamentals/middleware/index#middleware-order>.

If the app should localize resources based on storing a user's culture setting, use a localization culture cookie. Use of a cookie ensures that the WebSocket connection can correctly propagate the culture. If localization schemes are based on the URL path or query string, the scheme might not be able to work with [WebSockets](xref:fundamentals/websockets), thus fail to persist the culture. Therefore, the recommended approach is to use a localization culture cookie. See the [Dynamically set the culture by user preference](#dynamically-set-the-culture-by-user-preference) section of this article to see an example Razor expression for the `Pages/_Host.cshtml` file that persists the user's culture selection.

:::zone-end

The example of localized resources in this section works with the prior examples in this article where the app's supported cultures are English (`en`) as a default locale and Spanish (`es`) as a user-selectable or browser-specified alternate locale.

Create resources for each locale. In the following example, resources are created for a default `Greeting` string:

* English: `Hello, World!`
* Spanish (`es`): `¡Hola, Mundo!`

> [!NOTE]
> The following resource file can be added in Visual Studio by right-clicking the project's `Pages` folder and selecting **Add** > **New Item** > **Resources File**. Name the file `CultureExample2.resx`. When the editor appears, provide data for a new entry. Set the **Name** to `Greeting` and **Value** to `Hello, World!`. Save the file.

`Pages/CultureExample2.resx`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<root>
  <xsd:schema id="root" xmlns="" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
    <xsd:import namespace="http://www.w3.org/XML/1998/namespace" />
    <xsd:element name="root" msdata:IsDataSet="true">
      <xsd:complexType>
        <xsd:choice maxOccurs="unbounded">
          <xsd:element name="metadata">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" />
              </xsd:sequence>
              <xsd:attribute name="name" use="required" type="xsd:string" />
              <xsd:attribute name="type" type="xsd:string" />
              <xsd:attribute name="mimetype" type="xsd:string" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="assembly">
            <xsd:complexType>
              <xsd:attribute name="alias" type="xsd:string" />
              <xsd:attribute name="name" type="xsd:string" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="data">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
                <xsd:element name="comment" type="xsd:string" minOccurs="0" msdata:Ordinal="2" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" msdata:Ordinal="1" />
              <xsd:attribute name="type" type="xsd:string" msdata:Ordinal="3" />
              <xsd:attribute name="mimetype" type="xsd:string" msdata:Ordinal="4" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="resheader">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" />
            </xsd:complexType>
          </xsd:element>
        </xsd:choice>
      </xsd:complexType>
    </xsd:element>
  </xsd:schema>
  <resheader name="resmimetype">
    <value>text/microsoft-resx</value>
  </resheader>
  <resheader name="version">
    <value>2.0</value>
  </resheader>
  <resheader name="reader">
    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <resheader name="writer">
    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <data name="Greeting" xml:space="preserve">
    <value>Hello, World!</value>
  </data>
</root>
```

> [!NOTE]
> The following resource file can be added in Visual Studio by right-clicking the project's `Pages` folder and selecting **Add** > **New Item** > **Resources File**. Name the file `CultureExample2.es.resx`. When the editor appears, provide data for a new entry. Set the **Name** to `Greeting` and **Value** to `¡Hola, Mundo!`. Save the file.

`Pages/CultureExample2.es.resx`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<root>
  <xsd:schema id="root" xmlns="" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
    <xsd:import namespace="http://www.w3.org/XML/1998/namespace" />
    <xsd:element name="root" msdata:IsDataSet="true">
      <xsd:complexType>
        <xsd:choice maxOccurs="unbounded">
          <xsd:element name="metadata">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" />
              </xsd:sequence>
              <xsd:attribute name="name" use="required" type="xsd:string" />
              <xsd:attribute name="type" type="xsd:string" />
              <xsd:attribute name="mimetype" type="xsd:string" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="assembly">
            <xsd:complexType>
              <xsd:attribute name="alias" type="xsd:string" />
              <xsd:attribute name="name" type="xsd:string" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="data">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
                <xsd:element name="comment" type="xsd:string" minOccurs="0" msdata:Ordinal="2" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" msdata:Ordinal="1" />
              <xsd:attribute name="type" type="xsd:string" msdata:Ordinal="3" />
              <xsd:attribute name="mimetype" type="xsd:string" msdata:Ordinal="4" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="resheader">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" />
            </xsd:complexType>
          </xsd:element>
        </xsd:choice>
      </xsd:complexType>
    </xsd:element>
  </xsd:schema>
  <resheader name="resmimetype">
    <value>text/microsoft-resx</value>
  </resheader>
  <resheader name="version">
    <value>2.0</value>
  </resheader>
  <resheader name="reader">
    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <resheader name="writer">
    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <data name="Greeting" xml:space="preserve">
    <value>¡Hola, Mundo!</value>
  </data>
</root>
```

The following component demonstrates the use of the localized `Greeting` string with <xref:Microsoft.Extensions.Localization.IStringLocalizer%601>. The Razor markup `@Loc["Greeting"]` in the following example localizes the string keyed to the `Greeting` value, which is set in the preceding resource files.

Add the namespace for <xref:Microsoft.Extensions.Localization?displayProperty=fullName> to the app's `_Imports.razor` file:

```razor
@using Microsoft.Extensions.Localization
```

`Pages/CultureExample2.razor`:

```razor
@page "/culture-example-2"
@using System.Globalization
@inject IStringLocalizer<CultureExample2> Loc

<h1>Culture Example 2</h1>

<p>
    <b>CurrentCulture</b>: @CultureInfo.CurrentCulture
</p>

<h2>Greeting</h2>

<p>
    @Loc["Greeting"]
</p>

<p>
    @greeting
</p>

@code {
    private string greeting;

    protected override void OnInitialized()
    {
        greeting = Loc["Greeting"];
    }
}
```

Optionally, add a menu item to the navigation in `Shared/NavMenu.razor` for the `CultureExample2` component.

## Additional resources

* [Set the app base path](xref:blazor/host-and-deploy/index#app-base-path)
* <xref:fundamentals/localization>
* [Globalizing and localizing .NET applications](/dotnet/standard/globalization-localization/index)
* [Resources in .resx Files](/dotnet/framework/resources/working-with-resx-files-programmatically)
* [Microsoft Multilingual App Toolkit](https://marketplace.visualstudio.com/items?itemName=MultilingualAppToolkit.MultilingualAppToolkit-18308)
* [Localization & Generics](http://hishambinateya.com/localization-and-generics)

:::moniker-end
