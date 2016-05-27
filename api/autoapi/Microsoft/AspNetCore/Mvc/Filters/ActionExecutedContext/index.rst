

ActionExecutedContext Class
===========================






A context for action filters, specifically :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.IActionFilter.OnActionExecuted(Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext)` calls.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext`








Syntax
------

.. code-block:: csharp

    public class ActionExecutedContext : FilterContext








.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext.Canceled
    
        
    
        
        Gets or sets an indication that an action filter short-circuited the action and the action filter pipeline.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool Canceled
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext.Controller
    
        
    
        
        Gets the controller instance containing the action.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public virtual object Controller
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext.Exception
    
        
    
        
        Gets or sets the :any:`System.Exception` caught while executing the action or action filters, if
        any.
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
            public virtual Exception Exception
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext.ExceptionDispatchInfo
    
        
    
        
        Gets or sets the :any:`System.Runtime.ExceptionServices.ExceptionDispatchInfo` for the
        :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext.Exception`\, if an :any:`System.Exception` was caught and this information captured.
    
        
        :rtype: System.Runtime.ExceptionServices.ExceptionDispatchInfo
    
        
        .. code-block:: csharp
    
            public virtual ExceptionDispatchInfo ExceptionDispatchInfo
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext.ExceptionHandled
    
        
    
        
        Gets or sets an indication that the :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext.Exception` has been handled.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool ExceptionHandled
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext.Result
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.IActionResult`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.IActionResult
    
        
        .. code-block:: csharp
    
            public virtual IActionResult Result
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext.ActionExecutedContext(Microsoft.AspNetCore.Mvc.ActionContext, System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata>, System.Object)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext` instance.
    
        
    
        
        :param actionContext: The :any:`Microsoft.AspNetCore.Mvc.ActionContext`\.
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :param filters: All applicable :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata` implementations.
        
        :type filters: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata<Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata>}
    
        
        :param controller: The controller instance containing the action.
        
        :type controller: System.Object
    
        
        .. code-block:: csharp
    
            public ActionExecutedContext(ActionContext actionContext, IList<IFilterMetadata> filters, object controller)
    

