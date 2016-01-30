

MvcJsonMvcOptionsSetup Class
============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.OptionsModel.ConfigureOptions{Microsoft.AspNet.Mvc.MvcOptions}`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.Json.Internal.MvcJsonMvcOptionsSetup`








Syntax
------

.. code-block:: csharp

   public class MvcJsonMvcOptionsSetup : ConfigureOptions<MvcOptions>, IConfigureOptions<MvcOptions>





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Formatters.Json/Internal/MvcJsonMvcOptionsSetup.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Json.Internal.MvcJsonMvcOptionsSetup

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Json.Internal.MvcJsonMvcOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Formatters.Json.Internal.MvcJsonMvcOptionsSetup.MvcJsonMvcOptionsSetup(Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Mvc.MvcJsonOptions>)
    
        
        
        
        :type jsonOptions: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Mvc.MvcJsonOptions}
    
        
        .. code-block:: csharp
    
           public MvcJsonMvcOptionsSetup(IOptions<MvcJsonOptions> jsonOptions)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Json.Internal.MvcJsonMvcOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.Json.Internal.MvcJsonMvcOptionsSetup.ConfigureMvc(Microsoft.AspNet.Mvc.MvcOptions, Newtonsoft.Json.JsonSerializerSettings)
    
        
        
        
        :type options: Microsoft.AspNet.Mvc.MvcOptions
        
        
        :type serializerSettings: Newtonsoft.Json.JsonSerializerSettings
    
        
        .. code-block:: csharp
    
           public static void ConfigureMvc(MvcOptions options, JsonSerializerSettings serializerSettings)
    

