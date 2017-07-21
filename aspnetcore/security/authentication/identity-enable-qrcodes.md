# Enabling QR Code generation for authenticator apps in ASP.NET Core

> [!NOTE]
> This topic applies to ASP.NET Core 2.0

ASP.NET Core ships with support for Authenticator applications for individual authentication. 2fa Authenticator apps are the industry recommended method of two factor authentication, using a code based on a Time-based One-time Password Algorithm (TOTP). An authenticator app provides a six to eight digit code which users must enter after confirming their username and password. Typically an authenticator app is installed on a smart phone.

The ASP.NET Core templates for web applications and MVC web applications support authenticators, but do not provide support for QRCode generation, which applications can use to ease the setup. This document will guide you through adding QR Code generation to the 2fa configuration page.

## Adding QR Codes to the 2fa configuration page

These instructions use `qrcode.js` from https://davidshimjs.github.io/qrcodejs/.

* Download the [qrcode.js script](https://davidshimjs.github.io/qrcodejs/) and place it in the `wwwroot\lib` folder in your project.

* Open the `Pages\Account\Manage\EnableAuthenticator.cshtml` file.

* Locate the Scripts section at the end of the file. It will look something like this:

```None
@section Scripts {
    @await Html.PartialAsync("_ValidationScriptsPartial")
}
```
* Change the `Scripts` section to add a reference to the library you added and a call to generate the QR Code. It should look as follows:

```None
@section Scripts {
    @await Html.PartialAsync("_ValidationScriptsPartial")

    <script type="text/javascript" src="/lib/qrcode.js"></script>
    <script type="text/javascript">
        new QRCode(document.getElementById("qrCode"),
            {
                text: "@Html.Raw(Model.AuthenticatorUri)",
                width: 150,
                height: 150
            });
    </script>
}
```

* Finally delete the paragraph which links you to these instructions.

Run your application and ensure that you can scan the QR code and validate the code the authenticator proves.

## Change the site name in the QR Code

The site name in the QR Code is taken from the project name you choose when initially creating your project. You can change it by looking for the `GenerateQrCodeUri(string email, string unformattedKey)` method in `EnableAuthenticator.cshtml.cs`. 

The default code from the template looks as follows:

```c#
private string GenerateQrCodeUri(string email, string unformattedKey)
{
    return string.Format(
        AuthenicatorUriFormat,
        _urlEncoder.Encode("Razor Pages"),
        _urlEncoder.Encode(email),
        unformattedKey);
}
```

The second parameter in the call to `string.Format()` is your site name, taken from your solution name. It can be changed to anything value, but it must always be URL encoded.

## Using a different QR Code library

You may have a preferred QR Code library which you want to use. The `qrCode` element in the view is a suitable place to put the QR code.

The correctly formatted URL for the QR Code is available in two places, in the `AuthenticatorUri` property of the model and in the `data-url` property in the `qrCodeData` element. If you want to use the model property you must access it in your view using `@Html.Raw` otherwise the ampersands in the url will be double encoded and the label parameter of the QR Code will be ignored.