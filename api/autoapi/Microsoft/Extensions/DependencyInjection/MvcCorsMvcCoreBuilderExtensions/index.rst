

MvcCorsMvcCoreBuilderExtensions Class
=====================================





Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.AspNetCore.Mvc.Cors

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcCorsMvcCoreBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class MvcCorsMvcCoreBuilderExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcCorsMvcCoreBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcCorsMvcCoreBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcCorsMvcCoreBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCorsMvcCoreBuilderExtensions.AddCors(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder)
    
        
    
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder AddCors(this IMvcCoreBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCorsMvcCoreBuilderExtensions.AddCors(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Action<Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions>)
    
        
    
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions<Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder AddCors(this IMvcCoreBuilder builder, Action<CorsOptions> setupAction)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCorsMvcCoreBuilderExtensions.ConfigureCors(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Action<Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions>)
    
        
    
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions<Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder ConfigureCors(this IMvcCoreBuilder builder, Action<CorsOptions> setupAction)
    

