

IUrlHelper Interface
====================






Defines the contract for the helper to build URLs for ASP.NET MVC within an application.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IUrlHelper








.. dn:interface:: Microsoft.AspNetCore.Mvc.IUrlHelper
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.IUrlHelper

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.IUrlHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.IUrlHelper.Action(Microsoft.AspNetCore.Mvc.Routing.UrlActionContext)
    
        
    
        
        Generates a fully qualified or absolute URL specified by :any:`Microsoft.AspNetCore.Mvc.Routing.UrlActionContext` for an action
        method, which contains action name, controller name, route values, protocol to use, host name, and fragment.
    
        
    
        
        :param actionContext: The context object for the generated URLs for an action method.
        
        :type actionContext: Microsoft.AspNetCore.Mvc.Routing.UrlActionContext
        :rtype: System.String
        :return: The fully qualified or absolute URL to an action method.
    
        
        .. code-block:: csharp
    
            string Action(UrlActionContext actionContext)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.IUrlHelper.Content(System.String)
    
        
    
        
        Converts a virtual (relative) path to an application absolute path.
    
        
    
        
        :param contentPath: The virtual path of the content.
        
        :type contentPath: System.String
        :rtype: System.String
        :return: The application absolute path.
    
        
        .. code-block:: csharp
    
            string Content(string contentPath)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.IUrlHelper.IsLocalUrl(System.String)
    
        
    
        
        Returns a value that indicates whether the URL is local. A URL with an absolute path is considered local
        if it does not have a host/authority part. URLs using virtual paths ('~/') are also local.
    
        
    
        
        :param url: The URL.
        
        :type url: System.String
        :rtype: System.Boolean
        :return: <code>true</code> if the URL is local; otherwise, <code>false</code>.
    
        
        .. code-block:: csharp
    
            bool IsLocalUrl(string url)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.IUrlHelper.Link(System.String, System.Object)
    
        
    
        
        Generates an absolute URL using the specified route name and values.
    
        
    
        
        :param routeName: The name of the route that is used to generate the URL.
        
        :type routeName: System.String
    
        
        :param values: An object that contains the route values.
        
        :type values: System.Object
        :rtype: System.String
        :return: The generated absolute URL.
    
        
        .. code-block:: csharp
    
            string Link(string routeName, object values)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.IUrlHelper.RouteUrl(Microsoft.AspNetCore.Mvc.Routing.UrlRouteContext)
    
        
    
        
        Generates a fully qualified or absolute URL specified by :any:`Microsoft.AspNetCore.Mvc.Routing.UrlRouteContext`\, which
        contains the route name, the route values, protocol to use, host name and fragment.
    
        
    
        
        :param routeContext: The context object for the generated URLs for a route.
        
        :type routeContext: Microsoft.AspNetCore.Mvc.Routing.UrlRouteContext
        :rtype: System.String
        :return: The fully qualified or absolute URL.
    
        
        .. code-block:: csharp
    
            string RouteUrl(UrlRouteContext routeContext)
    

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.IUrlHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.IUrlHelper.ActionContext
    
        
    
        
        Gets the :dn:prop:`Microsoft.AspNetCore.Mvc.IUrlHelper.ActionContext` for the current request.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
            ActionContext ActionContext { get; }
    

