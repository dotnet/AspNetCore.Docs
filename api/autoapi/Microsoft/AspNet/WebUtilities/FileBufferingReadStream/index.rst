

FileBufferingReadStream Class
=============================



.. contents:: 
   :local:



Summary
-------

A Stream that wraps another stream and enables rewinding by buffering the content as it is read.
The content is buffered in memory up to a certain size and then spooled to a temp file on disk.
The temp file will be deleted on Dispose.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.MarshalByRefObject`
* :dn:cls:`System.IO.Stream`
* :dn:cls:`Microsoft.AspNet.WebUtilities.FileBufferingReadStream`








Syntax
------

.. code-block:: csharp

   public class FileBufferingReadStream : Stream, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.WebUtilities/FileBufferingReadStream.cs>`_





.. dn:class:: Microsoft.AspNet.WebUtilities.FileBufferingReadStream

Constructors
------------

.. dn:class:: Microsoft.AspNet.WebUtilities.FileBufferingReadStream
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.WebUtilities.FileBufferingReadStream.FileBufferingReadStream(System.IO.Stream, System.Int32, System.Func<System.String>)
    
        
        
        
        :type inner: System.IO.Stream
        
        
        :type memoryThreshold: System.Int32
        
        
        :type tempFileDirectoryAccessor: System.Func{System.String}
    
        
        .. code-block:: csharp
    
           public FileBufferingReadStream(Stream inner, int memoryThreshold, Func<string> tempFileDirectoryAccessor)
    
    .. dn:constructor:: Microsoft.AspNet.WebUtilities.FileBufferingReadStream.FileBufferingReadStream(System.IO.Stream, System.Int32, System.String)
    
        
        
        
        :type inner: System.IO.Stream
        
        
        :type memoryThreshold: System.Int32
        
        
        :type tempFileDirectory: System.String
    
        
        .. code-block:: csharp
    
           public FileBufferingReadStream(Stream inner, int memoryThreshold, string tempFileDirectory)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.WebUtilities.FileBufferingReadStream
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.WebUtilities.FileBufferingReadStream.Dispose(System.Boolean)
    
        
        
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
           protected override void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNet.WebUtilities.FileBufferingReadStream.Flush()
    
        
    
        
        .. code-block:: csharp
    
           public override void Flush()
    
    .. dn:method:: Microsoft.AspNet.WebUtilities.FileBufferingReadStream.Read(System.Byte[], System.Int32, System.Int32)
    
        
        
        
        :type buffer: System.Byte[]
        
        
        :type offset: System.Int32
        
        
        :type count: System.Int32
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Read(byte[] buffer, int offset, int count)
    
    .. dn:method:: Microsoft.AspNet.WebUtilities.FileBufferingReadStream.ReadAsync(System.Byte[], System.Int32, System.Int32, System.Threading.CancellationToken)
    
        
        
        
        :type buffer: System.Byte[]
        
        
        :type offset: System.Int32
        
        
        :type count: System.Int32
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Int32}
    
        
        .. code-block:: csharp
    
           public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.WebUtilities.FileBufferingReadStream.Seek(System.Int64, System.IO.SeekOrigin)
    
        
        
        
        :type offset: System.Int64
        
        
        :type origin: System.IO.SeekOrigin
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
           public override long Seek(long offset, SeekOrigin origin)
    
    .. dn:method:: Microsoft.AspNet.WebUtilities.FileBufferingReadStream.SetLength(System.Int64)
    
        
        
        
        :type value: System.Int64
    
        
        .. code-block:: csharp
    
           public override void SetLength(long value)
    
    .. dn:method:: Microsoft.AspNet.WebUtilities.FileBufferingReadStream.Write(System.Byte[], System.Int32, System.Int32)
    
        
        
        
        :type buffer: System.Byte[]
        
        
        :type offset: System.Int32
        
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
           public override void Write(byte[] buffer, int offset, int count)
    
    .. dn:method:: Microsoft.AspNet.WebUtilities.FileBufferingReadStream.WriteAsync(System.Byte[], System.Int32, System.Int32, System.Threading.CancellationToken)
    
        
        
        
        :type buffer: System.Byte[]
        
        
        :type offset: System.Int32
        
        
        :type count: System.Int32
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.WebUtilities.FileBufferingReadStream
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.WebUtilities.FileBufferingReadStream.CanRead
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool CanRead { get; }
    
    .. dn:property:: Microsoft.AspNet.WebUtilities.FileBufferingReadStream.CanSeek
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool CanSeek { get; }
    
    .. dn:property:: Microsoft.AspNet.WebUtilities.FileBufferingReadStream.CanWrite
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool CanWrite { get; }
    
    .. dn:property:: Microsoft.AspNet.WebUtilities.FileBufferingReadStream.Length
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
           public override long Length { get; }
    
    .. dn:property:: Microsoft.AspNet.WebUtilities.FileBufferingReadStream.Position
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
           public override long Position { get; set; }
    

