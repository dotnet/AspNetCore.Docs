---
title: ASP.NET Core Blazor globalization and localization
author: guardrex
description: Learn how to make Razor components accessible to users in multiple cultures and languages.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 06/10/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/globalization-localization
zone_pivot_groups: blazor-hosting-models
---
# ASP.NET Core Blazor globalization and localization

Razor components can be made accessible to users in multiple cultures and languages. The following .NET globalization and localization scenarios are available:

* .NET's resources system
* Culture-specific number and date formatting

A limited set of ASP.NET Core's localization scenarios are currently supported:

* <xref:Microsoft.Extensions.Localization.IStringLocalizer> and <xref:Microsoft.Extensions.Localization.IStringLocalizer%601> *are supported* in Blazor apps.
* <xref:Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer>, <xref:Microsoft.AspNetCore.Mvc.Localization.IViewLocalizer>, and Data Annotations localization are ASP.NET Core MVC scenarios and **not supported** in Blazor apps.

For more information, see <xref:fundamentals/localization>.

## Globalization

The [`@bind`](xref:mvc/views/razor#bind) attribute directive applies formats and parses values for display based on the user's first [preferred language)](https://developer.mozilla.org/docs/Web/API/NavigatorLanguage/languages).

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

The following component demonstrates Blazor's default globalization. The number string format `N0` 

`Pages/CultureExample1.razor`:

```razor
@page "/culture-example-1"
@using System.Globalization

<h1>Culture Example 1</h1>

<p>
    <b>CurrentCulture</b>: @CultureInfo.CurrentCulture
    <b>CurrentUICulture</b>: @CultureInfo.CurrentUICulture
</p>

<p>
    <b>Date</b>: @DateTime.Now
</p>

<p>
    <b>number</b>: @number.ToString("N0")
</p>

@code {
    private int number = 1999;
}
```

For more information on the `N0` numeric format, see [Standard numeric format strings: Numeric format specifier (N)](/dotnet/standard/base-types/standard-numeric-format-strings#numeric-format-specifier-n).

When the browser's culture is British English (`en-GB`), the rendered component uses month/day date formatting (`6/7`), 12-hour time (`AM`/`PM`), and comma separators in numbers (`1,999`):

> **CurrentCulture**: en-GB **CurrentUICulture**: en-GB
>
> **Date**: 6/7/2021 6:45:22 AM
>
> **number**: 1,999

When the browser's culture is Peruvian Spanish (`es-PE`), the rendered component uses day/month date formatting (`7/6`), 24-hour time, and period separators in numbers (`1.999`):

> **CurrentCulture**: es-PE **CurrentUICulture**: es-PE
>
> **Date**: 7/6/2021 6:49:38
>
> **number**: 1.999

## Statically set the application culture

::: zone pivot="webassembly"

::: moniker range=">= aspnetcore-5.0"

Blazor WebAssembly can be configured to launch using a specific application culture using options passed to `Blazor.start`. For instance, the sample below shows an app configured to launch using the `en-GB` culture:

```html
<script src="_framework/blazor.webassembly.js" autostart="false"></script>
<script>
  Blazor.start({
    applicationCulture: 'en-GB'
  });
</script>
```

For more information on Blazor startup, see <xref:blazor/fundamentals/startup>.

The value for `applicationCulture` must conform to the [BCP-47 language tag format](https://www.rfc-editor.org/info/bcp47).

The app's culture can also be set in C# code with the following approach.

Set the `BlazorWebAssemblyLoadAllGlobalizationData` property to `true` in the project file (`.csproj`):

```xml
<PropertyGroup>
  <BlazorWebAssemblyLoadAllGlobalizationData>true</BlazorWebAssemblyLoadAllGlobalizationData>
</PropertyGroup>
```

To explicitly configure the culture, set <xref:System.Globalization.CultureInfo.DefaultThreadCurrentCulture?displayProperty=nameWithType> and <xref:System.Globalization.CultureInfo.DefaultThreadCurrentUICulture?displayProperty=nameWithType> in `Program.Main` (`Program.cs`):

```csharp
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-GB");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-GB");
```

If the app doesn't require localization, you may configure the app to support the invariant culture, which is based on the `en-GB` culture. Set the `InvariantGlobalization` property to `true` in the project file:

```xml
<PropertyGroup>
  <InvariantGlobalization>true</InvariantGlobalization>
</PropertyGroup>
```

::: moniker-end

::: moniker range="< aspnetcore-5.0"

By default, the Intermediate Language (IL) Linker configuration for Blazor WebAssembly apps strips out internationalization information except for locales explicitly requested. For more information, see <xref:blazor/host-and-deploy/configure-linker#configure-the-linker-for-internationalization>.

::: moniker-end

::: zone-end

::: zone pivot="server"

Use [Localization Middleware](xref:fundamentals/localization#localization-middleware) to set the app's culture with a localization culture cookie. The Localization Middleware reads the cookie on subsequent requests to set the user's culture.

Use of a cookie ensures that the WebSocket connection can correctly propagate the culture. If localization schemes are based on the URL path or query string, the scheme might not be able to work with WebSockets, thus fail to persist the culture. Therefore, use of a localization culture cookie is the recommended approach.

Specify the app's supported cultures in `Startup.Configure` (`Startup.cs`). The following examples configures supported cultures for British English and Peruvian Spanish:

```csharp
app.UseRequestLocalization(new RequestLocalizationOptions()
    .AddSupportedCultures(new[] { "en-GB", "es-PE" })
    .AddSupportedUICultures(new[] { "en-GB", "es-PE" }));
```

The values for <xref:Microsoft.AspNetCore.Builder.RequestLocalizationOptions.AddSupportedCultures%2A> and <xref:Microsoft.AspNetCore.Builder.RequestLocalizationOptions.AddSupportedUICultures%2A> must conform to the [BCP-47 language tag format](https://www.rfc-editor.org/info/bcp47).

The following example shows how to set the app's culture to one of the supported cultures, in this case British English (`en-GB`), in a cookie that can be read by Localization Middleware. Create a Razor expression in the `Pages/_Host.cshtml` file immediately inside the opening `<body>` tag. The app's culture is explicitly set in ASP.NET Core's culture cookie (name: `.AspNetCore.Culture`) for <xref:System.Globalization.CultureInfo.CurrentUICulture> and <xref:System.Globalization.CultureInfo.CurrentUICulture>.

Add the following namespaces at the top of the `Pages/_Host.cshtml` file:

```csharp
@using System.Globalization
@using Microsoft.AspNetCore.Localization
```

Inside the opening `<body>` tag of `Pages/_Host.cshtml`:

```cshtml
@{
    this.HttpContext.Response.Cookies.Append(
        CookieRequestCultureProvider.DefaultCookieName,
        CookieRequestCultureProvider.MakeCookieValue(
            new RequestCulture(
                new CultureInfo("en-GB"),
                new CultureInfo("en-GB"))));
}
```

An alternative to using the `Pages/_Host.cshtml` file to set the app's culture is to set the culture with <xref:Microsoft.AspNetCore.Builder.RequestLocalizationOptions.SetDefaultCulture%2A?displayProperty=nameWithType>.

In `Startup.Configure` (`Startup.cs`):

```csharp
app.UseRequestLocalization(
    new RequestLocalizationOptions()
        .SetDefaultCulture("en-GB")
        .AddSupportedCultures(new[] { "en-GB" })
        .AddSupportedUICultures(new[] { "en-GB" }));
```

For information on ordering the Localization Middleware in the middleware pipeline of `Startup.Configure`, see <xref:fundamentals/middleware/index#middleware-order>.

To support multiple cultures with a default culture, create an array of the supported cultures and call <xref:Microsoft.AspNetCore.Builder.RequestLocalizationOptions.SetDefaultCulture%2A?displayProperty=nameWithType> with the default culture.

In `Startup.Configure` (`Startup.cs`):

```csharp
var supportedCultures = new[] { "en-GB", "es-PE" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);
```

::: zone-end

While the culture that Blazor selects by default might be sufficient for most users, consider offering a way for users to specify their preferred culture. For more information, see the [Localization](#localization) section.

## Dynamically set the application culture

Add a package reference for the [`Microsoft.Extensions.Localization`](https://www.nuget.org/packages/Microsoft.Extensions.Localization) package to the app's project file (`.csproj`):

```xml
<PackageReference Include="Microsoft.Extensions.Localization" Version="{VERSION}" />
```

The `{VERSION}` placeholder in the preceding package reference is the version of the package.

::: zone pivot="webassembly"

Set the `BlazorWebAssemblyLoadAllGlobalizationData` property to `true` in the project file:

```xml
<PropertyGroup>
  <BlazorWebAssemblyLoadAllGlobalizationData>true</BlazorWebAssemblyLoadAllGlobalizationData>
</PropertyGroup>
```

The app's culture in a Blazor WebAssembly app is set using the Blazor framework's API. A user's culture selection can be persisted in their browser's local storage.

Inside the closing `</body>` tag of `wwwroot/index.html`, provide JS functions to get and set the user's culture selection with the browser's local storage:

```html
<body>
    ...

    <script src="_framework/blazor.webassembly.js"></script>
    <script>
        window.blazorCulture = {
            get: () => window.localStorage['BlazorCulture'],
            set: (value) => window.localStorage['BlazorCulture'] = value
        };
    </script>
</body>
```

::: moniker range=">= aspnetcore-5.0"

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
> If you use the preceding functions, change the JS interop calls in this section from `BlazorCulture.get` to `getBlazorCulture` and from `BlazorCulture.set` to `setBlazorCulture`.

::: moniker-end

In `Program.Main` (`Program.cs`):

* Add namespaces for <xref:System.Globalization?displayProperty=fullName> and <xref:Microsoft.JSInterop?displayProperty=fullName>.
* Add Blazor's localization service to the app's service collection with `AddLocalization`.
* Use [JS interop](xref:blazor/js-interop/call-javascript-from-dotnet) to call into JS and retrieve the user's culture selection from local storage. If local storage doesn't contain a culture for the user, set a default value.

```csharp
...
using System.Globalization;
using Microsoft.JSInterop;

public class Program
{
    public static async Task Main(string[] args)
    {
        ...

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
            culture = new CultureInfo("en-GB");
            await js.InvokeVoidAsync("blazorCulture.set", "en-GB");
        }

        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;

        await host.RunAsync();
    }
}
```

Create a culture selector component that can be shared throughout the app.

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
        new CultureInfo("en-GB"),
        new CultureInfo("es-PE"),
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

Add a component to demonstrate user culture selection.

`Pages/CultureExample1.razor`:

```razor
@page "/culture-example-1"
@using System.Globalization

<h1>Culture Example 1</h1>

<p>
    <b>CurrentCulture</b>: @CultureInfo.CurrentCulture
    <b>CurrentUICulture</b>: @CultureInfo.CurrentUICulture
</p>

<p>
    <b>Date</b>: @DateTime.Now
</p>

<p>
    <b>number</b>: @number.ToString("N0")
</p>

@code {
    private int number = 1999;
}
```

Add a list item to the navigation menu `<ul>` element in `Shared/NavMenu.razor` for the `CultureExample1` component:

```razor
<li class="nav-item px-3">
    <NavLink class="nav-link" href="culture-example-1">
        <span class="oi oi-list-rich" aria-hidden="true"></span> Example 1
    </NavLink>
</li>
```

::: zone-end

::: zone pivot="server"

Blazor Server apps are localized using [Localization Middleware](xref:fundamentals/localization#localization-middleware).

Add localization services to the app.

In `Startup.ConfigureServices` (`Startup.cs`):

```csharp
services.AddLocalization();
```

Set the app's default and supported cultures with <xref:Microsoft.AspNetCore.Builder.RequestLocalizationOptions.SetDefaultCulture%2A?displayProperty=nameWithType>.

In `Startup.Configure`:

```csharp
var supportedCultures = new[] { "en-GB", "es-PE" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);
```

For information on ordering the Localization Middleware in the middleware pipeline of `Startup.Configure`, see <xref:fundamentals/middleware/index#middleware-order>.

If the app isn't configured to process controller actions:

* Add MVC services by calling <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllers%2A> on the service collection in `Startup.ConfigureServices`:

  ```csharp
  services.AddControllers();
  ```

* Add controller endpoint routing in `Startup.Configure` by calling <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllers%2A> on the <xref:Microsoft.AspNetCore.Routing.IEndpointRouteBuilder>:

  ```csharp
  app.UseEndpoints(endpoints =>
  {
      endpoints.MapControllers();
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

The following component shows an example of how to perform the initial redirection when the user selects a culture.

Create a culture selector component that can be shared throughout the app.

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
        new CultureInfo("en-GB"),
        new CultureInfo("es-PE"),
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

Add a component to demonstrate user culture selection.

`Pages/CultureExample1.razor`:

```razor
@page "/culture-example-1"
@using System.Globalization

<h1>Culture Example 1</h1>

<p>
    <b>CurrentCulture</b>: @CultureInfo.CurrentCulture
    <b>CurrentUICulture</b>: @CultureInfo.CurrentUICulture
</p>

<p>
    <b>Date</b>: @DateTime.Now
</p>

<p>
    <b>number</b>: @number.ToString("N0")
</p>

@code {
    private int number = 1999;
}
```

Add a list item to the navigation menu `<ul>` element in `Shared/NavMenu.razor` for the `CultureExample1` component:

```razor
<li class="nav-item px-3">
    <NavLink class="nav-link" href="culture-example-1">
        <span class="oi oi-list-rich" aria-hidden="true"></span> Example 1
    </NavLink>
</li>
```

::: zone-end

## Localization

Adopt an approach for the app to set a culture, including the addition of localization services. Follow the guidance in one of the following sections:

* [Statically set the application culture](#statically-set-the-application-culture)
* [Dynamically set the application culture](#dynamically-set-the-application-culture)

The example of localized resources in this section works with the prior examples in this article where the app's supported cultures are English (`en`) as a default locale and Spanish (`es`) as a user-selectable or browser-specified alternate locale.

Create resources for each locale. In the following example, resources are created for a default `Greeting` string of `Hello, World!` and a `Greeting` string in and Spanish (`es`), `¡Hola, Mundo!`.

> [!NOTE]
> The following resource files (`.resx`) can be added in Visual Studio by right-clicking the project's `Pages` folder and selecting **Add** > **New Item** > **Resources File**.

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

The following component demonstrates the use of the localized `Greeting` string with <xref:Microsoft.Extensions.Localization.IStringLocalizer%601>.

Add the namespace for <xref:Microsoft.Extensions.Localization?displayProperty=fullName> to the app's `_Imports.razor` file:

```razor
@using Microsoft.Extensions.Localization
```

`Pages/CultureExample2.razor`:

```razor
@page "/culture-example-2"
@inject IStringLocalizer<CultureExample2> Loc

<h1>Culture Example 2</h1>

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

## Additional resources

* [Set the app base path](xref:blazor/host-and-deploy/index#app-base-path)
* <xref:fundamentals/localization>
