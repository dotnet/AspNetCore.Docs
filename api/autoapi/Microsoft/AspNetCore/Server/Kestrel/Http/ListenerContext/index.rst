

ListenerContext Class
=====================





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








Syntax
------

.. code-block:: csharp

    public class ListenerContext : ServiceContext








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerContext.ConnectionManager
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionManager
    
        
        .. code-block:: csharp
    
            public ConnectionManager ConnectionManager
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerContext.Memory
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPool
    
        
        .. code-block:: csharp
    
            public MemoryPool Memory
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerContext.ServerAddress
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.ServerAddress
    
        
        .. code-block:: csharp
    
            public ServerAddress ServerAddress
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerContext.Thread
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.KestrelThread
    
        
        .. code-block:: csharp
    
            public KestrelThread Thread
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerContext.WriteReqPool
    
        
        :rtype: System.Collections.Generic.Queue<System.Collections.Generic.Queue`1>{Microsoft.AspNetCore.Server.Kestrel.Networking.UvWriteReq<Microsoft.AspNetCore.Server.Kestrel.Networking.UvWriteReq>}
    
        
        .. code-block:: csharp
    
            public Queue<UvWriteReq> WriteReqPool
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerContext.ListenerContext()
    
        
    
        
        .. code-block:: csharp
    
            public ListenerContext()
    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerContext.ListenerContext(Microsoft.AspNetCore.Server.Kestrel.Http.ListenerContext)
    
        
    
        
        :type listenerContext: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerContext
    
        
        .. code-block:: csharp
    
            public ListenerContext(ListenerContext listenerContext)
    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerContext.ListenerContext(Microsoft.AspNetCore.Server.Kestrel.ServiceContext)
    
        
    
        
        :type serviceContext: Microsoft.AspNetCore.Server.Kestrel.ServiceContext
    
        
        .. code-block:: csharp
    
            public ListenerContext(ServiceContext serviceContext)
    

