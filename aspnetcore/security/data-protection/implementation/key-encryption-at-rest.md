---
title: Key encryption at rest in Windows and Azure using ASP.NET Core
author: rick-anderson
description: Learn implementation details of ASP.NET Core Data Protection key encryption at rest.
ms.author: riande
$106/24/2025
uid: security/data-protection/implementation/key-encryption-at-rest
---
# Key encryption at rest in Windows and Azure using ASP.NET Core

The data protection system [employs a discovery mechanism by default](xref:security/data-protection/configuration/default-settings) to determine how cryptographic keys should be encrypted at rest. The developer can override the discovery mechanism and manually specify how keys should be encrypted at rest.

> [!WARNING]
> If you specify an explicit [key persistence location](xref:security/data-protection/implementation/key-storage-providers), the data protection system deregisters the default key encryption at rest mechanism. Consequently, keys are no longer encrypted at rest. We recommend that you [specify an explicit key encryption mechanism](xref:security/data-protection/implementation/key-encryption-at-rest) for production deployments. The encryption-at-rest mechanism options are described in this topic.

:::moniker range=">= aspnetcore-2.1"

## Azure Key Vault

For more information, see <xref:security/data-protection/configuration/overview#protect-keys-with-azure-key-vault-protectkeyswithazurekeyvault>.

:::moniker-end

## Windows DPAPI

**Only applies to Windows deployments.**

When Windows DPAPI is used, key material is encrypted with [CryptProtectData](/windows/desktop/api/dpapi/nf-dpapi-cryptprotectdata) before being persisted to storage. DPAPI is an appropriate encryption mechanism for data that's never read outside of the current machine (though it's possible to back these keys up to Active Directory). To configure DPAPI key-at-rest encryption, call one of the <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.ProtectKeysWithDpapi%2A>) extension methods:

```csharp
// Only the local user account can decrypt the keys
services.AddDataProtection()
    .ProtectKeysWithDpapi();
```

If `ProtectKeysWithDpapi` is called with no parameters, only the current Windows user account can decipher the persisted key ring. You can optionally specify that any user account on the machine (not just the current user account) be able to decipher the key ring:

```csharp
// All user accounts on the machine can decrypt the keys
services.AddDataProtection()
    .ProtectKeysWithDpapi(protectToLocalMachine: true);
```

:::moniker range=">= aspnetcore-2.0"

## X.509 certificate

If the app is spread across multiple machines, it may be convenient to distribute a shared X.509 certificate (`.pfx` format) across the machines and configure the hosted apps to use the certificate for encryption of keys at rest.

In the following example, the certificate's thumbprint is passed to <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.ProtectKeysWithCertificate%2A>:

```csharp
services.AddDataProtection()
    .ProtectKeysWithCertificate("{CERTIFICATE THUMBPRINT}");
```

In the following example, an <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> is passed to <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.ProtectKeysWithCertificate%2A>:

```csharp
var cert = new X509Certificate2(...);

services.AddDataProtection()
    .ProtectKeysWithCertificate(cert);
```

To create the certificate, use one of the following approaches or any other suitable tool or online service:

* [`dotnet dev-certs` command](/dotnet/core/tools/dotnet-dev-certs)
* [`New-SelfSignedCertificate` PowerShell command](/powershell/module/pki/new-selfsignedcertificate)
* [Azure Key Vault](/azure/key-vault/certificates/quick-create-portal#add-a-certificate-to-key-vault)
* [MakeCert on Windows](/windows/desktop/seccrypto/makecert)
* [OpenSSL](https://www.openssl.org)

For more information, see [Generate self-signed certificates with the .NET CLI](/dotnet/core/additional-tools/self-signed-certificates-guide).

Due to .NET Framework limitations, only certificates with CAPI private keys are supported. See the content below for possible workarounds to these limitations.

:::moniker-end

## Windows DPAPI-NG

**This mechanism is available only on Windows 8/Windows Server 2012 or later.**

Beginning with Windows 8, Windows OS supports DPAPI-NG (also called CNG DPAPI). For more information, see [About CNG DPAPI](/windows/desktop/SecCNG/cng-dpapi).

The principal is encoded as a protection descriptor rule. In the following example that calls <xref:Microsoft.AspNetCore.DataProtection.DataProtectionBuilderExtensions.ProtectKeysWithDpapiNG%2A>, only the domain-joined user with the specified SID can decrypt the key ring:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // Uses the descriptor rule "SID=S-1-5-21-..."
    services.AddDataProtection()
        .ProtectKeysWithDpapiNG("SID=S-1-5-21-...",
        flags: DpapiNGProtectionDescriptorFlags.None);
}
```

There's also a parameterless overload of `ProtectKeysWithDpapiNG`. Use this convenience method to specify the rule "SID={CURRENT_ACCOUNT_SID}", where *CURRENT_ACCOUNT_SID* is the SID of the current Windows user account:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // Use the descriptor rule "SID={current account SID}"
    services.AddDataProtection()
        .ProtectKeysWithDpapiNG();
}
```

In this scenario, the AD domain controller is responsible for distributing the encryption keys used by the DPAPI-NG operations. The target user can decipher the encrypted payload from any domain-joined machine (provided that the process is running under their identity).

## Certificate-based encryption with Windows DPAPI-NG

If the app is running on Windows 8.1/Windows Server 2012 R2 or later, you can use Windows DPAPI-NG to perform certificate-based encryption. Use the rule descriptor string "CERTIFICATE=HashId:{CERTIFICATE THUMBPRINT}", where the `{CERTIFICATE THUMBPRINT}` placeholder is the hex-encoded SHA1 thumbprint of the certificate:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDataProtection()
        .ProtectKeysWithDpapiNG("CERTIFICATE=HashId:{CERTIFICATE THUMBPRINT}",
            flags: DpapiNGProtectionDescriptorFlags.None);
}
```

Any app pointed at this repository must be running on Windows 8.1/Windows Server 2012 R2 or later to decipher the keys.

## Custom key encryption

If the in-box mechanisms aren't appropriate, the developer can specify their own key encryption mechanism by providing a custom <xref:Microsoft.AspNetCore.DataProtection.XmlEncryption.IXmlEncryptor>.
