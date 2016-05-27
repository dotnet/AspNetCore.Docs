

MvcCoreMvcBuilderExtensions Class
=================================






Extensions for configuring MVC using an :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.


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
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class MvcCoreMvcBuilderExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions.AddApplicationPart(Microsoft.Extensions.DependencyInjection.IMvcBuilder, System.Reflection.Assembly)
    
        
    
        
        Adds an :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart` to the list of :dn:prop:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager.ApplicationParts` on the
        :dn:prop:`Microsoft.Extensions.DependencyInjection.IMvcBuilder.PartManager`\.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
    
        
        :param assembly: The :any:`System.Reflection.Assembly` of the :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart`\.
        
        :type assembly: System.Reflection.Assembly
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcBuilder AddApplicationPart(IMvcBuilder builder, Assembly assembly)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions.AddControllersAsServices(Microsoft.Extensions.DependencyInjection.IMvcBuilder)
    
        
    
        
        Registers discovered controllers as services in the :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcBuilder AddControllersAsServices(IMvcBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions.AddFormatterMappings(Microsoft.Extensions.DependencyInjection.IMvcBuilder, System.Action<Microsoft.AspNetCore.Mvc.Formatters.FormatterMappings>)
    
        
    
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
    
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.AspNetCore.Mvc.Formatters.FormatterMappings<Microsoft.AspNetCore.Mvc.Formatters.FormatterMappings>}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
    
        
        .. code-block:: csharp
    
            public static IMvcBuilder AddFormatterMappings(IMvcBuilder builder, Action<FormatterMappings> setupAction)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions.AddMvcOptions(Microsoft.Extensions.DependencyInjection.IMvcBuilder, System.Action<Microsoft.AspNetCore.Mvc.MvcOptions>)
    
        
    
        
        Registers an action to configure :any:`Microsoft.AspNetCore.Mvc.MvcOptions`\.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
    
        
        :param setupAction: An :any:`System.Action\`1`\.
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.AspNetCore.Mvc.MvcOptions<Microsoft.AspNetCore.Mvc.MvcOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcBuilder AddMvcOptions(IMvcBuilder builder, Action<MvcOptions> setupAction)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions.ConfigureApplicationPartManager(Microsoft.Extensions.DependencyInjection.IMvcBuilder, System.Action<Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager>)
    
        
    
        
        Configures the :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager` of the :dn:prop:`Microsoft.Extensions.DependencyInjection.IMvcBuilder.PartManager` using
        the given :any:`System.Action\`1`\.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
    
        
        :param setupAction: The :any:`System.Action\`1`
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager<Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager>}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcBuilder ConfigureApplicationPartManager(IMvcBuilder builder, Action<ApplicationPartManager> setupAction)
    

