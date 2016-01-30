

HttpResponseExceptionActionFilter Class
=======================================



.. contents:: 
   :local:



Summary
-------

An action filter which sets :dn:prop:`Microsoft.AspNet.Mvc.Filters.ActionExecutedContext.Result` to an :any:`Microsoft.AspNet.Mvc.ObjectResult`
if the exception type is :any:`System.Web.Http.HttpResponseException`\.
This filter runs immediately after the action.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.WebApiCompatShim.HttpResponseExceptionActionFilter`








Syntax
------

.. code-block:: csharp

   public class HttpResponseExceptionActionFilter : IActionFilter, IOrderedFilter, IFilterMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.WebApiCompatShim/HttpResponseExceptionActionFilter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.WebApiCompatShim.HttpResponseExceptionActionFilter

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.WebApiCompatShim.HttpResponseExceptionActionFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.WebApiCompatShim.HttpResponseExceptionActionFilter.OnActionExecuted(Microsoft.AspNet.Mvc.Filters.ActionExecutedContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ActionExecutedContext
    
        
        .. code-block:: csharp
    
           public void OnActionExecuted(ActionExecutedContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.WebApiCompatShim.HttpResponseExceptionActionFilter.OnActionExecuting(Microsoft.AspNet.Mvc.Filters.ActionExecutingContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ActionExecutingContext
    
        
        .. code-block:: csharp
    
           public void OnActionExecuting(ActionExecutingContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.WebApiCompatShim.HttpResponseExceptionActionFilter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.WebApiCompatShim.HttpResponseExceptionActionFilter.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; set; }
    

