

OutboundRouteEntry Class
========================






Used to build a :any:`Microsoft.AspNetCore.Routing.Tree.TreeRouter`\. Represents a URL template that will be used to generate
outgoing URLs.


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
* :dn:cls:`Microsoft.AspNetCore.Routing.Tree.OutboundRouteEntry`








Syntax
------

.. code-block:: csharp

    public class OutboundRouteEntry








.. dn:class:: Microsoft.AspNetCore.Routing.Tree.OutboundRouteEntry
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.OutboundRouteEntry

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.OutboundRouteEntry
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.OutboundRouteEntry.Constraints
    
        
    
        
        Gets or sets the route constraints.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, Microsoft.AspNetCore.Routing.IRouteConstraint<Microsoft.AspNetCore.Routing.IRouteConstraint>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, IRouteConstraint> Constraints { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.OutboundRouteEntry.Defaults
    
        
    
        
        Gets or sets the route defaults.
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public RouteValueDictionary Defaults { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.OutboundRouteEntry.Handler
    
        
    
        
        The :any:`Microsoft.AspNetCore.Routing.IRouter` to invoke when this entry matches.
    
        
        :rtype: Microsoft.AspNetCore.Routing.IRouter
    
        
        .. code-block:: csharp
    
            public IRouter Handler { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.OutboundRouteEntry.Order
    
        
    
        
        Gets or sets the order of the entry.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.OutboundRouteEntry.Precedence
    
        
    
        
        Gets or sets the precedence of the template for link generation. A greater value of 
        :dn:prop:`Microsoft.AspNetCore.Routing.Tree.OutboundRouteEntry.Precedence` means that an entry is considered first.
    
        
        :rtype: System.Decimal
    
        
        .. code-block:: csharp
    
            public decimal Precedence { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.OutboundRouteEntry.RequiredLinkValues
    
        
    
        
        Gets or sets the set of values that must be present for link genration.
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public RouteValueDictionary RequiredLinkValues { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.OutboundRouteEntry.RouteName
    
        
    
        
        Gets or sets the name of the route.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RouteName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.OutboundRouteEntry.RouteTemplate
    
        
    
        
        Gets or sets the :dn:prop:`Microsoft.AspNetCore.Routing.Tree.OutboundRouteEntry.RouteTemplate`\.
    
        
        :rtype: Microsoft.AspNetCore.Routing.Template.RouteTemplate
    
        
        .. code-block:: csharp
    
            public RouteTemplate RouteTemplate { get; set; }
    

