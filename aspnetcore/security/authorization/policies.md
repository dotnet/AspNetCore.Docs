---
title: Policy-based authorization in ASP.NET Core
ai-usage: ai-assisted
author: wadepickett
description: Learn how to create and use authorization policy handlers for enforcing authorization requirements in an ASP.NET Core app.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 07/10/2026
uid: security/authorization/policies
---
# Policy-based authorization in ASP.NET Core

An ASP.NET Core authorization policy is a named set of one or more authorization requirements that the framework evaluates to decide whether a user is allowed to access a resource.

This article explains:

* Creating requirements.
* Registering and applying policies.
* Authorization handlers for single and multiple requirement evaluation.
* How multiple requirements in a single policy are evaluated.

In practice, a policy is applied with `[Authorize(Policy = "...")]` (Razor components, pages, and controllers) or `RequireAuthorization(...)` (endpoints), and the framework uses handlers to evaluate the requirements behind a policy. <xref:Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider> (<xref:security/authorization/iauthorizationpolicyprovider> documentation) generates policies dynamically instead of registering them at app startup.

[Role-based authorization](xref:security/authorization/roles) and [claim-based authorization](xref:security/authorization/claims) use a requirement, a requirement handler, and a preconfigured authorization policy. These building blocks support the expression of authorization evaluations in code.

This article uses Razor component examples and focuses on [Blazor](xref:blazor/index) authorization scenarios for ASP.NET Core 3.1 or later. For Razor Pages and MVC guidance, which apply to all releases of ASP.NET Core, see the following resources after reading this article:

* <xref:razor-pages/security/authorization/policies>
* <xref:mvc/security/authorization/policies>

Examples in this article use *primary constructors*, available in C# 12 (.NET 8) or later. For more information, see [Declare primary constructors for classes and structs (C# documentation tutorial)](/dotnet/csharp/whats-new/tutorials/primary-constructors) and [Primary constructors (C# Guide)](/dotnet/csharp/programming-guide/classes-and-structs/instance-constructors#primary-constructors).

## Requirements and policy registration

An authorization policy consists of one or more *requirements*. An authorization requirement is a collection of data parameters that a policy can use to evaluate authorization for the current user principal.

A requirement implements <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>, which is an empty marker interface. Consider the following `MinimumAgeRequirement` requirement, which describes a single parameter, a minimum age, to evaluate for user authorization:

:::moniker range=">= aspnetcore-8.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/BlazorWebAppAuthorization/Policies/Requirements/MinimumAgeRequirement.cs":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/6.0/AuthorizationPoliciesSample/Policies/Requirements/MinimumAgeRequirement.cs":::

:::moniker-end

:::moniker range="< aspnetcore-6.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/PoliciesAuthApp1/Services/Requirements/MinimumAgeRequirement.cs":::

:::moniker-end

If an authorization policy contains multiple authorization requirements, all of the requirements must pass in order for the policy evaluation to succeed. In other words, multiple authorization requirements added to a single authorization policy are treated on an **AND** basis.

> [!NOTE]
> A requirement doesn't require data or properties.

:::moniker range=">= aspnetcore-7.0"

A policy is registered as part of the authorization service configuration with <xref:Microsoft.AspNetCore.Authorization.AuthorizationBuilder.AddPolicy%2A?displayProperty=nameWithType> in the app's `Program` file. In the following example, the `AtLeast21` policy is created with a single requirement of a minimum age (`MinimumAgeRequirement`) and setting the minimum age to 21 years old:

```csharp
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("AtLeast21", policy => 
        policy.Requirements.Add(new MinimumAgeRequirement(21)));
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

A policy is registered as part of the authorization service configuration with <xref:Microsoft.AspNetCore.Authorization.AuthorizationOptions.AddPolicy%2A?displayProperty=nameWithType> in the app's `Program` file. In the following example, the `AtLeast21` policy is created with a single requirement of a minimum age (`MinimumAgeRequirement`) and setting the minimum age to 21 years old:

```csharp
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AtLeast21", policy =>
        policy.Requirements.Add(new MinimumAgeRequirement(21)));
});
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

