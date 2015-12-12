

IAsyncResourceFilter Interface
==============================



.. contents:: 
   :local:



Summary
-------

A filter which surrounds execution of model binding, the action (and filters) and the action result
(and filters).











Syntax
------

.. code-block:: csharp

   public interface IAsyncResourceFilter : IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/Filters/IAsyncResourceFilter.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IAsyncResourceFilter

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IAsyncResourceFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.IAsyncResourceFilter.OnResourceExecutionAsync(Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext, Microsoft.AspNet.Mvc.Filters.ResourceExecutionDelegate)
    
        
    
        Executes the resource filter.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext
        
        
        :param next: The . Invoked to execute the next
            resource filter, or the remainder of the pipeline.
        
        :type next: Microsoft.AspNet.Mvc.Filters.ResourceExecutionDelegate
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> which will complete when the remainder of the pipeline completes.
    
        
        .. code-block:: csharp
    
           Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
    

