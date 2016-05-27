

AttributeRoute Class
====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.AttributeRoute`








Syntax
------

.. code-block:: csharp

    public class AttributeRoute : IRouter








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.AttributeRoute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.AttributeRoute

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.AttributeRoute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.AttributeRoute.AttributeRoute(Microsoft.AspNetCore.Routing.IRouter, Microsoft.AspNetCore.Mvc.Infrastructure.IActionDescriptorCollectionProvider, Microsoft.AspNetCore.Routing.IInlineConstraintResolver, Microsoft.Extensions.ObjectPool.ObjectPool<Microsoft.AspNetCore.Routing.Internal.UriBuildingContext>, System.Text.Encodings.Web.UrlEncoder, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        :type target: Microsoft.AspNetCore.Routing.IRouter
    
        
        :type actionDescriptorCollectionProvider: Microsoft.AspNetCore.Mvc.Infrastructure.IActionDescriptorCollectionProvider
    
        
        :type constraintResolver: Microsoft.AspNetCore.Routing.IInlineConstraintResolver
    
        
        :type contextPool: Microsoft.Extensions.ObjectPool.ObjectPool<Microsoft.Extensions.ObjectPool.ObjectPool`1>{Microsoft.AspNetCore.Routing.Internal.UriBuildingContext<Microsoft.AspNetCore.Routing.Internal.UriBuildingContext>}
    
        
        :type urlEncoder: System.Text.Encodings.Web.UrlEncoder
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public AttributeRoute(IRouter target, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider, IInlineConstraintResolver constraintResolver, ObjectPool<UriBuildingContext> contextPool, UrlEncoder urlEncoder, ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.AttributeRoute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.AttributeRoute.GetVirtualPath(Microsoft.AspNetCore.Routing.VirtualPathContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Routing.VirtualPathContext
        :rtype: Microsoft.AspNetCore.Routing.VirtualPathData
    
        
        .. code-block:: csharp
    
            public VirtualPathData GetVirtualPath(VirtualPathContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.AttributeRoute.RouteAsync(Microsoft.AspNetCore.Routing.RouteContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Routing.RouteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task RouteAsync(RouteContext context)
    

