---
title: Use Identity to secure a Web API backend for SPAs
author: JeremyLikness
description: Learn how to use Identity to secure a Web API backend for single page applications (SPAs).
monikerRange: '>= aspnetcore-3.0'
ms.author: tdykstra
ms.date: 11/09/2023
uid: security/authentication/identity/spa
---
# How to use Identity to secure a Web API backend for SPAs

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-8.0"

[ASP.NET Core Identity](xref:security/authentication/identity) provides APIs that handle authentication, authorization, and identity management. The APIs make it possible to secure endpoints of a Web API backend with cookie-based authentication. There's a token-based option for clients that can't use cookies.

This article shows how to use Identity to secure a Web API backend for SPAs such as Angular, React, and Vue apps. The same backend APIs can be used to secure [Blazor WebAssembly apps](xref:blazor/security/webassembly/standalone-with-identity).

## Prerequisites

The steps shown in this article add authentication and authorization to an ASP.NET Core Web API app that:

* Targets `net8.0` or later.
* Includes OpenAPI support.
* Can be either minimal API or controller-based API.

## Install NuGet packages

Install the following NuGet packages:

* [`Microsoft.AspNetCore.Identity.EntityFrameworkCore`](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.EntityFrameworkCore) - Enables Identity to work with Entity Framework Core (EF Core).
* One that enables EF Core to work with a database, such as one of the following packages:
  * [`Microsoft.EntityFrameworkCore.SqlServer`](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer) or
  * [`Microsoft.EntityFrameworkCore.Sqlite`](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite) or
  * [`Microsoft.EntityFrameworkCore.InMemory`](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.InMemory).

For the quickest way to get started, use the in-memory database.

Change the database later to SQLite or SQL Server to save user data between sessions when testing or for production use. That introduces some complexity compared to in-memory, as it requires the database to be created through [migrations](/ef/core/managing-schemas/migrations/), as shown in the [EF Core getting started tutorial](/ef/core/get-started/overview/first-app).

Install these packages by using the [NuGet package manager in Visual Studio](/nuget/consume-packages/install-use-packages-visual-studio) or the [dotnet add package](/dotnet/core/tools/dotnet-add-package) CLI command.

## Create an `IdentityDbContext`

Add a class named `ApplicationDbContext` that inherits from <xref:Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext%601>:

```csharp
public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options) { }
}
```

The code shown provides a special constructor that makes it possible to configure the database for different environments.

Add one or more of the following `using` directives as needed when adding the code shown in these steps.

```csharp
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
```

## Configure the EF Core context

As noted earlier, the simplest way to get started is to use the in-memory database. With in-memory each run starts with a fresh database, and there's no need to use migrations. After the call to `WebApplication.CreateBuilder(args)`, add the following code to configure Identity to use an in-memory database:

```csharp
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseInMemoryDatabase("AppDb"));
```

To save user data between sessions when testing or for production use, change the database later to SQLite or SQL Server.
    
## Add Identity services to the container

After the call to `WebApplication.CreateBuilder(args)`, call <xref:Microsoft.Extensions.DependencyInjection.AuthorizationServiceCollectionExtensions.AddAuthorization%2A> to add services to the dependency injection (DI) container:

```csharp
builder.Services.AddAuthorization();
```

## Activate Identity APIs

After the call to `WebApplication.CreateBuilder(args)`, call <xref:Microsoft.Extensions.DependencyInjection.IdentityServiceCollectionExtensions.AddIdentityApiEndpoints%60%601(Microsoft.Extensions.DependencyInjection.IServiceCollection)> and <xref:Microsoft.Extensions.DependencyInjection.IdentityEntityFrameworkBuilderExtensions.AddEntityFrameworkStores%60%601(Microsoft.AspNetCore.Identity.IdentityBuilder)>.

```csharp
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
```

By default, both cookies and proprietary tokens are activated. Cookies are issued if the `useCookies` query string parameter in the login endpoint is `true`.

## Map Identity routes

After the call to `builder.Build()`, call <xref:Microsoft.AspNetCore.Routing.IdentityApiEndpointRouteBuilderExtensions.MapIdentityApi%60%601(Microsoft.AspNetCore.Routing.IEndpointRouteBuilder)> to map the Identity endpoints:

```csharp
app.MapIdentityApi<IdentityUser>();
```

## Secure endpoints

To secure an endpoint, use the <xref:Microsoft.AspNetCore.Builder.AuthorizationEndpointConventionBuilderExtensions.RequireAuthorization%2A> extension method on the `Map{Method}` call that defines the route. For example:

```csharp
app.MapGet("/weatherforecast", (HttpContext httpContext) =>
{
    //var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = summaries[Random.Shared.Next(summaries.Length)]
        })
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi()
.RequireAuthorization();
```

The `RequireAuthorization` method can also be used to secure Swagger UI endpoints, as shown in the following example:
    
