

ResourceExecutedContext Class
=============================






A context for resource filters, specifically :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.IResourceFilter.OnResourceExecuted(Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext)` calls.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Filters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ActionContext`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Filters.FilterContext`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext`








Syntax
------

.. code-block:: csharp

    public class ResourceExecutedContext : FilterContext








.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext.ResourceExecutedContext(Microsoft.AspNetCore.Mvc.ActionContext, System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata>)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext`\.
    
        
    
        
        :param actionContext: The :any:`Microsoft.AspNetCore.Mvc.ActionContext`\.
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :param filters: The list of :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata` instances.
        
        :type filters: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata<Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata>}
    
        
        .. code-block:: csharp
    
            public ResourceExecutedContext(ActionContext actionContext, IList<IFilterMetadata> filters)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext.Canceled
    
        
    
        
        Gets or sets a value which indicates whether or not execution was canceled by a resource filter.
        If true, then a resource filter short-circuted execution by setting 
        :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext.Result`\.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool Canceled { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext.Exception
    
        
    
        
        Gets or set the current :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext.Exception`\.
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
            public virtual Exception Exception { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext.ExceptionDispatchInfo
    
        
    
        
        Gets or set the current :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext.Exception`\.
    
        
        :rtype: System.Runtime.ExceptionServices.ExceptionDispatchInfo
    
        
        .. code-block:: csharp
    
            public virtual ExceptionDispatchInfo ExceptionDispatchInfo { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext.ExceptionHandled
    
        
    
        
        <p>
        Gets or sets a value indicating whether or not the current :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext.Exception` has been handled.
        </p>
        <p>
        If <code>false</code> the :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext.Exception` will be rethrown by the runtime after resource filters
        have executed.
        </p>
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool ExceptionHandled { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext.Result
    
        
    
        
        Gets or sets the result.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.IActionResult
    
        
        .. code-block:: csharp
    
            public virtual IActionResult Result { get; set; }
    

