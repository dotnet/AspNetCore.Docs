

ISocketOutput Interface
=======================



.. contents:: 
   :local:



Summary
-------

Operations performed for buffered socket output











Syntax
------

.. code-block:: csharp

   public interface ISocketOutput





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Http/ISocketOutput.cs>`_





.. dn:interface:: Microsoft.AspNet.Server.Kestrel.Http.ISocketOutput

Methods
-------

.. dn:interface:: Microsoft.AspNet.Server.Kestrel.Http.ISocketOutput
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.ISocketOutput.Write(System.ArraySegment<System.Byte>, System.Boolean)
    
        
        
        
        :type buffer: System.ArraySegment{System.Byte}
        
        
        :type immediate: System.Boolean
    
        
        .. code-block:: csharp
    
           void Write(ArraySegment<byte> buffer, bool immediate = true)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.ISocketOutput.WriteAsync(System.ArraySegment<System.Byte>, System.Boolean, System.Threading.CancellationToken)
    
        
        
        
        :type buffer: System.ArraySegment{System.Byte}
        
        
        :type immediate: System.Boolean
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task WriteAsync(ArraySegment<byte> buffer, bool immediate = true, CancellationToken cancellationToken = null)
    

