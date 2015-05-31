.. _data-protection-implementation-key-storage-providers:

Key Storage Providers
=====================

By default the data protection system :ref:`employs a heuristic <data-protection-default-settings>` to determine where cryptographic key material should be persisted. The developer can override the heuristic and manually specify the location.

.. NOTE::
  If you specify an explicit key persistence location, the data protection system will deregister the default key encryption at rest mechanism that the heuristic provided, so keys will no longer be encrypted at rest. It is recommended that you additionally :ref:`specify an explicit key encryption mechanism <data-protection-implementation-key-encryption-at-rest-providers>` for production applications.

The data protection system ships with two in-box key storage providers.

File system
-----------

We anticipate that the majority of applications will use a file system-based key repository. To configure this, call the PersistKeysToFileSystem configuration routine as demonstrated below, providing a DirectoryInfo pointing to the repository where keys should be stored.

.. code-block:: c#

  sc.ConfigureDataProtection(configure =>
  {
      // persist keys to a specific directory
      configure.PersistKeysToFileSystem(new DirectoryInfo(@"c:\temp-keys\"));
  });

The DirectoryInfo can point to a directory on the local machine, or it can point to a folder on a network share. If pointing to a directory on the local machine (and the scenario is that only applications on the local machine will need to use this repository), consider using :ref:`Windows DPAPI <data-protection-implementation-key-encryption-at-rest>` to encrypt the keys at rest. Otherwise consider using an :ref:`X.509 certificate <data-protection-implementation-key-encryption-at-rest>` to encrypt keys at rest.

Registry
--------

Sometimes the application might not have write access to the file system. Consider a scenario where an application is running as a virtual service account (such as w3wp.exe's app pool identity). In these cases, the administrator may have provisioned a registry key that is appropriate ACLed for the service account identity. Call the PersistKeysToRegistry configuration routine as demonstrated below to take advantage of this, providing a RegistryKey pointing to the location where cryptographic key material should be stored.

.. code-block:: c#

  sc.ConfigureDataProtection(configure =>
  {
      // persist keys to a specific location in the system registry
      configure.PersistKeysToRegistry(Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Sample\keys"));
  });

If you use the system registry as a persistence mechanism, consider using :ref:`Windows DPAPI <data-protection-implementation-key-encryption-at-rest>` to encrypt the keys at rest.

Custom key repository
---------------------

If the in-box mechanisms are not appropriate, the developer can specify his own key persistence mechanism by providing a custom IXmlRepository.


