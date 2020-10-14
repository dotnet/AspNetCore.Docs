using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

public class MyAuthorizationMiddlewareResultHandler : AuthorizationMiddlewareResultHandler
{
    public override async Task HandleAsync(
        RequestDelegate requestDelegate,
        HttpContext httpContext,
        AuthorizationPolicy authorizationPolicy,
        PolicyAuthorizationResult policyAuthorizationResult)
    {
        // if the authorization was forbidden and the resource had specific requirements,
        // provide a custom response.
        if (Show404ForForbiddenResult(policyAuthorizationResult))
        {
            // Return a 404 to make it appear as if the resource does not exist.
            httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            return;
        }

        // Fallback to the default implementation.
        await base.HandleAsync(requestDelegate, httpContext, authorizationPolicy, 
                               policyAuthorizationResult);
    }

    bool Show404ForForbiddenResult(PolicyAuthorizationResult policyAuthorizationResult)
    {
        return policyAuthorizationResult.Forbidden &&
            policyAuthorizationResult.AuthorizationFailure.FailedRequirements.OfType<
                                                           Show404Requirement>().Any();
    }
}

public class Show404Requirement : IAuthorizationRequirement { }
