

MemoryPoolHttpRequestStreamReaderFactory Class
==============================================






An :any:`Microsoft.AspNetCore.Mvc.Internal.IHttpRequestStreamReaderFactory` that uses pooled buffers.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.MemoryPoolHttpRequestStreamReaderFactory`








Syntax
------

.. code-block:: csharp

    public class MemoryPoolHttpRequestStreamReaderFactory : IHttpRequestStreamReaderFactory








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MemoryPoolHttpRequestStreamReaderFactory
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MemoryPoolHttpRequestStreamReaderFactory

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MemoryPoolHttpRequestStreamReaderFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.MemoryPoolHttpRequestStreamReaderFactory.MemoryPoolHttpRequestStreamReaderFactory(System.Buffers.ArrayPool<System.Byte>, System.Buffers.ArrayPool<System.Char>)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Internal.MemoryPoolHttpRequestStreamReaderFactory`\.
    
        
    
        
        :param bytePool: 
            The :any:`System.Buffers.ArrayPool\`1` for creating :any:`byte[]` buffers.
        
        :type bytePool: System.Buffers.ArrayPool<System.Buffers.ArrayPool`1>{System.Byte<System.Byte>}
    
        
        :param charPool: 
            The :any:`System.Buffers.ArrayPool\`1` for creating :any:`char[]` buffers.
        
        :type charPool: System.Buffers.ArrayPool<System.Buffers.ArrayPool`1>{System.Char<System.Char>}
    
        
        .. code-block:: csharp
    
            public MemoryPoolHttpRequestStreamReaderFactory(ArrayPool<byte> bytePool, ArrayPool<char> charPool)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MemoryPoolHttpRequestStreamReaderFactory
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.Internal.MemoryPoolHttpRequestStreamReaderFactory.DefaultBufferSize
    
        
    
        
        The default size of created char buffers.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public static readonly int DefaultBufferSize
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MemoryPoolHttpRequestStreamReaderFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MemoryPoolHttpRequestStreamReaderFactory.CreateReader(System.IO.Stream, System.Text.Encoding)
    
        
    
        
        :type stream: System.IO.Stream
    
        
        :type encoding: System.Text.Encoding
        :rtype: System.IO.TextReader
    
        
        .. code-block:: csharp
    
            public TextReader CreateReader(Stream stream, Encoding encoding)
    

