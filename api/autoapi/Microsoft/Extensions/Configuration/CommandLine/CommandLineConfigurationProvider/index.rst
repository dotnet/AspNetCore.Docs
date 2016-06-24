

CommandLineConfigurationProvider Class
======================================






A command line based :any:`Microsoft.Extensions.Configuration.ConfigurationProvider`\.


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

Constructors
------------

.. dn:class:: Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationProvider.CommandLineConfigurationProvider(System.Collections.Generic.IEnumerable<System.String>, System.Collections.Generic.IDictionary<System.String, System.String>)
    
        
    
        
        Initializes a new instance.
    
        
    
        
        :param args: The command line args.
        
        :type args: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        :param switchMappings: The switch mappings.
        
        :type switchMappings: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public CommandLineConfigurationProvider(IEnumerable<string> args, IDictionary<string, string> switchMappings = null)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationProvider.Args
    
        
    
        
        The command line arguments.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            protected IEnumerable<string> Args { get; }
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationProvider.Load()
    
        
    
        
        Loads the configuration data from the command line args.
    
        
    
        
        .. code-block:: csharp
    
            public override void Load()
    

