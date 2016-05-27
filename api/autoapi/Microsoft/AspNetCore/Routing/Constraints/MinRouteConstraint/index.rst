

MinRouteConstraint Class
========================






Constrains a route parameter to be a long with a minimum value.


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
* :dn:cls:`Microsoft.AspNetCore.Routing.Constraints.MinRouteConstraint`








Syntax
------

.. code-block:: csharp

    public class MinRouteConstraint : IRouteConstraint








.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.MinRouteConstraint
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.MinRouteConstraint

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.MinRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Constraints.MinRouteConstraint.Min
    
        
    
        
        Gets the minimum allowed value of the route parameter.
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public long Min
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.MinRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Constraints.MinRouteConstraint.MinRouteConstraint(System.Int64)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Routing.Constraints.MinRouteConstraint` class.
    
        
    
        
        :param min: The minimum value allowed for the route parameter.
        
        :type min: System.Int64
    
        
        .. code-block:: csharp
    
            public MinRouteConstraint(long min)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.MinRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.Constraints.MinRouteConstraint.Match(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Routing.IRouter, System.String, Microsoft.AspNetCore.Routing.RouteValueDictionary, Microsoft.AspNetCore.Routing.RouteDirection)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type route: Microsoft.AspNetCore.Routing.IRouter
    
        
        :type routeKey: System.String
    
        
        :type values: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        :type routeDirection: Microsoft.AspNetCore.Routing.RouteDirection
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    

