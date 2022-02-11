---
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---
<a name="ddav"></a>
### Disable default account verification

With the default templates, the user is redirected to the `Account.RegisterConfirmation` where they can select a link to have the account confirmed. The default `Account.RegisterConfirmation` is used ***only*** for testing, automatic account verification should be disabled in a production app.

To require a confirmed account and prevent immediate login at registration, set `DisplayConfirmAccountLink = false` in */Areas/Identity/Pages/Account/RegisterConfirmation.cshtml.cs*:

[!code-csharp[](~/security/authentication/accconfirm/sample/WebPWrecover60/Areas/Identity/Pages/Account/RegisterConfirmation.cshtml.cs?highlight=63)]