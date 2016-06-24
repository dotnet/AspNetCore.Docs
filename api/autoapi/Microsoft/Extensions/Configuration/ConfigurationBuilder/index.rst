

ConfigurationBuilder Class
==========================






Used to build key/value based configuration settings for use in an application.


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
* :dn:cls:`Microsoft.Extensions.Configuration.ConfigurationBuilder`








Syntax
------

.. code-block:: csharp

    public class ConfigurationBuilder : IConfigurationBuilder








.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationBuilder
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationBuilder

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationBuilder.Add(Microsoft.Extensions.Configuration.IConfigurationSource)
    
        
    
        
        Adds a new configuration source.
    
        
    
        
        :param source: The configuration source to add.
        
        :type source: Microsoft.Extensions.Configuration.IConfigurationSource
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :return: The same :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`\.
    
        
        .. code-block:: csharp
    
            public IConfigurationBuilder Add(IConfigurationSource source)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationBuilder.Build()
    
        
    
        
        Builds an :any:`Microsoft.Extensions.Configuration.IConfiguration` with keys and values from the set of providers registered in 
        :dn:prop:`Microsoft.Extensions.Configuration.ConfigurationBuilder.Sources`\.
    
        
        :rtype: Microsoft.Extensions.Configuration.IConfigurationRoot
        :return: An :any:`Microsoft.Extensions.Configuration.IConfigurationRoot` with keys and values from the registered providers.
    
        
        .. code-block:: csharp
    
            public IConfigurationRoot Build()
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Configuration.ConfigurationBuilder.Properties
    
        
    
        
        Gets a key/value collection that can be used to share data between the :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`
        and the registered :any:`Microsoft.Extensions.Configuration.IConfigurationProvider`\s.
    
        
        :rtype: System.Collections.Generic.Dictionary<System.Collections.Generic.Dictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public Dictionary<string, object> Properties { get; }
    
    .. dn:property:: Microsoft.Extensions.Configuration.ConfigurationBuilder.Sources
    
        
    
        
        Returns the sources used to obtain configuation values.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.Configuration.IConfigurationSource<Microsoft.Extensions.Configuration.IConfigurationSource>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<IConfigurationSource> Sources { get; }
    

