

DataProtectionServiceCollectionExtensions Class
===============================================






Extension methods for setting up data protection services in an :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.DataProtectionServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

    public class DataProtectionServiceCollectionExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.DataProtectionServiceCollectionExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.DataProtectionServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.DataProtectionServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.DataProtectionServiceCollectionExtensions.AddDataProtection(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Adds data protection services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder
    
        
        .. code-block:: csharp
    
            public static IDataProtectionBuilder AddDataProtection(this IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.DataProtectionServiceCollectionExtensions.AddDataProtection(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.AspNetCore.DataProtection.DataProtectionOptions>)
    
        
    
        
        Adds data protection services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param setupAction: An :any:`System.Action\`1` to configure the provided :any:`Microsoft.AspNetCore.DataProtection.DataProtectionOptions`\.
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.AspNetCore.DataProtection.DataProtectionOptions<Microsoft.AspNetCore.DataProtection.DataProtectionOptions>}
        :rtype: Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IDataProtectionBuilder AddDataProtection(this IServiceCollection services, Action<DataProtectionOptions> setupAction)
    

