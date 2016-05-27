

KnownRouteValueConstraint Class
===============================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Routing.KnownRouteValueConstraint`








Syntax
------

.. code-block:: csharp

    public class KnownRouteValueConstraint : IRouteConstraint








.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.KnownRouteValueConstraint
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.KnownRouteValueConstraint

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.KnownRouteValueConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Routing.KnownRouteValueConstraint.Match(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Routing.IRouter, System.String, Microsoft.AspNetCore.Routing.RouteValueDictionary, Microsoft.AspNetCore.Routing.RouteDirection)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type route: Microsoft.AspNetCore.Routing.IRouter
    
        
        :type routeKey: System.String
    
        
        :type values: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        :type routeDirection: Microsoft.AspNetCore.Routing.RouteDirection
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    

