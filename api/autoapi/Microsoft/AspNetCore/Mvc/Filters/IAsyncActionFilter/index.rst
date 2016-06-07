

IAsyncActionFilter Interface
============================






A filter that asynchronously surrounds execution of the action, after model binding is complete.


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

    public interface IAsyncActionFilter : IFilterMetadata








.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter.OnActionExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext, Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate)
    
        
    
        
        Called asynchronously before the action, after model binding is complete.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext
    
        
        :param next: 
            The :any:`Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate`\. Invoked to execute the next action filter or the action itself.
        
        :type next: Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` that on completion indicates the filter has executed.
    
        
        .. code-block:: csharp
    
            Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    

