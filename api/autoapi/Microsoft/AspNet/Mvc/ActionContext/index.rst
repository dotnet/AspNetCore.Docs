

ActionContext Class
===================



.. contents:: 
   :local:



Summary
-------

Context object for execution of action which has been selected as part of an HTTP request.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionContext`








Syntax
------

.. code-block:: csharp

   public class ActionContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ActionContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ActionContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ActionContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ActionContext.ActionContext()
    
        
    
        Creates an empty :any:`Microsoft.AspNet.Mvc.ActionContext`\.
    
        
    
        
        .. code-block:: csharp
    
           public ActionContext()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ActionContext.ActionContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Routing.RouteData, Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ActionContext`\.
    
        
        
        
        :param httpContext: The  for the current request.
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        
        
        :param routeData: The  for the current request.
        
        :type routeData: Microsoft.AspNet.Routing.RouteData
        
        
        :param actionDescriptor: The  for the selected action.
        
        :type actionDescriptor: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor
    
        
        .. code-block:: csharp
    
           public ActionContext(HttpContext httpContext, RouteData routeData, ActionDescriptor actionDescriptor)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ActionContext.ActionContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Routing.RouteData, Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor, Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ActionContext`\.
    
        
        
        
        :param httpContext: The  for the current request.
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        
        
        :param routeData: The  for the current request.
        
        :type routeData: Microsoft.AspNet.Routing.RouteData
        
        
        :param actionDescriptor: The  for the selected action.
        
        :type actionDescriptor: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor
        
        
        :param modelState: The .
        
        :type modelState: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
           public ActionContext(HttpContext httpContext, RouteData routeData, ActionDescriptor actionDescriptor, ModelStateDictionary modelState)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ActionContext.ActionContext(Microsoft.AspNet.Mvc.ActionContext)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ActionContext`\.
    
        
        
        
        :param actionContext: The  to copy.
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
           public ActionContext(ActionContext actionContext)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ActionContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ActionContext.ActionDescriptor
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor` for the selected action.
    
        
        :rtype: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor
    
        
        .. code-block:: csharp
    
           public ActionDescriptor ActionDescriptor { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ActionContext.HttpContext
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Http.HttpContext` for the current request.
    
        
        :rtype: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           public HttpContext HttpContext { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ActionContext.ModelState
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
           public ModelStateDictionary ModelState { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ActionContext.RouteData
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Routing.RouteData` for the current request.
    
        
        :rtype: Microsoft.AspNet.Routing.RouteData
    
        
        .. code-block:: csharp
    
           public RouteData RouteData { get; set; }
    

