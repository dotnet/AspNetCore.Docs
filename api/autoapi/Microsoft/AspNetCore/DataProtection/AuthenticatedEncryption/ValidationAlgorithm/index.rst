

ValidationAlgorithm Enum
========================






Specifies a message authentication algorithm to use for providing tamper-proofing
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

    public enum ValidationAlgorithm








.. dn:enumeration:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ValidationAlgorithm
    :hidden:

.. dn:enumeration:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ValidationAlgorithm

Fields
------

.. dn:enumeration:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ValidationAlgorithm
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ValidationAlgorithm.HMACSHA256
    
        
    
        
        The HMAC algorithm (RFC 2104) using the SHA-256 hash function (FIPS 180-4).
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ValidationAlgorithm
    
        
        .. code-block:: csharp
    
            HMACSHA256 = 0
    
    .. dn:field:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ValidationAlgorithm.HMACSHA512
    
        
    
        
        The HMAC algorithm (RFC 2104) using the SHA-512 hash function (FIPS 180-4).
    
        
        :rtype: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ValidationAlgorithm
    
        
        .. code-block:: csharp
    
            HMACSHA512 = 1
    

