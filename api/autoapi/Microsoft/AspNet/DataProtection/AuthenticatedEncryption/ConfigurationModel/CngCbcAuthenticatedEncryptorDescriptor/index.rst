

CngCbcAuthenticatedEncryptorDescriptor Class
============================================



.. contents:: 
   :local:



Summary
-------

A descriptor which can create an authenticated encryption system based upon the
configuration provided by an :any:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionOptions` object.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngCbcAuthenticatedEncryptorDescriptor`








Syntax
------

.. code-block:: csharp

   public sealed class CngCbcAuthenticatedEncryptorDescriptor : IAuthenticatedEncryptorDescriptor





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/AuthenticatedEncryption/ConfigurationModel/CngCbcAuthenticatedEncryptorDescriptor.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngCbcAuthenticatedEncryptorDescriptor

Constructors
------------

.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngCbcAuthenticatedEncryptorDescriptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngCbcAuthenticatedEncryptorDescriptor.CngCbcAuthenticatedEncryptorDescriptor(Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionOptions, Microsoft.AspNet.DataProtection.ISecret)
    
        
        
        
        :type options: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionOptions
        
        
        :type masterKey: Microsoft.AspNet.DataProtection.ISecret
    
        
        .. code-block:: csharp
    
           public CngCbcAuthenticatedEncryptorDescriptor(CngCbcAuthenticatedEncryptionOptions options, ISecret masterKey)
    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngCbcAuthenticatedEncryptorDescriptor.CngCbcAuthenticatedEncryptorDescriptor(Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionOptions, Microsoft.AspNet.DataProtection.ISecret, System.IServiceProvider)
    
        
        
        
        :type options: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionOptions
        
        
        :type masterKey: Microsoft.AspNet.DataProtection.ISecret
        
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public CngCbcAuthenticatedEncryptorDescriptor(CngCbcAuthenticatedEncryptionOptions options, ISecret masterKey, IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngCbcAuthenticatedEncryptorDescriptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngCbcAuthenticatedEncryptorDescriptor.CreateEncryptorInstance()
    
        
        :rtype: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor
    
        
        .. code-block:: csharp
    
           public IAuthenticatedEncryptor CreateEncryptorInstance()
    
    .. dn:method:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngCbcAuthenticatedEncryptorDescriptor.ExportToXml()
    
        
        :rtype: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo
    
        
        .. code-block:: csharp
    
           public XmlSerializedDescriptorInfo ExportToXml()
    

