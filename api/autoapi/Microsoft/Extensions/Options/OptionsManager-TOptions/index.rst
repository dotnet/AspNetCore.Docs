

OptionsManager<TOptions> Class
==============================





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

Properties
----------

.. dn:class:: Microsoft.Extensions.Options.OptionsManager<TOptions>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Options.OptionsManager<TOptions>.Value
    
        
        :rtype: TOptions
    
        
        .. code-block:: csharp
    
            public virtual TOptions Value
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Extensions.Options.OptionsManager<TOptions>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Options.OptionsManager<TOptions>.OptionsManager(System.Collections.Generic.IEnumerable<Microsoft.Extensions.Options.IConfigureOptions<TOptions>>)
    
        
    
        
        :type setups: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.Options.IConfigureOptions<Microsoft.Extensions.Options.IConfigureOptions`1>{TOptions}}
    
        
        .. code-block:: csharp
    
            public OptionsManager(IEnumerable<IConfigureOptions<TOptions>> setups)
    

