

RouterMiddleware Class
======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.RouterMiddleware`








Syntax
------

.. code-block:: csharp

    public class RouterMiddleware








.. dn:class:: Microsoft.AspNetCore.Builder.RouterMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.RouterMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Builder.RouterMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Builder.RouterMiddleware.RouterMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.AspNetCore.Routing.IRouter)
    
        
    
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type router: Microsoft.AspNetCore.Routing.IRouter
    
        
        .. code-block:: csharp
    
            public RouterMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, IRouter router)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.RouterMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.RouterMiddleware.Invoke(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task Invoke(HttpContext httpContext)
    

