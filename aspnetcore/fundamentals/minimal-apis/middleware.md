---
title: Middleware with Minimal API applications
author: BrennanConroy
description: Use middleware in Minimal API applications
ms.author: brecon
ms.date: 10/10/2022
monikerRange: '>= aspnetcore-7.0'
uid: fundamentals/minimal-apis/middleware
---

# Middleware in Minimal API apps

`WebApplication` automatically adds the following middleware depending on certain conditions:
* [`UseDeveloperExceptionPage`](/dotnet/api/microsoft.aspnetcore.diagnostics.developerexceptionpagemiddleware) is added first when the [`HostingEnvironment`](xref:fundamentals/environments) is `"Development"`.
* [`UseRouting`](/dotnet/api/microsoft.aspnetcore.builder.endpointroutingapplicationbuilderextensions.userouting) is added second if user code didn't already call `UseRouting` and if there are endpoints configured, for example `app.MapGet`.
* [`UseEndpoints`](/dotnet/api/microsoft.aspnetcore.builder.endpointroutingapplicationbuilderextensions.useendpoints) is added at the end of the middleware pipeline if any endpoints are configured.
* [`UseAuthentication`](/dotnet/api/microsoft.aspnetcore.builder.authappbuilderextensions.useauthentication) is added immediately after `UseRouting` if [`IAuthenticationSchemeProvider`](/dotnet/api/microsoft.aspnetcore.authentication.iauthenticationschemeprovider) can be detected in the service provider. `IAuthenticationSchemeProvider` is added by default when using [`AddAuthentication`](/dotnet/api/microsoft.extensions.dependencyinjection.authenticationservicecollectionextensions.addauthentication), and services are detected using [`IServiceProviderIsService`](/dotnet/api/microsoft.extensions.dependencyinjection.iserviceproviderisservice).
* [`UseAuthorization`](/dotnet/api/microsoft.aspnetcore.builder.authorizationappbuilderextensions.useauthorization) is added next if [`IAuthorizationHandlerProvider`](/dotnet/api/microsoft.aspnetcore.authorization.iauthorizationhandlerprovider) can be detected in the service provider. `IAuthorizationHandlerProvider` is added by default when using [`AddAuthorization`](/dotnet/api/microsoft.extensions.dependencyinjection.authenticationservicecollectionextensions.addauthentication), and services are detected using `IServiceProviderIsService`.
* User configured middleware and endpoints are added between `UseRouting` and `UseEndpoints`.

The following code is effectively what the automatic middleware being added to the application looks like.
```csharp
if (isDevelopment)
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

if (isAuthenticationConfigured)
{
    app.UseAuthentication();
}

if (isAuthorizationConfigured)
{
    app.UseAuthorization();
}

// user middleware/endpoints
app.CustomMiddleware(...);
app.MapGet("/", () => "hello world");
// end user middleware/endpoints

app.UseEndpoints(e => {});
```

In some cases, the default middleware configuration is not correct for the app and requires modification. For example, `UseCors` should be called before `UseAuthentication` and `UseAuthorization`. The app needs to call `UseAuthentication` and `UseAuthorization` in that case.
```csharp
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
```

If middleware should be run before route matching occurs, `UseRouting` should be called and the middleware should be placed before the call to `UseRouting`. `UseEndpoints` isn't required in this case as it is automatically added as described above.
```csharp
app.Use((context, next) =>
{
    return next(context);
});

app.UseRouting();

// other middleware and endpoints
```

When adding a terminal middleware (middleware that runs if no endpoint handles the request):

* The middleware must be added after `UseEndpoints`.
* The app needs to call `UseRouting` and `UseEndpoints` so that the terminal middleware can be placed at the correct location.
```csharp
app.UseRouting();

app.MapGet("/", () => "hello world");

app.UseEndpoints(e => {});

app.Run(context =>
{
    context.Response.StatusCode = 404;
    return Task.CompletedTask;
});
```

For more information about middleware see [ASP.NET Core Middleware](xref:fundamentals/middleware/index), and the [list of built-in middleware](xref:fundamentals/middleware/index#built-in-middleware) that can be added to applications.
