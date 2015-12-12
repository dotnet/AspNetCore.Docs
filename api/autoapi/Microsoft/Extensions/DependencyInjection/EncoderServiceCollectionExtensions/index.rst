

EncoderServiceCollectionExtensions Class
========================================



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





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.Extensions.WebEncoders/EncoderServiceCollectionExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.EncoderServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.EncoderServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.EncoderServiceCollectionExtensions.AddWebEncoders(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddWebEncoders(IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.EncoderServiceCollectionExtensions.AddWebEncoders(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.Extensions.WebEncoders.WebEncoderOptions>)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type configureOptions: System.Action{Microsoft.Extensions.WebEncoders.WebEncoderOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddWebEncoders(IServiceCollection services, Action<WebEncoderOptions> configureOptions)
    

