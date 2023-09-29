---
title: Introduction to authentication for Single Page Apps on ASP.NET Core
author: javiercn
description: Use Identity with a Single Page App hosted inside an ASP.NET Core app.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 09/12/2023
uid: security/authentication/identity/spa
---
# Authentication and authorization for SPAs

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-8.0"

The ASP.NET Core templates offer authentication in Single Page Apps (SPAs) using the support for API authorization. ASP.NET Core Identity for authenticating and storing users is combined with [Duende Identity Server](https://docs.duendesoftware.com) for implementing OpenID Connect.

> [!IMPORTANT]
> [Duende Software](https://duendesoftware.com/) might require you to pay a license fee for production use of Duende Identity Server. For more information, see <xref:migration/50-to-60#project-templates-use-duende-identity-server>.

An authentication parameter was added to the **Angular** and **React** project templates that is similar to the authentication parameter in the **Web Application (Model-View-Controller)** (MVC) and **Web Application** (Razor Pages) project templates. The allowed parameter values are **None** and **Individual**.

## Create an app with API authorization support

User authentication and authorization can be used with both Angular and React SPAs. Open a command shell, and run the following command:

**Angular**:

```dotnetcli
dotnet new angular -au Individual
```

**React**:

```dotnetcli
dotnet new react -au Individual
```

The preceding command creates an ASP.NET Core app with a *ClientApp* directory containing the SPA.

## General description of the ASP.NET Core components of the app

The following sections describe additions to the project when authentication support is included:

### `Program.cs`

The following code examples rely on the [Microsoft.AspNetCore.ApiAuthorization.IdentityServer](https://www.nuget.org/packages/Microsoft.AspNetCore.ApiAuthorization.IdentityServer) NuGet package. The examples configure API authentication and authorization using the <xref:Microsoft.Extensions.DependencyInjection.IdentityServerBuilderConfigurationExtensions.AddApiAuthorization%2A> and <xref:Microsoft.AspNetCore.ApiAuthorization.IdentityServer.ApiResourceCollection.AddIdentityServerJwt%2A> extension methods. Projects using the React or Angular SPA project templates with authentication include a reference to this package.

`dotnet new angular -au Individual` generates the following `Program.cs` file:

[!code-csharp[](~/security/authentication/identity-api-authorization/6samples/Program.cs)]

The preceding code configures:

* Identity with the default UI:

  ```csharp
  builder.Services.AddDbContext<ApplicationDbContext>(options =>
      options.UseSqlite(connectionString));
  builder.Services.AddDatabaseDeveloperPageExceptionFilter();
  
  builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
      .AddEntityFrameworkStores<ApplicationDbContext>();
  ```

* IdentityServer with an additional `AddApiAuthorization` helper method that sets up some default ASP.NET Core conventions on top of IdentityServer:

  ```csharp
  builder.Services.AddIdentityServer()
      .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();
  ```

* Authentication with an additional `AddIdentityServerJwt` helper method that configures the app to validate JWT tokens produced by IdentityServer:

   ```csharp
   builder.Services.AddAuthentication()
   .AddIdentityServerJwt();
   ```

* The authentication middleware that is responsible for validating the request credentials and setting the user on the request context:

    ```csharp
    app.UseAuthentication();
    ```

* The IdentityServer middleware that exposes the OpenID Connect endpoints:

    ```csharp
    app.UseIdentityServer();
    ```

### Azure App Service on Linux

For Azure App Service deployments on Linux, specify the issuer explicitly:

```csharp
builder.Services.Configure<JwtBearerOptions>(
    IdentityServerJwtConstants.IdentityServerJwtBearerScheme, 
    options =>
    {
        options.Authority = "{AUTHORITY}";
    });
```

In the preceding code, the `{AUTHORITY}` placeholder is the <xref:Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions.Authority> to use when making OpenID Connect calls.

Example:

```csharp
options.Authority = "https://contoso-service.azurewebsites.net";
```

### `AddApiAuthorization`

This helper method configures IdentityServer to use our supported configuration. IdentityServer is a powerful and extensible framework for handling app security concerns. At the same time, that exposes unnecessary complexity for the most common scenarios. Consequently, a set of conventions and configuration options is provided to you that are considered a good starting point. Once your authentication needs change, the full power of IdentityServer is still available to customize authentication to suit your needs.

### `AddIdentityServerJwt`

This helper method configures a policy scheme for the app as the default authentication handler. The policy is configured to let Identity handle all requests routed to any subpath in the Identity URL space "/Identity". The `JwtBearerHandler` handles all other requests. Additionally, this method registers an `<<ApplicationName>>API` API resource with IdentityServer with a default scope of `<<ApplicationName>>API` and configures the JWT Bearer token middleware to validate tokens issued by IdentityServer for the app.

### `WeatherForecastController`

In the  file, notice the `[Authorize]` attribute applied to the class that indicates that the user needs to be authorized based on the default policy to access the resource. The default authorization policy happens to be configured to use the default authentication scheme, which is set up by `AddIdentityServerJwt` to the policy scheme that was mentioned above, making the `JwtBearerHandler` configured by such helper method the default handler for requests to the app.

### `ApplicationDbContext`

In the  file, notice the same `DbContext` is used in Identity with the exception that it extends `ApiAuthorizationDbContext` (a more derived class from `IdentityDbContext`) to include the schema for IdentityServer.

To gain full control of the database schema, inherit from one of the available Identity `DbContext` classes and configure the context to include the Identity schema by calling `builder.ConfigurePersistedGrantContext(_operationalStoreOptions.Value)` on the `OnModelCreating` method.

### `OidcConfigurationController`

In the  file, notice the endpoint that's provisioned to serve the OIDC parameters that the client needs to use.

### `appsettings.json`

In the `appsettings.json` file of the project root, there's a new `IdentityServer` section that describes the list of configured clients. In the following example, there's a single client. The client name corresponds to the app name and is mapped by convention to the OAuth `ClientId` parameter. The profile indicates the app type being configured. It's used internally to drive conventions that simplify the configuration process for the server. There are several profiles available, as explained in the [Application profiles](#application-profiles) section.

```json
"IdentityServer": {
  "Clients": {
    "angularindividualpreview3final": {
      "Profile": "IdentityServerSPA"
    }
  }
}
```

### `appsettings.Development.json`

In the `appsettings.Development.json` file of the project root, there's an `IdentityServer` section that describes the key used to sign tokens. When deploying to production, a key needs to be provisioned and deployed alongside the app, as explained in the [Deploy to production](#deploy-to-production) section.

```json
"IdentityServer": {
  "Key": {
    "Type": "Development"
  }
}
```

## General description of the Angular app

The authentication and API authorization support in the Angular template resides in its own Angular module in the *ClientApp/src/api-authorization* directory. The module is composed of the following elements:

* 3 components:
  * `login.component.ts`: Handles the app's login flow.
  * `logout.component.ts`: Handles the app's logout flow.
  * `login-menu.component.ts`: A widget that displays one of the following sets of links:
    * User profile management and log out links when the user is authenticated.
    * Registration and log in links when the user isn't authenticated.
* A route guard `AuthorizeGuard` that can be added to routes and requires a user to be authenticated before visiting the route.
* An HTTP interceptor `AuthorizeInterceptor` that attaches the access token to outgoing HTTP requests targeting the API when the user is authenticated.
* A service `AuthorizeService` that handles the lower-level details of the authentication process and exposes information about the authenticated user to the rest of the app for consumption.
* An Angular module that defines routes associated with the authentication parts of the app. It exposes the login menu component, the interceptor, the guard, and the service for consumption from the rest of the app.

## General description of the React app

The support for authentication and API authorization in the React template resides in the *ClientApp/src/components/api-authorization* directory. It's composed of the following elements:

* 4 components:
  * `Login.js`: Handles the app's login flow.
  * `Logout.js`: Handles the app's logout flow.
  * `LoginMenu.js`: A widget that displays one of the following sets of links:
    * User profile management and log out links when the user is authenticated.
    * Registration and log in links when the user isn't authenticated.
  * `AuthorizeRoute.js`: A route component that requires a user to be authenticated before rendering the component indicated in the `Component` parameter.
* An exported `authService` instance of class `AuthorizeService` that handles the lower-level details of the authentication process and exposes information about the authenticated user to the rest of the app for consumption.

Now that you've seen the main components of the solution, you can take a deeper look at individual scenarios for the app.

## Require authorization on a new API

By default, the system is configured to easily require authorization for new APIs. To do so, create a new controller and add the `[Authorize]` attribute to the controller class or to any action within the controller.

## Customize the API authentication handler

To customize the configuration of the API's JWT handler, configure its <xref:Microsoft.AspNetCore.Builder.JwtBearerOptions> instance:

```csharp
builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.Configure<JwtBearerOptions>(
    IdentityServerJwtConstants.IdentityServerJwtBearerScheme,
    options =>
    {
        ...
    });
```

The API's JWT handler raises events that enable control over the authentication process using `JwtBearerEvents`. To provide support for API authorization, `AddIdentityServerJwt` registers its own event handlers.

To customize the handling of an event, wrap the existing event handler with additional logic as required. For example:

```csharp
builder.Services.Configure<JwtBearerOptions>(
    IdentityServerJwtConstants.IdentityServerJwtBearerScheme,
    options =>
    {
        var onTokenValidated = options.Events.OnTokenValidated;       
        
        options.Events.OnTokenValidated = async context =>
        {
            await onTokenValidated(context);
            ...
        }
    });
```

In the preceding code, the `OnTokenValidated` event handler is replaced with a custom implementation. This implementation:

1. Calls the original implementation provided by the API authorization support.
1. Run its own custom logic.

## Protect a client-side route (Angular)

Protecting a client-side route is done by adding the authorize guard to the list of guards to run when configuring a route. As an example, you can see how the `fetch-data` route is configured within the main app Angular module:

```typescript
RouterModule.forRoot([
  // ...
  { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
])
```

It's important to mention that protecting a route doesn't protect the actual endpoint (which still requires an `[Authorize]` attribute applied to it) but that it only prevents the user from navigating to the given client-side route when it isn't authenticated.

## Authenticate API requests (Angular)

Authenticating requests to APIs hosted alongside the app is done automatically through the use of the HTTP client interceptor defined by the app.

## Protect a client-side route (React)

Protect a client-side route by using the `AuthorizeRoute` component instead of the plain `Route` component. For example, notice how the `fetch-data` route is configured within the `App` component:

```jsx
<AuthorizeRoute path='/fetch-data' component={FetchData} />
```

Protecting a route:

* Doesn't protect the actual endpoint (which still requires an `[Authorize]` attribute applied to it).
* Only prevents the user from navigating to the given client-side route when it isn't authenticated.

## Authenticate API requests (React)

Authenticating requests with React is done by first importing the `authService` instance from the `AuthorizeService`. The access token is retrieved from the `authService` and is attached to the request as shown below. In React components, this work is typically done in the `componentDidMount` lifecycle method or as the result from some user interaction.

### Import the `authService` into a component

```javascript
import authService from './api-authorization/AuthorizeService'
```

### Retrieve and attach the access token to the response

```javascript
async populateWeatherData() {
  const token = await authService.getAccessToken();
  const response = await fetch('api/SampleData/WeatherForecasts', {
    headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
  });
  const data = await response.json();
  this.setState({ forecasts: data, loading: false });
}
```

## Deploy to production

To deploy the app to production, the following resources need to be provisioned:

* A database to store the Identity user accounts and the IdentityServer grants.
* A production certificate to use for signing tokens.
  * There are no specific requirements for this certificate; it can be a self-signed certificate or a certificate provisioned through a CA authority.
  * It can be generated through standard tools like PowerShell or OpenSSL.
  * It can be installed into the certificate store on the target machines or deployed as a *.pfx* file with a strong password.

### Example: Deploy to a non-Azure web hosting provider

In your web hosting panel, create or load your certificate. Then in the app's `appsettings.json` file, modify the `IdentityServer` section to include the key details. For example:

```json
"IdentityServer": {
  "Key": {
    "Type": "Store",
    "StoreName": "WebHosting",
    "StoreLocation": "CurrentUser",
    "Name": "CN=MyApplication"
  }
}
```

In the preceding example:

* `StoreName` represents the name of the certificate store where the certificate is stored. In this case, it points to the web hosting store.
* `StoreLocation` represents where to load the certificate from (`CurrentUser` in this case).
* `Name` corresponds with the distinguished subject for the certificate.

### Example: Deploy to Azure App Service

This section describes deploying the app to Azure App Service using a certificate stored in the certificate store. To modify the app to load a certificate from the certificate store, a Standard tier service plan or better is required when you configure the app in the Azure portal in a later step.

In the app's `appsettings.json` file, modify the `IdentityServer` section to include the key details:

```json
"IdentityServer": {
  "Key": {
    "Type": "Store",
    "StoreName": "My",
    "StoreLocation": "CurrentUser",
    "Name": "CN=MyApplication"
  }
}
```

* The store name represents the name of the certificate store where the certificate is stored. In this case, it points to the personal user store.
* The store location represents where to load the certificate from (`CurrentUser` or `LocalMachine`).
* The name property on certificate corresponds with the distinguished subject for the certificate.

To deploy to Azure App Service, follow the steps in [Deploy the app to Azure](xref:tutorials/publish-to-azure-webapp-using-vs#deploy-the-app-to-azure), which explains how to create the necessary Azure resources and deploy the app to production.

After following the preceding instructions, the app is deployed to Azure but isn't yet functional. The certificate used by the app must be configured in the Azure portal. Locate the thumbprint for the certificate and follow the steps described in [Load your certificates](/azure/app-service/app-service-web-ssl-cert-load#load-the-certificate-in-code).

While these steps mention SSL, there's a **Private certificates** section in the Azure portal where you can upload the provisioned certificate to use with the app.

After configuring the app and the app's settings in the Azure portal, restart the app in the portal.

## Other configuration options

The support for API authorization builds on top of IdentityServer with a set of conventions, default values, and enhancements to simplify the experience for SPAs. Needless to say, the full power of IdentityServer is available behind the scenes if the ASP.NET Core integrations don't cover your scenario. The ASP.NET Core support is focused on "first-party" apps, where all the apps are created and deployed by our organization. As such, support isn't offered for things like consent or federation. For those scenarios, use IdentityServer and follow their documentation.

### Application profiles

Application profiles are predefined configurations for apps that further define their parameters. At this time, the following profiles are supported:

* `IdentityServerSPA`: Represents a SPA hosted alongside IdentityServer as a single unit.
  * The `redirect_uri` defaults to `/authentication/login-callback`.
  * The `post_logout_redirect_uri` defaults to `/authentication/logout-callback`.
  * The set of scopes includes the `openid`, `profile`, and every scope defined for the APIs in the app.
  * The set of allowed OIDC response types is `id_token token` or each of them individually (`id_token`, `token`).
  * The allowed response mode is `fragment`.
* `SPA`: Represents a SPA that isn't hosted with IdentityServer.
  * The set of scopes includes the `openid`, `profile`, and every scope defined for the APIs in the app.
  * The set of allowed OIDC response types is `id_token token` or each of them individually (`id_token`, `token`).
  * The allowed response mode is `fragment`.
* `IdentityServerJwt`: Represents an API that is hosted alongside with IdentityServer.
  * The app is configured to have a single scope that defaults to the app name.
* `API`: Represents an API that isn't hosted with IdentityServer.
  * The app is configured to have a single scope that defaults to the app name.

### Configuration through `AppSettings`

Configure the apps through the configuration system by adding them to the list of `Clients` or `Resources`.

Configure each client's `redirect_uri` and `post_logout_redirect_uri` property, as shown in the following example:

```json
"IdentityServer": {
  "Clients": {
    "MySPA": {
      "Profile": "SPA",
      "RedirectUri": "https://www.example.com/authentication/login-callback",
      "LogoutUri": "https://www.example.com/authentication/logout-callback"
    }
  }
}
```

When configuring resources, you can configure the scopes for the resource as shown below:

```json
"IdentityServer": {
  "Resources": {
    "MyExternalApi": {
      "Profile": "API",
      "Scopes": "a b c"
    }
  }
}
```

### Configuration through code

You can also configure the clients and resources through code using an overload of `AddApiAuthorization` that takes an action to configure options.

```csharp
AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
{
    options.Clients.AddSPA(
        "My SPA", spa =>
        spa.WithRedirectUri("http://www.example.com/authentication/login-callback")
           .WithLogoutRedirectUri(
               "http://www.example.com/authentication/logout-callback"));

    options.ApiResources.AddApiResource("MyExternalApi", resource =>
        resource.WithScopes("a", "b", "c"));
});
```

## Additional resources

* <xref:spa/angular>
* <xref:spa/react>
* <xref:security/authentication/scaffold-identity>

:::moniker-end

[!INCLUDE[](~/security/authentication/identity-api-authorization/includes/identity-api-authorization3-7.md)]
