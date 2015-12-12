

ActionFilterAttribute Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.ActionFilterAttribute`








Syntax
------

.. code-block:: csharp

   public abstract class ActionFilterAttribute : Attribute, _Attribute, IActionFilter, IAsyncActionFilter, IResultFilter, IAsyncResultFilter, IOrderedFilter, IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Filters/ActionFilterAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Filters.ActionFilterAttribute

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.ActionFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.ActionFilterAttribute.OnActionExecuted(Microsoft.AspNet.Mvc.Filters.ActionExecutedContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ActionExecutedContext
    
        
        .. code-block:: csharp
    
           public virtual void OnActionExecuted(ActionExecutedContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.ActionFilterAttribute.OnActionExecuting(Microsoft.AspNet.Mvc.Filters.ActionExecutingContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ActionExecutingContext
    
        
        .. code-block:: csharp
    
           public virtual void OnActionExecuting(ActionExecutingContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.ActionFilterAttribute.OnActionExecutionAsync(Microsoft.AspNet.Mvc.Filters.ActionExecutingContext, Microsoft.AspNet.Mvc.Filters.ActionExecutionDelegate)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ActionExecutingContext
        
        
        :type next: Microsoft.AspNet.Mvc.Filters.ActionExecutionDelegate
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.ActionFilterAttribute.OnResultExecuted(Microsoft.AspNet.Mvc.Filters.ResultExecutedContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ResultExecutedContext
    
        
        .. code-block:: csharp
    
           public virtual void OnResultExecuted(ResultExecutedContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.ActionFilterAttribute.OnResultExecuting(Microsoft.AspNet.Mvc.Filters.ResultExecutingContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ResultExecutingContext
    
        
        .. code-block:: csharp
    
           public virtual void OnResultExecuting(ResultExecutingContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.ActionFilterAttribute.OnResultExecutionAsync(Microsoft.AspNet.Mvc.Filters.ResultExecutingContext, Microsoft.AspNet.Mvc.Filters.ResultExecutionDelegate)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ResultExecutingContext
        
        
        :type next: Microsoft.AspNet.Mvc.Filters.ResultExecutionDelegate
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.ActionFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ActionFilterAttribute.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; set; }
    

