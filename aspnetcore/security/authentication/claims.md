---
title: Multi-factor authentication in ASP.NET Core
author: damienbod
description: Learn how to map claims, do claims transformations, customize claims.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 05/28/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/authentication/mfa
---
# Mapping claims, customizing claims and transforming claims in ASP.NET Core

By [Damien Bowden](https://github.com/damienbod)

Claims can be used to store data from identity data which can be issued using a trusted identity provider or ASP.NET Core identity. A claim is a name value pair that represents what the subject is, not what the subject can do.
This article covers the following areas:

* How to configure map claims using an OpenID Connect client
* Set the name claim and the role claim
* Reset the claims namespaces
* Customize, extend the claims with ASP.NET Core Identity

## Claims mapping using Open ID Connect authentication

## Name claim and role claim mapping

## Claims namespaces

## Extending or adding custom claims in ASP.NET Core Identity

## Map claims from external identity providers