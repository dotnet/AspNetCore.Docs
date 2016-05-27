

DataProtectionServices Class
============================






Provides access to default Data Protection :any:`Microsoft.Extensions.DependencyInjection.ServiceDescriptor` instances.


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
* :dn:cls:`Microsoft.Extensions.DependencyInjection.DataProtectionServices`








Syntax
------

.. code-block:: csharp

    public class DataProtectionServices








.. dn:class:: Microsoft.Extensions.DependencyInjection.DataProtectionServices
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.DataProtectionServices

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.DataProtectionServices
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.DataProtectionServices.GetDefaultServices()
    
        
    
        
        Returns a collection of default :any:`Microsoft.Extensions.DependencyInjection.ServiceDescriptor` instances that can be
        used to bootstrap the Data Protection system.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.DependencyInjection.ServiceDescriptor<Microsoft.Extensions.DependencyInjection.ServiceDescriptor>}
    
        
        .. code-block:: csharp
    
            public static IEnumerable<ServiceDescriptor> GetDefaultServices()
    

