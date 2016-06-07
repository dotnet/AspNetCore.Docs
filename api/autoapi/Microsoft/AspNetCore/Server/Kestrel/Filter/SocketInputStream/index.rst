

SocketInputStream Class
=======================






This is a write-only stream that copies what is written into a
:any:`Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput` object. This is used as an argument to
:dn:meth:`System.IO.Stream.CopyToAsync(System.IO.Stream)` so input filtered by a
ConnectionFilter (e.g. SslStream) can be consumed by :any:`Microsoft.AspNetCore.Server.Kestrel.Http.Frame`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Filter`
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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Filter.SocketInputStream`








Syntax
------

.. code-block:: csharp

    public class SocketInputStream : Stream, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.SocketInputStream
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.SocketInputStream

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.SocketInputStream
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Filter.SocketInputStream.CanRead
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool CanRead
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Filter.SocketInputStream.CanSeek
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool CanSeek
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Filter.SocketInputStream.CanWrite
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool CanWrite
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Filter.SocketInputStream.Length
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public override long Length
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Filter.SocketInputStream.Position
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public override long Position
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.SocketInputStream
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Filter.SocketInputStream.SocketInputStream(Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput)
    
        
    
        
        :type socketInput: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput
    
        
        .. code-block:: csharp
    
            public SocketInputStream(SocketInput socketInput)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.SocketInputStream
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.SocketInputStream.Dispose(System.Boolean)
    
        
    
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
            protected override void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.SocketInputStream.Flush()
    
        
    
        
        .. code-block:: csharp
    
            public override void Flush()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.SocketInputStream.Read(System.Byte[], System.Int32, System.Int32)
    
        
    
        
        :type buffer: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Read(byte[] buffer, int offset, int count)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.SocketInputStream.Seek(System.Int64, System.IO.SeekOrigin)
    
        
    
        
        :type offset: System.Int64
    
        
        :type origin: System.IO.SeekOrigin
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public override long Seek(long offset, SeekOrigin origin)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.SocketInputStream.SetLength(System.Int64)
    
        
    
        
        :type value: System.Int64
    
        
        .. code-block:: csharp
    
            public override void SetLength(long value)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.SocketInputStream.Write(System.Byte[], System.Int32, System.Int32)
    
        
    
        
        :type buffer: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
            public override void Write(byte[] buffer, int offset, int count)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.SocketInputStream.WriteAsync(System.Byte[], System.Int32, System.Int32, System.Threading.CancellationToken)
    
        
    
        
        :type buffer: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
    
        
        :type token: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken token)
    

