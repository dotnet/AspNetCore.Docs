---
title: ASP.NET Core Data Protection Overview
author: rick-anderson
description: Learn about the concept of data protection and the design principles of the ASP.NET Core Data Protection APIs.
ms.author: riande
ms.custom: mvc
ms.date: 03/07/2022
uid: security/data-protection/introTmp
---
# DO NOT REVIEW THIS is a temporary file

The ASP.NET Core data protection provides a cryptographic API to protect data, including key management and rotation.

Web apps often need to store security-sensitive data. [DPAPI](/dotnet/standard/security/how-to-use-data-protection), the Windows data protection API isn't intended for use in web apps.

The ASP.NET Core data protection stack was designed to:

* Serve as the replacement for the `<machineKey>` element in ASP.NET 1.x - 4.x.
* Address many of the deficiencies of the previous encryption system while providing a built in solution for most Web scenarios.

## Problem statement

*I need to persist trusted information for later retrieval, but I don't trust the persistence mechanism.* In web terms, this might be written as *I need to round-trip trusted state via an untrusted client.*

The canonical example of this is an authentication cookie or bearer token. The server generates an ***I am Groot and have xyz permissions*** token and sends it to the client. The client presents that token back to the server, but the server needs some kind of assurance that the client hasn't forged the token. Authenticity, integrity, and tamper-proofing is a requirement.

Since the persisted state is trusted by the server, this state might contain information that's specific to the operating environment. The information might be:

* A file path
* A permission
* A handle or other indirect reference.
* Some server-specific data.

Such information shouldn't typically be disclosed to an untrusted client. Confidentiality is a requirement:

Since modern apps are componentized, individual components want to take advantage of this system without regard to other components in the system. For instance, consider a bearer token component using this stack. It should operate without any interference, for example, an anti-CSRF mechanism also using the same stack. Isolation is a requirement.

Further constraints are provided to narrow the scope of requirements. Assumptions:

* All services operating within the cryptosystem are equally trusted.
* The data doesn't need to be generated or consumed outside of the services under our direct control.

Operations must be fast since each request to the web service might go through the cryptosystem one or more times. The speed requirement makes symmetric cryptography ideal for our scenario. Asymmetric cryptography isn't used until it's required.

## Design philosophy

ASP.NET Core data protection is based on the following principles.

* Ease of configuration. The system strives for zero-configuration. In situations where developers need to configure a specific aspect, such as the key repository, those specific configurations aren't difficult.
* Offer a basic consumer-facing API. The APIs are straight forward to use correctly and difficult to use incorrectly.
* Developers don't have to learn key management principles. The system handles algorithm selection and key lifetime on the developer's behalf. The developer doesn't have access to the raw key material.
* Keys are protected at rest when possible. The system figures out an appropriate default protection mechanism and applies it automatically.

ASP.NET Core data protection is an [easy to use](xref:security/data-protection/using-data-protection) data protection stack.

The data protection APIs aren't primarily intended for indefinite persistence of confidential payloads. For example, [Windows CNG DPAPI](/windows/win32/seccng/cng-dpapi) and [Azure Rights Management](/rights-management/):

* Are recommended for indefinite storage.
* Have correspondingly strong key management capabilities.

There's nothing prohibiting a developer from using the ASP.NET Core data protection APIs for long-term protection of confidential data.

## Audience

The data protection system is provided in following packages. These APIs target three main audiences:

1. The [Consumer APIs Overview](xref:security/data-protection/consumer-apis/overview) target application and framework developers.

   *I don't want to learn about how the stack operates or about how it's configured. I just want to perform some operation with high probability of using the APIs successfully.*

2. The [configuration APIs](xref:security/data-protection/configuration/overview) target app developers and system administrators.

   *I need to tell the data protection system that my environment requires non-default paths or settings.*

3. The extensibility APIs target developers in charge of implementing custom policy. Usage of these APIs are limited to rare situations and experienced, security aware developers.

   *I need to replace an entire component within the system because I have truly unique behavioral requirements. I'm willing to learn uncommonly used parts of the API surface in order to build a plugin that fulfills my requirements.*

## Package layout

The data protection stack:

* [Microsoft.AspNetCore.DataProtection.Abstractions](https://www.nuget.org/packages/Microsoft.AspNetCore.DataProtection.Abstractions/) contains:

  * <xref:Microsoft.AspNetCore.DataProtection.IDataProtectionProvider> and <xref:Microsoft.AspNetCore.DataProtection.IDataProtector> interfaces to create data protection services.
  * Useful extension methods for working with these types. for example, [IDataProtector.Protect](xref:Microsoft.AspNetCore.DataProtection.IDataProtector.Protect%2A)

  If the data protection system is instantiated elsewhere and you're consuming the API, reference `Microsoft.AspNetCore.DataProtection.Abstractions`.

* [Microsoft.AspNetCore.DataProtection](https://www.nuget.org/packages/Microsoft.AspNetCore.DataProtection/) contains the core implementation of the data protection system, including:

  * Core cryptographic operations.
  * Key management.
  * Configuration and extensibility.

 To instantiate the data protection system, reference `Microsoft.AspNetCore.DataProtection`. You might need to reference the data protection system when:

* Adding it to an <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>.
* Modifying or extending its behavior.

* [Microsoft.AspNetCore.DataProtection.Extensions](https://www.nuget.org/packages/Microsoft.AspNetCore.DataProtection.Extensions/) contains additional APIs which developers might find useful but which don't belong in the core package. For instance, this package contains:

  * Factory methods to instantiate the data protection system to store keys at a location on the file system without dependency injection. See <xref:Microsoft.AspNetCore.DataProtection.DataProtectionProvider>.
  * Extension methods for limiting the lifetime of protected payloads. See <xref:Microsoft.AspNetCore.DataProtection.ITimeLimitedDataProtector>.

* [Microsoft.AspNetCore.DataProtection.SystemWeb](https://www.nuget.org/packages/Microsoft.AspNetCore.DataProtection.SystemWeb/) can be installed into an existing ASP.NET 4.x app to redirect its `<machineKey>` operations to use the new ASP.NET Core data protection stack. For more information, see <xref:security/data-protection/compatibility/replacing-machinekey>.

* [Microsoft.AspNetCore.Cryptography.KeyDerivation](https://www.nuget.org/packages/Microsoft.AspNetCore.Cryptography.KeyDerivation/) provides an implementation of the PBKDF2 password hashing routine and can be used by systems that must handle user passwords securely. For more information, see <xref:security/data-protection/consumer-apis/password-hashing>.

## Additional resources

* <xref:security/data-protection/using-data-protection>
* <xref:host-and-deploy/web-farm>
