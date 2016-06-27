

FileConfigurationSource Class
=============================






Represents a base class for file based :any:`Microsoft.Extensions.Configuration.IConfigurationSource`\.


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
* :dn:cls:`Microsoft.Extensions.Configuration.FileConfigurationSource`








Syntax
------

.. code-block:: csharp

    public abstract class FileConfigurationSource : IConfigurationSource








.. dn:class:: Microsoft.Extensions.Configuration.FileConfigurationSource
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.FileConfigurationSource

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.FileConfigurationSource
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.FileConfigurationSource.Build(Microsoft.Extensions.Configuration.IConfigurationBuilder)
    
        
    
        
        Builds the :any:`Microsoft.Extensions.Configuration.IConfigurationProvider` for this source.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`\.
        
        :type builder: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :rtype: Microsoft.Extensions.Configuration.IConfigurationProvider
        :return: A :any:`Microsoft.Extensions.Configuration.IConfigurationProvider`
    
        
        .. code-block:: csharp
    
            public abstract IConfigurationProvider Build(IConfigurationBuilder builder)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Configuration.FileConfigurationSource
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Configuration.FileConfigurationSource.FileProvider
    
        
    
        
        Used to access the contents of the file.
    
        
        :rtype: Microsoft.Extensions.FileProviders.IFileProvider
    
        
        .. code-block:: csharp
    
            public IFileProvider FileProvider { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Configuration.FileConfigurationSource.Optional
    
        
    
        
        Determines if loading the file is optional.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Optional { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Configuration.FileConfigurationSource.Path
    
        
    
        
        The path to the file.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Path { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Configuration.FileConfigurationSource.ReloadOnChange
    
        
    
        
        Determines whether the source will be loaded if the underlying file changes.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ReloadOnChange { get; set; }
    

