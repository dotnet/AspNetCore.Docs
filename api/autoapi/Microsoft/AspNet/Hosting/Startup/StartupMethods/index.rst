

StartupMethods Class
====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Hosting.Startup.StartupMethods`








Syntax
------

.. code-block:: csharp

   public class StartupMethods





GitHub
------

`View on GitHub <https://github.com/aspnet/hosting/blob/master/src/Microsoft.AspNet.Hosting/Startup/StartupMethods.cs>`_





.. dn:class:: Microsoft.AspNet.Hosting.Startup.StartupMethods

Constructors
------------

.. dn:class:: Microsoft.AspNet.Hosting.Startup.StartupMethods
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Hosting.Startup.StartupMethods.StartupMethods(System.Action<Microsoft.AspNet.Builder.IApplicationBuilder>)
    
        
        
        
        :type configure: System.Action{Microsoft.AspNet.Builder.IApplicationBuilder}
    
        
        .. code-block:: csharp
    
           public StartupMethods(Action<IApplicationBuilder> configure)
    
    .. dn:constructor:: Microsoft.AspNet.Hosting.Startup.StartupMethods.StartupMethods(System.Action<Microsoft.AspNet.Builder.IApplicationBuilder>, System.Func<Microsoft.Extensions.DependencyInjection.IServiceCollection, System.IServiceProvider>)
    
        
        
        
        :type configure: System.Action{Microsoft.AspNet.Builder.IApplicationBuilder}
        
        
        :type configureServices: System.Func{Microsoft.Extensions.DependencyInjection.IServiceCollection,System.IServiceProvider}
    
        
        .. code-block:: csharp
    
           public StartupMethods(Action<IApplicationBuilder> configure, Func<IServiceCollection, IServiceProvider> configureServices)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Hosting.Startup.StartupMethods
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Hosting.Startup.StartupMethods.ConfigureDelegate
    
        
        :rtype: System.Action{Microsoft.AspNet.Builder.IApplicationBuilder}
    
        
        .. code-block:: csharp
    
           public Action<IApplicationBuilder> ConfigureDelegate { get; }
    
    .. dn:property:: Microsoft.AspNet.Hosting.Startup.StartupMethods.ConfigureServicesDelegate
    
        
        :rtype: System.Func{Microsoft.Extensions.DependencyInjection.IServiceCollection,System.IServiceProvider}
    
        
        .. code-block:: csharp
    
           public Func<IServiceCollection, IServiceProvider> ConfigureServicesDelegate { get; }
    

