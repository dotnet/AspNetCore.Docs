

IConfigurationBuilder Interface
===============================



.. contents:: 
   :local:



Summary
-------

Represents a type used to build application configuration.











Syntax
------

.. code-block:: csharp

   public interface IConfigurationBuilder





GitHub
------

`View on GitHub <https://github.com/aspnet/configuration/blob/master/src/Microsoft.Extensions.Configuration.Abstractions/IConfigurationBuilder.cs>`_





.. dn:interface:: Microsoft.Extensions.Configuration.IConfigurationBuilder

Methods
-------

.. dn:interface:: Microsoft.Extensions.Configuration.IConfigurationBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.IConfigurationBuilder.Add(Microsoft.Extensions.Configuration.IConfigurationProvider)
    
        
    
        Adds a new configuration provider.
    
        
        
        
        :param provider: The configuration provider to add.
        
        :type provider: Microsoft.Extensions.Configuration.IConfigurationProvider
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :return: The same <see cref="T:Microsoft.Extensions.Configuration.IConfigurationBuilder" />.
    
        
        .. code-block:: csharp
    
           IConfigurationBuilder Add(IConfigurationProvider provider)
    
    .. dn:method:: Microsoft.Extensions.Configuration.IConfigurationBuilder.Build()
    
        
    
        Builds an :any:`Microsoft.Extensions.Configuration.IConfiguration` with keys and values from the set of providers registered in 
        :dn:prop:`Microsoft.Extensions.Configuration.IConfigurationBuilder.Providers`\.
    
        
        :rtype: Microsoft.Extensions.Configuration.IConfigurationRoot
        :return: An <see cref="T:Microsoft.Extensions.Configuration.IConfigurationRoot" /> with keys and values from the registered providers.
    
        
        .. code-block:: csharp
    
           IConfigurationRoot Build()
    

Properties
----------

.. dn:interface:: Microsoft.Extensions.Configuration.IConfigurationBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Configuration.IConfigurationBuilder.Properties
    
        
    
        Gets a key/value collection that can be used to share data between the :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`
        and the registered :any:`Microsoft.Extensions.Configuration.IConfigurationProvider`\s.
    
        
        :rtype: System.Collections.Generic.Dictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           Dictionary<string, object> Properties { get; }
    
    .. dn:property:: Microsoft.Extensions.Configuration.IConfigurationBuilder.Providers
    
        
    
        Gets the providers used to obtain configuation values
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.Extensions.Configuration.IConfigurationProvider}
    
        
        .. code-block:: csharp
    
           IEnumerable<IConfigurationProvider> Providers { get; }
    

