

KnownRouteValueConstraint Class
===============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Routing.KnownRouteValueConstraint`








Syntax
------

.. code-block:: csharp

   public class KnownRouteValueConstraint : IRouteConstraint





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Routing/KnownRouteValueConstraint.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Routing.KnownRouteValueConstraint

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Routing.KnownRouteValueConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Routing.KnownRouteValueConstraint.Match(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Routing.IRouter, System.String, System.Collections.Generic.IDictionary<System.String, System.Object>, Microsoft.AspNet.Routing.RouteDirection)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        
        
        :type route: Microsoft.AspNet.Routing.IRouter
        
        
        :type routeKey: System.String
        
        
        :type values: System.Collections.Generic.IDictionary{System.String,System.Object}
        
        
        :type routeDirection: Microsoft.AspNet.Routing.RouteDirection
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Match(HttpContext httpContext, IRouter route, string routeKey, IDictionary<string, object> values, RouteDirection routeDirection)
    

