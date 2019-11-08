using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using ResourceBasedAuthApp2.Models;
using System.Threading.Tasks;

namespace ResourceBasedAuthApp2.Services
{
    #region snippet_Handler
    public class DocumentAuthorizationCrudHandler :
        AuthorizationHandler<OperationAuthorizationRequirement, Document>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       OperationAuthorizationRequirement requirement,
                                                       Document resource)
        {
            if (context.User.Identity?.Name == resource.Author &&
                requirement.Name == Operations.Read.Name)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
    #endregion

    #region snippet_OperationsClass
    public static class Operations
    {
        public static OperationAuthorizationRequirement Create =
            new OperationAuthorizationRequirement { Name = nameof(Create) };
        public static OperationAuthorizationRequirement Read =
            new OperationAuthorizationRequirement { Name = nameof(Read) };
        public static OperationAuthorizationRequirement Update =
            new OperationAuthorizationRequirement { Name = nameof(Update) };
        public static OperationAuthorizationRequirement Delete =
            new OperationAuthorizationRequirement { Name = nameof(Delete) };
    }
    #endregion
}