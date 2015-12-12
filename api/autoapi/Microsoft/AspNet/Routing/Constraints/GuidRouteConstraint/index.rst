

GuidRouteConstraint Class
=========================



.. contents:: 
   :local:



Summary
-------

Constrains a route parameter to represent only :any:`System.Guid` values.
Matches values specified in any of the five formats "N", "D", "B", "P", or "X",
supported by Guid.ToString(string) and Guid.ToString(String, IFormatProvider) methods.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.Constraints.GuidRouteConstraint`








Syntax
------

.. code-block:: csharp

   public class GuidRouteConstraint : IRouteConstraint





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/routing/src/Microsoft.AspNet.Routing/Constraints/GuidRouteConstraint.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.Constraints.GuidRouteConstraint

Methods
-------

.. dn:class:: Microsoft.AspNet.Routing.Constraints.GuidRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.Constraints.GuidRouteConstraint.Match(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Routing.IRouter, System.String, System.Collections.Generic.IDictionary<System.String, System.Object>, Microsoft.AspNet.Routing.RouteDirection)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        
        
        :type route: Microsoft.AspNet.Routing.IRouter
        
        
        :type routeKey: System.String
        
        
        :type values: System.Collections.Generic.IDictionary{System.String,System.Object}
        
        
        :type routeDirection: Microsoft.AspNet.Routing.RouteDirection
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Match(HttpContext httpContext, IRouter route, string routeKey, IDictionary<string, object> values, RouteDirection routeDirection)
    

