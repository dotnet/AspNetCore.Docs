

IAuthorizationHandler Interface
===============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IAuthorizationHandler





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authorization/IAuthorizationHandler.cs>`_





.. dn:interface:: Microsoft.AspNet.Authorization.IAuthorizationHandler

Methods
-------

.. dn:interface:: Microsoft.AspNet.Authorization.IAuthorizationHandler
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authorization.IAuthorizationHandler.HandleAsync(Microsoft.AspNet.Authorization.AuthorizationContext)
    
        
        
        
        :type context: Microsoft.AspNet.Authorization.AuthorizationContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task HandleAsync(AuthorizationContext context)
    

