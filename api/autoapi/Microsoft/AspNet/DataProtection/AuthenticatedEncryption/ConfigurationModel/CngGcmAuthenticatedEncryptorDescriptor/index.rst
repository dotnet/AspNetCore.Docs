

CngGcmAuthenticatedEncryptorDescriptor Class
============================================



.. contents:: 
   :local:



Summary
-------

A descriptor which can create an authenticated encryption system based upon the
configuration provided by an :any:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionOptions` object.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngGcmAuthenticatedEncryptorDescriptor`








Syntax
------

.. code-block:: csharp

   public sealed class CngGcmAuthenticatedEncryptorDescriptor : IAuthenticatedEncryptorDescriptor





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/dataprotection/src/Microsoft.AspNet.DataProtection/AuthenticatedEncryption/ConfigurationModel/CngGcmAuthenticatedEncryptorDescriptor.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngGcmAuthenticatedEncryptorDescriptor

Constructors
------------

.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngGcmAuthenticatedEncryptorDescriptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngGcmAuthenticatedEncryptorDescriptor.CngGcmAuthenticatedEncryptorDescriptor(Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionOptions, Microsoft.AspNet.DataProtection.ISecret)
    
        
        
        
        :type options: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionOptions
        
        
        :type masterKey: Microsoft.AspNet.DataProtection.ISecret
    
        
        .. code-block:: csharp
    
           public CngGcmAuthenticatedEncryptorDescriptor(CngGcmAuthenticatedEncryptionOptions options, ISecret masterKey)
    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngGcmAuthenticatedEncryptorDescriptor.CngGcmAuthenticatedEncryptorDescriptor(Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionOptions, Microsoft.AspNet.DataProtection.ISecret, System.IServiceProvider)
    
        
        
        
        :type options: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionOptions
        
        
        :type masterKey: Microsoft.AspNet.DataProtection.ISecret
        
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public CngGcmAuthenticatedEncryptorDescriptor(CngGcmAuthenticatedEncryptionOptions options, ISecret masterKey, IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngGcmAuthenticatedEncryptorDescriptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngGcmAuthenticatedEncryptorDescriptor.CreateEncryptorInstance()
    
        
        :rtype: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor
    
        
        .. code-block:: csharp
    
           public IAuthenticatedEncryptor CreateEncryptorInstance()
    
    .. dn:method:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.CngGcmAuthenticatedEncryptorDescriptor.ExportToXml()
    
        
        :rtype: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.XmlSerializedDescriptorInfo
    
        
        .. code-block:: csharp
    
           public XmlSerializedDescriptorInfo ExportToXml()
    

