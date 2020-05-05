---
title: Configure ASP.NET Core Data Protection
author: rick-anderson
description: Learn how to configure Data Protection in ASP.NET Core.
ms.author: riande
ms.custom: mvc
ms.date: 10/07/2019
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/data-protection/configuration/overview
---
# Configure ASP.NET Core Data Protection

When the Data Protection system is initialized, it applies [default settings](xref:security/data-protection/configuration/default-settings) based on the operational environment. These settings are generally appropriate for apps running on a single machine. There are cases where a developer may want to change the default settings:

* The app is spread across multiple machines.
* For compliance reasons.

For these scenarios, the Data Protection system offers a rich configuration API.

> [!WARNING]
> Similar to configuration files, the data protection key ring should be protected using appropriate permissions. You can choose to encrypt keys at rest, but this doesn't prevent attackers from creating new keys. Consequently, your app's security is impacted. The storage location configured with Data Protection should have its access limited to the app itself, similar to the way you would protect configuration files. For example, if you choose to store your key ring on disk, use file system permissions. Ensure only the identity under which your web app runs has read, write, and create access to that directory. If you use Azure Blob Storage, only the web app should have the ability to read, write, or create new entries in the blob store, etc.
>
> The extension method [AddDataProtection](/dotnet/api/microsoft.extensions.dependencyinjection.dataprotectionservicecollectionextensions.adddataprotection) returns an [IDataProtectionBuilder](/dotnet/api/microsoft.aspnetcore.dataprotection.idataprotectionbuilder). `IDataProtectionBuilder` exposes extension methods that you can chain together to configure Data Protection options.

::: moniker range=">= aspnetcore-3.0"

The following NuGet packages are required for the Data Protection extensions used in this article:

