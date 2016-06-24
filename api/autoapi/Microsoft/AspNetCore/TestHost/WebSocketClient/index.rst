

WebSocketClient Class
=====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.TestHost`
Assemblies
    * Microsoft.AspNetCore.TestHost

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.TestHost.WebSocketClient`








Syntax
------

.. code-block:: csharp

    public class WebSocketClient








.. dn:class:: Microsoft.AspNetCore.TestHost.WebSocketClient
    :hidden:

.. dn:class:: Microsoft.AspNetCore.TestHost.WebSocketClient

Properties
----------

.. dn:class:: Microsoft.AspNetCore.TestHost.WebSocketClient
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.TestHost.WebSocketClient.ConfigureRequest
    
        
        :rtype: System.Action<System.Action`1>{Microsoft.AspNetCore.Http.HttpRequest<Microsoft.AspNetCore.Http.HttpRequest>}
    
        
        .. code-block:: csharp
    
            public Action<HttpRequest> ConfigureRequest { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.TestHost.WebSocketClient.SubProtocols
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IList<string> SubProtocols { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.TestHost.WebSocketClient
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.TestHost.WebSocketClient.ConnectAsync(System.Uri, System.Threading.CancellationToken)
    
        
    
        
        :type uri: System.Uri
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Net.WebSockets.WebSocket<System.Net.WebSockets.WebSocket>}
    
        
        .. code-block:: csharp
    
            public Task<WebSocket> ConnectAsync(Uri uri, CancellationToken cancellationToken)
    

