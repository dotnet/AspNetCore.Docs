

CngGcmAuthenticatedEncryptorConfiguration Class
===============================================






Represents a configured authenticated encryption mechanism which uses
Windows CNG algorithms in GCM encryption + authentication modes.


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
* :dn:cls:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngGcmAuthenticatedEncryptorConfiguration`








Syntax
------

.. code-block:: csharp

    public sealed class CngGcmAuthenticatedEncryptorConfiguration : IInternalAuthenticatedEncryptorConfiguration, IAuthenticatedEncryptorConfiguration








.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngGcmAuthenticatedEncryptorConfiguration
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngGcmAuthenticatedEncryptorConfiguration

Properties
----------

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngGcmAuthenticatedEncryptorConfiguration
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngGcmAuthenticatedEncryptorConfiguration.Settings
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionSettings
    
        
        .. code-block:: csharp
    
            public CngGcmAuthenticatedEncryptionSettings Settings
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngGcmAuthenticatedEncryptorConfiguration
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngGcmAuthenticatedEncryptorConfiguration.CngGcmAuthenticatedEncryptorConfiguration(Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionSettings)
    
        
    
        
        :type settings: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionSettings
    
        
        .. code-block:: csharp
    
            public CngGcmAuthenticatedEncryptorConfiguration(CngGcmAuthenticatedEncryptionSettings settings)
    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngGcmAuthenticatedEncryptorConfiguration.CngGcmAuthenticatedEncryptorConfiguration(Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionSettings, System.IServiceProvider)
    
        
    
        
        :type settings: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionSettings
    
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public CngGcmAuthenticatedEncryptorConfiguration(CngGcmAuthenticatedEncryptionSettings settings, IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngGcmAuthenticatedEncryptorConfiguration
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngGcmAuthenticatedEncryptorConfiguration.CreateNewDescriptor()
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor
    
        
        .. code-block:: csharp
    
            public IAuthenticatedEncryptorDescriptor CreateNewDescriptor()
    