* [Microsoft.AspNetCore.DataProtection.AzureStorage](https://www.nuget.org/packages/Microsoft.AspNetCore.DataProtection.AzureStorage/)
* [Microsoft.AspNetCore.DataProtection.AzureKeyVault](https://www.nuget.org/packages/Microsoft.AspNetCore.DataProtection.AzureKeyVault/)

::: moniker-end

::: moniker range=">= aspnetcore-2.1"

## ProtectKeysWithAzureKeyVault

To store keys in [Azure Key Vault](https://azure.microsoft.com/services/key-vault/), configure the system with [ProtectKeysWithAzureKeyVault](/dotnet/api/microsoft.aspnetcore.dataprotection.azuredataprotectionbuilderextensions.protectkeyswithazurekeyvault) in the `Startup` class:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDataProtection()
        .PersistKeysToAzureBlobStorage(new Uri("<blobUriWithSasToken>"))
        .ProtectKeysWithAzureKeyVault("<keyIdentifier>", "<clientId>", "<clientSecret>");
}
```

Set the key ring storage location (for example, [PersistKeysToAzureBlobStorage](/dotnet/api/microsoft.aspnetcore.dataprotection.azuredataprotectionbuilderextensions.persistkeystoazureblobstorage)). The location must be set because calling `ProtectKeysWithAzureKeyVault` implements an [IXmlEncryptor](/dotnet/api/microsoft.aspnetcore.dataprotection.xmlencryption.ixmlencryptor) that disables automatic data protection settings, including the key ring storage location. The preceding example uses Azure Blob Storage to persist the key ring. For more information, see [Key storage providers: Azure Storage](xref:security/data-protection/implementation/key-storage-providers#azure-storage). You can also persist the key ring locally with [PersistKeysToFileSystem](xref:security/data-protection/implementation/key-storage-providers#file-system).

The `keyIdentifier` is the key vault key identifier used for key encryption. For example, a key created in key vault named `dataprotection` in the `contosokeyvault` has the key identifier `https://contosokeyvault.vault.azure.net/keys/dataprotection/`. Provide the app with **Unwrap Key** and **Wrap Key** permissions to the key vault.

`ProtectKeysWithAzureKeyVault` overloads:

* [ProtectKeysWithAzureKeyVault(IDataProtectionBuilder, KeyVaultClient, String)](/dotnet/api/microsoft.aspnetcore.dataprotection.azuredataprotectionbuilderextensions.protectkeyswithazurekeyvault#Microsoft_AspNetCore_DataProtection_AzureDataProtectionBuilderExtensions_ProtectKeysWithAzureKeyVault_Microsoft_AspNetCore_DataProtection_IDataProtectionBuilder_Microsoft_Azure_KeyVault_KeyVaultClient_System_String_) permits the use of a [KeyVaultClient](/dotnet/api/microsoft.azure.keyvault.keyvaultclient) to enable the data protection system to use the key vault.
* [ProtectKeysWithAzureKeyVault(IDataProtectionBuilder, String, String, X509Certificate2)](/dotnet/api/microsoft.aspnetcore.dataprotection.azuredataprotectionbuilderextensions.protectkeyswithazurekeyvault#Microsoft_AspNetCore_DataProtection_AzureDataProtectionBuilderExtensions_ProtectKeysWithAzureKeyVault_Microsoft_AspNetCore_DataProtection_IDataProtectionBuilder_System_String_System_String_System_Security_Cryptography_X509Certificates_X509Certificate2_) permits the use of a `ClientId` and [X509Certificate](/dotnet/api/system.security.cryptography.x509certificates.x509certificate2) to enable the data protection system to use the key vault.
* [ProtectKeysWithAzureKeyVault(IDataProtectionBuilder, String, String, String)](/dotnet/api/microsoft.aspnetcore.dataprotection.azuredataprotectionbuilderextensions.protectkeyswithazurekeyvault#Microsoft_AspNetCore_DataProtection_AzureDataProtectionBuilderExtensions_ProtectKeysWithAzureKeyVault_Microsoft_AspNetCore_DataProtection_IDataProtectionBuilder_System_String_System_String_System_String_) permits the use of a `ClientId` and `ClientSecret` to enable the data protection system to use the key vault.

::: moniker-end

## PersistKeysToFileSystem

To store keys on a UNC share instead of at the *%LOCALAPPDATA%* default location, configure the system with [PersistKeysToFileSystem](/dotnet/api/microsoft.aspnetcore.dataprotection.dataprotectionbuilderextensions.persistkeystofilesystem):

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDataProtection()
        .PersistKeysToFileSystem(new DirectoryInfo(@"\\server\share\directory\"));
}
```

> [!WARNING]
> If you change the key persistence location, the system no longer automatically encrypts keys at rest, since it doesn't know whether DPAPI is an appropriate encryption mechanism.

## ProtectKeysWith\*

You can configure the system to protect keys at rest by calling any of the [ProtectKeysWith\*](/dotnet/api/microsoft.aspnetcore.dataprotection.dataprotectionbuilderextensions) configuration APIs. Consider the example below, which stores keys on a UNC share and encrypts those keys at rest with a specific X.509 certificate:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDataProtection()
        .PersistKeysToFileSystem(new DirectoryInfo(@"\\server\share\directory\"))
        .ProtectKeysWithCertificate("thumbprint");
}
```

::: moniker range=">= aspnetcore-2.1"

In ASP.NET Core 2.1 or later, you can provide an [X509Certificate2](/dotnet/api/system.security.cryptography.x509certificates.x509certificate2) to [ProtectKeysWithCertificate](/dotnet/api/microsoft.aspnetcore.dataprotection.dataprotectionbuilderextensions.protectkeyswithcertificate), such as a certificate loaded from a file:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDataProtection()
        .PersistKeysToFileSystem(new DirectoryInfo(@"\\server\share\directory\"))
        .ProtectKeysWithCertificate(
            new X509Certificate2("certificate.pfx", "password"));
}
```

::: moniker-end

See [Key Encryption At Rest](xref:security/data-protection/implementation/key-encryption-at-rest) for more examples and discussion on the built-in key encryption mechanisms.

::: moniker range=">= aspnetcore-2.1"

## UnprotectKeysWithAnyCertificate

In ASP.NET Core 2.1 or later, you can rotate certificates and decrypt keys at rest using an array of [X509Certificate2](/dotnet/api/system.security.cryptography.x509certificates.x509certificate2) certificates with [UnprotectKeysWithAnyCertificate](/dotnet/api/microsoft.aspnetcore.dataprotection.dataprotectionbuilderextensions.unprotectkeyswithanycertificate):

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDataProtection()
        .PersistKeysToFileSystem(new DirectoryInfo(@"\\server\share\directory\"))
        .ProtectKeysWithCertificate(
            new X509Certificate2("certificate.pfx", "password"));
        .UnprotectKeysWithAnyCertificate(
            new X509Certificate2("certificate_old_1.pfx", "password_1"),
            new X509Certificate2("certificate_old_2.pfx", "password_2"));
}
```

::: moniker-end

## SetDefaultKeyLifetime

To configure the system to use a key lifetime of 14 days instead of the default 90 days, use [SetDefaultKeyLifetime](/dotnet/api/microsoft.aspnetcore.dataprotection.dataprotectionbuilderextensions.setdefaultkeylifetime):

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDataProtection()
        .SetDefaultKeyLifetime(TimeSpan.FromDays(14));
}
```

## SetApplicationName

By default, the Data Protection system isolates apps from one another based on their [content root](xref:fundamentals/index#content-root) paths, even if they're sharing the same physical key repository. This prevents the apps from understanding each other's protected payloads.

To share protected payloads among apps:

* Configure <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.SetApplicationName*> in each app with the same value.
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

You may have a scenario where you don't want an app to automatically roll keys (create new keys) as they approach expiration. One example of this might be apps set up in a primary/secondary relationship, where only the primary app is responsible for key management concerns and secondary apps simply have a read-only view of the key ring. The secondary apps can be configured to treat the key ring as read-only by configuring the system with <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.DisableAutomaticKeyGeneration*>:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDataProtection()
        .DisableAutomaticKeyGeneration();
}
```

## Per-application isolation

When the Data Protection system is provided by an ASP.NET Core host, it automatically isolates apps from one another, even if those apps are running under the same worker process account and are using the same master keying material. This is somewhat similar to the IsolateApps modifier from System.Web's `<machineKey>` element.

The isolation mechanism works by considering each app on the local machine as a unique tenant, thus the <xref:Microsoft.AspNetCore.DataProtection.IDataProtector> rooted for any given app automatically includes the app ID as a discriminator. The app's unique ID is the app's physical path:

* For apps hosted in IIS, the unique ID is the IIS physical path of the app. If an app is deployed in a web farm environment, this value is stable assuming that the IIS environments are configured similarly across all machines in the web farm.
* For self-hosted apps running on the [Kestrel server](xref:fundamentals/servers/index#kestrel), the unique ID is the physical path to the app on disk.

The unique identifier is designed to survive resets&mdash;both of the individual app and of the machine itself.

This isolation mechanism assumes that the apps are not malicious. A malicious app can always impact any other app running under the same worker process account. In a shared hosting environment where apps are mutually untrusted, the hosting provider should take steps to ensure OS-level isolation between apps, including separating the apps' underlying key repositories.

If the Data Protection system isn't provided by an ASP.NET Core host (for example, if you instantiate it via the `DataProtectionProvider` concrete type) app isolation is disabled by default. When app isolation is disabled, all apps backed by the same keying material can share payloads as long as they provide the appropriate [purposes](xref:security/data-protection/consumer-apis/purpose-strings). To provide app isolation in this environment, call the [SetApplicationName](#setapplicationname) method on the configuration object and provide a unique name for each app.

## Changing algorithms with UseCryptographicAlgorithms

The Data Protection stack allows you to change the default algorithm used by newly-generated keys. The simplest way to do this is to call [UseCryptographicAlgorithms](/dotnet/api/microsoft.aspnetcore.dataprotection.dataprotectionbuilderextensions.usecryptographicalgorithms) from the configuration callback:

::: moniker range=">= aspnetcore-2.0"

```csharp
services.AddDataProtection()
    .UseCryptographicAlgorithms(
        new AuthenticatedEncryptorConfiguration()
    {
        EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
        ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
    });
```

::: moniker-end

::: moniker range="< aspnetcore-2.0"

```csharp
services.AddDataProtection()
    .UseCryptographicAlgorithms(
        new AuthenticatedEncryptionSettings()
    {
        EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
        ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
    });
```

::: moniker-end

The default EncryptionAlgorithm is AES-256-CBC, and the default ValidationAlgorithm is HMACSHA256. The default policy can be set by a system administrator via a [machine-wide policy](xref:security/data-protection/configuration/machine-wide-policy), but an explicit call to `UseCryptographicAlgorithms` overrides the default policy.

Calling `UseCryptographicAlgorithms` allows you to specify the desired algorithm from a predefined built-in list. You don't need to worry about the implementation of the algorithm. In the scenario above, the Data Protection system attempts to use the CNG implementation of AES if running on Windows. Otherwise, it falls back to the managed [System.Security.Cryptography.Aes](/dotnet/api/system.security.cryptography.aes) class.

You can manually specify an implementation via a call to [UseCustomCryptographicAlgorithms](/dotnet/api/microsoft.aspnetcore.dataprotection.dataprotectionbuilderextensions.usecustomcryptographicalgorithms).

> [!TIP]
> Changing algorithms doesn't affect existing keys in the key ring. It only affects newly-generated keys.

### Specifying custom managed algorithms

::: moniker range=">= aspnetcore-2.0"

To specify custom managed algorithms, create a [ManagedAuthenticatedEncryptorConfiguration](/dotnet/api/microsoft.aspnetcore.dataprotection.authenticatedencryption.configurationmodel.managedauthenticatedencryptorconfiguration) instance that points to the implementation types:

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

::: moniker-end

::: moniker range="< aspnetcore-2.0"

To specify custom managed algorithms, create a [ManagedAuthenticatedEncryptionSettings](/dotnet/api/microsoft.aspnetcore.dataprotection.authenticatedencryption.managedauthenticatedencryptionsettings) instance that points to the implementation types:

```csharp
serviceCollection.AddDataProtection()
    .UseCustomCryptographicAlgorithms(
        new ManagedAuthenticatedEncryptionSettings()
    {
        // A type that subclasses SymmetricAlgorithm
        EncryptionAlgorithmType = typeof(Aes),

        // Specified in bits
        EncryptionAlgorithmKeySize = 256,

        // A type that subclasses KeyedHashAlgorithm
        ValidationAlgorithmType = typeof(HMACSHA256)
    });
```

::: moniker-end

Generally the \*Type properties must point to concrete, instantiable (via a public parameterless ctor) implementations of [SymmetricAlgorithm](/dotnet/api/system.security.cryptography.symmetricalgorithm) and [KeyedHashAlgorithm](/dotnet/api/system.security.cryptography.keyedhashalgorithm), though the system special-cases some values like `typeof(Aes)` for convenience.

> [!NOTE]
> The SymmetricAlgorithm must have a key length of ≥ 128 bits and a block size of ≥ 64 bits, and it must support CBC-mode encryption with PKCS #7 padding. The KeyedHashAlgorithm must have a digest size of >= 128 bits, and it must support keys of length equal to the hash algorithm's digest length. The KeyedHashAlgorithm isn't strictly required to be HMAC.

### Specifying custom Windows CNG algorithms

::: moniker range=">= aspnetcore-2.0"

To specify a custom Windows CNG algorithm using CBC-mode encryption with HMAC validation, create a [CngCbcAuthenticatedEncryptorConfiguration](/dotnet/api/microsoft.aspnetcore.dataprotection.authenticatedencryption.configurationmodel.cngcbcauthenticatedencryptorconfiguration) instance that contains the algorithmic information:

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

::: moniker-end

::: moniker range="< aspnetcore-2.0"

To specify a custom Windows CNG algorithm using CBC-mode encryption with HMAC validation, create a [CngCbcAuthenticatedEncryptionSettings](/dotnet/api/microsoft.aspnetcore.dataprotection.authenticatedencryption.cngcbcauthenticatedencryptionsettings) instance that contains the algorithmic information:

```csharp
services.AddDataProtection()
    .UseCustomCryptographicAlgorithms(
        new CngCbcAuthenticatedEncryptionSettings()
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

::: moniker-end

> [!NOTE]
> The symmetric block cipher algorithm must have a key length of >= 128 bits, a block size of >= 64 bits, and it must support CBC-mode encryption with PKCS #7 padding. The hash algorithm must have a digest size of >= 128 bits and must support being opened with the BCRYPT\_ALG\_HANDLE\_HMAC\_FLAG flag. The \*Provider properties can be set to null to use the default provider for the specified algorithm. See the [BCryptOpenAlgorithmProvider](https://msdn.microsoft.com/library/windows/desktop/aa375479(v=vs.85).aspx) documentation for more information.

::: moniker range=">= aspnetcore-2.0"

To specify a custom Windows CNG algorithm using Galois/Counter Mode encryption with validation, create a [CngGcmAuthenticatedEncryptorConfiguration](/dotnet/api/microsoft.aspnetcore.dataprotection.authenticatedencryption.configurationmodel.cnggcmauthenticatedencryptorconfiguration) instance that contains the algorithmic information:

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

::: moniker-end

::: moniker range="< aspnetcore-2.0"

To specify a custom Windows CNG algorithm using Galois/Counter Mode encryption with validation, create a [CngGcmAuthenticatedEncryptionSettings](/dotnet/api/microsoft.aspnetcore.dataprotection.authenticatedencryption.cnggcmauthenticatedencryptionsettings) instance that contains the algorithmic information:

```csharp
services.AddDataProtection()
    .UseCustomCryptographicAlgorithms(
        new CngGcmAuthenticatedEncryptionSettings()
    {
        // Passed to BCryptOpenAlgorithmProvider
        EncryptionAlgorithm = "AES",
        EncryptionAlgorithmProvider = null,

        // Specified in bits
        EncryptionAlgorithmKeySize = 256
    });
```

::: moniker-end

> [!NOTE]
> The symmetric block cipher algorithm must have a key length of >= 128 bits, a block size of exactly 128 bits, and it must support GCM encryption. You can set the [EncryptionAlgorithmProvider](/dotnet/api/microsoft.aspnetcore.dataprotection.authenticatedencryption.configurationmodel.cngcbcauthenticatedencryptorconfiguration.encryptionalgorithmprovider) property to null to use the default provider for the specified algorithm. See the [BCryptOpenAlgorithmProvider](https://msdn.microsoft.com/library/windows/desktop/aa375479(v=vs.85).aspx) documentation for more information.

### Specifying other custom algorithms

Though not exposed as a first-class API, the Data Protection system is extensible enough to allow specifying almost any kind of algorithm. For example, it's possible to keep all keys contained within a Hardware Security Module (HSM) and to provide a custom implementation of the core encryption and decryption routines. See [IAuthenticatedEncryptor](/dotnet/api/microsoft.aspnetcore.dataprotection.authenticatedencryption.iauthenticatedencryptor) in [Core cryptography extensibility](xref:security/data-protection/extensibility/core-crypto) for more information.

## Persisting keys when hosting in a Docker container

When hosting in a [Docker](/dotnet/standard/microservices-architecture/container-docker-introduction/) container, keys should be maintained in either:

* A folder that's a Docker volume that persists beyond the container's lifetime, such as a shared volume or a host-mounted volume.
* An external provider, such as [Azure Key Vault](https://azure.microsoft.com/services/key-vault/) or [Redis](https://redis.io/).

## Persisting keys with Redis

Only Redis versions supporting [Redis Data Persistence](/azure/azure-cache-for-redis/cache-how-to-premium-persistence) should be used to store keys. [Azure Blob storage](/azure/storage/blobs/storage-blobs-introduction) is persistent and can be used to store keys. For more information, see [this GitHub issue](https://github.com/dotnet/AspNetCore/issues/13476).

## Additional resources

* <xref:security/data-protection/configuration/non-di-scenarios>
* <xref:security/data-protection/configuration/machine-wide-policy>
* <xref:host-and-deploy/web-farm>
* <xref:security/data-protection/implementation/key-storage-providers>
