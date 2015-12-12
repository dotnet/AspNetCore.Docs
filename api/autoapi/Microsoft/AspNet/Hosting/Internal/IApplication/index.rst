

IApplication Interface
======================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IApplication : IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/hosting/src/Microsoft.AspNet.Hosting/Internal/IApplication.cs>`_





.. dn:interface:: Microsoft.AspNet.Hosting.Internal.IApplication

Properties
----------

.. dn:interface:: Microsoft.AspNet.Hosting.Internal.IApplication
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Hosting.Internal.IApplication.ServerFeatures
    
        
        :rtype: Microsoft.AspNet.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
           IFeatureCollection ServerFeatures { get; }
    
    .. dn:property:: Microsoft.AspNet.Hosting.Internal.IApplication.Services
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           IServiceProvider Services { get; }
    

