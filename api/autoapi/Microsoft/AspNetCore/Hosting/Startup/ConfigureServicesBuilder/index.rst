

ConfigureServicesBuilder Class
==============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting.Startup`
Assemblies
    * Microsoft.AspNetCore.Hosting

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Hosting.Startup.ConfigureServicesBuilder`








Syntax
------

.. code-block:: csharp

    public class ConfigureServicesBuilder








.. dn:class:: Microsoft.AspNetCore.Hosting.Startup.ConfigureServicesBuilder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.Startup.ConfigureServicesBuilder

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Hosting.Startup.ConfigureServicesBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Hosting.Startup.ConfigureServicesBuilder.MethodInfo
    
        
        :rtype: System.Reflection.MethodInfo
    
        
        .. code-block:: csharp
    
            public MethodInfo MethodInfo
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Hosting.Startup.ConfigureServicesBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Hosting.Startup.ConfigureServicesBuilder.ConfigureServicesBuilder(System.Reflection.MethodInfo)
    
        
    
        
        :type configureServices: System.Reflection.MethodInfo
    
        
        .. code-block:: csharp
    
            public ConfigureServicesBuilder(MethodInfo configureServices)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Hosting.Startup.ConfigureServicesBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.Startup.ConfigureServicesBuilder.Build(System.Object)
    
        
    
        
        :type instance: System.Object
        :rtype: System.Func<System.Func`2>{Microsoft.Extensions.DependencyInjection.IServiceCollection<Microsoft.Extensions.DependencyInjection.IServiceCollection>, System.IServiceProvider<System.IServiceProvider>}
    
        
        .. code-block:: csharp
    
            public Func<IServiceCollection, IServiceProvider> Build(object instance)
    

