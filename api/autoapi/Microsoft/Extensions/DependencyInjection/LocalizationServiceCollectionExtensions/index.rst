

LocalizationServiceCollectionExtensions Class
=============================================



.. contents:: 
   :local:



Summary
-------

Extension methods for adding localization servics to the DI container.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

   public class LocalizationServiceCollectionExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/localization/blob/master/src/Microsoft.Extensions.Localization/LocalizationServiceCollectionExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        Adds services required for application localization.
    
        
        
        
        :param services: The  to add the services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IServiceCollection" />.
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddLocalization(IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.Extensions.Localization.LocalizationOptions>)
    
        
    
        Adds services required for application localization.
    
        
        
        
        :param services: The  to add the services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :param setupAction: An action to configure the .
        
        :type setupAction: System.Action{Microsoft.Extensions.Localization.LocalizationOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IServiceCollection" />.
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddLocalization(IServiceCollection services, Action<LocalizationOptions> setupAction)
    

