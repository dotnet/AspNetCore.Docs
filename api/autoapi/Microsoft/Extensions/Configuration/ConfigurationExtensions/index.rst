

ConfigurationExtensions Class
=============================






Extension methods for :any:`Microsoft.Extensions.Configuration.IConfiguration`\.


Namespace
    :dn:ns:`Microsoft.Extensions.Configuration`
Assemblies
    * Microsoft.Extensions.Configuration.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.ConfigurationExtensions`








Syntax
------

.. code-block:: csharp

    public class ConfigurationExtensions








.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationExtensions.AsEnumerable(Microsoft.Extensions.Configuration.IConfiguration)
    
        
    
        
        Get the enumeration of key value pairs within the :any:`Microsoft.Extensions.Configuration.IConfiguration`
    
        
    
        
        :param configuration: The :any:`Microsoft.Extensions.Configuration.IConfiguration` to enumerate.
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.String<System.String>}}
        :return: An enumeration of key value pairs.
    
        
        .. code-block:: csharp
    
            public static IEnumerable<KeyValuePair<string, string>> AsEnumerable(this IConfiguration configuration)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationExtensions.GetConnectionString(Microsoft.Extensions.Configuration.IConfiguration, System.String)
    
        
    
        
        Shorthand for GetSection("ConnectionStrings")[name].
    
        
    
        
        :param configuration: The configuration.
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
    
        
        :param name: The connection string key.
        
        :type name: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string GetConnectionString(this IConfiguration configuration, string name)
    

