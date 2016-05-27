

ResourceManagerWithCultureStringLocalizer Class
===============================================






An :any:`Microsoft.Extensions.Localization.IStringLocalizer` that uses the :any:`System.Resources.ResourceManager` and
:any:`System.Resources.ResourceReader` to provide localized strings for a specific :any:`System.Globalization.CultureInfo`\.


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
* :dn:cls:`Microsoft.Extensions.Localization.ResourceManagerStringLocalizer`
* :dn:cls:`Microsoft.Extensions.Localization.ResourceManagerWithCultureStringLocalizer`








Syntax
------

.. code-block:: csharp

    public class ResourceManagerWithCultureStringLocalizer : ResourceManagerStringLocalizer, IStringLocalizer








.. dn:class:: Microsoft.Extensions.Localization.ResourceManagerWithCultureStringLocalizer
    :hidden:

.. dn:class:: Microsoft.Extensions.Localization.ResourceManagerWithCultureStringLocalizer

Properties
----------

.. dn:class:: Microsoft.Extensions.Localization.ResourceManagerWithCultureStringLocalizer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Localization.ResourceManagerWithCultureStringLocalizer.Item[System.String]
    
        
    
        
        :type name: System.String
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
            public override LocalizedString this[string name]
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.Localization.ResourceManagerWithCultureStringLocalizer.Item[System.String, System.Object[]]
    
        
    
        
        :type name: System.String
    
        
        :type arguments: System.Object<System.Object>[]
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
            public override LocalizedString this[string name, params object[] arguments]
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Extensions.Localization.ResourceManagerWithCultureStringLocalizer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Localization.ResourceManagerWithCultureStringLocalizer.ResourceManagerWithCultureStringLocalizer(System.Resources.ResourceManager, System.Reflection.Assembly, System.String, Microsoft.Extensions.Localization.IResourceNamesCache, System.Globalization.CultureInfo)
    
        
    
        
        Creates a new :any:`Microsoft.Extensions.Localization.ResourceManagerWithCultureStringLocalizer`\.
    
        
    
        
        :param resourceManager: The :any:`System.Resources.ResourceManager` to read strings from.
        
        :type resourceManager: System.Resources.ResourceManager
    
        
        :param resourceAssembly: The :any:`System.Reflection.Assembly` that contains the strings as embedded resources.
        
        :type resourceAssembly: System.Reflection.Assembly
    
        
        :param baseName: The base name of the embedded resource in the :any:`System.Reflection.Assembly` that contains the strings.
        
        :type baseName: System.String
    
        
        :param resourceNamesCache: Cache of the list of strings for a given resource assembly name.
        
        :type resourceNamesCache: Microsoft.Extensions.Localization.IResourceNamesCache
    
        
        :param culture: The specific :any:`System.Globalization.CultureInfo` to use.
        
        :type culture: System.Globalization.CultureInfo
    
        
        .. code-block:: csharp
    
            public ResourceManagerWithCultureStringLocalizer(ResourceManager resourceManager, Assembly resourceAssembly, string baseName, IResourceNamesCache resourceNamesCache, CultureInfo culture)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Localization.ResourceManagerWithCultureStringLocalizer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Localization.ResourceManagerWithCultureStringLocalizer.GetAllStrings(System.Boolean)
    
        
    
        
        :type includeParentCultures: System.Boolean
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.Localization.LocalizedString<Microsoft.Extensions.Localization.LocalizedString>}
    
        
        .. code-block:: csharp
    
            public override IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
    

