

IAuthorizationFilter Interface
==============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IAuthorizationFilter : IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/Filters/IAuthorizationFilter.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IAuthorizationFilter

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IAuthorizationFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.IAuthorizationFilter.OnAuthorization(Microsoft.AspNet.Mvc.Filters.AuthorizationContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.AuthorizationContext
    
        
        .. code-block:: csharp
    
           void OnAuthorization(AuthorizationContext context)
    

