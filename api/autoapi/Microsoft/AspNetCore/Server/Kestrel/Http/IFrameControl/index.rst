

IFrameControl Interface
=======================





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

    public interface IFrameControl








.. dn:interface:: Microsoft.AspNetCore.Server.Kestrel.Http.IFrameControl
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Server.Kestrel.Http.IFrameControl

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Server.Kestrel.Http.IFrameControl
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.IFrameControl.Flush()
    
        
    
        
        .. code-block:: csharp
    
            void Flush()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.IFrameControl.FlushAsync(System.Threading.CancellationToken)
    
        
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task FlushAsync(CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.IFrameControl.ProduceContinue()
    
        
    
        
        .. code-block:: csharp
    
            void ProduceContinue()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.IFrameControl.Write(System.ArraySegment<System.Byte>)
    
        
    
        
        :type data: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        .. code-block:: csharp
    
            void Write(ArraySegment<byte> data)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.IFrameControl.WriteAsync(System.ArraySegment<System.Byte>, System.Threading.CancellationToken)
    
        
    
        
        :type data: System.ArraySegment<System.ArraySegment`1>{System.Byte<System.Byte>}
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task WriteAsync(ArraySegment<byte> data, CancellationToken cancellationToken)
    

