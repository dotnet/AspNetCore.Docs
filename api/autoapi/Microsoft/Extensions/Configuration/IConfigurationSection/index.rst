

IConfigurationSection Interface
===============================






Represents a section of application configuration values.


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

    public interface IConfigurationSection : IConfiguration








.. dn:interface:: Microsoft.Extensions.Configuration.IConfigurationSection
    :hidden:

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
    
            string Key
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.Configuration.IConfigurationSection.Path
    
        
    
        
        Gets the full path to this section within the :any:`Microsoft.Extensions.Configuration.IConfiguration`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string Path
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.Configuration.IConfigurationSection.Value
    
        
    
        
        Gets or sets the section value.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string Value
            {
                get;
                set;
            }
    

