---
title: Configure ASP.NET Core Data Protection
author: rick-anderson
description: Learn how to configure Data Protection in ASP.NET Core.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 02/14/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/data-protection/configuration/overview
---
# Configure ASP.NET Core Data Protection

:::moniker range=">= aspnetcore-6.0"

When the Data Protection system is initialized, it applies [default settings](xref:security/data-protection/configuration/default-settings) based on the operational environment. These settings are appropriate for apps running on a single machine. However, there are cases where a developer may want to change the default settings:

* The app is spread across multiple machines.
* For compliance reasons.

For these scenarios, the Data Protection system offers a rich configuration API.

> [!WARNING]
> Similar to configuration files, the data protection key ring should be protected using appropriate permissions. You can choose to encrypt keys at rest, but this doesn't prevent attackers from creating new keys. Consequently, your app's security is impacted. The storage location configured with Data Protection should have its access limited to the app itself, similar to the way you would protect configuration files. For example, if you choose to store your key ring on disk, use file system permissions. Ensure only the identity under which your web app runs has read, write, and create access to that directory. If you use Azure Blob Storage, only the web app should have the ability to read, write, or create new entries in the blob store, etc.
>
> The extension method <xref:Microsoft.Extensions.DependencyInjection.DataProtectionServiceCollectionExtensions.AddDataProtection%2A> returns an <xref:Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder>. `IDataProtectionBuilder` exposes extension methods that you can chain together to configure Data Protection options.

The following NuGet packages are required for the Data Protection extensions used in this article:

