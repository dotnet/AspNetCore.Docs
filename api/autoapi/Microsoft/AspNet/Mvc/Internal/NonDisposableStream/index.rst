

NonDisposableStream Class
=========================



.. contents:: 
   :local:



Summary
-------

Stream that delegates to an inner stream.
This Stream is present so that the inner stream is not closed
even when Close() or Dispose() is called.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.MarshalByRefObject`
* :dn:cls:`System.IO.Stream`
* :dn:cls:`Microsoft.AspNet.Mvc.Internal.NonDisposableStream`








Syntax
------

.. code-block:: csharp

   public class NonDisposableStream : Stream, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Internal/NonDisposableStream.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Internal.NonDisposableStream

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Internal.NonDisposableStream
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Internal.NonDisposableStream.NonDisposableStream(System.IO.Stream)
    
        
    
        Initializes a new :any:`Microsoft.AspNet.Mvc.Internal.NonDisposableStream`\.
    
        
        
        
        :param innerStream: The stream which should not be closed or flushed.
        
        :type innerStream: System.IO.Stream
    
        
        .. code-block:: csharp
    
           public NonDisposableStream(Stream innerStream)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Internal.NonDisposableStream
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.NonDisposableStream.CopyToAsync(System.IO.Stream, System.Int32, System.Threading.CancellationToken)
    
        
        
        
        :type destination: System.IO.Stream
        
        
        :type bufferSize: System.Int32
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.NonDisposableStream.Dispose(System.Boolean)
    
        
        
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
           protected override void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.NonDisposableStream.Flush()
    
        
    
        
        .. code-block:: csharp
    
           public override void Flush()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.NonDisposableStream.FlushAsync(System.Threading.CancellationToken)
    
        
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task FlushAsync(CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.NonDisposableStream.Read(System.Byte[], System.Int32, System.Int32)
    
        
        
        
        :type buffer: System.Byte[]
        
        
        :type offset: System.Int32
        
        
        :type count: System.Int32
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Read(byte[] buffer, int offset, int count)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.NonDisposableStream.ReadAsync(System.Byte[], System.Int32, System.Int32, System.Threading.CancellationToken)
    
        
        
        
        :type buffer: System.Byte[]
        
        
        :type offset: System.Int32
        
        
        :type count: System.Int32
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Int32}
    
        
        .. code-block:: csharp
    
           public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.NonDisposableStream.ReadByte()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int ReadByte()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.NonDisposableStream.Seek(System.Int64, System.IO.SeekOrigin)
    
        
        
        
        :type offset: System.Int64
        
        
        :type origin: System.IO.SeekOrigin
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
           public override long Seek(long offset, SeekOrigin origin)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.NonDisposableStream.SetLength(System.Int64)
    
        
        
        
        :type value: System.Int64
    
        
        .. code-block:: csharp
    
           public override void SetLength(long value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.NonDisposableStream.Write(System.Byte[], System.Int32, System.Int32)
    
        
        
        
        :type buffer: System.Byte[]
        
        
        :type offset: System.Int32
        
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
           public override void Write(byte[] buffer, int offset, int count)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.NonDisposableStream.WriteAsync(System.Byte[], System.Int32, System.Int32, System.Threading.CancellationToken)
    
        
        
        
        :type buffer: System.Byte[]
        
        
        :type offset: System.Int32
        
        
        :type count: System.Int32
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.NonDisposableStream.WriteByte(System.Byte)
    
        
        
        
        :type value: System.Byte
    
        
        .. code-block:: csharp
    
           public override void WriteByte(byte value)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Internal.NonDisposableStream
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.NonDisposableStream.CanRead
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool CanRead { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.NonDisposableStream.CanSeek
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool CanSeek { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.NonDisposableStream.CanTimeout
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool CanTimeout { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.NonDisposableStream.CanWrite
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool CanWrite { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.NonDisposableStream.InnerStream
    
        
    
        The inner stream this object delegates to.
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
           protected Stream InnerStream { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.NonDisposableStream.Length
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
           public override long Length { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.NonDisposableStream.Position
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
           public override long Position { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.NonDisposableStream.ReadTimeout
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int ReadTimeout { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Internal.NonDisposableStream.WriteTimeout
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int WriteTimeout { get; set; }
    

