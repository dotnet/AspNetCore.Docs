

KestrelTrace Class
==================



.. contents:: 
   :local:



Summary
-------

Summary description for KestrelTrace





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.KestrelTrace`








Syntax
------

.. code-block:: csharp

   public class KestrelTrace : IKestrelTrace, ILogger





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Infrastructure/KestrelTrace.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.KestrelTrace

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.KestrelTrace
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.KestrelTrace.KestrelTrace(Microsoft.Extensions.Logging.ILogger)
    
        
        
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           public KestrelTrace(ILogger logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.KestrelTrace
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelTrace.ApplicationError(System.Exception)
    
        
        
        
        :type ex: System.Exception
    
        
        .. code-block:: csharp
    
           public virtual void ApplicationError(Exception ex)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelTrace.BeginScopeImpl(System.Object)
    
        
        
        
        :type state: System.Object
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
           public virtual IDisposable BeginScopeImpl(object state)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelTrace.ConnectionDisconnect(System.Int64)
    
        
        
        
        :type connectionId: System.Int64
    
        
        .. code-block:: csharp
    
           public virtual void ConnectionDisconnect(long connectionId)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelTrace.ConnectionKeepAlive(System.Int64)
    
        
        
        
        :type connectionId: System.Int64
    
        
        .. code-block:: csharp
    
           public virtual void ConnectionKeepAlive(long connectionId)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelTrace.ConnectionPause(System.Int64)
    
        
        
        
        :type connectionId: System.Int64
    
        
        .. code-block:: csharp
    
           public virtual void ConnectionPause(long connectionId)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelTrace.ConnectionRead(System.Int64, System.Int32)
    
        
        
        
        :type connectionId: System.Int64
        
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
           public virtual void ConnectionRead(long connectionId, int count)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelTrace.ConnectionReadFin(System.Int64)
    
        
        
        
        :type connectionId: System.Int64
    
        
        .. code-block:: csharp
    
           public virtual void ConnectionReadFin(long connectionId)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelTrace.ConnectionResume(System.Int64)
    
        
        
        
        :type connectionId: System.Int64
    
        
        .. code-block:: csharp
    
           public virtual void ConnectionResume(long connectionId)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelTrace.ConnectionStart(System.Int64)
    
        
        
        
        :type connectionId: System.Int64
    
        
        .. code-block:: csharp
    
           public virtual void ConnectionStart(long connectionId)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelTrace.ConnectionStop(System.Int64)
    
        
        
        
        :type connectionId: System.Int64
    
        
        .. code-block:: csharp
    
           public virtual void ConnectionStop(long connectionId)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelTrace.ConnectionWrite(System.Int64, System.Int32)
    
        
        
        
        :type connectionId: System.Int64
        
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
           public virtual void ConnectionWrite(long connectionId, int count)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelTrace.ConnectionWriteCallback(System.Int64, System.Int32)
    
        
        
        
        :type connectionId: System.Int64
        
        
        :type status: System.Int32
    
        
        .. code-block:: csharp
    
           public virtual void ConnectionWriteCallback(long connectionId, int status)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelTrace.ConnectionWriteFin(System.Int64)
    
        
        
        
        :type connectionId: System.Int64
    
        
        .. code-block:: csharp
    
           public virtual void ConnectionWriteFin(long connectionId)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelTrace.ConnectionWroteFin(System.Int64, System.Int32)
    
        
        
        
        :type connectionId: System.Int64
        
        
        :type status: System.Int32
    
        
        .. code-block:: csharp
    
           public virtual void ConnectionWroteFin(long connectionId, int status)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelTrace.IsEnabled(Microsoft.Extensions.Logging.LogLevel)
    
        
        
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool IsEnabled(LogLevel logLevel)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelTrace.Log(Microsoft.Extensions.Logging.LogLevel, System.Int32, System.Object, System.Exception, System.Func<System.Object, System.Exception, System.String>)
    
        
        
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        
        
        :type eventId: System.Int32
        
        
        :type state: System.Object
        
        
        :type exception: System.Exception
        
        
        :type formatter: System.Func{System.Object,System.Exception,System.String}
    
        
        .. code-block:: csharp
    
           public virtual void Log(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.KestrelTrace
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.KestrelTrace._logger
    
        
    
        
        .. code-block:: csharp
    
           protected readonly ILogger _logger
    

