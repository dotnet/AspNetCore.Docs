

IDataProtectionBuilder Interface
================================






Provides access to configuration for the data protection system, which allows the
developer to configure default cryptographic algorithms, key storage locations,
and the mechanism by which keys are protected at rest.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IDataProtectionBuilder








.. dn:interface:: Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder.Services
    
        
    
        
        Provides access to the :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` passed to this object's constructor.
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
            IServiceCollection Services { get; }
    

