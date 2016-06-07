

HttpResponseExceptionActionFilter Class
=======================================






An action filter that sets :dn:prop:`Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext.Result` to an :any:`Microsoft.AspNetCore.Mvc.ObjectResult`
if the exception type is :any:`System.Web.Http.HttpResponseException`\.
This filter runs immediately after the action.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.WebApiCompatShim`
Assemblies
    * Microsoft.AspNetCore.Mvc.WebApiCompatShim

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.WebApiCompatShim.HttpResponseExceptionActionFilter`








Syntax
------

.. code-block:: csharp

    public class HttpResponseExceptionActionFilter : IActionFilter, IOrderedFilter, IFilterMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.HttpResponseExceptionActionFilter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.HttpResponseExceptionActionFilter

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.HttpResponseExceptionActionFilter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.HttpResponseExceptionActionFilter.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order
            {
                get;
                set;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.HttpResponseExceptionActionFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.HttpResponseExceptionActionFilter.OnActionExecuted(Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext
    
        
        .. code-block:: csharp
    
            public void OnActionExecuted(ActionExecutedContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.HttpResponseExceptionActionFilter.OnActionExecuting(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext
    
        
        .. code-block:: csharp
    
            public void OnActionExecuting(ActionExecutingContext context)
    

