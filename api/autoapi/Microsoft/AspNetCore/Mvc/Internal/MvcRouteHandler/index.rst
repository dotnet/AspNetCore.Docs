

MvcRouteHandler Class
=====================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.MvcRouteHandler`








Syntax
------

.. code-block:: csharp

    public class MvcRouteHandler : IRouter








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcRouteHandler
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcRouteHandler

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcRouteHandler
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcRouteHandler.GetVirtualPath(Microsoft.AspNetCore.Routing.VirtualPathContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Routing.VirtualPathContext
        :rtype: Microsoft.AspNetCore.Routing.VirtualPathData
    
        
        .. code-block:: csharp
    
            public VirtualPathData GetVirtualPath(VirtualPathContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcRouteHandler.RouteAsync(Microsoft.AspNetCore.Routing.RouteContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Routing.RouteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task RouteAsync(RouteContext context)
    

