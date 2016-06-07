

ManagedAuthenticatedEncryptorDescriptor Class
=============================================






A descriptor which can create an authenticated encryption system based upon the
configuration provided by an :any:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionSettings` object.


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
* :dn:cls:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorDescriptor`








Syntax
------

.. code-block:: csharp

    public sealed class ManagedAuthenticatedEncryptorDescriptor : IAuthenticatedEncryptorDescriptor








.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorDescriptor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorDescriptor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorDescriptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorDescriptor.ManagedAuthenticatedEncryptorDescriptor(Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionSettings, Microsoft.AspNetCore.DataProtection.ISecret)
    
        
    
        
        :type settings: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionSettings
    
        
        :type masterKey: Microsoft.AspNetCore.DataProtection.ISecret
    
        
        .. code-block:: csharp
    
            public ManagedAuthenticatedEncryptorDescriptor(ManagedAuthenticatedEncryptionSettings settings, ISecret masterKey)
    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorDescriptor.ManagedAuthenticatedEncryptorDescriptor(Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionSettings, Microsoft.AspNetCore.DataProtection.ISecret, System.IServiceProvider)
    
        
    
        
        :type settings: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionSettings
    
        
        :type masterKey: Microsoft.AspNetCore.DataProtection.ISecret
    
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public ManagedAuthenticatedEncryptorDescriptor(ManagedAuthenticatedEncryptionSettings settings, ISecret masterKey, IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorDescriptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorDescriptor.CreateEncryptorInstance()
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor
    
        
        .. code-block:: csharp
    
            public IAuthenticatedEncryptor CreateEncryptorInstance()
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.ManagedAuthenticatedEncryptorDescriptor.ExportToXml()
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo
    
        
        .. code-block:: csharp
    
            public XmlSerializedDescriptorInfo ExportToXml()
    

