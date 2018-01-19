---
title: Data Protection in ASP.NET Core
author: rick-anderson
description: This document serves as a table of contents for the various ASP.NET Core data protection topics.
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/data-protection/index
---
# Data Protection in ASP.NET Core: Consumer APIs, configuration, extensibility APIs and implementation

* [Introduction to data protection](introduction.md)

* [Get started with the Data Protection APIs](using-data-protection.md)

* [Consumer APIs](consumer-apis/index.md)

  * [Consumer APIs overview](consumer-apis/overview.md)

  * [Purpose strings](consumer-apis/purpose-strings.md)

  * [Purpose hierarchy and multi-tenancy](consumer-apis/purpose-strings-multitenancy.md)

  * [Password hashing](consumer-apis/password-hashing.md)

  * [Limiting the lifetime of protected payloads](consumer-apis/limited-lifetime-payloads.md)

  * [Unprotecting payloads whose keys have been revoked](consumer-apis/dangerous-unprotect.md)

* [Configuration](configuration/index.md)

  * [Configuring data protection](configuration/overview.md)

  * [Default settings](configuration/default-settings.md)

  * [Machine-wide policy](configuration/machine-wide-policy.md)

  * [Non DI-aware scenarios](configuration/non-di-scenarios.md)

* [Extensibility APIs](extensibility/index.md)

  * [Core cryptography extensibility](extensibility/core-crypto.md)

  * [Key management extensibility](extensibility/key-management.md)

  * [Miscellaneous APIs](extensibility/misc-apis.md)

* [Implementation](implementation/index.md)

  * [Authenticated encryption details](implementation/authenticated-encryption-details.md)

  * [Subkey derivation and authenticated encryption](implementation/subkeyderivation.md)

  * [Context headers](implementation/context-headers.md)

  * [Key management](implementation/key-management.md)

  * [Key storage providers](implementation/key-storage-providers.md)

  * [Key encryption at rest](implementation/key-encryption-at-rest.md)

  * [Key immutability and changing settings](implementation/key-immutability.md)

  * [Key storage format](implementation/key-storage-format.md)

  * [Ephemeral data protection providers](implementation/key-storage-ephemeral.md)

* [Compatibility](compatibility/index.md)

  * [Sharing cookies among apps](xref:security/data-protection/compatibility/cookie-sharing)

  * [Replacing <machineKey> in ASP.NET](xref:security/data-protection/compatibility/replacing-machinekey)
