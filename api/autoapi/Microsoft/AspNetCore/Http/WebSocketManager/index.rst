

WebSocketManager Class
======================






Manages the establishment of WebSocket connections for a specific HTTP request. 


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http`
Assemblies
    * Microsoft.AspNetCore.Http.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.WebSocketManager`








Syntax
------

.. code-block:: csharp

    public abstract class WebSocketManager








.. dn:class:: Microsoft.AspNetCore.Http.WebSocketManager
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.WebSocketManager

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.WebSocketManager
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.WebSocketManager.IsWebSocketRequest
    
        
    
        
        Gets a value indicating whether the request is a WebSocket establishment request.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public abstract bool IsWebSocketRequest
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.WebSocketManager.WebSocketRequestedProtocols
    
        
    
        
        Gets the list of requested WebSocket sub-protocols.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public abstract IList<string> WebSocketRequestedProtocols
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.WebSocketManager
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.WebSocketManager.AcceptWebSocketAsync()
    
        
    
        
        Transitions the request to a WebSocket connection.
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Net.WebSockets.WebSocket<System.Net.WebSockets.WebSocket>}
        :return: A task representing the completion of the transition.
    
        
        .. code-block:: csharp
    
            public virtual Task<WebSocket> AcceptWebSocketAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Http.WebSocketManager.AcceptWebSocketAsync(System.String)
    
        
    
        
        Transitions the request to a WebSocket connection using the specified sub-protocol.
    
        
    
        
        :param subProtocol: The sub-protocol to use.
        
        :type subProtocol: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Net.WebSockets.WebSocket<System.Net.WebSockets.WebSocket>}
        :return: A task representing the completion of the transition.
    
        
        .. code-block:: csharp
    
            public abstract Task<WebSocket> AcceptWebSocketAsync(string subProtocol)
    

