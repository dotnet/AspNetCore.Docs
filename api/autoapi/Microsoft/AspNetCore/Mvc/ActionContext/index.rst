

ActionContext Class
===================






Context object for execution of action which has been selected as part of an HTTP request.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ActionContext`








Syntax
------

.. code-block:: csharp

    public class ActionContext








.. dn:class:: Microsoft.AspNetCore.Mvc.ActionContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ActionContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ActionContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ActionContext.ActionContext()
    
        
    
        
        Creates an empty :any:`Microsoft.AspNetCore.Mvc.ActionContext`\.
    
        
    
        
        .. code-block:: csharp
    
            public ActionContext()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ActionContext.ActionContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Routing.RouteData, Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ActionContext`\.
    
        
    
        
        :param httpContext: The :any:`Microsoft.AspNetCore.Http.HttpContext` for the current request.
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param routeData: The :any:`Microsoft.AspNetCore.Routing.RouteData` for the current request.
        
        :type routeData: Microsoft.AspNetCore.Routing.RouteData
    
        
        :param actionDescriptor: The :any:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor` for the selected action.
        
        :type actionDescriptor: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
    
        
        .. code-block:: csharp
    
            public ActionContext(HttpContext httpContext, RouteData routeData, ActionDescriptor actionDescriptor)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ActionContext.ActionContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Routing.RouteData, Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ActionContext`\.
    
        
    
        
        :param httpContext: The :any:`Microsoft.AspNetCore.Http.HttpContext` for the current request.
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param routeData: The :any:`Microsoft.AspNetCore.Routing.RouteData` for the current request.
        
        :type routeData: Microsoft.AspNetCore.Routing.RouteData
    
        
        :param actionDescriptor: The :any:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor` for the selected action.
        
        :type actionDescriptor: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
    
        
        :param modelState: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`\.
        
        :type modelState: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
            public ActionContext(HttpContext httpContext, RouteData routeData, ActionDescriptor actionDescriptor, ModelStateDictionary modelState)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ActionContext.ActionContext(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ActionContext`\.
    
        
    
        
        :param actionContext: The :any:`Microsoft.AspNetCore.Mvc.ActionContext` to copy.
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
            public ActionContext(ActionContext actionContext)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ActionContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ActionContext.ActionDescriptor
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor` for the selected action.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
    
        
        .. code-block:: csharp
    
            public ActionDescriptor ActionDescriptor { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ActionContext.HttpContext
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Http.HttpContext` for the current request.
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public HttpContext HttpContext { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ActionContext.ModelState
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
            public ModelStateDictionary ModelState { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ActionContext.RouteData
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Routing.RouteData` for the current request.
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteData
    
        
        .. code-block:: csharp
    
            public RouteData RouteData { get; set; }
    

