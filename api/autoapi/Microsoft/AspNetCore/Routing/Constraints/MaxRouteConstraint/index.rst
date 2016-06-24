

MaxRouteConstraint Class
========================






Constrains a route parameter to be an integer with a maximum value.


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
* :dn:cls:`Microsoft.AspNetCore.Routing.Constraints.MaxRouteConstraint`








Syntax
------

.. code-block:: csharp

    public class MaxRouteConstraint : IRouteConstraint








.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.MaxRouteConstraint
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.MaxRouteConstraint

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.MaxRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Constraints.MaxRouteConstraint.MaxRouteConstraint(System.Int64)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Routing.Constraints.MaxRouteConstraint` class.
    
        
    
        
        :param max: The maximum value allowed for the route parameter.
        
        :type max: System.Int64
    
        
        .. code-block:: csharp
    
            public MaxRouteConstraint(long max)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.MaxRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.Constraints.MaxRouteConstraint.Match(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Routing.IRouter, System.String, Microsoft.AspNetCore.Routing.RouteValueDictionary, Microsoft.AspNetCore.Routing.RouteDirection)
    
        
    
        
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

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.MaxRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Constraints.MaxRouteConstraint.Max
    
        
    
        
        Gets the maximum allowed value of the route parameter.
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public long Max { get; }
    

