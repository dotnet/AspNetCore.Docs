

MvcXmlMvcCoreBuilderExtensions Class
====================================






Extension methods for adding XML formatters to MVC.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.AspNetCore.Mvc.Formatters.Xml

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcXmlMvcCoreBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class MvcXmlMvcCoreBuilderExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcXmlMvcCoreBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcXmlMvcCoreBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcXmlMvcCoreBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcXmlMvcCoreBuilderExtensions.AddXmlDataContractSerializerFormatters(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder)
    
        
    
        
        Adds the XML DataContractSerializer formatters to MVC.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder AddXmlDataContractSerializerFormatters(this IMvcCoreBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcXmlMvcCoreBuilderExtensions.AddXmlSerializerFormatters(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder)
    
        
    
        
        Adds the XML Serializer formatters to MVC.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder AddXmlSerializerFormatters(this IMvcCoreBuilder builder)
    

