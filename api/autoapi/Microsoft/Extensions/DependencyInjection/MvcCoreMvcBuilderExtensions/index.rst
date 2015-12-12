

MvcCoreMvcBuilderExtensions Class
=================================



.. contents:: 
   :local:



Summary
-------

Extensions for configuring MVC using an :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class MvcCoreMvcBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/DependencyInjection/MvcCoreMvcBuilderExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions.AddControllersAsServices(Microsoft.Extensions.DependencyInjection.IMvcBuilder, System.Collections.Generic.IEnumerable<System.Reflection.Assembly>)
    
        
    
        Registers controller types from the specified ``assemblies`` as services and as a source
        for controller discovery.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        
        
        :param controllerAssemblies: Assemblies to scan.
        
        :type controllerAssemblies: System.Collections.Generic.IEnumerable{System.Reflection.Assembly}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IMvcBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IMvcBuilder AddControllersAsServices(IMvcBuilder builder, IEnumerable<Assembly> controllerAssemblies)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions.AddControllersAsServices(Microsoft.Extensions.DependencyInjection.IMvcBuilder, System.Collections.Generic.IEnumerable<System.Type>)
    
        
    
        Register the specified ``controllerTypes`` as services and as a source for controller
        discovery.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        
        
        :param controllerTypes: A sequence of controller s to register in the
            and used for controller discovery.
        
        :type controllerTypes: System.Collections.Generic.IEnumerable{System.Type}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IMvcBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IMvcBuilder AddControllersAsServices(IMvcBuilder builder, IEnumerable<Type> controllerTypes)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions.AddFormatterMappings(Microsoft.Extensions.DependencyInjection.IMvcBuilder, System.Action<Microsoft.AspNet.Mvc.Formatters.FormatterMappings>)
    
        
        
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        
        
        :type setupAction: System.Action{Microsoft.AspNet.Mvc.Formatters.FormatterMappings}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
    
        
        .. code-block:: csharp
    
           public static IMvcBuilder AddFormatterMappings(IMvcBuilder builder, Action<FormatterMappings> setupAction)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions.AddMvcOptions(Microsoft.Extensions.DependencyInjection.IMvcBuilder, System.Action<Microsoft.AspNet.Mvc.MvcOptions>)
    
        
    
        Registers an action to configure :any:`Microsoft.AspNet.Mvc.MvcOptions`\.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        
        
        :param setupAction: An .
        
        :type setupAction: System.Action{Microsoft.AspNet.Mvc.MvcOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IMvcBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IMvcBuilder AddMvcOptions(IMvcBuilder builder, Action<MvcOptions> setupAction)
    

