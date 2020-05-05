---
title: Get started with the Data Protection APIs in ASP.NET Core
author: rick-anderson
description: Learn how to use the ASP.NET Core data protection APIs for protecting and unprotecting data in an app.
ms.author: riande
ms.date: 11/12/2019
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/data-protection/using-data-protection
---
# Get started with the Data Protection APIs in ASP.NET Core

<a name="security-data-protection-getting-started"></a>

At its simplest, protecting data consists of the following steps:

1. Create a data protector from a data protection provider.

2. Call the `Protect` method with the data you want to protect.

3. Call the `Unprotect` method with the data you want to turn back into plain text.

Most frameworks and app models, such as ASP.NET Core or SignalR, already configure the data protection system and add it to a service container you access via dependency injection. The following sample demonstrates configuring a service container for dependency injection and registering the data protection stack, receiving the data protection provider via DI, creating a protector and protecting then unprotecting data.

[!code-csharp[](../../security/data-protection/using-data-protection/samples/protectunprotect.cs?highlight=26,34,35,36,37,38,39,40)]

When you create a protector you must provide one or more [Purpose Strings](xref:security/data-protection/consumer-apis/purpose-strings). A purpose string provides isolation between consumers. For example, a protector created with a purpose string of "green" wouldn't be able to unprotect data provided by a protector with a purpose of "purple".

>[!TIP]
> Instances of `IDataProtectionProvider` and `IDataProtector` are thread-safe for multiple callers. It's intended that once a component gets a reference to an `IDataProtector` via a call to `CreateProtector`, it will use that reference for multiple calls to `Protect` and `Unprotect`.
>
>A call to `Unprotect` will throw CryptographicException if the protected payload cannot be verified or deciphered. Some components may wish to ignore errors during unprotect operations; a component which reads authentication cookies might handle this error and treat the request as if it had no cookie at all rather than fail the request outright. Components which want this behavior should specifically catch CryptographicException instead of swallowing all exceptions.
