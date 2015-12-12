

IKestrelTrace Interface
=======================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IKestrelTrace : ILogger





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel/Infrastructure/IKestrelTrace.cs>`_





.. dn:interface:: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace

Methods
-------

.. dn:interface:: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace.ApplicationError(System.Exception)
    
        
        
        
        :type ex: System.Exception
    
        
        .. code-block:: csharp
    
           void ApplicationError(Exception ex)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionDisconnect(System.Int64)
    
        
        
        
        :type connectionId: System.Int64
    
        
        .. code-block:: csharp
    
           void ConnectionDisconnect(long connectionId)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionKeepAlive(System.Int64)
    
        
        
        
        :type connectionId: System.Int64
    
        
        .. code-block:: csharp
    
           void ConnectionKeepAlive(long connectionId)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionPause(System.Int64)
    
        
        
        
        :type connectionId: System.Int64
    
        
        .. code-block:: csharp
    
           void ConnectionPause(long connectionId)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionRead(System.Int64, System.Int32)
    
        
        
        
        :type connectionId: System.Int64
        
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
           void ConnectionRead(long connectionId, int count)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionReadFin(System.Int64)
    
        
        
        
        :type connectionId: System.Int64
    
        
        .. code-block:: csharp
    
           void ConnectionReadFin(long connectionId)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionResume(System.Int64)
    
        
        
        
        :type connectionId: System.Int64
    
        
        .. code-block:: csharp
    
           void ConnectionResume(long connectionId)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionStart(System.Int64)
    
        
        
        
        :type connectionId: System.Int64
    
        
        .. code-block:: csharp
    
           void ConnectionStart(long connectionId)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionStop(System.Int64)
    
        
        
        
        :type connectionId: System.Int64
    
        
        .. code-block:: csharp
    
           void ConnectionStop(long connectionId)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionWrite(System.Int64, System.Int32)
    
        
        
        
        :type connectionId: System.Int64
        
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
           void ConnectionWrite(long connectionId, int count)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionWriteCallback(System.Int64, System.Int32)
    
        
        
        
        :type connectionId: System.Int64
        
        
        :type status: System.Int32
    
        
        .. code-block:: csharp
    
           void ConnectionWriteCallback(long connectionId, int status)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionWriteFin(System.Int64)
    
        
        
        
        :type connectionId: System.Int64
    
        
        .. code-block:: csharp
    
           void ConnectionWriteFin(long connectionId)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionWroteFin(System.Int64, System.Int32)
    
        
        
        
        :type connectionId: System.Int64
        
        
        :type status: System.Int32
    
        
        .. code-block:: csharp
    
           void ConnectionWroteFin(long connectionId, int status)
    

