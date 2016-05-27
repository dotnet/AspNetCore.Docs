

TcpListener Class
=================






Implementation of :any:`Microsoft.AspNetCore.Server.Kestrel.Http.Listener` that uses TCP sockets as its transport.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Http`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.ServiceContext`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.ListenerContext`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.Listener`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.TcpListener`








Syntax
------

.. code-block:: csharp

    public class TcpListener : Listener, IAsyncDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.TcpListener
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.TcpListener

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.TcpListener
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Http.TcpListener.TcpListener(Microsoft.AspNetCore.Server.Kestrel.ServiceContext)
    
        
    
        
        :type serviceContext: Microsoft.AspNetCore.Server.Kestrel.ServiceContext
    
        
        .. code-block:: csharp
    
            public TcpListener(ServiceContext serviceContext)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.TcpListener
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.TcpListener.CreateListenSocket()
    
        
    
        
        Creates the socket used to listen for incoming connections
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle
    
        
        .. code-block:: csharp
    
            protected override UvStreamHandle CreateListenSocket()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.TcpListener.OnConnection(Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle, System.Int32)
    
        
    
        
        Handle an incoming connection
    
        
    
        
        :param listenSocket: Socket being used to listen on
        
        :type listenSocket: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle
    
        
        :param status: Connection status
        
        :type status: System.Int32
    
        
        .. code-block:: csharp
    
            protected override void OnConnection(UvStreamHandle listenSocket, int status)
    

