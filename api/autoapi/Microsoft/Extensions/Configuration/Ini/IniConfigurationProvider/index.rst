

IniConfigurationProvider Class
==============================



.. contents:: 
   :local:



Summary
-------

An INI file based :any:`Microsoft.Extensions.Configuration.ConfigurationProvider`\.
Files are simple line structures (<a href="http://en.wikipedia.org/wiki/INI_file">INI Files on Wikipedia</a>)





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.ConfigurationProvider`
* :dn:cls:`Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider`








Syntax
------

.. code-block:: csharp

   public class IniConfigurationProvider : ConfigurationProvider, IConfigurationProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/configuration/src/Microsoft.Extensions.Configuration.Ini/IniConfigurationProvider.cs>`_





.. dn:class:: Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider

Constructors
------------

.. dn:class:: Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider.IniConfigurationProvider(System.String)
    
        
    
        Initializes a new instance of :any:`Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider`\.
    
        
        
        
        :param path: Absolute path of the INI configuration file.
        
        :type path: System.String
    
        
        .. code-block:: csharp
    
           public IniConfigurationProvider(string path)
    
    .. dn:constructor:: Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider.IniConfigurationProvider(System.String, System.Boolean)
    
        
    
        Initializes a new instance of :any:`Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider`\.
    
        
        
        
        :param path: Absolute path of the INI configuration file.
        
        :type path: System.String
        
        
        :param optional: Determines if the configuration is optional.
        
        :type optional: System.Boolean
    
        
        .. code-block:: csharp
    
           public IniConfigurationProvider(string path, bool optional)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider.Load()
    
        
    
        Loads the contents of the file at :dn:prop:`Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider.Path`\.
    
        
    
        
        .. code-block:: csharp
    
           public override void Load()
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider.Optional
    
        
    
        Gets a value that determines if this instance of :any:`Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider` is optional.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Optional { get; }
    
    .. dn:property:: Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider.Path
    
        
    
        The absolute path of the file backing this instance of :any:`Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Path { get; }
    

