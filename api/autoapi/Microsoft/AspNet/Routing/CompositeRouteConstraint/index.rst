

CompositeRouteConstraint Class
==============================



.. contents:: 
   :local:



Summary
-------

Constrains a route by several child constraints.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.CompositeRouteConstraint`








Syntax
------

.. code-block:: csharp

   public class CompositeRouteConstraint : IRouteConstraint





GitHub
------

`View on GitHub <https://github.com/aspnet/routing/blob/master/src/Microsoft.AspNet.Routing/Constraints/CompositeRouteConstraint.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.CompositeRouteConstraint

Constructors
------------

.. dn:class:: Microsoft.AspNet.Routing.CompositeRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Routing.CompositeRouteConstraint.CompositeRouteConstraint(System.Collections.Generic.IEnumerable<Microsoft.AspNet.Routing.IRouteConstraint>)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Routing.CompositeRouteConstraint` class.
    
        
        
        
        :param constraints: The child constraints that must match for this constraint to match.
        
        :type constraints: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Routing.IRouteConstraint}
    
        
        .. code-block:: csharp
    
           public CompositeRouteConstraint(IEnumerable<IRouteConstraint> constraints)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Routing.CompositeRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.CompositeRouteConstraint.Match(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Routing.IRouter, System.String, System.Collections.Generic.IDictionary<System.String, System.Object>, Microsoft.AspNet.Routing.RouteDirection)
    
        
        
        
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

.. dn:class:: Microsoft.AspNet.Routing.CompositeRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Routing.CompositeRouteConstraint.Constraints
    
        
    
        Gets the child constraints that must match for this constraint to match.
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Routing.IRouteConstraint}
    
        
        .. code-block:: csharp
    
           public IEnumerable<IRouteConstraint> Constraints { get; }
    

