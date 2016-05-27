

OptionsWrapper<TOptions> Class
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
* :dn:cls:`Microsoft.Extensions.Options.OptionsWrapper\<TOptions>`








Syntax
------

.. code-block:: csharp

    public class OptionsWrapper<TOptions> : IOptions<TOptions> where TOptions : class, new ()








.. dn:class:: Microsoft.Extensions.Options.OptionsWrapper`1
    :hidden:

.. dn:class:: Microsoft.Extensions.Options.OptionsWrapper<TOptions>

Properties
----------

.. dn:class:: Microsoft.Extensions.Options.OptionsWrapper<TOptions>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Options.OptionsWrapper<TOptions>.Value
    
        
        :rtype: TOptions
    
        
        .. code-block:: csharp
    
            public TOptions Value
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Extensions.Options.OptionsWrapper<TOptions>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Options.OptionsWrapper<TOptions>.OptionsWrapper(TOptions)
    
        
    
        
        :type options: TOptions
    
        
        .. code-block:: csharp
    
            public OptionsWrapper(TOptions options)
    

