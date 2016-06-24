

ExceptionFilterAttribute Class
==============================






An abstract filter that runs asynchronously after an action has thrown an :any:`System.Exception`\. Subclasses
must override :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute.OnException(Microsoft.AspNetCore.Mvc.Filters.ExceptionContext)` or :dn:meth:`Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute.OnExceptionAsync(Microsoft.AspNetCore.Mvc.Filters.ExceptionContext)` but not both.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Filters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class ExceptionFilterAttribute : Attribute, _Attribute, IAsyncExceptionFilter, IExceptionFilter, IOrderedFilter, IFilterMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute.OnException(Microsoft.AspNetCore.Mvc.Filters.ExceptionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ExceptionContext
    
        
        .. code-block:: csharp
    
            public virtual void OnException(ExceptionContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute.OnExceptionAsync(Microsoft.AspNetCore.Mvc.Filters.ExceptionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ExceptionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task OnExceptionAsync(ExceptionContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order { get; set; }
    

