

ResultExecutingContext Class
============================






A context for result filters, specifically :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.IResultFilter.OnResultExecuting(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext)` and
:dn:meth:`Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter.OnResultExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext,Microsoft.AspNetCore.Mvc.Filters.ResultExecutionDelegate)` calls.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext`








Syntax
------

.. code-block:: csharp

    public class ResultExecutingContext : FilterContext








.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext.Cancel
    
        
    
        
        Gets or sets an indication the result filter pipeline should be short-circuited.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool Cancel
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext.Controller
    
        
    
        
        Gets the controller instance containing the action.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public virtual object Controller
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext.Result
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.IActionResult` to execute. Setting :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext.Result` to a non-<code>null</code>
        value inside a result filter will short-circuit the result and any remaining result filters.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.IActionResult
    
        
        .. code-block:: csharp
    
            public virtual IActionResult Result
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext.ResultExecutingContext(Microsoft.AspNetCore.Mvc.ActionContext, System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata>, Microsoft.AspNetCore.Mvc.IActionResult, System.Object)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext` instance.
    
        
    
        
        :param actionContext: The :any:`Microsoft.AspNetCore.Mvc.ActionContext`\.
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :param filters: All applicable :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata` implementations.
        
        :type filters: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata<Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata>}
    
        
        :param result: The :any:`Microsoft.AspNetCore.Mvc.IActionResult` of the action and action filters.
        
        :type result: Microsoft.AspNetCore.Mvc.IActionResult
    
        
        :param controller: The controller instance containing the action.
        
        :type controller: System.Object
    
        
        .. code-block:: csharp
    
            public ResultExecutingContext(ActionContext actionContext, IList<IFilterMetadata> filters, IActionResult result, object controller)
    

