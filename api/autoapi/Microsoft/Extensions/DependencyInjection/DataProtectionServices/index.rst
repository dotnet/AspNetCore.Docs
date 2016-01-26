

DataProtectionServices Class
============================



.. contents:: 
   :local:



Summary
-------

Provides access to default Data Protection :any:`Microsoft.Extensions.DependencyInjection.ServiceDescriptor` instances.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.DataProtectionServices`








Syntax
------

.. code-block:: csharp

   public class DataProtectionServices





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/DataProtectionServices.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.DataProtectionServices

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.DataProtectionServices
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.DataProtectionServices.GetDefaultServices()
    
        
    
        Returns a collection of default :any:`Microsoft.Extensions.DependencyInjection.ServiceDescriptor` instances that can be
        used to bootstrap the Data Protection system.
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.Extensions.DependencyInjection.ServiceDescriptor}
    
        
        .. code-block:: csharp
    
           public static IEnumerable<ServiceDescriptor> GetDefaultServices()
    

