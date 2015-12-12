

SocketInputStream Class
=======================



.. contents:: 
   :local:



Summary
-------

This is a write-only stream that copies what is written into a 
:any:`Microsoft.AspNet.Server.Kestrel.Http.SocketInput` object. This is used as an argument to 
:dn:meth:`System.IO.Stream.CopyToAsync(System.IO.Stream)` so input filtered by a
ConnectionFilter (e.g. SslStream) can be consumed by :any:`Microsoft.AspNet.Server.Kestrel.Http.Frame`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.MarshalByRefObject`
* :dn:cls:`System.IO.Stream`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Filter.SocketInputStream`








Syntax
------

.. code-block:: csharp

   public class SocketInputStream : Stream, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel/Filter/SocketInputStream.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Filter.SocketInputStream

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Filter.SocketInputStream
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Filter.SocketInputStream.SocketInputStream(Microsoft.AspNet.Server.Kestrel.Http.SocketInput)
    
        
        
        
        :type socketInput: Microsoft.AspNet.Server.Kestrel.Http.SocketInput
    
        
        .. code-block:: csharp
    
           public SocketInputStream(SocketInput socketInput)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Filter.SocketInputStream
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Filter.SocketInputStream.Dispose(System.Boolean)
    
        
        
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
           protected override void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Filter.SocketInputStream.Flush()
    
        
    
        
        .. code-block:: csharp
    
           public override void Flush()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Filter.SocketInputStream.Read(System.Byte[], System.Int32, System.Int32)
    
        
        
        
        :type buffer: System.Byte[]
        
        
        :type offset: System.Int32
        
        
        :type count: System.Int32
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Read(byte[] buffer, int offset, int count)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Filter.SocketInputStream.Seek(System.Int64, System.IO.SeekOrigin)
    
        
        
        
        :type offset: System.Int64
        
        
        :type origin: System.IO.SeekOrigin
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
           public override long Seek(long offset, SeekOrigin origin)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Filter.SocketInputStream.SetLength(System.Int64)
    
        
        
        
        :type value: System.Int64
    
        
        .. code-block:: csharp
    
           public override void SetLength(long value)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Filter.SocketInputStream.Write(System.Byte[], System.Int32, System.Int32)
    
        
        
        
        :type buffer: System.Byte[]
        
        
        :type offset: System.Int32
        
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
           public override void Write(byte[] buffer, int offset, int count)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Filter.SocketInputStream.WriteAsync(System.Byte[], System.Int32, System.Int32, System.Threading.CancellationToken)
    
        
        
        
        :type buffer: System.Byte[]
        
        
        :type offset: System.Int32
        
        
        :type count: System.Int32
        
        
        :type token: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken token)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Filter.SocketInputStream
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Filter.SocketInputStream.CanRead
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool CanRead { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Filter.SocketInputStream.CanSeek
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool CanSeek { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Filter.SocketInputStream.CanWrite
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool CanWrite { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Filter.SocketInputStream.Length
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
           public override long Length { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Filter.SocketInputStream.Position
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
           public override long Position { get; set; }
    

