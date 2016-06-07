

RouteConstraintAttribute Class
==============================






An attribute which specifies a required route value for an action or controller.

When placed on an action, the route data of a request must match the expectations of the route
constraint in order for the action to be selected. See :dn:prop:`Microsoft.AspNetCore.Mvc.Routing.RouteConstraintAttribute.RouteKeyHandling` for
the expectations that must be satisfied by the route data.

When placed on a controller, unless overridden by the action, the constraint applies to all
actions defined by the controller.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Routing`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Routing.RouteConstraintAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class RouteConstraintAttribute : Attribute, _Attribute, IRouteConstraintProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.RouteConstraintAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.RouteConstraintAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.RouteConstraintAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.RouteConstraintAttribute.BlockNonAttributedActions
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool BlockNonAttributedActions
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.RouteConstraintAttribute.RouteKey
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RouteKey
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.RouteConstraintAttribute.RouteKeyHandling
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Routing.RouteKeyHandling
    
        
        .. code-block:: csharp
    
            public RouteKeyHandling RouteKeyHandling
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.RouteConstraintAttribute.RouteValue
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RouteValue
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.RouteConstraintAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Routing.RouteConstraintAttribute.RouteConstraintAttribute(System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Routing.RouteConstraintAttribute` with :dn:prop:`Microsoft.AspNetCore.Mvc.Routing.RouteConstraintAttribute.RouteKeyHandling` set as
        :dn:field:`Microsoft.AspNetCore.Mvc.Routing.RouteKeyHandling.DenyKey`\.
    
        
    
        
        :param routeKey: The route value key.
        
        :type routeKey: System.String
    
        
        .. code-block:: csharp
    
            protected RouteConstraintAttribute(string routeKey)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Routing.RouteConstraintAttribute.RouteConstraintAttribute(System.String, System.String, System.Boolean)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Routing.RouteConstraintAttribute` with
        :dn:prop:`Microsoft.AspNetCore.Mvc.Routing.RouteConstraintAttribute.RouteKeyHandling` set to :dn:field:`Microsoft.AspNetCore.Mvc.Routing.RouteKeyHandling.RequireKey`\.
    
        
    
        
        :param routeKey: The route value key.
        
        :type routeKey: System.String
    
        
        :param routeValue: The expected route value.
        
        :type routeValue: System.String
    
        
        :param blockNonAttributedActions: 
            Set to true to negate this constraint on all actions that do not define a behavior for this route key.
        
        :type blockNonAttributedActions: System.Boolean
    
        
        .. code-block:: csharp
    
            protected RouteConstraintAttribute(string routeKey, string routeValue, bool blockNonAttributedActions)
    

