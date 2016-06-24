

Microsoft.Extensions.Logging Namespace
======================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/Extensions/Logging/ConsoleLoggerExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/DebugLoggerFactoryExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/EventId/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/EventLoggerFactoryExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/FilterLoggerFactoryExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/FilterLoggerSettings/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/IFilterLoggerSettings/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/ILogger/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/ILoggerFactory/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/ILoggerProvider/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/ILogger-TCategoryName/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/LogLevel/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/LoggerExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/LoggerFactory/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/LoggerFactoryExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/LoggerMessage/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/Logger-T/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/TraceSourceFactoryExtensions/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.Extensions.Logging


    .. rubric:: Interfaces


    interface :dn:iface:`IFilterLoggerSettings`
        .. object: type=interface name=Microsoft.Extensions.Logging.IFilterLoggerSettings

        
        Filter settings for messages logged by an :any:`Microsoft.Extensions.Logging.ILogger`\.


    interface :dn:iface:`ILogger`
        .. object: type=interface name=Microsoft.Extensions.Logging.ILogger

        
        Represents a type used to perform logging.


    interface :dn:iface:`ILoggerFactory`
        .. object: type=interface name=Microsoft.Extensions.Logging.ILoggerFactory

        
        Represents a type used to configure the logging system and create instances of :any:`Microsoft.Extensions.Logging.ILogger` from
        the registered :any:`Microsoft.Extensions.Logging.ILoggerProvider`\s.


    interface :dn:iface:`ILoggerProvider`
        .. object: type=interface name=Microsoft.Extensions.Logging.ILoggerProvider

        
        Represents a type that can create instances of :any:`Microsoft.Extensions.Logging.ILogger`\.


    interface :dn:iface:`ILogger\<TCategoryName>`
        .. object: type=interface name=Microsoft.Extensions.Logging.ILogger\<TCategoryName>

        
        A generic interface for logging where the category name is derived from the specified
        <em>TCategoryName</em> type name.
        Generally used to enable activation of a named :any:`Microsoft.Extensions.Logging.ILogger` from dependency injection.


    .. rubric:: Enumerations


    enum :dn:enum:`LogLevel`
        .. object: type=enum name=Microsoft.Extensions.Logging.LogLevel

        
        Defines logging severity levels.


    .. rubric:: Classes


    class :dn:cls:`ConsoleLoggerExtensions`
        .. object: type=class name=Microsoft.Extensions.Logging.ConsoleLoggerExtensions

        


    class :dn:cls:`DebugLoggerFactoryExtensions`
        .. object: type=class name=Microsoft.Extensions.Logging.DebugLoggerFactoryExtensions

        
        Extension methods for the :any:`Microsoft.Extensions.Logging.ILoggerFactory` class.


    class :dn:cls:`EventLoggerFactoryExtensions`
        .. object: type=class name=Microsoft.Extensions.Logging.EventLoggerFactoryExtensions

        
        Extension methods for the :any:`Microsoft.Extensions.Logging.ILoggerFactory` class.


    class :dn:cls:`FilterLoggerFactoryExtensions`
        .. object: type=class name=Microsoft.Extensions.Logging.FilterLoggerFactoryExtensions

        
        :any:`Microsoft.Extensions.Logging.ILoggerFactory` extension methods which provide a common way to filter log messages across all
        registered :any:`Microsoft.Extensions.Logging.ILoggerProvider`\s.


    class :dn:cls:`FilterLoggerSettings`
        .. object: type=class name=Microsoft.Extensions.Logging.FilterLoggerSettings

        
        Filter settings for messages logged by an :any:`Microsoft.Extensions.Logging.ILogger`\.


    class :dn:cls:`LoggerExtensions`
        .. object: type=class name=Microsoft.Extensions.Logging.LoggerExtensions

        
        ILogger extension methods for common scenarios.


    class :dn:cls:`LoggerFactory`
        .. object: type=class name=Microsoft.Extensions.Logging.LoggerFactory

        
        Summary description for LoggerFactory


    class :dn:cls:`LoggerFactoryExtensions`
        .. object: type=class name=Microsoft.Extensions.Logging.LoggerFactoryExtensions

        
        ILoggerFactory extension methods for common scenarios.


    class :dn:cls:`LoggerMessage`
        .. object: type=class name=Microsoft.Extensions.Logging.LoggerMessage

        
        Creates delegates which can be later cached to log messages in a performant way.


    class :dn:cls:`Logger\<T>`
        .. object: type=class name=Microsoft.Extensions.Logging.Logger\<T>

        
        Delegates to a new :any:`Microsoft.Extensions.Logging.ILogger` instance using the full name of the given type, created by the
        provided :any:`Microsoft.Extensions.Logging.ILoggerFactory`\.


    class :dn:cls:`TraceSourceFactoryExtensions`
        .. object: type=class name=Microsoft.Extensions.Logging.TraceSourceFactoryExtensions

        


    .. rubric:: Structures


    struct :dn:struct:`EventId`
        .. object: type=struct name=Microsoft.Extensions.Logging.EventId

        


