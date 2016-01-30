

UrlHelper Class
===============



.. contents:: 
   :local:



Summary
-------

An implementation of :any:`Microsoft.AspNet.Mvc.IUrlHelper` that contains methods to
build URLs for ASP.NET MVC within an application.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Routing.UrlHelper`








Syntax
------

.. code-block:: csharp

   public class UrlHelper : IUrlHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Routing/UrlHelper.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Routing.UrlHelper

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Routing.UrlHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Routing.UrlHelper.UrlHelper(Microsoft.AspNet.Mvc.Infrastructure.IActionContextAccessor, Microsoft.AspNet.Mvc.Infrastructure.IActionSelector)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.Routing.UrlHelper` class using the specified action context and
        action selector.
    
        
        
        
        :param actionContextAccessor: The  to access the action context
            of the current request.
        
        :type actionContextAccessor: Microsoft.AspNet.Mvc.Infrastructure.IActionContextAccessor
        
        
        :param actionSelector: The  to be used for verifying the correctness of
            supplied parameters for a route.
        
        :type actionSelector: Microsoft.AspNet.Mvc.Infrastructure.IActionSelector
    
        
        .. code-block:: csharp
    
           public UrlHelper(IActionContextAccessor actionContextAccessor, IActionSelector actionSelector)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Routing.UrlHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Routing.UrlHelper.Action(Microsoft.AspNet.Mvc.Routing.UrlActionContext)
    
        
        
        
        :type actionContext: Microsoft.AspNet.Mvc.Routing.UrlActionContext
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string Action(UrlActionContext actionContext)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Routing.UrlHelper.Content(System.String)
    
        
        
        
        :type contentPath: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string Content(string contentPath)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Routing.UrlHelper.GeneratePathFromRoute(System.String, System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
    
        Generates the absolute path of the url for the specified route values by
        using the specified route name.
    
        
        
        
        :param routeName: The name of the route that is used to generate the URL.
        
        :type routeName: System.String
        
        
        :param values: A dictionary that contains the parameters for a route.
        
        :type values: System.Collections.Generic.IDictionary{System.String,System.Object}
        :rtype: System.String
        :return: The absolute path of the URL.
    
        
        .. code-block:: csharp
    
           protected virtual string GeneratePathFromRoute(string routeName, IDictionary<string, object> values)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Routing.UrlHelper.IsLocalUrl(System.String)
    
        
        
        
        :type url: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool IsLocalUrl(string url)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Routing.UrlHelper.Link(System.String, System.Object)
    
        
        
        
        :type routeName: System.String
        
        
        :type values: System.Object
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string Link(string routeName, object values)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Routing.UrlHelper.RouteUrl(Microsoft.AspNet.Mvc.Routing.UrlRouteContext)
    
        
        
        
        :type routeContext: Microsoft.AspNet.Mvc.Routing.UrlRouteContext
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string RouteUrl(UrlRouteContext routeContext)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Routing.UrlHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.UrlHelper.ActionContext
    
        
        :rtype: Microsoft.AspNet.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
           protected ActionContext ActionContext { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.UrlHelper.AmbientValues
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           protected IDictionary<string, object> AmbientValues { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.UrlHelper.HttpContext
    
        
        :rtype: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           protected HttpContext HttpContext { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.UrlHelper.Router
    
        
        :rtype: Microsoft.AspNet.Routing.IRouter
    
        
        .. code-block:: csharp
    
           protected IRouter Router { get; }
    

