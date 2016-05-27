

RoutingHttpContextExtensions Class
==================================






Extension methods for :any:`Microsoft.AspNetCore.Http.HttpContext` related to routing.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing`
Assemblies
    * Microsoft.AspNetCore.Routing.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Routing.RoutingHttpContextExtensions`








Syntax
------

.. code-block:: csharp

    public class RoutingHttpContextExtensions








.. dn:class:: Microsoft.AspNetCore.Routing.RoutingHttpContextExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.RoutingHttpContextExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.RoutingHttpContextExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.RoutingHttpContextExtensions.GetRouteData(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Routing.RouteData` associated with the provided <em>httpContext</em>.
    
        
    
        
        :param httpContext: The :any:`Microsoft.AspNetCore.Http.HttpContext` associated with the current request.
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
        :rtype: Microsoft.AspNetCore.Routing.RouteData
        :return: The :any:`Microsoft.AspNetCore.Routing.RouteData`\, or null.
    
        
        .. code-block:: csharp
    
            public static RouteData GetRouteData(HttpContext httpContext)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RoutingHttpContextExtensions.GetRouteValue(Microsoft.AspNetCore.Http.HttpContext, System.String)
    
        
    
        
        Gets a route value from :dn:prop:`Microsoft.AspNetCore.Routing.RouteData.Values` associated with the provided
        <em>httpContext</em>.
    
        
    
        
        :param httpContext: The :any:`Microsoft.AspNetCore.Http.HttpContext` associated with the current request.
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param key: The key of the route value.
        
        :type key: System.String
        :rtype: System.Object
        :return: The corresponding route value, or null.
    
        
        .. code-block:: csharp
    
            public static object GetRouteValue(HttpContext httpContext, string key)
    

