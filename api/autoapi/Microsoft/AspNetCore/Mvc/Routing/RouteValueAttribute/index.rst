

RouteValueAttribute Class
=========================






<p>
An attribute which specifies a required route value for an action or controller.
</p>
<p>
When placed on an action, the route data of a request must match the expectations of the route
constraint in order for the action to be selected. See :any:`Microsoft.AspNetCore.Mvc.Routing.IRouteValueProvider` for
the expectations that must be satisfied by the route data.
</p>
<p>
When placed on a controller, unless overridden by the action, the constraint applies to all
actions defined by the controller.
</p>


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Routing.RouteValueAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class RouteValueAttribute : Attribute, _Attribute, IRouteValueProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.RouteValueAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.RouteValueAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.RouteValueAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Routing.RouteValueAttribute.RouteValueAttribute(System.String, System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Routing.RouteValueAttribute`\.
    
        
    
        
        :param routeKey: The route value key.
        
        :type routeKey: System.String
    
        
        :param routeValue: The expected route value.
        
        :type routeValue: System.String
    
        
        .. code-block:: csharp
    
            protected RouteValueAttribute(string routeKey, string routeValue)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.RouteValueAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.RouteValueAttribute.RouteKey
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RouteKey { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.RouteValueAttribute.RouteValue
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RouteValue { get; }
    

