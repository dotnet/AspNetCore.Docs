

HtmlLocalizer<TResource> Class
==============================



.. contents:: 
   :local:



Summary
-------

This is an :any:`Microsoft.AspNet.Mvc.Localization.HtmlLocalizer` that provides localized HTML content.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Localization.HtmlLocalizer\<TResource>`








Syntax
------

.. code-block:: csharp

   public class HtmlLocalizer<TResource> : IHtmlLocalizer<TResource>, IHtmlLocalizer, IStringLocalizer





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Localization/HtmlLocalizerOfT.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer<TResource>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer<TResource>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer<TResource>.HtmlLocalizer(Microsoft.AspNet.Mvc.Localization.IHtmlLocalizerFactory)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.Localization.HtmlLocalizer`\.
    
        
        
        
        :param factory: The .
        
        :type factory: Microsoft.AspNet.Mvc.Localization.IHtmlLocalizerFactory
    
        
        .. code-block:: csharp
    
           public HtmlLocalizer(IHtmlLocalizerFactory factory)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer<TResource>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer<TResource>.GetAllStrings(System.Boolean)
    
        
        
        
        :type includeAncestorCultures: System.Boolean
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.Extensions.Localization.LocalizedString}
    
        
        .. code-block:: csharp
    
           public virtual IEnumerable<LocalizedString> GetAllStrings(bool includeAncestorCultures)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer<TResource>.GetString(System.String)
    
        
        
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
           public virtual LocalizedString GetString(string key)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer<TResource>.GetString(System.String, System.Object[])
    
        
        
        
        :type key: System.String
        
        
        :type arguments: System.Object[]
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
           public virtual LocalizedString GetString(string key, params object[] arguments)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer<TResource>.Html(System.String)
    
        
        
        
        :type key: System.String
        :rtype: Microsoft.AspNet.Mvc.Localization.LocalizedHtmlString
    
        
        .. code-block:: csharp
    
           public virtual LocalizedHtmlString Html(string key)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer<TResource>.Html(System.String, System.Object[])
    
        
        
        
        :type key: System.String
        
        
        :type arguments: System.Object[]
        :rtype: Microsoft.AspNet.Mvc.Localization.LocalizedHtmlString
    
        
        .. code-block:: csharp
    
           public virtual LocalizedHtmlString Html(string key, params object[] arguments)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer<TResource>.Microsoft.Extensions.Localization.IStringLocalizer.WithCulture(System.Globalization.CultureInfo)
    
        
        
        
        :type culture: System.Globalization.CultureInfo
        :rtype: Microsoft.Extensions.Localization.IStringLocalizer
    
        
        .. code-block:: csharp
    
           IStringLocalizer IStringLocalizer.WithCulture(CultureInfo culture)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer<TResource>.WithCulture(System.Globalization.CultureInfo)
    
        
        
        
        :type culture: System.Globalization.CultureInfo
        :rtype: Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer
    
        
        .. code-block:: csharp
    
           public virtual IHtmlLocalizer WithCulture(CultureInfo culture)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer<TResource>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer<TResource>.Item[System.String]
    
        
        
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
           public virtual LocalizedString this[string key] { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Localization.HtmlLocalizer<TResource>.Item[System.String, System.Object[]]
    
        
        
        
        :type key: System.String
        
        
        :type arguments: System.Object[]
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
           public virtual LocalizedString this[string key, params object[] arguments] { get; }
    

