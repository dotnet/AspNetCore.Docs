

DataProtectionStartup Class
===========================






Allows controlling the configuration of the ASP.NET Core Data Protection system.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.SystemWeb`
Assemblies
    * Microsoft.AspNetCore.DataProtection.SystemWeb

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.DataProtection.SystemWeb.DataProtectionStartup`








Syntax
------

.. code-block:: csharp

    public class DataProtectionStartup








.. dn:class:: Microsoft.AspNetCore.DataProtection.SystemWeb.DataProtectionStartup
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.SystemWeb.DataProtectionStartup

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.SystemWeb.DataProtectionStartup
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.SystemWeb.DataProtectionStartup.ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Configures services used by the Data Protection system.
    
        
    
        
        :param services: A mutable collection of services.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
            public virtual void ConfigureServices(IServiceCollection services)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.SystemWeb.DataProtectionStartup.CreateDataProtectionProvider(System.IServiceProvider)
    
        
    
        
        Creates a new instance of an :any:`Microsoft.AspNetCore.DataProtection.IDataProtectionProvider`\.
    
        
    
        
        :param services: A collection of services from which to create the :any:`Microsoft.AspNetCore.DataProtection.IDataProtectionProvider`\.
        
        :type services: System.IServiceProvider
        :rtype: Microsoft.AspNetCore.DataProtection.IDataProtectionProvider
        :return: An :any:`Microsoft.AspNetCore.DataProtection.IDataProtectionProvider`\.
    
        
        .. code-block:: csharp
    
            public virtual IDataProtectionProvider CreateDataProtectionProvider(IServiceProvider services)
    

