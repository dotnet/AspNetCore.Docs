---
title: Use Identity to secure a Web API backend for SPAs
author: JeremyLikness
description: Learn how to use Identity to secure a Web API backend for single page applications (SPAs).
monikerRange: '>= aspnetcore-3.0'
ms.author: tdykstra
ms.date: 12/15/2023
uid: security/authentication/identity/spa
---
# How to use Identity to secure a Web API backend for SPAs

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-8.0"

[ASP.NET Core Identity](xref:security/authentication/identity) provides APIs that handle authentication, authorization, and identity management. The APIs make it possible to secure endpoints of a Web API backend with cookie-based authentication. There's a token-based option for clients that can't use cookies.

This article shows how to use Identity to secure a Web API backend for SPAs such as Angular, React, and Vue apps. The same backend APIs can be used to secure [Blazor WebAssembly apps](xref:blazor/security/webassembly/standalone-with-identity).

## Prerequisites

The steps shown in this article add authentication and authorization to an ASP.NET Core Web API app that:

* Isn't already configured for authentication.
* Targets `net8.0` or later.
* Includes OpenAPI support.
* Can be either minimal API or controller-based API.

Some of the testing instructions in this article use the [Swagger UI](/aspnet/core/tutorials/web-api-help-pages-using-swagger) that's included with the project template. The Swagger UI isn't required to use Identity with a Web API backend.

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

By default, both cookies and proprietary tokens are activated. Cookies and tokens are issued at login if the `useCookies` query string parameter in the login endpoint is `true`.

## Map Identity routes

After the call to `builder.Build()`, call <xref:Microsoft.AspNetCore.Routing.IdentityApiEndpointRouteBuilderExtensions.MapIdentityApi%60%601(Microsoft.AspNetCore.Routing.IEndpointRouteBuilder)> to map the Identity endpoints:

```csharp
app.MapIdentityApi<IdentityUser>();
```

## Secure selected endpoints

To secure an endpoint, use the <xref:Microsoft.AspNetCore.Builder.AuthorizationEndpointConventionBuilderExtensions.RequireAuthorization%2A> extension method on the `Map{Method}` call that defines the route. For example:

