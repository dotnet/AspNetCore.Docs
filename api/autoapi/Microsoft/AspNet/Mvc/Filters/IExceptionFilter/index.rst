

IExceptionFilter Interface
==========================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IExceptionFilter : IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/Filters/IExceptionFilter.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IExceptionFilter

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IExceptionFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.IExceptionFilter.OnException(Microsoft.AspNet.Mvc.Filters.ExceptionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ExceptionContext
    
        
        .. code-block:: csharp
    
           void OnException(ExceptionContext context)
    

