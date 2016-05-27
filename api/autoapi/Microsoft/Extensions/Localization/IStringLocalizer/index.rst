

IStringLocalizer Interface
==========================






Represents a service that provides localized strings.


Namespace
    :dn:ns:`Microsoft.Extensions.Localization`
Assemblies
    * Microsoft.Extensions.Localization.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IStringLocalizer








.. dn:interface:: Microsoft.Extensions.Localization.IStringLocalizer
    :hidden:

.. dn:interface:: Microsoft.Extensions.Localization.IStringLocalizer

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
        :return: The string resource as a :any:`Microsoft.Extensions.Localization.LocalizedString`\.
    
        
        .. code-block:: csharp
    
            LocalizedString this[string name]
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.Localization.IStringLocalizer.Item[System.String, System.Object[]]
    
        
    
        
        Gets the string resource with the given name and formatted with the supplied arguments.
    
        
    
        
        :param name: The name of the string resource.
        
        :type name: System.String
    
        
        :param arguments: The values to format the string with.
        
        :type arguments: System.Object<System.Object>[]
        :rtype: Microsoft.Extensions.Localization.LocalizedString
        :return: The formatted string resource as a :any:`Microsoft.Extensions.Localization.LocalizedString`\.
    
        
        .. code-block:: csharp
    
            LocalizedString this[string name, params object[] arguments]
            {
                get;
            }
    

Methods
-------

.. dn:interface:: Microsoft.Extensions.Localization.IStringLocalizer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Localization.IStringLocalizer.GetAllStrings(System.Boolean)
    
        
    
        
        Gets all string resources.
    
        
    
        
        :param includeParentCultures: 
            A :any:`System.Boolean` indicating whether to include strings from parent cultures.
        
        :type includeParentCultures: System.Boolean
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.Localization.LocalizedString<Microsoft.Extensions.Localization.LocalizedString>}
        :return: The strings.
    
        
        .. code-block:: csharp
    
            IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
    
    .. dn:method:: Microsoft.Extensions.Localization.IStringLocalizer.WithCulture(System.Globalization.CultureInfo)
    
        
    
        
        Creates a new :any:`Microsoft.Extensions.Localization.IStringLocalizer` for a specific :any:`System.Globalization.CultureInfo`\.
    
        
    
        
        :param culture: The :any:`System.Globalization.CultureInfo` to use.
        
        :type culture: System.Globalization.CultureInfo
        :rtype: Microsoft.Extensions.Localization.IStringLocalizer
        :return: A culture-specific :any:`Microsoft.Extensions.Localization.IStringLocalizer`\.
    
        
        .. code-block:: csharp
    
            IStringLocalizer WithCulture(CultureInfo culture)
    

