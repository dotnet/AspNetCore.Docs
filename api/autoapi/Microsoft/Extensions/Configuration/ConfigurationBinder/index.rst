

ConfigurationBinder Class
=========================





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
    
        
    
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
    
        
        :type instance: System.Object
    
        
        .. code-block:: csharp
    
            public static void Bind(IConfiguration configuration, object instance)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationBinder.GetValue(Microsoft.Extensions.Configuration.IConfiguration, System.Type, System.String)
    
        
    
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
    
        
        :type type: System.Type
    
        
        :type key: System.String
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public static object GetValue(IConfiguration configuration, Type type, string key)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationBinder.GetValue(Microsoft.Extensions.Configuration.IConfiguration, System.Type, System.String, System.Object)
    
        
    
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
    
        
        :type type: System.Type
    
        
        :type key: System.String
    
        
        :type defaultValue: System.Object
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public static object GetValue(IConfiguration configuration, Type type, string key, object defaultValue)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationBinder.GetValue<T>(Microsoft.Extensions.Configuration.IConfiguration, System.String)
    
        
    
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
    
        
        :type key: System.String
        :rtype: T
    
        
        .. code-block:: csharp
    
            public static T GetValue<T>(IConfiguration configuration, string key)
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationBinder.GetValue<T>(Microsoft.Extensions.Configuration.IConfiguration, System.String, T)
    
        
    
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
    
        
        :type key: System.String
    
        
        :type defaultValue: T
        :rtype: T
    
        
        .. code-block:: csharp
    
            public static T GetValue<T>(IConfiguration configuration, string key, T defaultValue)
    

