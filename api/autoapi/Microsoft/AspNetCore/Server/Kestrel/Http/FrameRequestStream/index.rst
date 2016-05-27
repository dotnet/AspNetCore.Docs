

FrameRequestStream Class
========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Http`
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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestStream`








Syntax
------

.. code-block:: csharp

    public class FrameRequestStream : Stream, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestStream
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestStream

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestStream
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestStream.CanRead
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool CanRead
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestStream.CanSeek
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool CanSeek
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestStream.CanWrite
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool CanWrite
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestStream.Length
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public override long Length
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestStream.Position
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public override long Position
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestStream
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestStream.FrameRequestStream()
    
        
    
        
        .. code-block:: csharp
    
            public FrameRequestStream()
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestStream
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestStream.Abort()
    
        
    
        
        .. code-block:: csharp
    
            public void Abort()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestStream.BeginRead(System.Byte[], System.Int32, System.Int32, System.AsyncCallback, System.Object)
    
        
    
        
        :type buffer: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
    
        
        :type callback: System.AsyncCallback
    
        
        :type state: System.Object
        :rtype: System.IAsyncResult
    
        
        .. code-block:: csharp
    
            public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestStream.EndRead(System.IAsyncResult)
    
        
    
        
        :type asyncResult: System.IAsyncResult
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int EndRead(IAsyncResult asyncResult)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestStream.Flush()
    
        
    
        
        .. code-block:: csharp
    
            public override void Flush()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestStream.PauseAcceptingReads()
    
        
    
        
        .. code-block:: csharp
    
            public void PauseAcceptingReads()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestStream.Read(System.Byte[], System.Int32, System.Int32)
    
        
    
        
        :type buffer: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Read(byte[] buffer, int offset, int count)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestStream.ReadAsync(System.Byte[], System.Int32, System.Int32, System.Threading.CancellationToken)
    
        
    
        
        :type buffer: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestStream.ResumeAcceptingReads()
    
        
    
        
        .. code-block:: csharp
    
            public void ResumeAcceptingReads()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestStream.Seek(System.Int64, System.IO.SeekOrigin)
    
        
    
        
        :type offset: System.Int64
    
        
        :type origin: System.IO.SeekOrigin
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public override long Seek(long offset, SeekOrigin origin)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestStream.SetLength(System.Int64)
    
        
    
        
        :type value: System.Int64
    
        
        .. code-block:: csharp
    
            public override void SetLength(long value)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestStream.StartAcceptingReads(Microsoft.AspNetCore.Server.Kestrel.Http.MessageBody)
    
        
    
        
        :type body: Microsoft.AspNetCore.Server.Kestrel.Http.MessageBody
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public Stream StartAcceptingReads(MessageBody body)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestStream.StopAcceptingReads()
    
        
    
        
        .. code-block:: csharp
    
            public void StopAcceptingReads()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.FrameRequestStream.Write(System.Byte[], System.Int32, System.Int32)
    
        
    
        
        :type buffer: System.Byte<System.Byte>[]
    
        
        :type offset: System.Int32
    
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
            public override void Write(byte[] buffer, int offset, int count)
    

