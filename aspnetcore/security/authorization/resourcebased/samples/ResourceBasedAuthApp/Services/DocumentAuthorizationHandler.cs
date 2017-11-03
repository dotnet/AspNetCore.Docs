using Microsoft.AspNetCore.Authorization;
using ResourceBasedAuthApp.Models;
using System.Threading.Tasks;

namespace ResourceBasedAuthApp.Services
{
    public class DocumentAuthorizationHandler : AuthorizationHandler<SameAuthorRequirement, Document>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       SameAuthorRequirement requirement,
                                                       Document resource)
        {
            if (context.User.Identity.Name == resource.Author)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

    public class SameAuthorRequirement : IAuthorizationRequirement { }
}
