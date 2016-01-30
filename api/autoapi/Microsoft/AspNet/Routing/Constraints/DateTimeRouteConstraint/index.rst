

DateTimeRouteConstraint Class
=============================



.. contents:: 
   :local:



Summary
-------

Constrains a route parameter to represent only :any:`System.DateTime` values.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.Constraints.DateTimeRouteConstraint`








Syntax
------

.. code-block:: csharp

   public class DateTimeRouteConstraint : IRouteConstraint





GitHub
------

`View on GitHub <https://github.com/aspnet/routing/blob/master/src/Microsoft.AspNet.Routing/Constraints/DateTimeRouteConstraint.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.Constraints.DateTimeRouteConstraint

Methods
-------

.. dn:class:: Microsoft.AspNet.Routing.Constraints.DateTimeRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.Constraints.DateTimeRouteConstraint.Match(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Routing.IRouter, System.String, System.Collections.Generic.IDictionary<System.String, System.Object>, Microsoft.AspNet.Routing.RouteDirection)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        
        
        :type route: Microsoft.AspNet.Routing.IRouter
        
        
        :type routeKey: System.String
        
        
        :type values: System.Collections.Generic.IDictionary{System.String,System.Object}
        
        
        :type routeDirection: Microsoft.AspNet.Routing.RouteDirection
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Match(HttpContext httpContext, IRouter route, string routeKey, IDictionary<string, object> values, RouteDirection routeDirection)
    

