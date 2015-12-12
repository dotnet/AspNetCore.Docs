

Secret Class
============



.. contents:: 
   :local:



Summary
-------

Represents a secret value stored in memory.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.DataProtection.Secret`








Syntax
------

.. code-block:: csharp

   public sealed class Secret : ISecret, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/dataprotection/src/Microsoft.AspNet.DataProtection/Secret.cs>`_





.. dn:class:: Microsoft.AspNet.DataProtection.Secret

Constructors
------------

.. dn:class:: Microsoft.AspNet.DataProtection.Secret
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.Secret.Secret(Microsoft.AspNet.DataProtection.ISecret)
    
        
    
        Creates a new Secret from another secret object.
    
        
        
        
        :type secret: Microsoft.AspNet.DataProtection.ISecret
    
        
        .. code-block:: csharp
    
           public Secret(ISecret secret)
    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.Secret.Secret(System.ArraySegment<System.Byte>)
    
        
    
        Creates a new Secret from the provided input value, where the input value
        is specified as an array segment.
    
        
        
        
        :type value: System.ArraySegment{System.Byte}
    
        
        .. code-block:: csharp
    
           public Secret(ArraySegment<byte> value)
    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.Secret.Secret(System.Byte*, System.Int32)
    
        
    
        Creates a new Secret from the provided input value, where the input value
        is specified as a pointer to unmanaged memory.
    
        
        
        
        :type secret: System.Byte*
        
        
        :type secretLength: System.Int32
    
        
        .. code-block:: csharp
    
           public Secret(byte *secret, int secretLength)
    
    .. dn:constructor:: Microsoft.AspNet.DataProtection.Secret.Secret(System.Byte[])
    
        
    
        Creates a new Secret from the provided input value, where the input value
        is specified as an array.
    
        
        
        
        :type value: System.Byte[]
    
        
        .. code-block:: csharp
    
           public Secret(byte[] value)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.DataProtection.Secret
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.DataProtection.Secret.Dispose()
    
        
    
        Wipes the secret from memory.
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.AspNet.DataProtection.Secret.Random(System.Int32)
    
        
    
        Returns a Secret comprised entirely of random bytes retrieved from
        a cryptographically secure RNG.
    
        
        
        
        :type numBytes: System.Int32
        :rtype: Microsoft.AspNet.DataProtection.Secret
    
        
        .. code-block:: csharp
    
           public static Secret Random(int numBytes)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.Secret.WriteSecretIntoBuffer(System.ArraySegment<System.Byte>)
    
        
    
        Writes the secret value to the specified buffer.
    
        
        
        
        :type buffer: System.ArraySegment{System.Byte}
    
        
        .. code-block:: csharp
    
           public void WriteSecretIntoBuffer(ArraySegment<byte> buffer)
    
    .. dn:method:: Microsoft.AspNet.DataProtection.Secret.WriteSecretIntoBuffer(System.Byte*, System.Int32)
    
        
    
        Writes the secret value to the specified buffer.
    
        
        
        
        :param buffer: The buffer into which to write the secret value.
        
        :type buffer: System.Byte*
        
        
        :param bufferLength: The size (in bytes) of the provided buffer.
        
        :type bufferLength: System.Int32
    
        
        .. code-block:: csharp
    
           public void WriteSecretIntoBuffer(byte *buffer, int bufferLength)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.DataProtection.Secret
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.DataProtection.Secret.Length
    
        
    
        The length (in bytes) of the secret value.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Length { get; }
    

