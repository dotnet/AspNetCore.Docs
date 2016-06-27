

ActionExecutingContext Class
============================






A context for action filters, specifically :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.IActionFilter.OnActionExecuted(Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext)` and 
:dn:meth:`Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter.OnActionExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext,Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate)` calls.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext`








Syntax
------

.. code-block:: csharp

    public class ActionExecutingContext : FilterContext








.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext.ActionExecutingContext(Microsoft.AspNetCore.Mvc.ActionContext, System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata>, System.Collections.Generic.IDictionary<System.String, System.Object>, System.Object)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext` instance.
    
        
    
        
        :param actionContext: The :any:`Microsoft.AspNetCore.Mvc.ActionContext`\.
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :param filters: All applicable :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata` implementations.
        
        :type filters: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata<Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata>}
    
        
        :param actionArguments: 
            The arguments to pass when invoking the action. Keys are parameter names.
        
        :type actionArguments: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        :param controller: The controller instance containing the action.
        
        :type controller: System.Object
    
        
        .. code-block:: csharp
    
            public ActionExecutingContext(ActionContext actionContext, IList<IFilterMetadata> filters, IDictionary<string, object> actionArguments, object controller)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext.ActionArguments
    
        
    
        
        Gets the arguments to pass when invoking the action. Keys are parameter names.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public virtual IDictionary<string, object> ActionArguments { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext.Controller
    
        
    
        
        Gets the controller instance containing the action.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public virtual object Controller { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext.Result
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.IActionResult` to execute. Setting :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext.Result` to a non-<code>null</code>
        value inside an action filter will short-circuit the action and any remaining action filters.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.IActionResult
    
        
        .. code-block:: csharp
    
            public virtual IActionResult Result { get; set; }
    