```csharp
app.MapSwagger().RequireAuthorization();
```

In a controller-based web API project, secure endpoints by applying the [[`Authorize`]](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) attribute to a controller or action.

## Test the API

A quick way to test authentication is to use the in-memory database and the Swagger UI that's included with the project template. The following steps show how to test the API with the Swagger UI. Make sure that the [Swagger UI endpoints aren't secured](#secure-endpoints). 

### Attempt to access a secured endpoint

* Run the app and navigate to the Swagger UI.
* Expand a secured endpoint, such as `/weatherforecast` in a project created by the web API template.
* Select  **Try it out**.
* Select **Execute**. The response is `401 - not authorized`.

### Register and log in

* Expand `/register` and select **Try it out**.
* In the **Parameters** section of the UI, a sample request body is shown:

  ```json
  {
    "email": "string",
    "password": "string"
  }
  ```

* Replace "string" with a valid email address and password, and then select **Execute**.

  The password must be at least 6 characters long and contain at least one of each of the following:

  * Uppercase letter
  * Lowercase letter
  * Numeric digit
  * Non-alphanumeric character

  If you enter an invalid email address or a bad password, the result includes the validation errors. Here's an example of a response body with validation errors:

  ```json
  {
    "type": "https://tools.ietf.org/html/rfc9110#section-15.5.1",
    "title": "One or more validation errors occurred.",
    "status": 400,
    "errors": {
      "PasswordTooShort": [
        "Passwords must be at least 6 characters."
      ],
      "PasswordRequiresNonAlphanumeric": [
        "Passwords must have at least one non alphanumeric character."
      ],
      "PasswordRequiresDigit": [
        "Passwords must have at least one digit ('0'-'9')."
      ],
      "PasswordRequiresLower": [
        "Passwords must have at least one lowercase ('a'-'z')."
      ]
    }
  }
  ```

  The errors are returned in the [ProblemDetails](/aspnet/core/web-api/handle-errors#validation-failure-error-response) format so the client can easily parse them and display validation errors as needed.

  A successful registration results in a `200 - OK` response.

* Expand `/login` and select **Try it out**. The example request body shows two additional parameters:

  ```json
  {
    "email": "string",
    "password": "string",
    "twoFactorCode": "string",
    "twoFactorRecoveryCode": "string"
  }
  ```

  The extra JSON properties aren't needed for this example and can be deleted. Set `useCookies` to `true`. 

* Replace "string" with the email address and password that you used to register, and then select **Execute**.

  A successful login results in a `200 - OK` response with a cookie in the response header.

  The cookie is automatically sent with the request and the endpoint is authorized.

### Retest the secured endpoint

After a successful login, rerun the secured endpoint. The authentication cookie is automatically sent with the request, and the endpoint is authorized. Cookie-based authentication is securely built-in to the browser and "just works." 

### Testing with non-browser clients

Some web clients might not include cookies in the header by default:

* If you're using a tool for testing APIs, you might need to enable cookies in the settings.
* The JavaScript `fetch` API doesn't include cookies by default. Enable them by setting `credentials` to the value `include` in the options.
* An `HttpClient` running in a Blazor WebAssembly app needs the `HttpRequestMessage` to include credentials, like the following:

```csharp
request.SetBrowserRequestCredential(BrowserRequestCredentials.Include);
```

## Tokens

For clients that don't support cookies, the login API provides a parameter to request tokens. A custom token (one that is proprietary to the ASP.NET Core identity platform) is issued that can be used to authenticate subsequent requests. The token is passed in the `Authorization` header as a bearer token. A refresh token is also provided. This token allows the application to request a new token when the old one expires without forcing the user to log in again.

The tokens are not standard JSON Web Tokens (JWTs). The use of custom tokens is intentional, as the built-in Identity API is meant primarily for simple scenarios. The token option is not intended to be a fully-featured identity service provider or token server, but instead an alternative to the cookie option for clients that can't use cookies.

To use token-based authentication with the login API, set the `useCookies` query string parameter to `false`.

## See also

For more information, see the following resources:

* [Choose the right ASP.NET Core identity solution](/aspnet/core/security/how-to-choose-identity-solution)
* [List of identity management solutions for ASP.NET Core](/aspnet/core/security/identity-management-solutions)
* [Sample Web API backend for SPAs](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/samples/SimpleAuthCookiesAndTokens/SimpleAuthCookiesAndTokens)
  The .http file shows token-based authentication. For example:
  * Doesn't set `useCookies`
  * Uses the Authorization header to pass the token
  * Shows refresh to extend session without forcing the user to login again
* [Sample Angular app that uses Identity to secure a Web API backend](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/samples/ngIdentity)

:::moniker-end

[!INCLUDE[](~/security/authentication/identity-api-authorization/includes/identity-api-authorization3-7.md)]
