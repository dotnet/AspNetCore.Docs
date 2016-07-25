

StringLocalizerExtensions Class
===============================





Namespace
    :dn:ns:`Microsoft.Extensions.Localization`
Assemblies
    * Microsoft.Extensions.Localization.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Localization.StringLocalizerExtensions`








Syntax
------

.. code-block:: csharp

    public class StringLocalizerExtensions








.. dn:class:: Microsoft.Extensions.Localization.StringLocalizerExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.Localization.StringLocalizerExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Localization.StringLocalizerExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Localization.StringLocalizerExtensions.GetAllStrings(Microsoft.Extensions.Localization.IStringLocalizer)
    
        
    
        
        Gets all string resources including those for parent cultures.
    
        
    
        
        :param stringLocalizer: The :any:`Microsoft.Extensions.Localization.IStringLocalizer`\.
        
        :type stringLocalizer: Microsoft.Extensions.Localization.IStringLocalizer
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.Localization.LocalizedString<Microsoft.Extensions.Localization.LocalizedString>}
        :return: The string resources.
    
        
        .. code-block:: csharp
    
            public static IEnumerable<LocalizedString> GetAllStrings(this IStringLocalizer stringLocalizer)
    
    .. dn:method:: Microsoft.Extensions.Localization.StringLocalizerExtensions.GetString(Microsoft.Extensions.Localization.IStringLocalizer, System.String)
    
        
    
        
        Gets the string resource with the given name.
    
        
    
        
        :param stringLocalizer: The :any:`Microsoft.Extensions.Localization.IStringLocalizer`\.
        
        :type stringLocalizer: Microsoft.Extensions.Localization.IStringLocalizer
    
        
        :param name: The name of the string resource.
        
        :type name: System.String
        :rtype: Microsoft.Extensions.Localization.LocalizedString
        :return: The string resource as a :any:`Microsoft.Extensions.Localization.LocalizedString`\.
    
        
        .. code-block:: csharp
    
            public static LocalizedString GetString(this IStringLocalizer stringLocalizer, string name)
    
    .. dn:method:: Microsoft.Extensions.Localization.StringLocalizerExtensions.GetString(Microsoft.Extensions.Localization.IStringLocalizer, System.String, System.Object[])
    
        
    
        
        Gets the string resource with the given name and formatted with the supplied arguments.
    
        
    
        
        :param stringLocalizer: The :any:`Microsoft.Extensions.Localization.IStringLocalizer`\.
        
        :type stringLocalizer: Microsoft.Extensions.Localization.IStringLocalizer
    
        
        :param name: The name of the string resource.
        
        :type name: System.String
    
        
        :param arguments: The values to format the string with.
        
        :type arguments: System.Object<System.Object>[]
        :rtype: Microsoft.Extensions.Localization.LocalizedString
        :return: The formatted string resource as a :any:`Microsoft.Extensions.Localization.LocalizedString`\.
    
        
        .. code-block:: csharp
    
            public static LocalizedString GetString(this IStringLocalizer stringLocalizer, string name, params object[] arguments)
    

