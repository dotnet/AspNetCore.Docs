---
title: Default Settings | Microsoft Docs
author: rick-anderson
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: ef7dad2a-7029-4ae5-8f06-1fbebedccaa4
ms.technology: aspnet
ms.prod: aspnet-core
uid: security/data-protection/configuration/default-settings
---
# Default Settings

<a name=data-protection-default-settings></a>

## Key Management

The system tries to detect its operational environment and provide good zero-configuration behavioral defaults. The heuristic used is as follows.

1. If the system is being hosted in Azure Web Sites, keys are persisted to the "%HOME%\ASP.NET\DataProtection-Keys" folder. This folder is backed by network storage and is synchronized across all machines hosting the application. Keys are not protected at rest.

2. If the user profile is available, keys are persisted to the "%LOCALAPPDATA%\ASP.NET\DataProtection-Keys" folder. Additionally, if the operating system is Windows, they'll be encrypted at rest using DPAPI.

3. If the application is hosted in IIS, keys are persisted to the HKLM registry in a special registry key that is ACLed only to the worker process account. Keys are encrypted at rest using DPAPI.

4. If none of these conditions matches, keys are not persisted outside of the current process. When the process shuts down, all generated keys will be lost.

The developer is always in full control and can override how and where keys are stored. The first three options above should good defaults for most applications similar to how the ASP.NET <machineKey> auto-generation routines worked in the past. The final, fall back option is the only scenario that truly requires the developer to specify [configuration](overview.md) upfront if they want key persistence, but this fall-back would only occur in rare situations.

>[!WARNING]
> If the developer overrides this heuristic and points the data protection system at a specific key repository, automatic encryption of keys at rest will be disabled. At rest protection can be re-enabled via [configuration](overview.md).

## Key Lifetime

Keys by default have a 90-day lifetime. When a key expires, the system will automatically generate a new key and set the new key as the active key. As long as retired keys remain on the system you will still be able to decrypt any data protected with them. See [key lifetime](../implementation/key-management.md#data-protection-implementation-key-management-expiration) for more information.

## Default Algorithms

The default payload protection algorithm used is AES-256-CBC for confidentiality and HMACSHA256 for authenticity. A 512-bit master key, rolled every 90 days, is used to derive the two sub-keys used for these algorithms on a per-payload basis. See [subkey derivation](../implementation/subkeyderivation.md#data-protection-implementation-subkey-derivation-aad) for more information.
