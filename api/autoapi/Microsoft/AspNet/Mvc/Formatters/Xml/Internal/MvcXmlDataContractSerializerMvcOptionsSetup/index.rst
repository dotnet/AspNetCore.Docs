

MvcXmlDataContractSerializerMvcOptionsSetup Class
=================================================



.. contents:: 
   :local:



Summary
-------

A :any:`Microsoft.Extensions.OptionsModel.ConfigureOptions\`1` implementation which will add the
data contract serializer formatters to :any:`Microsoft.AspNet.Mvc.MvcOptions`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.OptionsModel.ConfigureOptions{Microsoft.AspNet.Mvc.MvcOptions}`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.Xml.Internal.MvcXmlDataContractSerializerMvcOptionsSetup`








Syntax
------

.. code-block:: csharp

   public class MvcXmlDataContractSerializerMvcOptionsSetup : ConfigureOptions<MvcOptions>, IConfigureOptions<MvcOptions>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Formatters.Xml/Internal/MvcXmlDataContractSerializerMvcOptionsSetup.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.Internal.MvcXmlDataContractSerializerMvcOptionsSetup

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.Internal.MvcXmlDataContractSerializerMvcOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Formatters.Xml.Internal.MvcXmlDataContractSerializerMvcOptionsSetup.MvcXmlDataContractSerializerMvcOptionsSetup()
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Mvc.Formatters.Xml.Internal.MvcXmlDataContractSerializerMvcOptionsSetup`\.
    
        
    
        
        .. code-block:: csharp
    
           public MvcXmlDataContractSerializerMvcOptionsSetup()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.Internal.MvcXmlDataContractSerializerMvcOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.Xml.Internal.MvcXmlDataContractSerializerMvcOptionsSetup.ConfigureMvc(Microsoft.AspNet.Mvc.MvcOptions)
    
        
    
        Adds the data contract serializer formatters to :any:`Microsoft.AspNet.Mvc.MvcOptions`\.
    
        
        
        
        :param options: The .
        
        :type options: Microsoft.AspNet.Mvc.MvcOptions
    
        
        .. code-block:: csharp
    
           public static void ConfigureMvc(MvcOptions options)
    

