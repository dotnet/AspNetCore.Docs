

IRouteHandler Interface
=======================






Defines a contract for a handler of a route. 


Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing`
Assemblies
    * Microsoft.AspNetCore.Routing.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IRouteHandler








.. dn:interface:: Microsoft.AspNetCore.Routing.IRouteHandler
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Routing.IRouteHandler

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Routing.IRouteHandler
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.IRouteHandler.GetRequestHandler(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Routing.RouteData)
    
        
    
        
        Gets a :any:`Microsoft.AspNetCore.Http.RequestDelegate` to handle the request, based on the provided
        <em>routeData</em>.
    
        
    
        
        :param httpContext: The :any:`Microsoft.AspNetCore.Http.HttpContext` associated with the current request.
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param routeData: The :any:`Microsoft.AspNetCore.Routing.RouteData` associated with the current routing match.
        
        :type routeData: Microsoft.AspNetCore.Routing.RouteData
        :rtype: Microsoft.AspNetCore.Http.RequestDelegate
        :return: 
            A :any:`Microsoft.AspNetCore.Http.RequestDelegate`\, or <code>null</code> if the handler cannot handle this request.
    
        
        .. code-block:: csharp
    
            RequestDelegate GetRequestHandler(HttpContext httpContext, RouteData routeData)
    

