

MvcXmlMvcBuilderExtensions Class
================================






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
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcXmlMvcBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class MvcXmlMvcBuilderExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcXmlMvcBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcXmlMvcBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcXmlMvcBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcXmlMvcBuilderExtensions.AddXmlDataContractSerializerFormatters(Microsoft.Extensions.DependencyInjection.IMvcBuilder)
    
        
    
        
        Adds the XML DataContractSerializer formatters to MVC.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcBuilder AddXmlDataContractSerializerFormatters(this IMvcBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcXmlMvcBuilderExtensions.AddXmlSerializerFormatters(Microsoft.Extensions.DependencyInjection.IMvcBuilder)
    
        
    
        
        Adds the XML Serializer formatters to MVC.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcBuilder AddXmlSerializerFormatters(this IMvcBuilder builder)
    

