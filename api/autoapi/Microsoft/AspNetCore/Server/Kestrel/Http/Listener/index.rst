

Listener Class
==============






Base class for listeners in Kestrel. Listens for incoming connections


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








Syntax
------

.. code-block:: csharp

    public abstract class Listener : ListenerContext, IAsyncDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.Listener
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.Listener

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.Listener
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.Listener.ListenSocket
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle
    
        
        .. code-block:: csharp
    
            protected UvStreamHandle ListenSocket
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.Listener
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Http.Listener.Listener(Microsoft.AspNetCore.Server.Kestrel.ServiceContext)
    
        
    
        
        :type serviceContext: Microsoft.AspNetCore.Server.Kestrel.ServiceContext
    
        
        .. code-block:: csharp
    
            protected Listener(ServiceContext serviceContext)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.Listener
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Listener.ConnectionCallback(Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle, System.Int32, System.Exception, System.Object)
    
        
    
        
        :type stream: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle
    
        
        :type status: System.Int32
    
        
        :type error: System.Exception
    
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
            protected static void ConnectionCallback(UvStreamHandle stream, int status, Exception error, object state)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Listener.CreateListenSocket()
    
        
    
        
        Creates the socket used to listen for incoming connections
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle
    
        
        .. code-block:: csharp
    
            protected abstract UvStreamHandle CreateListenSocket()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Listener.DispatchConnection(Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle)
    
        
    
        
        :type socket: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle
    
        
        .. code-block:: csharp
    
            protected virtual void DispatchConnection(UvStreamHandle socket)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Listener.DisposeAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task DisposeAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Listener.OnConnection(Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle, System.Int32)
    
        
    
        
        Handles an incoming connection
    
        
    
        
        :param listenSocket: Socket being used to listen on
        
        :type listenSocket: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle
    
        
        :param status: Connection status
        
        :type status: System.Int32
    
        
        .. code-block:: csharp
    
            protected abstract void OnConnection(UvStreamHandle listenSocket, int status)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Listener.StartAsync(Microsoft.AspNetCore.Server.Kestrel.ServerAddress, Microsoft.AspNetCore.Server.Kestrel.KestrelThread)
    
        
    
        
        :type address: Microsoft.AspNetCore.Server.Kestrel.ServerAddress
    
        
        :type thread: Microsoft.AspNetCore.Server.Kestrel.KestrelThread
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task StartAsync(ServerAddress address, KestrelThread thread)
    

