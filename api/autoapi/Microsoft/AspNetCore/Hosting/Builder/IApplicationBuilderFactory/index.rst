

IApplicationBuilderFactory Interface
====================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting.Builder`
Assemblies
    * Microsoft.AspNetCore.Hosting

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IApplicationBuilderFactory








.. dn:interface:: Microsoft.AspNetCore.Hosting.Builder.IApplicationBuilderFactory
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Hosting.Builder.IApplicationBuilderFactory

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Hosting.Builder.IApplicationBuilderFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.Builder.IApplicationBuilderFactory.CreateBuilder(Microsoft.AspNetCore.Http.Features.IFeatureCollection)
    
        
    
        
        :type serverFeatures: Microsoft.AspNetCore.Http.Features.IFeatureCollection
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            IApplicationBuilder CreateBuilder(IFeatureCollection serverFeatures)
    

