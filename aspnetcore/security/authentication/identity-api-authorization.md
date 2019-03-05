---
title: Introduction to authentication for Single Page Applications on ASP.NET Core
author: 
description: Use Identity with a single page application hosted inside an ASP.NET Core app.
ms.author: 
ms.date: 03/05/2018
uid: security/authentication/identity/spa
---

# Authentication and authorization for SPAs

In ASP.NET 3.0 we are introducing support for authentication in single page applications using our new support for API authorization. This support is based on a combination of ASP.NET Core Identity for authenticating and storing users and Identity Server for implementing Open ID Connect.

We have added a new authentication parameter to our Angular and React templates that is similar to the authentication parameter in our mvc and razor pages templates with allowed values 'None' and 'Individual'.

## Create an Angular app with API authorization support

To create a new Angular app with support for authentication and authorization of users, open a command shell and run the following command:

```console
dotnet new angular -o <output_directory_name> -au Individual
```

The preceding command creates an ASP.NET Core app with a *ClientApp* directory containing the Angular app.

## Create a React app with API authorization support

To create a new React app with support for authentication and authorization of users, open a command shell and run the following command:

```console
dotnet new react -o <output_directory_name> -au Individual
```

The preceding command creates an ASP.NET Core app with a *ClientApp* directory containing the React app.

## General description of the ASP.NET Core components of the app

There are several additions to the project when we include support for authentication:

### Startup class

If we look at the code in the Startup class below we can appreciate the following inclusions:
* Inside `public void ConfigureServices(IServiceCollection services)`:
  * Identity with the default UI.
    ```csharp
    services.AddDbContext<ApplicationDbContext>(options =>
      options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

    services.AddDefaultIdentity<ApplicationUser>()
      .AddDefaultUI(UIFramework.Bootstrap4)
      .AddEntityFrameworkStores<ApplicationDbContext>();
    ```
  * Identity Server with an additional AddApiAuthorization helper method that setups some default ASP.NET Conventions on top of Identity Server.
    ```csharp
    services.AddIdentityServer()
      .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();
    ```
  * Authentication with an additional AddIdentityServerJwt helper method that configures the application to validate Jwt tokens produced by Identity Server. 
    ```csharp
    services.AddAuthentication()
      .AddIdentityServerJwt();
    ```
* Inside `public void Configure(IApplicationBuilder app)`:
  * The authentication middleware that is responsible for validating the credentials in the incoming request and setting the user on the request context.
    ```csharp
    app.UseAuthentication();
    ```
  * The identity server middleware that exposes the Open ID Connect endpoints.
    ```csharp
    app.UseIdentityServer();
    ```

### AddApiAuthorization 
This helper method configures Identity Server to use our supported configuration. Identity Server is a very powerful and extensible framework for handling application security concerns but at the same time that exposes a lot of complexity that we don't need to know about for the most common scenarios, so we choose a set of conventions and configuration options for you that we consider are a good starting point. Once your authentication needs change the full power of Identity Server is still available to you so you can customize it to suit your needs.

### AddIdentityServerJwt
This helper method configures a policy scheme for the application as the default authentication handler. The policy is configured to let identity handle all the requests that go to any subpath in the Identity url space "/Identity" and to let the JwtBearerHandler handle all other requests.
Addionally this method registers an `<<ApplicationName>>API` Api resource with identity server with a default scope of `<<ApplicationName>>API` and configures the JWT Bearer token middleware to validate tokens issued by Identity Server for the application.

### SampleDataController
If we look at the file Controllers\SampleDataController.cs we can observe the `[Authorize]` attribute applied to the class that indicates that the user needs to be authorized based on the default policy to access the resource. The default authorization policy happens to be configured to use the default authentication scheme which is set up by `AddIdentityServerJwt` to the policy scheme that we mentioned above, making the JwtBearer handler configured by such helper method the default handler for requests to the app.

### ApplicationDbContext
If we look at the file in Data\ApplicationDbContext.cs we can see the same DbContext we use in identity with the exception that it extends ApiAuthorizationDbContext (a more derived class from IdentityDbContext) to include the schema for Identity Server.
If we want full control of the database schema we can simply inherit from one of the available Identity DbContext classes and configure the context to include the identity schema by calling `builder.ConfigurePersistedGrantContext(_operationalStoreOptions.Value)` on the `OnModelCreating` method.

### OidcConfigurationController
If we look at the file Controllers\OidcConfigurationController.cs we can see the endpoint that we stand-up to serve the OIDC parameters that the client needs to use.

