

ListenerSecondary Class
=======================






A secondary listener is delegated requests from a primary listener via a named pipe or 
UNIX domain socket.


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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.ListenerSecondary`








Syntax
------

.. code-block:: csharp

    public abstract class ListenerSecondary : ListenerContext, IAsyncDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerSecondary
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerSecondary

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerSecondary
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerSecondary.ListenerSecondary(Microsoft.AspNetCore.Server.Kestrel.ServiceContext)
    
        
    
        
        :type serviceContext: Microsoft.AspNetCore.Server.Kestrel.ServiceContext
    
        
        .. code-block:: csharp
    
            protected ListenerSecondary(ServiceContext serviceContext)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerSecondary
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerSecondary.CreateAcceptSocket()
    
        
    
        
        Creates a socket which can be used to accept an incoming connection
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle
    
        
        .. code-block:: csharp
    
            protected abstract UvStreamHandle CreateAcceptSocket()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerSecondary.DisposeAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task DisposeAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerSecondary.StartAsync(System.String, Microsoft.AspNetCore.Server.Kestrel.ServerAddress, Microsoft.AspNetCore.Server.Kestrel.KestrelThread)
    
        
    
        
        :type pipeName: System.String
    
        
        :type address: Microsoft.AspNetCore.Server.Kestrel.ServerAddress
    
        
        :type thread: Microsoft.AspNetCore.Server.Kestrel.KestrelThread
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task StartAsync(string pipeName, ServerAddress address, KestrelThread thread)
    

