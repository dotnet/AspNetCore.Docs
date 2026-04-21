---
title: Enable QR code generation for TOTP authenticator apps in ASP.NET Core
ai-usage: ai-assisted
author: wadepickett
description: Discover how to enable QR code generation for TOTP authenticator apps that work with ASP.NET Core two-factor authentication.
monikerRange: '>= aspnetcore-2.1'
ms.author: wpickett
ms.date: 04/21/2026
ms.reviewer: wpickett
uid: security/authentication/identity-enable-qrcodes
---

# Enable QR code generation for TOTP authenticator apps in ASP.NET Core

ASP.NET Core includes support for authenticator applications for individual authentication:

- Two-factor authentication (2FA) authenticator apps use a Time-based One-time Password Algorithm (TOTP), the industry-recommended approach for 2FA.
- TOTP-based 2FA is preferred over SMS 2FA.
- An authenticator app provides a 6 to 8 digit code that users enter after confirming their username and password.
- Typically, users install an authenticator app on a smartphone.

> [!WARNING]
> Keep an ASP.NET Core TOTP code secret because it can be used to authenticate successfully multiple times before it expires.

:::moniker range=">= aspnetcore-8.0"

The ASP.NET Core web app templates support authenticators but don't provide support for QR code generation. QR code generators make it easier to set up 2FA. This article provides guidance for Razor Pages and MVC apps on how to add [QR code](https://wikipedia.org/wiki/QR_code) generation to the 2FA configuration page. For guidance that applies to Blazor Web Apps, see <xref:blazor/security/qrcodes-for-authenticator-apps>. For guidance that applies to Blazor WebAssembly apps, see <xref:blazor/security/webassembly/standalone-with-identity/qrcodes-for-authenticator-apps>.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

The ASP.NET Core web app templates support authenticators but don't provide support for QR code generation. QR code generators make it easier to set up 2FA. This article guides you through adding [QR code](https://wikipedia.org/wiki/QR_code) generation to the 2FA configuration page.

> [!NOTE]
> For ASP.NET Core 8.0 or later, Blazor-specific guidance for QR code generation is available for <xref:blazor/security/qrcodes-for-authenticator-apps> (Blazor Web App) and <xref:blazor/security/webassembly/standalone-with-identity/qrcodes-for-authenticator-apps> (Blazor WebAssembly with Identity).

:::moniker-end

Two-factor authentication doesn't happen by using an external authentication provider, such as [Google](xref:security/authentication/google-logins) or [Facebook](xref:security/authentication/facebook-logins). External logins are protected by whatever mechanism the external login provider provides. For example, the [Microsoft](xref:security/authentication/microsoft-logins) authentication provider requires a hardware key or another 2FA approach. If the default templates required 2FA for both the web app and the external authentication provider, users would need to satisfy two 2FA approaches. Requiring two 2FA approaches deviates from established security practices, which typically rely on a single, strong 2FA method for authentication.

## Adding QR codes to the 2FA configuration page

These instructions use `qrcode.js` from the [https://davidshimjs.github.io/qrcodejs/](https://davidshimjs.github.io/qrcodejs/) repo.

* Download the [`qrcode.js` JavaScript library](https://davidshimjs.github.io/qrcodejs/) to the `wwwroot\lib` folder in your project.
* Follow the instructions in [Scaffold Identity](xref:security/authentication/scaffold-identity) to generate `/Areas/Identity/Pages/Account/Manage/EnableAuthenticator.cshtml`.
* In `/Areas/Identity/Pages/Account/Manage/EnableAuthenticator.cshtml`, locate the `Scripts` section at the end of the file:

```cshtml
@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
```
* Create a new JavaScript file called `qr.js` in `wwwroot/js` and add the following code to generate the QR code:

```javascript
window.addEventListener("load", () => {
  const uri = document.getElementById("qrCodeData").getAttribute('data-url');
  new QRCode(document.getElementById("qrCode"),
    {
      text: uri,
      width: 150,
      height: 150
    });
});
```

* Update the `Scripts` section to add a reference to the `qrcode.js` library you previously downloaded.
* Add the `qr.js` file with the call to generate the QR code:

```cshtml
@section Scripts {
    <partial name="_ValidationScriptsPartial" />

    <script type="text/javascript" src="~/lib/qrcode.js"></script>
    <script type="text/javascript" src="~/js/qr.js"></script>
}
```

* Delete the paragraph that links you to these instructions.

Run your app and ensure that you can scan the QR code and validate the code the authenticator provides.

## Change the site name in the QR code

The site name in the QR code comes from the project name you choose when initially creating your project. You can change it by looking for the `GenerateQrCodeUri(string email, string unformattedKey)` method in the `/Areas/Identity/Pages/Account/Manage/EnableAuthenticator.cshtml.cs`.

The default code from the template looks as follows:

```csharp
private string GenerateQrCodeUri(string email, string unformattedKey)
{
    return string.Format(
        AuthenticatorUriFormat,
        _urlEncoder.Encode("Razor Pages"),
        _urlEncoder.Encode(email),
        unformattedKey);
}
```

The second parameter in the call to `string.Format` is your site name, taken from your solution name. You can change it to any value, but it must always be URL encoded.

## Using a different QR code library

You can replace the QR code library with your preferred library. The HTML contains a `qrCode` element into which you can place a QR code by whatever mechanism your library provides.

You can find the correctly formatted URL for the QR code in the:

* `AuthenticatorUri` property of the model.
* `data-url` property in the `qrCodeData` element.

## TOTP client and server time skew

TOTP (Time-based One-Time Password) authentication depends on both the server and authenticator device having an accurate time. Tokens only last for 30 seconds. If TOTP 2FA logins fail, check that the server time is accurate, and preferably synchronized to an accurate NTP service.
