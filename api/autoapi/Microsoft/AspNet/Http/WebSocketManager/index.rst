

WebSocketManager Class
======================



.. contents:: 
   :local:



Summary
-------

Manages the establishment of WebSocket connections for a specific HTTP request.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.WebSocketManager`








Syntax
------

.. code-block:: csharp

   public abstract class WebSocketManager





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Abstractions/WebSocketManager.cs>`_





.. dn:class:: Microsoft.AspNet.Http.WebSocketManager

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.WebSocketManager
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.WebSocketManager.AcceptWebSocketAsync()
    
        
    
        Transitions the request to a WebSocket connection.
    
        
        :rtype: System.Threading.Tasks.Task{System.Net.WebSockets.WebSocket}
        :return: A task representing the completion of the transition.
    
        
        .. code-block:: csharp
    
           public virtual Task<WebSocket> AcceptWebSocketAsync()
    
    .. dn:method:: Microsoft.AspNet.Http.WebSocketManager.AcceptWebSocketAsync(System.String)
    
        
    
        Transitions the request to a WebSocket connection using the specified sub-protocol.
    
        
        
        
        :param subProtocol: The sub-protocol to use.
        
        :type subProtocol: System.String
        :rtype: System.Threading.Tasks.Task{System.Net.WebSockets.WebSocket}
        :return: A task representing the completion of the transition.
    
        
        .. code-block:: csharp
    
           public abstract Task<WebSocket> AcceptWebSocketAsync(string subProtocol)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.WebSocketManager
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.WebSocketManager.IsWebSocketRequest
    
        
    
        Gets a value indicating whether the request is a WebSocket establishment request.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public abstract bool IsWebSocketRequest { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.WebSocketManager.WebSocketRequestedProtocols
    
        
    
        Gets the list of requested WebSocket sub-protocols.
    
        
        :rtype: System.Collections.Generic.IList{System.String}
    
        
        .. code-block:: csharp
    
           public abstract IList<string> WebSocketRequestedProtocols { get; }
    

