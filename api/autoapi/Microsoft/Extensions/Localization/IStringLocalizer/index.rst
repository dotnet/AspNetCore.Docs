

IStringLocalizer Interface
==========================



.. contents:: 
   :local:



Summary
-------

Represents a service that provides localized strings.











Syntax
------

.. code-block:: csharp

   public interface IStringLocalizer





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/localization/src/Microsoft.Extensions.Localization.Abstractions/IStringLocalizer.cs>`_





.. dn:interface:: Microsoft.Extensions.Localization.IStringLocalizer

Methods
-------

.. dn:interface:: Microsoft.Extensions.Localization.IStringLocalizer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Localization.IStringLocalizer.GetAllStrings(System.Boolean)
    
        
    
        Gets all string resources.
    
        
        
        
        :param includeAncestorCultures: A  indicating whether to include
            strings from ancestor cultures.
        
        :type includeAncestorCultures: System.Boolean
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.Extensions.Localization.LocalizedString}
        :return: The strings.
    
        
        .. code-block:: csharp
    
           IEnumerable<LocalizedString> GetAllStrings(bool includeAncestorCultures)
    
    .. dn:method:: Microsoft.Extensions.Localization.IStringLocalizer.WithCulture(System.Globalization.CultureInfo)
    
        
    
        Creates a new ResourceManagerStringLocalizer for a specific :any:`System.Globalization.CultureInfo`\.
    
        
        
        
        :param culture: The  to use.
        
        :type culture: System.Globalization.CultureInfo
        :rtype: Microsoft.Extensions.Localization.IStringLocalizer
        :return: A culture-specific <see cref="T:Microsoft.Extensions.Localization.IStringLocalizer" />.
    
        
        .. code-block:: csharp
    
           IStringLocalizer WithCulture(CultureInfo culture)
    

Properties
----------

.. dn:interface:: Microsoft.Extensions.Localization.IStringLocalizer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Localization.IStringLocalizer.Item[System.String]
    
        
    
        Gets the string resource with the given name.
    
        
        
        
        :param name: The name of the string resource.
        
        :type name: System.String
        :rtype: Microsoft.Extensions.Localization.LocalizedString
        :return: The string resource as a <see cref="T:Microsoft.Extensions.Localization.LocalizedString" />.
    
        
        .. code-block:: csharp
    
           LocalizedString this[string name] { get; }
    
    .. dn:property:: Microsoft.Extensions.Localization.IStringLocalizer.Item[System.String, System.Object[]]
    
        
    
        Gets the string resource with the given name and formatted with the supplied arguments.
    
        
        
        
        :param name: The name of the string resource.
        
        :type name: System.String
        
        
        :param arguments: The values to format the string with.
        
        :type arguments: System.Object[]
        :rtype: Microsoft.Extensions.Localization.LocalizedString
        :return: The formatted string resource as a <see cref="T:Microsoft.Extensions.Localization.LocalizedString" />.
    
        
        .. code-block:: csharp
    
           LocalizedString this[string name, params object[] arguments] { get; }
    

