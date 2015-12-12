

AuthenticatedEncryptorConfiguration Class
=========================================



.. contents:: 
   :local:



Summary
-------

Represents a generalized authenticated encryption mechanism.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorConfiguration`








Syntax
------

.. code-block:: csharp

   public sealed class AuthenticatedEncryptorConfiguration : IInternalAuthenticatedEncryptorConfiguration, IAuthenticatedEncryptorConfiguration





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/AuthenticatedEncryption/ConfigurationModel/AuthenticatedEncryptorConfiguration.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorConfiguration

Constructors
------------

.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorConfiguration
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorConfiguration.AuthenticatedEncryptorConfiguration(Microsoft.AspNet.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionOptions)
    
        
        
        
        :type options: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionOptions
    
        
        .. code-block:: csharp
    
           public AuthenticatedEncryptorConfiguration(AuthenticatedEncryptionOptions options)
    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorConfiguration.AuthenticatedEncryptorConfiguration(Microsoft.AspNet.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionOptions, System.IServiceProvider)
    
        
        
        
        :type options: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionOptions
        
        
        :type services: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public AuthenticatedEncryptorConfiguration(AuthenticatedEncryptionOptions options, IServiceProvider services)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorConfiguration
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorConfiguration.CreateNewDescriptor()
    
        
        :rtype: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.IAuthenticatedEncryptorDescriptor
    
        
        .. code-block:: csharp
    
           public IAuthenticatedEncryptorDescriptor CreateNewDescriptor()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorConfiguration
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ConfigurationModel.AuthenticatedEncryptorConfiguration.Options
    
        
        :rtype: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionOptions
    
        
        .. code-block:: csharp
    
           public AuthenticatedEncryptionOptions Options { get; }
    

