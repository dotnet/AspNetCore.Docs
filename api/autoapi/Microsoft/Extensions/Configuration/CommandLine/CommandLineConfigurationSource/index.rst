

CommandLineConfigurationSource Class
====================================






Represents command line arguments as an :any:`Microsoft.Extensions.Configuration.IConfigurationSource`\.


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
* :dn:cls:`Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationSource`








Syntax
------

.. code-block:: csharp

    public class CommandLineConfigurationSource : IConfigurationSource








.. dn:class:: Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationSource
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationSource

Properties
----------

.. dn:class:: Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationSource
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationSource.Args
    
        
    
        
        Gets or sets the command line args.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<string> Args { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationSource.SwitchMappings
    
        
    
        
        Gets or sets the switch mappings.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, string> SwitchMappings { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationSource
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationSource.Build(Microsoft.Extensions.Configuration.IConfigurationBuilder)
    
        
    
        
        Builds the :any:`Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationProvider` for this source.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`\.
        
        :type builder: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :rtype: Microsoft.Extensions.Configuration.IConfigurationProvider
        :return: A :any:`Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationProvider`
    
        
        .. code-block:: csharp
    
            public IConfigurationProvider Build(IConfigurationBuilder builder)
    

