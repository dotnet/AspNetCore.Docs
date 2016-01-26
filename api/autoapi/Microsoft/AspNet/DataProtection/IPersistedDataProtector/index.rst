

IPersistedDataProtector Interface
=================================



.. contents:: 
   :local:



Summary
-------

An interface that can provide data protection services for data which has been persisted
to long-term storage.











Syntax
------

.. code-block:: csharp

   public interface IPersistedDataProtector : IDataProtector, IDataProtectionProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/IPersistedDataProtector.cs>`_





.. dn:interface:: Microsoft.AspNet.DataProtection.IPersistedDataProtector

Methods
-------

.. dn:interface:: Microsoft.AspNet.DataProtection.IPersistedDataProtector
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.IPersistedDataProtector.DangerousUnprotect(System.Byte[], System.Boolean, out System.Boolean, out System.Boolean)
    
        
    
        Cryptographically unprotects a piece of data, optionally ignoring failures due to
        revocation of the cryptographic keys used to protect the payload.
    
        
        
        
        :param protectedData: The protected data to unprotect.
        
        :type protectedData: System.Byte[]
        
        
        :param ignoreRevocationErrors: 'true' if the payload should be unprotected even
            if the cryptographic key used to protect it has been revoked (due to potential compromise),
            'false' if revocation should fail the unprotect operation.
        
        :type ignoreRevocationErrors: System.Boolean
        
        
        :param requiresMigration: 'true' if the data should be reprotected before being
            persisted back to long-term storage, 'false' otherwise. Migration might be requested
            when the default protection key has changed, for instance.
        
        :type requiresMigration: System.Boolean
        
        
        :param wasRevoked: 'true' if the cryptographic key used to protect this payload
            has been revoked, 'false' otherwise. Payloads whose keys have been revoked should be
            treated as suspect unless the application has separate assurance that the payload
            has not been tampered with.
        
        :type wasRevoked: System.Boolean
        :rtype: System.Byte[]
        :return: The plaintext form of the protected data.
    
        
        .. code-block:: csharp
    
           byte[] DangerousUnprotect(byte[] protectedData, bool ignoreRevocationErrors, out bool requiresMigration, out bool wasRevoked)
    

