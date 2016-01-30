

InnerAttributeRoute Class
=========================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Routing.IRouter` implementation for attribute routing.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Routing.InnerAttributeRoute`








Syntax
------

.. code-block:: csharp

   public class InnerAttributeRoute : IRouter





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Routing/InnerAttributeRoute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Routing.InnerAttributeRoute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Routing.InnerAttributeRoute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Routing.InnerAttributeRoute.InnerAttributeRoute(Microsoft.AspNet.Routing.IRouter, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Routing.AttributeRouteMatchingEntry>, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Routing.AttributeRouteLinkGenerationEntry>, Microsoft.Extensions.Logging.ILogger, Microsoft.Extensions.Logging.ILogger, System.Int32)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.Routing.InnerAttributeRoute`\.
    
        
        
        
        :param next: The next router. Invoked when a route entry matches.
        
        :type next: Microsoft.AspNet.Routing.IRouter
        
        
        :type matchingEntries: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Routing.AttributeRouteMatchingEntry}
        
        
        :type linkGenerationEntries: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Routing.AttributeRouteLinkGenerationEntry}
        
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :type constraintLogger: Microsoft.Extensions.Logging.ILogger
        
        
        :type version: System.Int32
    
        
        .. code-block:: csharp
    
           public InnerAttributeRoute(IRouter next, IEnumerable<AttributeRouteMatchingEntry> matchingEntries, IEnumerable<AttributeRouteLinkGenerationEntry> linkGenerationEntries, ILogger logger, ILogger constraintLogger, int version)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Routing.InnerAttributeRoute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Routing.InnerAttributeRoute.GetVirtualPath(Microsoft.AspNet.Routing.VirtualPathContext)
    
        
        
        
        :type context: Microsoft.AspNet.Routing.VirtualPathContext
        :rtype: Microsoft.AspNet.Routing.VirtualPathData
    
        
        .. code-block:: csharp
    
           public VirtualPathData GetVirtualPath(VirtualPathContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Routing.InnerAttributeRoute.RouteAsync(Microsoft.AspNet.Routing.RouteContext)
    
        
        
        
        :type context: Microsoft.AspNet.Routing.RouteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task RouteAsync(RouteContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Routing.InnerAttributeRoute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Routing.InnerAttributeRoute.Version
    
        
    
        Gets the version of this route. This corresponds to the value of 
        :dn:prop:`Microsoft.AspNet.Mvc.Infrastructure.ActionDescriptorsCollection.Version` when this route was created.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Version { get; }
    

