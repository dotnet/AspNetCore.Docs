using Microsoft.AspNetCore.Authorization;
using ResourceBasedAuthApp1.Models;
using System.Threading.Tasks;

namespace ResourceBasedAuthApp1.Services
{
    #region snippet_HandlerAndRequirement
    public class DocumentAuthorizationHandler : 
        AuthorizationHandler<SameAuthorRequirement, Document>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       SameAuthorRequirement requirement,
                                                       Document resource)
        {
            if (context.User.Identity?.Name == resource.Author)
            {
                context.Succeed(requirement);
            }

            //TODO: Use the following if targeting a version of
            //.NET Framework older than 4.6:
            //      return Task.FromResult(0);
            return Task.CompletedTask;
        }
    }

    public class SameAuthorRequirement : IAuthorizationRequirement { }
    #endregion
}
