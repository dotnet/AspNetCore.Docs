

ResultFilterAttribute Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.ResultFilterAttribute`








Syntax
------

.. code-block:: csharp

   public abstract class ResultFilterAttribute : Attribute, _Attribute, IResultFilter, IAsyncResultFilter, IOrderedFilter, IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Filters/ResultFilterAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Filters.ResultFilterAttribute

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.ResultFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.ResultFilterAttribute.OnResultExecuted(Microsoft.AspNet.Mvc.Filters.ResultExecutedContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ResultExecutedContext
    
        
        .. code-block:: csharp
    
           public virtual void OnResultExecuted(ResultExecutedContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.ResultFilterAttribute.OnResultExecuting(Microsoft.AspNet.Mvc.Filters.ResultExecutingContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ResultExecutingContext
    
        
        .. code-block:: csharp
    
           public virtual void OnResultExecuting(ResultExecutingContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Filters.ResultFilterAttribute.OnResultExecutionAsync(Microsoft.AspNet.Mvc.Filters.ResultExecutingContext, Microsoft.AspNet.Mvc.Filters.ResultExecutionDelegate)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ResultExecutingContext
        
        
        :type next: Microsoft.AspNet.Mvc.Filters.ResultExecutionDelegate
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.ResultFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ResultFilterAttribute.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; set; }
    

