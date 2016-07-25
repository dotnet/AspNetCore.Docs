

ConventionBasedStartup Class
============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting`
Assemblies
    * Microsoft.AspNetCore.Hosting

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Hosting.ConventionBasedStartup`








Syntax
------

.. code-block:: csharp

    public class ConventionBasedStartup : IStartup








.. dn:class:: Microsoft.AspNetCore.Hosting.ConventionBasedStartup
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.ConventionBasedStartup

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Hosting.ConventionBasedStartup
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Hosting.ConventionBasedStartup.ConventionBasedStartup(Microsoft.AspNetCore.Hosting.Internal.StartupMethods)
    
        
    
        
        :type methods: Microsoft.AspNetCore.Hosting.Internal.StartupMethods
    
        
        .. code-block:: csharp
    
            public ConventionBasedStartup(StartupMethods methods)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Hosting.ConventionBasedStartup
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.ConventionBasedStartup.Configure(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public void Configure(IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.ConventionBasedStartup.ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public IServiceProvider ConfigureServices(IServiceCollection services)
    

