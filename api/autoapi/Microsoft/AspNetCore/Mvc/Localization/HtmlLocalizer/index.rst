

HtmlLocalizer Class
===================






An :any:`Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer` that uses the provided :any:`Microsoft.Extensions.Localization.IStringLocalizer` to do HTML-aware
localization of content.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer`








Syntax
------

.. code-block:: csharp

    public class HtmlLocalizer : IHtmlLocalizer








.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer.Item[System.String]
    
        
    
        
        :type name: System.String
        :rtype: Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString
    
        
        .. code-block:: csharp
    
            public virtual LocalizedHtmlString this[string name]
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer.Item[System.String, System.Object[]]
    
        
    
        
        :type name: System.String
    
        
        :type arguments: System.Object<System.Object>[]
        :rtype: Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString
    
        
        .. code-block:: csharp
    
            public virtual LocalizedHtmlString this[string name, params object[] arguments]
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer.HtmlLocalizer(Microsoft.Extensions.Localization.IStringLocalizer)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer`\.
    
        
    
        
        :param localizer: The :any:`Microsoft.Extensions.Localization.IStringLocalizer` to read strings from.
        
        :type localizer: Microsoft.Extensions.Localization.IStringLocalizer
    
        
        .. code-block:: csharp
    
            public HtmlLocalizer(IStringLocalizer localizer)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer.GetAllStrings(System.Boolean)
    
        
    
        
        :type includeParentCultures: System.Boolean
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.Localization.LocalizedString<Microsoft.Extensions.Localization.LocalizedString>}
    
        
        .. code-block:: csharp
    
            public virtual IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer.GetString(System.String)
    
        
    
        
        :type name: System.String
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
            public virtual LocalizedString GetString(string name)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer.GetString(System.String, System.Object[])
    
        
    
        
        :type name: System.String
    
        
        :type arguments: System.Object<System.Object>[]
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
            public virtual LocalizedString GetString(string name, params object[] arguments)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer.ToHtmlString(Microsoft.Extensions.Localization.LocalizedString)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString` for a :any:`Microsoft.Extensions.Localization.LocalizedString`\.
    
        
    
        
        :param result: The :any:`Microsoft.Extensions.Localization.LocalizedString`\.
        
        :type result: Microsoft.Extensions.Localization.LocalizedString
        :rtype: Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString
    
        
        .. code-block:: csharp
    
            protected virtual LocalizedHtmlString ToHtmlString(LocalizedString result)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer.ToHtmlString(Microsoft.Extensions.Localization.LocalizedString, System.Object[])
    
        
    
        
        :type result: Microsoft.Extensions.Localization.LocalizedString
    
        
        :type arguments: System.Object<System.Object>[]
        :rtype: Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString
    
        
        .. code-block:: csharp
    
            protected virtual LocalizedHtmlString ToHtmlString(LocalizedString result, object[] arguments)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer.WithCulture(System.Globalization.CultureInfo)
    
        
    
        
        :type culture: System.Globalization.CultureInfo
        :rtype: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer
    
        
        .. code-block:: csharp
    
            public virtual IHtmlLocalizer WithCulture(CultureInfo culture)
    

