

IHtmlLocalizer Interface
========================






Represents a type that that does HTML-aware localization of strings, by HTML encoding arguments that are
formatted in the resource string.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Localization`
Assemblies
    * Microsoft.AspNetCore.Mvc.Localization

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IHtmlLocalizer








.. dn:interface:: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer.Item[System.String]
    
        
    
        
        Gets the string resource with the given name.
    
        
    
        
        :param name: The name of the string resource.
        
        :type name: System.String
        :rtype: Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString
        :return: The string resource as a :any:`Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString`\.
    
        
        .. code-block:: csharp
    
            LocalizedHtmlString this[string name]
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer.Item[System.String, System.Object[]]
    
        
    
        
        Gets the string resource with the given name and formatted with the supplied arguments. The arguments will
        be HTML encoded.
    
        
    
        
        :param name: The name of the string resource.
        
        :type name: System.String
    
        
        :param arguments: The values to format the string with.
        
        :type arguments: System.Object<System.Object>[]
        :rtype: Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString
        :return: The formatted string resource as a :any:`Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString`\.
    
        
        .. code-block:: csharp
    
            LocalizedHtmlString this[string name, params object[] arguments]
            {
                get;
            }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer.GetAllStrings(System.Boolean)
    
        
    
        
        Gets all string resources.
    
        
    
        
        :param includeParentCultures: 
            A :any:`System.Boolean` indicating whether to include strings from parent cultures.
        
        :type includeParentCultures: System.Boolean
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.Localization.LocalizedString<Microsoft.Extensions.Localization.LocalizedString>}
        :return: The strings.
    
        
        .. code-block:: csharp
    
            IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer.GetString(System.String)
    
        
    
        
        Gets the string resource with the given name.
    
        
    
        
        :param name: The name of the string resource.
        
        :type name: System.String
        :rtype: Microsoft.Extensions.Localization.LocalizedString
        :return: The string resource as a :any:`Microsoft.Extensions.Localization.LocalizedString`\.
    
        
        .. code-block:: csharp
    
            LocalizedString GetString(string name)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer.GetString(System.String, System.Object[])
    
        
    
        
        Gets the string resource with the given name and formatted with the supplied arguments.
    
        
    
        
        :param name: The name of the string resource.
        
        :type name: System.String
    
        
        :param arguments: The values to format the string with.
        
        :type arguments: System.Object<System.Object>[]
        :rtype: Microsoft.Extensions.Localization.LocalizedString
        :return: The formatted string resource as a :any:`Microsoft.Extensions.Localization.LocalizedString`\.
    
        
        .. code-block:: csharp
    
            LocalizedString GetString(string name, params object[] arguments)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer.WithCulture(System.Globalization.CultureInfo)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer` for a specific :any:`System.Globalization.CultureInfo`\.
    
        
    
        
        :param culture: The :any:`System.Globalization.CultureInfo` to use.
        
        :type culture: System.Globalization.CultureInfo
        :rtype: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer
        :return: A culture-specific :any:`Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer`\.
    
        
        .. code-block:: csharp
    
            IHtmlLocalizer WithCulture(CultureInfo culture)
    

