

StreamSocketOutput Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Filter.StreamSocketOutput`








Syntax
------

.. code-block:: csharp

   public class StreamSocketOutput : ISocketOutput





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel/Filter/StreamSocketOutput.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Filter.StreamSocketOutput

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Filter.StreamSocketOutput
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Filter.StreamSocketOutput.StreamSocketOutput(System.IO.Stream)
    
        
        
        
        :type outputStream: System.IO.Stream
    
        
        .. code-block:: csharp
    
           public StreamSocketOutput(Stream outputStream)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Filter.StreamSocketOutput
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Filter.StreamSocketOutput.Microsoft.AspNet.Server.Kestrel.Http.ISocketOutput.Write(System.ArraySegment<System.Byte>, System.Boolean)
    
        
        
        
        :type buffer: System.ArraySegment{System.Byte}
        
        
        :type immediate: System.Boolean
    
        
        .. code-block:: csharp
    
           void ISocketOutput.Write(ArraySegment<byte> buffer, bool immediate)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Filter.StreamSocketOutput.Microsoft.AspNet.Server.Kestrel.Http.ISocketOutput.WriteAsync(System.ArraySegment<System.Byte>, System.Boolean, System.Threading.CancellationToken)
    
        
        
        
        :type buffer: System.ArraySegment{System.Byte}
        
        
        :type immediate: System.Boolean
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task ISocketOutput.WriteAsync(ArraySegment<byte> buffer, bool immediate, CancellationToken cancellationToken)
    

