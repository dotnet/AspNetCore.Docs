

XmlConfigurationExtensions Class
================================



.. contents:: 
   :local:



Summary
-------

Extension methods for adding :any:`Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.XmlConfigurationExtensions`








Syntax
------

.. code-block:: csharp

   public class XmlConfigurationExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/configuration/src/Microsoft.Extensions.Configuration.Xml/XmlConfigurationExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.Configuration.XmlConfigurationExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.XmlConfigurationExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.XmlConfigurationExtensions.AddXmlFile(Microsoft.Extensions.Configuration.IConfigurationBuilder, System.String)
    
        
    
        Adds the XML configuration provider at ``path`` to ``configuraton``.
    
        
        
        
        :param configurationBuilder: The  to add to.
        
        :type configurationBuilder: Microsoft.Extensions.Configuration.IConfigurationBuilder
        
        
        :param path: Absolute path or path relative to  of
            .
        
        :type path: System.String
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :return: The <see cref="T:Microsoft.Extensions.Configuration.IConfigurationBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IConfigurationBuilder AddXmlFile(IConfigurationBuilder configurationBuilder, string path)
    
    .. dn:method:: Microsoft.Extensions.Configuration.XmlConfigurationExtensions.AddXmlFile(Microsoft.Extensions.Configuration.IConfigurationBuilder, System.String, System.Boolean)
    
        
    
        Adds the XML configuration provider at ``path`` to ``configurationBuilder``.
    
        
        
        
        :param configurationBuilder: The  to add to.
        
        :type configurationBuilder: Microsoft.Extensions.Configuration.IConfigurationBuilder
        
        
        :param path: Absolute path or path relative to  of
            .
        
        :type path: System.String
        
        
        :param optional: Determines if loading the configuration provider is optional.
        
        :type optional: System.Boolean
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :return: The <see cref="T:Microsoft.Extensions.Configuration.IConfigurationBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IConfigurationBuilder AddXmlFile(IConfigurationBuilder configurationBuilder, string path, bool optional)
    

