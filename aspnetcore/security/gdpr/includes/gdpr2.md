:::moniker range="= aspnetcore-2.2"

* The project templates include extension points and stubbed markup that you can replace with your privacy and cookie use policy.
* A cookie consent feature allows you to ask for (and track) consent from your users for storing personal information. If a user hasn't consented to data collection and the app has <xref:Microsoft.AspNetCore.Builder.CookiePolicyOptions.CheckConsentNeeded%2A> set to `true`, non-essential cookies aren't sent to the browser.
* Cookies can be marked as essential. Essential cookies are sent to the browser even when the user hasn't consented and tracking is disabled.
* [TempData and Session cookies](#tempdata) aren't functional when tracking is disabled.
* The [Identity manage](#pd) page provides a link to download and delete user data.

The [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/live/aspnetcore/security/gdpr/sample) allows you to test most of the GDPR extension points and APIs added to the ASP.NET Core 2.1 templates. See the [ReadMe](https://github.com/dotnet/AspNetCore.Docs/tree/live/aspnetcore/security/gdpr/sample) file for testing instructions.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/live/aspnetcore/security/gdpr/sample) ([how to download](xref:index#how-to-download-a-sample))

## ASP.NET Core GDPR support in template-generated code

Razor Pages and MVC projects created with the project templates include the following GDPR support:

* <xref:Microsoft.AspNetCore.Builder.CookiePolicyOptions> and <xref:Microsoft.AspNetCore.Builder.CookiePolicyAppBuilderExtensions.UseCookiePolicy%2A> are set in the `Startup` class.
* The *\_CookieConsentPartial.cshtml* [partial view](xref:mvc/views/tag-helpers/builtin-th/partial-tag-helper). An **Accept** button is included in this file. When the user clicks the **Accept** button, consent to store cookies is provided.
* The `Pages/Privacy.cshtml` page or `Views/Home/Privacy.cshtml` view provides a page to detail your site's privacy policy. The *\_CookieConsentPartial.cshtml* file generates a link to the Privacy page.
* For apps created with individual user accounts, the Manage page provides links to download and delete [personal user data](#pd).

### CookiePolicyOptions and UseCookiePolicy

<xref:Microsoft.AspNetCore.Builder.CookiePolicyOptions> are initialized in `Startup.ConfigureServices`:

[!code-csharp[Main](~/security/gdpr/sample/Startup.cs?name=snippet1&highlight=14-20)]

<xref:Microsoft.AspNetCore.Builder.CookiePolicyAppBuilderExtensions.UseCookiePolicy%2A> is called in `Startup.Configure`:

[!code-csharp[](~/security/gdpr/sample/Startup.cs?name=snippet1&highlight=51)]

### \_CookieConsentPartial.cshtml partial view

The *\_CookieConsentPartial.cshtml* partial view:

[!code-cshtml[](~/security/gdpr/sample/RP2.2/Pages/Shared/_CookieConsentPartial.cshtml)]

This partial:

* Obtains the state of tracking for the user. If the app is configured to require consent, the user must consent before cookies can be tracked. If consent is required, the cookie consent panel is fixed at top of the navigation bar created by the *\_Layout.cshtml* file.
* Provides an HTML `<p>` element to summarize your privacy and cookie use policy.
* Provides a link to Privacy page or view where you can detail your site's privacy policy.

## Essential cookies

If consent to store cookies hasn't been provided, only cookies marked essential are sent to the browser. The following code makes a cookie essential:

[!code-csharp[Main](~/security/gdpr/sample/RP2.2/Pages/Cookie.cshtml.cs?name=snippet1&highlight=5)]

<a name="tempdata"></a>

### TempData provider and session state cookies aren't essential

The [TempData provider](xref:fundamentals/app-state#tempdata) cookie isn't essential. If tracking is disabled, the TempData provider isn't functional. To enable the TempData provider when tracking is disabled, mark the TempData cookie as essential in `Startup.ConfigureServices`:

[!code-csharp[Main](~/security/gdpr/sample/RP2.2/Startup.cs?name=snippet1)]

[Session state](xref:fundamentals/app-state) cookies are not essential. Session state isn't functional when tracking is disabled. The following code makes session cookies essential:

[!code-csharp[](~/security/gdpr/sample/RP2.2/Startup.cs?name=snippet2)]

<a name="pd"></a>

## Personal data

ASP.NET Core apps created with individual user accounts include code to download and delete personal data.

Select the user name and then select **Personal data**:

![Manage personal data page](~/security/gdpr/_static/pd.png)

Notes:

* To generate the `Account/Manage` code, see [Scaffold Identity](xref:security/authentication/scaffold-identity).
* The **Delete** and **Download** links only act on the default identity data. Apps that create custom user data must be extended to delete/download the custom user data. For more information, see [Add, download, and delete custom user data to Identity](xref:security/authentication/add-user-data).
* Saved tokens for the user that are stored in the Identity database table `AspNetUserTokens` are deleted when the user is deleted via the cascading delete behavior due to the [foreign key](https://github.com/aspnet/Identity/blob/release/2.1/src/EF/IdentityUserContext.cs#L152).
* [External provider authentication](xref:security/authentication/social/index), such as Facebook and Google, isn't available before the cookie policy is accepted.

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

* [Microsoft.com/GDPR](https://www.microsoft.com/trustcenter/Privacy/GDPR)
:::moniker-end
