

MvcRazorMvcBuilderExtensions Class
==================================



.. contents:: 
   :local:



Summary
-------

Extensions methods for configuring MVC via an :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcRazorMvcBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class MvcRazorMvcBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor/DependencyInjection/MvcRazorMvcBuilderExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcRazorMvcBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcRazorMvcBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcRazorMvcBuilderExtensions.AddPrecompiledRazorViews(Microsoft.Extensions.DependencyInjection.IMvcBuilder, System.Reflection.Assembly[])
    
        
        
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        
        
        :type assemblies: System.Reflection.Assembly[]
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
    
        
        .. code-block:: csharp
    
           public static IMvcBuilder AddPrecompiledRazorViews(IMvcBuilder builder, params Assembly[] assemblies)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcRazorMvcBuilderExtensions.AddRazorOptions(Microsoft.Extensions.DependencyInjection.IMvcBuilder, System.Action<Microsoft.AspNet.Mvc.Razor.RazorViewEngineOptions>)
    
        
    
        Configures a set of :any:`Microsoft.AspNet.Mvc.Razor.RazorViewEngineOptions` for the application.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        
        
        :param setupAction: An action to configure the .
        
        :type setupAction: System.Action{Microsoft.AspNet.Mvc.Razor.RazorViewEngineOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IMvcBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IMvcBuilder AddRazorOptions(IMvcBuilder builder, Action<RazorViewEngineOptions> setupAction)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcRazorMvcBuilderExtensions.InitializeTagHelper<TTagHelper>(Microsoft.Extensions.DependencyInjection.IMvcBuilder, System.Action<TTagHelper, Microsoft.AspNet.Mvc.Rendering.ViewContext>)
    
        
    
        Adds an initialization callback for a given ``TTagHelper``.
    
        
        
        
        :param builder: The  instance this method extends.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        
        
        :param initialize: An action to initialize the .
        
        :type initialize: System.Action{{TTagHelper},Microsoft.AspNet.Mvc.Rendering.ViewContext}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IMvcBuilder" /> instance this method extends.
    
        
        .. code-block:: csharp
    
           public static IMvcBuilder InitializeTagHelper<TTagHelper>(IMvcBuilder builder, Action<TTagHelper, ViewContext> initialize)where TTagHelper : ITagHelper
    

