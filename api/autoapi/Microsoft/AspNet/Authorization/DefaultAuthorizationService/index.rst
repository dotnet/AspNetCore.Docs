

DefaultAuthorizationService Class
=================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authorization.DefaultAuthorizationService`








Syntax
------

.. code-block:: csharp

   public class DefaultAuthorizationService : IAuthorizationService





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authorization/DefaultAuthorizationService.cs>`_





.. dn:class:: Microsoft.AspNet.Authorization.DefaultAuthorizationService

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authorization.DefaultAuthorizationService
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authorization.DefaultAuthorizationService.DefaultAuthorizationService(Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Authorization.AuthorizationOptions>, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Authorization.IAuthorizationHandler>, Microsoft.Extensions.Logging.ILogger<Microsoft.AspNet.Authorization.DefaultAuthorizationService>)
    
        
        
        
        :type options: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Authorization.AuthorizationOptions}
        
        
        :type handlers: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Authorization.IAuthorizationHandler}
        
        
        :type logger: Microsoft.Extensions.Logging.ILogger{Microsoft.AspNet.Authorization.DefaultAuthorizationService}
    
        
        .. code-block:: csharp
    
           public DefaultAuthorizationService(IOptions<AuthorizationOptions> options, IEnumerable<IAuthorizationHandler> handlers, ILogger<DefaultAuthorizationService> logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Authorization.DefaultAuthorizationService
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authorization.DefaultAuthorizationService.AuthorizeAsync(System.Security.Claims.ClaimsPrincipal, System.Object, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Authorization.IAuthorizationRequirement>)
    
        
        
        
        :type user: System.Security.Claims.ClaimsPrincipal
        
        
        :type resource: System.Object
        
        
        :type requirements: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Authorization.IAuthorizationRequirement}
        :rtype: System.Threading.Tasks.Task{System.Boolean}
    
        
        .. code-block:: csharp
    
           public Task<bool> AuthorizeAsync(ClaimsPrincipal user, object resource, IEnumerable<IAuthorizationRequirement> requirements)
    
    .. dn:method:: Microsoft.AspNet.Authorization.DefaultAuthorizationService.AuthorizeAsync(System.Security.Claims.ClaimsPrincipal, System.Object, System.String)
    
        
        
        
        :type user: System.Security.Claims.ClaimsPrincipal
        
        
        :type resource: System.Object
        
        
        :type policyName: System.String
        :rtype: System.Threading.Tasks.Task{System.Boolean}
    
        
        .. code-block:: csharp
    
           public Task<bool> AuthorizeAsync(ClaimsPrincipal user, object resource, string policyName)
    

