Non DI Aware Scenarios
======================

The data protection system is normally designed :doc:`to be added to a service container <../consumer-apis/overview>` and to be provided to dependent components via a DI mechanism. However, there may be some cases where this is not feasible, especially when importing the system into an existing application.

To support these scenarios the package Microsoft.AspNetCore.DataProtection.Extensions provides a concrete type DataProtectionProvider which offers a simple way to use the data protection system without going through DI-specific code paths. The type itself implements IDataProtectionProvider, and constructing it is as easy as providing a DirectoryInfo where this provider's cryptographic keys should be stored.

For example:

.. literalinclude:: non-di-scenarios/_static/nodisample1.cs
        :language: none
        :linenos:

.. warning::
  By default the DataProtectionProvider concrete type does not encrypt raw key material before persisting it to the file system. This is to support scenarios where the developer points to a network share, in which case the data protection system cannot automatically deduce an appropriate at-rest key encryption mechanism.

  Additionally, the DataProtectionProvider concrete type does not :ref:`isolate applications <data-protection-configuration-per-app-isolation>` by default, so all applications pointed at the same key directory can share payloads as long as their purpose parameters match.

The application developer can address both of these if desired. The DataProtectionProvider constructor accepts an :ref:`optional configuration callback <data-protection-configuration-callback>` which can be used to tweak the behaviors of the system. The sample below demonstrates restoring isolation via an explicit call to SetApplicationName, and it also demonstrates configuring the system to automatically encrypt persisted keys using Windows DPAPI. If the directory points to a UNC share, you may wish to distribute a shared certificate across all relevant machines and to configure the system to use certificate-based encryption instead via a call to :ref:`ProtectKeysWithCertificate <configuring-x509-certificate>`.

.. literalinclude:: non-di-scenarios/_static/nodisample2.cs
        :language: none
        :linenos:

.. tip::
  Instances of the DataProtectionProvider concrete type are expensive to create. If an application maintains multiple instances of this type and if they're all pointing at the same key storage directory, application performance may be degraded. The intended usage is that the application developer instantiate this type once then keep reusing this single reference as much as possible. The DataProtectionProvider type and all IDataProtector instances created from it are thread-safe for multiple callers.
