

LengthRouteConstraint Class
===========================



.. contents:: 
   :local:



Summary
-------

Constrains a route parameter to be a string of a given length or within a given range of lengths.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.Constraints.LengthRouteConstraint`








Syntax
------

.. code-block:: csharp

   public class LengthRouteConstraint : IRouteConstraint





GitHub
------

`View on GitHub <https://github.com/aspnet/routing/blob/master/src/Microsoft.AspNet.Routing/Constraints/LengthRouteConstraint.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.Constraints.LengthRouteConstraint

Constructors
------------

.. dn:class:: Microsoft.AspNet.Routing.Constraints.LengthRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Routing.Constraints.LengthRouteConstraint.LengthRouteConstraint(System.Int32)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Routing.Constraints.LengthRouteConstraint` class that constrains
        a route parameter to be a string of a given length.
    
        
        
        
        :param length: The length of the route parameter.
        
        :type length: System.Int32
    
        
        .. code-block:: csharp
    
           public LengthRouteConstraint(int length)
    
    .. dn:constructor:: Microsoft.AspNet.Routing.Constraints.LengthRouteConstraint.LengthRouteConstraint(System.Int32, System.Int32)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Routing.Constraints.LengthRouteConstraint` class that constrains
        a route parameter to be a string of a given length.
    
        
        
        
        :param minLength: The minimum length allowed for the route parameter.
        
        :type minLength: System.Int32
        
        
        :param maxLength: The maximum length allowed for the route parameter.
        
        :type maxLength: System.Int32
    
        
        .. code-block:: csharp
    
           public LengthRouteConstraint(int minLength, int maxLength)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Routing.Constraints.LengthRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.Constraints.LengthRouteConstraint.Match(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Routing.IRouter, System.String, System.Collections.Generic.IDictionary<System.String, System.Object>, Microsoft.AspNet.Routing.RouteDirection)
    
        
        
        
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

.. dn:class:: Microsoft.AspNet.Routing.Constraints.LengthRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Routing.Constraints.LengthRouteConstraint.MaxLength
    
        
    
        Gets the maximum length allowed for the route parameter.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int MaxLength { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.Constraints.LengthRouteConstraint.MinLength
    
        
    
        Gets the minimum length allowed for the route parameter.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int MinLength { get; }
    

