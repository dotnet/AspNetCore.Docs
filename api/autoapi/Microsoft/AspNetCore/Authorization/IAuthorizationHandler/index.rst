

IAuthorizationHandler Interface
===============================





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

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.IAuthorizationHandler.HandleAsync(Microsoft.AspNetCore.Authorization.AuthorizationContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authorization.AuthorizationContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task HandleAsync(AuthorizationContext context)
    

