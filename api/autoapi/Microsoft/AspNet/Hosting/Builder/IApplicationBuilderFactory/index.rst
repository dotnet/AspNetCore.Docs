

IApplicationBuilderFactory Interface
====================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IApplicationBuilderFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/hosting/blob/master/src/Microsoft.AspNet.Hosting/Builder/IApplicationBuilderFactory.cs>`_





.. dn:interface:: Microsoft.AspNet.Hosting.Builder.IApplicationBuilderFactory

Methods
-------

.. dn:interface:: Microsoft.AspNet.Hosting.Builder.IApplicationBuilderFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Hosting.Builder.IApplicationBuilderFactory.CreateBuilder(Microsoft.AspNet.Http.Features.IFeatureCollection)
    
        
        
        
        :type serverFeatures: Microsoft.AspNet.Http.Features.IFeatureCollection
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           IApplicationBuilder CreateBuilder(IFeatureCollection serverFeatures)
    

