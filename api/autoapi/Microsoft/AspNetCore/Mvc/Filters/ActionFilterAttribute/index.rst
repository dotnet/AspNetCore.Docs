

ActionFilterAttribute Class
===========================






An abstract filter that asynchronously surrounds execution of the action and the action result. Subclasses
should override :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute.OnActionExecuting(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext)`\, :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute.OnActionExecuted(Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext)` or
:dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute.OnActionExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext,Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate)` but not :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute.OnActionExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext,Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate)` and either of the other two.
Similarly subclasses should override :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute.OnResultExecuting(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext)`\, :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute.OnResultExecuted(Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext)` or
:dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute.OnResultExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext,Microsoft.AspNetCore.Mvc.Filters.ResultExecutionDelegate)` but not :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute.OnResultExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext,Microsoft.AspNetCore.Mvc.Filters.ResultExecutionDelegate)` and either of the other two.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Filters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class ActionFilterAttribute : Attribute, _Attribute, IActionFilter, IAsyncActionFilter, IResultFilter, IAsyncResultFilter, IOrderedFilter, IFilterMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order
            {
                get;
                set;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute.OnActionExecuted(Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext
    
        
        .. code-block:: csharp
    
            public virtual void OnActionExecuted(ActionExecutedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute.OnActionExecuting(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext
    
        
        .. code-block:: csharp
    
            public virtual void OnActionExecuting(ActionExecutingContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute.OnActionExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext, Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext
    
        
        :type next: Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute.OnResultExecuted(Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext
    
        
        .. code-block:: csharp
    
            public virtual void OnResultExecuted(ResultExecutedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute.OnResultExecuting(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext
    
        
        .. code-block:: csharp
    
            public virtual void OnResultExecuting(ResultExecutingContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute.OnResultExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext, Microsoft.AspNetCore.Mvc.Filters.ResultExecutionDelegate)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext
    
        
        :type next: Microsoft.AspNetCore.Mvc.Filters.ResultExecutionDelegate
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    

