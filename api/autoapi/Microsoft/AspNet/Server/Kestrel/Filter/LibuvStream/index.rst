

LibuvStream Class
=================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.MarshalByRefObject`
* :dn:cls:`System.IO.Stream`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Filter.LibuvStream`








Syntax
------

.. code-block:: csharp

   public class LibuvStream : Stream, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel/Filter/LibuvStream.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Filter.LibuvStream

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Filter.LibuvStream
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Filter.LibuvStream.LibuvStream(Microsoft.AspNet.Server.Kestrel.Http.SocketInput, Microsoft.AspNet.Server.Kestrel.Http.ISocketOutput)
    
        
        
        
        :type input: Microsoft.AspNet.Server.Kestrel.Http.SocketInput
        
        
        :type output: Microsoft.AspNet.Server.Kestrel.Http.ISocketOutput
    
        
        .. code-block:: csharp
    
           public LibuvStream(SocketInput input, ISocketOutput output)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Filter.LibuvStream
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Filter.LibuvStream.Flush()
    
        
    
        
        .. code-block:: csharp
    
           public override void Flush()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Filter.LibuvStream.Read(System.Byte[], System.Int32, System.Int32)
    
        
        
        
        :type buffer: System.Byte[]
        
        
        :type offset: System.Int32
        
        
        :type count: System.Int32
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Read(byte[] buffer, int offset, int count)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Filter.LibuvStream.ReadAsync(System.Byte[], System.Int32, System.Int32, System.Threading.CancellationToken)
    
        
        
        
        :type buffer: System.Byte[]
        
        
        :type offset: System.Int32
        
        
        :type count: System.Int32
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Int32}
    
        
        .. code-block:: csharp
    
           public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Filter.LibuvStream.Seek(System.Int64, System.IO.SeekOrigin)
    
        
        
        
        :type offset: System.Int64
        
        
        :type origin: System.IO.SeekOrigin
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
           public override long Seek(long offset, SeekOrigin origin)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Filter.LibuvStream.SetLength(System.Int64)
    
        
        
        
        :type value: System.Int64
    
        
        .. code-block:: csharp
    
           public override void SetLength(long value)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Filter.LibuvStream.Write(System.Byte[], System.Int32, System.Int32)
    
        
        
        
        :type buffer: System.Byte[]
        
        
        :type offset: System.Int32
        
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
           public override void Write(byte[] buffer, int offset, int count)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Filter.LibuvStream.WriteAsync(System.Byte[], System.Int32, System.Int32, System.Threading.CancellationToken)
    
        
        
        
        :type buffer: System.Byte[]
        
        
        :type offset: System.Int32
        
        
        :type count: System.Int32
        
        
        :type token: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken token)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Filter.LibuvStream
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Filter.LibuvStream.CanRead
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool CanRead { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Filter.LibuvStream.CanSeek
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool CanSeek { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Filter.LibuvStream.CanWrite
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool CanWrite { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Filter.LibuvStream.Length
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
           public override long Length { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Filter.LibuvStream.Position
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
           public override long Position { get; set; }
    

