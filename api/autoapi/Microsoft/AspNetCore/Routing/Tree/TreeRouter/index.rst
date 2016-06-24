

TreeRouter Class
================






An :any:`Microsoft.AspNetCore.Routing.IRouter` implementation for attribute routing.


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
* :dn:cls:`Microsoft.AspNetCore.Routing.Tree.TreeRouter`








Syntax
------

.. code-block:: csharp

    public class TreeRouter : IRouter








.. dn:class:: Microsoft.AspNetCore.Routing.Tree.TreeRouter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.TreeRouter

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.TreeRouter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Tree.TreeRouter.TreeRouter(Microsoft.AspNetCore.Routing.Tree.UrlMatchingTree[], System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Routing.Tree.OutboundRouteEntry>, System.Text.Encodings.Web.UrlEncoder, Microsoft.Extensions.ObjectPool.ObjectPool<Microsoft.AspNetCore.Routing.Internal.UriBuildingContext>, Microsoft.Extensions.Logging.ILogger, Microsoft.Extensions.Logging.ILogger, System.Int32)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Routing.Tree.TreeRouter`\.
    
        
    
        
        :param trees: The list of :any:`Microsoft.AspNetCore.Routing.Tree.UrlMatchingTree` that contains the route entries.
        
        :type trees: Microsoft.AspNetCore.Routing.Tree.UrlMatchingTree<Microsoft.AspNetCore.Routing.Tree.UrlMatchingTree>[]
    
        
        :param linkGenerationEntries: The set of :any:`Microsoft.AspNetCore.Routing.Tree.OutboundRouteEntry`\.
        
        :type linkGenerationEntries: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Routing.Tree.OutboundRouteEntry<Microsoft.AspNetCore.Routing.Tree.OutboundRouteEntry>}
    
        
        :param urlEncoder: The :any:`System.Text.Encodings.Web.UrlEncoder`\.
        
        :type urlEncoder: System.Text.Encodings.Web.UrlEncoder
    
        
        :param objectPool: The :any:`Microsoft.Extensions.ObjectPool.ObjectPool\`1`\.
        
        :type objectPool: Microsoft.Extensions.ObjectPool.ObjectPool<Microsoft.Extensions.ObjectPool.ObjectPool`1>{Microsoft.AspNetCore.Routing.Internal.UriBuildingContext<Microsoft.AspNetCore.Routing.Internal.UriBuildingContext>}
    
        
        :param routeLogger: The :any:`Microsoft.Extensions.Logging.ILogger` instance.
        
        :type routeLogger: Microsoft.Extensions.Logging.ILogger
    
        
        :param constraintLogger: The :any:`Microsoft.Extensions.Logging.ILogger` instance used
            in :any:`Microsoft.AspNetCore.Routing.RouteConstraintMatcher`\.
        
        :type constraintLogger: Microsoft.Extensions.Logging.ILogger
    
        
        :param version: The version of this route.
        
        :type version: System.Int32
    
        
        .. code-block:: csharp
    
            public TreeRouter(UrlMatchingTree[] trees, IEnumerable<OutboundRouteEntry> linkGenerationEntries, UrlEncoder urlEncoder, ObjectPool<UriBuildingContext> objectPool, ILogger routeLogger, ILogger constraintLogger, int version)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.TreeRouter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.Tree.TreeRouter.GetVirtualPath(Microsoft.AspNetCore.Routing.VirtualPathContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Routing.VirtualPathContext
        :rtype: Microsoft.AspNetCore.Routing.VirtualPathData
    
        
        .. code-block:: csharp
    
            public VirtualPathData GetVirtualPath(VirtualPathContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.Tree.TreeRouter.RouteAsync(Microsoft.AspNetCore.Routing.RouteContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Routing.RouteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task RouteAsync(RouteContext context)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.TreeRouter
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Routing.Tree.TreeRouter.RouteGroupKey
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string RouteGroupKey
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.TreeRouter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.TreeRouter.Version
    
        
    
        
        Gets the version of this route.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Version { get; }
    

