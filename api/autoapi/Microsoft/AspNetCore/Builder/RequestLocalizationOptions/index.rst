

RequestLocalizationOptions Class
================================






Specifies options for the :any:`Microsoft.AspNetCore.Localization.RequestLocalizationMiddleware`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Localization

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.RequestLocalizationOptions`








Syntax
------

.. code-block:: csharp

    public class RequestLocalizationOptions








.. dn:class:: Microsoft.AspNetCore.Builder.RequestLocalizationOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.RequestLocalizationOptions

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Builder.RequestLocalizationOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Builder.RequestLocalizationOptions.RequestLocalizationOptions()
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Builder.RequestLocalizationOptions` with default values.
    
        
    
        
        .. code-block:: csharp
    
            public RequestLocalizationOptions()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.RequestLocalizationOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.RequestLocalizationOptions.DefaultRequestCulture
    
        
    
        
        Gets or sets the default culture to use for requests when a supported culture could not be determined by
        one of the configured :any:`Microsoft.AspNetCore.Localization.IRequestCultureProvider`\s.
        Defaults to :dn:prop:`System.Globalization.CultureInfo.CurrentCulture` and :dn:prop:`System.Globalization.CultureInfo.CurrentUICulture`\.
    
        
        :rtype: Microsoft.AspNetCore.Localization.RequestCulture
    
        
        .. code-block:: csharp
    
            public RequestCulture DefaultRequestCulture { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.RequestLocalizationOptions.FallBackToParentCultures
    
        
    
        
        Gets or sets a value indicating whether to set a request culture to an parent culture in the case the
        culture determined by the configured :any:`Microsoft.AspNetCore.Localization.IRequestCultureProvider`\s is not in the 
        :dn:prop:`Microsoft.AspNetCore.Builder.RequestLocalizationOptions.SupportedCultures` list but a parent culture is.
        Defaults to <code>true</code>;
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool FallBackToParentCultures { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.RequestLocalizationOptions.FallBackToParentUICultures
    
        
    
        
        Gets or sets a value indicating whether to set a request UI culture to a parent culture in the case the
        UI culture determined by the configured :any:`Microsoft.AspNetCore.Localization.IRequestCultureProvider`\s is not in the 
        :dn:prop:`Microsoft.AspNetCore.Builder.RequestLocalizationOptions.SupportedUICultures` list but a parent culture is.
        Defaults to <code>true</code>;
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool FallBackToParentUICultures { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.RequestLocalizationOptions.RequestCultureProviders
    
        
    
        
        An ordered list of providers used to determine a request's culture information. The first provider that
        returns a non-<code>null</code> result for a given request will be used.
        Defaults to the following:
        <ol><li> :any:`Microsoft.AspNetCore.Localization.QueryStringRequestCultureProvider`\</li><li> :any:`Microsoft.AspNetCore.Localization.CookieRequestCultureProvider`\</li><li> :any:`Microsoft.AspNetCore.Localization.AcceptLanguageHeaderRequestCultureProvider`\</li></ol>
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Localization.IRequestCultureProvider<Microsoft.AspNetCore.Localization.IRequestCultureProvider>}
    
        
        .. code-block:: csharp
    
            public IList<IRequestCultureProvider> RequestCultureProviders { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.RequestLocalizationOptions.SupportedCultures
    
        
    
        
        The cultures supported by the application. The :any:`Microsoft.AspNetCore.Localization.RequestLocalizationMiddleware` will only set
        the current request culture to an entry in this list.
        Defaults to :dn:prop:`System.Globalization.CultureInfo.CurrentCulture`\.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.Globalization.CultureInfo<System.Globalization.CultureInfo>}
    
        
        .. code-block:: csharp
    
            public IList<CultureInfo> SupportedCultures { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.RequestLocalizationOptions.SupportedUICultures
    
        
    
        
        The UI cultures supported by the application. The :any:`Microsoft.AspNetCore.Localization.RequestLocalizationMiddleware` will only set
        the current request culture to an entry in this list.
        Defaults to :dn:prop:`System.Globalization.CultureInfo.CurrentUICulture`\.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.Globalization.CultureInfo<System.Globalization.CultureInfo>}
    
        
        .. code-block:: csharp
    
            public IList<CultureInfo> SupportedUICultures { get; set; }
    

