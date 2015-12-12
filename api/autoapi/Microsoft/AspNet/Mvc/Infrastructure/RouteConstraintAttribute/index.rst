

RouteConstraintAttribute Class
==============================



.. contents:: 
   :local:



Summary
-------

An attribute which specifies a required route value for an action or controller.


When placed on an action, the route data of a request must match the expectations of the route
constraint in order for the action to be selected. See :dn:prop:`Microsoft.AspNet.Mvc.Infrastructure.RouteConstraintAttribute.RouteKeyHandling` for
the expectations that must be satisfied by the route data.


When placed on a controller, unless overridden by the action, the constraint applies to all
actions defined by the controller.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.Infrastructure.RouteConstraintAttribute`








Syntax
------

.. code-block:: csharp

   public abstract class RouteConstraintAttribute : Attribute, _Attribute, IRouteConstraintProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Infrastructure/RouteConstraintAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.RouteConstraintAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.RouteConstraintAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Infrastructure.RouteConstraintAttribute.RouteConstraintAttribute(System.String, Microsoft.AspNet.Mvc.Routing.RouteKeyHandling)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.Infrastructure.RouteConstraintAttribute`\.
    
        
        
        
        :param routeKey: The route value key.
        
        :type routeKey: System.String
        
        
        :param keyHandling: The  value. Must be
            or .
        
        :type keyHandling: Microsoft.AspNet.Mvc.Routing.RouteKeyHandling
    
        
        .. code-block:: csharp
    
           protected RouteConstraintAttribute(string routeKey, RouteKeyHandling keyHandling)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Infrastructure.RouteConstraintAttribute.RouteConstraintAttribute(System.String, System.String, System.Boolean)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.Infrastructure.RouteConstraintAttribute` with 
        :dn:prop:`Microsoft.AspNet.Mvc.Infrastructure.RouteConstraintAttribute.RouteKeyHandling` set to :dn:field:`Microsoft.AspNet.Mvc.Routing.RouteKeyHandling.RequireKey`\.
    
        
        
        
        :param routeKey: The route value key.
        
        :type routeKey: System.String
        
        
        :param routeValue: The expected route value.
        
        :type routeValue: System.String
        
        
        :param blockNonAttributedActions: Set to true to negate this constraint on all actions that do not define a behavior for this route key.
        
        :type blockNonAttributedActions: System.Boolean
    
        
        .. code-block:: csharp
    
           protected RouteConstraintAttribute(string routeKey, string routeValue, bool blockNonAttributedActions)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.RouteConstraintAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Infrastructure.RouteConstraintAttribute.BlockNonAttributedActions
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool BlockNonAttributedActions { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Infrastructure.RouteConstraintAttribute.RouteKey
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RouteKey { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Infrastructure.RouteConstraintAttribute.RouteKeyHandling
    
        
        :rtype: Microsoft.AspNet.Mvc.Routing.RouteKeyHandling
    
        
        .. code-block:: csharp
    
           public RouteKeyHandling RouteKeyHandling { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Infrastructure.RouteConstraintAttribute.RouteValue
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RouteValue { get; }
    

