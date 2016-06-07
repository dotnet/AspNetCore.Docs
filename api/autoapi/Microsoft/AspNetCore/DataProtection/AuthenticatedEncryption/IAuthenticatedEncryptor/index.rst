

IAuthenticatedEncryptor Interface
=================================






The basic interface for providing an authenticated encryption and decryption routine.


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

    public interface IAuthenticatedEncryptor








.. dn:interface:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor.Decrypt(System.ArraySegment<System.Byte>, System.ArraySegment<System.Byte>)
    
        
    
        
        Validates the authentication tag of and decrypts a blob of encrypted data.
    
        
    
        
        :param ciphertext: The ciphertext (including authentication tag) to decrypt.
        
        :type ciphertext: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        :param additionalAuthenticatedData: Any ancillary data which was used during computation
            of the authentication tag. The same AAD must have been specified in the corresponding
            call to 'Encrypt'.
        
        :type additionalAuthenticatedData: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
        :rtype: System.Byte<System.Byte>[]
        :return: The original plaintext data (if the authentication tag was validated and decryption succeeded).
    
        
        .. code-block:: csharp
    
            byte[] Decrypt(ArraySegment<byte> ciphertext, ArraySegment<byte> additionalAuthenticatedData)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.IAuthenticatedEncryptor.Encrypt(System.ArraySegment<System.Byte>, System.ArraySegment<System.Byte>)
    
        
    
        
        Encrypts and tamper-proofs a piece of data.
    
        
    
        
        :param plaintext: The plaintext to encrypt. This input may be zero bytes in length.
        
        :type plaintext: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        :param additionalAuthenticatedData: A piece of data which will not be included in
            the returned ciphertext but which will still be covered by the authentication tag.
            This input may be zero bytes in length. The same AAD must be specified in the corresponding
            call to Decrypt.
        
        :type additionalAuthenticatedData: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
        :rtype: System.Byte<System.Byte>[]
        :return: The ciphertext blob, including authentication tag.
    
        
        .. code-block:: csharp
    
            byte[] Encrypt(ArraySegment<byte> plaintext, ArraySegment<byte> additionalAuthenticatedData)
    

