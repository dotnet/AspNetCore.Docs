

BinaryBlob Class
================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Antiforgery.BinaryBlob`








Syntax
------

.. code-block:: csharp

   public sealed class BinaryBlob : IEquatable<BinaryBlob>





GitHub
------

`View on GitHub <https://github.com/aspnet/antiforgery/blob/master/src/Microsoft.AspNet.Antiforgery/BinaryBlob.cs>`_





.. dn:class:: Microsoft.AspNet.Antiforgery.BinaryBlob

Constructors
------------

.. dn:class:: Microsoft.AspNet.Antiforgery.BinaryBlob
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Antiforgery.BinaryBlob.BinaryBlob(System.Int32)
    
        
        
        
        :type bitLength: System.Int32
    
        
        .. code-block:: csharp
    
           public BinaryBlob(int bitLength)
    
    .. dn:constructor:: Microsoft.AspNet.Antiforgery.BinaryBlob.BinaryBlob(System.Int32, System.Byte[])
    
        
        
        
        :type bitLength: System.Int32
        
        
        :type data: System.Byte[]
    
        
        .. code-block:: csharp
    
           public BinaryBlob(int bitLength, byte[] data)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Antiforgery.BinaryBlob
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Antiforgery.BinaryBlob.Equals(Microsoft.AspNet.Antiforgery.BinaryBlob)
    
        
        
        
        :type other: Microsoft.AspNet.Antiforgery.BinaryBlob
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Equals(BinaryBlob other)
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.BinaryBlob.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.BinaryBlob.GetData()
    
        
        :rtype: System.Byte[]
    
        
        .. code-block:: csharp
    
           public byte[] GetData()
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.BinaryBlob.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Antiforgery.BinaryBlob
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Antiforgery.BinaryBlob.BitLength
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int BitLength { get; }
    

