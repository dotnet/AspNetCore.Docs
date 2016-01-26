

MinLengthRouteConstraint Class
==============================



.. contents:: 
   :local:



Summary
-------

Constrains a route parameter to be a string with a minimum length.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.Constraints.MinLengthRouteConstraint`








Syntax
------

.. code-block:: csharp

   public class MinLengthRouteConstraint : IRouteConstraint





GitHub
------

`View on GitHub <https://github.com/aspnet/routing/blob/master/src/Microsoft.AspNet.Routing/Constraints/MinLengthRouteConstraint.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.Constraints.MinLengthRouteConstraint

Constructors
------------

.. dn:class:: Microsoft.AspNet.Routing.Constraints.MinLengthRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Routing.Constraints.MinLengthRouteConstraint.MinLengthRouteConstraint(System.Int32)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Routing.Constraints.MinLengthRouteConstraint` class.
    
        
        
        
        :param minLength: The minimum length allowed for the route parameter.
        
        :type minLength: System.Int32
    
        
        .. code-block:: csharp
    
           public MinLengthRouteConstraint(int minLength)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Routing.Constraints.MinLengthRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.Constraints.MinLengthRouteConstraint.Match(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Routing.IRouter, System.String, System.Collections.Generic.IDictionary<System.String, System.Object>, Microsoft.AspNet.Routing.RouteDirection)
    
        
        
        
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

.. dn:class:: Microsoft.AspNet.Routing.Constraints.MinLengthRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Routing.Constraints.MinLengthRouteConstraint.MinLength
    
        
    
        Gets the minimum length allowed for the route parameter.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int MinLength { get; }
    

