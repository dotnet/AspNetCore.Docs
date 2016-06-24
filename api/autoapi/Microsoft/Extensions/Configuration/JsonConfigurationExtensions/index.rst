

JsonConfigurationExtensions Class
=================================






Extension methods for adding :any:`Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider`\.


Namespace
    :dn:ns:`Microsoft.Extensions.Configuration`
Assemblies
    * Microsoft.Extensions.Configuration.Json

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.JsonConfigurationExtensions`








Syntax
------

.. code-block:: csharp

    public class JsonConfigurationExtensions








.. dn:class:: Microsoft.Extensions.Configuration.JsonConfigurationExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.JsonConfigurationExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.JsonConfigurationExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.JsonConfigurationExtensions.AddJsonFile(Microsoft.Extensions.Configuration.IConfigurationBuilder, Microsoft.Extensions.FileProviders.IFileProvider, System.String, System.Boolean, System.Boolean)
    
        
    
        
        Adds a JSON configuration source to <em>builder</em>.
    
        
    
        
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
    
            public static IConfigurationBuilder AddJsonFile(this IConfigurationBuilder builder, IFileProvider provider, string path, bool optional, bool reloadOnChange)
    
    .. dn:method:: Microsoft.Extensions.Configuration.JsonConfigurationExtensions.AddJsonFile(Microsoft.Extensions.Configuration.IConfigurationBuilder, System.String)
    
        
    
        
        Adds the JSON configuration provider at <em>path</em> to <em>builder</em>.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder` to add to.
        
        :type builder: Microsoft.Extensions.Configuration.IConfigurationBuilder
    
        
        :param path: Path relative to the base path stored in 
            :dn:prop:`Microsoft.Extensions.Configuration.IConfigurationBuilder.Properties` of <em>builder</em>.
        
        :type path: System.String
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :return: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IConfigurationBuilder AddJsonFile(this IConfigurationBuilder builder, string path)
    
    .. dn:method:: Microsoft.Extensions.Configuration.JsonConfigurationExtensions.AddJsonFile(Microsoft.Extensions.Configuration.IConfigurationBuilder, System.String, System.Boolean)
    
        
    
        
        Adds the JSON configuration provider at <em>path</em> to <em>builder</em>.
    
        
    
        
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
    
            public static IConfigurationBuilder AddJsonFile(this IConfigurationBuilder builder, string path, bool optional)
    
    .. dn:method:: Microsoft.Extensions.Configuration.JsonConfigurationExtensions.AddJsonFile(Microsoft.Extensions.Configuration.IConfigurationBuilder, System.String, System.Boolean, System.Boolean)
    
        
    
        
        Adds the JSON configuration provider at <em>path</em> to <em>builder</em>.
    
        
    
        
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
    
            public static IConfigurationBuilder AddJsonFile(this IConfigurationBuilder builder, string path, bool optional, bool reloadOnChange)
    

