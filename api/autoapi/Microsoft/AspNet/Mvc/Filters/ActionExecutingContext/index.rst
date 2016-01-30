

ActionExecutingContext Class
============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionContext`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.FilterContext`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.ActionExecutingContext`








Syntax
------

.. code-block:: csharp

   public class ActionExecutingContext : FilterContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/Filters/ActionExecutingContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Filters.ActionExecutingContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.ActionExecutingContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Filters.ActionExecutingContext.ActionExecutingContext(Microsoft.AspNet.Mvc.ActionContext, System.Collections.Generic.IList<Microsoft.AspNet.Mvc.Filters.IFilterMetadata>, System.Collections.Generic.IDictionary<System.String, System.Object>, System.Object)
    
        
        
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type filters: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Filters.IFilterMetadata}
        
        
        :type actionArguments: System.Collections.Generic.IDictionary{System.String,System.Object}
        
        
        :type controller: System.Object
    
        
        .. code-block:: csharp
    
           public ActionExecutingContext(ActionContext actionContext, IList<IFilterMetadata> filters, IDictionary<string, object> actionArguments, object controller)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.ActionExecutingContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ActionExecutingContext.ActionArguments
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public virtual IDictionary<string, object> ActionArguments { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ActionExecutingContext.Controller
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public virtual object Controller { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ActionExecutingContext.Result
    
        
        :rtype: Microsoft.AspNet.Mvc.IActionResult
    
        
        .. code-block:: csharp
    
           public virtual IActionResult Result { get; set; }
    

