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

Multi-factor authentication (MFA) is a process where a user is prompted during a sign-in event for additional forms of identification. This prompt could be to enter a code on their cellphone, use a FIDO2 key or to provide a fingerprint scan. When you require a second form of authentication, security is increased as this additional factor isn't something that's easy for an attacker to obtain or duplicate.

This article covers the following:

* What MFA is and what MFA flows are recommended
* Configure MFA for Admin Pages in an ASP.NET Core Identity application
* Send MFA signin requirement to OpenID Connect server 
* Force ASP.NET Core OpenID Connect client to require MFA

## MFA TOTP (Time-based One-time Password Algorithm)

Multi-factor authentication using TOTP is a supported implementation using ASP.NET Core Identity. This can be used together with the following Apps:

- Microsoft Authenticator App
- Google Authenticator App

See the following link for details:

[Enable QR Code generation for TOTP authenticator apps in ASP.NET Core](xref:security/authentication/identity-enable-qrcodes)

## MFA FIDO2 or Passwordless

FIDO2 is the most secure way of doing Multi-factor authentication and is the only MFA flow which protects against phishing attacks. At present ASP.NET Core does not support FIDO2 support. FIDO2 can be used for MFA or passwordless flows.

Azure Active Directory provides support for FIDO2 and passwordless flows.

[Passwordless authentication options for Azure Active Directory](https://docs.microsoft.com/en-us/azure/active-directory/authentication/concept-authentication-passwordless)

You can implement ASP.NET Core with FIDO2 by using the following OSS FIDO2 implementation:

[FIDO2 .NET library for FIDO2 / WebAuthn Attestation and Assertion using .NET](https://github.com/abergs/fido2-net-lib)

## MFA SMS

Although MFA with SMS increases security massively compared with just a password authentication, it is no longer recommended to use SMS as a second factor as too many known attack vectors exist for this type of implementation.


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



