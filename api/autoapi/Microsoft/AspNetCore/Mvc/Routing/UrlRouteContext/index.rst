

UrlRouteContext Class
=====================






Context object to be used for the URLs that :dn:meth:`Microsoft.AspNetCore.Mvc.IUrlHelper.RouteUrl(Microsoft.AspNetCore.Mvc.Routing.UrlRouteContext)` generates.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Routing`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Routing.UrlRouteContext`








Syntax
------

.. code-block:: csharp

    public class UrlRouteContext








.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.UrlRouteContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.UrlRouteContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.UrlRouteContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.UrlRouteContext.Fragment
    
        
    
        
        The fragment for the URLs that :dn:meth:`Microsoft.AspNetCore.Mvc.IUrlHelper.RouteUrl(Microsoft.AspNetCore.Mvc.Routing.UrlRouteContext)` generates.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Fragment { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.UrlRouteContext.Host
    
        
    
        
        The host name for the URLs that :dn:meth:`Microsoft.AspNetCore.Mvc.IUrlHelper.RouteUrl(Microsoft.AspNetCore.Mvc.Routing.UrlRouteContext)` generates.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Host { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.UrlRouteContext.Protocol
    
        
    
        
        The protocol for the URLs that :dn:meth:`Microsoft.AspNetCore.Mvc.IUrlHelper.RouteUrl(Microsoft.AspNetCore.Mvc.Routing.UrlRouteContext)` generates
        such as "http" or "https"
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Protocol { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.UrlRouteContext.RouteName
    
        
    
        
        The name of the route that :dn:meth:`Microsoft.AspNetCore.Mvc.IUrlHelper.RouteUrl(Microsoft.AspNetCore.Mvc.Routing.UrlRouteContext)` uses to generate URLs.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RouteName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.UrlRouteContext.Values
    
        
    
        
        The object that contains the route values for the generated URLs.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Values { get; set; }
    

