

ResultFilterAttribute Class
===========================






An abstract filter that asynchronously surrounds execution of the action result. Subclasses
must override :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ResultFilterAttribute.OnResultExecuting(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext)`\, :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ResultFilterAttribute.OnResultExecuted(Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext)` or 
:dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ResultFilterAttribute.OnResultExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext,Microsoft.AspNetCore.Mvc.Filters.ResultExecutionDelegate)` but not :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ResultFilterAttribute.OnResultExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext,Microsoft.AspNetCore.Mvc.Filters.ResultExecutionDelegate)` and either of the other two.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Filters.ResultFilterAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class ResultFilterAttribute : Attribute, _Attribute, IResultFilter, IAsyncResultFilter, IOrderedFilter, IFilterMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ResultFilterAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ResultFilterAttribute

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ResultFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.ResultFilterAttribute.OnResultExecuted(Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext
    
        
        .. code-block:: csharp
    
            public virtual void OnResultExecuted(ResultExecutedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.ResultFilterAttribute.OnResultExecuting(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext
    
        
        .. code-block:: csharp
    
            public virtual void OnResultExecuting(ResultExecutingContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.ResultFilterAttribute.OnResultExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext, Microsoft.AspNetCore.Mvc.Filters.ResultExecutionDelegate)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext
    
        
        :type next: Microsoft.AspNetCore.Mvc.Filters.ResultExecutionDelegate
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ResultFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ResultFilterAttribute.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order { get; set; }
    