### appsettings.json
If we look at the appsettings.json file on the root of the project, we can see a new `IdentityServer` section that describes the list of configured clients and we can see that there is a single client. The name of the client corresponds to the name of the application and is mapped by convention to the oAuth ClientId parameter. The profile indicates what type of application we are configuring, and we use it internally to drive conventions that simplify the configuration process for the server. There are several profiles available explained in the section below.

```json
"IdentityServer": {
  "Clients": {
    "angularindividualpreview3final": {
      "Profile": "IdentityServerSPA"
    }
  }
}
```

### appsettings.Development.json
If we look at the appsettings.Development.json file on the root of the project, we can see a new `IdentityServer` section that describes the key we are using to sign tokens. When deploying to production a key needs to be provisioned and deployed alongside the application as explained below.

```json
  "IdentityServer": {
    "Key": {
      "Type": "Development"
    }
  }
}
```

## General description of the Angular application
The support for authentication and API authorization in the Angular template lives in its own Angular module. Under ClientApp\src\api-authorization and it is composed of the following elements:
* 3 Components:
  * Login component: Handles the login flow for the app.
  * Logout component: Handles the logout flow for the app.
  * Login menu component: A widget that displays the current authenticated user with links to manage the user profile and log out or links to log in or register when the user is not authenticated.
* A route guard `AuthorizeGuard` that can be added to routes and requires a user to be authenticated before visiting the route.
* An http interceptor `AuthorizeInterceptor` that attaches the access token to outgoing HTTP requests targeting the API when the user is authenticated.
* A service `AuthorizeService` that handles the lower level details of the authentication process and exposes information about the authenticated user to the rest of the application for consumption.
* An angular module that defines routes associated with the authentication parts of the application and exposes the login menu component, the interceptor, the guard and the service for consumption from the rest of the application.

## General description of the React application
The support for authentication and API authorization in the React template lives under ClientApp\src\components\api-authorization\ and it is composed of the following elements:
* 4 Components:
  * Login component: Handles the login flow for the app.
  * Logout component: Handles the logout flow for the app.
  * Login menu component: A widget that displays the current authenticated user with links to manage the user profile and log out or links to log in or register when the user is not authenticated.
  * AuthorizeRoute: A route component that requires a user to be authenticated before rendering the component indicated in the Component parameter.
  * An exported `authService` instance of class `AuthorizeService` that handles the lower level details of the authentication process and exposes information about the authenticated user to the rest of the application for consumption.

Now that we've seen the main components of the solution, we can take a specific look at individual scenarios for the application:

## Requiring authorization on a new API
The system is configured out of the box to make it trivial to require authorization for new APIs. In order to do so, simply create a new controller and add the `[Authorize]` attribute to the controller class or to any action within the controller.

## Protecting a client-side route (Angular)
Protecting a client side route is done by adding the authorize guard to the list of guards to run when configuring a route. As an example you can see how the fetch-data route is configured within the main app angular module:

```ts
RouterModule.forRoot([
  // ...
  { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
])
```

It is important to mention that protecting a route doesn't protect the actual endpoint (which still requires an `[Authorize]` attribute applied to it) but that it only prevents the user from navigating to the given client side route when it is not authenticated.

## Authenticate API requests (Angular)

Authenticating requests to APIs hosted along side the application is done automatically through the use of the HTTP client interceptor defined by the application.

## Protect a client-side route (React)

Protecting a client side route is done by using the AuthorizeRoute component instead of the plain Route component. As an example you can see how the fetch-data route is configured within the App component:

```jsx
<AuthorizeRoute path='/fetch-data' component={FetchData} />
```

It is important to mention that protecting a route doesn't protect the actual endpoint (which still requires an `[Authorize]` attribute applied to it) but that it only prevents the user from navigating to the given client side route when it is not authenticated.

## Authenticate API requests (React)

Authenticating requests with react is done by first importing the `authService` instance from the `AuthorizeService` and then retrieving the access token from the authService and attaching it to the request as shown below. In react components this is typically done in the componentDidMount lifecycle method or as the result from some user interaction.

### Import the authService into your component

```js
import authService from './api-authorization/AuthorizeService'
```

### Retrieve and attach the access token to the response

```js
async populateWeatherData() {
  const token = await authService.getAccessToken();
  const response = await fetch('api/SampleData/WeatherForecasts', {
    headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
  });
  const data = await response.json();
  this.setState({ forecasts: data, loading: false });
}
```

