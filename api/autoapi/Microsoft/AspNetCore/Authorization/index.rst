

Microsoft.AspNetCore.Authorization Namespace
============================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Authorization/AllowAnonymousAttribute/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authorization/AuthorizationHandlerContext/index
   
   
   
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


    .. rubric:: Interfaces


    interface :dn:iface:`IAllowAnonymous`
        .. object: type=interface name=Microsoft.AspNetCore.Authorization.IAllowAnonymous

        
        Marker interface to enable the :any:`Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute`\.


    interface :dn:iface:`IAuthorizationHandler`
        .. object: type=interface name=Microsoft.AspNetCore.Authorization.IAuthorizationHandler

        
        Classes implementing this interface are able to make a decision if authorization is allowed.


    interface :dn:iface:`IAuthorizationPolicyProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider

        
        A type which can provide a :any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy` for a particular name.


    interface :dn:iface:`IAuthorizationRequirement`
        .. object: type=interface name=Microsoft.AspNetCore.Authorization.IAuthorizationRequirement

        
        Represents an authorization requirement.


    interface :dn:iface:`IAuthorizationService`
        .. object: type=interface name=Microsoft.AspNetCore.Authorization.IAuthorizationService

        
        Checks policy based permissions for a user


    interface :dn:iface:`IAuthorizeData`
        .. object: type=interface name=Microsoft.AspNetCore.Authorization.IAuthorizeData

        
        Defines the set of data required to apply authorization rules to a resource.


    .. rubric:: Classes


    class :dn:cls:`AllowAnonymousAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute

        
        Specifies that the class or method that this attribute is applied to does not require authorization.


    class :dn:cls:`AuthorizationHandlerContext`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext

        
        Contains authorization information used by :any:`Microsoft.AspNetCore.Authorization.IAuthorizationHandler`\.


    class :dn:cls:`AuthorizationHandler\<TRequirement>`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.AuthorizationHandler\<TRequirement>

        
        Base class for authorization handlers that need to be called for a specific requirement type.


    class :dn:cls:`AuthorizationHandler\<TRequirement, TResource>`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.AuthorizationHandler\<TRequirement, TResource>

        
        Base class for authorization handlers that need to be called for specific requirement and
        resource types.


    class :dn:cls:`AuthorizationOptions`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.AuthorizationOptions

        
        Provides programmatic configuration used by :any:`Microsoft.AspNetCore.Authorization.IAuthorizationService` and :any:`Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider`\.


    class :dn:cls:`AuthorizationPolicy`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.AuthorizationPolicy

        
        Represents a collection of authorization requirements and the scheme or 
        schemes they are evaluated against, all of which must succeed
        for authorization to succeed.


    class :dn:cls:`AuthorizationPolicyBuilder`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder

        
        Used for building policies during application startup.


    class :dn:cls:`AuthorizationServiceExtensions`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.AuthorizationServiceExtensions

        
        Extension methods for :any:`Microsoft.AspNetCore.Authorization.IAuthorizationService`\.


    class :dn:cls:`AuthorizeAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.AuthorizeAttribute

        
        Specifies that the class or method that this attribute is applied to requires the specified authorization.


    class :dn:cls:`DefaultAuthorizationPolicyProvider`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.DefaultAuthorizationPolicyProvider

        
        The default implementation of a policy provider,
        which provides a :any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy` for a particular name.


    class :dn:cls:`DefaultAuthorizationService`
        .. object: type=class name=Microsoft.AspNetCore.Authorization.DefaultAuthorizationService

        
        The default implementation of an :any:`Microsoft.AspNetCore.Authorization.IAuthorizationService`\.


