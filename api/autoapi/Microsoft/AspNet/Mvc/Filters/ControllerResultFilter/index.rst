

ControllerResultFilter Class
============================



.. contents:: 
   :local:



Summary
-------

A filter implementation which delegates to the controller for result filter interfaces.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.ControllerResultFilter`








Syntax
------

.. code-block:: csharp

   public class ControllerResultFilter : IAsyncResultFilter, IOrderedFilter, IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Filters/ControllerResultFilter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Filters.ControllerResultFilter

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.ControllerResultFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.ControllerResultFilter.OnResultExecutionAsync(Microsoft.AspNet.Mvc.Filters.ResultExecutingContext, Microsoft.AspNet.Mvc.Filters.ResultExecutionDelegate)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ResultExecutingContext
        
        
        :type next: Microsoft.AspNet.Mvc.Filters.ResultExecutionDelegate
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.ControllerResultFilter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ControllerResultFilter.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; set; }
    

