

MaxLengthRouteConstraint Class
==============================



.. contents:: 
   :local:



Summary
-------

Constrains a route parameter to be a string with a maximum length.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.Constraints.MaxLengthRouteConstraint`








Syntax
------

.. code-block:: csharp

   public class MaxLengthRouteConstraint : IRouteConstraint





GitHub
------

`View on GitHub <https://github.com/aspnet/routing/blob/master/src/Microsoft.AspNet.Routing/Constraints/MaxLengthRouteConstraint.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.Constraints.MaxLengthRouteConstraint

Constructors
------------

.. dn:class:: Microsoft.AspNet.Routing.Constraints.MaxLengthRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Routing.Constraints.MaxLengthRouteConstraint.MaxLengthRouteConstraint(System.Int32)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Routing.Constraints.MaxLengthRouteConstraint` class.
    
        
        
        
        :param maxLength: The maximum length allowed for the route parameter.
        
        :type maxLength: System.Int32
    
        
        .. code-block:: csharp
    
           public MaxLengthRouteConstraint(int maxLength)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Routing.Constraints.MaxLengthRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.Constraints.MaxLengthRouteConstraint.Match(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Routing.IRouter, System.String, System.Collections.Generic.IDictionary<System.String, System.Object>, Microsoft.AspNet.Routing.RouteDirection)
    
        
        
        
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

.. dn:class:: Microsoft.AspNet.Routing.Constraints.MaxLengthRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Routing.Constraints.MaxLengthRouteConstraint.MaxLength
    
        
    
        Gets the maximum length allowed for the route parameter.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int MaxLength { get; }
    

