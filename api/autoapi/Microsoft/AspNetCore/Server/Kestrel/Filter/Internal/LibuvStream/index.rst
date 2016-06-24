

LibuvStream Class
=================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Filter.Internal`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.MarshalByRefObject`
* :dn:cls:`System.IO.Stream`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.LibuvStream`








Syntax
------

.. code-block:: csharp

    public class LibuvStream : Stream, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.LibuvStream
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.LibuvStream

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.LibuvStream
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.LibuvStream.LibuvStream(Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput, Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ISocketOutput)
    
        
    
        
        :type input: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput
    
        
        :type output: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ISocketOutput
    
        
        .. code-block:: csharp
    
            public LibuvStream(SocketInput input, ISocketOutput output)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.LibuvStream
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.LibuvStream.CanRead
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool CanRead { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.LibuvStream.CanSeek
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool CanSeek { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.LibuvStream.CanWrite
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool CanWrite { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.LibuvStream.Length
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public override long Length { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.LibuvStream.Position
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public override long Position { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.LibuvStream
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.LibuvStream.Flush()
    
        
    
        
        .. code-block:: csharp
    
            public override void Flush()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.LibuvStream.FlushAsync(System.Threading.CancellationToken)
    
        
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task FlushAsync(CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.LibuvStream.Read(System.Byte[], System.Int32, System.Int32)
    
        
    
        
        :type buffer: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Read(byte[] buffer, int offset, int count)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.LibuvStream.ReadAsync(System.Byte[], System.Int32, System.Int32, System.Threading.CancellationToken)
    
        
    
        
        :type buffer: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.LibuvStream.Seek(System.Int64, System.IO.SeekOrigin)
    
        
    
        
        :type offset: System.Int64
    
        
        :type origin: System.IO.SeekOrigin
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public override long Seek(long offset, SeekOrigin origin)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.LibuvStream.SetLength(System.Int64)
    
        
    
        
        :type value: System.Int64
    
        
        .. code-block:: csharp
    
            public override void SetLength(long value)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.LibuvStream.Write(System.Byte[], System.Int32, System.Int32)
    
        
    
        
        :type buffer: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
            public override void Write(byte[] buffer, int offset, int count)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.LibuvStream.WriteAsync(System.Byte[], System.Int32, System.Int32, System.Threading.CancellationToken)
    
        
    
        
        :type buffer: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
    
        
        :type token: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken token)
    

