

ResourceManagerStringLocalizer Class
====================================






An :any:`Microsoft.Extensions.Localization.IStringLocalizer` that uses the :any:`System.Resources.ResourceManager` and
:any:`System.Resources.ResourceReader` to provide localized strings.


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








Syntax
------

.. code-block:: csharp

    public class ResourceManagerStringLocalizer : IStringLocalizer








.. dn:class:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizer
    :hidden:

.. dn:class:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizer

Properties
----------

.. dn:class:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizer.Item[System.String]
    
        
    
        
        :type name: System.String
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
            public virtual LocalizedString this[string name]
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizer.Item[System.String, System.Object[]]
    
        
    
        
        :type name: System.String
    
        
        :type arguments: System.Object<System.Object>[]
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
            public virtual LocalizedString this[string name, params object[] arguments]
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizer.ResourceManagerStringLocalizer(System.Resources.ResourceManager, Microsoft.Extensions.Localization.Internal.AssemblyWrapper, System.String, Microsoft.Extensions.Localization.IResourceNamesCache)
    
        
    
        
        Intended for testing purposes only.
    
        
    
        
        :type resourceManager: System.Resources.ResourceManager
    
        
        :type resourceAssemblyWrapper: Microsoft.Extensions.Localization.Internal.AssemblyWrapper
    
        
        :type baseName: System.String
    
        
        :type resourceNamesCache: Microsoft.Extensions.Localization.IResourceNamesCache
    
        
        .. code-block:: csharp
    
            public ResourceManagerStringLocalizer(ResourceManager resourceManager, AssemblyWrapper resourceAssemblyWrapper, string baseName, IResourceNamesCache resourceNamesCache)
    
    .. dn:constructor:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizer.ResourceManagerStringLocalizer(System.Resources.ResourceManager, System.Reflection.Assembly, System.String, Microsoft.Extensions.Localization.IResourceNamesCache)
    
        
    
        
        Creates a new :any:`Microsoft.Extensions.Localization.ResourceManagerStringLocalizer`\.
    
        
    
        
        :param resourceManager: The :any:`System.Resources.ResourceManager` to read strings from.
        
        :type resourceManager: System.Resources.ResourceManager
    
        
        :param resourceAssembly: The :any:`System.Reflection.Assembly` that contains the strings as embedded resources.
        
        :type resourceAssembly: System.Reflection.Assembly
    
        
        :param baseName: The base name of the embedded resource in the :any:`System.Reflection.Assembly` that contains the strings.
        
        :type baseName: System.String
    
        
        :param resourceNamesCache: Cache of the list of strings for a given resource assembly name.
        
        :type resourceNamesCache: Microsoft.Extensions.Localization.IResourceNamesCache
    
        
        .. code-block:: csharp
    
            public ResourceManagerStringLocalizer(ResourceManager resourceManager, Assembly resourceAssembly, string baseName, IResourceNamesCache resourceNamesCache)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizer.GetAllStrings(System.Boolean)
    
        
    
        
        :type includeParentCultures: System.Boolean
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.Localization.LocalizedString<Microsoft.Extensions.Localization.LocalizedString>}
    
        
        .. code-block:: csharp
    
            public virtual IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
    
    .. dn:method:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizer.GetAllStrings(System.Boolean, System.Globalization.CultureInfo)
    
        
    
        
        Returns all strings in the specified culture.
    
        
    
        
        :type includeParentCultures: System.Boolean
    
        
        :param culture: The :any:`System.Globalization.CultureInfo` to get strings for.
        
        :type culture: System.Globalization.CultureInfo
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.Localization.LocalizedString<Microsoft.Extensions.Localization.LocalizedString>}
        :return: The strings.
    
        
        .. code-block:: csharp
    
            protected IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures, CultureInfo culture)
    
    .. dn:method:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizer.GetStringSafely(System.String, System.Globalization.CultureInfo)
    
        
    
        
        Gets a resource string from the :dn:field:`Microsoft.Extensions.Localization.ResourceManagerStringLocalizer._resourceManager` and returns <code>null</code> instead of
        throwing exceptions if a match isn't found.
    
        
    
        
        :param name: The name of the string resource.
        
        :type name: System.String
    
        
        :param culture: The :any:`System.Globalization.CultureInfo` to get the string for.
        
        :type culture: System.Globalization.CultureInfo
        :rtype: System.String
        :return: The resource string, or <code>null</code> if none was found.
    
        
        .. code-block:: csharp
    
            protected string GetStringSafely(string name, CultureInfo culture)
    
    .. dn:method:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizer.WithCulture(System.Globalization.CultureInfo)
    
        
    
        
        Creates a new :any:`Microsoft.Extensions.Localization.ResourceManagerStringLocalizer` for a specific :any:`System.Globalization.CultureInfo`\.
    
        
    
        
        :param culture: The :any:`System.Globalization.CultureInfo` to use.
        
        :type culture: System.Globalization.CultureInfo
        :rtype: Microsoft.Extensions.Localization.IStringLocalizer
        :return: A culture-specific :any:`Microsoft.Extensions.Localization.ResourceManagerStringLocalizer`\.
    
        
        .. code-block:: csharp
    
            public IStringLocalizer WithCulture(CultureInfo culture)
    

