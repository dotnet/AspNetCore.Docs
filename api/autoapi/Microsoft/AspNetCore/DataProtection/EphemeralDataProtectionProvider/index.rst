

EphemeralDataProtectionProvider Class
=====================================






An :any:`Microsoft.AspNetCore.DataProtection.IDataProtectionProvider` that is transient.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.DataProtection.EphemeralDataProtectionProvider`








Syntax
------

.. code-block:: csharp

    public sealed class EphemeralDataProtectionProvider : IDataProtectionProvider








.. dn:class:: Microsoft.AspNetCore.DataProtection.EphemeralDataProtectionProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.EphemeralDataProtectionProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.DataProtection.EphemeralDataProtectionProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.EphemeralDataProtectionProvider.EphemeralDataProtectionProvider()
    
        
    
        
        Creates an ephemeral :any:`Microsoft.AspNetCore.DataProtection.IDataProtectionProvider`\.
    
        
    
        
        .. code-block:: csharp
    
            public EphemeralDataProtectionProvider()
    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.EphemeralDataProtectionProvider.EphemeralDataProtectionProvider(System.IServiceProvider)
    
        
    
        
        Creates an ephemeral :any:`Microsoft.AspNetCore.DataProtection.IDataProtectionProvider`\, optionally providing
        services (such as logging) for consumption by the provider.
    
        
    
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public EphemeralDataProtectionProvider(IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.EphemeralDataProtectionProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.EphemeralDataProtectionProvider.CreateProtector(System.String)
    
        
    
        
        :type purpose: System.String
        :rtype: Microsoft.AspNetCore.DataProtection.IDataProtector
    
        
        .. code-block:: csharp
    
            public IDataProtector CreateProtector(string purpose)
    

