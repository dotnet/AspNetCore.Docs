

Microsoft.AspNetCore.Authorization.Infrastructure Namespace
===========================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Authorization/Infrastructure/AssertionRequirement/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authorization/Infrastructure/ClaimsAuthorizationRequirement/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authorization/Infrastructure/DenyAnonymousAuthorizationRequirement/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authorization/Infrastructure/NameAuthorizationRequirement/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authorization/Infrastructure/OperationAuthorizationRequirement/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authorization/Infrastructure/PassThroughAuthorizationHandler/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authorization/Infrastructure/RolesAuthorizationRequirement/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Authorization.Infrastructure


    .. rubric:: Classes


    class :dn:cls:`AssertionRequirement`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement

        
        Implements an :any:`Microsoft.AspNetCore.Authorization.IAuthorizationHandler` and :any:`Microsoft.AspNetCore.Authorization.IAuthorizationRequirement`
        that takes a user specified assertion.


    class :dn:cls:`ClaimsAuthorizationRequirement`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement

        
        Implements an :any:`Microsoft.AspNetCore.Authorization.IAuthorizationHandler` and :any:`Microsoft.AspNetCore.Authorization.IAuthorizationRequirement`
        which requires at least one instance of the specified claim type, and, if allowed values are specified, 
        the claim value must be any of the allowed values.


    class :dn:cls:`DenyAnonymousAuthorizationRequirement`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement

        
        Implements an :any:`Microsoft.AspNetCore.Authorization.IAuthorizationHandler` and :any:`Microsoft.AspNetCore.Authorization.IAuthorizationRequirement`
        which requires the current user must be authenticated.


    class :dn:cls:`NameAuthorizationRequirement`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement

        
        Implements an :any:`Microsoft.AspNetCore.Authorization.IAuthorizationHandler` and :any:`Microsoft.AspNetCore.Authorization.IAuthorizationRequirement`
        which requires the current user name must match the specified value.


    class :dn:cls:`OperationAuthorizationRequirement`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.Infrastructure.OperationAuthorizationRequirement

        
        A helper class to provide a useful :any:`Microsoft.AspNetCore.Authorization.IAuthorizationRequirement` which
        contains a name.


    class :dn:cls:`PassThroughAuthorizationHandler`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.Infrastructure.PassThroughAuthorizationHandler

        
        Infrastructre class which allows an :any:`Microsoft.AspNetCore.Authorization.IAuthorizationRequirement` to
        be its own :any:`Microsoft.AspNetCore.Authorization.IAuthorizationHandler`\.


    class :dn:cls:`RolesAuthorizationRequirement`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement

        
        Implements an :any:`Microsoft.AspNetCore.Authorization.IAuthorizationHandler` and :any:`Microsoft.AspNetCore.Authorization.IAuthorizationRequirement`
        which requires at least one role claim whose value must be any of the allowed roles.


