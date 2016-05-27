

FilteredStreamAdapter Class
===========================





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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Filter.FilteredStreamAdapter`








Syntax
------

.. code-block:: csharp

    public class FilteredStreamAdapter : IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.FilteredStreamAdapter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.FilteredStreamAdapter

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.FilteredStreamAdapter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Filter.FilteredStreamAdapter.SocketInput
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput
    
        
        .. code-block:: csharp
    
            public SocketInput SocketInput
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Filter.FilteredStreamAdapter.SocketOutput
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Http.ISocketOutput
    
        
        .. code-block:: csharp
    
            public ISocketOutput SocketOutput
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.FilteredStreamAdapter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Filter.FilteredStreamAdapter.FilteredStreamAdapter(System.String, System.IO.Stream, Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPool, Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace, Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IThreadPool)
    
        
    
        
        :type connectionId: System.String
    
        
        :type filteredStream: System.IO.Stream
    
        
        :type memory: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPool
    
        
        :type logger: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        :type threadPool: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IThreadPool
    
        
        .. code-block:: csharp
    
            public FilteredStreamAdapter(string connectionId, Stream filteredStream, MemoryPool memory, IKestrelTrace logger, IThreadPool threadPool)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.FilteredStreamAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.FilteredStreamAdapter.Abort()
    
        
    
        
        .. code-block:: csharp
    
            public void Abort()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.FilteredStreamAdapter.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.FilteredStreamAdapter.ReadInputAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task ReadInputAsync()
    

