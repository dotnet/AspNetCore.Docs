

ResultExecutedContext Class
===========================






A context for result filters, specifically :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.IResultFilter.OnResultExecuted(Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext)` calls.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext`








Syntax
------

.. code-block:: csharp

    public class ResultExecutedContext : FilterContext








.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext.Canceled
    
        
    
        
        Gets or sets an indication that a result filter set :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext.Cancel` to
        <code>true</code> and short-circuited the filter pipeline.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool Canceled
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext.Controller
    
        
    
        
        Gets the controller instance containing the action.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public virtual object Controller
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext.Exception
    
        
    
        
        Gets or sets the :any:`System.Exception` caught while executing the result or result filters, if
        any.
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
            public virtual Exception Exception
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext.ExceptionDispatchInfo
    
        
    
        
        Gets or sets the :any:`System.Runtime.ExceptionServices.ExceptionDispatchInfo` for the
        :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext.Exception`\, if an :any:`System.Exception` was caught and this information captured.
    
        
        :rtype: System.Runtime.ExceptionServices.ExceptionDispatchInfo
    
        
        .. code-block:: csharp
    
            public virtual ExceptionDispatchInfo ExceptionDispatchInfo
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext.ExceptionHandled
    
        
    
        
        Gets or sets an indication that the :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext.Exception` has been handled.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool ExceptionHandled
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext.Result
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.IActionResult` copied from :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext.Result`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.IActionResult
    
        
        .. code-block:: csharp
    
            public virtual IActionResult Result
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext.ResultExecutedContext(Microsoft.AspNetCore.Mvc.ActionContext, System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata>, Microsoft.AspNetCore.Mvc.IActionResult, System.Object)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext` instance.
    
        
    
        
        :param actionContext: The :any:`Microsoft.AspNetCore.Mvc.ActionContext`\.
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :param filters: All applicable :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata` implementations.
        
        :type filters: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata<Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata>}
    
        
        :param result: 
            The :any:`Microsoft.AspNetCore.Mvc.IActionResult` copied from :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext.Result`\.
        
        :type result: Microsoft.AspNetCore.Mvc.IActionResult
    
        
        :param controller: The controller instance containing the action.
        
        :type controller: System.Object
    
        
        .. code-block:: csharp
    
            public ResultExecutedContext(ActionContext actionContext, IList<IFilterMetadata> filters, IActionResult result, object controller)
    

