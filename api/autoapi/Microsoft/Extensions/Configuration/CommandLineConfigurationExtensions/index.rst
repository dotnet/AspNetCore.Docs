

CommandLineConfigurationExtensions Class
========================================





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
    
        
    
        
        :type configurationBuilder: Microsoft.Extensions.Configuration.IConfigurationBuilder
    
        
        :type args: System.String<System.String>[]
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
    
        
        .. code-block:: csharp
    
            public static IConfigurationBuilder AddCommandLine(IConfigurationBuilder configurationBuilder, string[] args)
    
    .. dn:method:: Microsoft.Extensions.Configuration.CommandLineConfigurationExtensions.AddCommandLine(Microsoft.Extensions.Configuration.IConfigurationBuilder, System.String[], System.Collections.Generic.IDictionary<System.String, System.String>)
    
        
    
        
        :type configurationBuilder: Microsoft.Extensions.Configuration.IConfigurationBuilder
    
        
        :type args: System.String<System.String>[]
    
        
        :type switchMappings: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
    
        
        .. code-block:: csharp
    
            public static IConfigurationBuilder AddCommandLine(IConfigurationBuilder configurationBuilder, string[] args, IDictionary<string, string> switchMappings)
    

