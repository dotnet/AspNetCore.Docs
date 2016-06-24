

ControllerActionFilter Class
============================






A filter implementation which delegates to the controller for action filter interfaces.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.ControllerActionFilter`








Syntax
------

.. code-block:: csharp

    public class ControllerActionFilter : IAsyncActionFilter, IOrderedFilter, IFilterMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionFilter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionFilter

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionFilter.OnActionExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext, Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext
    
        
        :type next: Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionFilter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionFilter.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order { get; set; }
    

