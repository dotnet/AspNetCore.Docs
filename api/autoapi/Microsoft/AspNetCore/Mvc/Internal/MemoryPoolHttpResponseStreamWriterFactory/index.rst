

MemoryPoolHttpResponseStreamWriterFactory Class
===============================================






An :any:`Microsoft.AspNetCore.Mvc.Internal.IHttpResponseStreamWriterFactory` that uses pooled buffers.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.MemoryPoolHttpResponseStreamWriterFactory`








Syntax
------

.. code-block:: csharp

    public class MemoryPoolHttpResponseStreamWriterFactory : IHttpResponseStreamWriterFactory








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MemoryPoolHttpResponseStreamWriterFactory
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MemoryPoolHttpResponseStreamWriterFactory

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MemoryPoolHttpResponseStreamWriterFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.MemoryPoolHttpResponseStreamWriterFactory.MemoryPoolHttpResponseStreamWriterFactory(System.Buffers.ArrayPool<System.Byte>, System.Buffers.ArrayPool<System.Char>)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Internal.MemoryPoolHttpResponseStreamWriterFactory`\.
    
        
    
        
        :param bytePool: 
            The :any:`System.Buffers.ArrayPool\`1` for creating :any:`System.Byte` buffers.
        
        :type bytePool: System.Buffers.ArrayPool<System.Buffers.ArrayPool`1>{System.Byte<System.Byte>}
    
        
        :param charPool: 
            The :any:`System.Buffers.ArrayPool\`1` for creating :any:`System.Char` buffers.
        
        :type charPool: System.Buffers.ArrayPool<System.Buffers.ArrayPool`1>{System.Char<System.Char>}
    
        
        .. code-block:: csharp
    
            public MemoryPoolHttpResponseStreamWriterFactory(ArrayPool<byte> bytePool, ArrayPool<char> charPool)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MemoryPoolHttpResponseStreamWriterFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MemoryPoolHttpResponseStreamWriterFactory.CreateWriter(System.IO.Stream, System.Text.Encoding)
    
        
    
        
        :type stream: System.IO.Stream
    
        
        :type encoding: System.Text.Encoding
        :rtype: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
            public TextWriter CreateWriter(Stream stream, Encoding encoding)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MemoryPoolHttpResponseStreamWriterFactory
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.Internal.MemoryPoolHttpResponseStreamWriterFactory.DefaultBufferSize
    
        
    
        
        The default size of created char buffers.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public static readonly int DefaultBufferSize
    

