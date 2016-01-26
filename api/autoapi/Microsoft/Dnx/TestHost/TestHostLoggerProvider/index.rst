

TestHostLoggerProvider Class
============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Dnx.TestHost.TestHostLoggerProvider`








Syntax
------

.. code-block:: csharp

   public class TestHostLoggerProvider : ILoggerProvider, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/testing/blob/master/src/Microsoft.Dnx.TestHost/TestAdapter/TestHostLoggerProvider.cs>`_





.. dn:class:: Microsoft.Dnx.TestHost.TestHostLoggerProvider

Constructors
------------

.. dn:class:: Microsoft.Dnx.TestHost.TestHostLoggerProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Dnx.TestHost.TestHostLoggerProvider.TestHostLoggerProvider(Microsoft.Dnx.TestHost.ReportingChannel)
    
        
        
        
        :type channel: Microsoft.Dnx.TestHost.ReportingChannel
    
        
        .. code-block:: csharp
    
           public TestHostLoggerProvider(ReportingChannel channel)
    

Methods
-------

.. dn:class:: Microsoft.Dnx.TestHost.TestHostLoggerProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Dnx.TestHost.TestHostLoggerProvider.CreateLogger(System.String)
    
        
        
        
        :type name: System.String
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           public ILogger CreateLogger(string name)
    
    .. dn:method:: Microsoft.Dnx.TestHost.TestHostLoggerProvider.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    

