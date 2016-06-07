

KestrelEngine Class
===================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.ServiceContext`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.KestrelEngine`








Syntax
------

.. code-block:: csharp

    public class KestrelEngine : ServiceContext, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.KestrelEngine
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.KestrelEngine

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.KestrelEngine
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.KestrelEngine.Libuv
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Networking.Libuv
    
        
        .. code-block:: csharp
    
            public Libuv Libuv
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.KestrelEngine.Threads
    
        
        :rtype: System.Collections.Generic.List<System.Collections.Generic.List`1>{Microsoft.AspNetCore.Server.Kestrel.KestrelThread<Microsoft.AspNetCore.Server.Kestrel.KestrelThread>}
    
        
        .. code-block:: csharp
    
            public List<KestrelThread> Threads
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.KestrelEngine
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.KestrelEngine.KestrelEngine(Microsoft.AspNetCore.Server.Kestrel.ServiceContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Server.Kestrel.ServiceContext
    
        
        .. code-block:: csharp
    
            public KestrelEngine(ServiceContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.KestrelEngine
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.KestrelEngine.CreateServer(Microsoft.AspNetCore.Server.Kestrel.ServerAddress)
    
        
    
        
        :type address: Microsoft.AspNetCore.Server.Kestrel.ServerAddress
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public IDisposable CreateServer(ServerAddress address)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.KestrelEngine.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.KestrelEngine.Start(System.Int32)
    
        
    
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
            public void Start(int count)
    

