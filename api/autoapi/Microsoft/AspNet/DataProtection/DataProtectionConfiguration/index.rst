

DataProtectionConfiguration Class
=================================



.. contents:: 
   :local:



Summary
-------

Provides access to configuration for the data protection system, which allows the
developer to configure default cryptographic algorithms, key storage locations,
and the mechanism by which keys are protected at rest.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.DataProtectionConfiguration`








Syntax
------

.. code-block:: csharp

   public class DataProtectionConfiguration





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/DataProtectionConfiguration.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.DataProtectionConfiguration

Constructors
------------

.. dn:class:: Microsoft.AspNet.DataProtection.DataProtectionConfiguration
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.DataProtectionConfiguration.DataProtectionConfiguration(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        Creates a new configuration object linked to a :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public DataProtectionConfiguration(IServiceCollection services)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.DataProtectionConfiguration
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionConfiguration.AddKeyEscrowSink(Microsoft.AspNet.DataProtection.KeyManagement.IKeyEscrowSink)
    
        
    
        Registers a :any:`Microsoft.AspNet.DataProtection.KeyManagement.IKeyEscrowSink` to perform escrow before keys are persisted to storage.
    
        
        
        
        :param sink: The instance of the  to register.
        
        :type sink: Microsoft.AspNet.DataProtection.KeyManagement.IKeyEscrowSink
        :rtype: Microsoft.AspNet.DataProtection.DataProtectionConfiguration
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public DataProtectionConfiguration AddKeyEscrowSink(IKeyEscrowSink sink)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionConfiguration.AddKeyEscrowSink(System.Func<System.IServiceProvider, Microsoft.AspNet.DataProtection.KeyManagement.IKeyEscrowSink>)
    
        
    
        Registers a :any:`Microsoft.AspNet.DataProtection.KeyManagement.IKeyEscrowSink` to perform escrow before keys are persisted to storage.
    
        
        
        
        :param factory: A factory that creates the  instance.
        
        :type factory: System.Func{System.IServiceProvider,Microsoft.AspNet.DataProtection.KeyManagement.IKeyEscrowSink}
        :rtype: Microsoft.AspNet.DataProtection.DataProtectionConfiguration
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public DataProtectionConfiguration AddKeyEscrowSink(Func<IServiceProvider, IKeyEscrowSink> factory)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionConfiguration.AddKeyEscrowSink<TImplementation>()
    
        
    
        Registers a :any:`Microsoft.AspNet.DataProtection.KeyManagement.IKeyEscrowSink` to perform escrow before keys are persisted to storage.
    
        
        :rtype: Microsoft.AspNet.DataProtection.DataProtectionConfiguration
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public DataProtectionConfiguration AddKeyEscrowSink<TImplementation>()where TImplementation : class, IKeyEscrowSink
    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionConfiguration.ConfigureGlobalOptions(System.Action<Microsoft.AspNet.DataProtection.DataProtectionOptions>)
    
        
    
        Configures miscellaneous global options.
    
        
        
        
        :param setupAction: A callback that configures the global options.
        
        :type setupAction: System.Action{Microsoft.AspNet.DataProtection.DataProtectionOptions}
        :rtype: Microsoft.AspNet.DataProtection.DataProtectionConfiguration
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public DataProtectionConfiguration ConfigureGlobalOptions(Action<DataProtectionOptions> setupAction)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionConfiguration.DisableAutomaticKeyGeneration()
    
        
    
        Configures the data protection system not to generate new keys automatically.
    
        
        :rtype: Microsoft.AspNet.DataProtection.DataProtectionConfiguration
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public DataProtectionConfiguration DisableAutomaticKeyGeneration()
    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionConfiguration.PersistKeysToFileSystem(System.IO.DirectoryInfo)
    
        
    
        Configures the data protection system to persist keys to the specified directory.
        This path may be on the local machine or may point to a UNC share.
    
        
        
        
        :param directory: The directory in which to store keys.
        
        :type directory: System.IO.DirectoryInfo
        :rtype: Microsoft.AspNet.DataProtection.DataProtectionConfiguration
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public DataProtectionConfiguration PersistKeysToFileSystem(DirectoryInfo directory)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionConfiguration.PersistKeysToRegistry(Microsoft.Win32.RegistryKey)
    
        
    
        Configures the data protection system to persist keys to the Windows registry.
    
        
        
        
        :param registryKey: The location in the registry where keys should be stored.
        
        :type registryKey: Microsoft.Win32.RegistryKey
        :rtype: Microsoft.AspNet.DataProtection.DataProtectionConfiguration
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public DataProtectionConfiguration PersistKeysToRegistry(RegistryKey registryKey)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionConfiguration.ProtectKeysWithCertificate(System.Security.Cryptography.X509Certificates.X509Certificate2)
    
        
    
        Configures keys to be encrypted to a given certificate before being persisted to storage.
    
        
        
        
        :param certificate: The certificate to use when encrypting keys.
        
        :type certificate: System.Security.Cryptography.X509Certificates.X509Certificate2
        :rtype: Microsoft.AspNet.DataProtection.DataProtectionConfiguration
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public DataProtectionConfiguration ProtectKeysWithCertificate(X509Certificate2 certificate)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionConfiguration.ProtectKeysWithCertificate(System.String)
    
        
    
        Configures keys to be encrypted to a given certificate before being persisted to storage.
    
        
        
        
        :param thumbprint: The thumbprint of the certificate to use when encrypting keys.
        
        :type thumbprint: System.String
        :rtype: Microsoft.AspNet.DataProtection.DataProtectionConfiguration
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public DataProtectionConfiguration ProtectKeysWithCertificate(string thumbprint)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionConfiguration.ProtectKeysWithDpapi()
    
        
    
        Configures keys to be encrypted with Windows DPAPI before being persisted to
        storage. The encrypted key will only be decryptable by the current Windows user account.
    
        
        :rtype: Microsoft.AspNet.DataProtection.DataProtectionConfiguration
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public DataProtectionConfiguration ProtectKeysWithDpapi()
    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionConfiguration.ProtectKeysWithDpapi(System.Boolean)
    
        
    
        Configures keys to be encrypted with Windows DPAPI before being persisted to
        storage.
    
        
        
        
        :param protectToLocalMachine: 'true' if the key should be decryptable by any
            use on the local machine, 'false' if the key should only be decryptable by the current
            Windows user account.
        
        :type protectToLocalMachine: System.Boolean
        :rtype: Microsoft.AspNet.DataProtection.DataProtectionConfiguration
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public DataProtectionConfiguration ProtectKeysWithDpapi(bool protectToLocalMachine)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionConfiguration.ProtectKeysWithDpapiNG()
    
        
    
        Configures keys to be encrypted with Windows CNG DPAPI before being persisted
        to storage. The keys will be decryptable by the current Windows user account.
    
        
        :rtype: Microsoft.AspNet.DataProtection.DataProtectionConfiguration
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public DataProtectionConfiguration ProtectKeysWithDpapiNG()
    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionConfiguration.ProtectKeysWithDpapiNG(System.String, Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags)
    
        
    
        Configures keys to be encrypted with Windows CNG DPAPI before being persisted to storage.
    
        
        
        
        :param protectionDescriptorRule: The descriptor rule string with which to protect the key material.
        
        :type protectionDescriptorRule: System.String
        
        
        :param flags: Flags that should be passed to the call to 'NCryptCreateProtectionDescriptor'.
            The default value of this parameter is .
        
        :type flags: Microsoft.AspNet.DataProtection.XmlEncryption.DpapiNGProtectionDescriptorFlags
        :rtype: Microsoft.AspNet.DataProtection.DataProtectionConfiguration
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public DataProtectionConfiguration ProtectKeysWithDpapiNG(string protectionDescriptorRule, DpapiNGProtectionDescriptorFlags flags)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionConfiguration.SetApplicationName(System.String)
    
        
    
        Sets the unique name of this application within the data protection system.
    
        
        
        
        :param applicationName: The application name.
        
        :type applicationName: System.String
        :rtype: Microsoft.AspNet.DataProtection.DataProtectionConfiguration
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public DataProtectionConfiguration SetApplicationName(string applicationName)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionConfiguration.SetDefaultKeyLifetime(System.TimeSpan)
    
        
    
        Sets the default lifetime of keys created by the data protection system.
    
        
        
        
        :param lifetime: The lifetime (time before expiration) for newly-created keys.
            See  for more information and
            usage notes.
        
        :type lifetime: System.TimeSpan
        :rtype: Microsoft.AspNet.DataProtection.DataProtectionConfiguration
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public DataProtectionConfiguration SetDefaultKeyLifetime(TimeSpan lifetime)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionConfiguration.UseCryptographicAlgorithms(Microsoft.AspNet.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionOptions)
    
        
    
        Configures the data protection system to use the specified cryptographic algorithms
        by default when generating protected payloads.
    
        
        
        
        :param options: Information about what cryptographic algorithms should be used.
        
        :type options: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.AuthenticatedEncryptionOptions
        :rtype: Microsoft.AspNet.DataProtection.DataProtectionConfiguration
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public DataProtectionConfiguration UseCryptographicAlgorithms(AuthenticatedEncryptionOptions options)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionConfiguration.UseCustomCryptographicAlgorithms(Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionOptions)
    
        
    
        Configures the data protection system to use custom Windows CNG algorithms.
        This API is intended for advanced scenarios where the developer cannot use the
        algorithms specified in the :any:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm` and 
        :any:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ValidationAlgorithm` enumerations.
    
        
        
        
        :param options: Information about what cryptographic algorithms should be used.
        
        :type options: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngCbcAuthenticatedEncryptionOptions
        :rtype: Microsoft.AspNet.DataProtection.DataProtectionConfiguration
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public DataProtectionConfiguration UseCustomCryptographicAlgorithms(CngCbcAuthenticatedEncryptionOptions options)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionConfiguration.UseCustomCryptographicAlgorithms(Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionOptions)
    
        
    
        Configures the data protection system to use custom Windows CNG algorithms.
        This API is intended for advanced scenarios where the developer cannot use the
        algorithms specified in the :any:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm` and 
        :any:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ValidationAlgorithm` enumerations.
    
        
        
        
        :param options: Information about what cryptographic algorithms should be used.
        
        :type options: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.CngGcmAuthenticatedEncryptionOptions
        :rtype: Microsoft.AspNet.DataProtection.DataProtectionConfiguration
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public DataProtectionConfiguration UseCustomCryptographicAlgorithms(CngGcmAuthenticatedEncryptionOptions options)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionConfiguration.UseCustomCryptographicAlgorithms(Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionOptions)
    
        
    
        Configures the data protection system to use custom algorithms.
        This API is intended for advanced scenarios where the developer cannot use the
        algorithms specified in the :any:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm` and 
        :any:`Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ValidationAlgorithm` enumerations.
    
        
        
        
        :param options: Information about what cryptographic algorithms should be used.
        
        :type options: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ManagedAuthenticatedEncryptionOptions
        :rtype: Microsoft.AspNet.DataProtection.DataProtectionConfiguration
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public DataProtectionConfiguration UseCustomCryptographicAlgorithms(ManagedAuthenticatedEncryptionOptions options)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.DataProtectionConfiguration.UseEphemeralDataProtectionProvider()
    
        
    
        Configures the data protection system to use the :any:`Microsoft.AspNet.DataProtection.EphemeralDataProtectionProvider`
        for data protection services.
    
        
        :rtype: Microsoft.AspNet.DataProtection.DataProtectionConfiguration
        :return: The 'this' instance.
    
        
        .. code-block:: csharp
    
           public DataProtectionConfiguration UseEphemeralDataProtectionProvider()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.DataProtection.DataProtectionConfiguration
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.DataProtection.DataProtectionConfiguration.Services
    
        
    
        Provides access to the :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` passed to this object's constructor.
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public IServiceCollection Services { get; }
    

