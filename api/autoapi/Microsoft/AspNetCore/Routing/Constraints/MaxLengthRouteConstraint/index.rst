

MaxLengthRouteConstraint Class
==============================






Constrains a route parameter to be a string with a maximum length.


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
* :dn:cls:`Microsoft.AspNetCore.Routing.Constraints.MaxLengthRouteConstraint`








Syntax
------

.. code-block:: csharp

    public class MaxLengthRouteConstraint : IRouteConstraint








.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.MaxLengthRouteConstraint
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.MaxLengthRouteConstraint

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.MaxLengthRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Constraints.MaxLengthRouteConstraint.MaxLengthRouteConstraint(System.Int32)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Routing.Constraints.MaxLengthRouteConstraint` class.
    
        
    
        
        :param maxLength: The maximum length allowed for the route parameter.
        
        :type maxLength: System.Int32
    
        
        .. code-block:: csharp
    
            public MaxLengthRouteConstraint(int maxLength)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.MaxLengthRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.Constraints.MaxLengthRouteConstraint.Match(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Routing.IRouter, System.String, Microsoft.AspNetCore.Routing.RouteValueDictionary, Microsoft.AspNetCore.Routing.RouteDirection)
    
        
    
        
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

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.MaxLengthRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Constraints.MaxLengthRouteConstraint.MaxLength
    
        
    
        
        Gets the maximum length allowed for the route parameter.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int MaxLength { get; }
    

