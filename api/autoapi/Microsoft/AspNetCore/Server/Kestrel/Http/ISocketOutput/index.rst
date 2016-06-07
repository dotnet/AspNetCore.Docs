

ISocketOutput Interface
=======================






  Operations performed for buffered socket output


Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Http`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ISocketOutput








.. dn:interface:: Microsoft.AspNetCore.Server.Kestrel.Http.ISocketOutput
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Server.Kestrel.Http.ISocketOutput

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Server.Kestrel.Http.ISocketOutput
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.ISocketOutput.ProducingComplete(Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator)
    
        
    
        
        Commits the response data appended to the iterator returned from :dn:meth:`Microsoft.AspNetCore.Server.Kestrel.Http.ISocketOutput.ProducingStart`\.
        All the data up to <em>end</em> will be included in the response.
        A write operation isn't guaranteed to be scheduled unless :dn:meth:`Microsoft.AspNetCore.Server.Kestrel.Http.ISocketOutput.Write(System.ArraySegment{System.Byte},System.Boolean)`
        or :dn:meth:`Microsoft.AspNetCore.Server.Kestrel.Http.ISocketOutput.WriteAsync(System.ArraySegment{System.Byte},System.Boolean,System.Threading.CancellationToken)` is called afterwards.
    
        
    
        
        :param end: Points to the end of the committed data.
        
        :type end: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator
    
        
        .. code-block:: csharp
    
            void ProducingComplete(MemoryPoolIterator end)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.ISocketOutput.ProducingStart()
    
        
    
        
        Returns an iterator pointing to the tail of the response buffer. Response data can be appended
        manually or by using :dn:meth:`Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator.CopyFrom(System.ArraySegment{System.Byte})`\.
        Be careful to ensure all appended blocks are backed by a :any:`Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolSlab`\. 
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator
    
        
        .. code-block:: csharp
    
            MemoryPoolIterator ProducingStart()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.ISocketOutput.Write(System.ArraySegment<System.Byte>, System.Boolean)
    
        
    
        
        :type buffer: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        :type chunk: System.Boolean
    
        
        .. code-block:: csharp
    
            void Write(ArraySegment<byte> buffer, bool chunk = false)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.ISocketOutput.WriteAsync(System.ArraySegment<System.Byte>, System.Boolean, System.Threading.CancellationToken)
    
        
    
        
        :type buffer: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        :type chunk: System.Boolean
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task WriteAsync(ArraySegment<byte> buffer, bool chunk = false, CancellationToken cancellationToken = null)
    

