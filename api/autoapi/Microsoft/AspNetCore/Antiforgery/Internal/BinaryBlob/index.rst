

BinaryBlob Class
================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Antiforgery.Internal`
Assemblies
    * Microsoft.AspNetCore.Antiforgery

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Antiforgery.Internal.BinaryBlob`








Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("{DebuggerString}")]
    public sealed class BinaryBlob : IEquatable<BinaryBlob>








.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.BinaryBlob
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.BinaryBlob

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.BinaryBlob
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Antiforgery.Internal.BinaryBlob.BitLength
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int BitLength
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.BinaryBlob
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Antiforgery.Internal.BinaryBlob.BinaryBlob(System.Int32)
    
        
    
        
        :type bitLength: System.Int32
    
        
        .. code-block:: csharp
    
            public BinaryBlob(int bitLength)
    
    .. dn:constructor:: Microsoft.AspNetCore.Antiforgery.Internal.BinaryBlob.BinaryBlob(System.Int32, System.Byte[])
    
        
    
        
        :type bitLength: System.Int32
    
        
        :type data: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public BinaryBlob(int bitLength, byte[] data)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.BinaryBlob
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.BinaryBlob.Equals(Microsoft.AspNetCore.Antiforgery.Internal.BinaryBlob)
    
        
    
        
        :type other: Microsoft.AspNetCore.Antiforgery.Internal.BinaryBlob
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Equals(BinaryBlob other)
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.BinaryBlob.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.BinaryBlob.GetData()
    
        
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public byte[] GetData()
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.BinaryBlob.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    

