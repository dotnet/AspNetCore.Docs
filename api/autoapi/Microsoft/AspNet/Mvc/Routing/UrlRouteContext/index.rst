

UrlRouteContext Class
=====================



.. contents:: 
   :local:



Summary
-------

Context object to be used for the URLs that :dn:meth:`Microsoft.AspNet.Mvc.IUrlHelper.RouteUrl(Microsoft.AspNet.Mvc.Routing.UrlRouteContext)` generates.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Routing.UrlRouteContext`








Syntax
------

.. code-block:: csharp

   public class UrlRouteContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Routing/UrlRouteContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Routing.UrlRouteContext

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Routing.UrlRouteContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.UrlRouteContext.Fragment
    
        
    
        The fragment for the URLs that :dn:meth:`Microsoft.AspNet.Mvc.IUrlHelper.RouteUrl(Microsoft.AspNet.Mvc.Routing.UrlRouteContext)` generates.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Fragment { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.UrlRouteContext.Host
    
        
    
        The host name for the URLs that :dn:meth:`Microsoft.AspNet.Mvc.IUrlHelper.RouteUrl(Microsoft.AspNet.Mvc.Routing.UrlRouteContext)` generates.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Host { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.UrlRouteContext.Protocol
    
        
    
        The protocol for the URLs that :dn:meth:`Microsoft.AspNet.Mvc.IUrlHelper.RouteUrl(Microsoft.AspNet.Mvc.Routing.UrlRouteContext)` generates
        such as "http" or "https"
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Protocol { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.UrlRouteContext.RouteName
    
        
    
        The name of the route that :dn:meth:`Microsoft.AspNet.Mvc.IUrlHelper.RouteUrl(Microsoft.AspNet.Mvc.Routing.UrlRouteContext)` uses to generate URLs.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RouteName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.UrlRouteContext.Values
    
        
    
        The object that contains the route values for the generated URLs.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object Values { get; set; }
    

