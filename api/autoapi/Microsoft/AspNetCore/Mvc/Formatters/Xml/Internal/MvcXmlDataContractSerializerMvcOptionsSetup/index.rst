

MvcXmlDataContractSerializerMvcOptionsSetup Class
=================================================






A :any:`Microsoft.Extensions.Options.ConfigureOptions\`1` implementation which will add the
data contract serializer formatters to :any:`Microsoft.AspNetCore.Mvc.MvcOptions`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal.MvcXmlDataContractSerializerMvcOptionsSetup`








Syntax
------

.. code-block:: csharp

    public class MvcXmlDataContractSerializerMvcOptionsSetup : ConfigureOptions<MvcOptions>, IConfigureOptions<MvcOptions>








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal.MvcXmlDataContractSerializerMvcOptionsSetup
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal.MvcXmlDataContractSerializerMvcOptionsSetup

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal.MvcXmlDataContractSerializerMvcOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal.MvcXmlDataContractSerializerMvcOptionsSetup.MvcXmlDataContractSerializerMvcOptionsSetup()
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal.MvcXmlDataContractSerializerMvcOptionsSetup`\.
    
        
    
        
        .. code-block:: csharp
    
            public MvcXmlDataContractSerializerMvcOptionsSetup()
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal.MvcXmlDataContractSerializerMvcOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal.MvcXmlDataContractSerializerMvcOptionsSetup.ConfigureMvc(Microsoft.AspNetCore.Mvc.MvcOptions)
    
        
    
        
        Adds the data contract serializer formatters to :any:`Microsoft.AspNetCore.Mvc.MvcOptions`\.
    
        
    
        
        :param options: The :any:`Microsoft.AspNetCore.Mvc.MvcOptions`\.
        
        :type options: Microsoft.AspNetCore.Mvc.MvcOptions
    
        
        .. code-block:: csharp
    
            public static void ConfigureMvc(MvcOptions options)
    

