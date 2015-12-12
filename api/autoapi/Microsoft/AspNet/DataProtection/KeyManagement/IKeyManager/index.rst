

IKeyManager Interface
=====================



.. contents:: 
   :local:



Summary
-------

The basic interface for performing key management operations.











Syntax
------

.. code-block:: csharp

   public interface IKeyManager





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/dataprotection/src/Microsoft.AspNet.DataProtection/KeyManagement/IKeyManager.cs>`_





.. dn:interface:: Microsoft.AspNet.DataProtection.KeyManagement.IKeyManager

Methods
-------

.. dn:interface:: Microsoft.AspNet.DataProtection.KeyManagement.IKeyManager
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.KeyManagement.IKeyManager.CreateNewKey(System.DateTimeOffset, System.DateTimeOffset)
    
        
    
        Creates a new key with the specified activation and expiration dates and persists
        the new key to the underlying repository.
    
        
        
        
        :param activationDate: The date on which encryptions to this key may begin.
        
        :type activationDate: System.DateTimeOffset
        
        
        :param expirationDate: The date after which encryptions to this key may no longer take place.
        
        :type expirationDate: System.DateTimeOffset
        :rtype: Microsoft.AspNet.DataProtection.KeyManagement.IKey
        :return: The newly-created IKey instance.
    
        
        .. code-block:: csharp
    
           IKey CreateNewKey(DateTimeOffset activationDate, DateTimeOffset expirationDate)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.KeyManagement.IKeyManager.GetAllKeys()
    
        
    
        Fetches all keys from the underlying repository.
    
        
        :rtype: System.Collections.Generic.IReadOnlyCollection{Microsoft.AspNet.DataProtection.KeyManagement.IKey}
        :return: The collection of all keys.
    
        
        .. code-block:: csharp
    
           IReadOnlyCollection<IKey> GetAllKeys()
    
    .. dn:method:: Microsoft.AspNet.DataProtection.KeyManagement.IKeyManager.GetCacheExpirationToken()
    
        
    
        Retrieves a token that signals that callers who have cached the return value of
        GetAllKeys should clear their caches. This could be in response to a call to
        CreateNewKey or RevokeKey, or it could be in response to some other external notification.
        Callers who are interested in observing this token should call this method before the
        corresponding call to GetAllKeys.
    
        
        :rtype: System.Threading.CancellationToken
        :return: The cache expiration token. When an expiration notification is triggered, any
            tokens previously returned by this method will become canceled, and tokens returned by
            future invocations of this method will themselves not trigger until the next expiration
            event.
    
        
        .. code-block:: csharp
    
           CancellationToken GetCacheExpirationToken()
    
    .. dn:method:: Microsoft.AspNet.DataProtection.KeyManagement.IKeyManager.RevokeAllKeys(System.DateTimeOffset, System.String)
    
        
    
        Revokes all keys created before a specified date and persists the revocation to the
        underlying repository.
    
        
        
        
        :param revocationDate: The revocation date. All keys with a creation date before
            this value will be revoked.
        
        :type revocationDate: System.DateTimeOffset
        
        
        :param reason: An optional human-readable reason for revocation.
        
        :type reason: System.String
    
        
        .. code-block:: csharp
    
           void RevokeAllKeys(DateTimeOffset revocationDate, string reason = null)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.KeyManagement.IKeyManager.RevokeKey(System.Guid, System.String)
    
        
    
        Revokes a specific key and persists the revocation to the underlying repository.
    
        
        
        
        :param keyId: The id of the key to revoke.
        
        :type keyId: System.Guid
        
        
        :param reason: An optional human-readable reason for revocation.
        
        :type reason: System.String
    
        
        .. code-block:: csharp
    
           void RevokeKey(Guid keyId, string reason = null)
    

