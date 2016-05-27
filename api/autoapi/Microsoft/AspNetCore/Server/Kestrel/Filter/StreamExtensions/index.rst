

StreamExtensions Class
======================





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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Filter.StreamExtensions`








Syntax
------

.. code-block:: csharp

    public class StreamExtensions








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.StreamExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.StreamExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Filter.StreamExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.StreamExtensions.CopyToAsync(System.IO.Stream, System.IO.Stream, Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock)
    
        
    
        
        :type source: System.IO.Stream
    
        
        :type destination: System.IO.Stream
    
        
        :type block: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolBlock
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public static Task CopyToAsync(Stream source, Stream destination, MemoryPoolBlock block)
    

