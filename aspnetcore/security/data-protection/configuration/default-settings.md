---
title: Data Protection key management and lifetime in ASP.NET Core
author: rick-anderson
description: Learn about Data Protection key management and lifetime in ASP.NET Core.
ms.author: riande
ms.date: 10/14/2016
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/data-protection/configuration/default-settings
---
# Data Protection key management and lifetime in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

## Key management

The app attempts to detect its operational environment and handle key configuration on its own.

1. If the app is hosted in [Azure Apps](https://azure.microsoft.com/services/app-service/), keys are persisted to the *%HOME%\ASP.NET\DataProtection-Keys* folder. This folder is backed by network storage and is synchronized across all machines hosting the app.
   * Keys aren't protected at rest.
   * The *DataProtection-Keys* folder supplies the key ring to all instances of an app in a single deployment slot.
   * Separate deployment slots, such as Staging and Production, don't share a key ring. When you swap between deployment slots, for example swapping Staging to Production or using A/B testing, any app using Data Protection won't be able to decrypt stored data using the key ring inside the previous slot. This leads to users being logged out of an app that uses the standard ASP.NET Core cookie authentication, as it uses Data Protection to protect its cookies. If you desire slot-independent key rings, use an external key ring provider, such as Azure Blob Storage, Azure Key Vault, a SQL store, or Redis cache.

1. If the user profile is available, keys are persisted to the *%LOCALAPPDATA%\ASP.NET\DataProtection-Keys* folder. If the operating system is Windows, the keys are encrypted at rest using DPAPI.

   The app pool's [setProfileEnvironment attribute](/iis/configuration/system.applicationhost/applicationpools/add/processmodel#configuration) must also be enabled. The default value of `setProfileEnvironment` is `true`. In some scenarios (for example, Windows OS), `setProfileEnvironment` is set to `false`. If keys aren't stored in the user profile directory as expected:

   1. Navigate to the *%windir%/system32/inetsrv/config* folder.
   1. Open the *applicationHost.config* file.
   1. Locate the `<system.applicationHost><applicationPools><applicationPoolDefaults><processModel>` element.
   1. Confirm that the `setProfileEnvironment` attribute isn't present, which defaults the value to `true`, or explicitly set the attribute's value to `true`.

1. If the app is hosted in IIS, keys are persisted to the HKLM registry in a special registry key that's ACLed only to the worker process account. Keys are encrypted at rest using DPAPI.

1. If none of these conditions match, keys aren't persisted outside of the current process. When the process shuts down, all generated keys are lost.

The developer is always in full control and can override how and where keys are stored. The first three options above should provide good defaults for most apps similar to how the ASP.NET **\<machineKey>** auto-generation routines worked in the past. The final, fallback option is the only scenario that requires the developer to specify [configuration](xref:security/data-protection/configuration/overview) upfront if they want key persistence, but this fallback only occurs in rare situations.

When hosting in a Docker container, keys should be persisted in a folder that's a Docker volume (a shared volume or a host-mounted volume that persists beyond the container's lifetime) or in an external provider, such as [Azure Key Vault](https://azure.microsoft.com/services/key-vault/) or [Redis](https://redis.io/). An external provider is also useful in web farm scenarios if apps can't access a shared network volume (see [PersistKeysToFileSystem](xref:security/data-protection/configuration/overview#persistkeystofilesystem) for more information).

> [!WARNING]
> If the developer overrides the rules outlined above and points the Data Protection system at a specific key repository, automatic encryption of keys at rest is disabled. At-rest protection can be re-enabled via [configuration](xref:security/data-protection/configuration/overview).

## Key lifetime

Keys have a 90-day lifetime by default. When a key expires, the app automatically generates a new key and sets the new key as the active key. As long as retired keys remain on the system, your app can decrypt any data protected with them. See [key management](xref:security/data-protection/implementation/key-management#key-expiration-and-rolling) for more information.

## Default algorithms

The default payload protection algorithm used is AES-256-CBC for confidentiality and HMACSHA256 for authenticity. A 512-bit master key, changed every 90 days, is used to derive the two sub-keys used for these algorithms on a per-payload basis. See [subkey derivation](xref:security/data-protection/implementation/subkeyderivation#additional-authenticated-data-and-subkey-derivation) for more information.

## Additional resources

* <xref:security/data-protection/extensibility/key-management>
* <xref:host-and-deploy/web-farm>
