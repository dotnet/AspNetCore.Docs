

Microsoft.AspNetCore.Authorization Namespace
============================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Authorization/AllowAnonymousAttribute/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authorization/AuthorizationContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authorization/AuthorizationHandler-TRequirement/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authorization/AuthorizationHandler-TRequirement-TResource/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authorization/AuthorizationOptions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authorization/AuthorizationPolicy/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authorization/AuthorizationPolicyBuilder/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authorization/AuthorizationServiceExtensions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authorization/AuthorizeAttribute/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authorization/DefaultAuthorizationPolicyProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authorization/DefaultAuthorizationService/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authorization/IAllowAnonymous/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authorization/IAuthorizationHandler/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authorization/IAuthorizationPolicyProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authorization/IAuthorizationRequirement/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authorization/IAuthorizationService/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authorization/IAuthorizeData/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Authorization


    .. rubric:: Classes


    class :dn:cls:`AllowAnonymousAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute

        
        Specifies that the class or method that this attribute is applied to does not require authorization.


    class :dn:cls:`AuthorizationContext`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.AuthorizationContext

        
        Contains authorization information used by :any:`Microsoft.AspNetCore.Authorization.IAuthorizationHandler`\.


    class :dn:cls:`AuthorizationHandler\<TRequirement>`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.AuthorizationHandler\<TRequirement>

        


    class :dn:cls:`AuthorizationHandler\<TRequirement, TResource>`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.AuthorizationHandler\<TRequirement, TResource>

        


    class :dn:cls:`AuthorizationOptions`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.AuthorizationOptions

        
        Provides programmatic configuration used by :any:`Microsoft.AspNetCore.Authorization.IAuthorizationService` and :any:`Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider`\.


    class :dn:cls:`AuthorizationPolicy`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.AuthorizationPolicy

        


    class :dn:cls:`AuthorizationPolicyBuilder`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder

        


    class :dn:cls:`AuthorizationServiceExtensions`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.AuthorizationServiceExtensions

        


    class :dn:cls:`AuthorizeAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.AuthorizeAttribute

        
        Specifies that the class or method that this attribute is applied to requires the specified authorization.


    class :dn:cls:`DefaultAuthorizationPolicyProvider`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.DefaultAuthorizationPolicyProvider

        
        A type which can provide a :any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy` for a particular name.


    class :dn:cls:`DefaultAuthorizationService`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.DefaultAuthorizationService

        


    .. rubric:: Interfaces


    interface :dn:iface:`IAllowAnonymous`
        .. object: type=interface name=Microsoft.AspNetCore.Authorization.IAllowAnonymous

        


    interface :dn:iface:`IAuthorizationHandler`
        .. object: type=interface name=Microsoft.AspNetCore.Authorization.IAuthorizationHandler

        


    interface :dn:iface:`IAuthorizationPolicyProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider

        
        A type which can provide a :any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy` for a particular name.


    interface :dn:iface:`IAuthorizationRequirement`
        .. object: type=interface name=Microsoft.AspNetCore.Authorization.IAuthorizationRequirement

        


    interface :dn:iface:`IAuthorizationService`
        .. object: type=interface name=Microsoft.AspNetCore.Authorization.IAuthorizationService

        
        Checks policy based permissions for a user


    interface :dn:iface:`IAuthorizeData`
        .. object: type=interface name=Microsoft.AspNetCore.Authorization.IAuthorizeData

        
        Defines the set of data required to apply authorization rules to a resource.