* [Azure.Extensions.AspNetCore.DataProtection.Blobs](https://www.nuget.org/packages/Azure.Extensions.AspNetCore.DataProtection.Blobs)
* [Azure.Extensions.AspNetCore.DataProtection.Keys](https://www.nuget.org/packages/Azure.Extensions.AspNetCore.DataProtection.Keys)

## ProtectKeysWithAzureKeyVault

Sign in to Azure using the CLI, for example:

```azurecli
az login
``` 

To store keys in [Azure Key Vault](https://azure.microsoft.com/services/key-vault/), configure the system with <xref:Microsoft.AspNetCore.DataProtection.AzureDataProtectionBuilderExtensions.ProtectKeysWithAzureKeyVault%2A> in `Program.cs`. `blobUriWithSasToken` is the full URI where the key file should be stored. The URI must contain the SAS token as a query string parameter:

:::code language="csharp" source="samples/6.x/DataProtectionConfigurationSample/Snippets/Program.cs" id="snippet_AddDataProtectionProtectKeysWithAzureKeyVault":::

For an app to communicate and authorize itself with KeyVault,  the [Azure.Identity](https://www.nuget.org/packages/Azure.Identity/) package  must be added.

Set the key ring storage location (for example, <xref:Microsoft.AspNetCore.DataProtection.AzureDataProtectionBuilderExtensions.PersistKeysToAzureBlobStorage%2A>). The location must be set because calling `ProtectKeysWithAzureKeyVault` implements an <xref:Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlEncryptor> that disables automatic data protection settings, including the key ring storage location. The preceding example uses Azure Blob Storage to persist the key ring. For more information, see [Key storage providers: Azure Storage](xref:security/data-protection/implementation/key-storage-providers#azure-storage). You can also persist the key ring locally with [PersistKeysToFileSystem](xref:security/data-protection/implementation/key-storage-providers#file-system).

The `keyIdentifier` is the key vault key identifier used for key encryption. For example, a key created in key vault named `dataprotection` in the `contosokeyvault` has the key identifier `https://contosokeyvault.vault.azure.net/keys/dataprotection/`. Provide the app with **Get**, **Unwrap Key** and **Wrap Key** permissions to the key vault.

`ProtectKeysWithAzureKeyVault` overloads:

* <xref:Microsoft.AspNetCore.DataProtection.AzureDataProtectionKeyVaultKeyBuilderExtensions.ProtectKeysWithAzureKeyVault(Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder,System.Uri,Azure.Core.TokenCredential)> permits the use of a keyIdentifier Uri and a tokenCredential to enable the data protection system to use the key vault.
* <xref:Microsoft.AspNetCore.DataProtection.AzureDataProtectionKeyVaultKeyBuilderExtensions.ProtectKeysWithAzureKeyVault(Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder,System.String,Azure.Core.Cryptography.IKeyEncryptionKeyResolver)> permits the use of a keyIdentifier string and IKeyEncryptionKeyResolver to enable the data protection system to use the key vault.

If the app uses the older Azure packages (Microsoft.AspNetCore.DataProtection.AzureStorage and Microsoft.AspNetCore.DataProtection.AzureKeyVault), we recommend ***removing*** these references and upgrading to the [Azure.Extensions.AspNetCore.DataProtection.Blobs](https://www.nuget.org/packages/Azure.Extensions.AspNetCore.DataProtection.Blobs) and [Azure.Extensions.AspNetCore.DataProtection.Keys](https://www.nuget.org/packages/Azure.Extensions.AspNetCore.DataProtection.Keys). These packages are where new updates are provided, and address some key security and stability issues with the older packages.

:::code language="csharp" source="samples/6.x/DataProtectionConfigurationSample/Snippets/Program.cs" id="snippet_AddDataProtectionProtectKeysWithAzureKeyVaultConnectionString":::

## PersistKeysToFileSystem

To store keys on a UNC share instead of at the *%LOCALAPPDATA%* default location, configure the system with <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.PersistKeysToFileSystem%2A>:

:::code language="csharp" source="samples/6.x/DataProtectionConfigurationSample/Snippets/Program.cs" id="snippet_AddDataProtectionPersistKeysToFileSystem":::

> [!WARNING]
> If you change the key persistence location, the system no longer automatically encrypts keys at rest, since it doesn't know whether DPAPI is an appropriate encryption mechanism.

## PersistKeysToDbContext

To store keys in a database using EntityFramework, configure the system with the [Microsoft.AspNetCore.DataProtection.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.AspNetCore.DataProtection.EntityFrameworkCore/) package:

:::code language="csharp" source="samples/6.x/DataProtectionConfigurationSample/Snippets/Program.cs" id="snippet_AddDataProtectionPersistKeysToDbContext":::

The preceding code stores the keys in the configured database. The database context being used must implement `IDataProtectionKeyContext`.  `IDataProtectionKeyContext` exposes the property `DataProtectionKeys` 

:::code language="csharp" source="samples/6.x/DataProtectionConfigurationSample/Snippets/SampleDbContext.cs" id="snippet_DataProtectionKeys":::

This property represents the table in which the keys are stored. Create the table manually or with `DbContext` Migrations. For more information, see <xref:Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.DataProtectionKey>.

## ProtectKeysWith\*

You can configure the system to protect keys at rest by calling any of the [ProtectKeysWith\*](xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions) configuration APIs. Consider the example below, which stores keys on a UNC share and encrypts those keys at rest with a specific X.509 certificate:

:::code language="csharp" source="samples/6.x/DataProtectionConfigurationSample/Snippets/Program.cs" id="snippet_AddDataProtectionProtectKeysWithCertificate":::

You can provide an <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> to <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.ProtectKeysWithCertificate%2A>, such as a certificate loaded from a file:

:::code language="csharp" source="samples/6.x/DataProtectionConfigurationSample/Snippets/Program.cs" id="snippet_AddDataProtectionProtectKeysWithCertificateX509Certificate2":::

See [Key Encryption At Rest](xref:security/data-protection/implementation/key-encryption-at-rest) for more examples and discussion on the built-in key encryption mechanisms.

## UnprotectKeysWithAnyCertificate

You can rotate certificates and decrypt keys at rest using an array of <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> certificates with <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.UnprotectKeysWithAnyCertificate%2A>:

:::code language="csharp" source="samples/6.x/DataProtectionConfigurationSample/Snippets/Program.cs" id="snippet_AddDataProtectionUnprotectKeysWithAnyCertificate":::

## SetDefaultKeyLifetime

To configure the system to use a key lifetime of 14 days instead of the default 90 days, use <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.SetDefaultKeyLifetime%2A>:

:::code language="csharp" source="samples/6.x/DataProtectionConfigurationSample/Snippets/Program.cs" id="snippet_AddDataProtectionSetDefaultKeyLifetime":::

## SetApplicationName

By default, the Data Protection system isolates apps from one another based on their [content root](xref:fundamentals/index#content-root) paths, even if they share the same physical key repository. This isolation prevents the apps from understanding each other's protected payloads.

To share protected payloads among apps:

* Configure <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.SetApplicationName%2A> in each app with the same value.
* Use the same version of the Data Protection API stack across the apps. Perform **either** of the following in the apps' project files:
  * Reference the same shared framework version via the [Microsoft.AspNetCore.App metapackage](xref:fundamentals/metapackage-app).
  * Reference the same [Data Protection package](xref:security/data-protection/introduction#package-layout) version.

:::code language="csharp" source="samples/6.x/DataProtectionConfigurationSample/Snippets/Program.cs" id="snippet_AddDataProtectionSetApplicationName":::

## DisableAutomaticKeyGeneration

You may have a scenario where you don't want an app to automatically roll keys (create new keys) as they approach expiration. One example of this scenario might be apps set up in a primary/secondary relationship, where only the primary app is responsible for key management concerns and secondary apps simply have a read-only view of the key ring. The secondary apps can be configured to treat the key ring as read-only by configuring the system with <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.DisableAutomaticKeyGeneration%2A>:

:::code language="csharp" source="samples/6.x/DataProtectionConfigurationSample/Snippets/Program.cs" id="snippet_AddDataProtectionDisableAutomaticKeyGeneration":::

## Per-application isolation

When the Data Protection system is provided by an ASP.NET Core host, it automatically isolates apps from one another, even if those apps are running under the same worker process account and are using the same master keying material. This is similar to the IsolateApps modifier from System.Web's `<machineKey>` element.

The isolation mechanism works by considering each app on the local machine as a unique tenant, thus the <xref:Microsoft.AspNetCore.DataProtection.IDataProtector> rooted for any given app automatically includes the app ID as a discriminator. The app's unique ID is the app's physical path:

* For apps hosted in IIS, the unique ID is the IIS physical path of the app. If an app is deployed in a web farm environment, this value is stable assuming that the IIS environments are configured similarly across all machines in the web farm.
* For self-hosted apps running on the [Kestrel server](xref:fundamentals/servers/index#kestrel), the unique ID is the physical path to the app on disk.

The unique identifier is designed to survive resets&mdash;both of the individual app and of the machine itself.

This isolation mechanism assumes that the apps aren't malicious. A malicious app can always impact any other app running under the same worker process account. In a shared hosting environment where apps are mutually untrusted, the hosting provider should take steps to ensure OS-level isolation between apps, including separating the apps' underlying key repositories.

If the Data Protection system isn't provided by an ASP.NET Core host (for example, if you instantiate it via the `DataProtectionProvider` concrete type) app isolation is disabled by default. When app isolation is disabled, all apps backed by the same keying material can share payloads as long as they provide the appropriate [purposes](xref:security/data-protection/consumer-apis/purpose-strings). To provide app isolation in this environment, call the [SetApplicationName](#setapplicationname) method on the configuration object and provide a unique name for each app.

### Data Protection and app isolation

Consider the following points for app isolation:

* When multiple apps are pointed at the same key repository, the intention is that the apps share the same master key material. Data Protection is developed with the assumption that all apps sharing a key ring can access all items in that key ring. The application unique identifier is used to isolate application specific keys derived from the key ring provided keys. It doesn't expect item level permissions, such as those provided by Azure KeyVault to be used to enforce extra isolation. Attempting item level permissions generates application errors. If you don't want to rely on the built-in application isolation, separate key store locations should be used and not shared between applications.

* The application discriminator is used to allow different apps to share the same master key material but to keep their cryptographic payloads distinct from one another. <!-- The docs already draw an analogy between this and multi-tenancy.--> For the apps to be able to read each other's cryptographic payloads, they must have the same application discriminator.

* If an app is compromised (for example, by an RCE attack), all master key material accessible to that app must also be considered compromised, regardless of its protection-at-rest state. This implies that if two apps are pointed at the same repository, even if they use different app discriminators, a compromise of one is functionally equivalent to a compromise of both.

  This "functionally equivalent to a compromise of both" clause holds even if the two apps use different mechanisms for key protection at rest. Typically, this isn't an expected configuration. The protection-at-rest mechanism is intended to provide protection in the event an adversary gains read access to the repository. An adversary who gains write access to the repository (perhaps because they attained code execution permission within an app) can insert malicious keys into storage. The Data Protection system intentionally doesn't provide protection against an adversary who gains write access to the key repository.

* If apps need to remain truly isolated from one another, they should use different key repositories. This naturally falls out of the definition of "isolated". Apps are ***not*** isolated if they all have Read and Write access to each other's data stores.

## Changing algorithms with UseCryptographicAlgorithms

The Data Protection stack allows you to change the default algorithm used by newly generated keys. The simplest way to do this is to call <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.UseCryptographicAlgorithms%2A> from the configuration callback:

:::code language="csharp" source="samples/6.x/DataProtectionConfigurationSample/Snippets/Program.cs" id="snippet_AddDataProtectionUseCryptographicAlgorithms":::

The default EncryptionAlgorithm is AES-256-CBC, and the default ValidationAlgorithm is HMACSHA256. The default policy can be set by a system administrator via a [machine-wide policy](xref:security/data-protection/configuration/machine-wide-policy), but an explicit call to `UseCryptographicAlgorithms` overrides the default policy.

Calling `UseCryptographicAlgorithms` allows you to specify the desired algorithm from a predefined built-in list. You don't need to worry about the implementation of the algorithm. In the scenario above, the Data Protection system attempts to use the CNG implementation of AES if running on Windows. Otherwise, it falls back to the managed <xref:System.Security.Cryptography.Aes?displayProperty=fullName> class.

You can manually specify an implementation via a call to <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.UseCustomCryptographicAlgorithms%2A>.

> [!TIP]
> Changing algorithms doesn't affect existing keys in the key ring. It only affects newly-generated keys.

### Specifying custom managed algorithms

To specify custom managed algorithms, create a <xref:Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorConfiguration> instance that points to the implementation types:

:::code language="csharp" source="samples/6.x/DataProtectionConfigurationSample/Snippets/Program.cs" id="snippet_AddDataProtectionUseCustomCryptographicAlgorithms":::

Generally the \*Type properties must point to concrete, instantiable (via a public parameterless ctor) implementations of <xref:System.Security.Cryptography.SymmetricAlgorithm> and <xref:System.Security.Cryptography.KeyedHashAlgorithm>, though the system special-cases some values like `typeof(Aes)` for convenience.

> [!NOTE]
> The SymmetricAlgorithm must have a key length of ≥ 128 bits and a block size of ≥ 64 bits, and it must support CBC-mode encryption with PKCS #7 padding. The KeyedHashAlgorithm must have a digest size of >= 128 bits, and it must support keys of length equal to the hash algorithm's digest length. The KeyedHashAlgorithm isn't strictly required to be HMAC.

### Specifying custom Windows CNG algorithms

To specify a custom Windows CNG algorithm using CBC-mode encryption with HMAC validation, create a <xref:Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngCbcAuthenticatedEncryptorConfiguration> instance that contains the algorithmic information:

:::code language="csharp" source="samples/6.x/DataProtectionConfigurationSample/Snippets/Program.cs" id="snippet_AddDataProtectionUseCustomCryptographicAlgorithmsCngCbc":::

> [!NOTE]
> The symmetric block cipher algorithm must have a key length of >= 128 bits, a block size of >= 64 bits, and it must support CBC-mode encryption with PKCS #7 padding. The hash algorithm must have a digest size of >= 128 bits and must support being opened with the BCRYPT\_ALG\_HANDLE\_HMAC\_FLAG flag. The \*Provider properties can be set to null to use the default provider for the specified algorithm. For more information, see the [BCryptOpenAlgorithmProvider](/windows/win32/api/bcrypt/nf-bcrypt-bcryptopenalgorithmprovider) documentation.

To specify a custom Windows CNG algorithm using Galois/Counter Mode encryption with validation, create a <xref:Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngGcmAuthenticatedEncryptorConfiguration> instance that contains the algorithmic information:

:::code language="csharp" source="samples/6.x/DataProtectionConfigurationSample/Snippets/Program.cs" id="snippet_AddDataProtectionUseCustomCryptographicAlgorithmsCngGcm":::

> [!NOTE]
> The symmetric block cipher algorithm must have a key length of >= 128 bits, a block size of exactly 128 bits, and it must support GCM encryption. You can set the <xref:Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngCbcAuthenticatedEncryptorConfiguration.EncryptionAlgorithmProvider> property to null to use the default provider for the specified algorithm. For more information, see the [BCryptOpenAlgorithmProvider](/windows/win32/api/bcrypt/nf-bcrypt-bcryptopenalgorithmprovider) documentation.

### Specifying other custom algorithms

Though not exposed as a first-class API, the Data Protection system is extensible enough to allow specifying almost any kind of algorithm. For example, it's possible to keep all keys contained within a Hardware Security Module (HSM) and to provide a custom implementation of the core encryption and decryption routines. For more information, see <xref:Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor> in [Core cryptography extensibility](xref:security/data-protection/extensibility/core-crypto).

## Persisting keys when hosting in a Docker container

When hosting in a [Docker](/dotnet/standard/microservices-architecture/container-docker-introduction/) container, keys should be maintained in either:

* A folder that's a Docker volume that persists beyond the container's lifetime, such as a shared volume or a host-mounted volume.
* An external provider, such as [Azure Blob Storage](/azure/storage/blobs/storage-blobs-introduction) (shown in the [`ProtectKeysWithAzureKeyVault`](#protectkeyswithazurekeyvault) section) or [Redis](https://redis.io).

## Persisting keys with Redis

Only Redis versions supporting [Redis Data Persistence](/azure/azure-cache-for-redis/cache-how-to-premium-persistence) should be used to store keys. [Azure Blob storage](/azure/storage/blobs/storage-blobs-introduction) is persistent and can be used to store keys. For more information, see [this GitHub issue](https://github.com/dotnet/AspNetCore/issues/13476).

## Logging DataProtection

Enable `Information` level logging of DataProtection to help diagnosis problem. The following `appsettings.json` file enables information logging of the DataProtection API:

:::code language="csharp" source="samples/6.x/DataProtectionConfigurationSample/appsettings.json" highlight="6":::

For more information on logging, see [Logging in .NET Core and ASP.NET Core](xref:fundamentals/logging/index).

## Additional resources

* <xref:security/data-protection/configuration/non-di-scenarios>
* <xref:security/data-protection/configuration/machine-wide-policy>
* <xref:host-and-deploy/web-farm>
* <xref:security/data-protection/implementation/key-storage-providers>

:::moniker-end


:::moniker range="< aspnetcore-6.0"

When the Data Protection system is initialized, it applies [default settings](xref:security/data-protection/configuration/default-settings) based on the operational environment. These settings are appropriate for apps running on a single machine. However, there are cases where a developer may want to change the default settings:

* The app is spread across multiple machines.
* For compliance reasons.

For these scenarios, the Data Protection system offers a rich configuration API.

> [!WARNING]
> Similar to configuration files, the data protection key ring should be protected using appropriate permissions. You can choose to encrypt keys at rest, but this doesn't prevent attackers from creating new keys. Consequently, your app's security is impacted. The storage location configured with Data Protection should have its access limited to the app itself, similar to the way you would protect configuration files. For example, if you choose to store your key ring on disk, use file system permissions. Ensure only the identity under which your web app runs has read, write, and create access to that directory. If you use Azure Blob Storage, only the web app should have the ability to read, write, or create new entries in the blob store, etc.
>
> The extension method <xref:Microsoft.Extensions.DependencyInjection.DataProtectionServiceCollectionExtensions.AddDataProtection%2A> returns an <xref:Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder>. `IDataProtectionBuilder` exposes extension methods that you can chain together to configure Data Protection options.

The following NuGet packages are required for the Data Protection extensions used in this article:

* [Azure.Extensions.AspNetCore.DataProtection.Blobs](https://www.nuget.org/packages/Azure.Extensions.AspNetCore.DataProtection.Blobs)
* [Azure.Extensions.AspNetCore.DataProtection.Keys](https://www.nuget.org/packages/Azure.Extensions.AspNetCore.DataProtection.Keys)

## ProtectKeysWithAzureKeyVault

Sign in to Azure using the CLI, for example:

```azurecli
az login
``` 

To store keys in [Azure Key Vault](https://azure.microsoft.com/services/key-vault/), configure the system with <xref:Microsoft.AspNetCore.DataProtection.AzureDataProtectionBuilderExtensions.ProtectKeysWithAzureKeyVault%2A> in the `Startup` class. `blobUriWithSasToken` is the full URI where the key file should be stored. The URI must contain the SAS token as a query string parameter:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDataProtection()
        .PersistKeysToAzureBlobStorage(new Uri("<blobUriWithSasToken>"))
        .ProtectKeysWithAzureKeyVault(new Uri("<keyIdentifier>"), new DefaultAzureCredential());
}
```

For an app to communicate and authorize itself with KeyVault,  the [Azure.Identity](https://www.nuget.org/packages/Azure.Identity/) package  must be added.

Set the key ring storage location (for example, <xref:Microsoft.AspNetCore.DataProtection.AzureDataProtectionBuilderExtensions.PersistKeysToAzureBlobStorage%2A>). The location must be set because calling `ProtectKeysWithAzureKeyVault` implements an <xref:Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlEncryptor> that disables automatic data protection settings, including the key ring storage location. The preceding example uses Azure Blob Storage to persist the key ring. For more information, see [Key storage providers: Azure Storage](xref:security/data-protection/implementation/key-storage-providers#azure-storage). You can also persist the key ring locally with [PersistKeysToFileSystem](xref:security/data-protection/implementation/key-storage-providers#file-system).

The `keyIdentifier` is the key vault key identifier used for key encryption. For example, a key created in key vault named `dataprotection` in the `contosokeyvault` has the key identifier `https://contosokeyvault.vault.azure.net/keys/dataprotection/`. Provide the app with **Get**, **Unwrap Key** and **Wrap Key** permissions to the key vault.

`ProtectKeysWithAzureKeyVault` overloads:

* <xref:Microsoft.AspNetCore.DataProtection.AzureDataProtectionKeyVaultKeyBuilderExtensions.ProtectKeysWithAzureKeyVault(Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder,System.Uri,Azure.Core.TokenCredential)> permits the use of a keyIdentifier Uri and a tokenCredential to enable the data protection system to use the key vault.
* <xref:Microsoft.AspNetCore.DataProtection.AzureDataProtectionKeyVaultKeyBuilderExtensions.ProtectKeysWithAzureKeyVault(Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder,System.String,Azure.Core.Cryptography.IKeyEncryptionKeyResolver)> permits the use of a keyIdentifier string and IKeyEncryptionKeyResolver to enable the data protection system to use the key vault.

If the app uses the older Azure packages (Microsoft.AspNetCore.DataProtection.AzureStorage and Microsoft.AspNetCore.DataProtection.AzureKeyVault), we recommend ***removing*** these references and upgrading to the [Azure.Extensions.AspNetCore.DataProtection.Blobs](https://www.nuget.org/packages/Azure.Extensions.AspNetCore.DataProtection.Blobs) and [Azure.Extensions.AspNetCore.DataProtection.Keys](https://www.nuget.org/packages/Azure.Extensions.AspNetCore.DataProtection.Keys). These packages are where new updates are provided, and address some key security and stability issues with the older packages.

```csharp
services.AddDataProtection()
    //This blob must already exist before the application is run
    .PersistKeysToAzureBlobStorage("<storage account connection string", "<key store container name>", "<key store blob name>")
    //Removing this line below for an initial run will ensure the file is created correctly
    .ProtectKeysWithAzureKeyVault(new Uri("<keyIdentifier>"), new DefaultAzureCredential());
```

## PersistKeysToFileSystem

To store keys on a UNC share instead of at the *%LOCALAPPDATA%* default location, configure the system with <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.PersistKeysToFileSystem%2A>:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDataProtection()
        .PersistKeysToFileSystem(new DirectoryInfo(@"\\server\share\directory\"));
}
```

> [!WARNING]
> If you change the key persistence location, the system no longer automatically encrypts keys at rest, since it doesn't know whether DPAPI is an appropriate encryption mechanism.

## PersistKeysToDbContext

To store keys in a database using EntityFramework, configure the system with the [Microsoft.AspNetCore.DataProtection.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.AspNetCore.DataProtection.EntityFrameworkCore/) package:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDataProtection()
        .PersistKeysToDbContext<DbContext>()
}
```

The preceding code stores the keys in the configured database. The database context being used must implement `IDataProtectionKeyContext`.  `IDataProtectionKeyContext` exposes the property `DataProtectionKeys` 

```csharp
public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }
```

This property represents the table in which the keys are stored. Create the table manually or with `DbContext` Migrations. For more information, see <xref:Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.DataProtectionKey>.

## ProtectKeysWith\*

You can configure the system to protect keys at rest by calling any of the [ProtectKeysWith\*](xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions) configuration APIs. Consider the example below, which stores keys on a UNC share and encrypts those keys at rest with a specific X.509 certificate:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDataProtection()
        .PersistKeysToFileSystem(new DirectoryInfo(@"\\server\share\directory\"))
        .ProtectKeysWithCertificate(Configuration["Thumbprint"]);
}
```

You can provide an <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> to <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.ProtectKeysWithCertificate%2A>, such as a certificate loaded from a file:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDataProtection()
        .PersistKeysToFileSystem(new DirectoryInfo(@"\\server\share\directory\"))
        .ProtectKeysWithCertificate(
            new X509Certificate2("certificate.pfx", Configuration["Thumbprint"]));
}
```

See [Key Encryption At Rest](xref:security/data-protection/implementation/key-encryption-at-rest) for more examples and discussion on the built-in key encryption mechanisms.

## UnprotectKeysWithAnyCertificate

You can rotate certificates and decrypt keys at rest using an array of <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> certificates with <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.UnprotectKeysWithAnyCertificate%2A>:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDataProtection()
        .PersistKeysToFileSystem(new DirectoryInfo(@"\\server\share\directory\"))
        .ProtectKeysWithCertificate(
            new X509Certificate2("certificate.pfx", Configuration["MyPasswordKey"));
        .UnprotectKeysWithAnyCertificate(
            new X509Certificate2("certificate_old_1.pfx", Configuration["MyPasswordKey_1"]),
            new X509Certificate2("certificate_old_2.pfx", Configuration["MyPasswordKey_2"]));
}
```

## SetDefaultKeyLifetime

To configure the system to use a key lifetime of 14 days instead of the default 90 days, use <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.SetDefaultKeyLifetime%2A>:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDataProtection()
        .SetDefaultKeyLifetime(TimeSpan.FromDays(14));
}
```

## SetApplicationName

By default, the Data Protection system isolates apps from one another based on their [content root](xref:fundamentals/index#content-root) paths, even if they share the same physical key repository. This isolation prevents the apps from understanding each other's protected payloads.

To share protected payloads among apps:

* Configure <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.SetApplicationName%2A> in each app with the same value.
* Use the same version of the Data Protection API stack across the apps. Perform **either** of the following in the apps' project files:
  * Reference the same shared framework version via the [Microsoft.AspNetCore.App metapackage](xref:fundamentals/metapackage-app).
  * Reference the same [Data Protection package](xref:security/data-protection/introduction#package-layout) version.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDataProtection()
        .SetApplicationName("shared app name");
}
```

## DisableAutomaticKeyGeneration

You may have a scenario where you don't want an app to automatically roll keys (create new keys) as they approach expiration. One example of this scenario might be apps set up in a primary/secondary relationship, where only the primary app is responsible for key management concerns and secondary apps simply have a read-only view of the key ring. The secondary apps can be configured to treat the key ring as read-only by configuring the system with <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.DisableAutomaticKeyGeneration%2A>:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDataProtection()
        .DisableAutomaticKeyGeneration();
}
```

## Per-application isolation

When the Data Protection system is provided by an ASP.NET Core host, it automatically isolates apps from one another, even if those apps are running under the same worker process account and are using the same master keying material. This is similar to the IsolateApps modifier from System.Web's `<machineKey>` element.

The isolation mechanism works by considering each app on the local machine as a unique tenant, thus the <xref:Microsoft.AspNetCore.DataProtection.IDataProtector> rooted for any given app automatically includes the app ID as a discriminator. The app's unique ID is the app's physical path:

* For apps hosted in IIS, the unique ID is the IIS physical path of the app. If an app is deployed in a web farm environment, this value is stable assuming that the IIS environments are configured similarly across all machines in the web farm.
* For self-hosted apps running on the [Kestrel server](xref:fundamentals/servers/index#kestrel), the unique ID is the physical path to the app on disk.

The unique identifier is designed to survive resets&mdash;both of the individual app and of the machine itself.

This isolation mechanism assumes that the apps aren't malicious. A malicious app can always impact any other app running under the same worker process account. In a shared hosting environment where apps are mutually untrusted, the hosting provider should take steps to ensure OS-level isolation between apps, including separating the apps' underlying key repositories.

If the Data Protection system isn't provided by an ASP.NET Core host (for example, if you instantiate it via the `DataProtectionProvider` concrete type) app isolation is disabled by default. When app isolation is disabled, all apps backed by the same keying material can share payloads as long as they provide the appropriate [purposes](xref:security/data-protection/consumer-apis/purpose-strings). To provide app isolation in this environment, call the [SetApplicationName](#setapplicationname) method on the configuration object and provide a unique name for each app.

### Data Protection and app isolation

Consider the following points for app isolation:

* When multiple apps are pointed at the same key repository, the intention is that the apps share the same master key material. Data Protection is developed with the assumption that all apps sharing a key ring can access all items in that key ring. The application unique identifier is used to isolate application specific keys derived from the key ring provided keys. It doesn't expect item level permissions, such as those provided by Azure KeyVault to be used to enforce extra isolation. Attempting item level permissions generates application errors. If you don't want to rely on the built-in application isolation, separate key store locations should be used and not shared between applications.

* The application discriminator is used to allow different apps to share the same master key material but to keep their cryptographic payloads distinct from one another. <!-- The docs already draw an analogy between this and multi-tenancy.--> For the apps to be able to read each other's cryptographic payloads, they must have the same application discriminator.

* If an app is compromised (for example, by an RCE attack), all master key material accessible to that app must also be considered compromised, regardless of its protection-at-rest state. This implies that if two apps are pointed at the same repository, even if they use different app discriminators, a compromise of one is functionally equivalent to a compromise of both.

  This "functionally equivalent to a compromise of both" clause holds even if the two apps use different mechanisms for key protection at rest. Typically, this isn't an expected configuration. The protection-at-rest mechanism is intended to provide protection in the event an adversary gains read access to the repository. An adversary who gains write access to the repository (perhaps because they attained code execution permission within an app) can insert malicious keys into storage. The Data Protection system intentionally doesn't provide protection against an adversary who gains write access to the key repository.

* If apps need to remain truly isolated from one another, they should use different key repositories. This naturally falls out of the definition of "isolated". Apps are ***not*** isolated if they all have Read and Write access to each other's data stores.

## Changing algorithms with UseCryptographicAlgorithms

The Data Protection stack allows you to change the default algorithm used by newly generated keys. The simplest way to do this is to call <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.UseCryptographicAlgorithms%2A> from the configuration callback:

```csharp
services.AddDataProtection()
    .UseCryptographicAlgorithms(
        new AuthenticatedEncryptorConfiguration()
    {
        EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
        ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
    });
```

The default EncryptionAlgorithm is AES-256-CBC, and the default ValidationAlgorithm is HMACSHA256. The default policy can be set by a system administrator via a [machine-wide policy](xref:security/data-protection/configuration/machine-wide-policy), but an explicit call to `UseCryptographicAlgorithms` overrides the default policy.

Calling `UseCryptographicAlgorithms` allows you to specify the desired algorithm from a predefined built-in list. You don't need to worry about the implementation of the algorithm. In the scenario above, the Data Protection system attempts to use the CNG implementation of AES if running on Windows. Otherwise, it falls back to the managed <xref:System.Security.Cryptography.Aes?displayProperty=fullName> class.

You can manually specify an implementation via a call to <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.UseCustomCryptographicAlgorithms%2A>.

> [!TIP]
> Changing algorithms doesn't affect existing keys in the key ring. It only affects newly-generated keys.

### Specifying custom managed algorithms

To specify custom managed algorithms, create a <xref:Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorConfiguration> instance that points to the implementation types:

```csharp
serviceCollection.AddDataProtection()
    .UseCustomCryptographicAlgorithms(
        new ManagedAuthenticatedEncryptorConfiguration()
    {
        // A type that subclasses SymmetricAlgorithm
        EncryptionAlgorithmType = typeof(Aes),

        // Specified in bits
        EncryptionAlgorithmKeySize = 256,

        // A type that subclasses KeyedHashAlgorithm
        ValidationAlgorithmType = typeof(HMACSHA256)
    });
```

Generally the \*Type properties must point to concrete, instantiable (via a public parameterless ctor) implementations of <xref:System.Security.Cryptography.SymmetricAlgorithm> and <xref:System.Security.Cryptography.KeyedHashAlgorithm>, though the system special-cases some values like `typeof(Aes)` for convenience.

> [!NOTE]
> The SymmetricAlgorithm must have a key length of ≥ 128 bits and a block size of ≥ 64 bits, and it must support CBC-mode encryption with PKCS #7 padding. The KeyedHashAlgorithm must have a digest size of >= 128 bits, and it must support keys of length equal to the hash algorithm's digest length. The KeyedHashAlgorithm isn't strictly required to be HMAC.

### Specifying custom Windows CNG algorithms

To specify a custom Windows CNG algorithm using CBC-mode encryption with HMAC validation, create a <xref:Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngCbcAuthenticatedEncryptorConfiguration> instance that contains the algorithmic information:

```csharp
services.AddDataProtection()
    .UseCustomCryptographicAlgorithms(
        new CngCbcAuthenticatedEncryptorConfiguration()
    {
        // Passed to BCryptOpenAlgorithmProvider
        EncryptionAlgorithm = "AES",
        EncryptionAlgorithmProvider = null,

        // Specified in bits
        EncryptionAlgorithmKeySize = 256,

        // Passed to BCryptOpenAlgorithmProvider
        HashAlgorithm = "SHA256",
        HashAlgorithmProvider = null
    });
```

> [!NOTE]
> The symmetric block cipher algorithm must have a key length of >= 128 bits, a block size of >= 64 bits, and it must support CBC-mode encryption with PKCS #7 padding. The hash algorithm must have a digest size of >= 128 bits and must support being opened with the BCRYPT\_ALG\_HANDLE\_HMAC\_FLAG flag. The \*Provider properties can be set to null to use the default provider for the specified algorithm. For more information, see the [BCryptOpenAlgorithmProvider](/windows/win32/api/bcrypt/nf-bcrypt-bcryptopenalgorithmprovider) documentation.

To specify a custom Windows CNG algorithm using Galois/Counter Mode encryption with validation, create a <xref:Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngGcmAuthenticatedEncryptorConfiguration> instance that contains the algorithmic information:

```csharp
services.AddDataProtection()
    .UseCustomCryptographicAlgorithms(
        new CngGcmAuthenticatedEncryptorConfiguration()
    {
        // Passed to BCryptOpenAlgorithmProvider
        EncryptionAlgorithm = "AES",
        EncryptionAlgorithmProvider = null,

        // Specified in bits
        EncryptionAlgorithmKeySize = 256
    });
```

> [!NOTE]
> The symmetric block cipher algorithm must have a key length of >= 128 bits, a block size of exactly 128 bits, and it must support GCM encryption. You can set the <xref:Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngCbcAuthenticatedEncryptorConfiguration.EncryptionAlgorithmProvider> property to null to use the default provider for the specified algorithm. For more information, see the [BCryptOpenAlgorithmProvider](/windows/win32/api/bcrypt/nf-bcrypt-bcryptopenalgorithmprovider) documentation.

### Specifying other custom algorithms

Though not exposed as a first-class API, the Data Protection system is extensible enough to allow specifying almost any kind of algorithm. For example, it's possible to keep all keys contained within a Hardware Security Module (HSM) and to provide a custom implementation of the core encryption and decryption routines. For more information, see <xref:Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor> in [Core cryptography extensibility](xref:security/data-protection/extensibility/core-crypto).

## Persisting keys when hosting in a Docker container

When hosting in a [Docker](/dotnet/standard/microservices-architecture/container-docker-introduction/) container, keys should be maintained in either:

* A folder that's a Docker volume that persists beyond the container's lifetime, such as a shared volume or a host-mounted volume.
* An external provider, such as [Azure Blob Storage](/azure/storage/blobs/storage-blobs-introduction) (shown in the [`ProtectKeysWithAzureKeyVault`](#protectkeyswithazurekeyvault) section) or [Redis](https://redis.io).

## Persisting keys with Redis

Only Redis versions supporting [Redis Data Persistence](/azure/azure-cache-for-redis/cache-how-to-premium-persistence) should be used to store keys. [Azure Blob storage](/azure/storage/blobs/storage-blobs-introduction) is persistent and can be used to store keys. For more information, see [this GitHub issue](https://github.com/dotnet/AspNetCore/issues/13476).

## Logging DataProtection

Enable `Information` level logging of DataProtection to help diagnosis problem. The following `appsettings.json` file enables information logging of the DataProtection API:

```JSON
{
  "Logging": {
    "LogLevel": {
      "Microsoft.AspNetCore.DataProtection": "Information"
    }
  }
}
```

For more information on logging, see [Logging in .NET Core and ASP.NET Core](xref:fundamentals/logging/index).

## Additional resources

* <xref:security/data-protection/configuration/non-di-scenarios>
* <xref:security/data-protection/configuration/machine-wide-policy>
* <xref:host-and-deploy/web-farm>
* <xref:security/data-protection/implementation/key-storage-providers>

:::moniker-end
