

KestrelTrace Class
==================






Summary description for KestrelTrace


Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Internal`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace`








Syntax
------

.. code-block:: csharp

    public class KestrelTrace : IKestrelTrace, ILogger








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace.KestrelTrace(Microsoft.Extensions.Logging.ILogger)
    
        
    
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            public KestrelTrace(ILogger logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace.ApplicationError(System.String, System.Exception)
    
        
    
        
        :type connectionId: System.String
    
        
        :type ex: System.Exception
    
        
        .. code-block:: csharp
    
            public virtual void ApplicationError(string connectionId, Exception ex)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace.BeginScope<TState>(TState)
    
        
    
        
        :type state: TState
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public virtual IDisposable BeginScope<TState>(TState state)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace.ConnectionBadRequest(System.String, Microsoft.AspNetCore.Server.Kestrel.BadHttpRequestException)
    
        
    
        
        :type connectionId: System.String
    
        
        :type ex: Microsoft.AspNetCore.Server.Kestrel.BadHttpRequestException
    
        
        .. code-block:: csharp
    
            public void ConnectionBadRequest(string connectionId, BadHttpRequestException ex)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace.ConnectionDisconnect(System.String)
    
        
    
        
        :type connectionId: System.String
    
        
        .. code-block:: csharp
    
            public virtual void ConnectionDisconnect(string connectionId)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace.ConnectionDisconnectedWrite(System.String, System.Int32, System.Exception)
    
        
    
        
        :type connectionId: System.String
    
        
        :type count: System.Int32
    
        
        :type ex: System.Exception
    
        
        .. code-block:: csharp
    
            public virtual void ConnectionDisconnectedWrite(string connectionId, int count, Exception ex)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace.ConnectionError(System.String, System.Exception)
    
        
    
        
        :type connectionId: System.String
    
        
        :type ex: System.Exception
    
        
        .. code-block:: csharp
    
            public virtual void ConnectionError(string connectionId, Exception ex)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace.ConnectionKeepAlive(System.String)
    
        
    
        
        :type connectionId: System.String
    
        
        .. code-block:: csharp
    
            public virtual void ConnectionKeepAlive(string connectionId)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace.ConnectionPause(System.String)
    
        
    
        
        :type connectionId: System.String
    
        
        .. code-block:: csharp
    
            public virtual void ConnectionPause(string connectionId)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace.ConnectionRead(System.String, System.Int32)
    
        
    
        
        :type connectionId: System.String
    
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
            public virtual void ConnectionRead(string connectionId, int count)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace.ConnectionReadFin(System.String)
    
        
    
        
        :type connectionId: System.String
    
        
        .. code-block:: csharp
    
            public virtual void ConnectionReadFin(string connectionId)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace.ConnectionResume(System.String)
    
        
    
        
        :type connectionId: System.String
    
        
        .. code-block:: csharp
    
            public virtual void ConnectionResume(string connectionId)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace.ConnectionStart(System.String)
    
        
    
        
        :type connectionId: System.String
    
        
        .. code-block:: csharp
    
            public virtual void ConnectionStart(string connectionId)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace.ConnectionStop(System.String)
    
        
    
        
        :type connectionId: System.String
    
        
        .. code-block:: csharp
    
            public virtual void ConnectionStop(string connectionId)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace.ConnectionWrite(System.String, System.Int32)
    
        
    
        
        :type connectionId: System.String
    
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
            public virtual void ConnectionWrite(string connectionId, int count)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace.ConnectionWriteCallback(System.String, System.Int32)
    
        
    
        
        :type connectionId: System.String
    
        
        :type status: System.Int32
    
        
        .. code-block:: csharp
    
            public virtual void ConnectionWriteCallback(string connectionId, int status)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace.ConnectionWriteFin(System.String)
    
        
    
        
        :type connectionId: System.String
    
        
        .. code-block:: csharp
    
            public virtual void ConnectionWriteFin(string connectionId)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace.ConnectionWroteFin(System.String, System.Int32)
    
        
    
        
        :type connectionId: System.String
    
        
        :type status: System.Int32
    
        
        .. code-block:: csharp
    
            public virtual void ConnectionWroteFin(string connectionId, int status)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace.IsEnabled(Microsoft.Extensions.Logging.LogLevel)
    
        
    
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool IsEnabled(LogLevel logLevel)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace.Log<TState>(Microsoft.Extensions.Logging.LogLevel, Microsoft.Extensions.Logging.EventId, TState, System.Exception, System.Func<TState, System.Exception, System.String>)
    
        
    
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
    
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :type state: TState
    
        
        :type exception: System.Exception
    
        
        :type formatter: System.Func<System.Func`3>{TState, System.Exception<System.Exception>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public virtual void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace.NotAllConnectionsClosedGracefully()
    
        
    
        
        .. code-block:: csharp
    
            public virtual void NotAllConnectionsClosedGracefully()
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelTrace._logger
    
        
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            protected readonly ILogger _logger
    

