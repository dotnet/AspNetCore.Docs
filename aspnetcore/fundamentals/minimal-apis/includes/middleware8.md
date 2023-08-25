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

## Antiforgery middleware

Call <xref:Microsoft.Extensions.DependencyInjection.AntiforgeryServiceCollectionExtensions.AddAntiforgery(IServiceCollection)> to add middleware for validating antiforgery tokens. Antiforgery tokens are used to mitigate [cross-site request forgery attacks](xref:security/anti-request-forgery).

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/MyAntiForgery/Program.cs" id="snippet_short" highlight="3":::

The antiforgery middleware:

* Does ***not*** short-circuit the execution of the rest of the request pipeline.
* Sets the [IAntiforgeryValidationFeature](https://source.dot.net/#Microsoft.AspNetCore.Http.Features/IAntiforgeryValidationFeature.cs,33a7a0e106f11c6f) in the [HttpContext.Features](xref:Microsoft.AspNetCore.Http.HttpContext.Features) of the current request.

The antiforgery token is only validated if:

* The endpoint contains metadata implementing [IAntiforgeryMetadata](https://source.dot.net/#Microsoft.AspNetCore.Http.Abstractions/Metadata/IAntiforgeryMetadata.cs,5f49d4d07fc58320) where `RequiresValidation=true``.
* The HTTP method associated with the endpoint is a relevant [HTTP method](https://developer.mozilla.org/docs/Web/HTTP/Methods). The relevant methods are all [HTTP methods](https://developer.mozilla.org/docs/Web/HTTP/Methods) except for TRACE, OPTIONS, HEAD, and GET.
* The request is associated with a valid endpoint.

***Note:*** The antiforgery middleware must run after the authentication and authorization middleware to prevent reading form data when the user is unauthenticated.

By default, minimal APIs that accept form data require antiforgery token validation.

Consider the following `GenerateForm` method:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/MyAntiForgery/Program.cs" id="snippet_html":::

The preceding code has three arguments, action, the anti-forgery token, and a bool indicating whether the token should be used.

Consider the following sample:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/MyAntiForgery/Program.cs" id="snippet_all" highlight="3":::

In the preceding code, posts to:

* `/todo` require a valid antiforgery token.
* `/todo2` do ***not*** require a valid antiforgery token because `DisableAntiforgery` is called.

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/MyAntiForgery/Program.cs" id="snippet_post":::

A POST to:

* `/todo` from the form generated by the `/` endpoint succeeds because the antiforgery token is valid.
* `/todo` from the form generated by the `/SkipToken` fails because the antiforgery is not included.
* `/todo2` from the form generated by the `/DisableAntiforgery` endpoint succeeds because the antiforgery is not required.

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/MyAntiForgery/Program.cs" id="snippet_post":::

:::moniker-end
