

TestLogger Class
================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.Testing.TestLogger`








Syntax
------

.. code-block:: csharp

   public class TestLogger : ILogger





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/logging/src/Microsoft.Extensions.Logging.Testing/TestLogger.cs>`_





.. dn:class:: Microsoft.Extensions.Logging.Testing.TestLogger

Constructors
------------

.. dn:class:: Microsoft.Extensions.Logging.Testing.TestLogger
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Logging.Testing.TestLogger.TestLogger(System.String, Microsoft.Extensions.Logging.Testing.TestSink, System.Boolean)
    
        
        
        
        :type name: System.String
        
        
        :type sink: Microsoft.Extensions.Logging.Testing.TestSink
        
        
        :type enabled: System.Boolean
    
        
        .. code-block:: csharp
    
           public TestLogger(string name, TestSink sink, bool enabled)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.Testing.TestLogger
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.TestLogger.BeginScopeImpl(System.Object)
    
        
        
        
        :type state: System.Object
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
           public IDisposable BeginScopeImpl(object state)
    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.TestLogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel)
    
        
        
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsEnabled(LogLevel logLevel)
    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.TestLogger.Log(Microsoft.Extensions.Logging.LogLevel, System.Int32, System.Object, System.Exception, System.Func<System.Object, System.Exception, System.String>)
    
        
        
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        
        
        :type eventId: System.Int32
        
        
        :type state: System.Object
        
        
        :type exception: System.Exception
        
        
        :type formatter: System.Func{System.Object,System.Exception,System.String}
    
        
        .. code-block:: csharp
    
           public void Log(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Logging.Testing.TestLogger
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Logging.Testing.TestLogger.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; set; }
    

