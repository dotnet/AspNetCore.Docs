---
title: Customizing the behavior of AuthorizationMiddleware
author: pranavkm
description: This article explains how to customize the result handling of AuthorizationMiddleware.
monikerRange: '>= aspnetcore-5.0'
uid: security/authorization/authorizationmiddlewareresulthandler
---
# Customizing the behavior of AuthorizationMiddleware

Applications can register a <xref:Microsoft.AspNetCore.Authorization.IAuthorizationMiddlewareResultHandler /> to customize the way the middleware handles the authorization results. Applications can use this to return customized responses 
or enhance the default challenge or forbid responses. Here is an example of an authorization handler that returns a custom response for certain kinds of authorization failures:

```csharp
 public class MyAuthorizationMiddlewareResultHandler : AuthorizationMiddlewareResultHandler
{
    public async Task HandleAsync(
        RequestDelegate requestDelegate,
        HttpContext httpContext,
        AuthorizationPolicy authorizationPolicy,
        PolicyAuthorizationResult policyAuthorizationResult)
    {
        // if the authorization was forbidden and the resource had specific requirements, let's provide a custom response.
        if (Show404ForForbiddenResult(policyAuthorizationResult))
        {
            // We'll return a 404 to make it appear as if the resource does not exist.
            httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            return;
        }
        
        // Fallback to the default implementation.
        await base.HandleAsync(requestDelegate, httpContext, authorizationPolicy, policyAuthorizationResult);
    }

    bool Show404ForForbiddenResult(PolicyAuthorizationResult policyAuthorizationResult)
    {
        return policyAuthorizationResult.Forbidden && 
            policyAuthorizationResult.AuthorizationFailure.FailedRequirements.OfType<Show404Requirement>().Any();
    }
}

// Startup.cs

public void ConfigureServices(IServiceCollection services)
{
    ...
    services.AddSingleton<IAuthorizationMiddlewareResultHandler, MyAuthorizationMiddlewareResultHandler>();
    ...
}
```
