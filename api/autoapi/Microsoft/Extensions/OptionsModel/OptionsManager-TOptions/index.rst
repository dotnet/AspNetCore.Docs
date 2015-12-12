

OptionsManager<TOptions> Class
==============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.OptionsModel.OptionsManager\<TOptions>`








Syntax
------

.. code-block:: csharp

   public class OptionsManager<TOptions> : IOptions<TOptions> where TOptions : class, new ()





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/options/src/Microsoft.Extensions.OptionsModel/OptionsManager.cs>`_





.. dn:class:: Microsoft.Extensions.OptionsModel.OptionsManager<TOptions>

Constructors
------------

.. dn:class:: Microsoft.Extensions.OptionsModel.OptionsManager<TOptions>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.OptionsModel.OptionsManager<TOptions>.OptionsManager(System.Collections.Generic.IEnumerable<Microsoft.Extensions.OptionsModel.IConfigureOptions<TOptions>>)
    
        
        
        
        :type setups: System.Collections.Generic.IEnumerable{Microsoft.Extensions.OptionsModel.IConfigureOptions{{TOptions}}}
    
        
        .. code-block:: csharp
    
           public OptionsManager(IEnumerable<IConfigureOptions<TOptions>> setups)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.OptionsModel.OptionsManager<TOptions>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.OptionsModel.OptionsManager<TOptions>.Value
    
        
        :rtype: {TOptions}
    
        
        .. code-block:: csharp
    
           public virtual TOptions Value { get; }
    

