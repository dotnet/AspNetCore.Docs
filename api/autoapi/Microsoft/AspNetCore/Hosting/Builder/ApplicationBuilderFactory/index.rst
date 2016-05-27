

ApplicationBuilderFactory Class
===============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting.Builder`
Assemblies
    * Microsoft.AspNetCore.Hosting

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Hosting.Builder.ApplicationBuilderFactory`








Syntax
------

.. code-block:: csharp

    public class ApplicationBuilderFactory : IApplicationBuilderFactory








.. dn:class:: Microsoft.AspNetCore.Hosting.Builder.ApplicationBuilderFactory
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.Builder.ApplicationBuilderFactory

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Hosting.Builder.ApplicationBuilderFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Hosting.Builder.ApplicationBuilderFactory.ApplicationBuilderFactory(System.IServiceProvider)
    
        
    
        
        :type serviceProvider: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public ApplicationBuilderFactory(IServiceProvider serviceProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Hosting.Builder.ApplicationBuilderFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.Builder.ApplicationBuilderFactory.CreateBuilder(Microsoft.AspNetCore.Http.Features.IFeatureCollection)
    
        
    
        
        :type serverFeatures: Microsoft.AspNetCore.Http.Features.IFeatureCollection
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public IApplicationBuilder CreateBuilder(IFeatureCollection serverFeatures)
    

