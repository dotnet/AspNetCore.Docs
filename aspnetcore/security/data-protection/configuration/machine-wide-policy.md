---
title: Machine Wide Policy
author: rick-anderson
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: 285ae47d-e0bf-4b03-b0a8-2b1fb18bc3a1
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/data-protection/configuration/machine-wide-policy
---
# Machine Wide Policy

<a name=data-protection-configuration-machinewidepolicy></a>

When running on Windows, the data protection system has limited support for setting default machine-wide policy for all applications which consume data protection. The general idea is that an administrator might wish to change some default setting (such as algorithms used or key lifetime) without needing to manually update every application on the machine.

>[!WARNING]
> The system administrator can set default policy, but they cannot enforce it. The application developer can always override any value with one of their own choosing. The default policy only affects applications where the developer has not specified an explicit value for some particular setting.

## Setting default policy

To set default policy, an administrator can set known values in the system registry under the following key.

Reg key: `HKLM\SOFTWARE\Microsoft\DotNetPackages\Microsoft.AspNetCore.DataProtection`

If you're on a 64-bit operating system and want to affect the behavior of 32-bit applications, remember also to configure the Wow6432Node equivalent of the above key.

The supported values are:

* EncryptionType [string] - specifies which algorithms should be used for data protection. This value must be "CNG-CBC", "CNG-GCM", or "Managed" and is described in more detail [below](#data-protection-encryption-types).

* DefaultKeyLifetime [DWORD] - specifies the lifetime for newly-generated keys. This value is specified in days and must be ≥ 7.

* KeyEscrowSinks [string] - specifies the types which will be used for key escrow. This value is a semicolon-delimited list of key escrow sinks, where each element in the list is the assembly qualified name of a type which implements IKeyEscrowSink.

<a name=data-protection-encryption-types></a>

### Encryption types

If EncryptionType is "CNG-CBC", the system will be configured to use a CBC-mode symmetric block cipher for confidentiality and HMAC for authenticity with services provided by Windows CNG (see [Specifying custom Windows CNG algorithms](overview.md#data-protection-changing-algorithms-cng) for more details). The following additional values are supported, each of which corresponds to a property on the CngCbcAuthenticatedEncryptionSettings type:

* EncryptionAlgorithm [string] - the name of a symmetric block cipher algorithm understood by CNG. This algorithm will be opened in CBC mode.

* EncryptionAlgorithmProvider [string] - the name of the CNG provider implementation which can produce the algorithm EncryptionAlgorithm.

* EncryptionAlgorithmKeySize [DWORD] - the length (in bits) of the key to derive for the symmetric block cipher algorithm.

* HashAlgorithm [string] - the name of a hash algorithm understood by CNG. This algorithm will be opened in HMAC mode.

* HashAlgorithmProvider [string] - the name of the CNG provider implementation which can produce the algorithm HashAlgorithm.

If EncryptionType is "CNG-GCM", the system will be configured to use a Galois/Counter Mode symmetric block cipher for confidentiality and authenticity with services provided by Windows CNG (see [Specifying custom Windows CNG algorithms](overview.md#data-protection-changing-algorithms-cng) for more details). The following additional values are supported, each of which corresponds to a property on the CngGcmAuthenticatedEncryptionSettings type:

* EncryptionAlgorithm [string] - the name of a symmetric block cipher algorithm understood by CNG. This algorithm will be opened in Galois/Counter Mode.

* EncryptionAlgorithmProvider [string] - the name of the CNG provider implementation which can produce the algorithm EncryptionAlgorithm.

* EncryptionAlgorithmKeySize [DWORD] - the length (in bits) of the key to derive for the symmetric block cipher algorithm.

If EncryptionType is "Managed", the system will be configured to use a managed SymmetricAlgorithm for confidentiality and KeyedHashAlgorithm for authenticity (see [Specifying custom managed algorithms](overview.md#data-protection-changing-algorithms-custom-managed) for more details). The following additional values are supported, each of which corresponds to a property on the ManagedAuthenticatedEncryptionSettings type:

* EncryptionAlgorithmType [string] - the assembly-qualified name of a type which implements SymmetricAlgorithm.

* EncryptionAlgorithmKeySize [DWORD] - the length (in bits) of the key to derive for the symmetric encryption algorithm.

* ValidationAlgorithmType [string] - the assembly-qualified name of a type which implements KeyedHashAlgorithm.

If EncryptionType has any other value (other than null / empty), the data protection system will throw an exception at startup.

>[!WARNING]
> When configuring a default policy setting that involves type names (EncryptionAlgorithmType, ValidationAlgorithmType, KeyEscrowSinks), the types must be available to the application. In practice, this means that for applications running on Desktop CLR, the assemblies which contain these types should be GACed. For ASP.NET Core applications running on [.NET Core](https://www.microsoft.com/net/core), the packages which contain these types should be installed.
