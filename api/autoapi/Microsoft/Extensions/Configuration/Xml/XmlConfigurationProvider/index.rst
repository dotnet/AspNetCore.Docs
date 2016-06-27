

XmlConfigurationProvider Class
==============================






Represents an XML file as an :any:`Microsoft.Extensions.Configuration.IConfigurationSource`\.


Namespace
    :dn:ns:`Microsoft.Extensions.Configuration.Xml`
Assemblies
    * Microsoft.Extensions.Configuration.Xml

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.ConfigurationProvider`
* :dn:cls:`Microsoft.Extensions.Configuration.FileConfigurationProvider`
* :dn:cls:`Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider`








Syntax
------

.. code-block:: csharp

    public class XmlConfigurationProvider : FileConfigurationProvider, IConfigurationProvider








.. dn:class:: Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider

Constructors
------------

.. dn:class:: Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider.XmlConfigurationProvider(Microsoft.Extensions.Configuration.Xml.XmlConfigurationSource)
    
        
    
        
        Initializes a new instance with the specified source.
    
        
    
        
        :param source: The source settings.
        
        :type source: Microsoft.Extensions.Configuration.Xml.XmlConfigurationSource
    
        
        .. code-block:: csharp
    
            public XmlConfigurationProvider(XmlConfigurationSource source)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider.Load(System.IO.Stream)
    
        
    
        
        Loads the XML data from a stream.
    
        
    
        
        :param stream: The stream to read.
        
        :type stream: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public override void Load(Stream stream)
    

