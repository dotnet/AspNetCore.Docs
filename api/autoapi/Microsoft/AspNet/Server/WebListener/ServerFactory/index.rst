

ServerFactory Class
===================



.. contents:: 
   :local:



Summary
-------

Implements the setup process for this server.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.WebListener.ServerFactory`








Syntax
------

.. code-block:: csharp

   public class ServerFactory : IServerFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/weblistener/src/Microsoft.AspNet.Server.WebListener/ServerFactory.cs>`_





.. dn:class:: Microsoft.AspNet.Server.WebListener.ServerFactory

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.WebListener.ServerFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.WebListener.ServerFactory.ServerFactory(Microsoft.Extensions.Logging.ILoggerFactory)
    
        
        
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
           public ServerFactory(ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.WebListener.ServerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.WebListener.ServerFactory.Initialize(Microsoft.Extensions.Configuration.IConfiguration)
    
        
    
        Creates a configurable instance of the server.
    
        
        
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
        :rtype: Microsoft.AspNet.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
           public IFeatureCollection Initialize(IConfiguration configuration)
    
    .. dn:method:: Microsoft.AspNet.Server.WebListener.ServerFactory.Start(Microsoft.AspNet.Http.Features.IFeatureCollection, System.Func<Microsoft.AspNet.Http.Features.IFeatureCollection, System.Threading.Tasks.Task>)
    
        
        
        
        :type serverFeatures: Microsoft.AspNet.Http.Features.IFeatureCollection
        
        
        :param app: The per-request application entry point.
        
        :type app: System.Func{Microsoft.AspNet.Http.Features.IFeatureCollection,System.Threading.Tasks.Task}
        :rtype: System.IDisposable
        :return: The server.  Invoke Dispose to shut down.
    
        
        .. code-block:: csharp
    
           public IDisposable Start(IFeatureCollection serverFeatures, Func<IFeatureCollection, Task> app)
    

