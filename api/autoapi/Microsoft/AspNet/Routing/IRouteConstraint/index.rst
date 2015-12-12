

IRouteConstraint Interface
==========================



.. contents:: 
   :local:



Summary
-------

Defines the contract that a class must implement in order to check whether a URL parameter value is valid for a constraint.











Syntax
------

.. code-block:: csharp

   public interface IRouteConstraint





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/routing/src/Microsoft.AspNet.Routing/IRouteConstraint.cs>`_





.. dn:interface:: Microsoft.AspNet.Routing.IRouteConstraint

Methods
-------

.. dn:interface:: Microsoft.AspNet.Routing.IRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.IRouteConstraint.Match(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Routing.IRouter, System.String, System.Collections.Generic.IDictionary<System.String, System.Object>, Microsoft.AspNet.Routing.RouteDirection)
    
        
    
        Determines whether the URL parameter contains a valid value for this constraint.
    
        
        
        
        :param httpContext: An object that encapsulates information about the HTTP request.
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        
        
        :param route: The router that this constraint belongs to.
        
        :type route: Microsoft.AspNet.Routing.IRouter
        
        
        :param routeKey: The name of the parameter that is being checked.
        
        :type routeKey: System.String
        
        
        :param values: A dictionary that contains the parameters for the URL.
        
        :type values: System.Collections.Generic.IDictionary{System.String,System.Object}
        
        
        :param routeDirection: An object that indicates whether the constraint check is being performed when an incoming request is being handled or when a URL is being generated.
        
        :type routeDirection: Microsoft.AspNet.Routing.RouteDirection
        :rtype: System.Boolean
        :return: <c>true</c> if the URL parameter contains a valid value; otherwise, <c>false</c>.
    
        
        .. code-block:: csharp
    
           bool Match(HttpContext httpContext, IRouter route, string routeKey, IDictionary<string, object> values, RouteDirection routeDirection)
    

