

RequestLocalizationOptions Class
================================



.. contents:: 
   :local:



Summary
-------

Specifies options for the :any:`Microsoft.AspNet.Localization.RequestLocalizationMiddleware`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Localization.RequestLocalizationOptions`








Syntax
------

.. code-block:: csharp

   public class RequestLocalizationOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/localization/blob/master/src/Microsoft.AspNet.Localization/RequestLocalizationOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Localization.RequestLocalizationOptions

Constructors
------------

.. dn:class:: Microsoft.AspNet.Localization.RequestLocalizationOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Localization.RequestLocalizationOptions.RequestLocalizationOptions()
    
        
    
        Creates a new :any:`Microsoft.AspNet.Localization.RequestLocalizationOptions` with default values.
    
        
    
        
        .. code-block:: csharp
    
           public RequestLocalizationOptions()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Localization.RequestLocalizationOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Localization.RequestLocalizationOptions.RequestCultureProviders
    
        
    
        An ordered list of providers used to determine a request's culture information. The first provider that
        returns a non-<c>null</c> result for a given request will be used.
        Defaults to the following:
        <list type="number"><item><description> :any:`Microsoft.AspNet.Localization.QueryStringRequestCultureProvider`\</description></item><item><description> :any:`Microsoft.AspNet.Localization.CookieRequestCultureProvider`\</description></item><item><description> :any:`Microsoft.AspNet.Localization.AcceptLanguageHeaderRequestCultureProvider`\</description></item></list>
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Localization.IRequestCultureProvider}
    
        
        .. code-block:: csharp
    
           public IList<IRequestCultureProvider> RequestCultureProviders { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Localization.RequestLocalizationOptions.SupportedCultures
    
        
    
        The cultures supported by the application. If this value is non-<c>null</c>, the 
        :any:`Microsoft.AspNet.Localization.RequestLocalizationMiddleware` will only set the current request culture to an entry in this
        list. A value of <c>null</c> means all cultures are supported.
        Defaults to <c>null</c>.
    
        
        :rtype: System.Collections.Generic.IList{System.Globalization.CultureInfo}
    
        
        .. code-block:: csharp
    
           public IList<CultureInfo> SupportedCultures { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Localization.RequestLocalizationOptions.SupportedUICultures
    
        
    
        The UI cultures supported by the application. If this value is non-<c>null</c>, the 
        :any:`Microsoft.AspNet.Localization.RequestLocalizationMiddleware` will only set the current request culture to an entry in this
        list. A value of <c>null</c> means all cultures are supported.
        Defaults to <c>null</c>.
    
        
        :rtype: System.Collections.Generic.IList{System.Globalization.CultureInfo}
    
        
        .. code-block:: csharp
    
           public IList<CultureInfo> SupportedUICultures { get; set; }
    

