---
title: Enable QR code generation for TOTP authentication
ai-usage: ai-assisted
description: Discover how to enable QR code generation for time-based one-time password (TOTP) authenticator apps that work with ASP.NET Core two-factor authentication.
monikerRange: '>= aspnetcore-2.1'
ms.date: 10/26/2026
uid: security/authentication/identity-enable-qrcodes

# customer intent: As an ASP.NET developer, I want to enable QR code generation for TOTP authenticator apps, so I can support two-factor authentication.
---

# Enable QR code generation for TOTP authenticator apps in ASP.NET Core

ASP.NET Core includes support for authenticator applications for user authentication. Two-factor authentication (2FA) authenticator apps use a Time-based One-time Password Algorithm (TOTP), the industry-recommended approach for 2FA. (TOTP-based 2FA is preferred over SMS 2FA.) Users typically install the authenticator app on a smartphone. The app provides a 6 to 8 digit code that the user enters after they confirm their username and password. 

> [!WARNING]
> Keep the ASP.NET Core TOTP code secret. The user can enter the code multiple times and authenticate successfully before it expires.

:::moniker range=">= aspnetcore-8.0"

The ASP.NET Core web app templates support authenticators, but they don't provide support for QR code generation. QR code generators make it easier to set up 2FA. This article provides guidance for Razor Pages and MVC apps on how to add [QR code](https://wikipedia.org/wiki/QR_code) generation to the 2FA configuration page.

:::moniker-end
:::moniker range="< aspnetcore-8.0"

The ASP.NET Core web app templates support authenticators but don't provide support for QR code generation. QR code generators make it easier to set up 2FA. This article guides you through adding [QR code](https://wikipedia.org/wiki/QR_code) generation to the 2FA configuration page.

:::moniker-end

Two-factor authentication doesn't happen by using an external authentication provider, such as [Google](xref:security/authentication/google-logins) or [Facebook](xref:security/authentication/facebook-logins). External sign ins are protected by whatever mechanism the external authentication provider supports. For example, the [Microsoft](xref:security/authentication/microsoft-logins) authentication provider requires a hardware key or another 2FA approach. When the default templates require 2FA for both the web app and the external authentication provider, users need to satisfy two 2FA approaches. Requiring two 2FA approaches deviates from established security practices, which typically rely on a single, strong 2FA method for authentication.

If you're working with Blazor in ASP.NET Core 8.0 or later, you can find similar guidance in the following articles:

* <xref:blazor/security/qrcodes-for-authenticator-apps>
* <xref:blazor/security/webassembly/standalone-with-identity/qrcodes-for-authenticator-apps>

## Add QR codes to the 2FA configuration page

The following instructions use the `qrcode.js` file from the [https://davidshimjs.github.io/qrcodejs/](https://davidshimjs.github.io/qrcodejs/) repo.

1. Download the ['qrcode.js' JavaScript library](https://davidshimjs.github.io/qrcodejs/) to the `wwwroot\lib` folder in your project.

1. Follow the instructions in [Scaffold Identity](xref:security/authentication/scaffold-identity) to generate the `/Areas/Identity/Pages/Account/Manage/EnableAuthenticator.cshtml` file.

1. In the `/Areas/Identity/Pages/Account/Manage/EnableAuthenticator.cshtml` file, locate the `Scripts` section at the end of the file:

   ```cshtml
   @section Scripts {
      <partial name="_ValidationScriptsPartial" />
   }
   ```

1. Create a new JavaScript file named `qr.js` in the `wwwroot/js` folder, and add the following code that generates the QR code:

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

1. Update the `Scripts` section to add a reference to the `qrcode.js` library you previously downloaded.

1. Add the `qr.js` file with the call that generates the QR code:

   ```cshtml
   @section Scripts {
      <partial name="_ValidationScriptsPartial" />
      <script type="text/javascript" src="~/lib/qrcode.js"></script>
      <script type="text/javascript" src="~/js/qr.js"></script>
   }
   ```

1. In `EnableAuthenticator.cshtml`, remove the placeholder notice that links to these instructions (for example, `<div class="alert alert-info">Learn how to <a href="...">enable QR code generation</a>.</div>`). Scaffolded pages may already include the container elements immediately following the notice; if they are missing from your file, add the `qrCode` and `qrCodeData` container elements required by `qr.js`:

   ```cshtml
   <div id="qrCode"></div>
   <div id="qrCodeData" data-url="@Model.AuthenticatorUri"></div>
   ```

1. Run your app. Confirm you can scan the QR code and validate the code the authenticator provides.

## Change the site name in the QR code

The site name in the QR code comes from the project name you select when you create your project. You can change it by looking for the `GenerateQrCodeUri(string email, string unformattedKey)` method in the `/Areas/Identity/Pages/Account/Manage/EnableAuthenticator.cshtml.cs` file.

Here's the default code from the template:

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

The second parameter in the call to `string.Format` is your site name, which is obtained from your solution name. You can change it to any value, but it must always be URL encoded.

## Use a different QR code library

You can replace the QR code library with your preferred library. The HTML contains a `qrCode` element into which you can place a QR code by whatever mechanism your library provides.

You can find the correctly formatted URL for the QR code in the following locations:

* `AuthenticatorUri` property of the model
* `data-url` property in the `qrCodeData` element

## Check TOTP client and server times

TOTP (Time-based One-Time Password) authentication depends on both the server and authenticator device having an accurate time. Tokens only last for 30 seconds. If TOTP 2FA sign-in fails, confirm the server time is accurate, and preferably synchronized to an accurate NTP service.

## Related content

- <xref:blazor/security/qrcodes-for-authenticator-apps>
- <xref:blazor/security/webassembly/standalone-with-identity/qrcodes-for-authenticator-apps>
