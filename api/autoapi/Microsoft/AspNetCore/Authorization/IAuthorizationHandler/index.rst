

IAuthorizationHandler Interface
===============================






Classes implementing this interface are able to make a decision if authorization is allowed.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authorization`
Assemblies
    * Microsoft.AspNetCore.Authorization

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IAuthorizationHandler








.. dn:interface:: Microsoft.AspNetCore.Authorization.IAuthorizationHandler
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Authorization.IAuthorizationHandler

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Authorization.IAuthorizationHandler
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.IAuthorizationHandler.HandleAsync(Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext)
    
        
    
        
        Makes a decision if authorization is allowed.
    
        
    
        
        :param context: The authorization information.
        
        :type context: Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task HandleAsync(AuthorizationHandlerContext context)
    

