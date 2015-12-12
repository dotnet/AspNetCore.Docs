

JsonConfigurationProvider Class
===============================



.. contents:: 
   :local:



Summary
-------

A JSON file based :any:`Microsoft.Extensions.Configuration.ConfigurationProvider`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.ConfigurationProvider`
* :dn:cls:`Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider`








Syntax
------

.. code-block:: csharp

   public class JsonConfigurationProvider : ConfigurationProvider, IConfigurationProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/configuration/src/Microsoft.Extensions.Configuration.Json/JsonConfigurationProvider.cs>`_





.. dn:class:: Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider

Constructors
------------

.. dn:class:: Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider.JsonConfigurationProvider(System.String)
    
        
    
        Initializes a new instance of :any:`Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider`\.
    
        
        
        
        :param path: Absolute path of the JSON configuration file.
        
        :type path: System.String
    
        
        .. code-block:: csharp
    
           public JsonConfigurationProvider(string path)
    
    .. dn:constructor:: Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider.JsonConfigurationProvider(System.String, System.Boolean)
    
        
    
        Initializes a new instance of :any:`Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider`\.
    
        
        
        
        :param path: Absolute path of the JSON configuration file.
        
        :type path: System.String
        
        
        :param optional: Determines if the configuration is optional.
        
        :type optional: System.Boolean
    
        
        .. code-block:: csharp
    
           public JsonConfigurationProvider(string path, bool optional)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider.Load()
    
        
    
        Loads the contents of the file at :dn:prop:`Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider.Path`\.
    
        
    
        
        .. code-block:: csharp
    
           public override void Load()
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider.Optional
    
        
    
        Gets a value that determines if this instance of :any:`Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider` is optional.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Optional { get; }
    
    .. dn:property:: Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider.Path
    
        
    
        The absolute path of the file backing this instance of :any:`Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Path { get; }
    

