

ValidationAlgorithm Enum
========================



.. contents:: 
   :local:



Summary
-------

Specifies a message authentication algorithm to use for providing tamper-proofing
to protected payloads.











Syntax
------

.. code-block:: csharp

   public enum ValidationAlgorithm





GitHub
------

`View on GitHub <https://github.com/aspnet/dataprotection/blob/master/src/Microsoft.AspNet.DataProtection/AuthenticatedEncryption/ValidationAlgorithm.cs>`_





.. dn:enumeration:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ValidationAlgorithm

Fields
------

.. dn:enumeration:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ValidationAlgorithm
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ValidationAlgorithm.HMACSHA256
    
        
    
        The HMAC algorithm (RFC 2104) using the SHA-256 hash function (FIPS 180-4).
    
        
    
        
        .. code-block:: csharp
    
           HMACSHA256 = 0
    
    .. dn:field:: Microsoft.AspNet.DataProtection.AuthenticatedEncryption.ValidationAlgorithm.HMACSHA512
    
        
    
        The HMAC algorithm (RFC 2104) using the SHA-512 hash function (FIPS 180-4).
    
        
    
        
        .. code-block:: csharp
    
           HMACSHA512 = 1
    

