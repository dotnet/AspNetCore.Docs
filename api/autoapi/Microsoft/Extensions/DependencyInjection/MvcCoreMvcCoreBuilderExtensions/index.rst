

MvcCoreMvcCoreBuilderExtensions Class
=====================================



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





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/DependencyInjection/MvcCoreMvcCoreBuilderExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcCoreBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcCoreBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcCoreBuilderExtensions.AddAuthorization(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder)
    
        
        
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder AddAuthorization(IMvcCoreBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcCoreBuilderExtensions.AddAuthorization(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Action<Microsoft.AspNet.Authorization.AuthorizationOptions>)
    
        
        
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        
        
        :type setupAction: System.Action{Microsoft.AspNet.Authorization.AuthorizationOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder AddAuthorization(IMvcCoreBuilder builder, Action<AuthorizationOptions> setupAction)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcCoreBuilderExtensions.AddControllersAsServices(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Collections.Generic.IEnumerable<System.Reflection.Assembly>)
    
        
    
        Registers controller types from the specified ``assemblies`` as services and as a source
        for controller discovery.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        
        
        :param controllerAssemblies: Assemblies to scan.
        
        :type controllerAssemblies: System.Collections.Generic.IEnumerable{System.Reflection.Assembly}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder AddControllersAsServices(IMvcCoreBuilder builder, IEnumerable<Assembly> controllerAssemblies)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcCoreBuilderExtensions.AddControllersAsServices(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Collections.Generic.IEnumerable<System.Type>)
    
        
    
        Register the specified ``controllerTypes`` as services and as a source for controller
        discovery.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        
        
        :param controllerTypes: A sequence of controller s to register in the
            and used for controller discovery.
        
        :type controllerTypes: System.Collections.Generic.IEnumerable{System.Type}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder AddControllersAsServices(IMvcCoreBuilder builder, IEnumerable<Type> controllerTypes)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcCoreBuilderExtensions.AddFormatterMappings(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder)
    
        
        
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder AddFormatterMappings(IMvcCoreBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcCoreBuilderExtensions.AddFormatterMappings(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Action<Microsoft.AspNet.Mvc.Formatters.FormatterMappings>)
    
        
        
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        
        
        :type setupAction: System.Action{Microsoft.AspNet.Mvc.Formatters.FormatterMappings}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder AddFormatterMappings(IMvcCoreBuilder builder, Action<FormatterMappings> setupAction)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcCoreBuilderExtensions.AddMvcOptions(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder, System.Action<Microsoft.AspNet.Mvc.MvcOptions>)
    
        
    
        Registers an action to configure :any:`Microsoft.AspNet.Mvc.MvcOptions`\.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        
        
        :param setupAction: An .
        
        :type setupAction: System.Action{Microsoft.AspNet.Mvc.MvcOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder AddMvcOptions(IMvcCoreBuilder builder, Action<MvcOptions> setupAction)
    

