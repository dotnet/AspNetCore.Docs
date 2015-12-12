

MvcXmlMvcCoreBuilderExtensions Class
====================================



.. contents:: 
   :local:



Summary
-------

Extension methods for adding XML formatters to MVC.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcXmlMvcCoreBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class MvcXmlMvcCoreBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Formatters.Xml/DependencyInjection/MvcXmlMvcCoreBuilderExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcXmlMvcCoreBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcXmlMvcCoreBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcXmlMvcCoreBuilderExtensions.AddXmlDataContractSerializerFormatters(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder)
    
        
    
        Adds the XML DataContractSerializer formatters to MVC.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder AddXmlDataContractSerializerFormatters(IMvcCoreBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcXmlMvcCoreBuilderExtensions.AddXmlSerializerFormatters(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder)
    
        
    
        Adds the XML Serializer formatters to MVC.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder AddXmlSerializerFormatters(IMvcCoreBuilder builder)
    

