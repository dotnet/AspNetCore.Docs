

RegexRouteConstraint Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.Constraints.RegexRouteConstraint`








Syntax
------

.. code-block:: csharp

   public class RegexRouteConstraint : IRouteConstraint





GitHub
------

`View on GitHub <https://github.com/aspnet/routing/blob/master/src/Microsoft.AspNet.Routing/Constraints/RegexRouteConstraint.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.Constraints.RegexRouteConstraint

Constructors
------------

.. dn:class:: Microsoft.AspNet.Routing.Constraints.RegexRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Routing.Constraints.RegexRouteConstraint.RegexRouteConstraint(System.String)
    
        
        
        
        :type regexPattern: System.String
    
        
        .. code-block:: csharp
    
           public RegexRouteConstraint(string regexPattern)
    
    .. dn:constructor:: Microsoft.AspNet.Routing.Constraints.RegexRouteConstraint.RegexRouteConstraint(System.Text.RegularExpressions.Regex)
    
        
        
        
        :type regex: System.Text.RegularExpressions.Regex
    
        
        .. code-block:: csharp
    
           public RegexRouteConstraint(Regex regex)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Routing.Constraints.RegexRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.Constraints.RegexRouteConstraint.Match(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Routing.IRouter, System.String, System.Collections.Generic.IDictionary<System.String, System.Object>, Microsoft.AspNet.Routing.RouteDirection)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        
        
        :type route: Microsoft.AspNet.Routing.IRouter
        
        
        :type routeKey: System.String
        
        
        :type routeValues: System.Collections.Generic.IDictionary{System.String,System.Object}
        
        
        :type routeDirection: Microsoft.AspNet.Routing.RouteDirection
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Match(HttpContext httpContext, IRouter route, string routeKey, IDictionary<string, object> routeValues, RouteDirection routeDirection)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Routing.Constraints.RegexRouteConstraint
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Routing.Constraints.RegexRouteConstraint.Constraint
    
        
        :rtype: System.Text.RegularExpressions.Regex
    
        
        .. code-block:: csharp
    
           public Regex Constraint { get; }
    

