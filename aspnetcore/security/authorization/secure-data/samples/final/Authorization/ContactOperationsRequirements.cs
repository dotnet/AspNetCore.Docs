using ContactManager.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

// Add https://github.com/blowdart/AspNetAuthorization-Samples/blob/master/src/AspNetAuthorization/Authorization/DocumentAuthorizationHandler.cs
// MapClaimsToOperations

namespace ContactManager.Authorization
{
    public static class ContactOperationsRequirements
    {
        public static OperationAuthorizationRequirement Create =  // Add a create handler
            new OperationAuthorizationRequirement { Name = "Create" };
        public static OperationAuthorizationRequirement Read =
            new OperationAuthorizationRequirement { Name = "Read" };  // Add a read handler
        public static OperationAuthorizationRequirement Update =
            new OperationAuthorizationRequirement { Name = "Update" }; // Add a delete handler
        public static OperationAuthorizationRequirement Delete =
            new OperationAuthorizationRequirement { Name = Constants.canDelete };
        public static OperationAuthorizationRequirement ContainsOne =
          new OperationAuthorizationRequirement { Name = Constants.ContainsOne };
    }

    public class Constants
    {
        public static readonly string canDelete = "canDelete";
        public static readonly string ContainsOne = "ContainsOne";
    }
}

// operations are not permission, permissions are what grant operations