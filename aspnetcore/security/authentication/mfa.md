---
title: Multi-factor authentication
author: damienbod
description: Multi-factor authentication
monikerRange: '>= aspnetcore-3.1'
ms.author: todo
ms.custom: mvc
ms.date: 02/25/2020
no-loc: [Identity]
uid: security/authentication/mfa
---
# Multi-factor authentication

By [Damien Bowden](https://github.com/damienbod)

Multi-factor authentication (MFA) is a process where a user is prompted during a sign-in event for additional forms of identification. This prompt could be to enter a code on their cellphone or to provide a fingerprint scan. When you require a second form of authentication, security is increased as this additional factor isn't something that's easy for an attacker to obtain or duplicate.

Multi-Factor authentication and Conditional Access policies give the flexibility to enable MFA for users during specific sign-in events.

This article covers the following:

* What MFA is and what MFA flows are recommended
* Configure MFA for Admin Pages in an ASP.NET Core Identity application
* Send MFA signin requirement to OpenID Connect server 
* Force ASP.NET Core OpenID Connect client to require MFA

## MFA TOTP (Time-based One-time Password Algorithm)

Microsoft Authenticator App

Google Authenticator App



## MFA FIDO2 or Passwordless



[Passwordless authentication options for Azure Active Directory](https://docs.microsoft.com/en-us/azure/active-directory/authentication/concept-authentication-passwordless)

FIDO2 ASP.NET Core OSS project

[FIDO2 .NET library for FIDO2 / WebAuthn Attestation and Assertion using .NET](https://github.com/abergs/fido2-net-lib)

## MFA SMS




## MFA ASP.NET Core Identity

[Enable QR Code generation for TOTP authenticator apps in ASP.NET Core](xref:security/authentication/identity-enable-qrcodes)

## Configure MFA for Admin Pages in an ASP.NET Core Identity application

## Send MFA signin requirement to OpenID Connect server 

## Force ASP.NET Core OpenID Connect client to require MFA

```csharp
```

```razor
```




## Additional resources

* [Enable QR Code generation for TOTP authenticator apps in ASP.NET Core](xref:security/authentication/identity-enable-qrcodes)

* [Passwordless authentication options for Azure Active Directory](https://docs.microsoft.com/en-us/azure/active-directory/authentication/concept-authentication-passwordless)

* [FIDO2 .NET library for FIDO2 / WebAuthn Attestation and Assertion using .NET](https://github.com/abergs/fido2-net-lib)

* [WebAuthn Awesome](https://github.com/herrjemand/awesome-webauthn)



