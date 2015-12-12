

IResourceFilter Interface
=========================



.. contents:: 
   :local:



Summary
-------

A filter which surrounds execution of model binding, the action (and filters) and the action result
(and filters).











Syntax
------

.. code-block:: csharp

   public interface IResourceFilter : IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/Filters/IResourceFilter.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IResourceFilter

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Filters.IResourceFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.IResourceFilter.OnResourceExecuted(Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext)
    
        
    
        Executes the resource filter. Called after execution of the remainder of the pipeline.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext
    
        
        .. code-block:: csharp
    
           void OnResourceExecuted(ResourceExecutedContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.IResourceFilter.OnResourceExecuting(Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext)
    
        
    
        Executes the resource filter. Called before execution of the remainder of the pipeline.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext
    
        
        .. code-block:: csharp
    
           void OnResourceExecuting(ResourceExecutingContext context)
    

