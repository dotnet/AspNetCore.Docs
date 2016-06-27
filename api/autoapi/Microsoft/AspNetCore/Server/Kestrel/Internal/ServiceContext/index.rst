

ServiceContext Class
====================





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








Syntax
------

.. code-block:: csharp

    public class ServiceContext








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.ServiceContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.ServiceContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.ServiceContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Internal.ServiceContext.ServiceContext()
    
        
    
        
        .. code-block:: csharp
    
            public ServiceContext()
    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Internal.ServiceContext.ServiceContext(Microsoft.AspNetCore.Server.Kestrel.Internal.ServiceContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Server.Kestrel.Internal.ServiceContext
    
        
        .. code-block:: csharp
    
            public ServiceContext(ServiceContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.ServiceContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.ServiceContext.AppLifetime
    
        
        :rtype: Microsoft.AspNetCore.Hosting.IApplicationLifetime
    
        
        .. code-block:: csharp
    
            public IApplicationLifetime AppLifetime { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.ServiceContext.DateHeaderValueManager
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.DateHeaderValueManager
    
        
        .. code-block:: csharp
    
            public DateHeaderValueManager DateHeaderValueManager { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.ServiceContext.FrameFactory
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ConnectionContext<Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ConnectionContext>, Microsoft.AspNetCore.Server.Kestrel.Internal.Http.Frame<Microsoft.AspNetCore.Server.Kestrel.Internal.Http.Frame>}
    
        
        .. code-block:: csharp
    
            public Func<ConnectionContext, Frame> FrameFactory { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.ServiceContext.Log
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
            public IKestrelTrace Log { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.ServiceContext.ServerOptions
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions
    
        
        .. code-block:: csharp
    
            public KestrelServerOptions ServerOptions { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.ServiceContext.ThreadPool
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.IThreadPool
    
        
        .. code-block:: csharp
    
            public IThreadPool ThreadPool { get; set; }
    

