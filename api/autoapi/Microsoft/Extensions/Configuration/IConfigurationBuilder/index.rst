

IConfigurationBuilder Interface
===============================






Represents a type used to build application configuration.


Namespace
    :dn:ns:`Microsoft.Extensions.Configuration`
Assemblies
    * Microsoft.Extensions.Configuration.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IConfigurationBuilder








.. dn:interface:: Microsoft.Extensions.Configuration.IConfigurationBuilder
    :hidden:

.. dn:interface:: Microsoft.Extensions.Configuration.IConfigurationBuilder

Properties
----------

.. dn:interface:: Microsoft.Extensions.Configuration.IConfigurationBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Configuration.IConfigurationBuilder.Properties
    
        
    
        
        Gets a key/value collection that can be used to share data between the :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`
        and the registered :any:`Microsoft.Extensions.Configuration.IConfigurationSource`\s.
    
        
        :rtype: System.Collections.Generic.Dictionary<System.Collections.Generic.Dictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            Dictionary<string, object> Properties
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.Configuration.IConfigurationBuilder.Sources
    
        
    
        
        Gets the sources used to obtain configuation values
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.Configuration.IConfigurationSource<Microsoft.Extensions.Configuration.IConfigurationSource>}
    
        
        .. code-block:: csharp
    
            IEnumerable<IConfigurationSource> Sources
            {
                get;
            }
    

Methods
-------

.. dn:interface:: Microsoft.Extensions.Configuration.IConfigurationBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.IConfigurationBuilder.Add(Microsoft.Extensions.Configuration.IConfigurationSource)
    
        
    
        
        Adds a new configuration source.
    
        
    
        
        :param source: The configuration source to add.
        
        :type source: Microsoft.Extensions.Configuration.IConfigurationSource
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :return: The same :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`\.
    
        
        .. code-block:: csharp
    
            IConfigurationBuilder Add(IConfigurationSource source)
    
    .. dn:method:: Microsoft.Extensions.Configuration.IConfigurationBuilder.Build()
    
        
    
        
        Builds an :any:`Microsoft.Extensions.Configuration.IConfiguration` with keys and values from the set of sources registered in
        :dn:prop:`Microsoft.Extensions.Configuration.IConfigurationBuilder.Sources`\.
    
        
        :rtype: Microsoft.Extensions.Configuration.IConfigurationRoot
        :return: An :any:`Microsoft.Extensions.Configuration.IConfigurationRoot` with keys and values from the registered sources.
    
        
        .. code-block:: csharp
    
            IConfigurationRoot Build()
    

