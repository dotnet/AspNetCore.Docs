# Retrieving the Current User 

In ASP.NET projects, it was common to use [ClaimsPrincipal.Current](https://docs.microsoft.com/dotnet/api/system.security.claims.claimsprincipal.current) to retrieve the current authenticated user's identity and claims. In ASP.NET Core, this property is no longer set so code that was depending on it needs to be updated to get the current authenticated user's identity through different means.

## Context-specific data instead of static data

When using ASP.NET Core, neither `ClaimsPrincipal.Current` nor `Thread.CurrentPrincipal` are set. These both represent static state, which ASP.NET Core generally avoids. Instead, ASP.NET Core's architecture is to retrieve dependencies (like the current user's identity) from context-specific service collections (using its [dependency injection](xref:fundamentals/dependency-injection) model). What's more, `Thread.CurrentPrincipal` is thread static so it may not persist changes in some async scenarios (and `ClaimsPrincipal.Current` just calls `Thread.CurrentPrincipal` by default). 

To understand the sorts of problems thread static members can lead to in asynchronous scenarios, consider this code snippet:

```CSharp
// Create a ClaimsPrincipal and set Thread.CurrentPrincipal
var identity = new ClaimsIdentity();
identity.AddClaim(new Claim(ClaimTypes.Name, "User1"));
Thread.CurrentPrincipal = new ClaimsPrincipal(identity);

// Check the current user
Console.WriteLine($"Current user: {Thread.CurrentPrincipal?.Identity.Name}");

// For the method to complete asynchronously
await Task.Yield();

// Check the current user after 
Console.WriteLine($"Current user: {Thread.CurrentPrincipal?.Identity.Name}");
```

This sample code sets `Thread.CurrentPrincipal` and then checks its value before and after awaiting an async call. The problem is that because `Thread.CurrentPrincipal` is specific to the *thread* it is set on and the method is likely to resume executing on a different thread after the await, we see that `Thread.CurrentPrincipal` is present when it is first checked but is null after the call to `await Task.Yield()`.

Getting the current user's identity from the app's dependency injection service collection is more testable, too, since test identities can be easily injected.

## Retrieving the current user in an ASP.NET Core app

There are several options for retrieving the current authenticated user's `ClaimsPrincipal` in ASP.NET Core in place of `ClaimsPrincipal.Current`.

* **ControllerBase.User**. MVC controllers can access the current authenticated user with their [User](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.user) property.
* **HttpContext.User**. Components with access to the current `HttpContext` (middleware, for example) can get the current user's `ClaimsPrincipal` from [HttpContext.User](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.http.httpcontext.user).
* **Passed in from caller**. Libraries without access to the current `HttpContext` are often called from controllers or middleware components and can have the current user's identity passed as an argument.
* **IHttpContextAccessor**. Sometimes when porting an existing ASP.NET project to ASP.NET Core, the code base may be too large to easily update the project to pass the current user's identity to all the places where it is needed. In such cases, [IHttpContextAccessor](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.http.ihttpcontextaccessor) can be used as a workaround. `IHttpContextAccessor` is able to access the current `HttpContext` (if one exists). So, a short-term solution to getting the current user's identity in code that hasn't yet been updated to work with ASP.NET Core's dependency injection-driven architecture would be:

  * Make `IHttpContextAccessor` available in the dependency injection container by calling [AddHttpContextAccessor](https://github.com/aspnet/Hosting/issues/793) in `Startup.ConfigureServices`.
  * Get an instance of `IHttpContextAccessor` during startup and store it in a static variable so that it will be available to code that was previously retrieving the current user from a static property.
  * Retrieve the current user's `ClaimsPrincipal` using `HttpContextAccessor.HttpContext?.User`. Note that if this is called outside of the context of an HTTP request, the `HttpContext` will be null.

Keep in mind that the final option (using `IHttpContextAccessor`) is contrary to ASP.NET Core principals (preferring injected dependencies to static dependencies) so you should plan to eventually update the code to not depend on the static `IHttpContextAccessor` helper. It can be a useful bridge, though, when migrating large existing ASP.NET applications that were previously using `ClaimsPrincipal.Current`.
