

IHttpWebSocketFeature Interface
===============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IHttpWebSocketFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Features/IHttpWebSocketFeature.cs>`_





.. dn:interface:: Microsoft.AspNet.Http.Features.IHttpWebSocketFeature

Methods
-------

.. dn:interface:: Microsoft.AspNet.Http.Features.IHttpWebSocketFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Features.IHttpWebSocketFeature.AcceptAsync(Microsoft.AspNet.Http.Features.WebSocketAcceptContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.Features.WebSocketAcceptContext
        :rtype: System.Threading.Tasks.Task{System.Net.WebSockets.WebSocket}
    
        
        .. code-block:: csharp
    
           Task<WebSocket> AcceptAsync(WebSocketAcceptContext context)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Http.Features.IHttpWebSocketFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.IHttpWebSocketFeature.IsWebSocketRequest
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IsWebSocketRequest { get; }
    

