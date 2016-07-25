

AuthenticatedEncryptorConfiguration Class
=========================================






Represents a generalized authenticated encryption mechanism.


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
* :dn:cls:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorConfiguration`








Syntax
------

.. code-block:: csharp

    public sealed class AuthenticatedEncryptorConfiguration : IInternalAuthenticatedEncryptorConfiguration, IAuthenticatedEncryptorConfiguration








.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorConfiguration
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorConfiguration

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorConfiguration
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorConfiguration.AuthenticatedEncryptorConfiguration(Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionSettings)
    
        
    
        
        :type settings: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionSettings
    
        
        .. code-block:: csharp
    
            public AuthenticatedEncryptorConfiguration(AuthenticatedEncryptionSettings settings)
    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorConfiguration.AuthenticatedEncryptorConfiguration(Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionSettings, System.IServiceProvider)
    
        
    
        
        :type settings: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionSettings
    
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public AuthenticatedEncryptorConfiguration(AuthenticatedEncryptionSettings settings, IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorConfiguration
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorConfiguration.CreateNewDescriptor()
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor
    
        
        .. code-block:: csharp
    
            public IAuthenticatedEncryptorDescriptor CreateNewDescriptor()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorConfiguration
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorConfiguration.Settings
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionSettings
    
        
        .. code-block:: csharp
    
            public AuthenticatedEncryptionSettings Settings { get; }
    

