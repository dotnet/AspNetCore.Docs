

RangeRouteConstraint Class
==========================



.. contents:: 
   :local:



Summary
-------

Constraints a route parameter to be an integer within a given range of values.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.Constraints.RangeRouteConstraint`








Syntax
------

.. code-block:: csharp

   public class RangeRouteConstraint : IRouteConstraint





GitHub
------

`View on GitHub <https://github.com/aspnet/routing/blob/master/src/Microsoft.AspNet.Routing/Constraints/RangeRouteConstraint.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.Constraints.RangeRouteConstraint

Constructors
------------

.. dn:class:: Microsoft.AspNet.Routing.Constraints.RangeRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Routing.Constraints.RangeRouteConstraint.RangeRouteConstraint(System.Int64, System.Int64)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Routing.Constraints.RangeRouteConstraint` class.
    
        
        
        
        :param min: The minimum value.
        
        :type min: System.Int64
        
        
        :param max: The maximum value.
        
        :type max: System.Int64
    
        
        .. code-block:: csharp
    
           public RangeRouteConstraint(long min, long max)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Routing.Constraints.RangeRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.Constraints.RangeRouteConstraint.Match(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Routing.IRouter, System.String, System.Collections.Generic.IDictionary<System.String, System.Object>, Microsoft.AspNet.Routing.RouteDirection)
    
        
        
        
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

.. dn:class:: Microsoft.AspNet.Routing.Constraints.RangeRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Routing.Constraints.RangeRouteConstraint.Max
    
        
    
        Gets the maximum allowed value of the route parameter.
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
           public long Max { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.Constraints.RangeRouteConstraint.Min
    
        
    
        Gets the minimum allowed value of the route parameter.
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
           public long Min { get; }
    

