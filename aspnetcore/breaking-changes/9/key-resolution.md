---
title: "Breaking change: DefaultKeyResolution.ShouldGenerateNewKey has altered meaning"
description: Learn about the breaking change in ASP.NET Core 9.0 where DefaultKeyResolution.ShouldGenerateNewKey has a slightly altered meaning.
ms.date: 04/01/2024
ms.custom: https://github.com/aspnet/Announcements/issues/512
---
# DefaultKeyResolution.ShouldGenerateNewKey has altered meaning

`DefaultKeyResolution.ShouldGenerateNewKey` no longer reflects whether the default key is close to its expiration time.

## Version introduced

ASP.NET Core 9.0 Preview 3

## Previous behavior

It was an undocumented, but consistent, feature of the API that `ShouldGenerateNewKey` was `true` if the default key was within two days (an oversimplification) of its expiration time. The amount of lead time was based on the polling interval of `ICacheableKeyRingProvider`, which was not something `IDefaultKeyResolver.ResolveDefaultKeyPolicy` should have depended upon (since, for example, alternative implementations would probably not be aware of these details).

## New behavior

Starting in .NET 9, if `ShouldGenerateNewKey` is `true`, it indicates that either there's no default key or that for some other policy reason (in a specialized implementation of `IDefaultKeyResolver`), a new key should be generated. The `ICacheableKeyRingProvider` makes its own decision about whether the expiration time is close enough to warrant generating a new key.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was made for two reasons:

- To change the logic around key generation near expiration time.
- To make it simpler to implement a custom `IDefaultKeyResolver`.

## Recommended action

If you have an `IDefaultKeyResolver` implementation that tries to replicate the expiry logic, you can remove that logic (however, leaving it is fine as well).

If you were consuming `IDefaultKeyResolver` directly to determine whether expiration was pending, you can check the default key's `ExpirationDate` property directly.

## Affected APIs

- `Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.DefaultKeyResolution.ShouldGenerateNewKey`
