

FileConfigurationProvider Class
===============================






Base class for file based :any:`Microsoft.Extensions.Configuration.ConfigurationProvider`\.


Namespace
    :dn:ns:`Microsoft.Extensions.Configuration`
Assemblies
    * Microsoft.Extensions.Configuration.FileExtensions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.ConfigurationProvider`
* :dn:cls:`Microsoft.Extensions.Configuration.FileConfigurationProvider`








Syntax
------

.. code-block:: csharp

    public abstract class FileConfigurationProvider : ConfigurationProvider, IConfigurationProvider








.. dn:class:: Microsoft.Extensions.Configuration.FileConfigurationProvider
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.FileConfigurationProvider

Properties
----------

.. dn:class:: Microsoft.Extensions.Configuration.FileConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Configuration.FileConfigurationProvider.Source
    
        
        :rtype: Microsoft.Extensions.Configuration.FileConfigurationSource
    
        
        .. code-block:: csharp
    
            public FileConfigurationSource Source
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Extensions.Configuration.FileConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Configuration.FileConfigurationProvider.FileConfigurationProvider(Microsoft.Extensions.Configuration.FileConfigurationSource)
    
        
    
        
        :type source: Microsoft.Extensions.Configuration.FileConfigurationSource
    
        
        .. code-block:: csharp
    
            public FileConfigurationProvider(FileConfigurationSource source)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.FileConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.FileConfigurationProvider.Load()
    
        
    
        
        Loads the contents of the file at :any:`System.IO.Path`\.
    
        
    
        
        .. code-block:: csharp
    
            public override void Load()
    
    .. dn:method:: Microsoft.Extensions.Configuration.FileConfigurationProvider.Load(System.IO.Stream)
    
        
    
        
        :type stream: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public abstract void Load(Stream stream)
    

