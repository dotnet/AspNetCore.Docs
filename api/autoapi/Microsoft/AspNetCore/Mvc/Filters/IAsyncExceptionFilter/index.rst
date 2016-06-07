

IAsyncExceptionFilter Interface
===============================






A filter that runs asynchronously after an action has thrown an :any:`System.Exception`\.


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

    public interface IAsyncExceptionFilter : IFilterMetadata








.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IAsyncExceptionFilter
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IAsyncExceptionFilter

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IAsyncExceptionFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.IAsyncExceptionFilter.OnExceptionAsync(Microsoft.AspNetCore.Mvc.Filters.ExceptionContext)
    
        
    
        
        Called after an action has thrown an :any:`System.Exception`\.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Filters.ExceptionContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ExceptionContext
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` that on completion indicates the filter has executed.
    
        
        .. code-block:: csharp
    
            Task OnExceptionAsync(ExceptionContext context)
    

