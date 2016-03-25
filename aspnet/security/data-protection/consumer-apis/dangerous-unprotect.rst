.. _data-protection-consumer-apis-dangerous-unprotect:

Unprotecting payloads whose keys have been revoked
==================================================

The ASP.NET Core data protection APIs are not primarily intended for indefinite persistence of confidential payloads. Other technologies like `Windows CNG DPAPI <https://msdn.microsoft.com/en-us/library/windows/desktop/hh706794%28v=vs.85%29.aspx>`_ and `Azure Rights Management <https://technet.microsoft.com/en-us/library/jj585024.aspx>`_ are more suited to the scenario of indefinite storage, and they have correspondingly strong key management capabilities. That said, there is nothing prohibiting a developer from using the ASP.NET Core data protection APIs for long-term protection of confidential data. Keys are never removed from the key ring, so IDataProtector.Unprotect can always recover existing payloads as long as the keys are available and valid.

However, an issue arises when the developer tries to unprotect data that has been protected with a revoked key, as IDataProtector.Unprotect will throw an exception in this case. This might be fine for short-lived or transient payloads (like authentication tokens), as these kinds of payloads can easily be recreated by the system, and at worst the site visitor might be required to log in again. But for persisted payloads, having Unprotect throw could lead to unacceptable data loss.

IPersistedDataProtector
-----------------------

To support the scenario of allowing payloads to be unprotected even in the face of revoked keys, the data protection system contains an IPersistedDataProtector type. To get an instance of IPersistedDataProtector, simply get an instance of IDataProtector in the normal fashion and try casting the IDataProtector to IPersistedDataProtector.

.. note:: 
  Not all IDataProtector instances can be cast to IPersistedDataProtector. Developers should use the C# as operator or similar to avoid runtime exceptions caused by invalid casts, and they should be prepared to handle the failure case appropriately.

IPersistedDataProtector exposes the following API surface:

.. code-block:: c#

  DangerousUnprotect(byte[] protectedData, bool ignoreRevocationErrors, 
    out bool requiresMigration, out bool wasRevoked) : byte[]

This API takes the protected payload (as a byte array) and returns the unprotected payload. There is no string-based overload. The two out parameters are as follows.

* requiresMigration: will be set to true if the key used to protect this payload is no longer the active default key, e.g., the key used to protect this payload is old and a key rolling operation has since taken place. The caller may wish to consider reprotecting the payload depending on his business needs.
* wasRevoked: will be set to true if the key used to protect this payload was revoked.

.. warning:: 
  Exercise extreme caution when passing ignoreRevocationErrors: true to the DangerousUnprotect method. If after calling this method the wasRevoked value is true, then the key used to protect this payload was revoked, and the payload's authenticity should be treated as suspect. In this case only continue operating on the unprotected payload if you have some separate assurance that it is authentic, e.g. that it's coming from a secure database rather than being sent by an untrusted web client.


.. literalinclude:: dangerous-unprotect/samples/dangerous-unprotect.cs
  :language: c#
  :linenos: