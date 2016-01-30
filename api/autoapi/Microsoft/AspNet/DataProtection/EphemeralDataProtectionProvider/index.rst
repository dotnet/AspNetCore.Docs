

EphemeralDataProtectionProvider Class
=====================================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.DataProtection.IDataProtectionProvider` that is transient.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.EphemeralDataProtectionProvider`








Syntax
------

.. code-block:: csharp

   public sealed class EphemeralDataProtectionProvider : IDataProtectionProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/EphemeralDataProtectionProvider.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.EphemeralDataProtectionProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.DataProtection.EphemeralDataProtectionProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.EphemeralDataProtectionProvider.EphemeralDataProtectionProvider()
    
        
    
        Creates an ephemeral :any:`Microsoft.AspNet.DataProtection.IDataProtectionProvider`\.
    
        
    
        
        .. code-block:: csharp
    
           public EphemeralDataProtectionProvider()
    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.EphemeralDataProtectionProvider.EphemeralDataProtectionProvider(System.IServiceProvider)
    
        
    
        Creates an ephemeral :any:`Microsoft.AspNet.DataProtection.IDataProtectionProvider`\, optionally providing
        services (such as logging) for consumption by the provider.
    
        
        
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public EphemeralDataProtectionProvider(IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.EphemeralDataProtectionProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.EphemeralDataProtectionProvider.CreateProtector(System.String)
    
        
        
        
        :type purpose: System.String
        :rtype: Microsoft.AspNet.DataProtection.IDataProtector
    
        
        .. code-block:: csharp
    
           public IDataProtector CreateProtector(string purpose)
    

