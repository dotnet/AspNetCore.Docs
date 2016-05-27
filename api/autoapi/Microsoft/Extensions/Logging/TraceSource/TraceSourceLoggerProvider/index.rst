

TraceSourceLoggerProvider Class
===============================






Provides an ILoggerFactory based on System.Diagnostics.TraceSource.


Namespace
    :dn:ns:`Microsoft.Extensions.Logging.TraceSource`
Assemblies
    * Microsoft.Extensions.Logging.TraceSource

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.TraceSource.TraceSourceLoggerProvider`








Syntax
------

.. code-block:: csharp

    public class TraceSourceLoggerProvider : ILoggerProvider, IDisposable








.. dn:class:: Microsoft.Extensions.Logging.TraceSource.TraceSourceLoggerProvider
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.TraceSource.TraceSourceLoggerProvider

Constructors
------------

.. dn:class:: Microsoft.Extensions.Logging.TraceSource.TraceSourceLoggerProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Logging.TraceSource.TraceSourceLoggerProvider.TraceSourceLoggerProvider(System.Diagnostics.SourceSwitch, System.Diagnostics.TraceListener)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.Extensions.Logging.TraceSource.TraceSourceLoggerProvider` class.
    
        
    
        
        :type rootSourceSwitch: System.Diagnostics.SourceSwitch
    
        
        :type rootTraceListener: System.Diagnostics.TraceListener
    
        
        .. code-block:: csharp
    
            public TraceSourceLoggerProvider(SourceSwitch rootSourceSwitch, TraceListener rootTraceListener)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.TraceSource.TraceSourceLoggerProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.TraceSource.TraceSourceLoggerProvider.CreateLogger(System.String)
    
        
    
        
        Creates a new :any:`Microsoft.Extensions.Logging.ILogger`  for the given component name.
    
        
    
        
        :type name: System.String
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            public ILogger CreateLogger(string name)
    
    .. dn:method:: Microsoft.Extensions.Logging.TraceSource.TraceSourceLoggerProvider.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    

