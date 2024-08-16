---
title: Enable QR code generation for TOTP authenticator apps in an ASP.NET Core Blazor Web App
author: guardrex
description: Discover how to enable QR code generation for TOTP authenticator apps that work with ASP.NET Core Blazor Web App two-factor authentication.
ms.author: riande
monikerRange: '>= aspnetcore-8.0'
ms.date: 04/01/2024
uid: blazor/security/server/qrcodes-for-authenticator-apps
---
# Enable QR code generation for TOTP authenticator apps in an ASP.NET Core Blazor Web App

This article explains how to configure an ASP.NET Core Blazor Web App with QR code generation for TOTP authenticator apps.

For an introduction to two-factor authentication (2FA) with authenticator apps using a Time-based One-time Password Algorithm (TOTP), see <xref:security/authentication/identity-enable-qrcodes>.

> [!WARNING]
> An ASP.NET Core TOTP code should be kept secret because it can be used to authenticate successfully multiple times before it expires.

## Scaffold the Enable Authenticator component into the app

Follow the guidance in <xref:security/authentication/scaffold-identity#scaffold-identity-into-a-blazor-project> to scaffold `Pages\Manage\EnableAuthenticator` into the app.

<!-- UPDATE 9.0 Update NOTE per followup on the issue -->

> [!NOTE]
> Although only the `EnableAuthenticator` component is selected for scaffolding in this example, scaffolding currently adds all of the Identity components to the app. Additionally, exceptions may be thrown during the process of scaffolding into the app. If exceptions occur when database migrations occur, stop the app and restart the app on each exception. For more information, see [Scaffolding exceptions for Blazor Web App (`dotnet/Scaffolding` #2694)](https://github.com/dotnet/Scaffolding/issues/2694).

Be patient while migrations are executed. Depending on the speed of the system, it can take up to a minute or two for database migrations to finish.

For more information, see <xref:security/authentication/scaffold-identity>. For guidance on using the .NET CLI instead of Visual Studio, see <xref:fundamentals/tools/dotnet-aspnet-codegenerator>.

## Adding QR codes to the 2FA configuration page

These instructions use [Shim Sangmin](https://hogangnono.com)'s [qrcode.js: Cross-browser QRCode generator for JavaScript](https://davidshimjs.github.io/qrcodejs/) ([`davidshimjs/qrcodejs` GitHub repository](https://github.com/davidshimjs/qrcodejs)).

Download the [`qrcode.min.js`](https://davidshimjs.github.io/qrcodejs/) library to the `wwwroot` folder of the solution's server project. The library has no dependencies.

In the `App` component (`Components/App.razor`), place a library script reference after [Blazor's `<script>` tag](xref:blazor/project-structure#location-of-the-blazor-script):

```razor
<script src="qrcode.min.js"></script>
```

The `EnableAuthenticator` component, which is part of the QR code system in the app and displays the QR code to users, adopts static server-side rendering (static SSR) with enhanced navigation. Therefore, normal scripts can't execute when the component loads or updates under enhanced navigation. Extra steps are required to trigger the QR code to load in the UI when the page is loaded. To accomplish loading the QR code, the approach explained in <xref:blazor/js-interop/ssr> is adopted.

Add the following [JavaScript initializer](xref:blazor/fundamentals/startup#javascript-initializers) to the server project's `wwwroot` folder. The `{NAME}` placeholder must be the name of the app's assembly in order for Blazor to locate and load the file automatically. If the server app's assembly name is `BlazorSample`, the file is named `BlazorSample.lib.module.js`.

`wwwroot/{NAME}.lib.module.js`:

[!INCLUDE[](~/blazor/includes/js-interop/blazor-page-script.md)]

Add the following shared `PageScript` component to the server app.

`Components/PageScript.razor`:

```razor
<page-script src="@Src"></page-script>

@code {
    [Parameter]
    [EditorRequired]
    public string Src { get; set; } = default!;
}
```

Add the following [collocated JS file](xref:blazor/js-interop/javascript-location#load-a-script-from-an-external-javascript-file-js-collocated-with-a-component) for the `EnableAuthenticator` component, which is located at `Components/Account/Pages/Manage/EnableAuthenticator.razor`. The `onLoad` function creates the QR code with Sangmin's `qrcode.js` library using the QR code URI produced by the `GenerateQrCodeUri` method in the component's `@code` block.

`Components/Account/Pages/Manage/EnableAuthenticator.razor.js`:

```javascript
export function onLoad() {
  const uri = document.getElementById('qrCodeData').getAttribute('data-url');
  new QRCode(document.getElementById('qrCode'), uri);
}
```

Under the `<PageTitle>` component in the `EnableAuthenticator` component, add the `PageScript` component with the path to the collocated JS file:

```razor
<PageScript Src="./Components/Account/Pages/Manage/EnableAuthenticator.razor.js" />
```

> [!NOTE]
> An alternative to using the approach with the `PageScript` component is to use an event listener (`blazor.addEventListener("enhancedload", {CALLBACK})`) registered in an [`afterWebStarted` JS initializer](xref:blazor/fundamentals/startup#javascript-initializers) to listen for page updates caused by enhanced navigation. The callback (`{CALLBACK}` placeholder) performs the QR code initialization logic.
>
> Using the callback approach with `enhancedload`, the code executes for every enhanced navigation, even when the QR code `<div>` isn't rendered. Therefore, additional code must be added to check for the presence of the `<div>` before executing the code that adds a QR code.


Delete the `<div>` element that contains the QR code instructions:

```diff
- <div class="alert alert-info">
-     Learn how to <a href="https://go.microsoft.com/fwlink/?Linkid=852423">enable 
-     QR code generation</a>.
- </div>
```

Locate the two `<div>` elements where the QR code should appear and where the QR code data is stored in the page.

Make the following changes:

* For the empty `<div>`, give the element an `id` of `qrCode`.
* For the `<div>` with the `data-url` attribute, give the element an `id` of `qrCodeData`.

```diff
- <div></div>
- <div data-url="@authenticatorUri"></div>
+ <div id="qrCode"></div>
+ <div id="qrCodeData" data-url="@authenticatorUri"></div>
```

Change the site name in the `GenerateQrCodeUri` method of the `EnableAuthenticator` component. The default value is `Microsoft.AspNetCore.Identity.UI`. Change the value to a meaningful site name that users can identify easily in their authenticator app alongside other QR codes for other apps. Leave the value URL encoded. Developers usually set a site name that matches the company's name. Examples: Yahoo, Amazon, Etsy, Microsoft, Zoho.

In the following example, the `{SITE NAME}` placeholder is where the site (company) name:

```diff
private string GenerateQrCodeUri(string email, string unformattedKey)
{
    return string.Format(
        CultureInfo.InvariantCulture,
        AuthenticatorUriFormat,
-       UrlEncoder.Encode("Microsoft.AspNetCore.Identity.UI"),
+       UrlEncoder.Encode("{SITE NAME}"),
        UrlEncoder.Encode(email),
        unformattedKey);
}
```

Run the app and ensure that the QR code is scannable and that the code validates.

> [!WARNING]
> An ASP.NET Core TOTP code should be kept secret because it can be used to authenticate successfully multiple times before it expires.

## `EnableAuthenticator` component in reference source

The `EnableAuthenticator` component can be inspected in reference source:

[`EnableAuthenticator` component in reference source](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWeb-CSharp/Components/Account/Pages/Manage/EnableAuthenticator.razor)

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

## Additional resources

* [Using a different QR code library](xref:security/authentication/identity-enable-qrcodes#using-a-different-qr-code-library)
* [TOTP client and server time skew](xref:security/authentication/identity-enable-qrcodes#totp-client-and-server-time-skew)
