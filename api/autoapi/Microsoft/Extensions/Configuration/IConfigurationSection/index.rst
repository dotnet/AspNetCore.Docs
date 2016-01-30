

IConfigurationSection Interface
===============================



.. contents:: 
   :local:



Summary
-------

Represents a section of application configuration values.











Syntax
------

.. code-block:: csharp

   public interface IConfigurationSection : IConfiguration





GitHub
------

`View on GitHub <https://github.com/aspnet/configuration/blob/master/src/Microsoft.Extensions.Configuration.Abstractions/IConfigurationSection.cs>`_





.. dn:interface:: Microsoft.Extensions.Configuration.IConfigurationSection

Properties
----------

.. dn:interface:: Microsoft.Extensions.Configuration.IConfigurationSection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Configuration.IConfigurationSection.Key
    
        
    
        Gets the key this section occupies in its parent.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Key { get; }
    
    .. dn:property:: Microsoft.Extensions.Configuration.IConfigurationSection.Path
    
        
    
        Gets the full path to this section within the :any:`Microsoft.Extensions.Configuration.IConfiguration`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Path { get; }
    
    .. dn:property:: Microsoft.Extensions.Configuration.IConfigurationSection.Value
    
        
    
        Gets or sets the section value.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string Value { get; set; }
    

