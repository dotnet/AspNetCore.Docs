

AttributeRouteInfo Class
========================






Represents the routing information for an action that is attribute routed.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Routing`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Routing.AttributeRouteInfo`








Syntax
------

.. code-block:: csharp

    public class AttributeRouteInfo








.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.AttributeRouteInfo
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.AttributeRouteInfo

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Routing.AttributeRouteInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.AttributeRouteInfo.Name
    
        
    
        
        Gets the name of the route associated with a given action. This property can be used
        to generate a link by referring to the route by name instead of attempting to match a
        route by provided route data.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.AttributeRouteInfo.Order
    
        
    
        
        Gets the order of the route associated with a given action. This property determines
        the order in which routes get executed. Routes with a lower order value are tried first. In case a route
        doesn't specify a value, it gets a default order of 0.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Routing.AttributeRouteInfo.Template
    
        
    
        
        The route template. May be null if the action has no attribute routes.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Template { get; set; }
    

