

TreeRouteBuilder Class
======================






Builder for :any:`Microsoft.AspNetCore.Routing.Tree.TreeRouter` instances.


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
* :dn:cls:`Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder`








Syntax
------

.. code-block:: csharp

    public class TreeRouteBuilder








.. dn:class:: Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder.TreeRouteBuilder(Microsoft.Extensions.Logging.ILoggerFactory, System.Text.Encodings.Web.UrlEncoder, Microsoft.Extensions.ObjectPool.ObjectPool<Microsoft.AspNetCore.Routing.Internal.UriBuildingContext>, Microsoft.AspNetCore.Routing.IInlineConstraintResolver)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder`\.
    
        
    
        
        :param loggerFactory: The :any:`Microsoft.Extensions.Logging.ILoggerFactory`\.
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :param urlEncoder: The :any:`System.Text.Encodings.Web.UrlEncoder`\.
        
        :type urlEncoder: System.Text.Encodings.Web.UrlEncoder
    
        
        :param objectPool: The :any:`Microsoft.Extensions.ObjectPool.ObjectPool\`1`\.
        
        :type objectPool: Microsoft.Extensions.ObjectPool.ObjectPool<Microsoft.Extensions.ObjectPool.ObjectPool`1>{Microsoft.AspNetCore.Routing.Internal.UriBuildingContext<Microsoft.AspNetCore.Routing.Internal.UriBuildingContext>}
    
        
        :param constraintResolver: The :any:`Microsoft.AspNetCore.Routing.IInlineConstraintResolver`\.
        
        :type constraintResolver: Microsoft.AspNetCore.Routing.IInlineConstraintResolver
    
        
        .. code-block:: csharp
    
            public TreeRouteBuilder(ILoggerFactory loggerFactory, UrlEncoder urlEncoder, ObjectPool<UriBuildingContext> objectPool, IInlineConstraintResolver constraintResolver)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder.Build()
    
        
    
        
        Builds a :any:`Microsoft.AspNetCore.Routing.Tree.TreeRouter` with the :dn:prop:`Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder.InboundEntries`
        and :dn:prop:`Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder.OutboundEntries` defined in this :any:`Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder`\.
    
        
        :rtype: Microsoft.AspNetCore.Routing.Tree.TreeRouter
        :return: The :any:`Microsoft.AspNetCore.Routing.Tree.TreeRouter`\.
    
        
        .. code-block:: csharp
    
            public TreeRouter Build()
    
    .. dn:method:: Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder.Build(System.Int32)
    
        
    
        
        Builds a :any:`Microsoft.AspNetCore.Routing.Tree.TreeRouter` with the :dn:prop:`Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder.InboundEntries`
        and :dn:prop:`Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder.OutboundEntries` defined in this :any:`Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder`\.
    
        
    
        
        :param version: The version of the :any:`Microsoft.AspNetCore.Routing.Tree.TreeRouter`\.
        
        :type version: System.Int32
        :rtype: Microsoft.AspNetCore.Routing.Tree.TreeRouter
        :return: The :any:`Microsoft.AspNetCore.Routing.Tree.TreeRouter`\.
    
        
        .. code-block:: csharp
    
            public TreeRouter Build(int version)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder.Clear()
    
        
    
        
        Removes all :dn:prop:`Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder.InboundEntries` and :dn:prop:`Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder.OutboundEntries` from this 
        :any:`Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder`\.
    
        
    
        
        .. code-block:: csharp
    
            public void Clear()
    
    .. dn:method:: Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder.MapInbound(Microsoft.AspNetCore.Routing.IRouter, Microsoft.AspNetCore.Routing.Template.RouteTemplate, System.String, System.Int32)
    
        
    
        
        Adds a new inbound route to the :any:`Microsoft.AspNetCore.Routing.Tree.TreeRouter`\.
    
        
    
        
        :param handler: The :any:`Microsoft.AspNetCore.Routing.IRouter` for handling the route.
        
        :type handler: Microsoft.AspNetCore.Routing.IRouter
    
        
        :param routeTemplate: The :any:`Microsoft.AspNetCore.Routing.Template.RouteTemplate` of the route.
        
        :type routeTemplate: Microsoft.AspNetCore.Routing.Template.RouteTemplate
    
        
        :param routeName: The route name.
        
        :type routeName: System.String
    
        
        :param order: The route order.
        
        :type order: System.Int32
        :rtype: Microsoft.AspNetCore.Routing.Tree.InboundRouteEntry
        :return: The :any:`Microsoft.AspNetCore.Routing.Tree.InboundRouteEntry`\.
    
        
        .. code-block:: csharp
    
            public InboundRouteEntry MapInbound(IRouter handler, RouteTemplate routeTemplate, string routeName, int order)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder.MapOutbound(Microsoft.AspNetCore.Routing.IRouter, Microsoft.AspNetCore.Routing.Template.RouteTemplate, Microsoft.AspNetCore.Routing.RouteValueDictionary, System.String, System.Int32)
    
        
    
        
        Adds a new outbound route to the :any:`Microsoft.AspNetCore.Routing.Tree.TreeRouter`\.
    
        
    
        
        :param handler: The :any:`Microsoft.AspNetCore.Routing.IRouter` for handling the link generation.
        
        :type handler: Microsoft.AspNetCore.Routing.IRouter
    
        
        :param routeTemplate: The :any:`Microsoft.AspNetCore.Routing.Template.RouteTemplate` of the route.
        
        :type routeTemplate: Microsoft.AspNetCore.Routing.Template.RouteTemplate
    
        
        :param requiredLinkValues: The :any:`Microsoft.AspNetCore.Routing.RouteValueDictionary` containing the route values.
        
        :type requiredLinkValues: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        :param routeName: The route name.
        
        :type routeName: System.String
    
        
        :param order: The route order.
        
        :type order: System.Int32
        :rtype: Microsoft.AspNetCore.Routing.Tree.OutboundRouteEntry
        :return: The :any:`Microsoft.AspNetCore.Routing.Tree.OutboundRouteEntry`\.
    
        
        .. code-block:: csharp
    
            public OutboundRouteEntry MapOutbound(IRouter handler, RouteTemplate routeTemplate, RouteValueDictionary requiredLinkValues, string routeName, int order)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder.InboundEntries
    
        
    
        
        Gets the list of :any:`Microsoft.AspNetCore.Routing.Tree.InboundRouteEntry`\.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Routing.Tree.InboundRouteEntry<Microsoft.AspNetCore.Routing.Tree.InboundRouteEntry>}
    
        
        .. code-block:: csharp
    
            public IList<InboundRouteEntry> InboundEntries { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder.OutboundEntries
    
        
    
        
        Gets the list of :any:`Microsoft.AspNetCore.Routing.Tree.OutboundRouteEntry`\.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Routing.Tree.OutboundRouteEntry<Microsoft.AspNetCore.Routing.Tree.OutboundRouteEntry>}
    
        
        .. code-block:: csharp
    
            public IList<OutboundRouteEntry> OutboundEntries { get; }
    

