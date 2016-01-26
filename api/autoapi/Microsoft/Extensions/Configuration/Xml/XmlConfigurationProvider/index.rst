

XmlConfigurationProvider Class
==============================



.. contents:: 
   :local:



Summary
-------

An XML file based :any:`Microsoft.Extensions.Configuration.ConfigurationProvider`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.ConfigurationProvider`
* :dn:cls:`Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider`








Syntax
------

.. code-block:: csharp

   public class XmlConfigurationProvider : ConfigurationProvider, IConfigurationProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/configuration/blob/master/src/Microsoft.Extensions.Configuration.Xml/XmlConfigurationProvider.cs>`_





.. dn:class:: Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider

Constructors
------------

.. dn:class:: Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider.XmlConfigurationProvider(System.String)
    
        
    
        Initializes a new instance of :any:`Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider`\.
    
        
        
        
        :param path: Absolute path of the XML configuration file.
        
        :type path: System.String
    
        
        .. code-block:: csharp
    
           public XmlConfigurationProvider(string path)
    
    .. dn:constructor:: Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider.XmlConfigurationProvider(System.String, System.Boolean)
    
        
        
        
        :type path: System.String
        
        
        :type optional: System.Boolean
    
        
        .. code-block:: csharp
    
           public XmlConfigurationProvider(string path, bool optional)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider.Load()
    
        
    
        Loads the contents of the file at :dn:prop:`Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider.Path`\.
    
        
    
        
        .. code-block:: csharp
    
           public override void Load()
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider.Optional
    
        
    
        Gets a value that determines if this instance of :any:`Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider` is optional.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Optional { get; }
    
    .. dn:property:: Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider.Path
    
        
    
        The absolute path of the file backing this instance of :any:`Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Path { get; }
    

