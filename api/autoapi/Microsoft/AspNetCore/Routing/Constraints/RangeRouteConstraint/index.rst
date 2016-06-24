

RangeRouteConstraint Class
==========================






Constraints a route parameter to be an integer within a given range of values.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing.Constraints`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Routing.Constraints.RangeRouteConstraint`








Syntax
------

.. code-block:: csharp

    public class RangeRouteConstraint : IRouteConstraint








.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.RangeRouteConstraint
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.RangeRouteConstraint

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.RangeRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Constraints.RangeRouteConstraint.RangeRouteConstraint(System.Int64, System.Int64)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Routing.Constraints.RangeRouteConstraint` class.
    
        
    
        
        :param min: The minimum value.
        
        :type min: System.Int64
    
        
        :param max: The maximum value.
        
        :type max: System.Int64
    
        
        .. code-block:: csharp
    
            public RangeRouteConstraint(long min, long max)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.RangeRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.Constraints.RangeRouteConstraint.Match(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Routing.IRouter, System.String, Microsoft.AspNetCore.Routing.RouteValueDictionary, Microsoft.AspNetCore.Routing.RouteDirection)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type route: Microsoft.AspNetCore.Routing.IRouter
    
        
        :type routeKey: System.String
    
        
        :type values: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        :type routeDirection: Microsoft.AspNetCore.Routing.RouteDirection
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.RangeRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Constraints.RangeRouteConstraint.Max
    
        
    
        
        Gets the maximum allowed value of the route parameter.
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public long Max { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Constraints.RangeRouteConstraint.Min
    
        
    
        
        Gets the minimum allowed value of the route parameter.
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public long Min { get; }
    

