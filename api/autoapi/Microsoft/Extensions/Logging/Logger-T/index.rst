

Logger<T> Class
===============



.. contents:: 
   :local:



Summary
-------

Delegates to a new :any:`Microsoft.Extensions.Logging.ILogger` instance using the full name of the given type, created by the
provided :any:`Microsoft.Extensions.Logging.ILoggerFactory`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.Logger\<T>`








Syntax
------

.. code-block:: csharp

   public class Logger<T> : ILogger<T>, ILogger





GitHub
------

`View on GitHub <https://github.com/aspnet/logging/blob/master/src/Microsoft.Extensions.Logging/LoggerOfT.cs>`_





.. dn:class:: Microsoft.Extensions.Logging.Logger<T>

Constructors
------------

.. dn:class:: Microsoft.Extensions.Logging.Logger<T>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Logging.Logger<T>.Logger(Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        Creates a new :any:`Microsoft.Extensions.Logging.Logger\`1`\.
    
        
        
        
        :param factory: The factory.
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
           public Logger(ILoggerFactory factory)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.Logger<T>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.Logger<T>.Microsoft.Extensions.Logging.ILogger.BeginScopeImpl(System.Object)
    
        
        
        
        :type state: System.Object
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
           IDisposable ILogger.BeginScopeImpl(object state)
    
    .. dn:method:: Microsoft.Extensions.Logging.Logger<T>.Microsoft.Extensions.Logging.ILogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel)
    
        
        
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool ILogger.IsEnabled(LogLevel logLevel)
    
    .. dn:method:: Microsoft.Extensions.Logging.Logger<T>.Microsoft.Extensions.Logging.ILogger.Log(Microsoft.Extensions.Logging.LogLevel, System.Int32, System.Object, System.Exception, System.Func<System.Object, System.Exception, System.String>)
    
        
        
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        
        
        :type eventId: System.Int32
        
        
        :type state: System.Object
        
        
        :type exception: System.Exception
        
        
        :type formatter: System.Func{System.Object,System.Exception,System.String}
    
        
        .. code-block:: csharp
    
           void ILogger.Log(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
    

