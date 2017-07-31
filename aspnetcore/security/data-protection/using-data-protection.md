---
title: Getting Started with the Data Protection APIs
author: rick-anderson
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: 39b7a73c-29d4-4137-b311-49529adcf3cb
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/data-protection/using-data-protection
---
# Getting Started with the Data Protection APIs

<a name=security-data-protection-getting-started></a>

At its simplest protecting data consists of the following steps:

1. Create a data protector from a data protection provider.

2. Call the Protect method with the data you want to protect.

3. Call the Unprotect method with the data you want to turn back into plain text.

Most frameworks such as ASP.NET or SignalR already configure the data protection system and add it to a service container you access via dependency injection. The following sample demonstrates configuring a service container for dependency injection and registering the data protection stack, receiving the data protection provider via DI, creating a protector and protecting then unprotecting data

[!code-csharp[Main](../../security/data-protection/using-data-protection/samples/protectunprotect.cs?highlight=26,34,35,36,37,38,39,40)]

When you create a protector you must provide one or more [Purpose Strings](consumer-apis/purpose-strings.md). A purpose string provides isolation between consumers, for example a protector created with a purpose string of "green" would not be able to unprotect data provided by a protector with a purpose of "purple".

>[!TIP]
> Instances of IDataProtectionProvider and IDataProtector are thread-safe for multiple callers. It is intended that once a component gets a reference to an IDataProtector via a call to CreateProtector, it will use that reference for multiple calls to Protect and Unprotect.
>
>A call to Unprotect will throw CryptographicException if the protected payload cannot be verified or deciphered. Some components may wish to ignore errors during unprotect operations; a component which reads authentication cookies might handle this error and treat the request as if it had no cookie at all rather than fail the request outright. Components which want this behavior should specifically catch CryptographicException instead of swallowing all exceptions.
