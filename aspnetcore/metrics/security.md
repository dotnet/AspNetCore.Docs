---
title: ASP.NET Core built-in authentication and authorization metrics
ai-usage: ai-assisted
author: guardrex
description: Learn about built-in authentication and authorization metrics for ASP.NET Core apps.
monikerRange: '>= aspnetcore-10.0'
ms.author: wpickett
ms.date: 08/05/2026
ms.topic: reference
uid: metrics/security
---
# ASP.NET Core built-in authentication and authorization metrics

This article describes the built-in authentication and authorization metrics for ASP.NET Core produced using the <xref:System.Diagnostics.Metrics?displayProperty=nameWithType> API. These metrics cover authorization attempts and authentication operations. They're available in ASP.NET Core 10.0 or later.

For an overview of all built-in metrics reference pages and how to read this reference, see <xref:metrics/built-in>. For information on how to collect, report, enrich, and test with ASP.NET Core metrics, see <xref:metrics/overview>.

## `Microsoft.AspNetCore.Authorization`

The `Microsoft.AspNetCore.Authorization` metrics report information about [authorization attempts](xref:security/authorization/introduction) in ASP.NET Core apps:

* [`aspnetcore.authorization.attempts`](#metric-aspnetcoreauthorizationattempts)

### Metric: `aspnetcore.authorization.attempts`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.authorization.attempts` | Counter | `{request}` | The total number of requests for which authorization was attempted.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`user.is_authenticated` | boolean | Whether the request came from an authenticated user. | `true` | `Required`
`aspnetcore.authorization.policy` | string | The name of the authorization policy. | `AtLeast21`; `EmployeeOnly` | `Conditionally Required` if an authorization policy is used.
`aspnetcore.authorization.result` | string | Whether the authorization succeeded or failed. | `success`; `failure` | `Conditionally Required` if an exception is not thrown during authorization.
`error.type` | string | The full name of the exception type. | `System.InvalidOperationException`; `Contoso.MyException` | `Conditionally Required` if the request has ended with an error.

## `Microsoft.AspNetCore.Authentication`

The `Microsoft.AspNetCore.Authentication` metrics report information about [Authentication](xref:security/authentication/index) in ASP.NET Core apps:

* [`aspnetcore.authentication.authenticate.duration`](#metric-aspnetcoreauthenticationauthenticateduration)
* [`aspnetcore.authentication.challenges`](#metric-aspnetcoreauthenticationchallenges)
* [`aspnetcore.authentication.forbids`](#metric-aspnetcoreauthenticationforbids)
* [`aspnetcore.authentication.sign_ins`](#metric-aspnetcoreauthenticationsign_ins)
* [`aspnetcore.authentication.sign_outs`](#metric-aspnetcoreauthenticationsign_outs)

### Metric: `aspnetcore.authentication.authenticate.duration`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.authentication.authenticate.duration` | Histogram | `s` | The authentication duration for a request.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.authentication.result` | string | The authentication result. | `success`; `failure`; `none`; `_OTHER` | `Conditionally Required` if the request did not end with an error.
`aspnetcore.authentication.scheme` | string | The name of the authentication scheme. | `Bearer`; `Cookies` | `Conditionally Required` if the request did not end with an error.
`error.type` | string | The full name of the exception type. | `System.InvalidOperationException`; `Contoso.MyException` | `Conditionally Required` if authentication failed or the request has ended with an error.

### Metric: `aspnetcore.authentication.challenges`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.authentication.challenges` | Counter | `{request}` | The total number of times a scheme is challenged.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.authentication.scheme` | string | The name of the authentication scheme. | `Bearer`; `Cookies` | `Conditionally Required` if the request did not end with an error.
`error.type` | string | The full name of the exception type. | `System.InvalidOperationException`; `Contoso.MyException` | `Conditionally Required` if the request has ended with an error.

### Metric: `aspnetcore.authentication.forbids`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.authentication.forbids` | Counter | `{request}` | The total number of times an authenticated user attempts to access a resource they aren't permitted to access.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.authentication.scheme` | string | The name of the authentication scheme. | `Bearer`; `Cookies` | `Conditionally Required` if the request did not end with an error.
`error.type` | string | The full name of the exception type. | `System.InvalidOperationException`; `Contoso.MyException` | `Conditionally Required` if the request has ended with an error.

### Metric: `aspnetcore.authentication.sign_ins`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.authentication.sign_ins` | Counter | `{request}` | The total number of times a principal is signed in with a scheme.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.authentication.scheme` | string | The name of the authentication scheme. | `Bearer`; `Cookies` | `Conditionally Required` if the request did not end with an error.
`error.type` | string | The full name of the exception type. | `System.InvalidOperationException`; `Contoso.MyException` | `Conditionally Required` if the request has ended with an error.

### Metric: `aspnetcore.authentication.sign_outs`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.authentication.sign_outs` | Counter | `{request}` | The total number of times a principal is signed out with a scheme.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.authentication.scheme` | string | The name of the authentication scheme. | `Bearer`; `Cookies` | `Conditionally Required` if the request did not end with an error.
`error.type` | string | The full name of the exception type. | `System.InvalidOperationException`; `Contoso.MyException` | `Conditionally Required` if the request has ended with an error.

## Additional resources

* <xref:metrics/built-in>
* <xref:metrics/http>
* <xref:metrics/diagnostics>
* <xref:metrics/blazor>
* <xref:metrics/overview>
