

OptionsManager<TOptions> Class
==============================






Implementation of IOptions.


Namespace
    :dn:ns:`Microsoft.Extensions.Options`
Assemblies
    * Microsoft.Extensions.Options

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Options.OptionsManager\<TOptions>`








Syntax
------

.. code-block:: csharp

    public class OptionsManager<TOptions> : IOptions<TOptions> where TOptions : class, new ()








.. dn:class:: Microsoft.Extensions.Options.OptionsManager`1
    :hidden:

.. dn:class:: Microsoft.Extensions.Options.OptionsManager<TOptions>

Constructors
------------

.. dn:class:: Microsoft.Extensions.Options.OptionsManager<TOptions>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Options.OptionsManager<TOptions>.OptionsManager(System.Collections.Generic.IEnumerable<Microsoft.Extensions.Options.IConfigureOptions<TOptions>>)
    
        
    
        
        Initializes a new instance with the specified options configurations.
    
        
    
        
        :param setups: The configuration actions to run.
        
        :type setups: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.Options.IConfigureOptions<Microsoft.Extensions.Options.IConfigureOptions`1>{TOptions}}
    
        
        .. code-block:: csharp
    
            public OptionsManager(IEnumerable<IConfigureOptions<TOptions>> setups)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Options.OptionsManager<TOptions>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Options.OptionsManager<TOptions>.Value
    
        
    
        
        The configured options instance.
    
        
        :rtype: TOptions
    
        
        .. code-block:: csharp
    
            public virtual TOptions Value { get; }
    

