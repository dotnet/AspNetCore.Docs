

AuthenticatedEncryptorDescriptor Class
======================================






A descriptor which can create an authenticated encryption system based upon the
configuration provided by an :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionSettings` object.


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
* :dn:cls:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptor`








Syntax
------

.. code-block:: csharp

    public sealed class AuthenticatedEncryptorDescriptor : IAuthenticatedEncryptorDescriptor








.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptor.AuthenticatedEncryptorDescriptor(Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionSettings, Microsoft.AspNetCore.DataProtection.ISecret)
    
        
    
        
        :type settings: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionSettings
    
        
        :type masterKey: Microsoft.AspNetCore.DataProtection.ISecret
    
        
        .. code-block:: csharp
    
            public AuthenticatedEncryptorDescriptor(AuthenticatedEncryptionSettings settings, ISecret masterKey)
    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptor.AuthenticatedEncryptorDescriptor(Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionSettings, Microsoft.AspNetCore.DataProtection.ISecret, System.IServiceProvider)
    
        
    
        
        :type settings: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionSettings
    
        
        :type masterKey: Microsoft.AspNetCore.DataProtection.ISecret
    
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public AuthenticatedEncryptorDescriptor(AuthenticatedEncryptionSettings settings, ISecret masterKey, IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptor.CreateEncryptorInstance()
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor
    
        
        .. code-block:: csharp
    
            public IAuthenticatedEncryptor CreateEncryptorInstance()
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptor.ExportToXml()
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo
    
        
        .. code-block:: csharp
    
            public XmlSerializedDescriptorInfo ExportToXml()
    

