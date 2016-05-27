

IRouteConstraint Interface
==========================






Defines the contract that a class must implement in order to check whether a URL parameter
value is valid for a constraint.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing`
Assemblies
    * Microsoft.AspNetCore.Routing.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IRouteConstraint








.. dn:interface:: Microsoft.AspNetCore.Routing.IRouteConstraint
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Routing.IRouteConstraint

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Routing.IRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.IRouteConstraint.Match(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Routing.IRouter, System.String, Microsoft.AspNetCore.Routing.RouteValueDictionary, Microsoft.AspNetCore.Routing.RouteDirection)
    
        
    
        
        Determines whether the URL parameter contains a valid value for this constraint.
    
        
    
        
        :param httpContext: An object that encapsulates information about the HTTP request.
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param route: The router that this constraint belongs to.
        
        :type route: Microsoft.AspNetCore.Routing.IRouter
    
        
        :param routeKey: The name of the parameter that is being checked.
        
        :type routeKey: System.String
    
        
        :param values: A dictionary that contains the parameters for the URL.
        
        :type values: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        :param routeDirection: 
            An object that indicates whether the constraint check is being performed
            when an incoming request is being handled or when a URL is being generated.
        
        :type routeDirection: Microsoft.AspNetCore.Routing.RouteDirection
        :rtype: System.Boolean
        :return: <code>true</code> if the URL parameter contains a valid value; otherwise, <code>false</code>.
    
        
        .. code-block:: csharp
    
            bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    

