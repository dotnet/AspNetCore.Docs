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

### ID tokens

### Refresh tokens

### Access tokens

#### Access tokens for applications

#### Delegeted Access tokens

#### Sender constrained access tokens

- Demonstrating Proof-of-Possession (DPoP)
- MTLS

### OAuth tokens, JAR and id_token_hint other tokens

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

[The OAuth 2.0 Authorization Framework](https://datatracker.ietf.org/doc/html/rfc6749)

[OAuth 2.0 Demonstrating Proof of Possession DPoP](https://datatracker.ietf.org/doc/html/rfc9449)

[OAuth 2.0 JWT-Secured Authorization Request (JAR) RFC 9101](https://datatracker.ietf.org/doc/rfc9101/)

[OAuth 2.0 Mutual-TLS Client Authentication and Certificate-Bound Access Tokens](https://datatracker.ietf.org/doc/html/rfc8705)

[OpenID Connect 1.0](https://openid.net/specs/openid-connect-core-1_0-final.html)
