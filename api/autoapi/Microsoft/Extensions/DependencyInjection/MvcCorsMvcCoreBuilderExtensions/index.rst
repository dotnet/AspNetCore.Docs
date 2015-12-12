

MvcCorsMvcCoreBuilderExtensions Class
=====================================



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





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Cors/DependencyInjection/MvcCorsMvcCoreBuilderExtensions.cs>`_





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
    
           public static IMvcCoreBuilder AddCors(IMvcCoreBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCorsMvcCoreBuilderExtensions.AddCors(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Action<Microsoft.AspNet.Cors.Infrastructure.CorsOptions>)
    
        
        
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        
        
        :type setupAction: System.Action{Microsoft.AspNet.Cors.Infrastructure.CorsOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder AddCors(IMvcCoreBuilder builder, Action<CorsOptions> setupAction)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCorsMvcCoreBuilderExtensions.ConfigureCors(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Action<Microsoft.AspNet.Cors.Infrastructure.CorsOptions>)
    
        
        
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        
        
        :type setupAction: System.Action{Microsoft.AspNet.Cors.Infrastructure.CorsOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder ConfigureCors(IMvcCoreBuilder builder, Action<CorsOptions> setupAction)
    

