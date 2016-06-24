

HtmlLocalizerExtensions Class
=============================






Extension methods for :any:`Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Localization`
Assemblies
    * Microsoft.AspNetCore.Mvc.Localization

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizerExtensions`








Syntax
------

.. code-block:: csharp

    public class HtmlLocalizerExtensions








.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizerExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizerExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizerExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizerExtensions.GetAllStrings(Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer)
    
        
    
        
        Gets all string resources including those for parent cultures.
    
        
    
        
        :param htmlLocalizer: The :any:`Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer`\.
        
        :type htmlLocalizer: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.Localization.LocalizedString<Microsoft.Extensions.Localization.LocalizedString>}
        :return: The string resources.
    
        
        .. code-block:: csharp
    
            public static IEnumerable<LocalizedString> GetAllStrings(this IHtmlLocalizer htmlLocalizer)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizerExtensions.GetHtml(Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer, System.String)
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString` resource for a specific name.
    
        
    
        
        :param htmlLocalizer: The :any:`Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer`\.
        
        :type htmlLocalizer: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer
    
        
        :param name: The key to use.
        
        :type name: System.String
        :rtype: Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString
        :return: The :any:`Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString` resource.
    
        
        .. code-block:: csharp
    
            public static LocalizedHtmlString GetHtml(this IHtmlLocalizer htmlLocalizer, string name)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizerExtensions.GetHtml(Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer, System.String, System.Object[])
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString` resource for a specific name.
    
        
    
        
        :param htmlLocalizer: The :any:`Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer`\.
        
        :type htmlLocalizer: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer
    
        
        :param name: The key to use.
        
        :type name: System.String
    
        
        :param arguments: The values to format the string with.
        
        :type arguments: System.Object<System.Object>[]
        :rtype: Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString
        :return: The :any:`Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString` resource.
    
        
        .. code-block:: csharp
    
            public static LocalizedHtmlString GetHtml(this IHtmlLocalizer htmlLocalizer, string name, params object[] arguments)
    

