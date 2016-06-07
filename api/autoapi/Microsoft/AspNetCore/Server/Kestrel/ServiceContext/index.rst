

ServiceContext Class
====================





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








Syntax
------

.. code-block:: csharp

    public class ServiceContext








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.ServiceContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.ServiceContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.ServiceContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.ServiceContext.AppLifetime
    
        
        :rtype: Microsoft.AspNetCore.Hosting.IApplicationLifetime
    
        
        .. code-block:: csharp
    
            public IApplicationLifetime AppLifetime
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.ServiceContext.DateHeaderValueManager
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Http.DateHeaderValueManager
    
        
        .. code-block:: csharp
    
            public DateHeaderValueManager DateHeaderValueManager
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.ServiceContext.FrameFactory
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext<Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext>, Microsoft.AspNetCore.Server.Kestrel.Http.Frame<Microsoft.AspNetCore.Server.Kestrel.Http.Frame>}
    
        
        .. code-block:: csharp
    
            public Func<ConnectionContext, Frame> FrameFactory
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.ServiceContext.Log
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
            public IKestrelTrace Log
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.ServiceContext.ServerOptions
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions
    
        
        .. code-block:: csharp
    
            public KestrelServerOptions ServerOptions
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.ServiceContext.ThreadPool
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IThreadPool
    
        
        .. code-block:: csharp
    
            public IThreadPool ThreadPool
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.ServiceContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.ServiceContext.ServiceContext()
    
        
    
        
        .. code-block:: csharp
    
            public ServiceContext()
    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.ServiceContext.ServiceContext(Microsoft.AspNetCore.Server.Kestrel.ServiceContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Server.Kestrel.ServiceContext
    
        
        .. code-block:: csharp
    
            public ServiceContext(ServiceContext context)
    

