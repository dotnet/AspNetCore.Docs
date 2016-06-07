

IResourceFilter Interface
=========================






A filter that surrounds execution of model binding, the action (and filters) and the action result
(and filters).


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

    public interface IResourceFilter : IFilterMetadata








.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IResourceFilter
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IResourceFilter

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Filters.IResourceFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.IResourceFilter.OnResourceExecuted(Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext)
    
        
    
        
        Executes the resource filter. Called after execution of the remainder of the pipeline.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext
    
        
        .. code-block:: csharp
    
            void OnResourceExecuted(ResourceExecutedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.IResourceFilter.OnResourceExecuting(Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext)
    
        
    
        
        Executes the resource filter. Called before execution of the remainder of the pipeline.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext
    
        
        .. code-block:: csharp
    
            void OnResourceExecuting(ResourceExecutingContext context)
    

