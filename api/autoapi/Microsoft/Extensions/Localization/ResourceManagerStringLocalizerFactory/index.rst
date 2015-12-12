

ResourceManagerStringLocalizerFactory Class
===========================================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.Extensions.Localization.IStringLocalizerFactory` that creates instances of :any:`Microsoft.Extensions.Localization.ResourceManagerStringLocalizer`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Localization.ResourceManagerStringLocalizerFactory`








Syntax
------

.. code-block:: csharp

   public class ResourceManagerStringLocalizerFactory : IStringLocalizerFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/localization/src/Microsoft.Extensions.Localization/ResourceManagerStringLocalizerFactory.cs>`_





.. dn:class:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizerFactory

Constructors
------------

.. dn:class:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizerFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizerFactory.ResourceManagerStringLocalizerFactory(Microsoft.Extensions.PlatformAbstractions.IApplicationEnvironment, Microsoft.Extensions.OptionsModel.IOptions<Microsoft.Extensions.Localization.LocalizationOptions>)
    
        
    
        Creates a new :any:`Microsoft.Extensions.Localization.ResourceManagerStringLocalizer`\.
    
        
        
        
        :param applicationEnvironment: The .
        
        :type applicationEnvironment: Microsoft.Extensions.PlatformAbstractions.IApplicationEnvironment
        
        
        :param localizationOptions: The .
        
        :type localizationOptions: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.Extensions.Localization.LocalizationOptions}
    
        
        .. code-block:: csharp
    
           public ResourceManagerStringLocalizerFactory(IApplicationEnvironment applicationEnvironment, IOptions<LocalizationOptions> localizationOptions)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizerFactory.Create(System.String, System.String)
    
        
    
        Creates a :any:`Microsoft.Extensions.Localization.ResourceManagerStringLocalizer`\.
    
        
        
        
        :param baseName: The base name of the resource to load strings from.
        
        :type baseName: System.String
        
        
        :param location: The location to load resources from.
        
        :type location: System.String
        :rtype: Microsoft.Extensions.Localization.IStringLocalizer
        :return: The <see cref="T:Microsoft.Extensions.Localization.ResourceManagerStringLocalizer" />.
    
        
        .. code-block:: csharp
    
           public IStringLocalizer Create(string baseName, string location)
    
    .. dn:method:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizerFactory.Create(System.Type)
    
        
    
        Creates a :any:`Microsoft.Extensions.Localization.ResourceManagerStringLocalizer` using the :any:`System.Reflection.Assembly` and 
        :dn:prop:`System.Type.FullName` of the specified :any:`System.Type`\.
    
        
        
        
        :param resourceSource: The .
        
        :type resourceSource: System.Type
        :rtype: Microsoft.Extensions.Localization.IStringLocalizer
        :return: The <see cref="T:Microsoft.Extensions.Localization.ResourceManagerStringLocalizer" />.
    
        
        .. code-block:: csharp
    
           public IStringLocalizer Create(Type resourceSource)
    

