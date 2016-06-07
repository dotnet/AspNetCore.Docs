

ConfigurationChangeTokenSource<TOptions> Class
==============================================





Namespace
    :dn:ns:`Microsoft.Extensions.Options`
Assemblies
    * Microsoft.Extensions.Options.ConfigurationExtensions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Options.ConfigurationChangeTokenSource\<TOptions>`








Syntax
------

.. code-block:: csharp

    public class ConfigurationChangeTokenSource<TOptions> : IOptionsChangeTokenSource<TOptions>








.. dn:class:: Microsoft.Extensions.Options.ConfigurationChangeTokenSource`1
    :hidden:

.. dn:class:: Microsoft.Extensions.Options.ConfigurationChangeTokenSource<TOptions>

Constructors
------------

.. dn:class:: Microsoft.Extensions.Options.ConfigurationChangeTokenSource<TOptions>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Options.ConfigurationChangeTokenSource<TOptions>.ConfigurationChangeTokenSource(Microsoft.Extensions.Configuration.IConfiguration)
    
        
    
        
        :type config: Microsoft.Extensions.Configuration.IConfiguration
    
        
        .. code-block:: csharp
    
            public ConfigurationChangeTokenSource(IConfiguration config)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Options.ConfigurationChangeTokenSource<TOptions>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Options.ConfigurationChangeTokenSource<TOptions>.GetChangeToken()
    
        
        :rtype: Microsoft.Extensions.Primitives.IChangeToken
    
        
        .. code-block:: csharp
    
            public IChangeToken GetChangeToken()
    

