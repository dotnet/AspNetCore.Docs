

MvcCoreMvcCoreBuilderExtensions Class
=====================================





Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcCoreMvcCoreBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class MvcCoreMvcCoreBuilderExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcCoreBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcCoreBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcCoreBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcCoreBuilderExtensions.AddApplicationPart(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Reflection.Assembly)
    
        
    
        
        Adds an :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart` to the list of :dn:prop:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager.ApplicationParts` on the 
        :dn:prop:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder.PartManager`\.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        :param assembly: The :any:`System.Reflection.Assembly` of the :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart`\.
        
        :type assembly: System.Reflection.Assembly
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder AddApplicationPart(this IMvcCoreBuilder builder, Assembly assembly)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcCoreBuilderExtensions.AddAuthorization(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder)
    
        
    
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder AddAuthorization(this IMvcCoreBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcCoreBuilderExtensions.AddAuthorization(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Action<Microsoft.AspNetCore.Authorization.AuthorizationOptions>)
    
        
    
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.AspNetCore.Authorization.AuthorizationOptions<Microsoft.AspNetCore.Authorization.AuthorizationOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder AddAuthorization(this IMvcCoreBuilder builder, Action<AuthorizationOptions> setupAction)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcCoreBuilderExtensions.AddControllersAsServices(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder)
    
        
    
        
        Registers discovered controllers as services in the :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder AddControllersAsServices(this IMvcCoreBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcCoreBuilderExtensions.AddFormatterMappings(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder)
    
        
    
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder AddFormatterMappings(this IMvcCoreBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcCoreBuilderExtensions.AddFormatterMappings(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Action<Microsoft.AspNetCore.Mvc.Formatters.FormatterMappings>)
    
        
    
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.AspNetCore.Mvc.Formatters.FormatterMappings<Microsoft.AspNetCore.Mvc.Formatters.FormatterMappings>}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder AddFormatterMappings(this IMvcCoreBuilder builder, Action<FormatterMappings> setupAction)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcCoreBuilderExtensions.AddMvcOptions(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Action<Microsoft.AspNetCore.Mvc.MvcOptions>)
    
        
    
        
        Registers an action to configure :any:`Microsoft.AspNetCore.Mvc.MvcOptions`\.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        :param setupAction: An :any:`System.Action\`1`\.
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.AspNetCore.Mvc.MvcOptions<Microsoft.AspNetCore.Mvc.MvcOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder AddMvcOptions(this IMvcCoreBuilder builder, Action<MvcOptions> setupAction)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcCoreBuilderExtensions.ConfigureApplicationPartManager(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Action<Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager>)
    
        
    
        
        Configures the :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager` of the :dn:prop:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder.PartManager` using
        the given :any:`System.Action\`1`\.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        :param setupAction: The :any:`System.Action\`1`
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager<Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager>}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder ConfigureApplicationPartManager(this IMvcCoreBuilder builder, Action<ApplicationPartManager> setupAction)
    

