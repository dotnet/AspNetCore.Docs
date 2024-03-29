---
title: Enable QR code generation for TOTP authenticator apps in an ASP.NET Core Blazor Web App
author: guardrex
description: Discover how to enable QR code generation for TOTP authenticator apps that work with ASP.NET Core Blazor Web App two-factor authentication.
ms.author: riande
monikerRange: '>= aspnetcore-8.0'
ms.date: 03/29/2024
uid: blazor/security/server/qrcodes-for-authenticator-apps
---
# Enable QR code generation for TOTP authenticator apps in an ASP.NET Core Blazor Web App

This article explains how to configure an ASP.NET Core Blazor Web App with QR code generation for TOTP authenticator apps.

For an introduction to two-factor authentication (2FA) with authenticator apps using a Time-based One-time Password Algorithm (TOTP), see <xref:security/authentication/identity-enable-qrcodes>.

## Scaffold the Enable Authenticator component into the app

If you haven't already scaffolded the `EnableAuthenticator` component into the app, use the following steps in Visual Studio to surface the component in the app:

1. In **Solution Explorer**, right-click **Add** > **New Scaffolded Item**.
1. Select **Identity** > **Blazor Identity**. Select the **Add** button.
1. On the **Add Blazor Identity** step, override the file for **Pages\Manage\EnableAuthenticator** in the list of pages. Select the app's DBContext class. Select the **Add** button.

Be patient while migrations are executed. Depending on the speed of the system, it can take up to a minute or two for database migrations to finish.

For more information, see <xref:security/authentication/scaffold-identity>. For guidance on using the .NET CLI instead of Visual Studio, see <xref:fundamentals/tools/dotnet-aspnet-codegenerator>.

## Adding QR codes to the 2FA configuration page

These instructions use [Shim Sangmin](https://hogangnono.com)'s [qrcode.js: Cross-browser QRCode generator for JavaScript](https://davidshimjs.github.io/qrcodejs/) ([`davidshimjs/qrcodejs` GitHub repository](https://github.com/davidshimjs/qrcodejs)).

Download the [`qrcode.min.js`](https://davidshimjs.github.io/qrcodejs/) library to the `wwwroot` folder in your project. The JavaScript library has no dependencies.

In the `App` component (`Components/App.razor`), place a script reference after [Blazor's `<script>` tag](xref:blazor/project-structure#location-of-the-blazor-script):

```razor
<script src="qrcode.min.js"></script>
```

Immediately after the added `<script>` file reference for `qrcode.min.js`, add the following JavaScript function. The following code generates a QR code at the position of the `qrCodeData` element:

```razor
<script>
  window.createCode = (uri) => 
  {
    var qrcode = document.getElementById('qrCode');
    qrcode.innerHTML = '';
    new QRCode(qrcode, uri);
  }
</script>
```

> [!NOTE]
> For general guidance on JS location and our recommendations for production apps, see <xref:blazor/js-interop/index#javascript-location>.

In the `EnableAuthenticator` component (`Components/Account/Pages/Manage/EnableAuthenticator.razor`), delete the `<div>` element that contains the QR code instructions:

```diff
- <div class="alert alert-info">
-     Learn how to <a href="https://go.microsoft.com/fwlink/?Linkid=852423">enable 
-     QR code generation</a>.
- </div>
```

Locate the instructions to the user on scanning a QR code or providing the shared key and replace it with the following instruction:

```razor
<button class="btn btn-link p-0 border-0" onclick="createCode('@authenticatorUri')">
    Load and scan a QR code
</button>
with your authenticator app or enter this key <kbd>@sharedKey</kbd> into your two 
factor authenticator app. Spaces are optional, and the value is case insensitive.
```

Locate the two `<div>` elements where the QR code should appear and where the QR code data is stored in the page and make the following changes:

* For the empty `<div>`, give the element an `id` of `qrCode`.
* For the `<div>` with the `data-url` attribute, give the element an `id` of `qrCodeData`.

```diff
- <div></div>
- <div data-url="@authenticatorUri"></div>
+ <div id="qrcode"></div>
+ <div id="qrCodeData" data-url="@authenticatorUri"></div>
```

Run the app and ensure that you can scan the QR code and validate the code the authenticator proves.

## Change the site name in the QR code

Change the site name in the `GenerateQrCodeUri` method of the `EnableAuthenticator` component.

The default value is `Microsoft.AspNetCore.Identity.UI`. Change the value to a meaningful site name that users can identify easily in their authenticator app alongside other QR codes for other apps. Leave the value URL encoded. Developers usually set a site name that matches the company's name. Examples: Yahoo, Amazon, Etsy, Microsoft, Zoho.

In the following example, the `{SITE NAME}` placeholder is where the site name is provided:

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

## `EnableAuthenticator` component in reference source

The `EnableAuthenticator` component can be inspected in reference source:

[`EnableAuthenticator` component in reference source](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/BlazorWeb-CSharp/BlazorWeb-CSharp/Components/Account/Pages/Manage/EnableAuthenticator.razor)

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

## Additional resources

* [Using a different QR code library](xref:security/authentication/identity-enable-qrcodes#using-a-different-qr-code-library)
* [TOTP client and server time skew](xref:security/authentication/identity-enable-qrcodes#totp-client-and-server-time-skew)
