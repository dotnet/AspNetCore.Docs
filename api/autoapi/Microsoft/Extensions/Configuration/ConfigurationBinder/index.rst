

ConfigurationBinder Class
=========================






Static helper class that allows binding strongly typed objects to configuration values.


Namespace
    :dn:ns:`Microsoft.Extensions.Configuration`
Assemblies
    * Microsoft.Extensions.Configuration.Binder

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.ConfigurationBinder`








Syntax
------

.. code-block:: csharp

    public class ConfigurationBinder








.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationBinder
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationBinder

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationBinder.Bind(Microsoft.Extensions.Configuration.IConfiguration, System.Object)
    
        
    
        
        Attempts to bind the given object instance to configuration values by matching property names against configuration keys recursively.
    
        
    
        
        :param configuration: The configuration instance to bind.
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
    
        
        :param instance: The object to bind.
        
        :type instance: System.Object
    
        
        .. code-block:: csharp
    
            public static void Bind(this IConfiguration configuration, object instance)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationBinder.GetValue(Microsoft.Extensions.Configuration.IConfiguration, System.Type, System.String)
    
        
    
        
        Extracts the value with the specified key and converts it to the specified type.
    
        
    
        
        :param configuration: The configuration.
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
    
        
        :param type: The type to convert the value to.
        
        :type type: System.Type
    
        
        :param key: The configuration key for the value to convert.
        
        :type key: System.String
        :rtype: System.Object
        :return: The converted value.
    
        
        .. code-block:: csharp
    
            public static object GetValue(this IConfiguration configuration, Type type, string key)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationBinder.GetValue(Microsoft.Extensions.Configuration.IConfiguration, System.Type, System.String, System.Object)
    
        
    
        
        Extracts the value with the specified key and converts it to the specified type.
    
        
    
        
        :param configuration: The configuration.
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
    
        
        :param type: The type to convert the value to.
        
        :type type: System.Type
    
        
        :param key: The configuration key for the value to convert.
        
        :type key: System.String
    
        
        :param defaultValue: The default value to use if no value is found.
        
        :type defaultValue: System.Object
        :rtype: System.Object
        :return: The converted value.
    
        
        .. code-block:: csharp
    
            public static object GetValue(this IConfiguration configuration, Type type, string key, object defaultValue)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationBinder.GetValue<T>(Microsoft.Extensions.Configuration.IConfiguration, System.String)
    
        
    
        
        Extracts the value with the specified key and converts it to type T.
    
        
    
        
        :param configuration: The configuration.
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
    
        
        :param key: The configuration key for the value to convert.
        
        :type key: System.String
        :rtype: T
        :return: The converted value.
    
        
        .. code-block:: csharp
    
            public static T GetValue<T>(this IConfiguration configuration, string key)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationBinder.GetValue<T>(Microsoft.Extensions.Configuration.IConfiguration, System.String, T)
    
        
    
        
        Extracts the value with the specified key and converts it to type T.
    
        
    
        
        :param configuration: The configuration.
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
    
        
        :param key: The configuration key for the value to convert.
        
        :type key: System.String
    
        
        :param defaultValue: The default value to use if no value is found.
        
        :type defaultValue: T
        :rtype: T
        :return: The converted value.
    
        
        .. code-block:: csharp
    
            public static T GetValue<T>(this IConfiguration configuration, string key, T defaultValue)
    

