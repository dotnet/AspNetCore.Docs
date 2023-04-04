:::moniker range="= aspnetcore-6.0"

* The project templates include extension points and stubbed markup that you can replace with your privacy and cookie use policy.
* The `Pages/Privacy.cshtml` page or `Views/Home/Privacy.cshtml` view provides a page to detail your site's privacy policy.

To enable the default cookie consent feature like that found in the ASP.NET Core 2.2 templates in a current ASP.NET Core template generated app, add the following highlighted code to `Program.cs`:

  [!code-csharp[Main](~/security/gdpr/sample/RP6.0/WebGDPR/Program.cs?name=snippet_1&highlight=4-11,23)]

In the preceding code, <xref:Microsoft.AspNetCore.Builder.CookiePolicyOptions> and <xref:Microsoft.AspNetCore.Builder.CookiePolicyAppBuilderExtensions.UseCookiePolicy%2A> are used.

* Add the cookie consent partial to the `_Layout.cshtml` file:

  [!code-cshtml[Main](~/security/gdpr/sample/RP6.0/WebGDPR/Pages/Shared/_Layout.cshtml?name=snippet&highlight=4)]

* Add the `_CookieConsentPartial.cshtml` file to the project:

  [!code-cshtml[Main](~/security/gdpr/sample/RP6.0/WebGDPR/Pages/Shared/_CookieConsentPartial.cshtml)]

* Select the ASP.NET Core [2.2 version](xref:security/gdpr?view=aspnetcore-2.2&preserve-view=true) of this article to read about the cookie consent feature.

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