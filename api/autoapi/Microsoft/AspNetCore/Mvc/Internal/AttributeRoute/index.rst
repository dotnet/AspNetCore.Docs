

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

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.AttributeRoute.AttributeRoute(Microsoft.AspNetCore.Mvc.Infrastructure.IActionDescriptorCollectionProvider, System.IServiceProvider, System.Func<Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor[], Microsoft.AspNetCore.Routing.IRouter>)
    
        
    
        
        :type actionDescriptorCollectionProvider: Microsoft.AspNetCore.Mvc.Infrastructure.IActionDescriptorCollectionProvider
    
        
        :type services: System.IServiceProvider
    
        
        :type handlerFactory: System.Func<System.Func`2>{Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor<Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor>[], Microsoft.AspNetCore.Routing.IRouter<Microsoft.AspNetCore.Routing.IRouter>}
    
        
        .. code-block:: csharp
    
            public AttributeRoute(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider, IServiceProvider services, Func<ActionDescriptor[], IRouter> handlerFactory)
    

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
    

