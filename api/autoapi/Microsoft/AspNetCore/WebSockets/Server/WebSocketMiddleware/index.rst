

WebSocketMiddleware Class
=========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.WebSockets.Server`
Assemblies
    * Microsoft.AspNetCore.WebSockets.Server

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.WebSockets.Server.WebSocketMiddleware`








Syntax
------

.. code-block:: csharp

    public class WebSocketMiddleware








.. dn:class:: Microsoft.AspNetCore.WebSockets.Server.WebSocketMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.WebSockets.Server.WebSocketMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.WebSockets.Server.WebSocketMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.WebSockets.Server.WebSocketMiddleware.WebSocketMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.WebSocketOptions>)
    
        
    
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.WebSocketOptions<Microsoft.AspNetCore.Builder.WebSocketOptions>}
    
        
        .. code-block:: csharp
    
            public WebSocketMiddleware(RequestDelegate next, IOptions<WebSocketOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.WebSockets.Server.WebSocketMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.WebSockets.Server.WebSocketMiddleware.Invoke(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task Invoke(HttpContext context)
    

