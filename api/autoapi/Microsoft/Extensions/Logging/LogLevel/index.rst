

LogLevel Enum
=============






Defines logging severity levels.


Namespace
    :dn:ns:`Microsoft.Extensions.Logging`
Assemblies
    * Microsoft.Extensions.Logging.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public enum LogLevel








.. dn:enumeration:: Microsoft.Extensions.Logging.LogLevel
    :hidden:

.. dn:enumeration:: Microsoft.Extensions.Logging.LogLevel

Fields
------

.. dn:enumeration:: Microsoft.Extensions.Logging.LogLevel
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.Extensions.Logging.LogLevel.Critical
    
        
    
        
        Logs that describe an unrecoverable application or system crash, or a catastrophic failure that requires
        immediate attention.
    
        
        :rtype: Microsoft.Extensions.Logging.LogLevel
    
        
        .. code-block:: csharp
    
            Critical = 5
    
    .. dn:field:: Microsoft.Extensions.Logging.LogLevel.Debug
    
        
    
        
        Logs that are used for interactive investigation during development.  These logs should primarily contain
        information useful for debugging and have no long-term value.
    
        
        :rtype: Microsoft.Extensions.Logging.LogLevel
    
        
        .. code-block:: csharp
    
            Debug = 1
    
    .. dn:field:: Microsoft.Extensions.Logging.LogLevel.Error
    
        
    
        
        Logs that highlight when the current flow of execution is stopped due to a failure. These should indicate a
        failure in the current activity, not an application-wide failure.
    
        
        :rtype: Microsoft.Extensions.Logging.LogLevel
    
        
        .. code-block:: csharp
    
            Error = 4
    
    .. dn:field:: Microsoft.Extensions.Logging.LogLevel.Information
    
        
    
        
        Logs that track the general flow of the application. These logs should have long-term value.
    
        
        :rtype: Microsoft.Extensions.Logging.LogLevel
    
        
        .. code-block:: csharp
    
            Information = 2
    
    .. dn:field:: Microsoft.Extensions.Logging.LogLevel.None
    
        
    
        
        Not used for writing log messages. Specifies that a logging category should not write any messages.
    
        
        :rtype: Microsoft.Extensions.Logging.LogLevel
    
        
        .. code-block:: csharp
    
            None = 6
    
    .. dn:field:: Microsoft.Extensions.Logging.LogLevel.Trace
    
        
    
        
        Logs that contain the most detailed messages. These messages may contain sensitive application data.
        These messages are disabled by default and should never be enabled in a production environment.
    
        
        :rtype: Microsoft.Extensions.Logging.LogLevel
    
        
        .. code-block:: csharp
    
            Trace = 0
    
    .. dn:field:: Microsoft.Extensions.Logging.LogLevel.Warning
    
        
    
        
        Logs that highlight an abnormal or unexpected event in the application flow, but do not otherwise cause the
        application execution to stop.
    
        
        :rtype: Microsoft.Extensions.Logging.LogLevel
    
        
        .. code-block:: csharp
    
            Warning = 3
    

