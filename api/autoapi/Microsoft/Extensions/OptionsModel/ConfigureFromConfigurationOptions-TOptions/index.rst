

ConfigureFromConfigurationOptions<TOptions> Class
=================================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.OptionsModel.ConfigureOptions{{TOptions}}`
* :dn:cls:`Microsoft.Extensions.OptionsModel.ConfigureFromConfigurationOptions\<TOptions>`








Syntax
------

.. code-block:: csharp

   public class ConfigureFromConfigurationOptions<TOptions> : ConfigureOptions<TOptions>, IConfigureOptions<TOptions> where TOptions : class





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/options/src/Microsoft.Extensions.OptionsModel/ConfigureFromConfigurationOptions.cs>`_





.. dn:class:: Microsoft.Extensions.OptionsModel.ConfigureFromConfigurationOptions<TOptions>

Constructors
------------

.. dn:class:: Microsoft.Extensions.OptionsModel.ConfigureFromConfigurationOptions<TOptions>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.OptionsModel.ConfigureFromConfigurationOptions<TOptions>.ConfigureFromConfigurationOptions(Microsoft.Extensions.Configuration.IConfiguration)
    
        
        
        
        :type config: Microsoft.Extensions.Configuration.IConfiguration
    
        
        .. code-block:: csharp
    
           public ConfigureFromConfigurationOptions(IConfiguration config)
    

