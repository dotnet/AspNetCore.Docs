

WebSocketOptions Class
======================






Configuration options for the WebSocketMiddleware


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.WebSockets.Server

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.WebSocketOptions`








Syntax
------

.. code-block:: csharp

    public class WebSocketOptions








.. dn:class:: Microsoft.AspNetCore.Builder.WebSocketOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.WebSocketOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.WebSocketOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.WebSocketOptions.KeepAliveInterval
    
        
    
        
        Gets or sets the frequency at which to send Ping/Pong keep-alive control frames.
        The default is two minutes.
    
        
        :rtype: System.TimeSpan
    
        
        .. code-block:: csharp
    
            public TimeSpan KeepAliveInterval
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.WebSocketOptions.ReceiveBufferSize
    
        
    
        
        Gets or sets the size of the protocol buffer used to receive and parse frames.
        The default is 4kb.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int ReceiveBufferSize
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.WebSocketOptions.ReplaceFeature
    
        
    
        
        Gets or sets if the middleware should replace the WebSocket implementation provided by
        a component earlier in the stack. This is false by default.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ReplaceFeature
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Builder.WebSocketOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Builder.WebSocketOptions.WebSocketOptions()
    
        
    
        
        .. code-block:: csharp
    
            public WebSocketOptions()
    

