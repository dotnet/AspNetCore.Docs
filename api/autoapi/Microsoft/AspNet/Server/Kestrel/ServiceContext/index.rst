

ServiceContext Class
====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.ServiceContext`








Syntax
------

.. code-block:: csharp

   public class ServiceContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel/ServiceContext.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.ServiceContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.ServiceContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.ServiceContext.ServiceContext()
    
        
    
        
        .. code-block:: csharp
    
           public ServiceContext()
    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.ServiceContext.ServiceContext(Microsoft.AspNet.Server.Kestrel.ServiceContext)
    
        
        
        
        :type context: Microsoft.AspNet.Server.Kestrel.ServiceContext
    
        
        .. code-block:: csharp
    
           public ServiceContext(ServiceContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.ServiceContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.ServiceContext.AppLifetime
    
        
        :rtype: Microsoft.AspNet.Hosting.IApplicationLifetime
    
        
        .. code-block:: csharp
    
           public IApplicationLifetime AppLifetime { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.ServiceContext.ConnectionFilter
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Filter.IConnectionFilter
    
        
        .. code-block:: csharp
    
           public IConnectionFilter ConnectionFilter { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.ServiceContext.DateHeaderValueManager
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Http.DateHeaderValueManager
    
        
        .. code-block:: csharp
    
           public DateHeaderValueManager DateHeaderValueManager { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.ServiceContext.Log
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
           public IKestrelTrace Log { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.ServiceContext.Memory
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Http.IMemoryPool
    
        
        .. code-block:: csharp
    
           public IMemoryPool Memory { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.ServiceContext.NoDelay
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool NoDelay { get; set; }
    

