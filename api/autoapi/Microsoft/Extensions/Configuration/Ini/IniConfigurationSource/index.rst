

IniConfigurationSource Class
============================






An INI file based :any:`Microsoft.Extensions.Configuration.IConfigurationSource`\.
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
* :dn:cls:`Microsoft.Extensions.Configuration.FileConfigurationSource`
* :dn:cls:`Microsoft.Extensions.Configuration.Ini.IniConfigurationSource`








Syntax
------

.. code-block:: csharp

    public class IniConfigurationSource : FileConfigurationSource, IConfigurationSource








.. dn:class:: Microsoft.Extensions.Configuration.Ini.IniConfigurationSource
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.Ini.IniConfigurationSource

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.Ini.IniConfigurationSource
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.Ini.IniConfigurationSource.Build(Microsoft.Extensions.Configuration.IConfigurationBuilder)
    
        
    
        
        :type builder: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :rtype: Microsoft.Extensions.Configuration.IConfigurationProvider
    
        
        .. code-block:: csharp
    
            public override IConfigurationProvider Build(IConfigurationBuilder builder)
    

