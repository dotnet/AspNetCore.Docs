

ConfigureOptions<TOptions> Class
================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.OptionsModel.ConfigureOptions\<TOptions>`








Syntax
------

.. code-block:: csharp

   public class ConfigureOptions<TOptions> : IConfigureOptions<TOptions> where TOptions : class





GitHub
------

`View on GitHub <https://github.com/aspnet/options/blob/master/src/Microsoft.Extensions.OptionsModel/ConfigureOptions.cs>`_





.. dn:class:: Microsoft.Extensions.OptionsModel.ConfigureOptions<TOptions>

Constructors
------------

.. dn:class:: Microsoft.Extensions.OptionsModel.ConfigureOptions<TOptions>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.OptionsModel.ConfigureOptions<TOptions>.ConfigureOptions(System.Action<TOptions>)
    
        
        
        
        :type action: System.Action{{TOptions}}
    
        
        .. code-block:: csharp
    
           public ConfigureOptions(Action<TOptions> action)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.OptionsModel.ConfigureOptions<TOptions>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.OptionsModel.ConfigureOptions<TOptions>.Configure(TOptions)
    
        
        
        
        :type options: {TOptions}
    
        
        .. code-block:: csharp
    
           public virtual void Configure(TOptions options)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.OptionsModel.ConfigureOptions<TOptions>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.OptionsModel.ConfigureOptions<TOptions>.Action
    
        
        :rtype: System.Action{{TOptions}}
    
        
        .. code-block:: csharp
    
           public Action<TOptions> Action { get; }
    

