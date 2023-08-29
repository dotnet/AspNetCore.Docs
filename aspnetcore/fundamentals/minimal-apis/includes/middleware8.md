:::moniker range=">= aspnetcore-8.0"

`WebApplication` automatically adds the following middleware depending on certain conditions:
* [`UseDeveloperExceptionPage`](/dotnet/api/microsoft.aspnetcore.diagnostics.developerexceptionpagemiddleware) is added first when the [`HostingEnvironment`](xref:fundamentals/environments) is `"Development"`.
* [`UseRouting`](/dotnet/api/microsoft.aspnetcore.builder.endpointroutingapplicationbuilderextensions.userouting) is added second if user code didn't already call `UseRouting` and if there are endpoints configured, for example `app.MapGet`.
* [`UseEndpoints`](/dotnet/api/microsoft.aspnetcore.builder.endpointroutingapplicationbuilderextensions.useendpoints) is added at the end of the middleware pipeline if any endpoints are configured.
* [`UseAuthentication`](/dotnet/api/microsoft.aspnetcore.builder.authappbuilderextensions.useauthentication) is added immediately after `UseRouting` if user code didn't already call `UseAuthentication` and if [`IAuthenticationSchemeProvider`](/dotnet/api/microsoft.aspnetcore.authentication.iauthenticationschemeprovider) can be detected in the service provider. `IAuthenticationSchemeProvider` is added by default when using [`AddAuthentication`](/dotnet/api/microsoft.extensions.dependencyinjection.authenticationservicecollectionextensions.addauthentication), and services are detected using [`IServiceProviderIsService`](/dotnet/api/microsoft.extensions.dependencyinjection.iserviceproviderisservice).
* [`UseAuthorization`](/dotnet/api/microsoft.aspnetcore.builder.authorizationappbuilderextensions.useauthorization) is added next if user code didn't already call `UseAuthorization` and if [`IAuthorizationHandlerProvider`](/dotnet/api/microsoft.aspnetcore.authorization.iauthorizationhandlerprovider) can be detected in the service provider. `IAuthorizationHandlerProvider` is added by default when using [`AddAuthorization`](/dotnet/api/microsoft.extensions.dependencyinjection.authenticationservicecollectionextensions.addauthentication), and services are detected using `IServiceProviderIsService`.
* User configured middleware and endpoints are added between `UseRouting` and `UseEndpoints`.

The following code is effectively what the automatic middleware being added to the app produces:

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

In some cases, the default middleware configuration isn't correct for the app and requires modification. For example, <xref:Microsoft.AspNetCore.Builder.CorsMiddlewareExtensions.UseCors%2A> should be called before <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A> and <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A>. The app needs to call `UseAuthentication` and `UseAuthorization` if `UseCors` is called:

```csharp
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
```

If middleware should be run before route matching occurs, <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A> should be called and the middleware should be placed before the call to `UseRouting`. <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A> isn't required in this case as it is automatically added as described previously:

```csharp
app.Use((context, next) =>
{
    return next(context);
});

app.UseRouting();

// other middleware and endpoints
```

When adding a terminal middleware:

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

Terminal middleware is middleware that runs if no endpoint handles the request.

For information on antiforgery middleware in Minimal APIs, see <xref:security/anti-request-forgery#afwma>

:::moniker-end
