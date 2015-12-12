

TraceSourceFactoryExtensions Class
==================================



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





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/logging/src/Microsoft.Extensions.Logging.TraceSource/TraceSourceFactoryExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.Logging.TraceSourceFactoryExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.TraceSourceFactoryExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.TraceSourceFactoryExtensions.AddTraceSource(Microsoft.Extensions.Logging.ILoggerFactory, System.Diagnostics.SourceSwitch, System.Diagnostics.TraceListener)
    
        
        
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
        
        
        :type sourceSwitch: System.Diagnostics.SourceSwitch
        
        
        :type listener: System.Diagnostics.TraceListener
        :rtype: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
           public static ILoggerFactory AddTraceSource(ILoggerFactory factory, SourceSwitch sourceSwitch, TraceListener listener)
    
    .. dn:method:: Microsoft.Extensions.Logging.TraceSourceFactoryExtensions.AddTraceSource(Microsoft.Extensions.Logging.ILoggerFactory, System.String, System.Diagnostics.TraceListener)
    
        
        
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
        
        
        :type switchName: System.String
        
        
        :type listener: System.Diagnostics.TraceListener
        :rtype: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
           public static ILoggerFactory AddTraceSource(ILoggerFactory factory, string switchName, TraceListener listener)
    

