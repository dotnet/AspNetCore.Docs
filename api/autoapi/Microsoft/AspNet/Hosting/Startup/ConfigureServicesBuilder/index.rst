

ConfigureServicesBuilder Class
==============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Hosting.Startup.ConfigureServicesBuilder`








Syntax
------

.. code-block:: csharp

   public class ConfigureServicesBuilder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/hosting/src/Microsoft.AspNet.Hosting/Startup/ConfigureServicesDelegate.cs>`_





.. dn:class:: Microsoft.AspNet.Hosting.Startup.ConfigureServicesBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNet.Hosting.Startup.ConfigureServicesBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Hosting.Startup.ConfigureServicesBuilder.ConfigureServicesBuilder(System.Reflection.MethodInfo)
    
        
        
        
        :type configureServices: System.Reflection.MethodInfo
    
        
        .. code-block:: csharp
    
           public ConfigureServicesBuilder(MethodInfo configureServices)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Hosting.Startup.ConfigureServicesBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Hosting.Startup.ConfigureServicesBuilder.Build(System.Object)
    
        
        
        
        :type instance: System.Object
        :rtype: System.Func{Microsoft.Extensions.DependencyInjection.IServiceCollection,System.IServiceProvider}
    
        
        .. code-block:: csharp
    
           public Func<IServiceCollection, IServiceProvider> Build(object instance)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Hosting.Startup.ConfigureServicesBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Hosting.Startup.ConfigureServicesBuilder.MethodInfo
    
        
        :rtype: System.Reflection.MethodInfo
    
        
        .. code-block:: csharp
    
           public MethodInfo MethodInfo { get; }
    

