

TcpListenerPrimary Class
========================






An implementation of :any:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ListenerPrimary` using TCP sockets.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.ServiceContext`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ListenerContext`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http.Listener`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ListenerPrimary`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http.TcpListenerPrimary`








Syntax
------

.. code-block:: csharp

    public class TcpListenerPrimary : ListenerPrimary, IAsyncDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.TcpListenerPrimary
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.TcpListenerPrimary

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.TcpListenerPrimary
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.TcpListenerPrimary.TcpListenerPrimary(Microsoft.AspNetCore.Server.Kestrel.Internal.ServiceContext)
    
        
    
        
        :type serviceContext: Microsoft.AspNetCore.Server.Kestrel.Internal.ServiceContext
    
        
        .. code-block:: csharp
    
            public TcpListenerPrimary(ServiceContext serviceContext)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.TcpListenerPrimary
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.TcpListenerPrimary.CreateListenSocket()
    
        
    
        
        Creates the socket used to listen for incoming connections
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvStreamHandle
    
        
        .. code-block:: csharp
    
            protected override UvStreamHandle CreateListenSocket()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.TcpListenerPrimary.OnConnection(Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvStreamHandle, System.Int32)
    
        
    
        
        Handles an incoming connection
    
        
    
        
        :param listenSocket: Socket being used to listen on
        
        :type listenSocket: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvStreamHandle
    
        
        :param status: Connection status
        
        :type status: System.Int32
    
        
        .. code-block:: csharp
    
            protected override void OnConnection(UvStreamHandle listenSocket, int status)
    

