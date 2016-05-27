

KeyDerivationPrf Enum
=====================






Specifies the PRF which should be used for the key derivation algorithm.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Cryptography.KeyDerivation`
Assemblies
    * Microsoft.AspNetCore.Cryptography.KeyDerivation

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public enum KeyDerivationPrf








.. dn:enumeration:: Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivationPrf
    :hidden:

.. dn:enumeration:: Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivationPrf

Fields
------

.. dn:enumeration:: Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivationPrf
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivationPrf.HMACSHA1
    
        
    
        
        The HMAC algorithm (RFC 2104) using the SHA-1 hash function (FIPS 180-4).
    
        
        :rtype: Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivationPrf
    
        
        .. code-block:: csharp
    
            HMACSHA1 = 0
    
    .. dn:field:: Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivationPrf.HMACSHA256
    
        
    
        
        The HMAC algorithm (RFC 2104) using the SHA-256 hash function (FIPS 180-4).
    
        
        :rtype: Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivationPrf
    
        
        .. code-block:: csharp
    
            HMACSHA256 = 1
    
    .. dn:field:: Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivationPrf.HMACSHA512
    
        
    
        
        The HMAC algorithm (RFC 2104) using the SHA-512 hash function (FIPS 180-4).
    
        
        :rtype: Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivationPrf
    
        
        .. code-block:: csharp
    
            HMACSHA512 = 2
    

