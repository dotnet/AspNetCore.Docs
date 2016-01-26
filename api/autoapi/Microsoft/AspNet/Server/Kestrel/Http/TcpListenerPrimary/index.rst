

TcpListenerPrimary Class
========================



.. contents:: 
   :local:



Summary
-------

An implementation of :any:`Microsoft.AspNet.Server.Kestrel.Http.ListenerPrimary` using TCP sockets.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.ServiceContext`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.ListenerContext`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.Listener`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.ListenerPrimary`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.TcpListenerPrimary`








Syntax
------

.. code-block:: csharp

   public class TcpListenerPrimary : ListenerPrimary, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Http/TcpListenerPrimary.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.TcpListenerPrimary

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.TcpListenerPrimary
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Http.TcpListenerPrimary.TcpListenerPrimary(Microsoft.AspNet.Server.Kestrel.ServiceContext)
    
        
        
        
        :type serviceContext: Microsoft.AspNet.Server.Kestrel.ServiceContext
    
        
        .. code-block:: csharp
    
           public TcpListenerPrimary(ServiceContext serviceContext)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.TcpListenerPrimary
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.TcpListenerPrimary.CreateListenSocket()
    
        
    
        Creates the socket used to listen for incoming connections
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
    
        
        .. code-block:: csharp
    
           protected override UvStreamHandle CreateListenSocket()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.TcpListenerPrimary.OnConnection(Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle, System.Int32)
    
        
    
        Handles an incoming connection
    
        
        
        
        :param listenSocket: Socket being used to listen on
        
        :type listenSocket: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
        
        
        :param status: Connection status
        
        :type status: System.Int32
    
        
        .. code-block:: csharp
    
           protected override void OnConnection(UvStreamHandle listenSocket, int status)
    

