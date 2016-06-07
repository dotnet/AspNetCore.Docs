

ExtendedWebSocketAcceptContext Class
====================================





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
* :dn:cls:`Microsoft.AspNetCore.Http.WebSocketAcceptContext`
* :dn:cls:`Microsoft.AspNetCore.WebSockets.Server.ExtendedWebSocketAcceptContext`








Syntax
------

.. code-block:: csharp

    public class ExtendedWebSocketAcceptContext : WebSocketAcceptContext








.. dn:class:: Microsoft.AspNetCore.WebSockets.Server.ExtendedWebSocketAcceptContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.WebSockets.Server.ExtendedWebSocketAcceptContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.WebSockets.Server.ExtendedWebSocketAcceptContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.WebSockets.Server.ExtendedWebSocketAcceptContext.KeepAliveInterval
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.TimeSpan<System.TimeSpan>}
    
        
        .. code-block:: csharp
    
            public TimeSpan? KeepAliveInterval
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.WebSockets.Server.ExtendedWebSocketAcceptContext.ReceiveBufferSize
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            public int ? ReceiveBufferSize
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.WebSockets.Server.ExtendedWebSocketAcceptContext.SubProtocol
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string SubProtocol
            {
                get;
                set;
            }
    

