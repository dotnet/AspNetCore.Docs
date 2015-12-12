

ControllerActionFilter Class
============================



.. contents:: 
   :local:



Summary
-------

A filter implementation which delegates to the controller for action filter interfaces.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.ControllerActionFilter`








Syntax
------

.. code-block:: csharp

   public class ControllerActionFilter : IAsyncActionFilter, IOrderedFilter, IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Filters/ControllerActionFilter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Filters.ControllerActionFilter

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.ControllerActionFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.ControllerActionFilter.OnActionExecutionAsync(Microsoft.AspNet.Mvc.Filters.ActionExecutingContext, Microsoft.AspNet.Mvc.Filters.ActionExecutionDelegate)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ActionExecutingContext
        
        
        :type next: Microsoft.AspNet.Mvc.Filters.ActionExecutionDelegate
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.ControllerActionFilter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ControllerActionFilter.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; set; }
    

