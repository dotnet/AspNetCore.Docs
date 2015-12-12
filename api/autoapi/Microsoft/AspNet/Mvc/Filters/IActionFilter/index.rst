

IActionFilter Interface
=======================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IActionFilter : IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/Filters/IActionFilter.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IActionFilter

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IActionFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.IActionFilter.OnActionExecuted(Microsoft.AspNet.Mvc.Filters.ActionExecutedContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ActionExecutedContext
    
        
        .. code-block:: csharp
    
           void OnActionExecuted(ActionExecutedContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.IActionFilter.OnActionExecuting(Microsoft.AspNet.Mvc.Filters.ActionExecutingContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ActionExecutingContext
    
        
        .. code-block:: csharp
    
           void OnActionExecuting(ActionExecutingContext context)
    

