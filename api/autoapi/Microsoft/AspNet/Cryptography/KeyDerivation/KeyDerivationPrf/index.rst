

KeyDerivationPrf Enum
=====================



.. contents:: 
   :local:



Summary
-------

Specifies the PRF which should be used for the key derivation algorithm.











Syntax
------

.. code-block:: csharp

   public enum KeyDerivationPrf





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.Cryptography.KeyDerivation/KeyDerivationPrf.cs>`_





.. dn:enumeration:: Microsoft.AspNet.Cryptography.KeyDerivation.KeyDerivationPrf

Fields
------

.. dn:enumeration:: Microsoft.AspNet.Cryptography.KeyDerivation.KeyDerivationPrf
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Cryptography.KeyDerivation.KeyDerivationPrf.HMACSHA1
    
        
    
        The HMAC algorithm (RFC 2104) using the SHA-1 hash function (FIPS 180-4).
    
        
    
        
        .. code-block:: csharp
    
           HMACSHA1 = 0
    
    .. dn:field:: Microsoft.AspNet.Cryptography.KeyDerivation.KeyDerivationPrf.HMACSHA256
    
        
    
        The HMAC algorithm (RFC 2104) using the SHA-256 hash function (FIPS 180-4).
    
        
    
        
        .. code-block:: csharp
    
           HMACSHA256 = 1
    
    .. dn:field:: Microsoft.AspNet.Cryptography.KeyDerivation.KeyDerivationPrf.HMACSHA512
    
        
    
        The HMAC algorithm (RFC 2104) using the SHA-512 hash function (FIPS 180-4).
    
        
    
        
        .. code-block:: csharp
    
           HMACSHA512 = 2
    

