

OptionsWrapper<TOptions> Class
==============================






IOptions wrapper that returns the options instance.


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
* :dn:cls:`Microsoft.Extensions.Options.OptionsWrapper\<TOptions>`








Syntax
------

.. code-block:: csharp

    public class OptionsWrapper<TOptions> : IOptions<TOptions> where TOptions : class, new ()








.. dn:class:: Microsoft.Extensions.Options.OptionsWrapper`1
    :hidden:

.. dn:class:: Microsoft.Extensions.Options.OptionsWrapper<TOptions>

Constructors
------------

.. dn:class:: Microsoft.Extensions.Options.OptionsWrapper<TOptions>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Options.OptionsWrapper<TOptions>.OptionsWrapper(TOptions)
    
        
    
        
        Intializes the wrapper with the options instance to return.
    
        
    
        
        :param options: The options instance to return.
        
        :type options: TOptions
    
        
        .. code-block:: csharp
    
            public OptionsWrapper(TOptions options)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Options.OptionsWrapper<TOptions>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Options.OptionsWrapper<TOptions>.Value
    
        
    
        
        The options instance.
    
        
        :rtype: TOptions
    
        
        .. code-block:: csharp
    
            public TOptions Value { get; }
    

