

MvcXmlSerializerMvcOptionsSetup Class
=====================================






A :any:`Microsoft.Extensions.Options.ConfigureOptions\`1` implementation which will add the
XML serializer formatters to :any:`Microsoft.AspNetCore.Mvc.MvcOptions`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Formatters.Xml

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Options.ConfigureOptions{Microsoft.AspNetCore.Mvc.MvcOptions}`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal.MvcXmlSerializerMvcOptionsSetup`








Syntax
------

.. code-block:: csharp

    public class MvcXmlSerializerMvcOptionsSetup : ConfigureOptions<MvcOptions>, IConfigureOptions<MvcOptions>








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal.MvcXmlSerializerMvcOptionsSetup
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal.MvcXmlSerializerMvcOptionsSetup

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal.MvcXmlSerializerMvcOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal.MvcXmlSerializerMvcOptionsSetup.MvcXmlSerializerMvcOptionsSetup()
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal.MvcXmlSerializerMvcOptionsSetup`\.
    
        
    
        
        .. code-block:: csharp
    
            public MvcXmlSerializerMvcOptionsSetup()
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal.MvcXmlSerializerMvcOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal.MvcXmlSerializerMvcOptionsSetup.ConfigureMvc(Microsoft.AspNetCore.Mvc.MvcOptions)
    
        
    
        
        Adds the XML serializer formatters to :any:`Microsoft.AspNetCore.Mvc.MvcOptions`\.
    
        
    
        
        :param options: The :any:`Microsoft.AspNetCore.Mvc.MvcOptions`\.
        
        :type options: Microsoft.AspNetCore.Mvc.MvcOptions
    
        
        .. code-block:: csharp
    
            public static void ConfigureMvc(MvcOptions options)
    

