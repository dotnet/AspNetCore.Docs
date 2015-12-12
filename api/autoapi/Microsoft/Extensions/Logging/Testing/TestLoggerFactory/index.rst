

TestLoggerFactory Class
=======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.Testing.TestLoggerFactory`








Syntax
------

.. code-block:: csharp

   public class TestLoggerFactory : ILoggerFactory, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/logging/src/Microsoft.Extensions.Logging.Testing/TestLoggerFactory.cs>`_





.. dn:class:: Microsoft.Extensions.Logging.Testing.TestLoggerFactory

Constructors
------------

.. dn:class:: Microsoft.Extensions.Logging.Testing.TestLoggerFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Logging.Testing.TestLoggerFactory.TestLoggerFactory(Microsoft.Extensions.Logging.Testing.TestSink, System.Boolean)
    
        
        
        
        :type sink: Microsoft.Extensions.Logging.Testing.TestSink
        
        
        :type enabled: System.Boolean
    
        
        .. code-block:: csharp
    
           public TestLoggerFactory(TestSink sink, bool enabled)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.Testing.TestLoggerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.TestLoggerFactory.AddProvider(Microsoft.Extensions.Logging.ILoggerProvider)
    
        
        
        
        :type provider: Microsoft.Extensions.Logging.ILoggerProvider
    
        
        .. code-block:: csharp
    
           public void AddProvider(ILoggerProvider provider)
    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.TestLoggerFactory.CreateLogger(System.String)
    
        
        
        
        :type name: System.String
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           public ILogger CreateLogger(string name)
    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.TestLoggerFactory.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Logging.Testing.TestLoggerFactory
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Logging.Testing.TestLoggerFactory.MinimumLevel
    
        
        :rtype: Microsoft.Extensions.Logging.LogLevel
    
        
        .. code-block:: csharp
    
           public LogLevel MinimumLevel { get; set; }
    

