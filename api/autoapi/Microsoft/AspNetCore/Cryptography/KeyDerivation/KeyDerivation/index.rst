

KeyDerivation Class
===================






Provides algorithms for performing key derivation.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Cryptography.KeyDerivation`
Assemblies
    * Microsoft.AspNetCore.Cryptography.KeyDerivation

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivation`








Syntax
------

.. code-block:: csharp

    public class KeyDerivation








.. dn:class:: Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivation
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivation

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivation
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivation.Pbkdf2(System.String, System.Byte[], Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivationPrf, System.Int32, System.Int32)
    
        
    
        
        Performs key derivation using the PBKDF2 algorithm.
    
        
    
        
        :param password: The password from which to derive the key.
        
        :type password: System.String
    
        
        :param salt: The salt to be used during the key derivation process.
        
        :type salt: System.Byte<System.Byte>[]
    
        
        :param prf: The pseudo-random function to be used in the key derivation process.
        
        :type prf: Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivationPrf
    
        
        :param iterationCount: The number of iterations of the pseudo-random function to apply
            during the key derivation process.
        
        :type iterationCount: System.Int32
    
        
        :param numBytesRequested: The desired length (in bytes) of the derived key.
        
        :type numBytesRequested: System.Int32
        :rtype: System.Byte<System.Byte>[]
        :return: The derived key.
    
        
        .. code-block:: csharp
    
            public static byte[] Pbkdf2(string password, byte[] salt, KeyDerivationPrf prf, int iterationCount, int numBytesRequested)
    

