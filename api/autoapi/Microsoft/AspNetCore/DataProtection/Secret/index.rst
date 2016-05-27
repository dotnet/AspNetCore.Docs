

Secret Class
============






Represents a secret value stored in memory.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.DataProtection.Secret`








Syntax
------

.. code-block:: csharp

    public sealed class Secret : ISecret, IDisposable








.. dn:class:: Microsoft.AspNetCore.DataProtection.Secret
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.Secret

Properties
----------

.. dn:class:: Microsoft.AspNetCore.DataProtection.Secret
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.Secret.Length
    
        
    
        
        The length (in bytes) of the secret value.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Length
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.DataProtection.Secret
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.Secret.Secret(Microsoft.AspNetCore.DataProtection.ISecret)
    
        
    
        
        Creates a new Secret from another secret object.
    
        
    
        
        :type secret: Microsoft.AspNetCore.DataProtection.ISecret
    
        
        .. code-block:: csharp
    
            public Secret(ISecret secret)
    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.Secret.Secret(System.ArraySegment<System.Byte>)
    
        
    
        
        Creates a new Secret from the provided input value, where the input value
        is specified as an array segment.
    
        
    
        
        :type value: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        .. code-block:: csharp
    
            public Secret(ArraySegment<byte> value)
    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.Secret.Secret(System.Byte*, System.Int32)
    
        
    
        
        Creates a new Secret from the provided input value, where the input value
        is specified as a pointer to unmanaged memory.
    
        
    
        
        :type secret: System.Byte<System.Byte>*
    
        
        :type secretLength: System.Int32
    
        
        .. code-block:: csharp
    
            public Secret(byte *secret, int secretLength)
    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.Secret.Secret(System.Byte[])
    
        
    
        
        Creates a new Secret from the provided input value, where the input value
        is specified as an array.
    
        
    
        
        :type value: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public Secret(byte[] value)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.DataProtection.Secret
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.Secret.Dispose()
    
        
    
        
        Wipes the secret from memory.
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.Secret.Random(System.Int32)
    
        
    
        
        Returns a Secret comprised entirely of random bytes retrieved from
        a cryptographically secure RNG.
    
        
    
        
        :type numBytes: System.Int32
        :rtype: Microsoft.AspNetCore.DataProtection.Secret
    
        
        .. code-block:: csharp
    
            public static Secret Random(int numBytes)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.Secret.WriteSecretIntoBuffer(System.ArraySegment<System.Byte>)
    
        
    
        
        Writes the secret value to the specified buffer.
    
        
    
        
        :type buffer: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        .. code-block:: csharp
    
            public void WriteSecretIntoBuffer(ArraySegment<byte> buffer)
    
    .. dn:method:: Microsoft.AspNetCore.DataProtection.Secret.WriteSecretIntoBuffer(System.Byte*, System.Int32)
    
        
    
        
        Writes the secret value to the specified buffer.
    
        
    
        
        :param buffer: The buffer into which to write the secret value.
        
        :type buffer: System.Byte<System.Byte>*
    
        
        :param bufferLength: The size (in bytes) of the provided buffer.
        
        :type bufferLength: System.Int32
    
        
        .. code-block:: csharp
    
            public void WriteSecretIntoBuffer(byte *buffer, int bufferLength)
    

