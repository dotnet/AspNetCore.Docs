

MvcJsonMvcBuilderExtensions Class
=================================






Extensions methods for configuring MVC via an :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.


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
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcJsonMvcBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class MvcJsonMvcBuilderExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcJsonMvcBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcJsonMvcBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcJsonMvcBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcJsonMvcBuilderExtensions.AddJsonOptions(Microsoft.Extensions.DependencyInjection.IMvcBuilder, System.Action<Microsoft.AspNetCore.Mvc.MvcJsonOptions>)
    
        
    
        
        Adds configuration of :any:`Microsoft.AspNetCore.Mvc.MvcJsonOptions` for the application.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcBuilder
    
        
        :param setupAction: The :any:`Microsoft.AspNetCore.Mvc.MvcJsonOptions` which need to be configured.
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.AspNetCore.Mvc.MvcJsonOptions<Microsoft.AspNetCore.Mvc.MvcJsonOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
    
        
        .. code-block:: csharp
    
            public static IMvcBuilder AddJsonOptions(IMvcBuilder builder, Action<MvcJsonOptions> setupAction)
    

