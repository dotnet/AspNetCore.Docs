

IniConfigurationExtensions Class
================================






Extension methods for adding :any:`Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider`\.


Namespace
    :dn:ns:`Microsoft.Extensions.Configuration`
Assemblies
    * Microsoft.Extensions.Configuration.Ini

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.IniConfigurationExtensions`








Syntax
------

.. code-block:: csharp

    public class IniConfigurationExtensions








.. dn:class:: Microsoft.Extensions.Configuration.IniConfigurationExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.IniConfigurationExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.IniConfigurationExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.IniConfigurationExtensions.AddIniFile(Microsoft.Extensions.Configuration.IConfigurationBuilder, Microsoft.Extensions.FileProviders.IFileProvider, System.String, System.Boolean, System.Boolean)
    
        
    
        
        Adds a INI configuration source to <em>builder</em>.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder` to add to.
        
        :type builder: Microsoft.Extensions.Configuration.IConfigurationBuilder
    
        
        :param provider: The :any:`Microsoft.Extensions.FileProviders.IFileProvider` to use to access the file.
        
        :type provider: Microsoft.Extensions.FileProviders.IFileProvider
    
        
        :param path: Path relative to the base path stored in 
            :dn:prop:`Microsoft.Extensions.Configuration.IConfigurationBuilder.Properties` of <em>builder</em>.
        
        :type path: System.String
    
        
        :param optional: Whether the file is optional.
        
        :type optional: System.Boolean
    
        
        :param reloadOnChange: Whether the configuration should be reloaded if the file changes.
        
        :type reloadOnChange: System.Boolean
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :return: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IConfigurationBuilder AddIniFile(this IConfigurationBuilder builder, IFileProvider provider, string path, bool optional, bool reloadOnChange)
    
    .. dn:method:: Microsoft.Extensions.Configuration.IniConfigurationExtensions.AddIniFile(Microsoft.Extensions.Configuration.IConfigurationBuilder, System.String)
    
        
    
        
        Adds the INI configuration provider at <em>path</em> to <em>builder</em>.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder` to add to.
        
        :type builder: Microsoft.Extensions.Configuration.IConfigurationBuilder
    
        
        :param path: Path relative to the base path stored in 
            :dn:prop:`Microsoft.Extensions.Configuration.IConfigurationBuilder.Properties` of <em>builder</em>.
        
        :type path: System.String
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :return: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IConfigurationBuilder AddIniFile(this IConfigurationBuilder builder, string path)
    
    .. dn:method:: Microsoft.Extensions.Configuration.IniConfigurationExtensions.AddIniFile(Microsoft.Extensions.Configuration.IConfigurationBuilder, System.String, System.Boolean)
    
        
    
        
        Adds the INI configuration provider at <em>path</em> to <em>builder</em>.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder` to add to.
        
        :type builder: Microsoft.Extensions.Configuration.IConfigurationBuilder
    
        
        :param path: Path relative to the base path stored in 
            :dn:prop:`Microsoft.Extensions.Configuration.IConfigurationBuilder.Properties` of <em>builder</em>.
        
        :type path: System.String
    
        
        :param optional: Whether the file is optional.
        
        :type optional: System.Boolean
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :return: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IConfigurationBuilder AddIniFile(this IConfigurationBuilder builder, string path, bool optional)
    
    .. dn:method:: Microsoft.Extensions.Configuration.IniConfigurationExtensions.AddIniFile(Microsoft.Extensions.Configuration.IConfigurationBuilder, System.String, System.Boolean, System.Boolean)
    
        
    
        
        Adds the INI configuration provider at <em>path</em> to <em>builder</em>.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder` to add to.
        
        :type builder: Microsoft.Extensions.Configuration.IConfigurationBuilder
    
        
        :param path: Path relative to the base path stored in 
            :dn:prop:`Microsoft.Extensions.Configuration.IConfigurationBuilder.Properties` of <em>builder</em>.
        
        :type path: System.String
    
        
        :param optional: Whether the file is optional.
        
        :type optional: System.Boolean
    
        
        :param reloadOnChange: Whether the configuration should be reloaded if the file changes.
        
        :type reloadOnChange: System.Boolean
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :return: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IConfigurationBuilder AddIniFile(this IConfigurationBuilder builder, string path, bool optional, bool reloadOnChange)
    

