

HttpResponseStreamWriter Class
==============================



.. contents:: 
   :local:



Summary
-------

Writes to the :any:`System.IO.Stream` using the supplied :dn:prop:`Microsoft.AspNet.Mvc.HttpResponseStreamWriter.Encoding`\.
It does not write the BOM and also does not close the stream.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.MarshalByRefObject`
* :dn:cls:`System.IO.TextWriter`
* :dn:cls:`Microsoft.AspNet.Mvc.HttpResponseStreamWriter`








Syntax
------

.. code-block:: csharp

   public class HttpResponseStreamWriter : TextWriter, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/HttpResponseStreamWriter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.HttpResponseStreamWriter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.HttpResponseStreamWriter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.HttpResponseStreamWriter.HttpResponseStreamWriter(System.IO.Stream, System.Text.Encoding)
    
        
        
        
        :type stream: System.IO.Stream
        
        
        :type encoding: System.Text.Encoding
    
        
        .. code-block:: csharp
    
           public HttpResponseStreamWriter(Stream stream, Encoding encoding)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.HttpResponseStreamWriter.HttpResponseStreamWriter(System.IO.Stream, System.Text.Encoding, System.Int32)
    
        
        
        
        :type stream: System.IO.Stream
        
        
        :type encoding: System.Text.Encoding
        
        
        :type bufferSize: System.Int32
    
        
        .. code-block:: csharp
    
           public HttpResponseStreamWriter(Stream stream, Encoding encoding, int bufferSize)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.HttpResponseStreamWriter.HttpResponseStreamWriter(System.IO.Stream, System.Text.Encoding, System.Int32, Microsoft.Extensions.MemoryPool.LeasedArraySegment<System.Byte>, Microsoft.Extensions.MemoryPool.LeasedArraySegment<System.Char>)
    
        
        
        
        :type stream: System.IO.Stream
        
        
        :type encoding: System.Text.Encoding
        
        
        :type bufferSize: System.Int32
        
        
        :type leasedByteBuffer: Microsoft.Extensions.MemoryPool.LeasedArraySegment{System.Byte}
        
        
        :type leasedCharBuffer: Microsoft.Extensions.MemoryPool.LeasedArraySegment{System.Char}
    
        
        .. code-block:: csharp
    
           public HttpResponseStreamWriter(Stream stream, Encoding encoding, int bufferSize, LeasedArraySegment<byte> leasedByteBuffer, LeasedArraySegment<char> leasedCharBuffer)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.HttpResponseStreamWriter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.HttpResponseStreamWriter.Dispose(System.Boolean)
    
        
        
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
           protected override void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNet.Mvc.HttpResponseStreamWriter.Flush()
    
        
    
        
        .. code-block:: csharp
    
           public override void Flush()
    
    .. dn:method:: Microsoft.AspNet.Mvc.HttpResponseStreamWriter.FlushAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task FlushAsync()
    
    .. dn:method:: Microsoft.AspNet.Mvc.HttpResponseStreamWriter.Write(System.Char)
    
        
        
        
        :type value: System.Char
    
        
        .. code-block:: csharp
    
           public override void Write(char value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.HttpResponseStreamWriter.Write(System.Char[], System.Int32, System.Int32)
    
        
        
        
        :type values: System.Char[]
        
        
        :type index: System.Int32
        
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
           public override void Write(char[] values, int index, int count)
    
    .. dn:method:: Microsoft.AspNet.Mvc.HttpResponseStreamWriter.Write(System.String)
    
        
        
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           public override void Write(string value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.HttpResponseStreamWriter.WriteAsync(System.Char)
    
        
        
        
        :type value: System.Char
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task WriteAsync(char value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.HttpResponseStreamWriter.WriteAsync(System.Char[], System.Int32, System.Int32)
    
        
        
        
        :type values: System.Char[]
        
        
        :type index: System.Int32
        
        
        :type count: System.Int32
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task WriteAsync(char[] values, int index, int count)
    
    .. dn:method:: Microsoft.AspNet.Mvc.HttpResponseStreamWriter.WriteAsync(System.String)
    
        
        
        
        :type value: System.String
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task WriteAsync(string value)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Mvc.HttpResponseStreamWriter
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.HttpResponseStreamWriter.DefaultBufferSize
    
        
    
        Default buffer size.
    
        
    
        
        .. code-block:: csharp
    
           public const int DefaultBufferSize
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.HttpResponseStreamWriter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.HttpResponseStreamWriter.Encoding
    
        
        :rtype: System.Text.Encoding
    
        
        .. code-block:: csharp
    
           public override Encoding Encoding { get; }
    

