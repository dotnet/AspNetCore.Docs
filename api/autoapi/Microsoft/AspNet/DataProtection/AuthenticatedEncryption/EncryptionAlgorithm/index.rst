

EncryptionAlgorithm Enum
========================



.. contents:: 
   :local:



Summary
-------

Specifies a symmetric encryption algorithm to use for providing confidentiality
to protected payloads.











Syntax
------

.. code-block:: csharp

   public enum EncryptionAlgorithm





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/dataprotection/src/Microsoft.AspNet.DataProtection/AuthenticatedEncryption/EncryptionAlgorithm.cs>`_





.. dn:enumeration:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm

Fields
------

.. dn:enumeration:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm.AES_128_CBC
    
        
    
        The AES algorithm (FIPS 197) with a 128-bit key running in Cipher Block Chaining mode.
    
        
    
        
        .. code-block:: csharp
    
           AES_128_CBC = 0
    
    .. dn:field:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm.AES_128_GCM
    
        
    
        The AES algorithm (FIPS 197) with a 128-bit key running in Galois/Counter Mode (FIPS SP 800-38D).
    
        
    
        
        .. code-block:: csharp
    
           AES_128_GCM = 3
    
    .. dn:field:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm.AES_192_CBC
    
        
    
        The AES algorithm (FIPS 197) with a 192-bit key running in Cipher Block Chaining mode.
    
        
    
        
        .. code-block:: csharp
    
           AES_192_CBC = 1
    
    .. dn:field:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm.AES_192_GCM
    
        
    
        The AES algorithm (FIPS 197) with a 192-bit key running in Galois/Counter Mode (FIPS SP 800-38D).
    
        
    
        
        .. code-block:: csharp
    
           AES_192_GCM = 4
    
    .. dn:field:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm.AES_256_CBC
    
        
    
        The AES algorithm (FIPS 197) with a 256-bit key running in Cipher Block Chaining mode.
    
        
    
        
        .. code-block:: csharp
    
           AES_256_CBC = 2
    
    .. dn:field:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm.AES_256_GCM
    
        
    
        The AES algorithm (FIPS 197) with a 256-bit key running in Galois/Counter Mode (FIPS SP 800-38D).
    
        
    
        
        .. code-block:: csharp
    
           AES_256_GCM = 5
    

