

IStartup Interface
==================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting`
Assemblies
    * Microsoft.AspNetCore.Hosting.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IStartup








.. dn:interface:: Microsoft.AspNetCore.Hosting.IStartup
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Hosting.IStartup

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Hosting.IStartup
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.IStartup.Configure(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            void Configure(IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.IStartup.ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            IServiceProvider ConfigureServices(IServiceCollection services)
    

