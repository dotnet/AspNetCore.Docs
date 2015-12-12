

CommandLineConfigurationExtensions Class
========================================



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





GitHub
------

`View on GitHub <https://github.com/aspnet/configuration/blob/master/src/Microsoft.Extensions.Configuration.CommandLine/CommandLineConfigurationExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.Configuration.CommandLineConfigurationExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.CommandLineConfigurationExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.CommandLineConfigurationExtensions.AddCommandLine(Microsoft.Extensions.Configuration.IConfigurationBuilder, System.String[])
    
        
        
        
        :type configurationBuilder: Microsoft.Extensions.Configuration.IConfigurationBuilder
        
        
        :type args: System.String[]
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
    
        
        .. code-block:: csharp
    
           public static IConfigurationBuilder AddCommandLine(IConfigurationBuilder configurationBuilder, string[] args)
    
    .. dn:method:: Microsoft.Extensions.Configuration.CommandLineConfigurationExtensions.AddCommandLine(Microsoft.Extensions.Configuration.IConfigurationBuilder, System.String[], System.Collections.Generic.IDictionary<System.String, System.String>)
    
        
        
        
        :type configurationBuilder: Microsoft.Extensions.Configuration.IConfigurationBuilder
        
        
        :type args: System.String[]
        
        
        :type switchMappings: System.Collections.Generic.IDictionary{System.String,System.String}
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
    
        
        .. code-block:: csharp
    
           public static IConfigurationBuilder AddCommandLine(IConfigurationBuilder configurationBuilder, string[] args, IDictionary<string, string> switchMappings)
    