A policy is registered as part of the authorization service configuration with <xref:Microsoft.AspNetCore.Authorization.AuthorizationOptions.AddPolicy%2A?displayProperty=nameWithType> in `Startup.ConfigureServices` (`Startup.cs`). In the following example, the `AtLeast21` policy is created with a single requirement of a minimum age (`MinimumAgeRequirement`) and setting the minimum age to 21 years old:

```csharp
services.AddAuthorization(options =>
{
    options.AddPolicy("AtLeast21", policy =>
        policy.Requirements.Add(new MinimumAgeRequirement(21)));
});
```

:::moniker-end

## Apply policies to Razor components

Apply policies to Razor components using the `[Authorize]` attribute with the policy name:

```razor
@using Microsoft.AspNetCore.Authorization
@attribute [Authorize(Policy = "CustomerServiceMember")]
```

If multiple policies are applied, ***all*** policies must pass before access is granted:

```razor
@using Microsoft.AspNetCore.Authorization
@attribute [Authorize(Policy = "CustomerServiceMember")]
@attribute [Authorize(Policy = "HumanResourcesMember")]
```

## Apply policies to endpoints

Apply policies to endpoints by using <xref:Microsoft.AspNetCore.Builder.AuthorizationEndpointConventionBuilderExtensions.RequireAuthorization%2A> with the policy name. For example:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/6.0/AuthorizationPoliciesSample/Program.cs" id="snippet_requireAuthorization":::

## Apply policies in MVC and Razor Pages apps

For guidance on applying policies in Razor Pages and MVC apps, see the following resources:

* <xref:razor-pages/security/authorization/policies>
* <xref:mvc/security/authorization/policies>

## Authorization service interface (`IAuthorizationService`)

<xref:Microsoft.AspNetCore.Authorization.IAuthorizationService> is primarily responsible for determining if authorization is successful when an <xref:Microsoft.AspNetCore.Authorization.IAuthorizationService.AuthorizeAsync%2A?displayProperty=nameWithType> overload is called:

* `AuthorizeAsync(ClaimsPrincipal user, object resource, IEnumerable<IAuthorizationRequirement> requirements)`: Checks if a user meets a specific set of authorization requirements for a specified resource.
* `AuthorizeAsync(ClaimsPrincipal user, object resource, string policyName)`: Checks if a user meets a specific authorization policy for a specified resource.

If a resource isn't required for policy evaluation, `null` is passed for the resource.

The preceding methods return `true` when authorization succeeds and `false` when it fails.

Each <xref:Microsoft.AspNetCore.Authorization.IAuthorizationHandler> is responsible for checking if requirements are met via <xref:Microsoft.AspNetCore.Authorization.IAuthorizationHandler.HandleAsync%2A?displayProperty=nameWithType>. The <xref:Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext> class contains the authorization information used by the <xref:Microsoft.AspNetCore.Authorization.IAuthorizationHandler> implementation. <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirement> is a marker interface with no methods that serves as the mechanism for tracking whether authorization is successful. When <xref:Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext.Succeed%2A?displayProperty=nameWithType> is called with the <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>, the policy is met:

```csharp
context.Succeed(requirement);
```

## Authorization handlers

An authorization handler is responsible for the evaluation of a requirement's properties. The authorization handler evaluates the requirements against a provided <xref:Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext> to determine if access is allowed.

