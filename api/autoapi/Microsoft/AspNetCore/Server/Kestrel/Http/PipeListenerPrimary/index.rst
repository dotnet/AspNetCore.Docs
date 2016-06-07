

PipeListenerPrimary Class
=========================






An implementation of :any:`Microsoft.AspNetCore.Server.Kestrel.Http.ListenerPrimary` using UNIX sockets.


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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.ListenerPrimary`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.PipeListenerPrimary`








Syntax
------

.. code-block:: csharp

    public class PipeListenerPrimary : ListenerPrimary, IAsyncDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.PipeListenerPrimary
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.PipeListenerPrimary

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.PipeListenerPrimary
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Http.PipeListenerPrimary.PipeListenerPrimary(Microsoft.AspNetCore.Server.Kestrel.ServiceContext)
    
        
    
        
        :type serviceContext: Microsoft.AspNetCore.Server.Kestrel.ServiceContext
    
        
        .. code-block:: csharp
    
            public PipeListenerPrimary(ServiceContext serviceContext)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.PipeListenerPrimary
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.PipeListenerPrimary.CreateListenSocket()
    
        
    
        
        Creates the socket used to listen for incoming connections
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle
    
        
        .. code-block:: csharp
    
            protected override UvStreamHandle CreateListenSocket()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.PipeListenerPrimary.OnConnection(Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle, System.Int32)
    
        
    
        
        Handles an incoming connection
    
        
    
        
        :param listenSocket: Socket being used to listen on
        
        :type listenSocket: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle
    
        
        :param status: Connection status
        
        :type status: System.Int32
    
        
        .. code-block:: csharp
    
            protected override void OnConnection(UvStreamHandle listenSocket, int status)
    

