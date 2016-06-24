

FilteredStreamAdapter Class
===========================





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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.FilteredStreamAdapter`








Syntax
------

.. code-block:: csharp

    public class FilteredStreamAdapter : IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.FilteredStreamAdapter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.FilteredStreamAdapter

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.FilteredStreamAdapter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.FilteredStreamAdapter.FilteredStreamAdapter(System.String, System.IO.Stream, Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPool, Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.IKestrelTrace, Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.IThreadPool, Microsoft.AspNetCore.Server.Kestrel.Internal.Http.IBufferSizeControl)
    
        
    
        
        :type connectionId: System.String
    
        
        :type filteredStream: System.IO.Stream
    
        
        :type memory: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.MemoryPool
    
        
        :type logger: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.IKestrelTrace
    
        
        :type threadPool: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.IThreadPool
    
        
        :type bufferSizeControl: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.IBufferSizeControl
    
        
        .. code-block:: csharp
    
            public FilteredStreamAdapter(string connectionId, Stream filteredStream, MemoryPool memory, IKestrelTrace logger, IThreadPool threadPool, IBufferSizeControl bufferSizeControl)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.FilteredStreamAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.FilteredStreamAdapter.Abort()
    
        
    
        
        .. code-block:: csharp
    
            public void Abort()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.FilteredStreamAdapter.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.FilteredStreamAdapter.ReadInputAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task ReadInputAsync()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.FilteredStreamAdapter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.FilteredStreamAdapter.SocketInput
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.SocketInput
    
        
        .. code-block:: csharp
    
            public SocketInput SocketInput { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Filter.Internal.FilteredStreamAdapter.SocketOutput
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ISocketOutput
    
        
        .. code-block:: csharp
    
            public ISocketOutput SocketOutput { get; }
    

