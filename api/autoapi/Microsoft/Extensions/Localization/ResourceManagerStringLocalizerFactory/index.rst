

ResourceManagerStringLocalizerFactory Class
===========================================






An :any:`Microsoft.Extensions.Localization.IStringLocalizerFactory` that creates instances of :any:`Microsoft.Extensions.Localization.ResourceManagerStringLocalizer`\.


Namespace
    :dn:ns:`Microsoft.Extensions.Localization`
Assemblies
    * Microsoft.Extensions.Localization

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Localization.ResourceManagerStringLocalizerFactory`








Syntax
------

.. code-block:: csharp

    public class ResourceManagerStringLocalizerFactory : IStringLocalizerFactory








.. dn:class:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizerFactory
    :hidden:

.. dn:class:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizerFactory

Constructors
------------

.. dn:class:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizerFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizerFactory.ResourceManagerStringLocalizerFactory(Microsoft.AspNetCore.Hosting.IHostingEnvironment, Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Localization.LocalizationOptions>)
    
        
    
        
        Creates a new :any:`Microsoft.Extensions.Localization.ResourceManagerStringLocalizer`\.
    
        
    
        
        :param hostingEnvironment: The :any:`Microsoft.AspNetCore.Hosting.IHostingEnvironment`\.
        
        :type hostingEnvironment: Microsoft.AspNetCore.Hosting.IHostingEnvironment
    
        
        :param localizationOptions: The :any:`Microsoft.Extensions.Options.IOptions\`1`\.
        
        :type localizationOptions: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.Extensions.Localization.LocalizationOptions<Microsoft.Extensions.Localization.LocalizationOptions>}
    
        
        .. code-block:: csharp
    
            public ResourceManagerStringLocalizerFactory(IHostingEnvironment hostingEnvironment, IOptions<LocalizationOptions> localizationOptions)
    

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
        :return: The :any:`Microsoft.Extensions.Localization.ResourceManagerStringLocalizer`\.
    
        
        .. code-block:: csharp
    
            public IStringLocalizer Create(string baseName, string location)
    
    .. dn:method:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizerFactory.Create(System.Type)
    
        
    
        
        Creates a :any:`Microsoft.Extensions.Localization.ResourceManagerStringLocalizer` using the :any:`System.Reflection.Assembly` and 
        :dn:prop:`System.Type.FullName` of the specified :any:`System.Type`\.
    
        
    
        
        :param resourceSource: The :any:`System.Type`\.
        
        :type resourceSource: System.Type
        :rtype: Microsoft.Extensions.Localization.IStringLocalizer
        :return: The :any:`Microsoft.Extensions.Localization.ResourceManagerStringLocalizer`\.
    
        
        .. code-block:: csharp
    
            public IStringLocalizer Create(Type resourceSource)
    

