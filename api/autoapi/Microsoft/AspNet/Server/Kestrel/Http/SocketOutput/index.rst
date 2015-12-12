

SocketOutput Class
==================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.SocketOutput`








Syntax
------

.. code-block:: csharp

   public class SocketOutput : ISocketOutput





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel/Http/SocketOutput.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.SocketOutput

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.SocketOutput
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Http.SocketOutput.SocketOutput(Microsoft.AspNet.Server.Kestrel.KestrelThread, Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle, System.Int64, Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace)
    
        
        
        
        :type thread: Microsoft.AspNet.Server.Kestrel.KestrelThread
        
        
        :type socket: Microsoft.AspNet.Server.Kestrel.Networking.UvStreamHandle
        
        
        :type connectionId: System.Int64
        
        
        :type log: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
           public SocketOutput(KestrelThread thread, UvStreamHandle socket, long connectionId, IKestrelTrace log)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.SocketOutput
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.SocketOutput.End(Microsoft.AspNet.Server.Kestrel.Http.ProduceEndType)
    
        
        
        
        :type endType: Microsoft.AspNet.Server.Kestrel.Http.ProduceEndType
    
        
        .. code-block:: csharp
    
           public void End(ProduceEndType endType)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.SocketOutput.Microsoft.AspNet.Server.Kestrel.Http.ISocketOutput.Write(System.ArraySegment<System.Byte>, System.Boolean)
    
        
        
        
        :type buffer: System.ArraySegment{System.Byte}
        
        
        :type immediate: System.Boolean
    
        
        .. code-block:: csharp
    
           void ISocketOutput.Write(ArraySegment<byte> buffer, bool immediate)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.SocketOutput.Microsoft.AspNet.Server.Kestrel.Http.ISocketOutput.WriteAsync(System.ArraySegment<System.Byte>, System.Boolean, System.Threading.CancellationToken)
    
        
        
        
        :type buffer: System.ArraySegment{System.Byte}
        
        
        :type immediate: System.Boolean
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task ISocketOutput.WriteAsync(ArraySegment<byte> buffer, bool immediate, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.SocketOutput.Write(System.ArraySegment<System.Byte>, System.Action<System.Exception, System.Object, System.Boolean>, System.Object, System.Boolean, System.Boolean, System.Boolean)
    
        
        
        
        :type buffer: System.ArraySegment{System.Byte}
        
        
        :type callback: System.Action{System.Exception,System.Object,System.Boolean}
        
        
        :type state: System.Object
        
        
        :type immediate: System.Boolean
        
        
        :type socketShutdownSend: System.Boolean
        
        
        :type socketDisconnect: System.Boolean
    
        
        .. code-block:: csharp
    
           public void Write(ArraySegment<byte> buffer, Action<Exception, object, bool> callback, object state, bool immediate = true, bool socketShutdownSend = false, bool socketDisconnect = false)
    

