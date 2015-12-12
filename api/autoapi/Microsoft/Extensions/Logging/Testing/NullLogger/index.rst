

NullLogger Class
================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.Testing.NullLogger`








Syntax
------

.. code-block:: csharp

   public class NullLogger : ILogger





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/logging/src/Microsoft.Extensions.Logging.Testing/NullLogger.cs>`_





.. dn:class:: Microsoft.Extensions.Logging.Testing.NullLogger

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.Testing.NullLogger
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.NullLogger.BeginScopeImpl(System.Object)
    
        
        
        
        :type state: System.Object
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
           public IDisposable BeginScopeImpl(object state)
    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.NullLogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel)
    
        
        
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsEnabled(LogLevel logLevel)
    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.NullLogger.Log(Microsoft.Extensions.Logging.LogLevel, System.Int32, System.Object, System.Exception, System.Func<System.Object, System.Exception, System.String>)
    
        
        
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        
        
        :type eventId: System.Int32
        
        
        :type state: System.Object
        
        
        :type exception: System.Exception
        
        
        :type formatter: System.Func{System.Object,System.Exception,System.String}
    
        
        .. code-block:: csharp
    
           public void Log(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
    

Fields
------

.. dn:class:: Microsoft.Extensions.Logging.Testing.NullLogger
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.Extensions.Logging.Testing.NullLogger.Instance
    
        
    
        
        .. code-block:: csharp
    
           public static readonly NullLogger Instance
    

