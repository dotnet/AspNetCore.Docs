

RouteHandler Class
==================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Routing.RouteHandler`








Syntax
------

.. code-block:: csharp

    public class RouteHandler : IRouteHandler, IRouter








.. dn:class:: Microsoft.AspNetCore.Routing.RouteHandler
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.RouteHandler

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.RouteHandler
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.RouteHandler.RouteHandler(Microsoft.AspNetCore.Http.RequestDelegate)
    
        
    
        
        :type requestDelegate: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        .. code-block:: csharp
    
            public RouteHandler(RequestDelegate requestDelegate)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.RouteHandler
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.RouteHandler.GetRequestHandler(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Routing.RouteData)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type routeData: Microsoft.AspNetCore.Routing.RouteData
        :rtype: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        .. code-block:: csharp
    
            public RequestDelegate GetRequestHandler(HttpContext httpContext, RouteData routeData)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RouteHandler.GetVirtualPath(Microsoft.AspNetCore.Routing.VirtualPathContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Routing.VirtualPathContext
        :rtype: Microsoft.AspNetCore.Routing.VirtualPathData
    
        
        .. code-block:: csharp
    
            public VirtualPathData GetVirtualPath(VirtualPathContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RouteHandler.RouteAsync(Microsoft.AspNetCore.Routing.RouteContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Routing.RouteContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task RouteAsync(RouteContext context)
    

