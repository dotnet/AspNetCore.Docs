

DataStoreErrorLogger Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLogger`








Syntax
------

.. code-block:: csharp

   public class DataStoreErrorLogger : ILogger





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics.Entity/DataStoreErrorLogger.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLogger

Methods
-------

.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLogger
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLogger.BeginScopeImpl(System.Object)
    
        
        
        
        :type state: System.Object
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
           public virtual IDisposable BeginScopeImpl(object state)
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel)
    
        
        
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool IsEnabled(LogLevel logLevel)
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLogger.Log(Microsoft.Extensions.Logging.LogLevel, System.Int32, System.Object, System.Exception, System.Func<System.Object, System.Exception, System.String>)
    
        
        
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        
        
        :type eventId: System.Int32
        
        
        :type state: System.Object
        
        
        :type exception: System.Exception
        
        
        :type formatter: System.Func{System.Object,System.Exception,System.String}
    
        
        .. code-block:: csharp
    
           public virtual void Log(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLogger.StartLoggingForCurrentCallContext()
    
        
    
        
        .. code-block:: csharp
    
           public virtual void StartLoggingForCurrentCallContext()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLogger
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLogger.LastError
    
        
        :rtype: Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLogger.DataStoreErrorLog
    
        
        .. code-block:: csharp
    
           public virtual DataStoreErrorLogger.DataStoreErrorLog LastError { get; }
    

