

IResultFilter Interface
=======================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IResultFilter : IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/Filters/IResultFilter.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IResultFilter

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IResultFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.IResultFilter.OnResultExecuted(Microsoft.AspNet.Mvc.Filters.ResultExecutedContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ResultExecutedContext
    
        
        .. code-block:: csharp
    
           void OnResultExecuted(ResultExecutedContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.IResultFilter.OnResultExecuting(Microsoft.AspNet.Mvc.Filters.ResultExecutingContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ResultExecutingContext
    
        
        .. code-block:: csharp
    
           void OnResultExecuting(ResultExecutingContext context)
    

