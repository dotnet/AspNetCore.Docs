### Disable default account verification when Account.RegisterConfirmation is scaffolded

If `Account.RegisterConfirmation` is scaffolded, complete the instructions in this section.

> [!IMPORTANT]
> If `Account.RegisterConfirmation` is **not** scaffolded, skip the following instructions and continue to the next section.

The user is redirected to the `/Identity/Account/RegisterConfirmation` page where they can select a link to have the account confirmed. The default `Account.RegisterConfirmation` is used ***only*** for testing. Automatic account verification should be disabled in a production app.

To require a confirmed account and prevent immediate sign in at registration, set `DisplayConfirmAccountLink = false` in the scaffolded _/Areas/Identity/Pages/Account/RegisterConfirmation.cshtml.cs_ file:

[!code-csharp[](~/security/authentication/accconfirm/sample/RegisterConfirmation.cshtml.cs?highlight=63)]

This step is necessary only when `Account.RegisterConfirmation` is scaffolded.

The non-scaffolded [RegisterConfirmation](https://github.com/dotnet/aspnetcore/blob/1dcf7acfacf0fe154adcc23270cb0da11ff44ace/src/Identity/UI/src/Areas/Identity/Pages/V4/Account/RegisterConfirmation.cshtml.cs#L74-L87) automatically detects when an [IEmailSender](https://github.com/dotnet/aspnetcore/blob/1dcf7acfacf0fe154adcc23270cb0da11ff44ace/src/Identity/UI/src/Areas/Identity/Services/EmailSender.cs) is implemented and registered with the [dependency injection container](xref:fundamentals/dependency-injection).
