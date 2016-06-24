

Microsoft.Extensions.Configuration Namespace
============================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/Extensions/Configuration/CommandLineConfigurationExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/Configuration/ConfigurationBinder/index
   
   
   
   /autoapi/Microsoft/Extensions/Configuration/ConfigurationBuilder/index
   
   
   
   /autoapi/Microsoft/Extensions/Configuration/ConfigurationExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/Configuration/ConfigurationKeyComparer/index
   
   
   
   /autoapi/Microsoft/Extensions/Configuration/ConfigurationPath/index
   
   
   
   /autoapi/Microsoft/Extensions/Configuration/ConfigurationProvider/index
   
   
   
   /autoapi/Microsoft/Extensions/Configuration/ConfigurationReloadToken/index
   
   
   
   /autoapi/Microsoft/Extensions/Configuration/ConfigurationRoot/index
   
   
   
   /autoapi/Microsoft/Extensions/Configuration/ConfigurationSection/index
   
   
   
   /autoapi/Microsoft/Extensions/Configuration/EnvironmentVariablesExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/Configuration/FileConfigurationExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/Configuration/FileConfigurationProvider/index
   
   
   
   /autoapi/Microsoft/Extensions/Configuration/FileConfigurationSource/index
   
   
   
   /autoapi/Microsoft/Extensions/Configuration/IConfiguration/index
   
   
   
   /autoapi/Microsoft/Extensions/Configuration/IConfigurationBuilder/index
   
   
   
   /autoapi/Microsoft/Extensions/Configuration/IConfigurationProvider/index
   
   
   
   /autoapi/Microsoft/Extensions/Configuration/IConfigurationRoot/index
   
   
   
   /autoapi/Microsoft/Extensions/Configuration/IConfigurationSection/index
   
   
   
   /autoapi/Microsoft/Extensions/Configuration/IConfigurationSource/index
   
   
   
   /autoapi/Microsoft/Extensions/Configuration/IniConfigurationExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/Configuration/JsonConfigurationExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/Configuration/MemoryConfigurationBuilderExtensions/index
   
   
   
   /autoapi/Microsoft/Extensions/Configuration/XmlConfigurationExtensions/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.Extensions.Configuration


    .. rubric:: Interfaces


    interface :dn:iface:`IConfiguration`
        .. object: type=interface name=Microsoft.Extensions.Configuration.IConfiguration

        
        Represents a set of key/value application configuration properties.


    interface :dn:iface:`IConfigurationBuilder`
        .. object: type=interface name=Microsoft.Extensions.Configuration.IConfigurationBuilder

        
        Represents a type used to build application configuration.


    interface :dn:iface:`IConfigurationProvider`
        .. object: type=interface name=Microsoft.Extensions.Configuration.IConfigurationProvider

        
        Provides configuration key/values for an application.


    interface :dn:iface:`IConfigurationRoot`
        .. object: type=interface name=Microsoft.Extensions.Configuration.IConfigurationRoot

        
        Represents the root of an :any:`Microsoft.Extensions.Configuration.IConfiguration` hierarchy.


    interface :dn:iface:`IConfigurationSection`
        .. object: type=interface name=Microsoft.Extensions.Configuration.IConfigurationSection

        
        Represents a section of application configuration values.


    interface :dn:iface:`IConfigurationSource`
        .. object: type=interface name=Microsoft.Extensions.Configuration.IConfigurationSource

        
        Represents a source of configuration key/values for an application.


    .. rubric:: Classes


    class :dn:cls:`CommandLineConfigurationExtensions`
        .. object: type=class name=Microsoft.Extensions.Configuration.CommandLineConfigurationExtensions

        
        Extension methods for registering :any:`Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationProvider` with :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`\.


    class :dn:cls:`ConfigurationBinder`
        .. object: type=class name=Microsoft.Extensions.Configuration.ConfigurationBinder

        
        Static helper class that allows binding strongly typed objects to configuration values.


    class :dn:cls:`ConfigurationBuilder`
        .. object: type=class name=Microsoft.Extensions.Configuration.ConfigurationBuilder

        
        Used to build key/value based configuration settings for use in an application.


    class :dn:cls:`ConfigurationExtensions`
        .. object: type=class name=Microsoft.Extensions.Configuration.ConfigurationExtensions

        
        Extension methods for :any:`Microsoft.Extensions.Configuration.IConfiguration`\.


    class :dn:cls:`ConfigurationKeyComparer`
        .. object: type=class name=Microsoft.Extensions.Configuration.ConfigurationKeyComparer

        
        IComparer implementation used to order configuration keys.


    class :dn:cls:`ConfigurationPath`
        .. object: type=class name=Microsoft.Extensions.Configuration.ConfigurationPath

        
        Utility methods and constants for manipulating Configuration paths


    class :dn:cls:`ConfigurationProvider`
        .. object: type=class name=Microsoft.Extensions.Configuration.ConfigurationProvider

        
        Base helper class for implementing an :any:`Microsoft.Extensions.Configuration.IConfigurationProvider`


    class :dn:cls:`ConfigurationReloadToken`
        .. object: type=class name=Microsoft.Extensions.Configuration.ConfigurationReloadToken

        
        Implements :any:`Microsoft.Extensions.Primitives.IChangeToken`


    class :dn:cls:`ConfigurationRoot`
        .. object: type=class name=Microsoft.Extensions.Configuration.ConfigurationRoot

        
        The root node for a configuration.


    class :dn:cls:`ConfigurationSection`
        .. object: type=class name=Microsoft.Extensions.Configuration.ConfigurationSection

        
        Represents a section of application configuration values.


    class :dn:cls:`EnvironmentVariablesExtensions`
        .. object: type=class name=Microsoft.Extensions.Configuration.EnvironmentVariablesExtensions

        
        Extension methods for registering :any:`Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationProvider` with :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`\.


    class :dn:cls:`FileConfigurationExtensions`
        .. object: type=class name=Microsoft.Extensions.Configuration.FileConfigurationExtensions

        
        Extension methods for :any:`Microsoft.Extensions.Configuration.FileConfigurationProvider`\.


    class :dn:cls:`FileConfigurationProvider`
        .. object: type=class name=Microsoft.Extensions.Configuration.FileConfigurationProvider

        
        Base class for file based :any:`Microsoft.Extensions.Configuration.ConfigurationProvider`\.


    class :dn:cls:`FileConfigurationSource`
        .. object: type=class name=Microsoft.Extensions.Configuration.FileConfigurationSource

        
        Represents a base class for file based :any:`Microsoft.Extensions.Configuration.IConfigurationSource`\.


    class :dn:cls:`IniConfigurationExtensions`
        .. object: type=class name=Microsoft.Extensions.Configuration.IniConfigurationExtensions

        
        Extension methods for adding :any:`Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider`\.


    class :dn:cls:`JsonConfigurationExtensions`
        .. object: type=class name=Microsoft.Extensions.Configuration.JsonConfigurationExtensions

        
        Extension methods for adding :any:`Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider`\.


    class :dn:cls:`MemoryConfigurationBuilderExtensions`
        .. object: type=class name=Microsoft.Extensions.Configuration.MemoryConfigurationBuilderExtensions

        
        IConfigurationBuilder extension methods for the MemoryConfigurationProvider.


    class :dn:cls:`XmlConfigurationExtensions`
        .. object: type=class name=Microsoft.Extensions.Configuration.XmlConfigurationExtensions

        
        Extension methods for adding :any:`Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider`\.


