

Microsoft.Extensions.Logging Namespace
======================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/Extensions/Logging/ConsoleLoggerExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/DebugLoggerFactoryExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/EventLoggerFactoryExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/ILogValues/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/ILogger/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/ILoggerFactory/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/ILoggerProvider/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/ILogger-TCategoryName/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/LogFormatter/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/LogLevel/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/LoggerExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/LoggerFactory/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/LoggerFactoryExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/LoggerMessage/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/Logger-T/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/NLogLoggerFactoryExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/Logging/TraceSourceFactoryExtensions/index
   
   











.. dn:namespace:: Microsoft.Extensions.Logging


    .. rubric:: Classes


    class :dn:cls:`Microsoft.Extensions.Logging.ConsoleLoggerExtensions`
        


    class :dn:cls:`Microsoft.Extensions.Logging.DebugLoggerFactoryExtensions`
        Extension methods for the :any:`Microsoft.Extensions.Logging.ILoggerFactory` class.


    class :dn:cls:`Microsoft.Extensions.Logging.EventLoggerFactoryExtensions`
        Extension methods for the :any:`Microsoft.Extensions.Logging.ILoggerFactory` class.


    class :dn:cls:`Microsoft.Extensions.Logging.LogFormatter`
        Formatters for common logging scenarios.


    class :dn:cls:`Microsoft.Extensions.Logging.LoggerExtensions`
        ILogger extension methods for common scenarios.


    class :dn:cls:`Microsoft.Extensions.Logging.LoggerFactory`
        Summary description for LoggerFactory


    class :dn:cls:`Microsoft.Extensions.Logging.LoggerFactoryExtensions`
        ILoggerFactory extension methods for common scenarios.


    class :dn:cls:`Microsoft.Extensions.Logging.LoggerMessage`
        Creates delegates which can be later cached to log messages in a performant way.


    class :dn:cls:`Microsoft.Extensions.Logging.Logger\<T>`
        Delegates to a new :any:`Microsoft.Extensions.Logging.ILogger` instance using the full name of the given type, created by the
        provided :any:`Microsoft.Extensions.Logging.ILoggerFactory`\.


    class :dn:cls:`Microsoft.Extensions.Logging.NLogLoggerFactoryExtensions`
        Summary description for NLogLoggerFactoryExtensions


    class :dn:cls:`Microsoft.Extensions.Logging.TraceSourceFactoryExtensions`
        


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.Extensions.Logging.ILogValues`
        


    interface :dn:iface:`Microsoft.Extensions.Logging.ILogger`
        Represents a type used to perform logging.


    interface :dn:iface:`Microsoft.Extensions.Logging.ILoggerFactory`
        Represents a type used to configure the logging system and create instances of :any:`Microsoft.Extensions.Logging.ILogger` from
        the registered :any:`Microsoft.Extensions.Logging.ILoggerProvider`\s.


    interface :dn:iface:`Microsoft.Extensions.Logging.ILoggerProvider`
        Represents a type that can create instances of :any:`Microsoft.Extensions.Logging.ILogger`\.


    interface :dn:iface:`Microsoft.Extensions.Logging.ILogger\<TCategoryName>`
        A generic interface for logging where the category name is derived from the specified
        ``TCategoryName`` type name.
        Generally used to enable activation of a named :any:`Microsoft.Extensions.Logging.ILogger` from dependency injection.


    .. rubric:: Enumerations


    enum :dn:enum:`Microsoft.Extensions.Logging.LogLevel`
        Defines logging severity levels.


