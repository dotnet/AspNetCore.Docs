---
title: ASP.NET Core Blazor globalization and localization
author: guardrex
description: Learn how to render globalized and localized content to users in different cultures and languages.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 02/09/2024
uid: blazor/globalization-localization
---
# ASP.NET Core Blazor globalization and localization

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to render globalized and localized content to users in different cultures and languages.

## Globalization and localization

For [globalization](/dotnet/core/extensions/globalization), Blazor provides number and date formatting. For [localization](/dotnet/core/extensions/localization), Blazor renders content using the [.NET Resources system](/dotnet/framework/resources/).

A limited set of ASP.NET Core's localization features are supported:

<span aria-hidden="true">✔️</span><span class="visually-hidden">Supported:</span> <xref:Microsoft.Extensions.Localization.IStringLocalizer> and <xref:Microsoft.Extensions.Localization.IStringLocalizer%601> are supported in Blazor apps.

<span aria-hidden="true">❌</span><span class="visually-hidden">Not supported:</span> <xref:Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer>, <xref:Microsoft.AspNetCore.Mvc.Localization.IViewLocalizer>, and [Data Annotations localization](xref:fundamentals/localization#dataannotations-localization) are ASP.NET Core MVC features and *not supported* in Blazor apps.

This article describes how to use Blazor's globalization and localization features based on:

* The [`Accept-Language` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Accept-Language), which is set by the browser based on a user's language preferences in browser settings.
* A culture set by the app not based on the value of the [`Accept-Language` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Accept-Language). The setting can be static for all users or dynamic based on app logic. When the setting is based on the user's preference, the setting is usually saved for reload on future visits.

For additional general information, see the following resources:

* <xref:fundamentals/localization>
* [.NET Fundamentals: Globalization](/dotnet/core/extensions/globalization)
* [.NET Fundamentals: Localization](/dotnet/core/extensions/localization)

Often, the terms *language* and *culture* are used interchangeably when dealing with globalization and localization concepts.

In this article, *language* refers to selections made by a user in their browser's settings. The user's language selections are submitted in browser requests in the [`Accept-Language` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Accept-Language). Browser settings usually use the word "language" in the UI.

*Culture* pertains to members of .NET and Blazor API. For example, a user's request can include the [`Accept-Language` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Accept-Language) specifying a *language* from the user's perspective, but the app ultimately sets the <xref:System.Globalization.CultureInfo.CurrentCulture> ("culture") property from the language that the user requested. API usually uses the word "culture" in its member names.

The guidance in this article doesn't cover setting the page's HTML language attribute ([`<html lang="...">`](https://developer.mozilla.org/docs/Web/HTML/Global_attributes/lang)), which accessiblity tools use. You can set the value statically by assigning a language to the `lang` attribute of the `<html>` tag or to `document.documentElement.lang` in JavaScript. You can dynamically set the value of `document.documentElement.lang` with [JS interop](xref:blazor/js-interop/index).

> [!NOTE]
> The code examples in this article adopt [nullable reference types (NRTs) and .NET compiler null-state static analysis](xref:migration/50-to-60#nullable-reference-types-nrts-and-net-compiler-null-state-static-analysis), which are supported in ASP.NET Core in .NET 6 or later. When targeting ASP.NET Core 5.0 or earlier, remove the null type designation (`?`) from the article's examples.

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

## .NET globalization and International Components for Unicode (ICU) support (Blazor WebAssembly)

:::moniker range=">= aspnetcore-8.0"

Blazor WebAssembly uses a reduced globalization API and set of built-in International Components for Unicode (ICU) locales. For more information, see [.NET globalization and ICU: ICU on WebAssembly](/dotnet/core/extensions/globalization-icu#icu-on-webassembly).

<!-- UPDATE 9.0 Tooling features for building custom ICU data file -->

To load a custom ICU data file to control the app's locales, see [WASM Globalization Icu](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-icu-wasm.md). Currently, manually building the custom ICU data file is required. .NET tooling to ease the process of creating the file is planned for .NET 9 in November, 2024.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Blazor WebAssembly uses a reduced globalization API and set of built-in International Components for Unicode (ICU) locales. For more information, see [.NET globalization and ICU: ICU on WebAssembly](/dotnet/core/extensions/globalization-icu#icu-on-webassembly).

Loading a custom subset of locales in a Blazor WebAssembly app is supported in .NET 8 or later. For more information, access this section for an 8.0 or later version of this article.

:::moniker-end

## Invariant globalization

*This section only applies to client-side Blazor scenarios.*

If the app doesn't require localization, configure the app to support the invariant culture, which is generally based on United States English (`en-US`). Using invariant globalization reduces the app's download size and results in faster app startup. Set the `InvariantGlobalization` property to `true` in the app's project file (`.csproj`):

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

:::moniker range=">= aspnetcore-8.0"

## Timezone information

*This section only applies to client-side Blazor scenarios.*

Adopting [invariant globalization](#invariant-globalization) only results in using non-localized timezone names. To trim timezone code and data, which reduces the app's download size and results in faster app startup, apply the `<InvariantTimezone>` MSBuild property with a value of `true` in the app's project file:

```xml
<PropertyGroup>
  <InvariantTimezone>true</InvariantTimezone>
</PropertyGroup>
```

> [!NOTE]
> [`<BlazorEnableTimeZoneSupport>`](xref:blazor/performance#disable-unused-features) overrides an earlier `<InvariantTimezone>` setting. We recommend removing the `<BlazorEnableTimeZoneSupport>` setting.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

A data file is included to make timezone information correct. If the app doesn't require this feature, consider disabling it by setting the `<BlazorEnableTimeZoneSupport>` MSBuild property to `false` in the app's project file:

```xml
<PropertyGroup>
  <BlazorEnableTimeZoneSupport>false</BlazorEnableTimeZoneSupport>
</PropertyGroup>
```

:::moniker-end

## Demonstration component

The following `CultureExample1` component can be used to demonstrate Blazor globalization and localization concepts covered by this article.

`CultureExample1.razor`:

```razor
@page "/culture-example-1"
@using System.Globalization

<h1>Culture Example 1</h1>

<ul>
    <li><b>CurrentCulture</b>: @CultureInfo.CurrentCulture</li>
    <li><b>CurrentUICulture</b>: @CultureInfo.CurrentUICulture</li>
</ul>

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

Optionally, add a menu item to the navigation in the `NavMenu` component (`NavMenu.razor`) for the `CultureExample1` component.

## Dynamically set the culture from the `Accept-Language` header

Add the [`Microsoft.Extensions.Localization`](https://www.nuget.org/packages/Microsoft.Extensions.Localization) package to the app.

The [`Accept-Language` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Accept-Language) is set by the browser and controlled by the user's language preferences in browser settings. In browser settings, a user sets one or more preferred languages in order of preference. The order of preference is used by the browser to set quality values (`q`, 0-1) for each language in the header. The following example specifies United States English, English, and Costa Rican Spanish with a preference for United States English or English:

**Accept-Language**: en-US,en;q=0.9,es-CR;q=0.8

The app's culture is set by matching the first requested language that matches a supported culture of the app.

:::moniker range=">= aspnetcore-5.0"

In ***client-side development***, set the `BlazorWebAssemblyLoadAllGlobalizationData` property to `true` in the client-side app's project file (`.csproj`):

```xml
<PropertyGroup>
  <BlazorWebAssemblyLoadAllGlobalizationData>true</BlazorWebAssemblyLoadAllGlobalizationData>
</PropertyGroup>
```

:::moniker-end

:::moniker range="< aspnetcore-5.0"

In ***client-side development***, dynamically setting the culture from the `Accept-Language` header isn't supported.

:::moniker-end

> [!NOTE]
> If the app's specification requires limiting the supported cultures to an explicit list, see the [Dynamically set the client-side culture by user preference](#dynamically-set-the-client-side-culture-by-user-preference) section of this article.

Apps are localized using [Localization Middleware](xref:fundamentals/localization#localization-middleware). Add localization services to the app with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A>.

Add the following line to the `Program` file where services are registered:

```csharp
builder.Services.AddLocalization();
```

In ***server-side development***, you can specify the app's supported cultures immediately after Routing Middleware is added to the processing pipeline. The following example configures supported cultures for United States English and Costa Rican Spanish:

```csharp
app.UseRequestLocalization(new RequestLocalizationOptions()
    .AddSupportedCultures(new[] { "en-US", "es-CR" })
    .AddSupportedUICultures(new[] { "en-US", "es-CR" }));
```

For information on ordering the Localization Middleware in the middleware pipeline of the `Program` file, see <xref:fundamentals/middleware/index#middleware-order>.

Use the `CultureExample1` component shown in the [Demonstration component](#demonstration-component) section to study how globalization works. Issue a request with United States English (`en-US`). Switch to Costa Rican Spanish (`es-CR`) in the browser's language settings. Request the webpage again.

> [!NOTE]
> Some browsers force you to use the default language setting for both requests and the browser's own UI settings. This can make changing the language back to one that you understand difficult because all of the setting UI screens might end up in a language that you can't read. A browser such as [Opera](https://www.opera.com/download) is a good choice for testing because it permits you to set a default language for webpage requests but leave the browser's settings UI in your language.

When the culture is United States English (`en-US`), the rendered component uses month/day date formatting (`6/7`), 12-hour time (`AM`/`PM`), and comma separators in numbers with a dot for the decimal value (`1,999.69`):

* **Date**: 6/7/2021 6:45:22 AM
* **Number**: 1,999.69

When the culture is Costa Rican Spanish (`es-CR`), the rendered component uses day/month date formatting (`7/6`), 24-hour time, and period separators in numbers with a comma for the decimal value (`1.999,69`):

* **Date**: 7/6/2021 6:49:38
* **Number**: 1.999,69

## Statically set the client-side culture

:::moniker range=">= aspnetcore-5.0"

Set the `BlazorWebAssemblyLoadAllGlobalizationData` property to `true` in the app's project file (`.csproj`):

```xml
<PropertyGroup>
  <BlazorWebAssemblyLoadAllGlobalizationData>true</BlazorWebAssemblyLoadAllGlobalizationData>
</PropertyGroup>
```

:::moniker-end

:::moniker range="< aspnetcore-5.0"

By default, the Intermediate Language (IL) Linker configuration for client-side rendering strips out internationalization information except for locales explicitly requested. For more information, see <xref:blazor/host-and-deploy/configure-linker#configure-the-linker-for-internationalization>.

:::moniker-end

The app's culture can be set in JavaScript when Blazor starts with the `applicationCulture` Blazor start option. The following example configures the app to launch using the United States English (`en-US`) culture.

Prevent Blazor autostart by adding `autostart="false"` to [Blazor's `<script>` tag](xref:blazor/project-structure#location-of-the-blazor-script):

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
```

In the preceding example, the `{BLAZOR SCRIPT}` placeholder is the Blazor script path and file name. For the location of the script, see <xref:blazor/project-structure#location-of-the-blazor-script>.

Add the following `<script>` block after [Blazor's `<script>` tag](xref:blazor/project-structure#location-of-the-blazor-script) and before the closing `</body>` tag:

:::moniker range=">= aspnetcore-8.0"

Blazor Web App:

```html
<script>
  Blazor.start({
    webAssembly: {
      applicationCulture: 'en-US'
    }
  });
</script>
```

Standalone Blazor WebAssembly:

:::moniker-end

```html
<script>
  Blazor.start({
    applicationCulture: 'en-US'
  });
</script>
```

The value for `applicationCulture` must conform to the [BCP-47 language tag format](https://www.rfc-editor.org/info/bcp47). For more information on Blazor startup, see <xref:blazor/fundamentals/startup>.

An alternative to setting the culture Blazor's start option is to set the culture in C# code. Set <xref:System.Globalization.CultureInfo.DefaultThreadCurrentCulture?displayProperty=nameWithType> and <xref:System.Globalization.CultureInfo.DefaultThreadCurrentUICulture?displayProperty=nameWithType> in the `Program` file to the same culture.

Add the <xref:System.Globalization?displayProperty=fullName> namespace to the `Program` file:

```csharp
using System.Globalization;
```

Add the culture settings before the line that builds and runs the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder> (`await builder.Build().RunAsync();`):

```csharp
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");
```

> [!NOTE]
> Currently, Blazor WebAssembly apps only load resources based on <xref:System.Globalization.CultureInfo.DefaultThreadCurrentCulture>. For more information, see [Blazor WASM only relies on the current culture (current UI culture isn't respected) (`dotnet/aspnetcore` #56824)](https://github.com/dotnet/aspnetcore/issues/56824).

Use the `CultureExample1` component shown in the [Demonstration component](#demonstration-component) section to study how globalization works. Issue a request with United States English (`en-US`). Switch to Costa Rican Spanish (`es-CR`) in the browser's language settings. Request the webpage again. When the requested language is Costa Rican Spanish, the app's culture remains United States English (`en-US`).

## Statically set the server-side culture

:::moniker range=">= aspnetcore-6.0"

Server-side apps are localized using [Localization Middleware](xref:fundamentals/localization#localization-middleware). Add localization services to the app with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A>.

In the `Program` file:

```csharp
builder.Services.AddLocalization();
```

Specify the static culture in the `Program` file immediately after Routing Middleware is added to the processing pipeline. The following example configures United States English:

```csharp
app.UseRequestLocalization("en-US");
```

The culture value for <xref:Microsoft.AspNetCore.Builder.ApplicationBuilderExtensions.UseRequestLocalization%2A> must conform to the [BCP-47 language tag format](https://www.rfc-editor.org/info/bcp47).

For information on ordering the Localization Middleware in the middleware pipeline of the `Program` file, see <xref:fundamentals/middleware/index#middleware-order>.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Server-side apps are localized using [Localization Middleware](xref:fundamentals/localization#localization-middleware). Add localization services to the app with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A>.

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

:::moniker-end

Use the `CultureExample1` component shown in the [Demonstration component](#demonstration-component) section to study how globalization works. Issue a request with United States English (`en-US`). Switch to Costa Rican Spanish (`es-CR`) in the browser's language settings. Request the webpage again. When the requested language is Costa Rican Spanish, the app's culture remains United States English (`en-US`).

## Dynamically set the client-side culture by user preference

Examples of locations where an app might store a user's preference include in [browser local storage](https://developer.mozilla.org/docs/Web/API/Window/localStorage) (common for client-side scenarios), in a localization cookie or database (common for server-side scenarios), or in an external service attached to an external database and accessed by a [web API](xref:blazor/call-web-api). The following example demonstrates how to use browser local storage.

Add the [`Microsoft.Extensions.Localization`](https://www.nuget.org/packages/Microsoft.Extensions.Localization) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

:::moniker range=">= aspnetcore-5.0"

Set the `BlazorWebAssemblyLoadAllGlobalizationData` property to `true` in the project file:

```xml
<PropertyGroup>
  <BlazorWebAssemblyLoadAllGlobalizationData>true</BlazorWebAssemblyLoadAllGlobalizationData>
</PropertyGroup>
```

:::moniker-end

The app's culture for client-side rendering is set using the Blazor framework's API. A user's culture selection can be persisted in browser local storage.

Provide JS functions after [Blazor's `<script>` tag](xref:blazor/project-structure#location-of-the-blazor-script) to get and set the user's culture selection with browser local storage:

```html
<script>
  window.blazorCulture = {
    get: () => window.localStorage['BlazorCulture'],
    set: (value) => window.localStorage['BlazorCulture'] = value
  };
</script>
```

:::moniker range=">= aspnetcore-5.0"

> [!NOTE]
> The preceding example pollutes the client with global functions. For a better approach in production apps, see [JavaScript isolation in JavaScript modules](xref:blazor/js-interop/call-javascript-from-dotnet#javascript-isolation-in-javascript-modules).

:::moniker-end

Add the namespaces for <xref:System.Globalization?displayProperty=fullName> and <xref:Microsoft.JSInterop?displayProperty=fullName> to the top of the `Program` file:

```csharp
using System.Globalization;
using Microsoft.JSInterop;
```

Remove the following line:

```diff
- await builder.Build().RunAsync();
```

Replace the preceding line with the following code. The code adds Blazor's localization service to the app's service collection with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A> and uses [JS interop](xref:blazor/js-interop/call-javascript-from-dotnet) to call into JS and retrieve the user's culture selection from local storage. If local storage doesn't contain a culture for the user, the code sets a default value of United States English (`en-US`).

```csharp
builder.Services.AddLocalization();

var host = builder.Build();

const string defaultCulture = "en-US";

var js = host.Services.GetRequiredService<IJSRuntime>();
var result = await js.InvokeAsync<string>("blazorCulture.get");
var culture = CultureInfo.GetCultureInfo(result ?? defaultCulture);

if (result == null)
{
    await js.InvokeVoidAsync("blazorCulture.set", defaultCulture);
}

CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

await host.RunAsync();
```

> [!NOTE]
> Currently, Blazor WebAssembly apps only load resources based on <xref:System.Globalization.CultureInfo.DefaultThreadCurrentCulture>. For more information, see [Blazor WASM only relies on the current culture (current UI culture isn't respected) (`dotnet/aspnetcore` #56824)](https://github.com/dotnet/aspnetcore/issues/56824).

The following `CultureSelector` component shows how to perform the following actions:

* Set the user's culture selection into browser local storage via JS interop.
* Reload the component that they requested (`forceLoad: true`), which uses the updated culture.

`CultureSelector.razor`:

:::moniker range=">= aspnetcore-7.0"

```razor
@using System.Globalization
@inject IJSRuntime JS
@inject NavigationManager Navigation

<p>
    <label>
        Select your locale:
        <select @bind="selectedCulture" @bind:after="ApplySelectedCultureAsync">
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
        new CultureInfo("es-CR"),
    };

    private CultureInfo? selectedCulture;

    protected override void OnInitialized()
    {
        selectedCulture = CultureInfo.CurrentCulture;
    }

    private async Task ApplySelectedCultureAsync()
    {
        if (CultureInfo.CurrentCulture != selectedCulture)
        {
            await JS.InvokeVoidAsync("blazorCulture.set", selectedCulture!.Name);

            Navigation.NavigateTo(Navigation.Uri, forceLoad: true);
        }
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-7.0"

```razor
@using System.Globalization
@inject IJSRuntime JS
@inject NavigationManager Navigation

<p>
    <label>
        Select your locale:
        <select value="@selectedCulture" @onchange="HandleSelectedCultureChanged">
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
        new CultureInfo("es-CR"),
    };

    private CultureInfo? selectedCulture;

    protected override void OnInitialized()
    {
        selectedCulture = CultureInfo.CurrentCulture;
    }

    private async Task HandleSelectedCultureChanged(ChangeEventArgs args)
    {
        selectedCulture = CultureInfo.GetCultureInfo((string)args.Value!);

        if (CultureInfo.CurrentCulture != selectedCulture)
        {
            await JS.InvokeVoidAsync("blazorCulture.set", selectedCulture!.Name);

            Navigation.NavigateTo(Navigation.Uri, forceLoad: true);
        }
    }
}
```

:::moniker-end

> [!NOTE]
> For more information on <xref:Microsoft.JSInterop.IJSInProcessRuntime>, see <xref:blazor/js-interop/call-javascript-from-dotnet#invoke-javascript-functions-without-reading-a-returned-value-invokevoidasync>.

Inside the closing tag of the `</main>` element in the `MainLayout` component (`MainLayout.razor`), add the `CultureSelector` component:

```razor
<article class="bottom-row px-4">
    <CultureSelector />
</article>
```

Use the `CultureExample1` component shown in the [Demonstration component](#demonstration-component) section to study how the preceding example works.

## Dynamically set the server-side culture by user preference

Examples of locations where an app might store a user's preference include in [browser local storage](https://developer.mozilla.org/docs/Web/API/Window/localStorage) (common for client-side scenarios), in a localization cookie or database (common for server-side scenarios), or in an external service attached to an external database and accessed by a [web API](xref:blazor/call-web-api). The following example demonstrates how to use a localization cookie.

:::moniker range=">= aspnetcore-8.0"

> [!NOTE]
> The following example assumes that the app adopts ***global*** interactivity by specifying the interactive server-side rendering (interactive SSR) on the `Routes` component in the `App` component (`Components/App.razor`):
>
> ```razor
> <Routes @rendermode="InteractiveServer" />
> ```
>
> If the app adopts ***per-page/component*** interactivity, see the remarks at the end of this section to modify the render modes of the example's components.

:::moniker-end

Add the [`Microsoft.Extensions.Localization`](https://www.nuget.org/packages/Microsoft.Extensions.Localization) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

Server-side apps are localized using [Localization Middleware](xref:fundamentals/localization#localization-middleware). Add localization services to the app with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A>.

In the `Program` file:

```csharp
builder.Services.AddLocalization();
```

Set the app's default and supported cultures with <xref:Microsoft.AspNetCore.Builder.RequestLocalizationOptions>.

:::moniker range=">= aspnetcore-8.0"

Before the call to `app.MapRazorComponents` in the request processing pipeline, place the following code:

:::moniker-end

:::moniker range="< aspnetcore-8.0"

After the call to `app.UseRouting` in the request processing pipeline, place the following code:

:::moniker-end

```csharp
var supportedCultures = new[] { "en-US", "es-CR" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);
```

For information on ordering the Localization Middleware in the middleware pipeline, see <xref:fundamentals/middleware/index#middleware-order>.

The following example shows how to set the current culture in a cookie that can be read by the Localization Middleware.

:::moniker range=">= aspnetcore-8.0"

The following namespaces are required for the `App` component:

* <xref:System.Globalization?displayProperty=fullName>
* <xref:Microsoft.AspNetCore.Localization?displayProperty=fullName>

Add the following to the top of the `App` component file (`Components/App.razor`):

```razor
@using System.Globalization
@using Microsoft.AspNetCore.Localization
```

Add the following `@code` block to the bottom of the `App` component file:

```razor
@code {
    [CascadingParameter]
    public HttpContext? HttpContext { get; set; }

    protected override void OnInitialized()
    {
        HttpContext?.Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(
                new RequestCulture(
                    CultureInfo.CurrentCulture,
                    CultureInfo.CurrentUICulture)));
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Modifications to the `Pages/_Host.cshtml` file require the following namespaces:

* <xref:System.Globalization?displayProperty=fullName>
* <xref:Microsoft.AspNetCore.Localization?displayProperty=fullName>

Add the following to the file:

```cshtml
@using System.Globalization
@using Microsoft.AspNetCore.Localization
@{
    this.HttpContext.Response.Cookies.Append(
        CookieRequestCultureProvider.DefaultCookieName,
        CookieRequestCultureProvider.MakeCookieValue(
            new RequestCulture(
                CultureInfo.CurrentCulture,
                CultureInfo.CurrentUICulture)));
}
```

:::moniker-end

For information on ordering the Localization Middleware in the middleware pipeline, see <xref:fundamentals/middleware/index#middleware-order>.

If the app isn't configured to process controller actions:

* Add MVC services by calling <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllers%2A> on the service collection in the `Program` file:

  ```csharp
  builder.Services.AddControllers();
  ```

* Add controller endpoint routing in the `Program` file by calling <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllers%2A> on the <xref:Microsoft.AspNetCore.Routing.IEndpointRouteBuilder> (`app`):

  ```csharp
  app.MapControllers();
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
> Use the <xref:Microsoft.AspNetCore.Mvc.ControllerBase.LocalRedirect%2A> action result, as shown in the preceding example, to prevent open redirect attacks. For more information, see <xref:security/preventing-open-redirects>.

The following `CultureSelector` component shows how to call the `Set` method of the `CultureController` with the new culture. The component is placed in the `Shared` folder for use throughout the app.

`CultureSelector.razor`:

:::moniker range=">= aspnetcore-7.0"

```razor
@using System.Globalization
@inject IJSRuntime JS
@inject NavigationManager Navigation

<p>
    <label>
        Select your locale:
        <select @bind="selectedCulture" @bind:after="ApplySelectedCultureAsync">
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
        new CultureInfo("es-CR"),
    };

    private CultureInfo? selectedCulture;

    protected override void OnInitialized()
    {
        selectedCulture = CultureInfo.CurrentCulture;
    }

    private async Task ApplySelectedCultureAsync()
    {
        if (CultureInfo.CurrentCulture != selectedCulture)
        {
            var uri = new Uri(Navigation.Uri)
                .GetComponents(UriComponents.PathAndQuery, UriFormat.Unescaped);
            var cultureEscaped = Uri.EscapeDataString(selectedCulture.Name);
            var uriEscaped = Uri.EscapeDataString(uri);
    
            Navigation.NavigateTo(
                $"Culture/Set?culture={cultureEscaped}&redirectUri={uriEscaped}",
                forceLoad: true);
        }
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-7.0"

```razor
@using System.Globalization
@inject IJSRuntime JS
@inject NavigationManager Navigation

<p>
    <label>
        Select your locale:
        <select value="@selectedCulture" @onchange="HandleSelectedCultureChanged">
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
        new CultureInfo("es-CR"),
    };

    private CultureInfo? selectedCulture;

    protected override void OnInitialized()
    {
        selectedCulture = CultureInfo.CurrentCulture;
    }

    private async Task HandleSelectedCultureChanged(ChangeEventArgs args)
    {
        selectedCulture = CultureInfo.GetCultureInfo((string)args.Value!);

        if (CultureInfo.CurrentCulture != selectedCulture)
        {
            var uri = new Uri(Navigation.Uri)
                .GetComponents(UriComponents.PathAndQuery, UriFormat.Unescaped);
            var cultureEscaped = Uri.EscapeDataString(selectedCulture.Name);
            var uriEscaped = Uri.EscapeDataString(uri);
    
            Navigation.NavigateTo(
                $"Culture/Set?culture={cultureEscaped}&redirectUri={uriEscaped}",
                forceLoad: true);
        }
    }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

Add the `CultureSelector` component to the `MainLayout` component. Place the following markup inside the closing `</main>` tag in the `Components/Layout/MainLayout.razor` file:

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Add the `CultureSelector` component to the `MainLayout` component. Place the following markup inside the closing `</main>` tag in the `Shared/MainLayout.razor` file:

:::moniker-end

```razor
<article class="bottom-row px-4">
    <CultureSelector />
</article>
```

Use the `CultureExample1` component shown in the [Demonstration component](#demonstration-component) section to study how the preceding example works.

:::moniker range=">= aspnetcore-8.0"

The preceding example assumes that the app adopts ***global*** interactivity by specifying the Interactive Server render mode on the `Routes` component in the `App` component (`Components/App.razor`):

```razor
<Routes @rendermode="InteractiveServer" />
```

If the app adopts ***per-page/component*** interactivity, make the following changes:

* Add the Interactive Server render mode to the top of the `CultureExample1` component file (`Components/Pages/CultureExample1.razor`):

  ```razor
  @rendermode InteractiveServer
  ```

* In the app's main layout (`Components/Layout/MainLayout.razor`), apply the Interactive Server render mode to the `CultureSelector` component:

  ```razor
  <CultureSelector @rendermode="InteractiveServer" />
  ```

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

## Dynamically set the culture in a Blazor Web App by user preference

*This section applies to Blazor Web Apps that adopt Auto (Server and WebAssembly) interactivity.*

Examples of locations where an app might store a user's preference include in [browser local storage](https://developer.mozilla.org/docs/Web/API/Window/localStorage) (common for client-side scenarios), in a localization cookie or database (common for server-side scenarios), both local storage and a localization cookie (Blazor Web Apps with server and WebAssembly components), or in an external service attached to an external database and accessed by a [web API](xref:blazor/call-web-api). The following example demonstrates how to use browser local storage for client-side rendered (CSR) components and a localization cookie for server-side rendered (SSR) components.

### Updates to the `.Client` project

Add the [`Microsoft.Extensions.Localization`](https://www.nuget.org/packages/Microsoft.Extensions.Localization) package to the `.Client` project.

[!INCLUDE[](~/includes/package-reference.md)]

Set the `BlazorWebAssemblyLoadAllGlobalizationData` property to `true` in the `.Client` project file:

```xml
<PropertyGroup>
  <BlazorWebAssemblyLoadAllGlobalizationData>true</BlazorWebAssemblyLoadAllGlobalizationData>
</PropertyGroup>
```

Add the namespaces for <xref:System.Globalization?displayProperty=fullName> and <xref:Microsoft.JSInterop?displayProperty=fullName> to the top of the `.Client` project's `Program` file:

```csharp
using System.Globalization;
using Microsoft.JSInterop;
```

Remove the following line:

```diff
- await builder.Build().RunAsync();
```

Replace the preceding line with the following code. The code adds Blazor's localization service to the app's service collection with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A> and uses [JS interop](xref:blazor/js-interop/call-javascript-from-dotnet) to call into JS and retrieve the user's culture selection from local storage. If local storage doesn't contain a culture for the user, the code sets a default value of United States English (`en-US`).

```csharp
builder.Services.AddLocalization();

var host = builder.Build();

const string defaultCulture = "en-US";

var js = host.Services.GetRequiredService<IJSRuntime>();
var result = await js.InvokeAsync<string>("blazorCulture.get");
var culture = CultureInfo.GetCultureInfo(result ?? defaultCulture);

if (result == null)
{
    await js.InvokeVoidAsync("blazorCulture.set", defaultCulture);
}

CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

await host.RunAsync();
```

> [!NOTE]
> Currently, Blazor WebAssembly apps only load resources based on <xref:System.Globalization.CultureInfo.DefaultThreadCurrentCulture>. For more information, see [Blazor WASM only relies on the current culture (current UI culture isn't respected) (`dotnet/aspnetcore` #56824)](https://github.com/dotnet/aspnetcore/issues/56824).

Add the following `CultureSelector` component to the `.Client` project.

The component adopts the following approaches to work for either SSR or CSR components:

* The display name of each available culture in the dropdown list is provided by a dictionary because client-side globalization data include localized text of culture display names that server-side globalization data provides. For example, server-side localization displays `English (United States)` when `en-US` is the culture and `Ingles ()` when a different culture is used. Because localization of the culture display names isn't available with Blazor WebAssembly globalization, the display name for United States English on the client for any loaded culture is just `en-US`. Using a custom dictionary permits the component to at least display full English culture names.
* When user changes the culture, JS interop sets the culture in local browser storage and a controller action updates the localization cookie with the culture. The controller is added to the app later in the [Server project updates](#server-project-updates) section.

`Pages/CultureSelector.razor`:

```razor
@using System.Globalization
@inject IJSRuntime JS
@inject NavigationManager Navigation

<p>
    <label>
        Select your locale:
        <select @bind="@selectedCulture" @bind:after="ApplySelectedCultureAsync">
            @foreach (var culture in supportedCultures)
            {
                <option value="@culture">@cultureDict[culture.Name]</option>
            }
        </select>
    </label>
</p>

@code
{
    private Dictionary<string, string> cultureDict = 
        new()
        {
            { "en-US", "English (United States)" },
            { "es-CR", "Spanish (Costa Rica)" }
        };

    private CultureInfo[] supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("es-CR"),
    };

    private CultureInfo? selectedCulture;

    protected override void OnInitialized()
    {
        selectedCulture = CultureInfo.CurrentCulture;
    }

    private async Task ApplySelectedCultureAsync()
    {
        if (CultureInfo.CurrentCulture != selectedCulture)
        {
            await JS.InvokeVoidAsync("blazorCulture.set", selectedCulture!.Name);

            var uri = new Uri(Navigation.Uri)
                .GetComponents(UriComponents.PathAndQuery, UriFormat.Unescaped);
            var cultureEscaped = Uri.EscapeDataString(selectedCulture.Name);
            var uriEscaped = Uri.EscapeDataString(uri);

            Navigation.NavigateTo(
                $"Culture/Set?culture={cultureEscaped}&redirectUri={uriEscaped}",
                forceLoad: true);
        }
    }
}
```

> [!NOTE]
> For more information on <xref:Microsoft.JSInterop.IJSInProcessRuntime>, see <xref:blazor/js-interop/call-javascript-from-dotnet#invoke-javascript-functions-without-reading-a-returned-value-invokevoidasync>.

In the `.Client` project, place the following `CultureClient` component to study how globalization works for CSR components.

`Pages/CultureClient.razor`:

```razor
@page "/culture-client"
@rendermode InteractiveWebAssembly
@using System.Globalization

<PageTitle>Culture Client</PageTitle>

<h1>Culture Client</h1>

<ul>
    <li><b>CurrentCulture</b>: @CultureInfo.CurrentCulture</li>
    <li><b>CurrentUICulture</b>: @CultureInfo.CurrentUICulture</li>
</ul>

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

### Server project updates

Add the [`Microsoft.Extensions.Localization`](https://www.nuget.org/packages/Microsoft.Extensions.Localization) package to the server project.

[!INCLUDE[](~/includes/package-reference.md)]

Server-side apps are localized using [Localization Middleware](xref:fundamentals/localization#localization-middleware). Add localization services to the app with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A>.

In the server project's `Program` file where services are registered:

```csharp
builder.Services.AddLocalization();
```

Set the app's default and supported cultures with <xref:Microsoft.AspNetCore.Builder.RequestLocalizationOptions>.

Before the call to `app.MapRazorComponents` in the request processing pipeline, place the following code:

```csharp
var supportedCultures = new[] { "en-US", "es-CR" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);
```

The following example shows how to set the current culture in a cookie that can be read by the Localization Middleware.

The following namespaces are required for the `App` component:

* <xref:System.Globalization?displayProperty=fullName>
* <xref:Microsoft.AspNetCore.Localization?displayProperty=fullName>

Add the following to the top of the `App` component file (`Components/App.razor`):

```razor
@using System.Globalization
@using Microsoft.AspNetCore.Localization
```

The app's culture for client-side rendering is set using the Blazor framework's API. A user's culture selection can be persisted in browser local storage for CSR components.

After the [Blazor's `<script>` tag](xref:blazor/project-structure#location-of-the-blazor-script), provide JS functions to get and set the user's culture selection with browser local storage:

```html
<script>
  window.blazorCulture = {
    get: () => window.localStorage['BlazorCulture'],
    set: (value) => window.localStorage['BlazorCulture'] = value
  };
</script>
```

> [!NOTE]
> The preceding example pollutes the client with global functions. For a better approach in production apps, see [JavaScript isolation in JavaScript modules](xref:blazor/js-interop/call-javascript-from-dotnet#javascript-isolation-in-javascript-modules).

Add the following `@code` block to the bottom of the `App` component file:

```razor
@code {
    [CascadingParameter]
    public HttpContext? HttpContext { get; set; }

    protected override void OnInitialized()
    {
        HttpContext?.Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(
                new RequestCulture(
                    CultureInfo.CurrentCulture,
                    CultureInfo.CurrentUICulture)));
    }
}
```

If the server project isn't configured to process controller actions:

* Add MVC services by calling <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllers%2A> on the service collection in the `Program` file:

  ```csharp
  builder.Services.AddControllers();
  ```

* Add controller endpoint routing in the `Program` file by calling <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllers%2A> on the <xref:Microsoft.AspNetCore.Routing.IEndpointRouteBuilder> (`app`):

  ```csharp
  app.MapControllers();
  ```

To allow a user to select a culture for SSR components, use a *redirect-based approach* with a localization cookie. The app persists the user's selected culture via a redirect to a controller. The controller sets the user's selected culture into a cookie and redirects the user back to the original URI. The process is similar to what happens in a web app when a user attempts to access a secure resource, where the user is redirected to a sign-in page and then redirected back to the original resource.

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
> Use the <xref:Microsoft.AspNetCore.Mvc.ControllerBase.LocalRedirect%2A> action result, as shown in the preceding example, to prevent open redirect attacks. For more information, see <xref:security/preventing-open-redirects>.

Add the `CultureSelector` component to the `MainLayout` component. Place the following markup inside the closing `</main>` tag in the `Components/Layout/MainLayout.razor` file:

```razor
<article class="bottom-row px-4">
    <CultureSelector @rendermode="InteractiveAuto" />
</article>
```

Use the `CultureExample1` component shown in the [Demonstration component](#demonstration-component) section to study how the preceding example works.

In the server project, place the following `CultureServer` component to study how globalization works for SSR components.

`Components/Pages/CultureServer.razor`:

```razor
@page "/culture-server"
@rendermode InteractiveServer
@using System.Globalization

<PageTitle>Culture Server</PageTitle>

<h1>Culture Server</h1>

<ul>
    <li><b>CurrentCulture</b>: @CultureInfo.CurrentCulture</li>
    <li><b>CurrentUICulture</b>: @CultureInfo.CurrentUICulture</li>
</ul>

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

Add both the `CultureClient` and `CultureServer` components to the sidebar navigation in `Components/Layout/NavMenu.razor`:

```razor
<div class="nav-item px-3">
    <NavLink class="nav-link" href="culture-server">
        <span class="bi bi-list-nested-nav-menu" aria-hidden="true"></span> Culture (Server)
    </NavLink>
</div>
<div class="nav-item px-3">
    <NavLink class="nav-link" href="culture-client">
        <span class="bi bi-list-nested-nav-menu" aria-hidden="true"></span> Culture (Client)
    </NavLink>
</div>
```

### Interactive Auto components

The guidance in this section also works for components that adopt the Interactive Auto render mode:

```razor
@rendermode InteractiveAuto
```

:::moniker-end

## Localization

If the app doesn't already support dynamic culture selection, add the [`Microsoft.Extensions.Localization`](https://www.nuget.org/packages/Microsoft.Extensions.Localization) package to the app.

[!INCLUDE[](~/includes/package-reference.md)]

### Client-side localization

:::moniker range=">= aspnetcore-5.0"

Set the `BlazorWebAssemblyLoadAllGlobalizationData` property to `true` in the app's project file (`.csproj`):

```xml
<PropertyGroup>
  <BlazorWebAssemblyLoadAllGlobalizationData>true</BlazorWebAssemblyLoadAllGlobalizationData>
</PropertyGroup>
```

:::moniker-end

In the `Program` file, add namespace the namespace for <xref:System.Globalization?displayProperty=fullName> to the top of the file:

```csharp
using System.Globalization;
```

Add Blazor's localization service to the app's service collection with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A>:

```csharp
builder.Services.AddLocalization();
```

### Server-side localization

Use [Localization Middleware](xref:fundamentals/localization#localization-middleware) to set the app's culture.

If the app doesn't already support dynamic culture selection:

:::moniker range=">= aspnetcore-6.0"

* Add localization services to the app with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A>.
* Specify the app's default and supported cultures in the `Program` file. The following example configures supported cultures for United States English and Costa Rican Spanish.

```csharp
builder.Services.AddLocalization();
```

Immediately after Routing Middleware is added to the processing pipeline:

```csharp
var supportedCultures = new[] { "en-US", "es-CR" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);
```

For information on ordering the Localization Middleware in the middleware pipeline, see <xref:fundamentals/middleware/index#middleware-order>.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

* Add localization services to the app with <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A>.
* Specify the app's default and supported cultures in `Startup.Configure` (`Startup.cs`). The following example configures supported cultures for United States English and Costa Rican Spanish.

In `Startup.ConfigureServices` (`Startup.cs`):

```csharp
services.AddLocalization();
```

In `Startup.Configure` immediately after Routing Middleware is added to the processing pipeline:

```csharp
var supportedCultures = new[] { "en-US", "es-CR" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);
```

For information on ordering the Localization Middleware in the middleware pipeline of `Startup.Configure`, see <xref:fundamentals/middleware/index#middleware-order>.

:::moniker-end

If the app should localize resources based on storing a user's culture setting, use a localization culture cookie. Use of a cookie ensures that the WebSocket connection can correctly propagate the culture. If localization schemes are based on the URL path or query string, the scheme might not be able to work with [WebSockets](xref:fundamentals/websockets), thus fail to persist the culture. Therefore, the recommended approach is to use a localization culture cookie. See the [Dynamically set the server-side culture by user preference](#dynamically-set-the-server-side-culture-by-user-preference) section of this article to see an example Razor expression that persists the user's culture selection.

### Example of localized resources

The example of localized resources in this section works with the prior examples in this article where the app's supported cultures are English (`en`) as a default locale and Spanish (`es`) as a user-selectable or browser-specified alternate locale.

Create a resource file for each locale. In the following example, resources are created for a `Greeting` string in English and Spanish:

* English (`en`): `Hello, World!`
* Spanish (`es`): `¡Hola, Mundo!`

> [!NOTE]
> The following resource file can be added in Visual Studio by right-clicking the `Pages` folder and selecting **Add** > **New Item** > **Resources File**. Name the file `CultureExample2.resx`. When the editor appears, provide data for a new entry. Set the **Name** to `Greeting` and **Value** to `Hello, World!`. Save the file.
>
> If using Visual Studio Code, we recommend installing [Tim Heuer's ResX Viewer and Editor](https://marketplace.visualstudio.com/items?itemName=TimHeuer.resx-editor). Add an empty `CultureExample2.resx` file to the `Pages` folder. The extension automatically takes over managing the file in the UI. Select the **Add New Resource** button. Follow the instructions to add an entry for `Greeting` (key), `Hello, World!` (value), and `None` (comment). Save the file. If you close and re-open the file, you can see the `Greeting` resource.
>
> [Tim Heuer's ResX Viewer and Editor](https://marketplace.visualstudio.com/items?itemName=TimHeuer.resx-editor) isn't owned or maintained by Microsoft and isn't covered by any Microsoft Support Agreement or license.

The following demonstrates a typical resource file. You can manually place resource files into the app's `Pages` folder if you prefer not to use built-in tooling with an integrated development environment (IDE), such as Visual Studio's built-in resource file editor or Visual Studio Code with an extension for creating and editing resource files.

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
> The following resource file can be added in Visual Studio by right-clicking the `Pages` folder and selecting **Add** > **New Item** > **Resources File**. Name the file `CultureExample2.es.resx`. When the editor appears, provide data for a new entry. Set the **Name** to `Greeting` and **Value** to `¡Hola, Mundo!`. Save the file.
>
> If using Visual Studio Code, we recommend installing [Tim Heuer's ResX Viewer and Editor](https://marketplace.visualstudio.com/items?itemName=TimHeuer.resx-editor). Add an empty `CultureExample2.resx` file to the `Pages` folder. The extension automatically takes over managing the file in the UI. Select the **Add New Resource** button. Follow the instructions to add an entry for `Greeting` (key), `¡Hola, Mundo!` (value), and `None` (comment). Save the file. If you close and re-open the file, you can see the `Greeting` resource.

The following demonstrates a typical resource file. You can manually place resource files into the app's `Pages` folder if you prefer not to use built-in tooling with an integrated development environment (IDE), such as Visual Studio's built-in resource file editor or Visual Studio Code with an extension for creating and editing resource files.

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

`CultureExample2.razor`:

```razor
@page "/culture-example-2"
@using System.Globalization
@inject IStringLocalizer<CultureExample2> Loc

<h1>Culture Example 2</h1>

<ul>
    <li><b>CurrentCulture</b>: @CultureInfo.CurrentCulture</li>
    <li><b>CurrentUICulture</b>: @CultureInfo.CurrentUICulture</li>
</ul>

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

Optionally, add a menu item for the `CultureExample2` component to the navigation in the `NavMenu` component (`NavMenu.razor`).

:::moniker range=">= aspnetcore-5.0"

## WebAssembly culture provider reference source

To further understand how the Blazor framework processes localization, see the [`WebAssemblyCultureProvider` class](https://github.com/dotnet/aspnetcore/blob/main/src/Components/WebAssembly/WebAssembly/src/Hosting/WebAssemblyCultureProvider.cs) in the ASP.NET Core reference source.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

:::moniker-end

## Shared resources

To create localization shared resources, adopt the following approach.

* Create a dummy class with an arbitrary class name. In the following example:

  * The app uses the `BlazorSample` namespace, and localization assets use the `BlazorSample.Localization` namespace.
  * The dummy class is named `SharedResource`.
  * The class file is placed in a `Localization` folder at the root of the app.

  `Localization/SharedResource.cs`:

  ```csharp
  namespace BlazorSample.Localization;
  
  public class SharedResource
  {
  }
  ```

* Create the shared resource files with a **Build Action** of `Embedded resource`. In the following example:

  * The files are placed in the `Localization` folder with the dummy `SharedResource` class (`Localization/SharedResource.cs`).
  * Name the resource files to match the name of the dummy class. The following example files include a default localization file and a file for Spanish (`es`) localization.

  * `Localization/SharedResource.resx`
  * `Localization/SharedResource.es.resx`

  > [!WARNING]
  > When following the approach in this section, you can't simultaneously set <xref:Microsoft.Extensions.Localization.LocalizationOptions.ResourcesPath%2A?displayProperty=nameWithType> and use <xref:Microsoft.Extensions.Localization.IStringLocalizerFactory.Create%2A?displayProperty=nameWithType> to load resources.

* To reference the dummy class for an injected <xref:Microsoft.Extensions.Localization.IStringLocalizer%601> in a Razor component, either place an [`@using`](xref:mvc/views/razor#using) directive for the localization namespace or include the localization namespace in the dummy class reference. In the following examples:

  * The first example states the `Localization` namespace for the `SharedResource` dummy class with an [`@using`](xref:mvc/views/razor#using) directive.
  * The second example states the `SharedResource` dummy class's namespace explicitly.

  In a Razor component, use ***either*** of the following approaches:

  ```razor
  @using Localization
  @inject IStringLocalizer<SharedResource> Loc
  ```

  ```razor
  @inject IStringLocalizer<Localization.SharedResource> Loc
  ```

For additional guidance, see <xref:fundamentals/localization>.

## Location override using "Sensors" pane in developer tools

When using the location override using the **Sensors** pane in Google Chrome or Microsoft Edge developer tools, the fallback language is reset after prerendering. Avoid setting the language using the **Sensors** pane when testing. Set the language using the browser's language settings.

For more information, see [Blazor Localization does not work with InteractiveServer (`dotnet/aspnetcore` #53707)](https://github.com/dotnet/aspnetcore/issues/53707).

## Additional resources

* [Set the app base path](xref:blazor/host-and-deploy/index#app-base-path)
* <xref:fundamentals/localization>
* [Globalizing and localizing .NET applications](/dotnet/core/extensions/globalization-and-localization)
* [Resources in .resx Files](/dotnet/framework/resources/working-with-resx-files-programmatically)
* [Microsoft Multilingual App Toolkit](https://marketplace.visualstudio.com/items?itemName=MultilingualAppToolkit.MultilingualAppToolkit-18308)
* [Localization & Generics](http://hishambinateya.com/localization-and-generics)
* [Calling `InvokeAsync(StateHasChanged)` causes page to fallback to default culture (dotnet/aspnetcore #28521)](https://github.com/dotnet/aspnetcore/issues/28521)
* [Blazor Localization does not work with InteractiveServer (`dotnet/aspnetcore` #53707)](https://github.com/dotnet/aspnetcore/issues/53707) ([Location override using "Sensors" pane](#location-override-using-sensors-pane-in-developer-tools))
