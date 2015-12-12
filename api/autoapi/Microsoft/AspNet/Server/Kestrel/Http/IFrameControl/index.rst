

IFrameControl Interface
=======================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IFrameControl





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Http/IFrameControl.cs>`_





.. dn:interface:: Microsoft.AspNet.Server.Kestrel.Http.IFrameControl

Methods
-------

.. dn:interface:: Microsoft.AspNet.Server.Kestrel.Http.IFrameControl
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.IFrameControl.Flush()
    
        
    
        
        .. code-block:: csharp
    
           void Flush()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.IFrameControl.FlushAsync(System.Threading.CancellationToken)
    
        
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task FlushAsync(CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.IFrameControl.ProduceContinue()
    
        
    
        
        .. code-block:: csharp
    
           void ProduceContinue()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.IFrameControl.Write(System.ArraySegment<System.Byte>)
    
        
        
        
        :type data: System.ArraySegment{System.Byte}
    
        
        .. code-block:: csharp
    
           void Write(ArraySegment<byte> data)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.IFrameControl.WriteAsync(System.ArraySegment<System.Byte>, System.Threading.CancellationToken)
    
        
        
        
        :type data: System.ArraySegment{System.Byte}
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task WriteAsync(ArraySegment<byte> data, CancellationToken cancellationToken)
    

