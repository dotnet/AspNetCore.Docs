

IActionFilter Interface
=======================






A filter that surrounds execution of the action.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Filters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IActionFilter : IFilterMetadata








.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IActionFilter
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IActionFilter

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IActionFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.IActionFilter.OnActionExecuted(Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext)
    
        
    
        
        Called after the action executes, before the action result.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext
    
        
        .. code-block:: csharp
    
            void OnActionExecuted(ActionExecutedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.IActionFilter.OnActionExecuting(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext)
    
        
    
        
        Called before the action executes, after model binding is complete.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext
    
        
        .. code-block:: csharp
    
            void OnActionExecuting(ActionExecutingContext context)
    

