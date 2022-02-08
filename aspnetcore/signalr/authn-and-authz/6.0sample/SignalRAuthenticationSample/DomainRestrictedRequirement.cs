using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace SignalRAuthenticationSample;

public class DomainRestrictedRequirement :
    AuthorizationHandler<DomainRestrictedRequirement, HubInvocationContext>,
    IAuthorizationRequirement
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        DomainRestrictedRequirement requirement,
        HubInvocationContext resource)
    {
        if (context.User.Identity != null && 
           !string.IsNullOrEmpty(context.User.Identity.Name))
        {
            var name = context.User.Identity.Name;

            if (IsUserAllowedToDoThis(resource.HubMethodName, name) &&
                name.EndsWith("@microsoft.com"))
            {
                context.Succeed(requirement);
            }
        }
        return Task.CompletedTask;
    }

    private bool IsUserAllowedToDoThis(string hubMethodName,
        string currentUsername)
    {
        return !(currentUsername.Equals("asdf42@microsoft.com") &&
            hubMethodName.Equals("banUser", StringComparison.OrdinalIgnoreCase));
    }
}
