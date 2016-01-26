

IAsyncExceptionFilter Interface
===============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IAsyncExceptionFilter : IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/Filters/IAsyncExceptionFilter.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IAsyncExceptionFilter

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IAsyncExceptionFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.IAsyncExceptionFilter.OnExceptionAsync(Microsoft.AspNet.Mvc.Filters.ExceptionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ExceptionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task OnExceptionAsync(ExceptionContext context)
    

