---
title: Key immutability and key settings in ASP.NET Core
author: rick-anderson
description: Learn the implementation details of the ASP.NET Core Data Protection key immutability APIs.
ms.author: riande
ms.date: 10/14/2016
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/data-protection/implementation/key-immutability
---

# Key immutability and key settings in ASP.NET Core

Once an object is persisted to the backing store, its representation is forever fixed. New data can be added to the backing store, but existing data can never be mutated. The primary purpose of this behavior is to prevent data corruption.

One consequence of this behavior is that once a key is written to the backing store, it's immutable. Its creation, activation, and expiration dates can never be changed, though it can revoked by using `IKeyManager`. Additionally, its underlying algorithmic information, master keying material, and encryption at rest properties are also immutable.

If the developer changes any setting that affects key persistence, those changes won't go into effect until the next time a key is generated, either via an explicit call to `IKeyManager.CreateNewKey` or via the data protection system's own [automatic key generation](xref:security/data-protection/implementation/key-management#data-protection-implementation-key-management) behavior. The settings that affect key persistence are as follows:

* [The default key lifetime](xref:security/data-protection/implementation/key-management#data-protection-implementation-key-management)

* [The key encryption at rest mechanism](xref:security/data-protection/implementation/key-encryption-at-rest)

* [The algorithmic information contained within the key](xref:security/data-protection/configuration/overview#changing-algorithms-with-usecryptographicalgorithms)

If you need these settings to kick in earlier than the next automatic key rolling time, consider making an explicit call to `IKeyManager.CreateNewKey` to force the creation of a new key. Remember to provide an explicit activation date ({ now + 2 days } is a good rule of thumb to allow time for the change to propagate) and expiration date in the call.

>[!TIP]
> All applications touching the repository should specify the same settings with the `IDataProtectionBuilder` extension methods. Otherwise, the properties of the persisted key will be dependent on the particular application that invoked the key generation routines.
