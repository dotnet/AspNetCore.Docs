

StreamCopyOperation Class
=========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Extensions`
Assemblies
    * Microsoft.AspNetCore.Http.Extensions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.Extensions.StreamCopyOperation`








Syntax
------

.. code-block:: csharp

    public class StreamCopyOperation








.. dn:class:: Microsoft.AspNetCore.Http.Extensions.StreamCopyOperation
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Extensions.StreamCopyOperation

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.Extensions.StreamCopyOperation
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Extensions.StreamCopyOperation.CopyToAsync(System.IO.Stream, System.IO.Stream, System.Nullable<System.Int64>, System.Threading.CancellationToken)
    
        
    
        
        :type source: System.IO.Stream
    
        
        :type destination: System.IO.Stream
    
        
        :type count: System.Nullable<System.Nullable`1>{System.Int64<System.Int64>}
    
        
        :type cancel: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public static Task CopyToAsync(Stream source, Stream destination, long ? count, CancellationToken cancel)
    

