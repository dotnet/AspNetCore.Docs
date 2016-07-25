

PassThroughAuthorizationHandler Class
=====================================






Infrastructre class which allows an :any:`Microsoft.AspNetCore.Authorization.IAuthorizationRequirement` to
be its own :any:`Microsoft.AspNetCore.Authorization.IAuthorizationHandler`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authorization.Infrastructure`
Assemblies
    * Microsoft.AspNetCore.Authorization

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authorization.Infrastructure.PassThroughAuthorizationHandler`








Syntax
------

.. code-block:: csharp

    public class PassThroughAuthorizationHandler : IAuthorizationHandler








.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.PassThroughAuthorizationHandler
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.PassThroughAuthorizationHandler

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.PassThroughAuthorizationHandler
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.Infrastructure.PassThroughAuthorizationHandler.HandleAsync(Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext)
    
        
    
        
        Makes a decision if authorization is allowed.
    
        
    
        
        :param context: The authorization context.
        
        :type context: Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task HandleAsync(AuthorizationHandlerContext context)
    

