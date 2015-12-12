

FrameRequestStream Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.MarshalByRefObject`
* :dn:cls:`System.IO.Stream`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.FrameRequestStream`








Syntax
------

.. code-block:: csharp

   public class FrameRequestStream : Stream, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel/Http/FrameRequestStream.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestStream

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestStream
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestStream.FrameRequestStream(Microsoft.AspNet.Server.Kestrel.Http.MessageBody)
    
        
        
        
        :type body: Microsoft.AspNet.Server.Kestrel.Http.MessageBody
    
        
        .. code-block:: csharp
    
           public FrameRequestStream(MessageBody body)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestStream
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestStream.Flush()
    
        
    
        
        .. code-block:: csharp
    
           public override void Flush()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestStream.Read(System.Byte[], System.Int32, System.Int32)
    
        
        
        
        :type buffer: System.Byte[]
        
        
        :type offset: System.Int32
        
        
        :type count: System.Int32
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Read(byte[] buffer, int offset, int count)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestStream.ReadAsync(System.Byte[], System.Int32, System.Int32, System.Threading.CancellationToken)
    
        
        
        
        :type buffer: System.Byte[]
        
        
        :type offset: System.Int32
        
        
        :type count: System.Int32
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Int32}
    
        
        .. code-block:: csharp
    
           public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestStream.ReadAsync(System.Byte[], System.Int32, System.Int32, System.Threading.CancellationToken, System.Object)
    
        
        
        
        :type buffer: System.Byte[]
        
        
        :type offset: System.Int32
        
        
        :type count: System.Int32
        
        
        :type cancellationToken: System.Threading.CancellationToken
        
        
        :type state: System.Object
        :rtype: System.Threading.Tasks.Task{System.Int32}
    
        
        .. code-block:: csharp
    
           public Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken, object state)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestStream.Seek(System.Int64, System.IO.SeekOrigin)
    
        
        
        
        :type offset: System.Int64
        
        
        :type origin: System.IO.SeekOrigin
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
           public override long Seek(long offset, SeekOrigin origin)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestStream.SetLength(System.Int64)
    
        
        
        
        :type value: System.Int64
    
        
        .. code-block:: csharp
    
           public override void SetLength(long value)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestStream.Write(System.Byte[], System.Int32, System.Int32)
    
        
        
        
        :type buffer: System.Byte[]
        
        
        :type offset: System.Int32
        
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
           public override void Write(byte[] buffer, int offset, int count)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestStream
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestStream.CanRead
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool CanRead { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestStream.CanSeek
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool CanSeek { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestStream.CanWrite
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool CanWrite { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestStream.Length
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
           public override long Length { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.FrameRequestStream.Position
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
           public override long Position { get; set; }
    

