

DefaultWebSocketManager Class
=============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Internal`
Assemblies
    * Microsoft.AspNetCore.Http

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.WebSocketManager`
* :dn:cls:`Microsoft.AspNetCore.Http.Internal.DefaultWebSocketManager`








Syntax
------

.. code-block:: csharp

    public class DefaultWebSocketManager : WebSocketManager








.. dn:class:: Microsoft.AspNetCore.Http.Internal.DefaultWebSocketManager
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Internal.DefaultWebSocketManager

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.DefaultWebSocketManager
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Internal.DefaultWebSocketManager.DefaultWebSocketManager(Microsoft.AspNetCore.Http.Features.IFeatureCollection)
    
        
    
        
        :type features: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
            public DefaultWebSocketManager(IFeatureCollection features)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.DefaultWebSocketManager
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.DefaultWebSocketManager.AcceptWebSocketAsync(System.String)
    
        
    
        
        :type subProtocol: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Net.WebSockets.WebSocket<System.Net.WebSockets.WebSocket>}
    
        
        .. code-block:: csharp
    
            public override Task<WebSocket> AcceptWebSocketAsync(string subProtocol)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.DefaultWebSocketManager.Initialize(Microsoft.AspNetCore.Http.Features.IFeatureCollection)
    
        
    
        
        :type features: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
            public virtual void Initialize(IFeatureCollection features)
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.DefaultWebSocketManager.Uninitialize()
    
        
    
        
        .. code-block:: csharp
    
            public virtual void Uninitialize()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Internal.DefaultWebSocketManager
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultWebSocketManager.IsWebSocketRequest
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool IsWebSocketRequest { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.DefaultWebSocketManager.WebSocketRequestedProtocols
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public override IList<string> WebSocketRequestedProtocols { get; }
    

