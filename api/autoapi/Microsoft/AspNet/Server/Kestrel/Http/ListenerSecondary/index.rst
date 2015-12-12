

ListenerSecondary Class
=======================



.. contents:: 
   :local:



Summary
-------

A secondary listener is delegated requests from a primary listener via a named pipe or
UNIX domain socket.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.ServiceContext`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.ListenerContext`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.ListenerSecondary`








Syntax
------

.. code-block:: csharp

   public abstract class ListenerSecondary : ListenerContext, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Http/ListenerSecondary.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.ListenerSecondary

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.ListenerSecondary
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Http.ListenerSecondary.ListenerSecondary(Microsoft.AspNet.Server.Kestrel.ServiceContext)
    
        
        
        
        :type serviceContext: Microsoft.AspNet.Server.Kestrel.ServiceContext
    
        
        .. code-block:: csharp
    
           protected ListenerSecondary(ServiceContext serviceContext)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.ListenerSecondary
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.ListenerSecondary.CreateAcceptSocket()
    
        
    
        Creates a socket which can be used to accept an incoming connection
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
    
        
        .. code-block:: csharp
    
           protected abstract UvStreamHandle CreateAcceptSocket()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.ListenerSecondary.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.ListenerSecondary.StartAsync(System.String, Microsoft.AspNet.Server.Kestrel.ServerAddress, Microsoft.AspNet.Server.Kestrel.KestrelThread, System.Func<Microsoft.AspNet.Server.Kestrel.Http.Frame, System.Threading.Tasks.Task>)
    
        
        
        
        :type pipeName: System.String
        
        
        :type address: Microsoft.AspNet.Server.Kestrel.ServerAddress
        
        
        :type thread: Microsoft.AspNet.Server.Kestrel.KestrelThread
        
        
        :type application: System.Func{Microsoft.AspNet.Server.Kestrel.Http.Frame,System.Threading.Tasks.Task}
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task StartAsync(string pipeName, ServerAddress address, KestrelThread thread, Func<Frame, Task> application)
    

