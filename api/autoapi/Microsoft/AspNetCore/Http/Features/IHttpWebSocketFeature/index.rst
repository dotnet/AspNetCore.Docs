

IHttpWebSocketFeature Interface
===============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Features`
Assemblies
    * Microsoft.AspNetCore.Http.Features

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IHttpWebSocketFeature








.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpWebSocketFeature
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpWebSocketFeature

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpWebSocketFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IHttpWebSocketFeature.IsWebSocketRequest
    
        
    
        
        Indicates if this is a WebSocket upgrade request.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool IsWebSocketRequest
            {
                get;
            }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpWebSocketFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Features.IHttpWebSocketFeature.AcceptAsync(Microsoft.AspNetCore.Http.WebSocketAcceptContext)
    
        
    
        
        Attempts to upgrade the request to a :any:`System.Net.WebSockets.WebSocket`\. Check :dn:prop:`Microsoft.AspNetCore.Http.Features.IHttpWebSocketFeature.IsWebSocketRequest`
        before invoking this.
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.WebSocketAcceptContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Net.WebSockets.WebSocket<System.Net.WebSockets.WebSocket>}
    
        
        .. code-block:: csharp
    
            Task<WebSocket> AcceptAsync(WebSocketAcceptContext context)
    

