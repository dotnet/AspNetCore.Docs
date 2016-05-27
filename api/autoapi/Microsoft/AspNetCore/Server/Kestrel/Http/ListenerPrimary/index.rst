

ListenerPrimary Class
=====================






A primary listener waits for incoming connections on a specified socket. Incoming 
connections may be passed to a secondary listener to handle.


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








Syntax
------

.. code-block:: csharp

    public abstract class ListenerPrimary : Listener, IAsyncDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerPrimary
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerPrimary

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerPrimary
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerPrimary.ListenerPrimary(Microsoft.AspNetCore.Server.Kestrel.ServiceContext)
    
        
    
        
        :type serviceContext: Microsoft.AspNetCore.Server.Kestrel.ServiceContext
    
        
        .. code-block:: csharp
    
            protected ListenerPrimary(ServiceContext serviceContext)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerPrimary
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerPrimary.DispatchConnection(Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle)
    
        
    
        
        :type socket: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle
    
        
        .. code-block:: csharp
    
            protected override void DispatchConnection(UvStreamHandle socket)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerPrimary.DisposeAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task DisposeAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerPrimary.StartAsync(System.String, Microsoft.AspNetCore.Server.Kestrel.ServerAddress, Microsoft.AspNetCore.Server.Kestrel.KestrelThread)
    
        
    
        
        :type pipeName: System.String
    
        
        :type address: Microsoft.AspNetCore.Server.Kestrel.ServerAddress
    
        
        :type thread: Microsoft.AspNetCore.Server.Kestrel.KestrelThread
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task StartAsync(string pipeName, ServerAddress address, KestrelThread thread)
    

