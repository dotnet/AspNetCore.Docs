

ExceptionContext Class
======================






A context for exception filters i.e. :any:`Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter` and 
:any:`Microsoft.AspNetCore.Mvc.Filters.IAsyncExceptionFilter` implementations.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Filters.ExceptionContext`








Syntax
------

.. code-block:: csharp

    public class ExceptionContext : FilterContext








.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ExceptionContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ExceptionContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ExceptionContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Filters.ExceptionContext.ExceptionContext(Microsoft.AspNetCore.Mvc.ActionContext, System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata>)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Mvc.Filters.ExceptionContext` instance.
    
        
    
        
        :param actionContext: The :any:`Microsoft.AspNetCore.Mvc.ActionContext`\.
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :param filters: All applicable :any:`Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata` implementations.
        
        :type filters: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata<Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata>}
    
        
        .. code-block:: csharp
    
            public ExceptionContext(ActionContext actionContext, IList<IFilterMetadata> filters)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ExceptionContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ExceptionContext.Exception
    
        
    
        
        Gets or sets the :any:`System.Exception` caught while executing the action.
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
            public virtual Exception Exception { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ExceptionContext.ExceptionDispatchInfo
    
        
    
        
        Gets or sets the :any:`System.Runtime.ExceptionServices.ExceptionDispatchInfo` for the 
        :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.ExceptionContext.Exception`\, if this information was captured.
    
        
        :rtype: System.Runtime.ExceptionServices.ExceptionDispatchInfo
    
        
        .. code-block:: csharp
    
            public virtual ExceptionDispatchInfo ExceptionDispatchInfo { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ExceptionContext.ExceptionHandled
    
        
    
        
        Gets or sets an indication that the :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.ExceptionContext.Exception` has been handled.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool ExceptionHandled { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ExceptionContext.Result
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.IActionResult`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.IActionResult
    
        
        .. code-block:: csharp
    
            public virtual IActionResult Result { get; set; }
    

