

CommandLineConfigurationExtensions Class
========================================






Extension methods for registering :any:`Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationProvider` with :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`\.


Namespace
    :dn:ns:`Microsoft.Extensions.Configuration`
Assemblies
    * Microsoft.Extensions.Configuration.CommandLine

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.CommandLineConfigurationExtensions`








Syntax
------

.. code-block:: csharp

    public class CommandLineConfigurationExtensions








.. dn:class:: Microsoft.Extensions.Configuration.CommandLineConfigurationExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.CommandLineConfigurationExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.CommandLineConfigurationExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.CommandLineConfigurationExtensions.AddCommandLine(Microsoft.Extensions.Configuration.IConfigurationBuilder, System.String[])
    
        
    
        
        Adds an :any:`Microsoft.Extensions.Configuration.IConfigurationProvider` that reads configuration values from the command line.
    
        
    
        
        :param configurationBuilder: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder` to add to.
        
        :type configurationBuilder: Microsoft.Extensions.Configuration.IConfigurationBuilder
    
        
        :param args: The command line args.
        
        :type args: System.String<System.String>[]
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :return: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IConfigurationBuilder AddCommandLine(this IConfigurationBuilder configurationBuilder, string[] args)
    
    .. dn:method:: Microsoft.Extensions.Configuration.CommandLineConfigurationExtensions.AddCommandLine(Microsoft.Extensions.Configuration.IConfigurationBuilder, System.String[], System.Collections.Generic.IDictionary<System.String, System.String>)
    
        
    
        
        Adds an :any:`Microsoft.Extensions.Configuration.IConfigurationProvider` that reads configuration values from the command line using the specified switch mappings.
    
        
    
        
        :param configurationBuilder: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder` to add to.
        
        :type configurationBuilder: Microsoft.Extensions.Configuration.IConfigurationBuilder
    
        
        :param args: The command line args.
        
        :type args: System.String<System.String>[]
    
        
        :param switchMappings: The switch mappings.
        
        :type switchMappings: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :return: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IConfigurationBuilder AddCommandLine(this IConfigurationBuilder configurationBuilder, string[] args, IDictionary<string, string> switchMappings)
    

