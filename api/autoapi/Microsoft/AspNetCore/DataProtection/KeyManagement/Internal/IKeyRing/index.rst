

IKeyRing Interface
==================






The basic interface for accessing a read-only keyring.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.KeyManagement.Internal`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IKeyRing








.. dn:interface:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IKeyRing
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IKeyRing

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IKeyRing
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IKeyRing.DefaultAuthenticatedEncryptor
    
        
    
        
        The authenticated encryptor that shall be used for new encryption operations.
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor
    
        
        .. code-block:: csharp
    
            IAuthenticatedEncryptor DefaultAuthenticatedEncryptor { get; }
    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IKeyRing.DefaultKeyId
    
        
    
        
        The id of the key associated with :dn:prop:`Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IKeyRing.DefaultAuthenticatedEncryptor`\.
    
        
        :rtype: System.Guid
    
        
        .. code-block:: csharp
    
            Guid DefaultKeyId { get; }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IKeyRing
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.KeyManagement.Internal.IKeyRing.GetAuthenticatedEncryptorByKeyId(System.Guid, out System.Boolean)
    
        
    
        
        Returns an encryptor instance for the given key, or 'null' if the key with the
        specified id cannot be found in the keyring.
    
        
    
        
        :type keyId: System.Guid
    
        
        :type isRevoked: System.Boolean
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor
    
        
        .. code-block:: csharp
    
            IAuthenticatedEncryptor GetAuthenticatedEncryptorByKeyId(Guid keyId, out bool isRevoked)
    

