

InboundRouteEntry Class
=======================






Used to build an :any:`Microsoft.AspNetCore.Routing.Tree.TreeRouter`\. Represents a URL template tha will be used to match incoming
request URLs.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing.Tree`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Routing.Tree.InboundRouteEntry`








Syntax
------

.. code-block:: csharp

    public class InboundRouteEntry








.. dn:class:: Microsoft.AspNetCore.Routing.Tree.InboundRouteEntry
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.InboundRouteEntry

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.InboundRouteEntry
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.InboundRouteEntry.Constraints
    
        
    
        
        Gets or sets the route constraints.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, Microsoft.AspNetCore.Routing.IRouteConstraint<Microsoft.AspNetCore.Routing.IRouteConstraint>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, IRouteConstraint> Constraints { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.InboundRouteEntry.Defaults
    
        
    
        
        Gets or sets the route defaults.
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public RouteValueDictionary Defaults { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.InboundRouteEntry.Handler
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Routing.IRouter` to invoke when this entry matches.
    
        
        :rtype: Microsoft.AspNetCore.Routing.IRouter
    
        
        .. code-block:: csharp
    
            public IRouter Handler { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.InboundRouteEntry.Order
    
        
    
        
        Gets or sets the order of the entry.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.InboundRouteEntry.Precedence
    
        
    
        
        Gets or sets the precedence of the entry.
    
        
        :rtype: System.Decimal
    
        
        .. code-block:: csharp
    
            public decimal Precedence { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.InboundRouteEntry.RouteName
    
        
    
        
        Gets or sets the name of the route.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RouteName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.InboundRouteEntry.RouteTemplate
    
        
    
        
        Gets or sets the :dn:prop:`Microsoft.AspNetCore.Routing.Tree.InboundRouteEntry.RouteTemplate`\.
    
        
        :rtype: Microsoft.AspNetCore.Routing.Template.RouteTemplate
    
        
        .. code-block:: csharp
    
            public RouteTemplate RouteTemplate { get; set; }
    

