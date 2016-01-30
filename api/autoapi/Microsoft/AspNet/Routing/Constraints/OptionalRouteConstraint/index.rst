

OptionalRouteConstraint Class
=============================



.. contents:: 
   :local:



Summary
-------

Defines a constraint on an optional parameter. If the parameter is present, then it is constrained by InnerConstraint.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.Constraints.OptionalRouteConstraint`








Syntax
------

.. code-block:: csharp

   public class OptionalRouteConstraint : IRouteConstraint





GitHub
------

`View on GitHub <https://github.com/aspnet/routing/blob/master/src/Microsoft.AspNet.Routing/Constraints/OptionalRouteConstraint.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.Constraints.OptionalRouteConstraint

Constructors
------------

.. dn:class:: Microsoft.AspNet.Routing.Constraints.OptionalRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Routing.Constraints.OptionalRouteConstraint.OptionalRouteConstraint(Microsoft.AspNet.Routing.IRouteConstraint)
    
        
        
        
        :type innerConstraint: Microsoft.AspNet.Routing.IRouteConstraint
    
        
        .. code-block:: csharp
    
           public OptionalRouteConstraint(IRouteConstraint innerConstraint)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Routing.Constraints.OptionalRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.Constraints.OptionalRouteConstraint.Match(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Routing.IRouter, System.String, System.Collections.Generic.IDictionary<System.String, System.Object>, Microsoft.AspNet.Routing.RouteDirection)
    
        
        
        
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

.. dn:class:: Microsoft.AspNet.Routing.Constraints.OptionalRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Routing.Constraints.OptionalRouteConstraint.InnerConstraint
    
        
        :rtype: Microsoft.AspNet.Routing.IRouteConstraint
    
        
        .. code-block:: csharp
    
           public IRouteConstraint InnerConstraint { get; }
    

