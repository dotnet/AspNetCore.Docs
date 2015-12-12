

ResourceManagerStringLocalizer Class
====================================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.Extensions.Localization.IStringLocalizer` that uses the :any:`System.Resources.ResourceManager` and 
:any:`System.Resources.ResourceReader` to provide localized strings.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Localization.ResourceManagerStringLocalizer`








Syntax
------

.. code-block:: csharp

   public class ResourceManagerStringLocalizer : IStringLocalizer





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/localization/src/Microsoft.Extensions.Localization/ResourceManagerStringLocalizer.cs>`_





.. dn:class:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizer

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
    
        
        
        
        :param resourceManager: The  to read strings from.
        
        :type resourceManager: System.Resources.ResourceManager
        
        
        :param resourceAssembly: The  that contains the strings as embedded resources.
        
        :type resourceAssembly: System.Reflection.Assembly
        
        
        :param baseName: The base name of the embedded resource in the  that contains the strings.
        
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
    
        
        
        
        :type includeAncestorCultures: System.Boolean
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.Extensions.Localization.LocalizedString}
    
        
        .. code-block:: csharp
    
           public virtual IEnumerable<LocalizedString> GetAllStrings(bool includeAncestorCultures)
    
    .. dn:method:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizer.GetAllStrings(System.Boolean, System.Globalization.CultureInfo)
    
        
    
        Returns all strings in the specified culture.
    
        
        
        
        :type includeAncestorCultures: System.Boolean
        
        
        :param culture: The  to get strings for.
        
        :type culture: System.Globalization.CultureInfo
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.Extensions.Localization.LocalizedString}
        :return: The strings.
    
        
        .. code-block:: csharp
    
           protected IEnumerable<LocalizedString> GetAllStrings(bool includeAncestorCultures, CultureInfo culture)
    
    .. dn:method:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizer.GetStringSafely(System.String, System.Globalization.CultureInfo)
    
        
    
        Gets a resource string from the :dn:field:`Microsoft.Extensions.Localization.ResourceManagerStringLocalizer._resourceManager` and returns <c>null</c> instead of
        throwing exceptions if a match isn't found.
    
        
        
        
        :param name: The name of the string resource.
        
        :type name: System.String
        
        
        :param culture: The  to get the string for.
        
        :type culture: System.Globalization.CultureInfo
        :rtype: System.String
        :return: The resource string, or <c>null</c> if none was found.
    
        
        .. code-block:: csharp
    
           protected string GetStringSafely(string name, CultureInfo culture)
    
    .. dn:method:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizer.WithCulture(System.Globalization.CultureInfo)
    
        
    
        Creates a new :any:`Microsoft.Extensions.Localization.ResourceManagerStringLocalizer` for a specific :any:`System.Globalization.CultureInfo`\.
    
        
        
        
        :param culture: The  to use.
        
        :type culture: System.Globalization.CultureInfo
        :rtype: Microsoft.Extensions.Localization.IStringLocalizer
        :return: A culture-specific <see cref="T:Microsoft.Extensions.Localization.ResourceManagerStringLocalizer" />.
    
        
        .. code-block:: csharp
    
           public IStringLocalizer WithCulture(CultureInfo culture)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizer.Item[System.String]
    
        
        
        
        :type name: System.String
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
           public virtual LocalizedString this[string name] { get; }
    
    .. dn:property:: Microsoft.Extensions.Localization.ResourceManagerStringLocalizer.Item[System.String, System.Object[]]
    
        
        
        
        :type name: System.String
        
        
        :type arguments: System.Object[]
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
           public virtual LocalizedString this[string name, params object[] arguments] { get; }
    

