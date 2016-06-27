

MemoryConfigurationBuilderExtensions Class
==========================================






IConfigurationBuilder extension methods for the MemoryConfigurationProvider.


Namespace
    :dn:ns:`Microsoft.Extensions.Configuration`
Assemblies
    * Microsoft.Extensions.Configuration

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.MemoryConfigurationBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class MemoryConfigurationBuilderExtensions








.. dn:class:: Microsoft.Extensions.Configuration.MemoryConfigurationBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.MemoryConfigurationBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.MemoryConfigurationBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.MemoryConfigurationBuilderExtensions.AddInMemoryCollection(Microsoft.Extensions.Configuration.IConfigurationBuilder)
    
        
    
        
        Adds the memory configuration provider to <em>configurationBuilder</em>.
    
        
    
        
        :param configurationBuilder: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder` to add to.
        
        :type configurationBuilder: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :return: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IConfigurationBuilder AddInMemoryCollection(this IConfigurationBuilder configurationBuilder)
    
    .. dn:method:: Microsoft.Extensions.Configuration.MemoryConfigurationBuilderExtensions.AddInMemoryCollection(Microsoft.Extensions.Configuration.IConfigurationBuilder, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, System.String>>)
    
        
    
        
        Adds the memory configuration provider to <em>configurationBuilder</em>.
    
        
    
        
        :param configurationBuilder: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder` to add to.
        
        :type configurationBuilder: Microsoft.Extensions.Configuration.IConfigurationBuilder
    
        
        :param initialData: The data to add to memory configuration provider.
        
        :type initialData: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.String<System.String>}}
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :return: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IConfigurationBuilder AddInMemoryCollection(this IConfigurationBuilder configurationBuilder, IEnumerable<KeyValuePair<string, string>> initialData)
    

