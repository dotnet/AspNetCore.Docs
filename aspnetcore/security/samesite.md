---
title: SameSite
author: rick-anderson
description: Learn how to react to SameSite changes in ASP.NET Core
ms.author: riande
ms.custom: mvc
ms.date: 11/11/2019
uid: security/samesite
---
# React to SameSite changes in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

https://docs.microsoft.com/en-us/dotnet/api/system.identitymodel.services.wsfederationauthenticationmodule?view=netframework-4.8

Firefox and Chrome based browsers are making breaking changes to their implementations of [SameSite](https://tools.ietf.org/html/draft-west-first-party-cookies-07) for cookies. The SameSite changes impact remote authentication scenarios like [OpenID Connect](https://openid.net/connect/) and [WS-Federation](https://auth0.com/docs/protocols/ws-fed). With this change, OpenID Connect and WS-Federation must opt out by sending `SameSite=None`. However, setting `SameSite=None` doesn't work on iOS 12 and some older versions of other browsers. To support iOS 12 and older browsers, ASP.NET Core app's must detect these browsers and omit `SameSite`.

## SameSite draft standard

The [SameSite 2016 draft standard](https://tools.ietf.org/html/draft-west-first-party-cookies-07#section-4.1) extension to HTTP cookies:

* Was intended to mitigate cross site request forgery (CSRF).
* Was originally designed as a feature servers would opt into by adding the new "SameSite" attribute and attribute values to cookies.
* Is supported in ASP.NET 2.0 and later.

## New (2019) SameSite draft standard

The new [SameSite 2019 draft standard](https://tools.ietf.org/html/draft-west-cookie-incrementalism-00):

* Is not backwards compatible.
* Changes the default mode to `Lax`.
* Adds a new entry `None` to opt out. 

`Lax` is OK for most application cookies but breaks cross site scenarios like OpenIdConnect and Ws-Federation login. Most [OAuth](https://oauth.net/) logins are not affected due to differences in how the request flows. The new `None` parameter causes compatibility problems with clients that implemented the prior draft standard (for example, iOS 12). The Chrome browsers (Chrome 80) are expected to go live in February 2020 with the 2019 SameSite draft standard.