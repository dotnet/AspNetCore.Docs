---
title: Data Protection in ASP.NET Core
author: rick-anderson
description: This document serves as a table of contents for the various ASP.NET Core data protection topics.
ms.author: riande
ms.date: 10/14/2016
uid: security/data-protection/index
---
# Data Protection in ASP.NET Core

* [Introduction to data protection](xref:security/data-protection/introduction)

* [Get started with the Data Protection APIs](xref:security/data-protection/using-data-protection)

* [Consumer APIs](xref:security/data-protection/consumer-apis/index)

  * [Consumer APIs overview](xref:security/data-protection/consumer-apis/overview)

  * [Purpose strings](xref:security/data-protection/consumer-apis/purpose-strings)

  * [Purpose hierarchy and multi-tenancy](xref:security/data-protection/consumer-apis/purpose-strings-multitenancy)

  * [Hash passwords](xref:security/data-protection/consumer-apis/password-hashing)

  * [Limit the lifetime of protected payloads](xref:security/data-protection/consumer-apis/limited-lifetime-payloads)

  * [Unprotect payloads whose keys have been revoked](xref:security/data-protection/consumer-apis/dangerous-unprotect)

* [Configuration](xref:security/data-protection/configuration/index)

  * [Configure ASP.NET Core Data Protection](xref:security/data-protection/configuration/overview)

  * [Default settings](xref:security/data-protection/configuration/default-settings)

  * [Machine-wide policy](xref:security/data-protection/configuration/machine-wide-policy)

  * [Non DI-aware scenarios](xref:security/data-protection/configuration/non-di-scenarios)

* [Extensibility APIs](xref:security/data-protection/extensibility/index)

  * [Core cryptography extensibility](xref:security/data-protection/extensibility/core-crypto)

  * [Key management extensibility](xref:security/data-protection/extensibility/key-management)

  * [Miscellaneous APIs](xref:security/data-protection/extensibility/misc-apis)

* [Implementation](xref:security/data-protection/implementation/index)

  * [Authenticated encryption details](xref:security/data-protection/implementation/authenticated-encryption-details)

  * [Subkey derivation and authenticated encryption](xref:security/data-protection/implementation/subkeyderivation)

  * [Context headers](xref:security/data-protection/implementation/context-headers)

  * [Key management](xref:security/data-protection/implementation/key-management)

  * [Key storage providers](xref:security/data-protection/implementation/key-storage-providers)

  * [Key encryption at rest](xref:security/data-protection/implementation/key-encryption-at-rest)

  * [Key immutability and settings](xref:security/data-protection/implementation/key-immutability)

  * [Key storage format](xref:security/data-protection/implementation/key-storage-format)

  * [Ephemeral data protection providers](xref:security/data-protection/implementation/key-storage-ephemeral)

* [Compatibility](xref:security/data-protection/compatibility/index)

  * [Replacing ASP.NET <machineKey> in ASP.NET Core](xref:security/data-protection/compatibility/replacing-machinekey)
