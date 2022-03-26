---
title: Data Protection machine-wide policy support in ASP.NET Core
author: rick-anderson
description: Learn about support for setting a default machine-wide policy for all apps that consume ASP.NET Core Data Protection.
ms.author: riande
ms.date: 10/14/2016
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/data-protection/configuration/machine-wide-policy
---
# Data Protection machine-wide policy support in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

When running on Windows, the Data Protection system has limited support for setting a default machine-wide policy for all apps that consume ASP.NET Core Data Protection. The general idea is that an administrator might wish to change a default setting, such as the algorithms used or key lifetime, without the need to manually update every app on the machine.

> [!WARNING]
> The system administrator can set default policy, but they can't enforce it. The app developer can always override any value with one of their own choosing. The default policy only affects apps where the developer hasn't specified an explicit value for a setting.

## Setting default policy

To set default policy, an administrator can set known values in the system registry under the following registry key:

**HKLM\SOFTWARE\Microsoft\DotNetPackages\Microsoft.AspNetCore.DataProtection**

If you're on a 64-bit operating system and want to affect the behavior of 32-bit apps, remember to configure the Wow6432Node equivalent of the above key.

The supported values are shown below.

| Value              | Type   | Description |
| ------------------ | :----: | ----------- |
| EncryptionType     | string | Specifies which algorithms should be used for data protection. The value must be CNG-CBC, CNG-GCM, or Managed and is described in more detail below. |
| DefaultKeyLifetime | DWORD  | Specifies the lifetime for newly-generated keys. The value is specified in days and must be >= 7. |
| KeyEscrowSinks     | string | Specifies the types that are used for key escrow. The value is a semicolon-delimited list of key escrow sinks, where each element in the list is the assembly-qualified name of a type that implements <xref:Microsoft.AspNetCore.DataProtection.KeyManagement.IKeyEscrowSink>. |

## Encryption types

If EncryptionType is CNG-CBC, the system is configured to use a CBC-mode symmetric block cipher for confidentiality and HMAC for authenticity with services provided by Windows CNG (see [Specifying custom Windows CNG algorithms](xref:security/data-protection/configuration/overview#specifying-custom-windows-cng-algorithms) for more details). The following additional values are supported, each of which corresponds to a property on the CngCbcAuthenticatedEncryptionSettings type.

| Value                       | Type   | Description |
| --------------------------- | :----: | ----------- |
| EncryptionAlgorithm         | string | The name of a symmetric block cipher algorithm understood by CNG. This algorithm is opened in CBC mode. |
| EncryptionAlgorithmProvider | string | The name of the CNG provider implementation that can produce the algorithm EncryptionAlgorithm. |
| EncryptionAlgorithmKeySize  | DWORD  | The length (in bits) of the key to derive for the symmetric block cipher algorithm. |
| HashAlgorithm               | string | The name of a hash algorithm understood by CNG. This algorithm is opened in HMAC mode. |
| HashAlgorithmProvider       | string | The name of the CNG provider implementation that can produce the algorithm HashAlgorithm. |

If EncryptionType is CNG-GCM, the system is configured to use a Galois/Counter Mode symmetric block cipher for confidentiality and authenticity with services provided by Windows CNG (see [Specifying custom Windows CNG algorithms](xref:security/data-protection/configuration/overview#specifying-custom-windows-cng-algorithms) for more details). The following additional values are supported, each of which corresponds to a property on the CngGcmAuthenticatedEncryptionSettings type.

| Value                       | Type   | Description |
| --------------------------- | :----: | ----------- |
| EncryptionAlgorithm         | string | The name of a symmetric block cipher algorithm understood by CNG. This algorithm is opened in Galois/Counter Mode. |
| EncryptionAlgorithmProvider | string | The name of the CNG provider implementation that can produce the algorithm EncryptionAlgorithm. |
| EncryptionAlgorithmKeySize  | DWORD  | The length (in bits) of the key to derive for the symmetric block cipher algorithm. |

If EncryptionType is Managed, the system is configured to use a managed SymmetricAlgorithm for confidentiality and KeyedHashAlgorithm for authenticity (see [Specifying custom managed algorithms](xref:security/data-protection/configuration/overview#specifying-custom-managed-algorithms) for more details). The following additional values are supported, each of which corresponds to a property on the ManagedAuthenticatedEncryptionSettings type.

| Value                      | Type   | Description |
| -------------------------- | :----: | ----------- |
| EncryptionAlgorithmType    | string | The assembly-qualified name of a type that implements SymmetricAlgorithm. |
| EncryptionAlgorithmKeySize | DWORD  | The length (in bits) of the key to derive for the symmetric encryption algorithm. |
| ValidationAlgorithmType    | string | The assembly-qualified name of a type that implements KeyedHashAlgorithm. |

If EncryptionType has any other value other than null or empty, the Data Protection system throws an exception at startup.

> [!WARNING]
> When configuring a default policy setting that involves type names (EncryptionAlgorithmType, ValidationAlgorithmType, KeyEscrowSinks), the types must be available to the app. This means that for apps running on Desktop CLR, the assemblies that contain these types should be present in the Global Assembly Cache (GAC). For ASP.NET Core apps running on .NET Core, the packages that contain these types should be installed.
