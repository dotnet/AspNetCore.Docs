

MvcJsonMvcCoreBuilderExtensions Class
=====================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcJsonMvcCoreBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class MvcJsonMvcCoreBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Formatters.Json/DependencyInjection/MvcJsonMvcCoreBuilderExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcJsonMvcCoreBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcJsonMvcCoreBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcJsonMvcCoreBuilderExtensions.AddJsonFormatters(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder)
    
        
        
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder AddJsonFormatters(IMvcCoreBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcJsonMvcCoreBuilderExtensions.AddJsonFormatters(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Action<Newtonsoft.Json.JsonSerializerSettings>)
    
        
        
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        
        
        :type setupAction: System.Action{Newtonsoft.Json.JsonSerializerSettings}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder AddJsonFormatters(IMvcCoreBuilder builder, Action<JsonSerializerSettings> setupAction)
    

