

ViewLocalizer Class
===================






An :any:`Microsoft.AspNetCore.Mvc.Localization.IViewLocalizer` implementation that derives the resource location from the executing view's
file path.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Localization.ViewLocalizer`








Syntax
------

.. code-block:: csharp

    public class ViewLocalizer : IViewLocalizer, IHtmlLocalizer, IViewContextAware








.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.ViewLocalizer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.ViewLocalizer

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.ViewLocalizer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Localization.ViewLocalizer.Item[System.String]
    
        
    
        
        :type key: System.String
        :rtype: Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString
    
        
        .. code-block:: csharp
    
            public virtual LocalizedHtmlString this[string key]
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Localization.ViewLocalizer.Item[System.String, System.Object[]]
    
        
    
        
        :type key: System.String
    
        
        :type arguments: System.Object<System.Object>[]
        :rtype: Microsoft.AspNetCore.Mvc.Localization.LocalizedHtmlString
    
        
        .. code-block:: csharp
    
            public virtual LocalizedHtmlString this[string key, params object[] arguments]
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.ViewLocalizer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Localization.ViewLocalizer.ViewLocalizer(Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizerFactory, Microsoft.AspNetCore.Hosting.IHostingEnvironment)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Localization.ViewLocalizer`\.
    
        
    
        
        :param localizerFactory: The :any:`Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizerFactory`\.
        
        :type localizerFactory: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizerFactory
    
        
        :param hostingEnvironment: The :any:`Microsoft.AspNetCore.Hosting.IHostingEnvironment`\.
        
        :type hostingEnvironment: Microsoft.AspNetCore.Hosting.IHostingEnvironment
    
        
        .. code-block:: csharp
    
            public ViewLocalizer(IHtmlLocalizerFactory localizerFactory, IHostingEnvironment hostingEnvironment)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Localization.ViewLocalizer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.ViewLocalizer.Contextualize(Microsoft.AspNetCore.Mvc.Rendering.ViewContext)
    
        
    
        
        Apply the specified :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext`\.
    
        
    
        
        :param viewContext: The :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext`\.
        
        :type viewContext: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
            public void Contextualize(ViewContext viewContext)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.ViewLocalizer.GetAllStrings(System.Boolean)
    
        
    
        
        :type includeParentCultures: System.Boolean
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.Localization.LocalizedString<Microsoft.Extensions.Localization.LocalizedString>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.ViewLocalizer.GetString(System.String)
    
        
    
        
        :type name: System.String
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
            public LocalizedString GetString(string name)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.ViewLocalizer.GetString(System.String, System.Object[])
    
        
    
        
        :type name: System.String
    
        
        :type values: System.Object<System.Object>[]
        :rtype: Microsoft.Extensions.Localization.LocalizedString
    
        
        .. code-block:: csharp
    
            public LocalizedString GetString(string name, params object[] values)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Localization.ViewLocalizer.WithCulture(System.Globalization.CultureInfo)
    
        
    
        
        :type culture: System.Globalization.CultureInfo
        :rtype: Microsoft.AspNetCore.Mvc.Localization.IHtmlLocalizer
    
        
        .. code-block:: csharp
    
            public IHtmlLocalizer WithCulture(CultureInfo culture)
    

