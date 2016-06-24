

KestrelEngine Class
===================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Internal`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.ServiceContext`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelEngine`








Syntax
------

.. code-block:: csharp

    public class KestrelEngine : ServiceContext, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelEngine
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelEngine

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelEngine
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelEngine.KestrelEngine(Microsoft.AspNetCore.Server.Kestrel.Internal.ServiceContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Server.Kestrel.Internal.ServiceContext
    
        
        .. code-block:: csharp
    
            public KestrelEngine(ServiceContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelEngine
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelEngine.CreateServer(Microsoft.AspNetCore.Server.Kestrel.ServerAddress)
    
        
    
        
        :type address: Microsoft.AspNetCore.Server.Kestrel.ServerAddress
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public IDisposable CreateServer(ServerAddress address)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelEngine.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelEngine.Start(System.Int32)
    
        
    
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
            public void Start(int count)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelEngine
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelEngine.Libuv
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.Libuv
    
        
        .. code-block:: csharp
    
            public Libuv Libuv { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelEngine.Threads
    
        
        :rtype: System.Collections.Generic.List<System.Collections.Generic.List`1>{Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelThread<Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelThread>}
    
        
        .. code-block:: csharp
    
            public List<KestrelThread> Threads { get; }
    

