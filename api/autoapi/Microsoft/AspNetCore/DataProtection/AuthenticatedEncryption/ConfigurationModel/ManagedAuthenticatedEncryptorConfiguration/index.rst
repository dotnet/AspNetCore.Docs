

ManagedAuthenticatedEncryptorConfiguration Class
================================================






Represents a configured authenticated encryption mechanism which uses
managed :any:`System.Security.Cryptography.SymmetricAlgorithm` and 
:any:`System.Security.Cryptography.KeyedHashAlgorithm` types.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorConfiguration`








Syntax
------

.. code-block:: csharp

    public sealed class ManagedAuthenticatedEncryptorConfiguration : IInternalAuthenticatedEncryptorConfiguration, IAuthenticatedEncryptorConfiguration








.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorConfiguration
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorConfiguration

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorConfiguration
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorConfiguration.ManagedAuthenticatedEncryptorConfiguration(Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionSettings)
    
        
    
        
        :type settings: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionSettings
    
        
        .. code-block:: csharp
    
            public ManagedAuthenticatedEncryptorConfiguration(ManagedAuthenticatedEncryptionSettings settings)
    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorConfiguration.ManagedAuthenticatedEncryptorConfiguration(Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionSettings, System.IServiceProvider)
    
        
    
        
        :type settings: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionSettings
    
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public ManagedAuthenticatedEncryptorConfiguration(ManagedAuthenticatedEncryptionSettings settings, IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorConfiguration
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorConfiguration.CreateNewDescriptor()
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor
    
        
        .. code-block:: csharp
    
            public IAuthenticatedEncryptorDescriptor CreateNewDescriptor()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorConfiguration
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorConfiguration.Settings
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionSettings
    
        
        .. code-block:: csharp
    
            public ManagedAuthenticatedEncryptionSettings Settings { get; }
    

