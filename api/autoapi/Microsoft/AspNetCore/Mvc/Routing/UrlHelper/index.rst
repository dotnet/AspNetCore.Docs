

UrlHelper Class
===============






An implementation of :any:`Microsoft.AspNetCore.Mvc.IUrlHelper` that contains methods to
build URLs for ASP.NET MVC within an application.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Routing`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Routing.UrlHelper`








Syntax
------

.. code-block:: csharp

    public class UrlHelper : IUrlHelper








.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.UrlHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.UrlHelper

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.UrlHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Routing.UrlHelper.UrlHelper(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.Routing.UrlHelper` class using the specified action context and
        action selector.
    
        
    
        
        :param actionContext: The :any:`Microsoft.AspNetCore.Mvc.ActionContext` for the current request.
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
            public UrlHelper(ActionContext actionContext)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.UrlHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Routing.UrlHelper.Action(Microsoft.AspNetCore.Mvc.Routing.UrlActionContext)
    
        
    
        
        :type actionContext: Microsoft.AspNetCore.Mvc.Routing.UrlActionContext
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string Action(UrlActionContext actionContext)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Routing.UrlHelper.Content(System.String)
    
        
    
        
        :type contentPath: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string Content(string contentPath)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Routing.UrlHelper.GenerateUrl(System.String, System.String, Microsoft.AspNetCore.Routing.VirtualPathData, System.String)
    
        
    
        
        Generates the URL using the specified components.
    
        
    
        
        :param protocol: The protocol.
        
        :type protocol: System.String
    
        
        :param host: The host.
        
        :type host: System.String
    
        
        :param pathData: The :any:`Microsoft.AspNetCore.Routing.VirtualPathData`\.
        
        :type pathData: Microsoft.AspNetCore.Routing.VirtualPathData
    
        
        :param fragment: The URL fragment.
        
        :type fragment: System.String
        :rtype: System.String
        :return: The generated URL.
    
        
        .. code-block:: csharp
    
            protected virtual string GenerateUrl(string protocol, string host, VirtualPathData pathData, string fragment)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Routing.UrlHelper.GetVirtualPathData(System.String, Microsoft.AspNetCore.Routing.RouteValueDictionary)
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Routing.VirtualPathData` for the specified route values by using the specified route name.
    
        
    
        
        :param routeName: The name of the route that is used to generate the :any:`Microsoft.AspNetCore.Routing.VirtualPathData`\.
        
        :type routeName: System.String
    
        
        :param values: A dictionary that contains the parameters for a route.
        
        :type values: Microsoft.AspNetCore.Routing.RouteValueDictionary
        :rtype: Microsoft.AspNetCore.Routing.VirtualPathData
        :return: The :any:`Microsoft.AspNetCore.Routing.VirtualPathData`\.
    
        
        .. code-block:: csharp
    
            protected virtual VirtualPathData GetVirtualPathData(string routeName, RouteValueDictionary values)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Routing.UrlHelper.IsLocalUrl(System.String)
    
        
    
        
        :type url: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool IsLocalUrl(string url)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Routing.UrlHelper.Link(System.String, System.Object)
    
        
    
        
        :type routeName: System.String
    
        
        :type values: System.Object
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string Link(string routeName, object values)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Routing.UrlHelper.RouteUrl(Microsoft.AspNetCore.Mvc.Routing.UrlRouteContext)
    
        
    
        
        :type routeContext: Microsoft.AspNetCore.Mvc.Routing.UrlRouteContext
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string RouteUrl(UrlRouteContext routeContext)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.UrlHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.UrlHelper.ActionContext
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
            public ActionContext ActionContext { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.UrlHelper.AmbientValues
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            protected RouteValueDictionary AmbientValues { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.UrlHelper.HttpContext
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            protected HttpContext HttpContext { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.UrlHelper.Router
    
        
        :rtype: Microsoft.AspNetCore.Routing.IRouter
    
        
        .. code-block:: csharp
    
            protected IRouter Router { get; }
    

