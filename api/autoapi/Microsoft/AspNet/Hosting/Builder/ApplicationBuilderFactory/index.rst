

ApplicationBuilderFactory Class
===============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Hosting.Builder.ApplicationBuilderFactory`








Syntax
------

.. code-block:: csharp

   public class ApplicationBuilderFactory : IApplicationBuilderFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/hosting/src/Microsoft.AspNet.Hosting/Builder/ApplicationBuilderFactory.cs>`_





.. dn:class:: Microsoft.AspNet.Hosting.Builder.ApplicationBuilderFactory

Constructors
------------

.. dn:class:: Microsoft.AspNet.Hosting.Builder.ApplicationBuilderFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Hosting.Builder.ApplicationBuilderFactory.ApplicationBuilderFactory(System.IServiceProvider)
    
        
        
        
        :type serviceProvider: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public ApplicationBuilderFactory(IServiceProvider serviceProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Hosting.Builder.ApplicationBuilderFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Hosting.Builder.ApplicationBuilderFactory.CreateBuilder(Microsoft.AspNet.Http.Features.IFeatureCollection)
    
        
        
        
        :type serverFeatures: Microsoft.AspNet.Http.Features.IFeatureCollection
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public IApplicationBuilder CreateBuilder(IFeatureCollection serverFeatures)
    

