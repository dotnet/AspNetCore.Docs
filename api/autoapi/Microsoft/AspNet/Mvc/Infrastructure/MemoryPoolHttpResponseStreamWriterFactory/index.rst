

MemoryPoolHttpResponseStreamWriterFactory Class
===============================================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Mvc.Infrastructure.IHttpResponseStreamWriterFactory` that uses pooled buffers.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Infrastructure.MemoryPoolHttpResponseStreamWriterFactory`








Syntax
------

.. code-block:: csharp

   public class MemoryPoolHttpResponseStreamWriterFactory : IHttpResponseStreamWriterFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Infrastructure/MemoryPoolHttpResponseStreamWriterFactory.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.MemoryPoolHttpResponseStreamWriterFactory

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.MemoryPoolHttpResponseStreamWriterFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Infrastructure.MemoryPoolHttpResponseStreamWriterFactory.MemoryPoolHttpResponseStreamWriterFactory(Microsoft.Extensions.MemoryPool.IArraySegmentPool<System.Byte>, Microsoft.Extensions.MemoryPool.IArraySegmentPool<System.Char>)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.Infrastructure.MemoryPoolHttpResponseStreamWriterFactory`\.
    
        
        
        
        :param bytePool: The  for creating  buffers.
        
        :type bytePool: Microsoft.Extensions.MemoryPool.IArraySegmentPool{System.Byte}
        
        
        :param charPool: The  for creating  buffers.
        
        :type charPool: Microsoft.Extensions.MemoryPool.IArraySegmentPool{System.Char}
    
        
        .. code-block:: csharp
    
           public MemoryPoolHttpResponseStreamWriterFactory(IArraySegmentPool<byte> bytePool, IArraySegmentPool<char> charPool)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.MemoryPoolHttpResponseStreamWriterFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Infrastructure.MemoryPoolHttpResponseStreamWriterFactory.CreateWriter(System.IO.Stream, System.Text.Encoding)
    
        
        
        
        :type stream: System.IO.Stream
        
        
        :type encoding: System.Text.Encoding
        :rtype: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           public TextWriter CreateWriter(Stream stream, Encoding encoding)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.MemoryPoolHttpResponseStreamWriterFactory
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.Infrastructure.MemoryPoolHttpResponseStreamWriterFactory.DefaultBufferSize
    
        
    
        The default size of created char buffers.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly int DefaultBufferSize
    

