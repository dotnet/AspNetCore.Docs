

XmlConfigurationProvider Class
==============================






An XML file based :any:`Microsoft.Extensions.Configuration.FileConfigurationProvider`\.


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
    
        
    
        
        :type source: Microsoft.Extensions.Configuration.Xml.XmlConfigurationSource
    
        
        .. code-block:: csharp
    
            public XmlConfigurationProvider(XmlConfigurationSource source)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider.Load(System.IO.Stream)
    
        
    
        
        :type stream: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public override void Load(Stream stream)
    

