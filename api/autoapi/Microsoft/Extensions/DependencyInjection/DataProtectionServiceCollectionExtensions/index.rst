

DataProtectionServiceCollectionExtensions Class
===============================================



.. contents:: 
   :local:



Summary
-------

Allows registering and configuring Data Protection in the application.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.DataProtectionServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

   public class DataProtectionServiceCollectionExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/DataProtectionServiceCollectionExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.DataProtectionServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.DataProtectionServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.DataProtectionServiceCollectionExtensions.AddDataProtection(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        Adds default Data Protection services to an :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
        
        
        :param services: The service collection to which to add DataProtection services.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The <paramref name="services" /> instance.
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddDataProtection(IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.DataProtectionServiceCollectionExtensions.ConfigureDataProtection(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.AspNet.DataProtection.DataProtectionConfiguration>)
    
        
    
        Configures the behavior of the Data Protection system.
    
        
        
        
        :param services: A service collection to which Data Protection has already been added.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :param configure: A callback which takes a  parameter.
            This callback will be responsible for configuring the system.
        
        :type configure: System.Action{Microsoft.AspNet.DataProtection.DataProtectionConfiguration}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The <paramref name="services" /> instance.
    
        
        .. code-block:: csharp
    
           public static IServiceCollection ConfigureDataProtection(IServiceCollection services, Action<DataProtectionConfiguration> configure)
    

