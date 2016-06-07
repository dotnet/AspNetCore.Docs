

StreamSocketOutput Class
========================





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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Filter.StreamSocketOutput`








Syntax
------

.. code-block:: csharp

    public class StreamSocketOutput : ISocketOutput








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.StreamSocketOutput
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.StreamSocketOutput

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.StreamSocketOutput
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Filter.StreamSocketOutput.StreamSocketOutput(System.String, System.IO.Stream, Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPool, Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace)
    
        
    
        
        :type connectionId: System.String
    
        
        :type outputStream: System.IO.Stream
    
        
        :type memory: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPool
    
        
        :type logger: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
            public StreamSocketOutput(string connectionId, Stream outputStream, MemoryPool memory, IKestrelTrace logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.StreamSocketOutput
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.StreamSocketOutput.ProducingComplete(Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator)
    
        
    
        
        :type end: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator
    
        
        .. code-block:: csharp
    
            public void ProducingComplete(MemoryPoolIterator end)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.StreamSocketOutput.ProducingStart()
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator
    
        
        .. code-block:: csharp
    
            public MemoryPoolIterator ProducingStart()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.StreamSocketOutput.Write(System.ArraySegment<System.Byte>, System.Boolean)
    
        
    
        
        :type buffer: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        :type chunk: System.Boolean
    
        
        .. code-block:: csharp
    
            public void Write(ArraySegment<byte> buffer, bool chunk)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.StreamSocketOutput.WriteAsync(System.ArraySegment<System.Byte>, System.Boolean, System.Threading.CancellationToken)
    
        
    
        
        :type buffer: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        :type chunk: System.Boolean
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task WriteAsync(ArraySegment<byte> buffer, bool chunk, CancellationToken cancellationToken)
    

