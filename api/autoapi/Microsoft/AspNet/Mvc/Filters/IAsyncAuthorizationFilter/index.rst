

IAsyncAuthorizationFilter Interface
===================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IAsyncAuthorizationFilter : IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/Filters/IAsyncAuthorizationFilter.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IAsyncAuthorizationFilter

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IAsyncAuthorizationFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.IAsyncAuthorizationFilter.OnAuthorizationAsync(Microsoft.AspNet.Mvc.Filters.AuthorizationContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.AuthorizationContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task OnAuthorizationAsync(AuthorizationContext context)
    

