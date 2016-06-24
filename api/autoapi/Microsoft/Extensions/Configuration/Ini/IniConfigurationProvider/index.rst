

IniConfigurationProvider Class
==============================






An INI file based :any:`Microsoft.Extensions.Configuration.ConfigurationProvider`\.
Files are simple line structures (<a href="http://en.wikipedia.org/wiki/INI_file">INI Files on Wikipedia</a>)


Namespace
    :dn:ns:`Microsoft.Extensions.Configuration.Ini`
Assemblies
    * Microsoft.Extensions.Configuration.Ini

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.ConfigurationProvider`
* :dn:cls:`Microsoft.Extensions.Configuration.FileConfigurationProvider`
* :dn:cls:`Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider`








Syntax
------

.. code-block:: csharp

    public class IniConfigurationProvider : FileConfigurationProvider, IConfigurationProvider








.. dn:class:: Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider

Constructors
------------

.. dn:class:: Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider.IniConfigurationProvider(Microsoft.Extensions.Configuration.Ini.IniConfigurationSource)
    
        
    
        
        Initializes a new instance with the specified source.
    
        
    
        
        :param source: The source settings.
        
        :type source: Microsoft.Extensions.Configuration.Ini.IniConfigurationSource
    
        
        .. code-block:: csharp
    
            public IniConfigurationProvider(IniConfigurationSource source)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider.Load(System.IO.Stream)
    
        
    
        
        Loads the INI data from a stream.
    
        
    
        
        :param stream: The stream to read.
        
        :type stream: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public override void Load(Stream stream)
    

