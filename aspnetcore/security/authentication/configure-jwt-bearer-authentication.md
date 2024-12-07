---
title: Configure JWT bearer authentication in ASP.NET Core
author: damienbod
description: Learn how to set up JWT bearer authentication in an ASP.NET Core app.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 12/7/2024
uid: security/authentication/configure-jwt-bearer-authentication
---
# Configure JWT bearer authentication in ASP.NET Core

By [Damien Bowden](https://github.com/damienbod)

This article covers the following areas:

* Token types
* Using JWT tokens to secure an APIs
* How OIDC/OAuth fits into this?
* Examples with code snippets
* Recommended approaches to create a JWT
* Downstream APIs
* Advanced features, standards
* Testing APIs

Is this really authentication?

## Token types

There are many different types of tokens and many formats. You should not be creating access tokens or ID tokens yourself unless in testing scenarios. Creating self-made tokens and not following standards usually ends up with security problems and can only be used in closed systems. It is recommended to use OpenID Connect and/or OAuth to create access tokens for API access. 

### Access tokens

An access token is a string used by a client application to make requests to the server implementing an API. Access tokens can vary in format and different APIs may use different formats for their tokens.

An access token can be encrypted. Access tokens should never be read or interpreted by a web client or UI application holding the access token, only an API is the intended audience.

Access tokens are intended solely for making requests to an API. This is normally sent to the API is the **Authorization** request header as a bearer token.

[OAUTH spec](datatracker.ietf.org/doc/html/rfc6749#section-1.4)

#### Application access tokens and delegeted Access tokens

When requesting or creating an access token, an application or an application acting on behalf of a user can request and access token. The tokens are **application access tokens** or **delegated access tokens**. The tokens have different claims and are handled and persisted in different ways. An application is normally persisted once in the application until it expires where the delegated access token is persisted per user, either in a cookie or in a cache on a secure server.

#### Sender constrained access tokens

There are two types of access tokens: **bearer tokens** and **sender-constrained** tokens. Sender-constrained tokens require the requesting client to prove possession of a private key to use the token, making the token unusable on its own. Sender-constrained tokens can be implemented in two ways:

- Demonstrating Proof-of-Possession (DPoP)
- MTLS

### ID tokens

ID tokens are security tokens that confirm a user’s successful authentication. They allow the client to verify the user’s identity. The authorization server issues ID tokens containing claims with user information. ID tokens are always in JWT (JSON Web Token) format.

ID tokens should never be used to access APIs.

### Other tokens

There are many different types of tokens as well as access tokens and ID tokens. OpenID Connect and OAuth standards specify many different types. Refresh tokens can be used to refresh a UI application without authenticating the user again, OAuth JAR tokens can be used to send authorization requests is a secure way. Verifiable credentials using JWT types in issuing or verifying credentials. It is important to use the tokens following the specifications. Please refer to the Standards provided in the links for more information.

## Using JWT tokens to secure an API

### 401

### 403

## How OIDC/OAuth fits into this?

### OIDC and user access tokens

### OAuth application tokens

## Examples with code snippets

## Recommended approaches to create a JWT

### Use standards

### Use asymmetric keys

### Why creating your own access tokens is normally a bad idea

### Should I create an access token from a username/password request?

## Downstream APIs

### OAuth downstream application tokens

### Microsoft OBO downstream access tokens

### How Yarp can help

## Advanced features, standards

### Access token rotation

### Access tokens and cache

### Encypted access tokens

## Testing APIs

### Testing application access tokens

### Testing delegated access tokens

### Use Swagger, Postman and other API UI tools

## Map claims from OpenID Connect

Refer to the following document:

[Mapping, customizing, and transforming claims in ASP.NET Core](xref:security/authentication/claims)

## Standards

[JSON Web Token (JWT)](https://datatracker.ietf.org/doc/html/rfc7519)

[The OAuth 2.0 Authorization Framework](https://datatracker.ietf.org/doc/html/rfc6749)

[OAuth 2.0 Demonstrating Proof of Possession DPoP](https://datatracker.ietf.org/doc/html/rfc9449)

[OAuth 2.0 JWT-Secured Authorization Request (JAR) RFC 9101](https://datatracker.ietf.org/doc/rfc9101/)

[OAuth 2.0 Mutual-TLS Client Authentication and Certificate-Bound Access Tokens](https://datatracker.ietf.org/doc/html/rfc8705)

[OpenID Connect 1.0](https://openid.net/specs/openid-connect-core-1_0-final.html)

[Microsoft identity platform and OAuth 2.0 On-Behalf-Of flow](https://learn.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-on-behalf-of-flow)

[OAuth 2.0 Token Exchange](https://datatracker.ietf.org/doc/html/rfc8693)
