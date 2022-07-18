---
title: Hash passwords in ASP.NET Core
author: rick-anderson
description: Learn how to hash passwords using the ASP.NET Core Data Protection APIs.
ms.author: riande
ms.date: 10/14/2016
uid: security/data-protection/consumer-apis/password-hashing
---

# Hash passwords in ASP.NET Core

This article shows how to call the [`KeyDerivation.Pbkdf2`](/dotnet/api/microsoft.aspnetcore.cryptography.keyderivation.keyderivation.pbkdf2) method which allows hashing a password using the [PBKDF2 algorithm](https://tools.ietf.org/html/rfc2898#section-5.2).

> [!WARNING]
> The `KeyDerivation.Pbkdf2` API is a low-level cryptographic primitive and is intended to be used to integrate apps into an existing protocol or cryptographic system. `KeyDerivation.Pbkdf2` should not be used in new apps which support password based login and need to store hashed passwords in a datastore. New apps should use [`PasswordHasher`](/dotnet/api/microsoft.aspnetcore.identity.passwordhasher-1). For more information on `PasswordHasher`, see [Exploring the ASP.NET Core Identity PasswordHasher](https://andrewlock.net/exploring-the-asp-net-core-identity-passwordhasher/).

The data protection code base includes a NuGet package [Microsoft.AspNetCore.Cryptography.KeyDerivation](https://www.nuget.org/packages/Microsoft.AspNetCore.Cryptography.KeyDerivation/) which contains cryptographic key derivation functions. This package is a standalone component and has no dependencies on the rest of the data protection system. It can be used independently. The source exists alongside the data protection code base as a convenience.

> [!WARNING]
> The following code shows how to use `KeyDerivation.Pbkdf2` to  generate a shared secret key. It should not be used to hash a password for storage in a datastore.

<!-- See https://github.com/dotnet/AspNetCore.Docs/pull/26253#issuecomment-1187984822 for detailed reasoning -->

:::moniker range=">= aspnetcore-6.0"

[!code-csharp[](password-hashing/samples/6.x/passwordhasher.cs)]

:::moniker-end

:::moniker range="< aspnetcore-6.0"

[!code-csharp[](password-hashing/samples/5.x/passwordhasher.cs)]

:::moniker-end

See the [source code](https://github.com/dotnet/AspNetCore/blob/main/src/Identity/Extensions.Core/src/PasswordHasher.cs) for ASP.NET Core Identity's `PasswordHasher` type for a real-world use case.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]
