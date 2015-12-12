

AuthenticatedEncryptorDescriptor Class
======================================



.. contents:: 
   :local:



Summary
-------

A descriptor which can create an authenticated encryption system based upon the
configuration provided by an :any:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionOptions` object.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptor`








Syntax
------

.. code-block:: csharp

   public sealed class AuthenticatedEncryptorDescriptor : IAuthenticatedEncryptorDescriptor





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/AuthenticatedEncryption/ConfigurationModel/AuthenticatedEncryptorDescriptor.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptor

Constructors
------------

.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptor.AuthenticatedEncryptorDescriptor(Microsoft.AspNet.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionOptions, Microsoft.AspNet.DataProtection.ISecret)
    
        
        
        
        :type options: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionOptions
        
        
        :type masterKey: Microsoft.AspNet.DataProtection.ISecret
    
        
        .. code-block:: csharp
    
           public AuthenticatedEncryptorDescriptor(AuthenticatedEncryptionOptions options, ISecret masterKey)
    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptor.AuthenticatedEncryptorDescriptor(Microsoft.AspNet.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionOptions, Microsoft.AspNet.DataProtection.ISecret, System.IServiceProvider)
    
        
        
        
        :type options: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionOptions
        
        
        :type masterKey: Microsoft.AspNet.DataProtection.ISecret
        
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public AuthenticatedEncryptorDescriptor(AuthenticatedEncryptionOptions options, ISecret masterKey, IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptor.CreateEncryptorInstance()
    
        
        :rtype: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor
    
        
        .. code-block:: csharp
    
           public IAuthenticatedEncryptor CreateEncryptorInstance()
    
    .. dn:method:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorDescriptor.ExportToXml()
    
        
        :rtype: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo
    
        
        .. code-block:: csharp
    
           public XmlSerializedDescriptorInfo ExportToXml()
    

