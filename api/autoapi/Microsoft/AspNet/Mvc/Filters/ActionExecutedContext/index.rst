

ActionExecutedContext Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionContext`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.FilterContext`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.ActionExecutedContext`








Syntax
------

.. code-block:: csharp

   public class ActionExecutedContext : FilterContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/Filters/ActionExecutedContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Filters.ActionExecutedContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.ActionExecutedContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Filters.ActionExecutedContext.ActionExecutedContext(Microsoft.AspNet.Mvc.ActionContext, System.Collections.Generic.IList<Microsoft.AspNet.Mvc.Filters.IFilterMetadata>, System.Object)
    
        
        
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type filters: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Filters.IFilterMetadata}
        
        
        :type controller: System.Object
    
        
        .. code-block:: csharp
    
           public ActionExecutedContext(ActionContext actionContext, IList<IFilterMetadata> filters, object controller)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.ActionExecutedContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ActionExecutedContext.Canceled
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool Canceled { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ActionExecutedContext.Controller
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public virtual object Controller { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ActionExecutedContext.Exception
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
           public virtual Exception Exception { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ActionExecutedContext.ExceptionDispatchInfo
    
        
        :rtype: System.Runtime.ExceptionServices.ExceptionDispatchInfo
    
        
        .. code-block:: csharp
    
           public virtual ExceptionDispatchInfo ExceptionDispatchInfo { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ActionExecutedContext.ExceptionHandled
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool ExceptionHandled { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ActionExecutedContext.Result
    
        
        :rtype: Microsoft.AspNet.Mvc.IActionResult
    
        
        .. code-block:: csharp
    
           public virtual IActionResult Result { get; set; }
    

