

LengthRouteConstraint Class
===========================






Constrains a route parameter to be a string of a given length or within a given range of lengths.


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
* :dn:cls:`Microsoft.AspNetCore.Routing.Constraints.LengthRouteConstraint`








Syntax
------

.. code-block:: csharp

    public class LengthRouteConstraint : IRouteConstraint








.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.LengthRouteConstraint
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.LengthRouteConstraint

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.LengthRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Constraints.LengthRouteConstraint.MaxLength
    
        
    
        
        Gets the maximum length allowed for the route parameter.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int MaxLength
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Constraints.LengthRouteConstraint.MinLength
    
        
    
        
        Gets the minimum length allowed for the route parameter.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int MinLength
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.LengthRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Constraints.LengthRouteConstraint.LengthRouteConstraint(System.Int32)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Routing.Constraints.LengthRouteConstraint` class that constrains
        a route parameter to be a string of a given length.
    
        
    
        
        :param length: The length of the route parameter.
        
        :type length: System.Int32
    
        
        .. code-block:: csharp
    
            public LengthRouteConstraint(int length)
    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Constraints.LengthRouteConstraint.LengthRouteConstraint(System.Int32, System.Int32)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Routing.Constraints.LengthRouteConstraint` class that constrains
        a route parameter to be a string of a given length.
    
        
    
        
        :param minLength: The minimum length allowed for the route parameter.
        
        :type minLength: System.Int32
    
        
        :param maxLength: The maximum length allowed for the route parameter.
        
        :type maxLength: System.Int32
    
        
        .. code-block:: csharp
    
            public LengthRouteConstraint(int minLength, int maxLength)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.LengthRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.Constraints.LengthRouteConstraint.Match(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Routing.IRouter, System.String, Microsoft.AspNetCore.Routing.RouteValueDictionary, Microsoft.AspNetCore.Routing.RouteDirection)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type route: Microsoft.AspNetCore.Routing.IRouter
    
        
        :type routeKey: System.String
    
        
        :type values: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        :type routeDirection: Microsoft.AspNetCore.Routing.RouteDirection
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    

