

MaxRouteConstraint Class
========================



.. contents:: 
   :local:



Summary
-------

Constrains a route parameter to be an integer with a maximum value.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.Constraints.MaxRouteConstraint`








Syntax
------

.. code-block:: csharp

   public class MaxRouteConstraint : IRouteConstraint





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/routing/src/Microsoft.AspNet.Routing/Constraints/MaxRouteConstraint.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.Constraints.MaxRouteConstraint

Constructors
------------

.. dn:class:: Microsoft.AspNet.Routing.Constraints.MaxRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Routing.Constraints.MaxRouteConstraint.MaxRouteConstraint(System.Int64)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Routing.Constraints.MaxRouteConstraint` class.
    
        
        
        
        :param max: The maximum value allowed for the route parameter.
        
        :type max: System.Int64
    
        
        .. code-block:: csharp
    
           public MaxRouteConstraint(long max)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Routing.Constraints.MaxRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.Constraints.MaxRouteConstraint.Match(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Routing.IRouter, System.String, System.Collections.Generic.IDictionary<System.String, System.Object>, Microsoft.AspNet.Routing.RouteDirection)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        
        
        :type route: Microsoft.AspNet.Routing.IRouter
        
        
        :type routeKey: System.String
        
        
        :type values: System.Collections.Generic.IDictionary{System.String,System.Object}
        
        
        :type routeDirection: Microsoft.AspNet.Routing.RouteDirection
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Match(HttpContext httpContext, IRouter route, string routeKey, IDictionary<string, object> values, RouteDirection routeDirection)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Routing.Constraints.MaxRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Routing.Constraints.MaxRouteConstraint.Max
    
        
    
        Gets the maximum allowed value of the route parameter.
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
           public long Max { get; }
    

