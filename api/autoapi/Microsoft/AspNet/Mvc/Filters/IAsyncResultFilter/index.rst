

IAsyncResultFilter Interface
============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IAsyncResultFilter : IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/Filters/IAsyncResultFilter.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IAsyncResultFilter

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IAsyncResultFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.IAsyncResultFilter.OnResultExecutionAsync(Microsoft.AspNet.Mvc.Filters.ResultExecutingContext, Microsoft.AspNet.Mvc.Filters.ResultExecutionDelegate)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ResultExecutingContext
        
        
        :type next: Microsoft.AspNet.Mvc.Filters.ResultExecutionDelegate
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    

