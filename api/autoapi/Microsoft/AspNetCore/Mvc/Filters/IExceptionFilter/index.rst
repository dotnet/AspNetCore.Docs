

IExceptionFilter Interface
==========================






A filter that runs after an action has thrown an :any:`System.Exception`\.


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

    public interface IExceptionFilter : IFilterMetadata








.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter.OnException(Microsoft.AspNetCore.Mvc.Filters.ExceptionContext)
    
        
    
        
        Called after an action has thrown an :any:`System.Exception`\.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Filters.ExceptionContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ExceptionContext
    
        
        .. code-block:: csharp
    
            void OnException(ExceptionContext context)
    