## Deploy into production

In order to deploy the application into production we need to provision several resources:
* A database to store the Identity user accounts and the identity server grants.
* A production certificate to use for signing tokens.
  * There are no specific requirements for this certificate; it can be a self-signed certificate or a certificate provisioned through a CA authority.
  * It can be generated through standard tools like powershell or openssl.
  * It can be installed into the certificate store on the target machines or deployed as a pfx file with a strong password.

### Example: Deploy into Azure Websites

In this section we are going to deploy the application to Azure websites using a certificate stored in the certificate store. We need to modify the application to load a certicate from the certificate store. To do so, our app service plan needs to be at least on the standard tier when we configure in a later step. In our application we simply need to modify the IdentityServer section on appsettings.json to include the key details:
```json
  "IdentityServer": {
    "Key": {
      "Type": "Store",
      "StoreName": "My",
      "StoreLocation": "CurrentUser",
      "Name": "CN=MyApplication"
    }
  }
}
```
* The name property on certificate corresponds with the distinguished subject for the certificate.
* The store location represents where to load the certificate from (CurrentUrser or LocalMachine).
* The store name represents the name of the certificate store where the certificate is stored, in this case it points to the personal user store.

To deploy to Azure Websites, deploy the app following the steps in [Deploy the app to Azure](xref:tutorials/publish-to-azure-webapp-using-vs#deploy-the-app-to-azure) to create the necessary Azure resources and deploy the app to production.

After doing this, the application is deployed into Azure but is not yet completely functional as we still need to setup the certificate to be used by the application. To do so, we need to have the thumbprint for the certificate we are going to use and follow the steps described in [Load your certificates](/azure/app-service/app-service-web-ssl-cert-load#load-your-certificates).

While these steps mention SSL, there is a "Private certificates" section on the portal where we can upload our provisioned certificate to use with our app.

After this step, we should be able to restart our application and it should be completely functional.

## Other configuration options
Our support for API authorization builds on top of Identity Server with a set of conventions, default values and enhancements to simplify the experience for Single Page Applications. Needless to say, the full power of Identity Server is available behind the scenes if the integrations that we offer don't cover your scenario. Our support is focused on what we call "first-party" applications, where all the applications are created and deployed by our organization. As such we don't offer support for things like consent or federation. For those scenarios our recommendation is to use Identity Server and follow their documentation.

### Application profiles
Application profiles are predefined configurations for applications that further define their parameters. At this time we support two profiles:
* IdentityServerSPA: Represents a single page application hosted alongside Identity Server as a single unit.
  * The redirect_uri defaults to `/authentication/login-callback`.
  * The post_logout_redirect_uri defaults to `/authentication/logout-callback`.
  * The set of scopes includes the `openid`, `profile`, and every scope defined for the APIs in the application.
  * The set of allowed OIDC response types is `id_token token` or each of them individually (`id_token`, `token`).
  * The allowed response mode is `fragment`.
* SPA: Represents a single page application that is not hosted with Identity Server.
  * The set of scopes includes the `openid`, `profile`, and every scope defined for the APIs in the application.
  * The set of allowed OIDC response types is `id_token token` or each of them individually (`id_token`, `token`).
  * The allowed response mode is `fragment`.
* IdentityServerJwt: Represents an API that is hosted alongside with Identity Server.
  * The application is configured to have a single scope that defaults to the application name.
* API: Represents an API that is not hosted with Identity Server.
  * The application is configured to have a single scope that defaults to the application name.

### Configuration through AppSettings
We can configure the applications through our configuration system by adding them to the list of Clients or Resources respectively. 

When configuring clients we can configure the `redirect_uri` and the `post_logout_redirect_uri` as shown below:
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

When configuring resources we can configure the scopes for the resource as shown below:
```json
"IdentityServer": {
  "Resources": {
    "MyExternalApi": {
      "Profile": "API",
      "Scopes": "a b c",
    }
  }
}
```

### Configuration through code
We can also configure the clients and resources through code using an overload of AddApiAuthorization that takes an action to configure options.
```csharp
AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
{
    options.Clients.AddSPA(
        "My SPA",
        spa => spa.WithRedirectUri("http://www.example.com/authentication/login-callback")
            .WithLogoutRedirectUri("http://www.example.com/authentication/logout-callback"));

    options.ApiResources.AddApiResource("MyExternalApi", resource => resource.WithScopes("a", "b", "c"));
});
```
