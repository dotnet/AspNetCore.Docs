---
title: Data Protection in ASP.NET Core
author: rick-anderson
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: 1f402da8-1052-4970-9835-9f9f16a02dbc
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/data-protection/index
---
# Data Protection in ASP.NET Core: Consumer APIs, configuration, extensibility APIs and implementation

* [Introduction to Data Protection](introduction.md)

* [Getting Started with the Data Protection APIs](using-data-protection.md)

* [Consumer APIs](consumer-apis/index.md)

  * [Consumer APIs Overview](consumer-apis/overview.md)

  * [Purpose Strings](consumer-apis/purpose-strings.md)

  * [Purpose hierarchy and multi-tenancy](consumer-apis/purpose-strings-multitenancy.md)

  * [Password Hashing](consumer-apis/password-hashing.md)

  * [Limiting the lifetime of protected payloads](consumer-apis/limited-lifetime-payloads.md)

  * [Unprotecting payloads whose keys have been revoked](consumer-apis/dangerous-unprotect.md)

* [Configuration](configuration/index.md)

  * [Configuring Data Protection](configuration/overview.md)

  * [Default Settings](configuration/default-settings.md)

  * [Machine Wide Policy](configuration/machine-wide-policy.md)

  * [Non DI Aware Scenarios](configuration/non-di-scenarios.md)

* [Extensibility APIs](extensibility/index.md)

  * [Core cryptography extensibility](extensibility/core-crypto.md)

  * [Key management extensibility](extensibility/key-management.md)

  * [Miscellaneous APIs](extensibility/misc-apis.md)

* [Implementation](implementation/index.md)

  * [Authenticated encryption details.](implementation/authenticated-encryption-details.md)

  * [Subkey Derivation and Authenticated Encryption](implementation/subkeyderivation.md)

  * [Context headers](implementation/context-headers.md)

  * [Key Management](implementation/key-management.md)

  * [Key Storage Providers](implementation/key-storage-providers.md)

  * [Key Encryption At Rest](implementation/key-encryption-at-rest.md)

  * [Key Immutability and Changing Settings](implementation/key-immutability.md)

  * [Key Storage Format](implementation/key-storage-format.md)

  * [Ephemeral data protection providers](implementation/key-storage-ephemeral.md)

* [Compatibility](compatibility/index.md)

  * [Sharing cookies between applications](compatibility/cookie-sharing.md)

  * [Replacing <machineKey> in ASP.NET](compatibility/replacing-machinekey.md)
