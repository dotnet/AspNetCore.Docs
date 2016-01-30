

MemoryConfigurationExtensions Class
===================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.MemoryConfigurationExtensions`








Syntax
------

.. code-block:: csharp

   public class MemoryConfigurationExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/configuration/blob/master/src/Microsoft.Extensions.Configuration/MemoryConfigurationExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.Configuration.MemoryConfigurationExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.MemoryConfigurationExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.MemoryConfigurationExtensions.AddInMemoryCollection(Microsoft.Extensions.Configuration.IConfigurationBuilder)
    
        
    
        Adds the memory configuration provider to ``configuraton``.
    
        
        
        
        :param configurationBuilder: The  to add to.
        
        :type configurationBuilder: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :return: The <see cref="T:Microsoft.Extensions.Configuration.IConfigurationBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IConfigurationBuilder AddInMemoryCollection(IConfigurationBuilder configurationBuilder)
    
    .. dn:method:: Microsoft.Extensions.Configuration.MemoryConfigurationExtensions.AddInMemoryCollection(Microsoft.Extensions.Configuration.IConfigurationBuilder, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, System.String>>)
    
        
    
        Adds the memory configuration provider to ``configuraton``.
    
        
        
        
        :param configurationBuilder: The  to add to.
        
        :type configurationBuilder: Microsoft.Extensions.Configuration.IConfigurationBuilder
        
        
        :param initialData: The data to add to memory configuration provider.
        
        :type initialData: System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.String}}
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :return: The <see cref="T:Microsoft.Extensions.Configuration.IConfigurationBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IConfigurationBuilder AddInMemoryCollection(IConfigurationBuilder configurationBuilder, IEnumerable<KeyValuePair<string, string>> initialData)
    

