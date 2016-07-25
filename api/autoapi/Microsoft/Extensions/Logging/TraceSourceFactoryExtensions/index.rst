

TraceSourceFactoryExtensions Class
==================================





Namespace
    :dn:ns:`Microsoft.Extensions.Logging`
Assemblies
    * Microsoft.Extensions.Logging.TraceSource

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.TraceSourceFactoryExtensions`








Syntax
------

.. code-block:: csharp

    public class TraceSourceFactoryExtensions








.. dn:class:: Microsoft.Extensions.Logging.TraceSourceFactoryExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.TraceSourceFactoryExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.TraceSourceFactoryExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.TraceSourceFactoryExtensions.AddTraceSource(Microsoft.Extensions.Logging.ILoggerFactory, System.Diagnostics.SourceSwitch)
    
        
    
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type sourceSwitch: System.Diagnostics.SourceSwitch
        :rtype: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public static ILoggerFactory AddTraceSource(this ILoggerFactory factory, SourceSwitch sourceSwitch)
    
    .. dn:method:: Microsoft.Extensions.Logging.TraceSourceFactoryExtensions.AddTraceSource(Microsoft.Extensions.Logging.ILoggerFactory, System.Diagnostics.SourceSwitch, System.Diagnostics.TraceListener)
    
        
    
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type sourceSwitch: System.Diagnostics.SourceSwitch
    
        
        :type listener: System.Diagnostics.TraceListener
        :rtype: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public static ILoggerFactory AddTraceSource(this ILoggerFactory factory, SourceSwitch sourceSwitch, TraceListener listener)
    
    .. dn:method:: Microsoft.Extensions.Logging.TraceSourceFactoryExtensions.AddTraceSource(Microsoft.Extensions.Logging.ILoggerFactory, System.String)
    
        
    
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type switchName: System.String
        :rtype: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public static ILoggerFactory AddTraceSource(this ILoggerFactory factory, string switchName)
    
    .. dn:method:: Microsoft.Extensions.Logging.TraceSourceFactoryExtensions.AddTraceSource(Microsoft.Extensions.Logging.ILoggerFactory, System.String, System.Diagnostics.TraceListener)
    
        
    
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type switchName: System.String
    
        
        :type listener: System.Diagnostics.TraceListener
        :rtype: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public static ILoggerFactory AddTraceSource(this ILoggerFactory factory, string switchName, TraceListener listener)
    

