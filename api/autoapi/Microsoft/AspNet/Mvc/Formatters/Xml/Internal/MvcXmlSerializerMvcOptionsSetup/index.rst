

MvcXmlSerializerMvcOptionsSetup Class
=====================================



.. contents:: 
   :local:



Summary
-------

A :any:`Microsoft.Extensions.OptionsModel.ConfigureOptions\`1` implementation which will add the
XML serializer formatters to :any:`Microsoft.AspNet.Mvc.MvcOptions`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.OptionsModel.ConfigureOptions{Microsoft.AspNet.Mvc.MvcOptions}`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.Xml.Internal.MvcXmlSerializerMvcOptionsSetup`








Syntax
------

.. code-block:: csharp

   public class MvcXmlSerializerMvcOptionsSetup : ConfigureOptions<MvcOptions>, IConfigureOptions<MvcOptions>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Formatters.Xml/Internal/MvcXmlSerializerMvcOptionsSetup.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.Internal.MvcXmlSerializerMvcOptionsSetup

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.Internal.MvcXmlSerializerMvcOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Formatters.Xml.Internal.MvcXmlSerializerMvcOptionsSetup.MvcXmlSerializerMvcOptionsSetup()
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.Formatters.Xml.Internal.MvcXmlSerializerMvcOptionsSetup`\.
    
        
    
        
        .. code-block:: csharp
    
           public MvcXmlSerializerMvcOptionsSetup()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.Internal.MvcXmlSerializerMvcOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.Xml.Internal.MvcXmlSerializerMvcOptionsSetup.ConfigureMvc(Microsoft.AspNet.Mvc.MvcOptions)
    
        
    
        Adds the XML serializer formatters to :any:`Microsoft.AspNet.Mvc.MvcOptions`\.
    
        
        
        
        :param options: The .
        
        :type options: Microsoft.AspNet.Mvc.MvcOptions
    
        
        .. code-block:: csharp
    
           public static void ConfigureMvc(MvcOptions options)
    

