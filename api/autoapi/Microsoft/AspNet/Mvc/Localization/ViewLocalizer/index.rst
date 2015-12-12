

ViewLocalizer Class
===================



.. contents:: 
   :local:



Summary
-------

A :any:`Microsoft.AspNet.Mvc.Localization.HtmlLocalizer` that provides localized strings for views.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Localization.ViewLocalizer`








Syntax
------

.. code-block:: csharp

   public class ViewLocalizer : IViewLocalizer, IHtmlLocalizer, IStringLocalizer, ICanHasViewContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Localization/ViewLocalizer.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Localization.ViewLocalizer

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Localization.ViewLocalizer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Localization.ViewLocalizer.ViewLocalizer(Microsoft.AspNet.Mvc.Localization.IHtmlLocalizerFactory, Microsoft.Extensions.PlatformAbstractions.IApplicationEnvironment)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.Localization.ViewLocalizer`\.
    
        
        
        
        :param localizerFactory: The .
        
        :type localizerFactory: Microsoft.AspNet.Mvc.Localization.IHtmlLocalizerFactory
        
        
        :param applicationEnvironment: The .
        
        :type applicationEnvironment: Microsoft.Extensions.PlatformAbstractions.IApplicationEnvironment
    
        
        .. code-block:: csharp
    
           public ViewLocalizer(IHtmlLocalizerFactory localizerFactory, IApplicationEnvironment applicationEnvironment)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Localization.ViewLocalizer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.ViewLocalizer.Contextualize(Microsoft.AspNet.Mvc.Rendering.ViewContext)
    
        
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           public void Contextualize(ViewContext viewContext)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.ViewLocalizer.GetAllStrings(System.Boolean)
    
        
        
        
        :type includeAncestorCultures: System.Boolean
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.Extensions.Localization.LocalizedString}
    
        
        .. code-block:: csharp
    
           public IEnumerable<LocalizedString> GetAllStrings(bool includeAncestorCultures)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.ViewLocalizer.GetString(System.String)
    
        
        
        
        :type name: System.String
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
           public LocalizedString GetString(string name)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.ViewLocalizer.GetString(System.String, System.Object[])
    
        
        
        
        :type name: System.String
        
        
        :type values: System.Object[]
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
           public LocalizedString GetString(string name, params object[] values)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.ViewLocalizer.Html(System.String)
    
        
        
        
        :type key: System.String
        :rtype: Microsoft.AspNet.Mvc.Localization.LocalizedHtmlString
    
        
        .. code-block:: csharp
    
           public LocalizedHtmlString Html(string key)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.ViewLocalizer.Html(System.String, System.Object[])
    
        
        
        
        :type key: System.String
        
        
        :type arguments: System.Object[]
        :rtype: Microsoft.AspNet.Mvc.Localization.LocalizedHtmlString
    
        
        .. code-block:: csharp
    
           public LocalizedHtmlString Html(string key, params object[] arguments)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.ViewLocalizer.Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer.WithCulture(System.Globalization.CultureInfo)
    
        
        
        
        :type culture: System.Globalization.CultureInfo
        :rtype: Microsoft.AspNet.Mvc.Localization.IHtmlLocalizer
    
        
        .. code-block:: csharp
    
           IHtmlLocalizer IHtmlLocalizer.WithCulture(CultureInfo culture)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Localization.ViewLocalizer.WithCulture(System.Globalization.CultureInfo)
    
        
        
        
        :type culture: System.Globalization.CultureInfo
        :rtype: Microsoft.Extensions.Localization.IStringLocalizer
    
        
        .. code-block:: csharp
    
           public IStringLocalizer WithCulture(CultureInfo culture)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Localization.ViewLocalizer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Localization.ViewLocalizer.Item[System.String]
    
        
        
        
        :type key: System.String
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
           public virtual LocalizedString this[string key] { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Localization.ViewLocalizer.Item[System.String, System.Object[]]
    
        
        
        
        :type key: System.String
        
        
        :type arguments: System.Object[]
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
           public virtual LocalizedString this[string key, params object[] arguments] { get; }
    

