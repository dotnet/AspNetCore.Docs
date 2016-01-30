

ResultExecutedContext Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionContext`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.FilterContext`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.ResultExecutedContext`








Syntax
------

.. code-block:: csharp

   public class ResultExecutedContext : FilterContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/Filters/ResultExecutedContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Filters.ResultExecutedContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.ResultExecutedContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Filters.ResultExecutedContext.ResultExecutedContext(Microsoft.AspNet.Mvc.ActionContext, System.Collections.Generic.IList<Microsoft.AspNet.Mvc.Filters.IFilterMetadata>, Microsoft.AspNet.Mvc.IActionResult, System.Object)
    
        
        
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type filters: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Filters.IFilterMetadata}
        
        
        :type result: Microsoft.AspNet.Mvc.IActionResult
        
        
        :type controller: System.Object
    
        
        .. code-block:: csharp
    
           public ResultExecutedContext(ActionContext actionContext, IList<IFilterMetadata> filters, IActionResult result, object controller)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.ResultExecutedContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ResultExecutedContext.Canceled
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool Canceled { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ResultExecutedContext.Controller
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public virtual object Controller { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ResultExecutedContext.Exception
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
           public virtual Exception Exception { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ResultExecutedContext.ExceptionDispatchInfo
    
        
        :rtype: System.Runtime.ExceptionServices.ExceptionDispatchInfo
    
        
        .. code-block:: csharp
    
           public virtual ExceptionDispatchInfo ExceptionDispatchInfo { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ResultExecutedContext.ExceptionHandled
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool ExceptionHandled { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ResultExecutedContext.Result
    
        
        :rtype: Microsoft.AspNet.Mvc.IActionResult
    
        
        .. code-block:: csharp
    
           public virtual IActionResult Result { get; }
    