A requirement can have [multiple handlers](#why-would-i-want-multiple-handlers-for-a-requirement). A handler may inherit <xref:Microsoft.AspNetCore.Authorization.AuthorizationHandler%601>, where `TRequirement` is the requirement to handle. Alternatively, a handler may implement <xref:Microsoft.AspNetCore.Authorization.IAuthorizationHandler> directly to handle more than one type of requirement.

### Use a handler for one requirement

The following example shows a one-to-one relationship in which a minimum age handler handles a single requirement:

:::moniker range=">= aspnetcore-8.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/BlazorWebAppAuthorization/Policies/Handlers/MinimumAgeHandler.cs":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/6.0/AuthorizationPoliciesSample/Policies/Handlers/MinimumAgeHandler.cs":::

:::moniker-end

:::moniker range="< aspnetcore-6.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/PoliciesAuthApp1/Services/Handlers/MinimumAgeHandler.cs":::

:::moniker-end

The preceding code determines if the current user principal has a date of birth claim. Authorization can't occur when the claim is missing, in which case a completed task is returned. When a claim is present, the user's age is calculated. If the user meets the minimum age defined by the requirement, authorization is considered successful. When authorization is successful, [`context.Succeed`](xref:Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext.Succeed%2A) is invoked with the satisfied requirement as its sole parameter.

### Use a handler for multiple requirements

The following example shows a one-to-many relationship in which a permission handler can handle three different types of requirements:

:::moniker range=">= aspnetcore-6.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/BlazorWebAppAuthorization/Policies/Handlers/PermissionHandler.cs":::

:::moniker-end

:::moniker range="< aspnetcore-6.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/PoliciesAuthApp1/Services/Handlers/PermissionHandler.cs":::

:::moniker-end

The preceding code traverses <xref:Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext.PendingRequirements%2A>&mdash;a property containing requirements not marked as successful. For a `ReadPermission` requirement, the user must be either an owner or a sponsor to access the requested resource. For an `EditPermission` or `DeletePermission` requirement, they must be an owner to access the requested resource.

### Handler registration

Register handlers in the services collection during configuration. The following example registers a minimum age handler (`MinimumAgeHandler`) as singleton service, but a handler can be registered using any of the built-in [service lifetimes](xref:fundamentals/dependency-injection#service-lifetimes):

:::moniker range=">= aspnetcore-6.0"

```csharp
builder.Services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();
```

:::moniker-end

It's possible to bundle both a requirement and a handler into a single class implementing both <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirement> and <xref:Microsoft.AspNetCore.Authorization.IAuthorizationHandler>. This bundling creates a tight coupling between the handler and requirement and is only recommended for simple requirements and handlers. Creating a class that implements both interfaces removes the need to register the handler in the service container due to the built-in <xref:Microsoft.AspNetCore.Authorization.Infrastructure.PassThroughAuthorizationHandler> that allows requirements to handle themselves.

See the [implementation of the ASP.NET Core `AssertionRequirement` class](https://github.com/dotnet/aspnetcore/blob/main/src/Security/Authorization/Core/src/AssertionRequirement.cs) for an example where the <xref:Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement> is both a requirement and the handler in a fully self-contained class. The <xref:Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement> framework's API allows you to validate access using inline lambda expressions instead of writing separate, boilerplate requirement and handler classes.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

### What should a handler return?

The `Handle` method in the [handler example](#use-a-handler-for-one-requirement) returns no value. How is a status of either success or failure indicated?

* A handler indicates success by calling [`context.Succeed`](xref:Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext.Succeed%2A), passing the successfully validated requirement (<xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>).

* A handler isn't required to handle failures generally, as other handlers for the same requirement may succeed.

* To guarantee failure, even if other requirement handlers succeed, call [`context.Fail`](xref:Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext.Fail%2A).

If a handler calls [`context.Succeed`](xref:Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext.Succeed%2A) or [`context.Fail`](xref:Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext.Fail%2A), all other handlers are still called. This allows requirements to produce side effects, such as logging, which takes place even if another handler successfully validates or fails on a requirement. When set to `false`, the <xref:Microsoft.AspNetCore.Authorization.AuthorizationOptions.InvokeHandlersAfterFailure%2A> property short-circuits the execution of handlers when [`context.Fail`](xref:Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext.Fail%2A) is called. <xref:Microsoft.AspNetCore.Authorization.AuthorizationOptions.InvokeHandlersAfterFailure%2A> defaults to `true`, in which case all handlers are called.

> [!NOTE]
> Authorization handlers are called even if authentication fails. Also handlers can execute in any order, so do ***not*** depend on the order of calling handlers.

### Why would I want multiple handlers for a requirement?

In cases where you want evaluation to be on an **OR** basis, implement multiple handlers for a single requirement. For example, assume that the Contoso Corporation has doors that only open with key cards. If you leave your key card at home, the receptionist prints a temporary sticker and opens the door for you. In this scenario, the app has a single requirement but multiple handlers, each one examining a single requirement.

In the following example implementations:

* `BuildingEntryRequirement` is the building entry requirement.
* `BadgeEntryHandler` (the individual has a badge) and `TemporaryStickerHandler` (the individual has a temporary sticker) are separate handlers, each examining a single requirement.

:::moniker range=">= aspnetcore-6.0"

`BuildingEntryRequirement.cs`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/BlazorWebAppAuthorization/Policies/Requirements/BuildingEntryRequirement.cs":::

`BadgeEntryHandler.cs`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/BlazorWebAppAuthorization/Policies/Handlers/BadgeEntryHandler.cs":::

`TemporaryStickerHandler.cs`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/BlazorWebAppAuthorization/Policies/Handlers/TemporaryStickerHandler.cs":::

:::moniker-end

:::moniker range="< aspnetcore-6.0"

`BuildingEntryRequirement.cs`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/PoliciesAuthApp1/Services/Requirements/BuildingEntryRequirement.cs":::

`BadgeEntryHandler.cs`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/PoliciesAuthApp1/Services/Handlers/BadgeEntryHandler.cs":::

`TemporaryStickerHandler.cs`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/PoliciesAuthApp1/Services/Handlers/TemporaryStickerHandler.cs":::

:::moniker-end

Ensure that both handlers are [registered](xref:security/authorization/policies#handler-registration). If either of the handlers succeed when a policy evaluates the `BuildingEntryRequirement`, the policy evaluation succeeds.

## Use a `Func` to fulfill a policy

There are situations where fulfilling a policy is simple to express in code with a `Func<AuthorizationHandlerContext, bool>` delegate when configuring a policy with the `RequireAssertion` policy builder. For example, the preceding `BadgeEntryHandler` can be rewritten as follows:

:::moniker range=">= aspnetcore-6.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/6.0/AuthorizationPoliciesSample/Program.cs" range="20-21,25-29":::

:::moniker-end

:::moniker range="< aspnetcore-6.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/3.0PoliciesAuthApp1/Startup.cs" range="42-43,47-53":::

:::moniker-end

## Require global user authentication

For information on how to require authentication for all app users, see <xref:security/authorization/secure-data#require-authenticated-users>.

:::moniker range=">= aspnetcore-6.0"

## Authorization via an external service sample

The [Authorization via an external service sample (`dotnet/AspNetCore.Docs.Samples` GitHub repository)](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/security/authorization/AuthorizationExternalService) shows how to implement additional authorization requirements with an external authorization service. The solution's `Contoso.API` project is secured with [Microsoft Entra ID](/entra/fundamentals/what-is-entra). An additional authorization check from the `Contoso.Security.API` project returns a payload describing whether the `Contoso.API` client app can invoke the `GetWeather` API.

### Configure the sample

The following demonstration relies on using the [Nswag (Swagger/OpenAPI)](https://github.com/RicoSuter/NSwag) or [cURL](https://curl.se/) in a command shell.

In the `Contoso.Security.API` project, configure the `AllowedClients` placeholder of `{CLIENT ID (FOR THE CLIENT CALLING CONTOSO.API)}` of the  with any test GUID value (for example, `00001111-aaaa-2222-bbbb-3333cccc4444`):

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/AuthorizationExternalService/Contoso.Security.API/appsettings.json":::

In a command shell opened to the `Contoso.API` project, use [`dotnet user-jwts`](xref:security/authentication/jwt) to generate an access token with an `appid` claim for the client app's ID, which was created in the preceding step (for example, `00001111-aaaa-2222-bbbb-3333cccc4444`).

```dotnetcli
dotnet user-jwts create --claim appid={GUID}
```

Example:

```dotnetcli
dotnet user-jwts create --claim appid=00001111-aaaa-2222-bbbb-3333cccc4444
```

The output produces a token after "`Token:`" in the command shell:

```dotnetcli
New JWT saved with ID '{JWT ID}'.
Name: {USER}
Custom Claims: [appid=00001111-aaaa-2222-bbbb-3333cccc4444]

Token: {TOKEN}
```

Set the value of the token (where the `{TOKEN}` placeholder appears in the preceding output) aside for use later.

You can decode the token in an online JWT decoder, such as [`jwt.ms`](https://jwt.ms/) to see its contents, revealing that it contains an `appid` claim with the client app's ID:

```json
{
  "alg": "HS256",
  "typ": "JWT"
}.{
  "unique_name": "{USER}",
  "sub": "{USER}",
  "jti": "14ed7729",
  "appid": "9e7b23cf-2f98-48b5-a681-42cb4fb0df68",
  "aud": [
    "https://localhost:7250",
    "http://localhost:7251"
  ],
  "nbf": 1780660887,
  "exp": 1788609687,
  "iat": 1780660888,
  "iss": "dotnet-user-jwts"
}.[Signature]
```

Execute the command again with an incorrect client ID (`appid`) value:

```dotnetcli
dotnet user-jwts create --claim appid=aaaabbbb-0000-cccc-1111-dddd2222eeee
```

Set the value of second token aside.

Start both the `Contoso.API` and `Contoso.Security.API` projects in Visual Studio or with the `dotnet watch` command in a command shell:

```dotnetcli
dotnet watch
```

# [Swagger UI](#tab/swagger-ui)

In the Swagger UI of the `Contoso.API` project (`https://localhost:7250/swagger/index.html`), select the **Authorize** button.

In the **Available authorizations: Bearer** window, enter the access token. Select the **Authorize** button. Close the **Available authorizations** window.

Under **default**, select the **Get** button for the `/WeatherForecast` endpoint. Select the **Try it out** button. Select the **Execute** button.

The output under **Responses** > **Server response** > **Response body** shows the weather forecast JSON returned by the `Contoso.API` project.

Perform the same steps with the access token that was generated with an invalid client app ID. The response is *403 - Forbidden*.

# [cURL in a command shell](#tab/curl-command-shell)

In a command shell, use the .NET CLI to execute the following `curl.exe` command to request the `WeatherForecast` endpoint. Replace the `{TOKEN}` placeholder with the first JWT bearer token that you saved earlier:

```dotnetcli
curl.exe -i -H "Authorization: Bearer {TOKEN}" https://localhost:7250/WeatherForecast
```

The output indicates success because the user's birth date claim indicates that they're at least 21 years old:

```dotnetcli
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8
Date: Fri, 05 Jun 2026 12:48:58 GMT
Server: Kestrel
Transfer-Encoding: chunked

[{ ... WEATHER DATA ... }]
```

Execute the command again using the second token with the invalid client ID (`appid`). The result indicates a policy failure:

```dotnetcli
HTTP/1.1 403 Forbidden
Content-Length: 0
Date: Fri, 05 Jun 2026 13:09:56 GMT
Server: Kestrel
```

You can add breakpoints in the `Contoso.Security.API.SecurityPolicyController` and observe the passed client ID (`appid`) is used to assert whether it is allowed to obtain weather data.

You can also send the client ID directly to the `Contoso.Security.API` either via the Swagger UI or cURL in a command shell (for example: ``) to see it return either `true` or `false` for `canGetWeather`

```dotnetcli
curl.exe -i -H "Authorization: Bearer {TOKEN}" https://localhost:7123/SecurityPolicy/9e7b23cf-2f98-48b5-a681-42cb4fb0df68
```

With the correct client ID (`appid`), `canGetWeather` is `true`:

```dotnetcli
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8
Date: Fri, 05 Jun 2026 13:19:49 GMT
Server: Kestrel
Transfer-Encoding: chunked

{"canGetWeather":true}
```

---

## Additional resources

* [Quickstart: Configure an application to expose a web API](/entra/identity-platform/quickstart-configure-app-expose-web-apis)
* [Authorization via an external service sample (`dotnet/AspNetCore.Docs.Samples` GitHub repository)](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/security/authorization/AuthorizationExternalService)

:::moniker-end
