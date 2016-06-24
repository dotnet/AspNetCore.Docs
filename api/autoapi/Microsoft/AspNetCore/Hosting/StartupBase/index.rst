

StartupBase Class
=================





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
* :dn:cls:`Microsoft.AspNetCore.Hosting.StartupBase`








Syntax
------

.. code-block:: csharp

    public abstract class StartupBase : IStartup








.. dn:class:: Microsoft.AspNetCore.Hosting.StartupBase
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.StartupBase

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Hosting.StartupBase
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.StartupBase.Configure(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public abstract void Configure(IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.StartupBase.ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public virtual IServiceProvider ConfigureServices(IServiceCollection services)
    

