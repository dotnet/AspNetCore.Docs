

ResultExecutingContext Class
============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionContext`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.FilterContext`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.ResultExecutingContext`








Syntax
------

.. code-block:: csharp

   public class ResultExecutingContext : FilterContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/Filters/ResultExecutingContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Filters.ResultExecutingContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.ResultExecutingContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Filters.ResultExecutingContext.ResultExecutingContext(Microsoft.AspNet.Mvc.ActionContext, System.Collections.Generic.IList<Microsoft.AspNet.Mvc.Filters.IFilterMetadata>, Microsoft.AspNet.Mvc.IActionResult, System.Object)
    
        
        
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type filters: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Filters.IFilterMetadata}
        
        
        :type result: Microsoft.AspNet.Mvc.IActionResult
        
        
        :type controller: System.Object
    
        
        .. code-block:: csharp
    
           public ResultExecutingContext(ActionContext actionContext, IList<IFilterMetadata> filters, IActionResult result, object controller)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.ResultExecutingContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ResultExecutingContext.Cancel
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool Cancel { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ResultExecutingContext.Controller
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public virtual object Controller { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ResultExecutingContext.Result
    
        
        :rtype: Microsoft.AspNet.Mvc.IActionResult
    
        
        .. code-block:: csharp
    
           public virtual IActionResult Result { get; set; }
    

