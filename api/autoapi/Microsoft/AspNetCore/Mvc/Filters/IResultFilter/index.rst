

IResultFilter Interface
=======================






A filter that surrounds execution of the action result.


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

    public interface IResultFilter : IFilterMetadata








.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IResultFilter
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IResultFilter

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IResultFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.IResultFilter.OnResultExecuted(Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext)
    
        
    
        
        Called after the action result executes.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext
    
        
        .. code-block:: csharp
    
            void OnResultExecuted(ResultExecutedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.IResultFilter.OnResultExecuting(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext)
    
        
    
        
        Called before the action result executes.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext
    
        
        .. code-block:: csharp
    
            void OnResultExecuting(ResultExecutingContext context)
    

