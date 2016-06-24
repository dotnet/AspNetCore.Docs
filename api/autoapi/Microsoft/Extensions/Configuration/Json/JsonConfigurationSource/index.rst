

JsonConfigurationSource Class
=============================






Represents a JSON file as an :any:`Microsoft.Extensions.Configuration.IConfigurationSource`\.


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
* :dn:cls:`Microsoft.Extensions.Configuration.FileConfigurationSource`
* :dn:cls:`Microsoft.Extensions.Configuration.Json.JsonConfigurationSource`








Syntax
------

.. code-block:: csharp

    public class JsonConfigurationSource : FileConfigurationSource, IConfigurationSource








.. dn:class:: Microsoft.Extensions.Configuration.Json.JsonConfigurationSource
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.Json.JsonConfigurationSource

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.Json.JsonConfigurationSource
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.Json.JsonConfigurationSource.Build(Microsoft.Extensions.Configuration.IConfigurationBuilder)
    
        
    
        
        Builds the :any:`Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider` for this source.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`\.
        
        :type builder: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :rtype: Microsoft.Extensions.Configuration.IConfigurationProvider
        :return: A :any:`Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider`
    
        
        .. code-block:: csharp
    
            public override IConfigurationProvider Build(IConfigurationBuilder builder)
    

