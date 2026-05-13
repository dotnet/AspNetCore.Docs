---
title: Hash passwords in ASP.NET Core
author: wadepickett
description: Learn how to hash passwords using the ASP.NET Core Data Protection APIs.
ms.author: wpickett
ms.date: 05/14/2026
uid: security/data-protection/consumer-apis/password-hashing

# customer intent: As an ASP.NET developer, I want to use the Data Protection APIs, so I can hash passwords in my ASP.NET Core apps.
---

# Hash passwords in ASP.NET Core

This article shows how to call the [KeyDerivation.Pbkdf2](/dotnet/api/microsoft.aspnetcore.cryptography.keyderivation.keyderivation.pbkdf2) method, which allows hashing a password with the PBKDF2 algorithm, as described in [RFC 2898, Section 5.2](https://datatracker.ietf.org/doc/html/rfc2898#section-5.2).

> [!WARNING]
> The `KeyDerivation.Pbkdf2` API is a low-level cryptographic primitive. The intended use is for integrating apps into an existing protocol or cryptographic system. `KeyDerivation.Pbkdf2` shouldn't be used in new apps that support password-based sign in and which need to store hashed passwords in a datastore. New apps should use the [PasswordHasher](/dotnet/api/microsoft.aspnetcore.identity.passwordhasher-1) class. For more information, see [Exploring the ASP.NET Core Identity PasswordHasher](https://andrewlock.net/exploring-the-asp-net-core-identity-passwordhasher/).

The data protection code base includes a NuGet package [Microsoft.AspNetCore.Cryptography.KeyDerivation](https://www.nuget.org/packages/Microsoft.AspNetCore.Cryptography.KeyDerivation/) that contains cryptographic key derivation functions. This package is a standalone component and has no dependencies on the rest of the data protection system. The package can be used independently. The source exists alongside the data protection code base as a convenience.

> [!WARNING]
> The following code shows how to use `KeyDerivation.Pbkdf2` to generate a shared secret key. It shouldn't be used to hash a password for storage in a datastore.

<!-- See https://github.com/dotnet/AspNetCore.Docs/pull/26253#issuecomment-1187984822 for detailed reasoning -->

:::moniker range=">= aspnetcore-6.0"

[!code-csharp[](password-hashing/samples/6.x/passwordhasher.cs)]

:::moniker-end

:::moniker range="< aspnetcore-6.0"

[!code-csharp[](password-hashing/samples/5.x/passwordhasher.cs)]

:::moniker-end

For a real-world use case of the ASP.NET Core Identity `PasswordHasher` type, see the [source code](https://github.com/dotnet/AspNetCore/blob/main/src/Identity/Extensions.Core/src/PasswordHasher.cs) on GitHub.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

## Related content

- [Exploring the ASP.NET Core Identity 'PasswordHasher' type](https://andrewlock.net/exploring-the-asp-net-core-identity-passwordhasher/)
- [KeyDerivation.Pbkdf2](/dotnet/api/microsoft.aspnetcore.cryptography.keyderivation.keyderivation.pbkdf2)
