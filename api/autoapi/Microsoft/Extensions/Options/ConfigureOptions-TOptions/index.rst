

ConfigureOptions<TOptions> Class
================================





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
* :dn:cls:`Microsoft.Extensions.Options.ConfigureOptions\<TOptions>`








Syntax
------

.. code-block:: csharp

    public class ConfigureOptions<TOptions> : IConfigureOptions<TOptions> where TOptions : class








.. dn:class:: Microsoft.Extensions.Options.ConfigureOptions`1
    :hidden:

.. dn:class:: Microsoft.Extensions.Options.ConfigureOptions<TOptions>

Properties
----------

.. dn:class:: Microsoft.Extensions.Options.ConfigureOptions<TOptions>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Options.ConfigureOptions<TOptions>.Action
    
        
        :rtype: System.Action<System.Action`1>{TOptions}
    
        
        .. code-block:: csharp
    
            public Action<TOptions> Action
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Extensions.Options.ConfigureOptions<TOptions>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Options.ConfigureOptions<TOptions>.ConfigureOptions(System.Action<TOptions>)
    
        
    
        
        :type action: System.Action<System.Action`1>{TOptions}
    
        
        .. code-block:: csharp
    
            public ConfigureOptions(Action<TOptions> action)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Options.ConfigureOptions<TOptions>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Options.ConfigureOptions<TOptions>.Configure(TOptions)
    
        
    
        
        :type options: TOptions
    
        
        .. code-block:: csharp
    
            public virtual void Configure(TOptions options)
    

