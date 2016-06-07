

NonDisposableStream Class
=========================






Stream that delegates to an inner stream.
This Stream is present so that the inner stream is not closed
even when Close() or Dispose() is called.


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
* :dn:cls:`System.MarshalByRefObject`
* :dn:cls:`System.IO.Stream`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream`








Syntax
------

.. code-block:: csharp

    public class NonDisposableStream : Stream, IDisposable








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.CanRead
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool CanRead
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.CanSeek
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool CanSeek
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.CanTimeout
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool CanTimeout
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.CanWrite
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool CanWrite
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.InnerStream
    
        
    
        
        The inner stream this object delegates to.
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
            protected Stream InnerStream
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.Length
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public override long Length
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.Position
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public override long Position
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.ReadTimeout
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int ReadTimeout
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.WriteTimeout
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int WriteTimeout
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.NonDisposableStream(System.IO.Stream)
    
        
    
        
        Initializes a new :any:`Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream`\.
    
        
    
        
        :param innerStream: The stream which should not be closed or flushed.
        
        :type innerStream: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public NonDisposableStream(Stream innerStream)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.BeginRead(System.Byte[], System.Int32, System.Int32, System.AsyncCallback, System.Object)
    
        
    
        
        :type buffer: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
    
        
        :type callback: System.AsyncCallback
    
        
        :type state: System.Object
        :rtype: System.IAsyncResult
    
        
        .. code-block:: csharp
    
            public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.BeginWrite(System.Byte[], System.Int32, System.Int32, System.AsyncCallback, System.Object)
    
        
    
        
        :type buffer: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
    
        
        :type callback: System.AsyncCallback
    
        
        :type state: System.Object
        :rtype: System.IAsyncResult
    
        
        .. code-block:: csharp
    
            public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.Close()
    
        
    
        
        .. code-block:: csharp
    
            public override void Close()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.CopyToAsync(System.IO.Stream, System.Int32, System.Threading.CancellationToken)
    
        
    
        
        :type destination: System.IO.Stream
    
        
        :type bufferSize: System.Int32
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.Dispose(System.Boolean)
    
        
    
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
            protected override void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.EndRead(System.IAsyncResult)
    
        
    
        
        :type asyncResult: System.IAsyncResult
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int EndRead(IAsyncResult asyncResult)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.EndWrite(System.IAsyncResult)
    
        
    
        
        :type asyncResult: System.IAsyncResult
    
        
        .. code-block:: csharp
    
            public override void EndWrite(IAsyncResult asyncResult)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.Flush()
    
        
    
        
        .. code-block:: csharp
    
            public override void Flush()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.FlushAsync(System.Threading.CancellationToken)
    
        
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task FlushAsync(CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.Read(System.Byte[], System.Int32, System.Int32)
    
        
    
        
        :type buffer: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Read(byte[] buffer, int offset, int count)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.ReadAsync(System.Byte[], System.Int32, System.Int32, System.Threading.CancellationToken)
    
        
    
        
        :type buffer: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.ReadByte()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int ReadByte()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.Seek(System.Int64, System.IO.SeekOrigin)
    
        
    
        
        :type offset: System.Int64
    
        
        :type origin: System.IO.SeekOrigin
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public override long Seek(long offset, SeekOrigin origin)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.SetLength(System.Int64)
    
        
    
        
        :type value: System.Int64
    
        
        .. code-block:: csharp
    
            public override void SetLength(long value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.Write(System.Byte[], System.Int32, System.Int32)
    
        
    
        
        :type buffer: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
            public override void Write(byte[] buffer, int offset, int count)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.WriteAsync(System.Byte[], System.Int32, System.Int32, System.Threading.CancellationToken)
    
        
    
        
        :type buffer: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.NonDisposableStream.WriteByte(System.Byte)
    
        
    
        
        :type value: System.Byte
    
        
        .. code-block:: csharp
    
            public override void WriteByte(byte value)
    

