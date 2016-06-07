

HttpMethodRouteConstraint Class
===============================






Constrains the HTTP method of request or a route.


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
* :dn:cls:`Microsoft.AspNetCore.Routing.Constraints.HttpMethodRouteConstraint`








Syntax
------

.. code-block:: csharp

    public class HttpMethodRouteConstraint : IRouteConstraint








.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.HttpMethodRouteConstraint
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.HttpMethodRouteConstraint

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.HttpMethodRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Constraints.HttpMethodRouteConstraint.AllowedMethods
    
        
    
        
        Gets the HTTP methods allowed by the constraint.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IList<string> AllowedMethods
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.HttpMethodRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Constraints.HttpMethodRouteConstraint.HttpMethodRouteConstraint(System.String[])
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Routing.Constraints.HttpMethodRouteConstraint` that accepts the HTTP methods specified
        by <em>allowedMethods</em>.
    
        
    
        
        :param allowedMethods: The allowed HTTP methods.
        
        :type allowedMethods: System.String<System.String>[]
    
        
        .. code-block:: csharp
    
            public HttpMethodRouteConstraint(params string[] allowedMethods)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.HttpMethodRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.Constraints.HttpMethodRouteConstraint.Match(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Routing.IRouter, System.String, Microsoft.AspNetCore.Routing.RouteValueDictionary, Microsoft.AspNetCore.Routing.RouteDirection)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type route: Microsoft.AspNetCore.Routing.IRouter
    
        
        :type routeKey: System.String
    
        
        :type values: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        :type routeDirection: Microsoft.AspNetCore.Routing.RouteDirection
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    

