

RegexRouteConstraint Class
==========================





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
* :dn:cls:`Microsoft.AspNetCore.Routing.Constraints.RegexRouteConstraint`








Syntax
------

.. code-block:: csharp

    public class RegexRouteConstraint : IRouteConstraint








.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.RegexRouteConstraint
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.RegexRouteConstraint

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.RegexRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Constraints.RegexRouteConstraint.RegexRouteConstraint(System.String)
    
        
    
        
        :type regexPattern: System.String
    
        
        .. code-block:: csharp
    
            public RegexRouteConstraint(string regexPattern)
    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Constraints.RegexRouteConstraint.RegexRouteConstraint(System.Text.RegularExpressions.Regex)
    
        
    
        
        :type regex: System.Text.RegularExpressions.Regex
    
        
        .. code-block:: csharp
    
            public RegexRouteConstraint(Regex regex)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.RegexRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Constraints.RegexRouteConstraint.Constraint
    
        
        :rtype: System.Text.RegularExpressions.Regex
    
        
        .. code-block:: csharp
    
            public Regex Constraint { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.Constraints.RegexRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.Constraints.RegexRouteConstraint.Match(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Routing.IRouter, System.String, Microsoft.AspNetCore.Routing.RouteValueDictionary, Microsoft.AspNetCore.Routing.RouteDirection)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type route: Microsoft.AspNetCore.Routing.IRouter
    
        
        :type routeKey: System.String
    
        
        :type values: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        :type routeDirection: Microsoft.AspNetCore.Routing.RouteDirection
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    

