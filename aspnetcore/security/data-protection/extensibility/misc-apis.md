---
title: Miscellaneous APIs
author: rick-anderson
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: 512c6ba7-88ec-47e4-a656-6b30350b34e6
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/data-protection/extensibility/misc-apis
---
# Miscellaneous APIs

<a name=data-protection-extensibility-mics-apis></a>

>[!WARNING]
> Types that implement any of the following interfaces should be thread-safe for multiple callers.

## ISecret

The ISecret interface represents a secret value, such as cryptographic key material. It contains the following API surface.

* Length : int

* Dispose() : void

* WriteSecretIntoBuffer(ArraySegment<byte> buffer) : void

The WriteSecretIntoBuffer method populates the supplied buffer with the raw secret value. The reason this API takes the buffer as a parameter rather than returning a byte[] directly is that this gives the caller the opportunity to pin the buffer object, limiting secret exposure to the managed garbage collector.

The Secret type is a concrete implementation of ISecret where the secret value is stored in in-process memory. On Windows platforms, the secret value is encrypted via [CryptProtectMemory](https://msdn.microsoft.com/library/windows/desktop/aa380262(v=vs.85).aspx).
