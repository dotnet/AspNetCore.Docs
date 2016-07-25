

ListenerSecondary Class
=======================






A secondary listener is delegated requests from a primary listener via a named pipe or 
UNIX domain socket.


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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ListenerSecondary`








Syntax
------

.. code-block:: csharp

    public abstract class ListenerSecondary : ListenerContext, IAsyncDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ListenerSecondary
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ListenerSecondary

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ListenerSecondary
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ListenerSecondary.ListenerSecondary(Microsoft.AspNetCore.Server.Kestrel.Internal.ServiceContext)
    
        
    
        
        :type serviceContext: Microsoft.AspNetCore.Server.Kestrel.Internal.ServiceContext
    
        
        .. code-block:: csharp
    
            protected ListenerSecondary(ServiceContext serviceContext)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ListenerSecondary
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ListenerSecondary.CreateAcceptSocket()
    
        
    
        
        Creates a socket which can be used to accept an incoming connection
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvStreamHandle
    
        
        .. code-block:: csharp
    
            protected abstract UvStreamHandle CreateAcceptSocket()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ListenerSecondary.DisposeAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task DisposeAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ListenerSecondary.StartAsync(System.String, Microsoft.AspNetCore.Server.Kestrel.ServerAddress, Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelThread)
    
        
    
        
        :type pipeName: System.String
    
        
        :type address: Microsoft.AspNetCore.Server.Kestrel.ServerAddress
    
        
        :type thread: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelThread
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task StartAsync(string pipeName, ServerAddress address, KestrelThread thread)
    

