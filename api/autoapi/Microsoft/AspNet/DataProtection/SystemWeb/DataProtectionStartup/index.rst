

DataProtectionStartup Class
===========================



.. contents:: 
   :local:



Summary
-------

Allows controlling the configuration of the ASP.NET 5 Data Protection system.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.SystemWeb.DataProtectionStartup`








Syntax
------

.. code-block:: csharp

   public class DataProtectionStartup





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection.SystemWeb/DataProtectionStartup.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.SystemWeb.DataProtectionStartup

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.SystemWeb.DataProtectionStartup
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.SystemWeb.DataProtectionStartup.ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        Configures services used by the Data Protection system.
    
        
        
        
        :param services: A mutable collection of services.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public virtual void ConfigureServices(IServiceCollection services)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.SystemWeb.DataProtectionStartup.CreateDataProtectionProvider(System.IServiceProvider)
    
        
    
        Creates a new instance of an :any:`Microsoft.AspNet.DataProtection.IDataProtectionProvider`\.
    
        
        
        
        :param services: A collection of services from which to create the .
        
        :type services: System.IServiceProvider
        :rtype: Microsoft.AspNet.DataProtection.IDataProtectionProvider
        :return: An <see cref="T:Microsoft.AspNet.DataProtection.IDataProtectionProvider" />.
    
        
        .. code-block:: csharp
    
           public virtual IDataProtectionProvider CreateDataProtectionProvider(IServiceProvider services)
    

