

EncoderServiceCollectionExtensions Class
========================================






Extension methods for setting up web encoding services in an :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.Extensions.WebEncoders

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.EncoderServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

    public class EncoderServiceCollectionExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.EncoderServiceCollectionExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.EncoderServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.EncoderServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.EncoderServiceCollectionExtensions.AddWebEncoders(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Adds :any:`System.Text.Encodings.Web.HtmlEncoder`\, :any:`System.Text.Encodings.Web.JavaScriptEncoder` and :any:`System.Text.Encodings.Web.UrlEncoder`
        to the specified <em>services</em>.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddWebEncoders(this IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.EncoderServiceCollectionExtensions.AddWebEncoders(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.Extensions.WebEncoders.WebEncoderOptions>)
    
        
    
        
        Adds :any:`System.Text.Encodings.Web.HtmlEncoder`\, :any:`System.Text.Encodings.Web.JavaScriptEncoder` and :any:`System.Text.Encodings.Web.UrlEncoder`
        to the specified <em>services</em>.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param setupAction: An :any:`System.Action\`1` to configure the provided :any:`Microsoft.Extensions.WebEncoders.WebEncoderOptions`\.
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.Extensions.WebEncoders.WebEncoderOptions<Microsoft.Extensions.WebEncoders.WebEncoderOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddWebEncoders(this IServiceCollection services, Action<WebEncoderOptions> setupAction)
    

