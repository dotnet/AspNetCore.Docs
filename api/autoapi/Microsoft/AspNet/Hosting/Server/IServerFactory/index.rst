

IServerFactory Interface
========================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IServerFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/hosting/blob/master/src/Microsoft.AspNet.Hosting.Server.Abstractions/IServerFactory.cs>`_





.. dn:interface:: Microsoft.AspNet.Hosting.Server.IServerFactory

Methods
-------

.. dn:interface:: Microsoft.AspNet.Hosting.Server.IServerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Hosting.Server.IServerFactory.Initialize(Microsoft.Extensions.Configuration.IConfiguration)
    
        
        
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
        :rtype: Microsoft.AspNet.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
           IFeatureCollection Initialize(IConfiguration configuration)
    
    .. dn:method:: Microsoft.AspNet.Hosting.Server.IServerFactory.Start(Microsoft.AspNet.Http.Features.IFeatureCollection, System.Func<Microsoft.AspNet.Http.Features.IFeatureCollection, System.Threading.Tasks.Task>)
    
        
        
        
        :type serverFeatures: Microsoft.AspNet.Http.Features.IFeatureCollection
        
        
        :type application: System.Func{Microsoft.AspNet.Http.Features.IFeatureCollection,System.Threading.Tasks.Task}
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
           IDisposable Start(IFeatureCollection serverFeatures, Func<IFeatureCollection, Task> application)
    

