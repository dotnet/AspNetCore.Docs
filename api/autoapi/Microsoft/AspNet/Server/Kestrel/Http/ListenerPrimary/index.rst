

ListenerPrimary Class
=====================



.. contents:: 
   :local:



Summary
-------

A primary listener waits for incoming connections on a specified socket. Incoming
connections may be passed to a secondary listener to handle.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.ServiceContext`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.ListenerContext`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.Listener`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.ListenerPrimary`








Syntax
------

.. code-block:: csharp

   public abstract class ListenerPrimary : Listener, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel/Http/ListenerPrimary.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.ListenerPrimary

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.ListenerPrimary
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Http.ListenerPrimary.ListenerPrimary(Microsoft.AspNet.Server.Kestrel.ServiceContext)
    
        
        
        
        :type serviceContext: Microsoft.AspNet.Server.Kestrel.ServiceContext
    
        
        .. code-block:: csharp
    
           protected ListenerPrimary(ServiceContext serviceContext)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.ListenerPrimary
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.ListenerPrimary.DispatchConnection(Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle)
    
        
        
        
        :type socket: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
    
        
        .. code-block:: csharp
    
           protected override void DispatchConnection(UvStreamHandle socket)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.ListenerPrimary.StartAsync(System.String, Microsoft.AspNet.Server.Kestrel.ServerAddress, Microsoft.AspNet.Server.Kestrel.KestrelThread, System.Func<Microsoft.AspNet.Server.Kestrel.Http.Frame, System.Threading.Tasks.Task>)
    
        
        
        
        :type pipeName: System.String
        
        
        :type address: Microsoft.AspNet.Server.Kestrel.ServerAddress
        
        
        :type thread: Microsoft.AspNet.Server.Kestrel.KestrelThread
        
        
        :type application: System.Func{Microsoft.AspNet.Server.Kestrel.Http.Frame,System.Threading.Tasks.Task}
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task StartAsync(string pipeName, ServerAddress address, KestrelThread thread, Func<Frame, Task> application)
    

