

IAsyncResourceFilter Interface
==============================






A filter that asynchronously surrounds execution of model binding, the action (and filters) and the action
result (and filters).


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

    public interface IAsyncResourceFilter : IFilterMetadata








.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IAsyncResourceFilter
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IAsyncResourceFilter

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IAsyncResourceFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.IAsyncResourceFilter.OnResourceExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext, Microsoft.AspNetCore.Mvc.Filters.ResourceExecutionDelegate)
    
        
    
        
        Called asynchronously before the rest of the pipeline.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext
    
        
        :param next: 
            The :any:`Microsoft.AspNetCore.Mvc.Filters.ResourceExecutionDelegate`\. Invoked to execute the next resource filter or the remainder
            of the pipeline.
        
        :type next: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutionDelegate
        :rtype: System.Threading.Tasks.Task
        :return: 
            A :any:`System.Threading.Tasks.Task` which will complete when the remainder of the pipeline completes.
    
        
        .. code-block:: csharp
    
            Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
    

