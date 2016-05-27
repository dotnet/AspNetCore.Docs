

WebSocketClient Class
=====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.WebSockets.Client`
Assemblies
    * Microsoft.AspNetCore.WebSockets.Client

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.WebSockets.Client.WebSocketClient`








Syntax
------

.. code-block:: csharp

    public class WebSocketClient








.. dn:class:: Microsoft.AspNetCore.WebSockets.Client.WebSocketClient
    :hidden:

.. dn:class:: Microsoft.AspNetCore.WebSockets.Client.WebSocketClient

Properties
----------

.. dn:class:: Microsoft.AspNetCore.WebSockets.Client.WebSocketClient
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.WebSockets.Client.WebSocketClient.ConfigureRequest
    
        
        :rtype: System.Action<System.Action`1>{System.Net.HttpWebRequest<System.Net.HttpWebRequest>}
    
        
        .. code-block:: csharp
    
            public Action<HttpWebRequest> ConfigureRequest
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.WebSockets.Client.WebSocketClient.InspectResponse
    
        
        :rtype: System.Action<System.Action`1>{System.Net.HttpWebResponse<System.Net.HttpWebResponse>}
    
        
        .. code-block:: csharp
    
            public Action<HttpWebResponse> InspectResponse
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.WebSockets.Client.WebSocketClient.KeepAliveInterval
    
        
        :rtype: System.TimeSpan
    
        
        .. code-block:: csharp
    
            public TimeSpan KeepAliveInterval
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.WebSockets.Client.WebSocketClient.ReceiveBufferSize
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int ReceiveBufferSize
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.WebSockets.Client.WebSocketClient.SubProtocols
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IList<string> SubProtocols
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.WebSockets.Client.WebSocketClient.UseZeroMask
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool UseZeroMask
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.WebSockets.Client.WebSocketClient
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.WebSockets.Client.WebSocketClient.WebSocketClient()
    
        
    
        
        .. code-block:: csharp
    
            public WebSocketClient()
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.WebSockets.Client.WebSocketClient
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.WebSockets.Client.WebSocketClient.ConnectAsync(System.Uri, System.Threading.CancellationToken)
    
        
    
        
        :type uri: System.Uri
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Net.WebSockets.WebSocket<System.Net.WebSockets.WebSocket>}
    
        
        .. code-block:: csharp
    
            public Task<WebSocket> ConnectAsync(Uri uri, CancellationToken cancellationToken)
    

