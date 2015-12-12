

HtmlLocalizer Class
===================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer` that uses the :any:`Microsoft.Extensions.Localization.IStringLocalizer` to provide localized HTML content.
This service just encodes the arguments but not the resource string.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Localization.HtmlLocalizer`








Syntax
------

.. code-block:: csharp

   public class HtmlLocalizer : IHtmlLocalizer, IStringLocalizer





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Localization/HtmlLocalizer.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer.HtmlLocalizer(Microsoft.Extensions.Localization.IStringLocalizer, Microsoft.Extensions.WebEncoders.IHtmlEncoder)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.Localization.HtmlLocalizer`\.
    
        
        
        
        :param localizer: The  to read strings from.
        
        :type localizer: Microsoft.Extensions.Localization.IStringLocalizer
        
        
        :param encoder: The .
        
        :type encoder: Microsoft.Extensions.WebEncoders.IHtmlEncoder
    
        
        .. code-block:: csharp
    
           public HtmlLocalizer(IStringLocalizer localizer, IHtmlEncoder encoder)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer.EncodeArguments(System.String, System.Object[])
    
        
    
        Encodes the arguments based on the object type.
    
        
        
        
        :param resourceString: The resourceString whose arguments need to be encoded.
        
        :type resourceString: System.String
        
        
        :param arguments: The array of objects to encode.
        
        :type arguments: System.Object[]
        :rtype: System.String
        :return: The string with encoded arguments.
    
        
        .. code-block:: csharp
    
           protected virtual string EncodeArguments(string resourceString, object[] arguments)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer.GetAllStrings(System.Boolean)
    
        
        
        
        :type includeAncestorCultures: System.Boolean
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.Extensions.Localization.LocalizedString}
    
        
        .. code-block:: csharp
    
           public virtual IEnumerable<LocalizedString> GetAllStrings(bool includeAncestorCultures)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer.GetString(System.String)
    
        
        
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
           public virtual LocalizedString GetString(string key)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer.GetString(System.String, System.Object[])
    
        
        
        
        :type key: System.String
        
        
        :type arguments: System.Object[]
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
           public virtual LocalizedString GetString(string key, params object[] arguments)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer.Html(System.String)
    
        
        
        
        :type key: System.String
        :rtype: Microsoft.AspNet.Mvc.Localization.LocalizedHtmlString
    
        
        .. code-block:: csharp
    
           public virtual LocalizedHtmlString Html(string key)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer.Html(System.String, System.Object[])
    
        
        
        
        :type key: System.String
        
        
        :type arguments: System.Object[]
        :rtype: Microsoft.AspNet.Mvc.Localization.LocalizedHtmlString
    
        
        .. code-block:: csharp
    
           public virtual LocalizedHtmlString Html(string key, params object[] arguments)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer.Microsoft.Extensions.Localization.IStringLocalizer.WithCulture(System.Globalization.CultureInfo)
    
        
    
        Creates a new :any:`Microsoft.Extensions.Localization.IStringLocalizer` for a specific :any:`System.Globalization.CultureInfo`\.
    
        
        
        
        :param culture: The  to use.
        
        :type culture: System.Globalization.CultureInfo
        :rtype: Microsoft.Extensions.Localization.IStringLocalizer
        :return: A culture-specific <see cref="T:Microsoft.Extensions.Localization.IStringLocalizer" />.
    
        
        .. code-block:: csharp
    
           IStringLocalizer IStringLocalizer.WithCulture(CultureInfo culture)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer.ToHtmlString(Microsoft.Extensions.Localization.LocalizedString)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.Localization.LocalizedHtmlString` for a :any:`Microsoft.Extensions.Localization.LocalizedString`\.
    
        
        
        
        :param result: The .
        
        :type result: Microsoft.Extensions.Localization.LocalizedString
        :rtype: Microsoft.AspNet.Mvc.Localization.LocalizedHtmlString
    
        
        .. code-block:: csharp
    
           protected virtual LocalizedHtmlString ToHtmlString(LocalizedString result)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer.WithCulture(System.Globalization.CultureInfo)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer` for a specific :any:`System.Globalization.CultureInfo`\.
    
        
        
        
        :param culture: The  to use.
        
        :type culture: System.Globalization.CultureInfo
        :rtype: Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer
        :return: A culture-specific <see cref="T:Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer" />.
    
        
        .. code-block:: csharp
    
           public virtual IHtmlLocalizer WithCulture(CultureInfo culture)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer.Item[System.String]
    
        
        
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
           public virtual LocalizedString this[string key] { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer.Item[System.String, System.Object[]]
    
        
        
        
        :type key: System.String
        
        
        :type arguments: System.Object[]
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
           public virtual LocalizedString this[string key, params object[] arguments] { get; }
    

