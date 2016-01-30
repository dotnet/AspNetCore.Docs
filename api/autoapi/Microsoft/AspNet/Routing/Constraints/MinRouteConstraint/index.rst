

MinRouteConstraint Class
========================



.. contents:: 
   :local:



Summary
-------

Constrains a route parameter to be a long with a minimum value.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.Constraints.MinRouteConstraint`








Syntax
------

.. code-block:: csharp

   public class MinRouteConstraint : IRouteConstraint





GitHub
------

`View on GitHub <https://github.com/aspnet/routing/blob/master/src/Microsoft.AspNet.Routing/Constraints/MinRouteConstraint.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.Constraints.MinRouteConstraint

Constructors
------------

.. dn:class:: Microsoft.AspNet.Routing.Constraints.MinRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Routing.Constraints.MinRouteConstraint.MinRouteConstraint(System.Int64)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Routing.Constraints.MinRouteConstraint` class.
    
        
        
        
        :param min: The minimum value allowed for the route parameter.
        
        :type min: System.Int64
    
        
        .. code-block:: csharp
    
           public MinRouteConstraint(long min)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Routing.Constraints.MinRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.Constraints.MinRouteConstraint.Match(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Routing.IRouter, System.String, System.Collections.Generic.IDictionary<System.String, System.Object>, Microsoft.AspNet.Routing.RouteDirection)
    
        
        
        
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

.. dn:class:: Microsoft.AspNet.Routing.Constraints.MinRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Routing.Constraints.MinRouteConstraint.Min
    
        
    
        Gets the minimum allowed value of the route parameter.
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
           public long Min { get; }
    

