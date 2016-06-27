

ConfigurationSection Class
==========================






Represents a section of application configuration values.


Namespace
    :dn:ns:`Microsoft.Extensions.Configuration`
Assemblies
    * Microsoft.Extensions.Configuration

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.ConfigurationSection`








Syntax
------

.. code-block:: csharp

    public class ConfigurationSection : IConfigurationSection, IConfiguration








.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationSection
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationSection

Constructors
------------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationSection
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Configuration.ConfigurationSection.ConfigurationSection(Microsoft.Extensions.Configuration.ConfigurationRoot, System.String)
    
        
    
        
        Initializes a new instance.
    
        
    
        
        :param root: The configuration root.
        
        :type root: Microsoft.Extensions.Configuration.ConfigurationRoot
    
        
        :param path: The path to this section.
        
        :type path: System.String
    
        
        .. code-block:: csharp
    
            public ConfigurationSection(ConfigurationRoot root, string path)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationSection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationSection.GetChildren()
    
        
    
        
        Gets the immediate descendant configuration sub-sections.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.Configuration.IConfigurationSection<Microsoft.Extensions.Configuration.IConfigurationSection>}
        :return: The configuration sub-sections.
    
        
        .. code-block:: csharp
    
            public IEnumerable<IConfigurationSection> GetChildren()
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationSection.GetReloadToken()
    
        
    
        
        Returns a :any:`Microsoft.Extensions.Primitives.IChangeToken` that can be used to observe when this configuration is reloaded.
    
        
        :rtype: Microsoft.Extensions.Primitives.IChangeToken
    
        
        .. code-block:: csharp
    
            public IChangeToken GetReloadToken()
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationSection.GetSection(System.String)
    
        
    
        
        Gets a configuration sub-section with the specified key.
    
        
    
        
        :param key: The key of the configuration section.
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Configuration.IConfigurationSection
        :return: The :any:`Microsoft.Extensions.Configuration.IConfigurationSection`\.
    
        
        .. code-block:: csharp
    
            public IConfigurationSection GetSection(string key)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationSection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Configuration.ConfigurationSection.Item[System.String]
    
        
    
        
        Gets or sets the value corresponding to a configuration key.
    
        
    
        
        :param key: The configuration key.
        
        :type key: System.String
        :rtype: System.String
        :return: The configuration value.
    
        
        .. code-block:: csharp
    
            public string this[string key] { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Configuration.ConfigurationSection.Key
    
        
    
        
        Gets the key this section occupies in its parent.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Key { get; }
    
    .. dn:property:: Microsoft.Extensions.Configuration.ConfigurationSection.Path
    
        
    
        
        Gets the full path to this section from the :any:`Microsoft.Extensions.Configuration.IConfigurationRoot`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Path { get; }
    
    .. dn:property:: Microsoft.Extensions.Configuration.ConfigurationSection.Value
    
        
    
        
        Gets or sets the section value.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Value { get; set; }
    

