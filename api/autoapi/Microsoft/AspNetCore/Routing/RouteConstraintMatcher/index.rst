

RouteConstraintMatcher Class
============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Routing.RouteConstraintMatcher`








Syntax
------

.. code-block:: csharp

    public class RouteConstraintMatcher








.. dn:class:: Microsoft.AspNetCore.Routing.RouteConstraintMatcher
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.RouteConstraintMatcher

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.RouteConstraintMatcher
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.RouteConstraintMatcher.Match(System.Collections.Generic.IDictionary<System.String, Microsoft.AspNetCore.Routing.IRouteConstraint>, Microsoft.AspNetCore.Routing.RouteValueDictionary, Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Routing.IRouter, Microsoft.AspNetCore.Routing.RouteDirection, Microsoft.Extensions.Logging.ILogger)
    
        
    
        
        :type constraints: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, Microsoft.AspNetCore.Routing.IRouteConstraint<Microsoft.AspNetCore.Routing.IRouteConstraint>}
    
        
        :type routeValues: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type route: Microsoft.AspNetCore.Routing.IRouter
    
        
        :type routeDirection: Microsoft.AspNetCore.Routing.RouteDirection
    
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool Match(IDictionary<string, IRouteConstraint> constraints, RouteValueDictionary routeValues, HttpContext httpContext, IRouter route, RouteDirection routeDirection, ILogger logger)
    

