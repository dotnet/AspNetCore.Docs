

FilteredStreamAdapter Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Filter.FilteredStreamAdapter`








Syntax
------

.. code-block:: csharp

   public class FilteredStreamAdapter





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Filter/FilteredStreamAdapter.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Filter.FilteredStreamAdapter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Filter.FilteredStreamAdapter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Filter.FilteredStreamAdapter.FilteredStreamAdapter(System.IO.Stream, Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPool2, Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace)
    
        
        
        
        :type filteredStream: System.IO.Stream
        
        
        :type memory: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPool2
        
        
        :type logger: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
           public FilteredStreamAdapter(Stream filteredStream, MemoryPool2 memory, IKestrelTrace logger)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Filter.FilteredStreamAdapter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Filter.FilteredStreamAdapter.SocketInput
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Http.SocketInput
    
        
        .. code-block:: csharp
    
           public SocketInput SocketInput { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Filter.FilteredStreamAdapter.SocketOutput
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Http.ISocketOutput
    
        
        .. code-block:: csharp
    
           public ISocketOutput SocketOutput { get; }
    

