

CngAuthenticatedEncryptorBase Class
===================================






Base class used for all CNG-related authentication encryption operations.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.Cng.Internal`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.DataProtection.Cng.Internal.CngAuthenticatedEncryptorBase`








Syntax
------

.. code-block:: csharp

    public abstract class CngAuthenticatedEncryptorBase : IOptimizedAuthenticatedEncryptor, IAuthenticatedEncryptor, IDisposable








.. dn:class:: Microsoft.AspNetCore.DataProtection.Cng.Internal.CngAuthenticatedEncryptorBase
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.Cng.Internal.CngAuthenticatedEncryptorBase

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.Cng.Internal.CngAuthenticatedEncryptorBase
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.Cng.Internal.CngAuthenticatedEncryptorBase.Decrypt(System.ArraySegment<System.Byte>, System.ArraySegment<System.Byte>)
    
        
    
        
        :type ciphertext: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        :type additionalAuthenticatedData: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public byte[] Decrypt(ArraySegment<byte> ciphertext, ArraySegment<byte> additionalAuthenticatedData)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.Cng.Internal.CngAuthenticatedEncryptorBase.DecryptImpl(System.Byte*, System.UInt32, System.Byte*, System.UInt32)
    
        
    
        
        :type pbCiphertext: System.Byte<System.Byte>*
    
        
        :type cbCiphertext: System.UInt32
    
        
        :type pbAdditionalAuthenticatedData: System.Byte<System.Byte>*
    
        
        :type cbAdditionalAuthenticatedData: System.UInt32
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            protected abstract byte[] DecryptImpl(byte *pbCiphertext, uint cbCiphertext, byte *pbAdditionalAuthenticatedData, uint cbAdditionalAuthenticatedData)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.Cng.Internal.CngAuthenticatedEncryptorBase.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public abstract void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.Cng.Internal.CngAuthenticatedEncryptorBase.Encrypt(System.ArraySegment<System.Byte>, System.ArraySegment<System.Byte>)
    
        
    
        
        :type plaintext: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        :type additionalAuthenticatedData: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public byte[] Encrypt(ArraySegment<byte> plaintext, ArraySegment<byte> additionalAuthenticatedData)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.Cng.Internal.CngAuthenticatedEncryptorBase.Encrypt(System.ArraySegment<System.Byte>, System.ArraySegment<System.Byte>, System.UInt32, System.UInt32)
    
        
    
        
        :type plaintext: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        :type additionalAuthenticatedData: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        :type preBufferSize: System.UInt32
    
        
        :type postBufferSize: System.UInt32
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public byte[] Encrypt(ArraySegment<byte> plaintext, ArraySegment<byte> additionalAuthenticatedData, uint preBufferSize, uint postBufferSize)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.Cng.Internal.CngAuthenticatedEncryptorBase.EncryptImpl(System.Byte*, System.UInt32, System.Byte*, System.UInt32, System.UInt32, System.UInt32)
    
        
    
        
        :type pbPlaintext: System.Byte<System.Byte>*
    
        
        :type cbPlaintext: System.UInt32
    
        
        :type pbAdditionalAuthenticatedData: System.Byte<System.Byte>*
    
        
        :type cbAdditionalAuthenticatedData: System.UInt32
    
        
        :type cbPreBuffer: System.UInt32
    
        
        :type cbPostBuffer: System.UInt32
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            protected abstract byte[] EncryptImpl(byte *pbPlaintext, uint cbPlaintext, byte *pbAdditionalAuthenticatedData, uint cbAdditionalAuthenticatedData, uint cbPreBuffer, uint cbPostBuffer)
    

