

HtmlLocalizer<TResource> Class
==============================






An :any:`Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer` implementation that provides localized HTML content for the specified type
<em>TResource</em>.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer\<TResource>`








Syntax
------

.. code-block:: csharp

    public class HtmlLocalizer<TResource> : IHtmlLocalizer<TResource>, IHtmlLocalizer








.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer<TResource>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer<TResource>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer<TResource>.HtmlLocalizer(Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizerFactory)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer\`1`\.
    
        
    
        
        :param factory: The :any:`Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizerFactory`\.
        
        :type factory: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizerFactory
    
        
        .. code-block:: csharp
    
            public HtmlLocalizer(IHtmlLocalizerFactory factory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer<TResource>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer<TResource>.GetAllStrings(System.Boolean)
    
        
    
        
        :type includeParentCultures: System.Boolean
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.Localization.LocalizedString<Microsoft.Extensions.Localization.LocalizedString>}
    
        
        .. code-block:: csharp
    
            public virtual IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer<TResource>.GetString(System.String)
    
        
    
        
        :type name: System.String
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
            public virtual LocalizedString GetString(string name)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer<TResource>.GetString(System.String, System.Object[])
    
        
    
        
        :type name: System.String
    
        
        :type arguments: System.Object<System.Object>[]
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
            public virtual LocalizedString GetString(string name, params object[] arguments)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer<TResource>.WithCulture(System.Globalization.CultureInfo)
    
        
    
        
        :type culture: System.Globalization.CultureInfo
        :rtype: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer
    
        
        .. code-block:: csharp
    
            public virtual IHtmlLocalizer WithCulture(CultureInfo culture)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer<TResource>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer<TResource>.Item[System.String]
    
        
    
        
        :type name: System.String
        :rtype: Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString
    
        
        .. code-block:: csharp
    
            public virtual LocalizedHtmlString this[string name] { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Localization.HtmlLocalizer<TResource>.Item[System.String, System.Object[]]
    
        
    
        
        :type name: System.String
    
        
        :type arguments: System.Object<System.Object>[]
        :rtype: Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString
    
        
        .. code-block:: csharp
    
            public virtual LocalizedHtmlString this[string name, params object[] arguments] { get; }
    

