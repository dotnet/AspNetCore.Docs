

KestrelEngine Class
===================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.ServiceContext`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.KestrelEngine`








Syntax
------

.. code-block:: csharp

   public class KestrelEngine : ServiceContext, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel/KestrelEngine.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.KestrelEngine

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.KestrelEngine
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.KestrelEngine.KestrelEngine(Microsoft.AspNet.Server.Kestrel.ServiceContext)
    
        
        
        
        :type context: Microsoft.AspNet.Server.Kestrel.ServiceContext
    
        
        .. code-block:: csharp
    
           public KestrelEngine(ServiceContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.KestrelEngine
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelEngine.CreateServer(Microsoft.AspNet.Server.Kestrel.ServerAddress, System.Func<Microsoft.AspNet.Http.Features.IFeatureCollection, System.Threading.Tasks.Task>)
    
        
        
        
        :type address: Microsoft.AspNet.Server.Kestrel.ServerAddress
        
        
        :type application: System.Func{Microsoft.AspNet.Http.Features.IFeatureCollection,System.Threading.Tasks.Task}
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
           public IDisposable CreateServer(ServerAddress address, Func<IFeatureCollection, Task> application)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelEngine.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelEngine.Start(System.Int32)
    
        
        
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
           public void Start(int count)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.KestrelEngine
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.KestrelEngine.Libuv
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Networking.Libuv
    
        
        .. code-block:: csharp
    
           public Libuv Libuv { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.KestrelEngine.Threads
    
        
        :rtype: System.Collections.Generic.List{Microsoft.AspNet.Server.Kestrel.KestrelThread}
    
        
        .. code-block:: csharp
    
           public List<KestrelThread> Threads { get; }
    

