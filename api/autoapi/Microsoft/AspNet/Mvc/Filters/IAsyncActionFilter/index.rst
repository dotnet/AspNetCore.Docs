

IAsyncActionFilter Interface
============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IAsyncActionFilter : IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/Filters/IAsyncActionFilter.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IAsyncActionFilter

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IAsyncActionFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.IAsyncActionFilter.OnActionExecutionAsync(Microsoft.AspNet.Mvc.Filters.ActionExecutingContext, Microsoft.AspNet.Mvc.Filters.ActionExecutionDelegate)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ActionExecutingContext
        
        
        :type next: Microsoft.AspNet.Mvc.Filters.ActionExecutionDelegate
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    

