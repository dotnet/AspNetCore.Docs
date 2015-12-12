

AttributeRoute Class
====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Routing.AttributeRoute`








Syntax
------

.. code-block:: csharp

   public class AttributeRoute : IRouter





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Routing/AttributeRoute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Routing.AttributeRoute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Routing.AttributeRoute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Routing.AttributeRoute.AttributeRoute(Microsoft.AspNet.Routing.IRouter, Microsoft.AspNet.Mvc.Infrastructure.IActionDescriptorsCollectionProvider, Microsoft.AspNet.Routing.IInlineConstraintResolver, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
        
        
        :type target: Microsoft.AspNet.Routing.IRouter
        
        
        :type actionDescriptorsCollectionProvider: Microsoft.AspNet.Mvc.Infrastructure.IActionDescriptorsCollectionProvider
        
        
        :type constraintResolver: Microsoft.AspNet.Routing.IInlineConstraintResolver
        
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
           public AttributeRoute(IRouter target, IActionDescriptorsCollectionProvider actionDescriptorsCollectionProvider, IInlineConstraintResolver constraintResolver, ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Routing.AttributeRoute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Routing.AttributeRoute.GetVirtualPath(Microsoft.AspNet.Routing.VirtualPathContext)
    
        
        
        
        :type context: Microsoft.AspNet.Routing.VirtualPathContext
        :rtype: Microsoft.AspNet.Routing.VirtualPathData
    
        
        .. code-block:: csharp
    
           public VirtualPathData GetVirtualPath(VirtualPathContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Routing.AttributeRoute.RouteAsync(Microsoft.AspNet.Routing.RouteContext)
    
        
        
        
        :type context: Microsoft.AspNet.Routing.RouteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task RouteAsync(RouteContext context)
    

