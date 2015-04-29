Configuring Data Protection
===========================

When the data protection system is initialized it applies some :ref:`default settings <data-protection-default-settings>` based on the operational environment. These settings are generally good for applications running on a single machine. There are some cases where a developer may want to change these (perhaps because his application is spread across multiple machines or for compliance reasons), and for these scenarios the data protection system offers a rich configuration API.

.. _data-protection-configuration-callback:

There is an extension method ConfigureDataProtection hanging off of IServiceCollection. This method takes a callback, and the parameter passed to the callback object allows configuration of the system. For instance, to store keys at a UNC share instead of %LOCALAPPDATA% (the default), configure the system as follows:

.. code-block:: c#

  public void ConfigureServices(IServiceCollection services)
  {
      services.AddDataProtection();
      services.ConfigureDataProtection(configure =>
      {
          configure.PersistKeysToFileSystem(new DirectoryInfo(@"\\server\share\directory\"));
      });
  }

.. warning:: 
  If you change the key persistence location, the system will no longer automatically encrypt keys at rest since it doesn't know whether DPAPI is an appropriate encryption mechanism. 

.. _configuring-x509-certificate:

You can configure the system to protect keys at rest by calling any of the ProtectKeysWith* configuration APIs. Consider the example below, which stores keys at a UNC share and encrypts those keys at rest with a specific X.509 certificate.

.. code-block:: c#

	public void ConfigureServices(IServiceCollection services)
  	{
      	services.AddDataProtection();
      	services.ConfigureDataProtection(configure =>
      	{
          	configure.PersistKeysToFileSystem(new DirectoryInfo(@"\\server\share\directory\"));
          	configure.ProtectKeysWithCertificate("thumbprint");
      	});
  	}

See [ed note: link to key encryption at rest section in key management] for more examples and for discussion on the built-in key encryption mechanisms.

To configure the system to use a default key lifetime of 14 days instead of 90 days, consider the following example:

.. code-block:: c#

  public void ConfigureServices(IServiceCollection services)
  {
      services.AddDataProtection();
      services.ConfigureDataProtection(configure =>
      {
          configure.SetDefaultKeyLifetime(TimeSpan.FromDays(14));
      });
  }

By default the data protection system isolates applications from one another, even if they're sharing the same physical key repository. This prevents the applications from understanding each other's protected payloads. To share protected payloads between two different applications, configure the system passing in the same application name for both applications as in the below example:

.. _data-protection-code-sample-application-name:

.. code-block:: c#

  public void ConfigureServices(IServiceCollection services)
  {
      services.AddDataProtection();
      services.ConfigureDataProtection(configure =>
      {
          configure.SetApplicationName("my application");
      });
  }

.. _data-protection-configuring-disable-automatic-key-generation:

Finally, you may have a scenario where you do not want an application to automatically roll keys as they approach expiration. One example of this might be applications set up in a primary / secondary relationship, where only the primary application is responsible for key management concerns, and all secondary applications simply have a read-only view of the key ring. The secondary applications can be configured to treat the key ring as read-only by configuring the system as below:

.. code-block:: c#

  public void ConfigureServices(IServiceCollection services)
  {
    services.AddDataProtection();
    services.ConfigureDataProtection(configure =>
    {
        configure.DisableAutomaticKeyGeneration();
    });
  }

.. _data-protection-configuration-per-app-isolation:

Per-application isolation
^^^^^^^^^^^^^^^^^^^^^^^^^

When the data protection system is provided by an ASP.NET host, it will automatically isolate applications from one another, even if those applications are running under the same worker process account and are using the same master keying material. This is somewhat similar to the IsolateApps modifier from System.Web's <machineKey> element.

The isolation mechanism works by considering each application on the local machine as a unique tenant, thus the IDataProtector rooted for any given application automatically includes the application ID as a discriminator. The application's unique ID comes from one of two places.

#. If the application is hosted in IIS, the unique identifier is the application's configuration path. If an application is deployed in a farm environment, this value should be stable assuming that the IIS environments are configured similarly across all machines in the farm.
#. If the application is not hosted in IIS, the unique identifier is the physical path of the application.

The unique identifier is designed to survive resets - both of the individual application and of the machine itself.

This isolation mechanism assumes that the applications are not malicious. A malicious application can always impact any other application running under the same worker process account. In a shared hosting environment where applications are mutually untrusted, the hosting provider should take steps to ensure OS-level isolation between applications, including separating the applications' underlying key repositories.

If the data protection system is not provided by an ASP.NET host (e.g., if the developer instantiates it himself via the DataProtectionProvider concrete type), application isolation is disabled by default, and all applications backed by the same keying material can share payloads as long as they provide the appropriate purposes. To provide application isolation in this environment, call the SetApplicationName method on the configuration object, see the :ref:`code sample <data-protection-code-sample-application-name>` above.

.. _data-protection-changing-algorithms:

Changing algorithms
^^^^^^^^^^^^^^^^^^^
The data protection stack allows changing the default algorithm used by newly-generated keys. The simplest way to do this is to call UseCryptographicAlgorithms from the configuration callback, as in the below example.

.. code-block:: c#

  services.ConfigureDataProtection(configure =>
  {
      configure.UseCryptographicAlgorithms(new AuthenticatedEncryptionOptions()
      {
          EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
          ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
      });
  });

The default EncryptionAlgorithm and ValidationAlgorithm are AES-256-CBC and HMACSHA256, respectively. The default policy can be set by a system administrator via :doc:`machine-wide-policy`, but an explicit call to UseCryptographicAlgorithms will override the default policy.

Calling UseCryptographicAlgorithms will allow the developer to specify the desired algorithm (from a predefined built-in list), and the developer does not need to worry about the implementation of the algorithm. For instance, in the scenario above the data protection system will attempt to use the CNG implementation of AES if running on Windows, otherwise it will fall back to the managed System.Security.Cryptography.Aes class.

The developer can manually specify an implementation if desired via a call to UseCustomCryptographicAlgorithms, as show in the below examples.

.. tip:: 
  Changing algorithms does not affect existing keys in the key ring. It only affects newly-generated keys.

.. _data-protection-changing-algorithms-custom-managed:

Specifying custom managed algorithms
------------------------------------

To specify custom managed algorithms, create a ManagedAuthenticatedEncryptionOptions instance that points to the implementation types.


.. code-block:: c#

  services.ConfigureDataProtection(configure =>
  {
      configure.UseCustomCryptographicAlgorithms(new ManagedAuthenticatedEncryptionOptions()
      {
          // a type that subclasses SymmetricAlgorithm
          EncryptionAlgorithmType = typeof(Aes),
 
          // specified in bits
          EncryptionAlgorithmKeySize = 256,
 
          // a type that subclasses KeyedHashAlgorithm
          ValidationAlgorithmType = typeof(HMACSHA256)
      });
  });

Generally the \*Type properties must point to concrete, instantiable (via a public parameterless ctor) implementations of SymmetricAlgorithm and KeyedHashAlgorithm, though the system special-cases some values like typeof(Aes) for convenience.

.. note:: 
  The SymmetricAlgorithm must have a key length of ≥ 128 bits and a block size of ≥ 64 bits, and it must support CBC-mode encryption with PKCS #7 padding. The KeyedHashAlgorithm must have a digest size of >= 128 bits, and it must support keys of length equal to the hash algorithm's digest length. The KeyedHashAlgorithm is not strictly required to be HMAC.

.. _data-protection-changing-algorithms-cng:

Specifying custom Windows CNG algorithms
----------------------------------------

To specify a custom Windows CNG algorithm using CBC-mode encryption + HMAC validation, create a CngCbcAuthenticatedEncryptionOptions instance that contains the algorithmic information.

.. code-block:: c#

  services.ConfigureDataProtection(configure =>
  {
      configure.UseCustomCryptographicAlgorithms(new CngCbcAuthenticatedEncryptionOptions()
      {
          // passed to BCryptOpenAlgorithmProvider
          EncryptionAlgorithm = "AES",
          EncryptionAlgorithmProvider = null,
 
          // specified in bits
          EncryptionAlgorithmKeySize = 256,
 
          // passed to BCryptOpenAlgorithmProvider
          HashAlgorithm = "SHA256",
          HashAlgorithmProvider = null
      });
  });

.. note:: 
  The symmetric block cipher algorithm must have a key length of ≥ 128 bits and a block size of ≥ 64 bits, and it must support CBC-mode encryption with PKCS #7 padding. The hash algorithm must have a digest size of >= 128 bits and must support being opened with the BCRYPT_ALG_HANDLE_HMAC_FLAG flag. The \*Provider properties can be set to null to use the default provider for the specified algorithm. See the `BCryptOpenAlgorithmProvider <https://msdn.microsoft.com/en-us/library/windows/desktop/aa375479(v=vs.85).aspx>_` documentation for more information.

To specify a custom Windows CNG algorithm using Galois/Counter Mode encryption + validation, create a CngGcmAuthenticatedEncryptionOptions instance that contains the algorithmic information.

.. code-block:: c#

  services.ConfigureDataProtection(configure =>
  {
      configure.UseCustomCryptographicAlgorithms(new CngGcmAuthenticatedEncryptionOptions()
      {
          // passed to BCryptOpenAlgorithmProvider
          EncryptionAlgorithm = "AES",
          EncryptionAlgorithmProvider = null,
 
          // specified in bits
          EncryptionAlgorithmKeySize = 256
      });
  });

.. note:: 
  The symmetric block cipher algorithm must have a key length of ≥ 128 bits and a block size of exactly 128 bits, and it must support GCM encryption. The EncryptionAlgorithmProvider property can be set to null to use the default provider for the specified algorithm. See the `BCryptOpenAlgorithmProvider <https://msdn.microsoft.com/en-us/library/windows/desktop/aa375479(v=vs.85).aspx>_` documentation for more information.

Specifying other custom algorithms
----------------------------------

Though not exposed as a first-class API, the data protection system is extensible enough to allow specifying almost any kind of algorithm. For example, it is possible to keep all keys contained within an HSM and to provide a custom implementation of the core encryption and decryption routines. See IAuthenticatedEncryptorConfiguration in the core cryptography extensibility section for more information.

See also
--------
:doc:`configuration-non-di-scenarios`

:doc:`machine-wide-policy`