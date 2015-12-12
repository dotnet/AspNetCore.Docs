

ServerFactory Class
===================



.. contents:: 
   :local:



Summary
-------

Summary description for ServerFactory





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.ServerFactory`








Syntax
------

.. code-block:: csharp

   public class ServerFactory : IServerFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/ServerFactory.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.ServerFactory

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.ServerFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.ServerFactory.ServerFactory(Microsoft.AspNet.Hosting.IApplicationLifetime, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
        
        
        :type appLifetime: Microsoft.AspNet.Hosting.IApplicationLifetime
        
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
           public ServerFactory(IApplicationLifetime appLifetime, ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.ServerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.ServerFactory.Initialize(Microsoft.Extensions.Configuration.IConfiguration)
    
        
        
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
        :rtype: Microsoft.AspNet.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
           public IFeatureCollection Initialize(IConfiguration configuration)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.ServerFactory.Start(Microsoft.AspNet.Http.Features.IFeatureCollection, System.Func<Microsoft.AspNet.Http.Features.IFeatureCollection, System.Threading.Tasks.Task>)
    
        
        
        
        :type serverFeatures: Microsoft.AspNet.Http.Features.IFeatureCollection
        
        
        :type application: System.Func{Microsoft.AspNet.Http.Features.IFeatureCollection,System.Threading.Tasks.Task}
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
           public IDisposable Start(IFeatureCollection serverFeatures, Func<IFeatureCollection, Task> application)
    

