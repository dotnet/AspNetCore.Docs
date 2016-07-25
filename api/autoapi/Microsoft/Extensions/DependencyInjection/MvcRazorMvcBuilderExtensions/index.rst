

MvcRazorMvcBuilderExtensions Class
==================================






Extensions methods for configuring MVC via an :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcRazorMvcBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class MvcRazorMvcBuilderExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcRazorMvcBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcRazorMvcBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcRazorMvcBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcRazorMvcBuilderExtensions.AddRazorOptions(Microsoft.Extensions.DependencyInjection.IMvcBuilder, System.Action<Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions>)
    
        
    
        
        Configures a set of :any:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions` for the application.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
    
        
        :param setupAction: An action to configure the :any:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions`\.
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions<Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcBuilder AddRazorOptions(this IMvcBuilder builder, Action<RazorViewEngineOptions> setupAction)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcRazorMvcBuilderExtensions.AddTagHelpersAsServices(Microsoft.Extensions.DependencyInjection.IMvcBuilder)
    
        
    
        
        Registers tag helpers as services and replaces the existing :any:`Microsoft.AspNetCore.Mvc.Razor.ITagHelperActivator`
        with an :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.ServiceBasedTagHelperActivator`\.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder` instance this method extends.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder` instance this method extends.
    
        
        .. code-block:: csharp
    
            public static IMvcBuilder AddTagHelpersAsServices(this IMvcBuilder builder)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcRazorMvcBuilderExtensions.InitializeTagHelper<TTagHelper>(Microsoft.Extensions.DependencyInjection.IMvcBuilder, System.Action<TTagHelper, Microsoft.AspNetCore.Mvc.Rendering.ViewContext>)
    
        
    
        
        Adds an initialization callback for a given <em>TTagHelper</em>.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder` instance this method extends.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
    
        
        :param initialize: An action to initialize the <em>TTagHelper</em>.
        
        :type initialize: System.Action<System.Action`2>{TTagHelper, Microsoft.AspNetCore.Mvc.Rendering.ViewContext<Microsoft.AspNetCore.Mvc.Rendering.ViewContext>}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder` instance this method extends.
    
        
        .. code-block:: csharp
    
            public static IMvcBuilder InitializeTagHelper<TTagHelper>(this IMvcBuilder builder, Action<TTagHelper, ViewContext> initialize)where TTagHelper : ITagHelper
    

