

DefaultWebSocketManager Class
=============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.WebSocketManager`
* :dn:cls:`Microsoft.AspNet.Http.Internal.DefaultWebSocketManager`








Syntax
------

.. code-block:: csharp

   public class DefaultWebSocketManager : WebSocketManager, IFeatureCache





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http/DefaultWebSocketManager.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Internal.DefaultWebSocketManager

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Internal.DefaultWebSocketManager
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Internal.DefaultWebSocketManager.DefaultWebSocketManager(Microsoft.AspNet.Http.Features.IFeatureCollection)
    
        
        
        
        :type features: Microsoft.AspNet.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
           public DefaultWebSocketManager(IFeatureCollection features)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Internal.DefaultWebSocketManager
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Internal.DefaultWebSocketManager.AcceptWebSocketAsync(System.String)
    
        
        
        
        :type subProtocol: System.String
        :rtype: System.Threading.Tasks.Task{System.Net.WebSockets.WebSocket}
    
        
        .. code-block:: csharp
    
           public override Task<WebSocket> AcceptWebSocketAsync(string subProtocol)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Internal.DefaultWebSocketManager
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultWebSocketManager.IsWebSocketRequest
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool IsWebSocketRequest { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultWebSocketManager.WebSocketRequestedProtocols
    
        
        :rtype: System.Collections.Generic.IList{System.String}
    
        
        .. code-block:: csharp
    
           public override IList<string> WebSocketRequestedProtocols { get; }
    

