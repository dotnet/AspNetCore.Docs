

OptionalRouteConstraint Class
=============================






Defines a constraint on an optional parameter. If the parameter is present, then it is constrained by InnerConstraint. 


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
* :dn:cls:`Microsoft.AspNetCore.Routing.Constraints.OptionalRouteConstraint`








Syntax
------

.. code-block:: csharp

    public class OptionalRouteConstraint : IRouteConstraint








.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.OptionalRouteConstraint
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.OptionalRouteConstraint

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.OptionalRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Constraints.OptionalRouteConstraint.OptionalRouteConstraint(Microsoft.AspNetCore.Routing.IRouteConstraint)
    
        
    
        
        :type innerConstraint: Microsoft.AspNetCore.Routing.IRouteConstraint
    
        
        .. code-block:: csharp
    
            public OptionalRouteConstraint(IRouteConstraint innerConstraint)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.OptionalRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Constraints.OptionalRouteConstraint.InnerConstraint
    
        
        :rtype: Microsoft.AspNetCore.Routing.IRouteConstraint
    
        
        .. code-block:: csharp
    
            public IRouteConstraint InnerConstraint { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.OptionalRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.Constraints.OptionalRouteConstraint.Match(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Routing.IRouter, System.String, Microsoft.AspNetCore.Routing.RouteValueDictionary, Microsoft.AspNetCore.Routing.RouteDirection)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type route: Microsoft.AspNetCore.Routing.IRouter
    
        
        :type routeKey: System.String
    
        
        :type values: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        :type routeDirection: Microsoft.AspNetCore.Routing.RouteDirection
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    

