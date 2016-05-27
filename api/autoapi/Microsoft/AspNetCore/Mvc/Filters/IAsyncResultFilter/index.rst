

IAsyncResultFilter Interface
============================






A filter that asynchronously surrounds execution of the action result.


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

    public interface IAsyncResultFilter : IFilterMetadata








.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter.OnResultExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext, Microsoft.AspNetCore.Mvc.Filters.ResultExecutionDelegate)
    
        
    
        
        Called asynchronously before the action result.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext
    
        
        :param next: 
            The :any:`Microsoft.AspNetCore.Mvc.Filters.ResultExecutionDelegate`\. Invoked to execute the next result filter or the result itself.
        
        :type next: Microsoft.AspNetCore.Mvc.Filters.ResultExecutionDelegate
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` that on completion indicates the filter has executed.
    
        
        .. code-block:: csharp
    
            Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    

