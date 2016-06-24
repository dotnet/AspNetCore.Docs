

JsonConfigurationProvider Class
===============================






A JSON file based :any:`Microsoft.Extensions.Configuration.FileConfigurationProvider`\.


Namespace
    :dn:ns:`Microsoft.Extensions.Configuration.Json`
Assemblies
    * Microsoft.Extensions.Configuration.Json

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.ConfigurationProvider`
* :dn:cls:`Microsoft.Extensions.Configuration.FileConfigurationProvider`
* :dn:cls:`Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider`








Syntax
------

.. code-block:: csharp

    public class JsonConfigurationProvider : FileConfigurationProvider, IConfigurationProvider








.. dn:class:: Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider

Constructors
------------

.. dn:class:: Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider.JsonConfigurationProvider(Microsoft.Extensions.Configuration.Json.JsonConfigurationSource)
    
        
    
        
        Initializes a new instance with the specified source.
    
        
    
        
        :param source: The source settings.
        
        :type source: Microsoft.Extensions.Configuration.Json.JsonConfigurationSource
    
        
        .. code-block:: csharp
    
            public JsonConfigurationProvider(JsonConfigurationSource source)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider.Load(System.IO.Stream)
    
        
    
        
        Loads the JSON data from a stream.
    
        
    
        
        :param stream: The stream to read.
        
        :type stream: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public override void Load(Stream stream)
    

