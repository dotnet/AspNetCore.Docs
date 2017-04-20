using ContactManager.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

// Add https://github.com/blowdart/AspNetAuthorization-Samples/blob/master/src/AspNetAuthorization/Authorization/DocumentAuthorizationHandler.cs
// MapClaimsToOperations

namespace ContactManager.Authorization
{
    public static class ContactOperations
    {
        public static OperationAuthorizationRequirement Create =   new OperationAuthorizationRequirement { Name = Constants.CreateOperationName };
        public static OperationAuthorizationRequirement Read = new OperationAuthorizationRequirement { Name = Constants.ReadOperationName };  
        public static OperationAuthorizationRequirement Update = new OperationAuthorizationRequirement { Name = Constants.UpdateOperationName }; 
        public static OperationAuthorizationRequirement Delete = new OperationAuthorizationRequirement { Name = Constants.DeleteOperationName };
        public static OperationAuthorizationRequirement ContainsOne = new OperationAuthorizationRequirement { Name = Constants.ContainsOne };
    }

    public class Constants
    {
        public static readonly string CreateOperationName = "Create";
        public static readonly string ReadOperationName = "Read";
        public static readonly string UpdateOperationName = "Update";
        public static readonly string DeleteOperationName = "Delete";

        public static readonly string OperationRolePrefix = "can";

        public static readonly string ContainsOne = "ContainsOne";
    }
}

// operations are not permission, permissions are what grant operations