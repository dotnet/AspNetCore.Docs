

StringLocalizerExtensions Class
===============================



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





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/localization/src/Microsoft.Extensions.Localization.Abstractions/StringLocalizerExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.Localization.StringLocalizerExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Localization.StringLocalizerExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Localization.StringLocalizerExtensions.GetAllStrings(Microsoft.Extensions.Localization.IStringLocalizer)
    
        
    
        Gets all string resources including those for ancestor cultures.
    
        
        
        
        :param stringLocalizer: The .
        
        :type stringLocalizer: Microsoft.Extensions.Localization.IStringLocalizer
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.Extensions.Localization.LocalizedString}
        :return: The string resources.
    
        
        .. code-block:: csharp
    
           public static IEnumerable<LocalizedString> GetAllStrings(IStringLocalizer stringLocalizer)
    
    .. dn:method:: Microsoft.Extensions.Localization.StringLocalizerExtensions.GetString(Microsoft.Extensions.Localization.IStringLocalizer, System.String)
    
        
    
        Gets the string resource with the given name.
    
        
        
        
        :param stringLocalizer: The .
        
        :type stringLocalizer: Microsoft.Extensions.Localization.IStringLocalizer
        
        
        :param name: The name of the string resource.
        
        :type name: System.String
        :rtype: Microsoft.Extensions.Localization.LocalizedString
        :return: The string resource as a <see cref="T:Microsoft.Extensions.Localization.LocalizedString" />.
    
        
        .. code-block:: csharp
    
           public static LocalizedString GetString(IStringLocalizer stringLocalizer, string name)
    
    .. dn:method:: Microsoft.Extensions.Localization.StringLocalizerExtensions.GetString(Microsoft.Extensions.Localization.IStringLocalizer, System.String, System.Object[])
    
        
    
        Gets the string resource with the given name and formatted with the supplied arguments.
    
        
        
        
        :param stringLocalizer: The .
        
        :type stringLocalizer: Microsoft.Extensions.Localization.IStringLocalizer
        
        
        :param name: The name of the string resource.
        
        :type name: System.String
        
        
        :param arguments: The values to format the string with.
        
        :type arguments: System.Object[]
        :rtype: Microsoft.Extensions.Localization.LocalizedString
        :return: The formatted string resource as a <see cref="T:Microsoft.Extensions.Localization.LocalizedString" />.
    
        
        .. code-block:: csharp
    
           public static LocalizedString GetString(IStringLocalizer stringLocalizer, string name, params object[] arguments)
    

