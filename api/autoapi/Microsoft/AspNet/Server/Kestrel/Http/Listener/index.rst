

Listener Class
==============



.. contents:: 
   :local:



Summary
-------

Base class for listeners in Kestrel. Listens for incoming connections





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.ServiceContext`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.ListenerContext`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.Listener`








Syntax
------

.. code-block:: csharp

   public abstract class Listener : ListenerContext, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Http/Listener.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.Listener

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.Listener
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Http.Listener.Listener(Microsoft.AspNet.Server.Kestrel.ServiceContext)
    
        
        
        
        :type serviceContext: Microsoft.AspNet.Server.Kestrel.ServiceContext
    
        
        .. code-block:: csharp
    
           protected Listener(ServiceContext serviceContext)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.Listener
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Listener.ConnectionCallback(Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle, System.Int32, System.Exception, System.Object)
    
        
        
        
        :type stream: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
        
        
        :type status: System.Int32
        
        
        :type error: System.Exception
        
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
           protected static void ConnectionCallback(UvStreamHandle stream, int status, Exception error, object state)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Listener.CreateListenSocket()
    
        
    
        Creates the socket used to listen for incoming connections
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
    
        
        .. code-block:: csharp
    
           protected abstract UvStreamHandle CreateListenSocket()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Listener.DispatchConnection(Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle)
    
        
        
        
        :type socket: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
    
        
        .. code-block:: csharp
    
           protected virtual void DispatchConnection(UvStreamHandle socket)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Listener.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Listener.OnConnection(Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle, System.Int32)
    
        
    
        Handles an incoming connection
    
        
        
        
        :param listenSocket: Socket being used to listen on
        
        :type listenSocket: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
        
        
        :param status: Connection status
        
        :type status: System.Int32
    
        
        .. code-block:: csharp
    
           protected abstract void OnConnection(UvStreamHandle listenSocket, int status)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.Listener.StartAsync(Microsoft.AspNet.Server.Kestrel.ServerAddress, Microsoft.AspNet.Server.Kestrel.KestrelThread, System.Func<Microsoft.AspNet.Server.Kestrel.Http.Frame, System.Threading.Tasks.Task>)
    
        
        
        
        :type address: Microsoft.AspNet.Server.Kestrel.ServerAddress
        
        
        :type thread: Microsoft.AspNet.Server.Kestrel.KestrelThread
        
        
        :type application: System.Func{Microsoft.AspNet.Server.Kestrel.Http.Frame,System.Threading.Tasks.Task}
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task StartAsync(ServerAddress address, KestrelThread thread, Func<Frame, Task> application)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.Listener
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.Listener.ListenSocket
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
    
        
        .. code-block:: csharp
    
           protected UvStreamHandle ListenSocket { get; }
    

