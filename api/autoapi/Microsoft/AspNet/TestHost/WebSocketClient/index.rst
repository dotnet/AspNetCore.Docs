

WebSocketClient Class
=====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.TestHost.WebSocketClient`








Syntax
------

.. code-block:: csharp

   public class WebSocketClient





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/hosting/src/Microsoft.AspNet.TestHost/WebSocketClient.cs>`_





.. dn:class:: Microsoft.AspNet.TestHost.WebSocketClient

Methods
-------

.. dn:class:: Microsoft.AspNet.TestHost.WebSocketClient
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.TestHost.WebSocketClient.ConnectAsync(System.Uri, System.Threading.CancellationToken)
    
        
        
        
        :type uri: System.Uri
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Net.WebSockets.WebSocket}
    
        
        .. code-block:: csharp
    
           public Task<WebSocket> ConnectAsync(Uri uri, CancellationToken cancellationToken)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.TestHost.WebSocketClient
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.TestHost.WebSocketClient.ConfigureRequest
    
        
        :rtype: System.Action{Microsoft.AspNet.Http.HttpRequest}
    
        
        .. code-block:: csharp
    
           public Action<HttpRequest> ConfigureRequest { get; set; }
    
    .. dn:property:: Microsoft.AspNet.TestHost.WebSocketClient.SubProtocols
    
        
        :rtype: System.Collections.Generic.IList{System.String}
    
        
        .. code-block:: csharp
    
           public IList<string> SubProtocols { get; }
    

