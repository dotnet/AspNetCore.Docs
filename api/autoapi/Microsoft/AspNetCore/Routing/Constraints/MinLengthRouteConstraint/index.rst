

MinLengthRouteConstraint Class
==============================






Constrains a route parameter to be a string with a minimum length.


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
* :dn:cls:`Microsoft.AspNetCore.Routing.Constraints.MinLengthRouteConstraint`








Syntax
------

.. code-block:: csharp

    public class MinLengthRouteConstraint : IRouteConstraint








.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.MinLengthRouteConstraint
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.MinLengthRouteConstraint

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.MinLengthRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Constraints.MinLengthRouteConstraint.MinLengthRouteConstraint(System.Int32)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Routing.Constraints.MinLengthRouteConstraint` class.
    
        
    
        
        :param minLength: The minimum length allowed for the route parameter.
        
        :type minLength: System.Int32
    
        
        .. code-block:: csharp
    
            public MinLengthRouteConstraint(int minLength)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.MinLengthRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.Constraints.MinLengthRouteConstraint.Match(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Routing.IRouter, System.String, Microsoft.AspNetCore.Routing.RouteValueDictionary, Microsoft.AspNetCore.Routing.RouteDirection)
    
        
    
        
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

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.MinLengthRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Constraints.MinLengthRouteConstraint.MinLength
    
        
    
        
        Gets the minimum length allowed for the route parameter.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int MinLength { get; }
    

