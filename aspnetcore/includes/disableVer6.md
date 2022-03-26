---
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---
<a name="ddav"></a>
### Disable default account verification when Account.RegisterConfirmation has been scaffolded

This section only applies when `Account.RegisterConfirmation` is scaffolded. Skip this section if you have not scaffolded `Account.RegisterConfirmation`.

The user is redirected to the `Account.RegisterConfirmation` where they can select a link to have the account confirmed. The default `Account.RegisterConfirmation` is used ***only*** for testing, automatic account verification should be disabled in a production app.

To require a confirmed account and prevent immediate login at registration, set `DisplayConfirmAccountLink = false` in the scaffolded `/Areas/Identity/Pages/Account/RegisterConfirmation.cshtml.cs` file:

[!code-csharp[](~/security/authentication/accconfirm/sample/RegisterConfirmation.cshtml.cs?highlight=63)]

This step is only necessary when `Account.RegisterConfirmation` is scaffolded. The non-scaffolded [RegisterConfirmation](https://github.com/dotnet/aspnetcore/blob/1dcf7acfacf0fe154adcc23270cb0da11ff44ace/src/Identity/UI/src/Areas/Identity/Pages/V4/Account/RegisterConfirmation.cshtml.cs#L74-L87) automatically detects when an [IEmailSender](https://github.com/dotnet/aspnetcore/blob/1dcf7acfacf0fe154adcc23270cb0da11ff44ace/src/Identity/UI/src/Areas/Identity/Services/EmailSender.cs) has been implemented and registered with the [directory injection container](xref:fundamentals/dependency-injection) container.