```csharp
app.MapGet("/weatherforecast", (HttpContext httpContext) =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
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

The `RequireAuthorization` method can also be used to:

* Secure Swagger UI endpoints, as shown in the following example:
    
  ```csharp
  app.MapSwagger().RequireAuthorization();
  ```

* Secure with a specific claim or permission, as shown in the following example:

```csharp
RequiresAuthorization("Admin")
```

In a controller-based web API project, secure endpoints by applying the [[`Authorize`]](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) attribute to a controller or action.

## Test the API

A quick way to test authentication is to use the in-memory database and the Swagger UI that's included with the project template. The following steps show how to test the API with the Swagger UI. Make sure that the [Swagger UI endpoints aren't secured](#secure-selected-endpoints). 

### Attempt to access a secured endpoint

* Run the app and navigate to the Swagger UI.
* Expand a secured endpoint, such as `/weatherforecast` in a project created by the web API template.
* Select  **Try it out**.
* Select **Execute**. The response is `401 - not authorized`.

### Test registration

* Expand `/register` and select **Try it out**.
* In the **Parameters** section of the UI, a sample request body is shown:

  ```json
  {
    "email": "string",
    "password": "string"
  }
  ```

* Replace "string" with a valid email address and password, and then select **Execute**.

  To comply with the default password validation rules, the password must be at least six characters long and contain at least one of each of the following characters:

  * Uppercase letter
  * Lowercase letter
  * Numeric digit
  * Nonalphanumeric character

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

  The errors are returned in the [ProblemDetails](/aspnet/core/web-api/handle-errors#validation-failure-error-response) format so the client can parse them and display validation errors as needed.

  A successful registration results in a `200 - OK` response.

### Test login

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

### Retest the secured endpoint

After a successful login, rerun the secured endpoint. The authentication cookie is automatically sent with the request, and the endpoint is authorized. Cookie-based authentication is securely built-in to the browser and "just works."

### Testing with nonbrowser clients

Some web clients might not include cookies in the header by default:

* If you're using a tool for testing APIs, you might need to enable cookies in the settings.
* The JavaScript `fetch` API doesn't include cookies by default. Enable them by setting `credentials` to the value `include` in the options.
* An `HttpClient` running in a Blazor WebAssembly app needs the `HttpRequestMessage` to include credentials, like the following example:

```csharp
request.SetBrowserRequestCredential(BrowserRequestCredentials.Include);
```

## Use token-based authentication

For clients that don't support cookies, the login API provides a parameter to request tokens. A custom token (one that is proprietary to the ASP.NET Core identity platform) is issued that can be used to authenticate subsequent requests. The token is passed in the `Authorization` header as a bearer token. A refresh token is also provided. This token allows the application to request a new token when the old one expires without forcing the user to log in again.

The tokens aren't standard JSON Web Tokens (JWTs). The use of custom tokens is intentional, as the built-in Identity API is meant primarily for simple scenarios. The token option isn't intended to be a full-featured identity service provider or token server, but instead an alternative to the cookie option for clients that can't use cookies.

To use token-based authentication, set the `useCookies` query string parameter to `false` when calling the `/login` endpoint. Tokens use the _bearer_ authentication scheme. Using the token returned from the call to `/login`, subsequent calls to protected endpoints should add the header `Authorization: Bearer <token>` where `<token>` is the access token. For more information, see [Use the `POST /login` endpoint](#use-the-post-login-endpoint) later in this article.

## Log out

To provide a way for the user to log out, define a `/logout` endpoint like the following example:

```csharp
app.MapPost("/logout", async (SignInManager<IdentityUser> signInManager,
    [FromBody]object empty) =>
{
    if (empty != null)
    {
        await signInManager.SignOutAsync();
        return Results.Ok();
    }
    return Results.Unauthorized();
})
.WithOpenApi()
.RequireAuthorization();
```

Provide an empty JSON object (`{}`) in the request body when calling this endpoint. The following code is an example of a call to the logout endpoint:

```typescript
public signOut() {
  return this.http.post('/logout', {}, {
    withCredentials: true,
    observe: 'response',
    responseType: 'text'
```

## The `MapIdentityApi<TUser>` endpoints

The call to `MapIdentityApi<TUser>` adds the following endpoints to the app:

* [Use the `POST /register`](#use-the-post-register-endpoint)
* [Use the `POST /login`](#use-the-post-login-endpoint)
* [Use the `POST /refresh`](#use-the-post-refresh-endpoint)
* [Use the `GET /confirmEmail`](#use-the-get-confirmemail-endpoint)
* [Use the `POST /resendConfirmationEmail`](#use-the-post-resendconfirmationemail-endpoint)
* [Use the `POST /forgotPassword`](#use-the-post-forgotpassword-endpoint)
* [Use the `POST /reset Password`](#use-the-post-resetpassword-endpoint)
* [Use the `POST /manage/2fa`](#use-the-post-manage2fa-endpoint)
* [Use the `GET /manage/info`](#use-the-get-manageinfo-endpoint)
* [Use the `POST /manage/info`](#use-the-post-manageinfo-endpoint)

## Use the `POST /register` endpoint

The request body must have <xref:Microsoft.AspNetCore.Identity.Data.LoginRequest.Email> and <xref:Microsoft.AspNetCore.Identity.Data.LoginRequest.Password> properties:

```json
{
  "email": "string",
  "password": "string",
}
```

For more information, see:

* [Test registration](#test-registration) earlier in this article.
* <xref:Microsoft.AspNetCore.Identity.Data.RegisterRequest>.

## Use the `POST /login` endpoint

In the request body, <xref:Microsoft.AspNetCore.Identity.Data.LoginRequest.Email> and <xref:Microsoft.AspNetCore.Identity.Data.LoginRequest.Password> are required. If two-factor authentication (2FA) is enabled, either <xref:Microsoft.AspNetCore.Identity.Data.LoginRequest.TwoFactorCode> or <xref:Microsoft.AspNetCore.Identity.Data.LoginRequest.TwoFactorRecoveryCode> is required. If 2FA isn't enabled, omit both `twoFactorCode` and `twoFactorRecoveryCode`. For more information, see [Use the `POST /manage/2fa` endpoint](#use-the-post-manage2fa-endpoint) later in this article.

Here's a request body example with 2FA not enabled:

```json
{
  "email": "string",
  "password": "string"
}
```

Here are request body examples with 2FA enabled:

* ```json
  {
    "email": "string",
    "password": "string",
    "twoFactorCode": "string",
  }
  ```

* ```json
  {
    "email": "string",
    "password": "string",
    "twoFactorRecoveryCode": "string"
  }
  ```

The endpoint expects a query string parameter:

* `useCookies` - Set to `true` for cookie-based authentication. Set to `false` or omit for token-based authentication.

For more information about cookie-based authentication, see [Test login](#test-login) earlier in this article.

### Token-based authentication

If `useCookies` is `false` or omitted, token-based authentication is enabled. The response body includes the following properties:

```json
{
  "tokenType": "string",
  "accessToken": "string",
  "expiresIn": 0,
  "refreshToken": "string"
}
```

For more information about these properties, see <xref:Microsoft.AspNetCore.Authentication.BearerToken.AccessTokenResponse>.

Put the access token in a header to make authenticated requests, as shown in the following example

```http
Authorization: Bearer {access token}
```

When the access token is about to expire, call the [/refresh](#use-the-post-refresh-endpoint) endpoint.

## Use the `POST /refresh` endpoint

For use only with token-based authentication. Gets a new access token without forcing the user to log in again. Call this endpoint when the access token is about to expire.

The request body contains only the <xref:Microsoft.AspNetCore.Identity.Data.RefreshRequest.RefreshToken>. Here's a request body example:

```json
{
  "refreshToken": "string"
}
```

If the call is successful, the response body is a new <xref:Microsoft.AspNetCore.Authentication.BearerToken.AccessTokenResponse>, as shown in the following example:

```json
{
  "tokenType": "string",
  "accessToken": "string",
  "expiresIn": 0,
  "refreshToken": "string"
}
```

## Use the `GET /confirmEmail` endpoint

If Identity is set up for email confirmation, a successful call to the `/register` endpoint sends an email that contains a link to the `/confirmEmail` endpoint. The link contains the following query string parameters:

* `userId`
* `code`
* `changedEmail` - Included only if the user changed the email address during registration. 

By default, the email subject is "Confirm your email" and the email body looks like the following example:

```http
 Please confirm your account by <a href='https://contoso.com/confirmEmail?userId={user ID}&code={generated code}&changedEmail={new email address}'>clicking here</a>.
```

If the <xref:Microsoft.AspNetCore.Identity.SignInOptions.RequireConfirmedEmail> property is set to `true`, the user can't log in until the email address is confirmed by clicking the link in the email. The `/confirmEmail` endpoint:

* Confirms the email address and enables the user to log in.
* Returns the text "Thank you for confirming your email." in the response body.

To set up Identity for email confirmation, add code in `Program.cs` to set `RequireConfirmedEmail` to `true` and add a class that implements `IEmailSender` to the DI container. For example:

```csharp
builder.Services.Configure<IdentityOptions>(options =>
{
    options.SignIn.RequireConfirmedEmail = true;
});

builder.Services.AddTransient<IEmailSender, EmailSender>();
```

In the preceding example, `EmailSender` is a class that implements `IEmailSender`. For more information, including an example of a class that implements `IEmailSender`, see <xref:security/authentication/accconfirm>.

## Use the `POST /resendConfirmationEmail` endpoint

Sends an email only if the address is valid for a registered user.

The request body contains only the <xref:Microsoft.AspNetCore.Identity.Data.ResendConfirmationEmailRequest.Email>. Here's a request body example:

```json
{
  "email": "string"
}
```

For more information, see [Use the `GET /confirmEmail` endpoint](#use-the-get-confirmemail-endpoint) earlier in this article.

## Use the `POST /forgotPassword` endpoint

Generates an email that contains a password reset code. Send that code to [`/resetPassword`](#use-the-post-resetpassword-endpoint) with a new password.

The request body contains only the <xref:Microsoft.AspNetCore.Identity.Data.ForgotPasswordRequest.Email>. Here's an example:

```json
{
  "email": "string"
}
```

For information about how to enable Identity to send emails, see [Use the `GET /confirmEmail` endpoint](#use-the-get-confirmemail-endpoint).

## Use the `POST /resetPassword` endpoint

Call this endpoint after getting a reset code by calling the `/forgotPassword` endpoint.

The request body requires <xref:Microsoft.AspNetCore.Identity.Data.ResetPasswordRequest.Email>, <xref:Microsoft.AspNetCore.Identity.Data.ResetPasswordRequest.ResetCode>, and <xref:Microsoft.AspNetCore.Identity.Data.ResetPasswordRequest.NewPassword>. Here's an example:

```json
{
  "email": "string",
  "resetCode": "string",
  "newPassword": "string"
}
```

## Use the `POST /manage/2fa` endpoint

Configures two-factor authentication (2FA) for the user. When 2FA is enabled, successful login requires a code produced by an authenticator app in addition to the email address and password.

### Enable 2FA

To enable 2FA for the currently authenticated user:

* Call the `/manage/2fa` endpoint, sending an empty JSON object (`{}`) in the request body.

* The response body provides the <xref:Microsoft.AspNetCore.Identity.Data.TwoFactorResponse.SharedKey> along with some other properties that aren't needed at this point. The shared key is used to set up the authenticator app. Response body example:

  ```json
  {
    "sharedKey": "string",
    "recoveryCodesLeft": 0,
    "recoveryCodes": null,
    "isTwoFactorEnabled": false,
    "isMachineRemembered": false
  }
  ```

* Use the shared key to get a Time-based one-time password (TOTP). For more information, see <xref:security/authentication/identity-enable-qrcodes>.

* Call the `/manage/2fa` endpoint, sending the TOTP and `"enable": true` in the request body. For example:

    ```json
    {
      "enable": true,
      "twoFactorCode": "string"
    }
  ```

* The response body confirms that <xref:Microsoft.AspNetCore.Identity.Data.TwoFactorResponse.IsTwoFactorEnabled> is true and provides the <xref:Microsoft.AspNetCore.Identity.Data.TwoFactorResponse.RecoveryCodes>. The recovery codes are used to log in when the authenticator app isn't available. Response body example after successfully enabling 2FA:

  ```json
  {
    "sharedKey": "string",
    "recoveryCodesLeft": 10,
    "recoveryCodes": [
      "string",
      "string",
      "string",
      "string",
      "string",
      "string",
      "string",
      "string",
      "string",
      "string"
    ],
    "isTwoFactorEnabled": true,
    "isMachineRemembered": false
  }
  ```
  
### Log in with 2FA

Call the `/login` endpoint, sending the email address, password, and TOTP in the request body. For example:

```json
{
  "email": "string",
  "password": "string",
  "twoFactorCode": "string"
}
```

If the user doesn't have access to the authenticator app, log in by calling the `/login` endpoint with one of the recovery codes that was provided when 2FA was enabled. The request body looks like the following example:

  ```json
  {
    "email": "string",
    "password": "string",
    "twoFactorRecoveryCode": "string"
  }
  ```

### Reset the recovery codes

To get a new collection of recovery codes, call this endpoint with <xref:Microsoft.AspNetCore.Identity.Data.TwoFactorRequest.ResetRecoveryCodes> set to `true`. Here's a request body example:

```json
{
  "resetRecoveryCodes": true
}
```

### Reset the shared key

To get a new random shared key, call this endpoint with <xref:Microsoft.AspNetCore.Identity.Data.TwoFactorRequest.ResetSharedKey> set to `true`. Here's a request body example:

```json
{
  "resetSharedKey": true
}
```

Resetting the key automatically disables the two-factor login requirement for the authenticated user until it's re-enabled by a later request.

### Forget the machine

To clear the cookie "remember me flag" if present, call this endpoint with <xref:Microsoft.AspNetCore.Identity.Data.TwoFactorRequest.ForgetMachine> set to true. Here's a request body example:

```json
{
  "forgetMachine": true
}
```

This endpoint has no impact on token-based authentication. 

## Use the `GET /manage/info` endpoint

Gets email address and email confirmation status of the logged-in user. Claims were omitted from this endpoint for security reasons. If claims are needed, use the server-side APIs to set up an endpoint for claims. Or instead of sharing all of the users' claims, provide a validation endpoint that accepts a claim and responds whether the user has it.

The request doesn't require any parameters. The response body includes the <xref:Microsoft.AspNetCore.Identity.Data.InfoResponse.Email> and <xref:Microsoft.AspNetCore.Identity.Data.InfoResponse.IsEmailConfirmed> properties, as in the following example:
  
```json
{
  "email": "string",
  "isEmailConfirmed": true
}
```

## Use the `POST /manage/info` endpoint

Updates the email address and password of the logged-in user. Send <xref:Microsoft.AspNetCore.Identity.Data.InfoRequest.NewEmail>, <xref:Microsoft.AspNetCore.Identity.Data.InfoRequest.NewPassword>, and <xref:Microsoft.AspNetCore.Identity.Data.InfoRequest.OldPassword> in the request body, as shown in the following example:

```json
{
  "newEmail": "string",
  "newPassword": "string",
  "oldPassword": "string"
}
```

Here's an example of the response body:

```json
{
  "email": "string",
  "isEmailConfirmed": false
}
```

## See also

For more information, see the following resources:

* <xref:security/how-to-choose-identity>
* <xref:security/identity-management-solutions>
* <xref:security/authorization/simple>
* <xref:security/authentication/add-user-data>
* <xref:security/authorization/secure-data>
* <xref:security/authentication/accconfirm>
* <xref:security/authentication/identity-enable-qrcodes>
* [Sample Web API backend for SPAs](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/samples/SimpleAuthCookiesAndTokens/SimpleAuthCookiesAndTokens)
  The .http file shows token-based authentication. For example:
  * Doesn't set `useCookies`
  * Uses the Authorization header to pass the token
  * Shows refresh to extend session without forcing the user to login again
* [Sample Angular app that uses Identity to secure a Web API backend](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/samples/ngIdentity)

:::moniker-end

[!INCLUDE[](~/security/authentication/identity-api-authorization/includes/identity-api-authorization3-7.md)]
