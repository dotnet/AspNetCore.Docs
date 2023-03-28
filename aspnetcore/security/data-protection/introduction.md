---
title: ASP.NET Core Data Protection Overview
author: rick-anderson
description: Learn about the concept of data protection and the design principles of the ASP.NET Core Data Protection APIs.
ms.author: riande
ms.custom: mvc
ms.date: 03/07/2022
uid: security/data-protection/introduction
---
# ASP.NET Core Data Protection Overview

The ASP.NET Core data protection provides a cryptographic API to protect data, including key management and rotation.

Web applications often need to store security-sensitive data. Windows provides a data protection API, [DPAPI](/dotnet/standard/security/how-to-use-data-protection), but Windows DPAPI isn't intended for use in web applications.

The ASP.NET Core data protection stack is designed to serve as the long-term replacement for the &lt;machineKey&gt; element in ASP.NET 1.x - 4.x. It was designed to address many of the shortcomings of the old cryptographic stack while providing an out-of-the-box solution for the majority of use cases modern applications are likely to encounter.

## Problem statement

The overall problem statement can be succinctly stated in a single sentence: I need to persist trusted information for later retrieval, but I don't trust the persistence mechanism. In web terms, this might be written as "I need to round-trip trusted state via an untrusted client."

The canonical example of this is an authentication cookie or bearer token. The server generates an "I am Groot and have xyz permissions" token and hands it to the client. At some future date the client will present that token back to the server, but the server needs some kind of assurance that the client hasn't forged the token. Thus the first requirement: authenticity (a.k.a. integrity, tamper-proofing).

Since the persisted state is trusted by the server, we anticipate that this state might contain information that's specific to the operating environment. This could be in the form of a file path, a permission, a handle or other indirect reference, or some other piece of server-specific data. Such information should generally not be disclosed to an untrusted client. Thus the second requirement: confidentiality.

Finally, since modern applications are componentized, what we've seen is that individual components will want to take advantage of this system without regard to other components in the system. For instance, if a bearer token component is using this stack, it should operate without interference from an anti-CSRF mechanism that might also be using the same stack. Thus the final requirement: isolation.

We can provide further constraints in order to narrow the scope of our requirements. We assume that all services operating within the cryptosystem are equally trusted and that the data doesn't need to be generated or consumed outside of the services under our direct control. Furthermore, we require that operations are as fast as possible since each request to the web service might go through the cryptosystem one or more times. This makes symmetric cryptography ideal for our scenario, and we can discount asymmetric cryptography until such a time that it's needed.

## Design philosophy

We started by identifying problems with the existing stack. Once we had that, we surveyed the landscape of existing solutions and concluded that no existing solution quite had the capabilities we sought. We then engineered a solution based on several guiding principles.

* The system should offer simplicity of configuration. Ideally the system would be zero-configuration and developers could hit the ground running. In situations where developers need to configure a specific aspect (such as the key repository), consideration should be given to making those specific configurations simple.

* Offer a simple consumer-facing API. The APIs should be easy to use correctly and difficult to use incorrectly.

* Developers shouldn't have to learn key management principles. The system should handle algorithm selection and key lifetime on the developer's behalf. Ideally the developer should never even have access to the raw key material.

* Keys should be protected at rest when possible. The system should figure out an appropriate default protection mechanism and apply it automatically.

With these principles in mind we developed a simple, [easy to use](xref:security/data-protection/using-data-protection) data protection stack.

The ASP.NET Core data protection APIs are not primarily intended for indefinite persistence of confidential payloads. Other technologies like [Windows CNG DPAPI](/windows/win32/seccng/cng-dpapi) and [Azure Rights Management](/rights-management/) are more suited to the scenario of indefinite storage, and they have correspondingly strong key management capabilities. That said, there's nothing prohibiting a developer from using the ASP.NET Core data protection APIs for long-term protection of confidential data.

## Audience

The data protection system is divided into five main packages. Various aspects of these APIs target three main audiences;

1. The [Consumer APIs Overview](xref:security/data-protection/consumer-apis/overview) target application and framework developers.

   "I don't want to learn about how the stack operates or about how it's configured. I simply want to perform some operation in as simple a manner as possible with high probability of using the APIs successfully."

2. The [configuration APIs](xref:security/data-protection/configuration/overview) target application developers and system administrators.

   "I need to tell the data protection system that my environment requires non-default paths or settings."

3. The extensibility APIs target developers in charge of implementing custom policy. Usage of these APIs would be limited to rare situations and experienced, security aware developers.

   "I need to replace an entire component within the system because I have truly unique behavioral requirements. I am willing to learn uncommonly-used parts of the API surface in order to build a plugin that fulfills my requirements."

## Package layout

The data protection stack consists of five packages.

* [Microsoft.AspNetCore.DataProtection.Abstractions](https://www.nuget.org/packages/Microsoft.AspNetCore.DataProtection.Abstractions/) contains the <xref:Microsoft.AspNetCore.DataProtection.IDataProtectionProvider> and <xref:Microsoft.AspNetCore.DataProtection.IDataProtector> interfaces to create data protection services. It also contains useful extension methods for working with these types (for example, [IDataProtector.Protect](xref:Microsoft.AspNetCore.DataProtection.DataProtectionCommonExtensions.Protect*)). If the data protection system is instantiated elsewhere and you're consuming the API, reference `Microsoft.AspNetCore.DataProtection.Abstractions`.

* [Microsoft.AspNetCore.DataProtection](https://www.nuget.org/packages/Microsoft.AspNetCore.DataProtection/) contains the core implementation of the data protection system, including core cryptographic operations, key management, configuration, and extensibility. To instantiate the data protection system (for example, adding it to an <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>) or modifying or extending its behavior, reference `Microsoft.AspNetCore.DataProtection`.

* [Microsoft.AspNetCore.DataProtection.Extensions](https://www.nuget.org/packages/Microsoft.AspNetCore.DataProtection.Extensions/) contains additional APIs which developers might find useful but which don't belong in the core package. For instance, this package contains factory methods to instantiate the data protection system to store keys at a location on the file system without dependency injection (see <xref:Microsoft.AspNetCore.DataProtection.DataProtectionProvider>). It also contains extension methods for limiting the lifetime of protected payloads (see <xref:Microsoft.AspNetCore.DataProtection.ITimeLimitedDataProtector>).

* [Microsoft.AspNetCore.DataProtection.SystemWeb](https://www.nuget.org/packages/Microsoft.AspNetCore.DataProtection.SystemWeb/) can be installed into an existing ASP.NET 4.x app to redirect its `<machineKey>` operations to use the new ASP.NET Core data protection stack. For more information, see <xref:security/data-protection/compatibility/replacing-machinekey>.

* [Microsoft.AspNetCore.Cryptography.KeyDerivation](https://www.nuget.org/packages/Microsoft.AspNetCore.Cryptography.KeyDerivation/) provides an implementation of the PBKDF2 password hashing routine and can be used by systems that must handle user passwords securely. For more information, see <xref:security/data-protection/consumer-apis/password-hashing>.

## Additional resources

* <xref:security/data-protection/using-data-protection>
* <xref:host-and-deploy/web-farm>
