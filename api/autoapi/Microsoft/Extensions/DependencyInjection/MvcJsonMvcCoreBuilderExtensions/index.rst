

MvcJsonMvcCoreBuilderExtensions Class
=====================================





Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.AspNetCore.Mvc.Formatters.Json

----

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








.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcJsonMvcCoreBuilderExtensions
    :hidden:

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
    
            public static IMvcCoreBuilder AddJsonFormatters(this IMvcCoreBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcJsonMvcCoreBuilderExtensions.AddJsonFormatters(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Action<Newtonsoft.Json.JsonSerializerSettings>)
    
        
    
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        :type setupAction: System.Action<System.Action`1>{Newtonsoft.Json.JsonSerializerSettings<Newtonsoft.Json.JsonSerializerSettings>}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder AddJsonFormatters(this IMvcCoreBuilder builder, Action<JsonSerializerSettings> setupAction)
    

