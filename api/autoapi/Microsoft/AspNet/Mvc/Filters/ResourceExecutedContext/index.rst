

ResourceExecutedContext Class
=============================



.. contents:: 
   :local:



Summary
-------

A context for resource filters.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionContext`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.FilterContext`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext`








Syntax
------

.. code-block:: csharp

   public class ResourceExecutedContext : FilterContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/Filters/ResourceExecutedContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext.ResourceExecutedContext(Microsoft.AspNet.Mvc.ActionContext, System.Collections.Generic.IList<Microsoft.AspNet.Mvc.Filters.IFilterMetadata>)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext`\.
    
        
        
        
        :param actionContext: The .
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :param filters: The list of  instances.
        
        :type filters: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Filters.IFilterMetadata}
    
        
        .. code-block:: csharp
    
           public ResourceExecutedContext(ActionContext actionContext, IList<IFilterMetadata> filters)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext.Canceled
    
        
    
        Gets or sets a value which indicates whether or not execution was canceled by a resource filter.
        If true, then a resource filter short-circuted execution by setting 
        :dn:prop:`Microsoft.AspNet.Mvc.Filters.ResourceExecutingContext.Result`\.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool Canceled { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext.Exception
    
        
    
        Gets or set the current :dn:prop:`Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext.Exception`\.
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
           public virtual Exception Exception { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext.ExceptionDispatchInfo
    
        
    
        Gets or set the current :dn:prop:`Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext.Exception`\.
    
        
        :rtype: System.Runtime.ExceptionServices.ExceptionDispatchInfo
    
        
        .. code-block:: csharp
    
           public virtual ExceptionDispatchInfo ExceptionDispatchInfo { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext.ExceptionHandled
    
        
    
        Gets or sets a value indicating whether or not the current :dn:prop:`Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext.Exception` has been handled.
        
        
        If <c>false</c> the :dn:prop:`Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext.Exception` will be rethrown by the runtime after resource filters
        have executed.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool ExceptionHandled { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.ResourceExecutedContext.Result
    
        
    
        Gets or sets the result.
    
        
        :rtype: Microsoft.AspNet.Mvc.IActionResult
    
        
        .. code-block:: csharp
    
           public virtual IActionResult Result { get; set; }
    

