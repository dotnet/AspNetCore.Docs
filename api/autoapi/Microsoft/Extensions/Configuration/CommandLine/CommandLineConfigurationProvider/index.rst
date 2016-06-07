

CommandLineConfigurationProvider Class
======================================





Namespace
    :dn:ns:`Microsoft.Extensions.Configuration.CommandLine`
Assemblies
    * Microsoft.Extensions.Configuration.CommandLine

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.ConfigurationProvider`
* :dn:cls:`Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationProvider`








Syntax
------

.. code-block:: csharp

    public class CommandLineConfigurationProvider : ConfigurationProvider, IConfigurationProvider








.. dn:class:: Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationProvider
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationProvider

Properties
----------

.. dn:class:: Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationProvider.Args
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            protected IEnumerable<string> Args
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationProvider.CommandLineConfigurationProvider(System.Collections.Generic.IEnumerable<System.String>, System.Collections.Generic.IDictionary<System.String, System.String>)
    
        
    
        
        :type args: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        :type switchMappings: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public CommandLineConfigurationProvider(IEnumerable<string> args, IDictionary<string, string> switchMappings = null)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationProvider.Load()
    
        
    
        
        .. code-block:: csharp
    
            public override void Load()
    

