

RouteConstraintMatcher Class
============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.RouteConstraintMatcher`








Syntax
------

.. code-block:: csharp

   public class RouteConstraintMatcher





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/routing/src/Microsoft.AspNet.Routing/RouteConstraintMatcher.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.RouteConstraintMatcher

Methods
-------

.. dn:class:: Microsoft.AspNet.Routing.RouteConstraintMatcher
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.RouteConstraintMatcher.Match(System.Collections.Generic.IReadOnlyDictionary<System.String, Microsoft.AspNet.Routing.IRouteConstraint>, System.Collections.Generic.IDictionary<System.String, System.Object>, Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Routing.IRouter, Microsoft.AspNet.Routing.RouteDirection, Microsoft.Extensions.Logging.ILogger)
    
        
        
        
        :type constraints: System.Collections.Generic.IReadOnlyDictionary{System.String,Microsoft.AspNet.Routing.IRouteConstraint}
        
        
        :type routeValues: System.Collections.Generic.IDictionary{System.String,System.Object}
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        
        
        :type route: Microsoft.AspNet.Routing.IRouter
        
        
        :type routeDirection: Microsoft.AspNet.Routing.RouteDirection
        
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool Match(IReadOnlyDictionary<string, IRouteConstraint> constraints, IDictionary<string, object> routeValues, HttpContext httpContext, IRouter route, RouteDirection routeDirection, ILogger logger)
    

