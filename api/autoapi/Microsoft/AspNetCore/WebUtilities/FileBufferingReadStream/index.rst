

FileBufferingReadStream Class
=============================






A Stream that wraps another stream and enables rewinding by buffering the content as it is read.
The content is buffered in memory up to a certain size and then spooled to a temp file on disk.
The temp file will be deleted on Dispose.


Namespace
    :dn:ns:`Microsoft.AspNetCore.WebUtilities`
Assemblies
    * Microsoft.AspNetCore.WebUtilities

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.MarshalByRefObject`
* :dn:cls:`System.IO.Stream`
* :dn:cls:`Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream`








Syntax
------

.. code-block:: csharp

    public class FileBufferingReadStream : Stream, IDisposable








.. dn:class:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream
    :hidden:

.. dn:class:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream.FileBufferingReadStream(System.IO.Stream, System.Int32, System.Nullable<System.Int64>, System.Func<System.String>)
    
        
    
        
        :type inner: System.IO.Stream
    
        
        :type memoryThreshold: System.Int32
    
        
        :type bufferLimit: System.Nullable<System.Nullable`1>{System.Int64<System.Int64>}
    
        
        :type tempFileDirectoryAccessor: System.Func<System.Func`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public FileBufferingReadStream(Stream inner, int memoryThreshold, long ? bufferLimit, Func<string> tempFileDirectoryAccessor)
    
    .. dn:constructor:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream.FileBufferingReadStream(System.IO.Stream, System.Int32, System.Nullable<System.Int64>, System.Func<System.String>, System.Buffers.ArrayPool<System.Byte>)
    
        
    
        
        :type inner: System.IO.Stream
    
        
        :type memoryThreshold: System.Int32
    
        
        :type bufferLimit: System.Nullable<System.Nullable`1>{System.Int64<System.Int64>}
    
        
        :type tempFileDirectoryAccessor: System.Func<System.Func`1>{System.String<System.String>}
    
        
        :type bytePool: System.Buffers.ArrayPool<System.Buffers.ArrayPool`1>{System.Byte<System.Byte>}
    
        
        .. code-block:: csharp
    
            public FileBufferingReadStream(Stream inner, int memoryThreshold, long ? bufferLimit, Func<string> tempFileDirectoryAccessor, ArrayPool<byte> bytePool)
    
    .. dn:constructor:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream.FileBufferingReadStream(System.IO.Stream, System.Int32, System.Nullable<System.Int64>, System.String)
    
        
    
        
        :type inner: System.IO.Stream
    
        
        :type memoryThreshold: System.Int32
    
        
        :type bufferLimit: System.Nullable<System.Nullable`1>{System.Int64<System.Int64>}
    
        
        :type tempFileDirectory: System.String
    
        
        .. code-block:: csharp
    
            public FileBufferingReadStream(Stream inner, int memoryThreshold, long ? bufferLimit, string tempFileDirectory)
    
    .. dn:constructor:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream.FileBufferingReadStream(System.IO.Stream, System.Int32, System.Nullable<System.Int64>, System.String, System.Buffers.ArrayPool<System.Byte>)
    
        
    
        
        :type inner: System.IO.Stream
    
        
        :type memoryThreshold: System.Int32
    
        
        :type bufferLimit: System.Nullable<System.Nullable`1>{System.Int64<System.Int64>}
    
        
        :type tempFileDirectory: System.String
    
        
        :type bytePool: System.Buffers.ArrayPool<System.Buffers.ArrayPool`1>{System.Byte<System.Byte>}
    
        
        .. code-block:: csharp
    
            public FileBufferingReadStream(Stream inner, int memoryThreshold, long ? bufferLimit, string tempFileDirectory, ArrayPool<byte> bytePool)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream.BeginRead(System.Byte[], System.Int32, System.Int32, System.AsyncCallback, System.Object)
    
        
    
        
        :type buffer: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
    
        
        :type callback: System.AsyncCallback
    
        
        :type state: System.Object
        :rtype: System.IAsyncResult
    
        
        .. code-block:: csharp
    
            public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream.BeginWrite(System.Byte[], System.Int32, System.Int32, System.AsyncCallback, System.Object)
    
        
    
        
        :type buffer: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
    
        
        :type callback: System.AsyncCallback
    
        
        :type state: System.Object
        :rtype: System.IAsyncResult
    
        
        .. code-block:: csharp
    
            public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream.Dispose(System.Boolean)
    
        
    
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
            protected override void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream.EndRead(System.IAsyncResult)
    
        
    
        
        :type asyncResult: System.IAsyncResult
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int EndRead(IAsyncResult asyncResult)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream.EndWrite(System.IAsyncResult)
    
        
    
        
        :type asyncResult: System.IAsyncResult
    
        
        .. code-block:: csharp
    
            public override void EndWrite(IAsyncResult asyncResult)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream.Flush()
    
        
    
        
        .. code-block:: csharp
    
            public override void Flush()
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream.Read(System.Byte[], System.Int32, System.Int32)
    
        
    
        
        :type buffer: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Read(byte[] buffer, int offset, int count)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream.ReadAsync(System.Byte[], System.Int32, System.Int32, System.Threading.CancellationToken)
    
        
    
        
        :type buffer: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream.Seek(System.Int64, System.IO.SeekOrigin)
    
        
    
        
        :type offset: System.Int64
    
        
        :type origin: System.IO.SeekOrigin
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public override long Seek(long offset, SeekOrigin origin)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream.SetLength(System.Int64)
    
        
    
        
        :type value: System.Int64
    
        
        .. code-block:: csharp
    
            public override void SetLength(long value)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream.Write(System.Byte[], System.Int32, System.Int32)
    
        
    
        
        :type buffer: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
            public override void Write(byte[] buffer, int offset, int count)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream.WriteAsync(System.Byte[], System.Int32, System.Int32, System.Threading.CancellationToken)
    
        
    
        
        :type buffer: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream.CanRead
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool CanRead { get; }
    
    .. dn:property:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream.CanSeek
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool CanSeek { get; }
    
    .. dn:property:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream.CanWrite
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool CanWrite { get; }
    
    .. dn:property:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream.InMemory
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool InMemory { get; }
    
    .. dn:property:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream.Length
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public override long Length { get; }
    
    .. dn:property:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream.Position
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public override long Position { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream.TempFileName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string TempFileName { get; }
    

