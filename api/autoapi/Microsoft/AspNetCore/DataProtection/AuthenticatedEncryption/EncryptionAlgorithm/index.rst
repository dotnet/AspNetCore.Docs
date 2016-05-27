

EncryptionAlgorithm Enum
========================






Specifies a symmetric encryption algorithm to use for providing confidentiality
to protected payloads.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public enum EncryptionAlgorithm








.. dn:enumeration:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm
    :hidden:

.. dn:enumeration:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm

Fields
------

.. dn:enumeration:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm.AES_128_CBC
    
        
    
        
        The AES algorithm (FIPS 197) with a 128-bit key running in Cipher Block Chaining mode.
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm
    
        
        .. code-block:: csharp
    
            AES_128_CBC = 0
    
    .. dn:field:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm.AES_128_GCM
    
        
    
        
        The AES algorithm (FIPS 197) with a 128-bit key running in Galois/Counter Mode (FIPS SP 800-38D).
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm
    
        
        .. code-block:: csharp
    
            AES_128_GCM = 3
    
    .. dn:field:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm.AES_192_CBC
    
        
    
        
        The AES algorithm (FIPS 197) with a 192-bit key running in Cipher Block Chaining mode.
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm
    
        
        .. code-block:: csharp
    
            AES_192_CBC = 1
    
    .. dn:field:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm.AES_192_GCM
    
        
    
        
        The AES algorithm (FIPS 197) with a 192-bit key running in Galois/Counter Mode (FIPS SP 800-38D).
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm
    
        
        .. code-block:: csharp
    
            AES_192_GCM = 4
    
    .. dn:field:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm.AES_256_CBC
    
        
    
        
        The AES algorithm (FIPS 197) with a 256-bit key running in Cipher Block Chaining mode.
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm
    
        
        .. code-block:: csharp
    
            AES_256_CBC = 2
    
    .. dn:field:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm.AES_256_GCM
    
        
    
        
        The AES algorithm (FIPS 197) with a 256-bit key running in Galois/Counter Mode (FIPS SP 800-38D).
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm
    
        
        .. code-block:: csharp
    
            AES_256_GCM = 5
    

