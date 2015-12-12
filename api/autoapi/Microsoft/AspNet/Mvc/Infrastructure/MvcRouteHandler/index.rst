

MvcRouteHandler Class
=====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Infrastructure.MvcRouteHandler`








Syntax
------

.. code-block:: csharp

   public class MvcRouteHandler : IRouter





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Infrastructure/MvcRouteHandler.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.MvcRouteHandler

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.MvcRouteHandler
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Infrastructure.MvcRouteHandler.GetVirtualPath(Microsoft.AspNet.Routing.VirtualPathContext)
    
        
        
        
        :type context: Microsoft.AspNet.Routing.VirtualPathContext
        :rtype: Microsoft.AspNet.Routing.VirtualPathData
    
        
        .. code-block:: csharp
    
           public VirtualPathData GetVirtualPath(VirtualPathContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Infrastructure.MvcRouteHandler.RouteAsync(Microsoft.AspNet.Routing.RouteContext)
    
        
        
        
        :type context: Microsoft.AspNet.Routing.RouteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task RouteAsync(RouteContext context)
    

