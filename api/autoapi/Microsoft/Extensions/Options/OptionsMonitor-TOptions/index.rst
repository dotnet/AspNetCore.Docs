

OptionsMonitor<TOptions> Class
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
* :dn:cls:`Microsoft.Extensions.Options.OptionsMonitor\<TOptions>`








Syntax
------

.. code-block:: csharp

    public class OptionsMonitor<TOptions> : IOptionsMonitor<TOptions> where TOptions : class, new ()








.. dn:class:: Microsoft.Extensions.Options.OptionsMonitor`1
    :hidden:

.. dn:class:: Microsoft.Extensions.Options.OptionsMonitor<TOptions>

Properties
----------

.. dn:class:: Microsoft.Extensions.Options.OptionsMonitor<TOptions>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Options.OptionsMonitor<TOptions>.CurrentValue
    
        
        :rtype: TOptions
    
        
        .. code-block:: csharp
    
            public TOptions CurrentValue
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Extensions.Options.OptionsMonitor<TOptions>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Options.OptionsMonitor<TOptions>.OptionsMonitor(System.Collections.Generic.IEnumerable<Microsoft.Extensions.Options.IConfigureOptions<TOptions>>, System.Collections.Generic.IEnumerable<Microsoft.Extensions.Options.IOptionsChangeTokenSource<TOptions>>)
    
        
    
        
        :type setups: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.Options.IConfigureOptions<Microsoft.Extensions.Options.IConfigureOptions`1>{TOptions}}
    
        
        :type sources: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.Options.IOptionsChangeTokenSource<Microsoft.Extensions.Options.IOptionsChangeTokenSource`1>{TOptions}}
    
        
        .. code-block:: csharp
    
            public OptionsMonitor(IEnumerable<IConfigureOptions<TOptions>> setups, IEnumerable<IOptionsChangeTokenSource<TOptions>> sources)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Options.OptionsMonitor<TOptions>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Options.OptionsMonitor<TOptions>.OnChange(System.Action<TOptions>)
    
        
    
        
        :type listener: System.Action<System.Action`1>{TOptions}
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public IDisposable OnChange(Action<TOptions> listener)
    

