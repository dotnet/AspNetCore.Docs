

ConfigurationBinder Class
=========================



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





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/configuration/src/Microsoft.Extensions.Configuration.Binder/ConfigurationBinder.cs>`_





.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationBinder

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationBinder.Bind(Microsoft.Extensions.Configuration.IConfiguration, System.Object)
    
        
        
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
        
        
        :type instance: System.Object
    
        
        .. code-block:: csharp
    
           public static void Bind(IConfiguration configuration, object instance)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationBinder.Get(Microsoft.Extensions.Configuration.IConfiguration, System.Type)
    
        
        
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
        
        
        :type type: System.Type
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public static object Get(IConfiguration configuration, Type type)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationBinder.Get(Microsoft.Extensions.Configuration.IConfiguration, System.Type, System.String)
    
        
        
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
        
        
        :type type: System.Type
        
        
        :type key: System.String
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public static object Get(IConfiguration configuration, Type type, string key)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationBinder.Get<T>(Microsoft.Extensions.Configuration.IConfiguration)
    
        
        
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
        :rtype: {T}
    
        
        .. code-block:: csharp
    
           public static T Get<T>(IConfiguration configuration)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationBinder.Get<T>(Microsoft.Extensions.Configuration.IConfiguration, System.String)
    
        
        
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
        
        
        :type key: System.String
        :rtype: {T}
    
        
        .. code-block:: csharp
    
           public static T Get<T>(IConfiguration configuration, string key)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationBinder.Get<T>(Microsoft.Extensions.Configuration.IConfiguration, System.String, T)
    
        
        
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
        
        
        :type key: System.String
        
        
        :type defaultValue: {T}
        :rtype: {T}
    
        
        .. code-block:: csharp
    
           public static T Get<T>(IConfiguration configuration, string key, T defaultValue)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationBinder.Get<T>(Microsoft.Extensions.Configuration.IConfiguration, T)
    
        
        
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
        
        
        :type defaultValue: {T}
        :rtype: {T}
    
        
        .. code-block:: csharp
    
           public static T Get<T>(IConfiguration configuration, T defaultValue)
    

