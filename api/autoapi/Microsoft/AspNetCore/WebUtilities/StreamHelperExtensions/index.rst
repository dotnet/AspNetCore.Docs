

StreamHelperExtensions Class
============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.WebUtilities`
Assemblies
    * Microsoft.AspNetCore.WebUtilities

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.WebUtilities.StreamHelperExtensions`








Syntax
------

.. code-block:: csharp

    public class StreamHelperExtensions








.. dn:class:: Microsoft.AspNetCore.WebUtilities.StreamHelperExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.WebUtilities.StreamHelperExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.WebUtilities.StreamHelperExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.StreamHelperExtensions.DrainAsync(System.IO.Stream, System.Buffers.ArrayPool<System.Byte>, System.Nullable<System.Int64>, System.Threading.CancellationToken)
    
        
    
        
        :type stream: System.IO.Stream
    
        
        :type bytePool: System.Buffers.ArrayPool<System.Buffers.ArrayPool`1>{System.Byte<System.Byte>}
    
        
        :type limit: System.Nullable<System.Nullable`1>{System.Int64<System.Int64>}
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public static Task DrainAsync(Stream stream, ArrayPool<byte> bytePool, long ? limit, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.StreamHelperExtensions.DrainAsync(System.IO.Stream, System.Nullable<System.Int64>, System.Threading.CancellationToken)
    
        
    
        
        :type stream: System.IO.Stream
    
        
        :type limit: System.Nullable<System.Nullable`1>{System.Int64<System.Int64>}
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public static Task DrainAsync(Stream stream, long ? limit, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.StreamHelperExtensions.DrainAsync(System.IO.Stream, System.Threading.CancellationToken)
    
        
    
        
        :type stream: System.IO.Stream
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public static Task DrainAsync(Stream stream, CancellationToken cancellationToken)
    

