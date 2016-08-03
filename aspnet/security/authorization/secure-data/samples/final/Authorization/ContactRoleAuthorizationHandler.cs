using System.Threading.Tasks;
using ContactManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace ContactManager.Authorization
{
    public class ContactRoleAuthorizationHandler
                    : AuthorizationHandler<OperationAuthorizationRequirement, Contact>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                            OperationAuthorizationRequirement requirement, Contact resource)
        {
            if (context.User == null)
            {
                return Task.FromResult(0);
            }

            if (context.User.IsInRole(requirement.Name))
            {
                context.Succeed(requirement);
            }
            return Task.FromResult(0);
        }
    }
}
