

ListenerContext Class
=====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.ServiceContext`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.ListenerContext`








Syntax
------

.. code-block:: csharp

   public class ListenerContext : ServiceContext





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Http/ListenerContext.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.ListenerContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.ListenerContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Http.ListenerContext.ListenerContext()
    
        
    
        
        .. code-block:: csharp
    
           public ListenerContext()
    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Http.ListenerContext.ListenerContext(Microsoft.AspNet.Server.Kestrel.Http.ListenerContext)
    
        
        
        
        :type listenerContext: Microsoft.AspNet.Server.Kestrel.Http.ListenerContext
    
        
        .. code-block:: csharp
    
           public ListenerContext(ListenerContext listenerContext)
    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Http.ListenerContext.ListenerContext(Microsoft.AspNet.Server.Kestrel.ServiceContext)
    
        
        
        
        :type serviceContext: Microsoft.AspNet.Server.Kestrel.ServiceContext
    
        
        .. code-block:: csharp
    
           public ListenerContext(ServiceContext serviceContext)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.ListenerContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.ListenerContext.Application
    
        
        :rtype: System.Func{Microsoft.AspNet.Server.Kestrel.Http.Frame,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<Frame, Task> Application { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.ListenerContext.Memory2
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPool2
    
        
        .. code-block:: csharp
    
           public MemoryPool2 Memory2 { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.ListenerContext.ServerAddress
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.ServerAddress
    
        
        .. code-block:: csharp
    
           public ServerAddress ServerAddress { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.ListenerContext.Thread
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.KestrelThread
    
        
        .. code-block:: csharp
    
           public KestrelThread Thread { get; set; }
    

