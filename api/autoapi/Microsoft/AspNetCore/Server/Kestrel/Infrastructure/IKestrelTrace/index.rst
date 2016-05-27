

IKestrelTrace Interface
=======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Infrastructure`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IKestrelTrace : ILogger








.. dn:interface:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace.ApplicationError(System.String, System.Exception)
    
        
    
        
        :type connectionId: System.String
    
        
        :type ex: System.Exception
    
        
        .. code-block:: csharp
    
            void ApplicationError(string connectionId, Exception ex)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionBadRequest(System.String, Microsoft.AspNetCore.Server.Kestrel.Exceptions.BadHttpRequestException)
    
        
    
        
        :type connectionId: System.String
    
        
        :type ex: Microsoft.AspNetCore.Server.Kestrel.Exceptions.BadHttpRequestException
    
        
        .. code-block:: csharp
    
            void ConnectionBadRequest(string connectionId, BadHttpRequestException ex)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionDisconnect(System.String)
    
        
    
        
        :type connectionId: System.String
    
        
        .. code-block:: csharp
    
            void ConnectionDisconnect(string connectionId)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionDisconnectedWrite(System.String, System.Int32, System.Exception)
    
        
    
        
        :type connectionId: System.String
    
        
        :type count: System.Int32
    
        
        :type ex: System.Exception
    
        
        .. code-block:: csharp
    
            void ConnectionDisconnectedWrite(string connectionId, int count, Exception ex)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionError(System.String, System.Exception)
    
        
    
        
        :type connectionId: System.String
    
        
        :type ex: System.Exception
    
        
        .. code-block:: csharp
    
            void ConnectionError(string connectionId, Exception ex)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionKeepAlive(System.String)
    
        
    
        
        :type connectionId: System.String
    
        
        .. code-block:: csharp
    
            void ConnectionKeepAlive(string connectionId)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionPause(System.String)
    
        
    
        
        :type connectionId: System.String
    
        
        .. code-block:: csharp
    
            void ConnectionPause(string connectionId)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionRead(System.String, System.Int32)
    
        
    
        
        :type connectionId: System.String
    
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
            void ConnectionRead(string connectionId, int count)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionReadFin(System.String)
    
        
    
        
        :type connectionId: System.String
    
        
        .. code-block:: csharp
    
            void ConnectionReadFin(string connectionId)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionResume(System.String)
    
        
    
        
        :type connectionId: System.String
    
        
        .. code-block:: csharp
    
            void ConnectionResume(string connectionId)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionStart(System.String)
    
        
    
        
        :type connectionId: System.String
    
        
        .. code-block:: csharp
    
            void ConnectionStart(string connectionId)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionStop(System.String)
    
        
    
        
        :type connectionId: System.String
    
        
        .. code-block:: csharp
    
            void ConnectionStop(string connectionId)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionWrite(System.String, System.Int32)
    
        
    
        
        :type connectionId: System.String
    
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
            void ConnectionWrite(string connectionId, int count)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionWriteCallback(System.String, System.Int32)
    
        
    
        
        :type connectionId: System.String
    
        
        :type status: System.Int32
    
        
        .. code-block:: csharp
    
            void ConnectionWriteCallback(string connectionId, int status)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionWriteFin(System.String)
    
        
    
        
        :type connectionId: System.String
    
        
        .. code-block:: csharp
    
            void ConnectionWriteFin(string connectionId)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace.ConnectionWroteFin(System.String, System.Int32)
    
        
    
        
        :type connectionId: System.String
    
        
        :type status: System.Int32
    
        
        .. code-block:: csharp
    
            void ConnectionWroteFin(string connectionId, int status)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace.NotAllConnectionsClosedGracefully()
    
        
    
        
        .. code-block:: csharp
    
            void NotAllConnectionsClosedGracefully()
    

