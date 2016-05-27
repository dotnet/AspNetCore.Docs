

ConfigureFromConfigurationOptions<TOptions> Class
=================================================





Namespace
    :dn:ns:`Microsoft.Extensions.Options`
Assemblies
    * Microsoft.Extensions.Options.ConfigurationExtensions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Options.ConfigureOptions{{TOptions}}`
* :dn:cls:`Microsoft.Extensions.Options.ConfigureFromConfigurationOptions\<TOptions>`








Syntax
------

.. code-block:: csharp

    public class ConfigureFromConfigurationOptions<TOptions> : ConfigureOptions<TOptions>, IConfigureOptions<TOptions> where TOptions : class








.. dn:class:: Microsoft.Extensions.Options.ConfigureFromConfigurationOptions`1
    :hidden:

.. dn:class:: Microsoft.Extensions.Options.ConfigureFromConfigurationOptions<TOptions>

Constructors
------------

.. dn:class:: Microsoft.Extensions.Options.ConfigureFromConfigurationOptions<TOptions>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Options.ConfigureFromConfigurationOptions<TOptions>.ConfigureFromConfigurationOptions(Microsoft.Extensions.Configuration.IConfiguration)
    
        
    
        
        :type config: Microsoft.Extensions.Configuration.IConfiguration
    
        
        .. code-block:: csharp
    
            public ConfigureFromConfigurationOptions(IConfiguration config)
    

