---
title: General Data Protection Regulation (GDPR) support in ASP.NET Core
author: rick-anderson
description: Learn how to access the GDPR extension points in a ASP.NET Core web app.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.custom: mvc
ms.date: 05/29/2018
uid: security/gdpr
---
# EU General Data Protection Regulation (GDPR) support in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

ASP.NET Core provides APIs and templates to help meet some of the [EU General Data Protection Regulation (GDPR)](https://www.eugdpr.org/) requirements:

* The project templates include extension points and stubbed markup that you can replace with your privacy and cookie use policy.
* A cookie consent feature allows you to ask for (and track) consent from your users for storing personal information. If a user hasn't consented to data collection and the app has [CheckConsentNeeded](/dotnet/api/microsoft.aspnetcore.builder.cookiepolicyoptions.checkconsentneeded) set to `true`, non-essential cookies aren't sent to the browser.
* Cookies can be marked as essential. Essential cookies are sent to the browser even when the user hasn't consented and tracking is disabled.
* [TempData and Session cookies](#tempdata) aren't functional when tracking is disabled.
* The [Identity manage](#pd) page provides a link to download and delete user data.

The [sample app](https://github.com/aspnet/Docs/tree/live/aspnetcore/security/gdpr/sample) allows you test most of the GDPR extension points and APIs added to the ASP.NET Core 2.1 templates. See the [ReadMe](https://github.com/aspnet/Docs/tree/live/aspnetcore/security/gdpr/sample) file for testing instructions.

[View or download sample code](https://github.com/aspnet/Docs/tree/live/aspnetcore/security/gdpr/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## ASP.NET Core GDPR support in template generated code

Razor Pages and MVC projects created with the project templates include the following GDPR support:

* [CookiePolicyOptions](/dotnet/api/microsoft.aspnetcore.builder.cookiepolicyoptions) and [UseCookiePolicy](/dotnet/api/microsoft.aspnetcore.builder.cookiepolicyappbuilderextensions.usecookiepolicy) are set in `Startup`.
* The *_CookieConsentPartial.cshtml* [partial view](xref:mvc/views/tag-helpers/builtin-th/partial-tag-helper).
* The *Pages/Privacy.cshtml* page or *Views/Home/Privacy.cshtml* view provides a page to detail your site's privacy policy. The *_CookieConsentPartial.cshtml* file generates a link to the Privacy page.
* For apps created with individual user accounts, the Manage page provides links to download and delete [personal user data](#pd).

### CookiePolicyOptions and UseCookiePolicy

[CookiePolicyOptions](/dotnet/api/microsoft.aspnetcore.builder.cookiepolicyoptions) are initialized in `Startup.ConfigureServices`:

[!code-csharp[Main](gdpr/sample/Startup.cs?name=snippet1&highlight=14-20)]

[UseCookiePolicy](/dotnet/api/microsoft.aspnetcore.builder.cookiepolicyappbuilderextensions.usecookiepolicy) is called in `Startup.Configure`:

[!code-csharp[](gdpr/sample/Startup.cs?name=snippet1&highlight=49)]

### _CookieConsentPartial.cshtml partial view

The *_CookieConsentPartial.cshtml* partial view:

[!code-html[](gdpr/sample/RP/Pages/Shared/_CookieConsentPartial.cshtml)]

This partial:

* Obtains the state of tracking for the user. If the app is configured to require consent, the user must consent before cookies can be tracked. If consent is required, the cookie consent panel is fixed at top of the navigation bar created by the *_Layout.cshtml* file.
* Provides an HTML `<p>` element to summarize your privacy and cookie use policy.
* Provides a link to Privacy page or view where you can detail your site's privacy policy.

## Essential cookies

If consent has not been given, only cookies marked essential are sent to the browser. The following code makes a cookie essential:

[!code-csharp[Main](gdpr/sample/RP/Pages/Cookie.cshtml.cs?name=snippet1&highlight=5)]

<a name="tempdata"></a>

## Tempdata provider and session state cookies are not essential

The [Tempdata provider](xref:fundamentals/app-state#tempdata) cookie isn't essential. If tracking is disabled, the Tempdata provider isn't functional. To enable the Tempdata provider when tracking is disabled, mark the TempData cookie as essential in `Startup.ConfigureServices`:

[!code-csharp[Main](gdpr/sample/RP/Startup.cs?name=snippet1)]

[Session state](xref:fundamentals/app-state) cookies are not essential. Session state isn't functional when tracking is disabled.

<a name="pd"></a>

## Personal data

ASP.NET Core apps created with individual user accounts include code to download and delete personal data.

Select the user name and then select **Personal data**:

![Manage personal data page](gdpr/_static/pd.png)

Notes:

* To generate the `Account/Manage` code, see [Scaffold Identity](xref:security/authentication/scaffold-identity).
* Delete and download only impact the default identity data. Apps that create custom user data must be extended to delete/download the custom user data. For more information, see [Add, download, and delete custom user data to Identity](xref:security/authentication/add-user-data).
* Saved tokens for the user that are stored in the Identity database table `AspNetUserTokens` are deleted when the user is deleted via the cascading delete behavior due to the [foreign key](https://github.com/aspnet/Identity/blob/release/2.1/src/EF/IdentityUserContext.cs#L152).

## Encryption at rest

Some databases and storage mechanisms allow for encryption at rest. Encryption at rest:

* Encrypts stored data automatically.
* Encrypts without configuration, programming, or other work for the software that accesses the data.
* Is the easiest and safest option.
* Allows the database to manage keys and encryption.

For example:

* Microsoft SQL and Azure SQL provide [Transparent Data Encryption](/sql/relational-databases/security/encryption/transparent-data-encryption) (TDE).
* [SQL Azure encrypts the database by default](https://azure.microsoft.com/updates/newly-created-azure-sql-databases-encrypted-by-default/)
* [Azure Blobs, Files, Table, and Queue Storage are encrypted by default](https://azure.microsoft.com/blog/announcing-default-encryption-for-azure-blobs-files-table-and-queue-storage/).

For databases that don't provide built-in encryption at rest, you may be able to use disk encryption to provide the same protection. For example:

* [BitLocker for Windows Server](/windows/security/information-protection/bitlocker/bitlocker-how-to-deploy-on-windows-server)
* Linux:
  * [eCryptfs](https://launchpad.net/ecryptfs)
  * [EncFS](https://github.com/vgough/encfs).

## Additional resources

* [Microsoft.com/GDPR](https://www.microsoft.com/en-us/trustcenter/Privacy/GDPR)
