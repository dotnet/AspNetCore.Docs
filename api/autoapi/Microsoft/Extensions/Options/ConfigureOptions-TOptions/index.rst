

ConfigureOptions<TOptions> Class
================================






Implementation of IConfigureOptions.


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

Constructors
------------

.. dn:class:: Microsoft.Extensions.Options.ConfigureOptions<TOptions>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Options.ConfigureOptions<TOptions>.ConfigureOptions(System.Action<TOptions>)
    
        
    
        
        Constructor.
    
        
    
        
        :param action: The action to register.
        
        :type action: System.Action<System.Action`1>{TOptions}
    
        
        .. code-block:: csharp
    
            public ConfigureOptions(Action<TOptions> action)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Options.ConfigureOptions<TOptions>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Options.ConfigureOptions<TOptions>.Action
    
        
    
        
        The configuration action.
    
        
        :rtype: System.Action<System.Action`1>{TOptions}
    
        
        .. code-block:: csharp
    
            public Action<TOptions> Action { get; }
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Options.ConfigureOptions<TOptions>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Options.ConfigureOptions<TOptions>.Configure(TOptions)
    
        
    
        
        Invokes the registered configure Action.
    
        
    
        
        :type options: TOptions
    
        
        .. code-block:: csharp
    
            public virtual void Configure(TOptions options)
    

