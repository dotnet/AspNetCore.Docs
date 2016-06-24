

CookieRequestCultureProvider Class
==================================






Determines the culture information for a request via the value of a cookie.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Localization`
Assemblies
    * Microsoft.AspNetCore.Localization

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Localization.RequestCultureProvider`
* :dn:cls:`Microsoft.AspNetCore.Localization.CookieRequestCultureProvider`








Syntax
------

.. code-block:: csharp

    public class CookieRequestCultureProvider : RequestCultureProvider, IRequestCultureProvider








.. dn:class:: Microsoft.AspNetCore.Localization.CookieRequestCultureProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Localization.CookieRequestCultureProvider

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Localization.CookieRequestCultureProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Localization.CookieRequestCultureProvider.DetermineProviderCultureResult(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Localization.ProviderCultureResult<Microsoft.AspNetCore.Localization.ProviderCultureResult>}
    
        
        .. code-block:: csharp
    
            public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
    
    .. dn:method:: Microsoft.AspNetCore.Localization.CookieRequestCultureProvider.MakeCookieValue(Microsoft.AspNetCore.Localization.RequestCulture)
    
        
    
        
        Creates a string representation of a :any:`Microsoft.AspNetCore.Localization.RequestCulture` for placement in a cookie.
    
        
    
        
        :param requestCulture: The :any:`Microsoft.AspNetCore.Localization.RequestCulture`\.
        
        :type requestCulture: Microsoft.AspNetCore.Localization.RequestCulture
        :rtype: System.String
        :return: The cookie value.
    
        
        .. code-block:: csharp
    
            public static string MakeCookieValue(RequestCulture requestCulture)
    
    .. dn:method:: Microsoft.AspNetCore.Localization.CookieRequestCultureProvider.ParseCookieValue(System.String)
    
        
    
        
        Parses a :any:`Microsoft.AspNetCore.Localization.RequestCulture` from the specified cookie value.
        Returns <code>null</code> if parsing fails.
    
        
    
        
        :param value: The cookie value to parse.
        
        :type value: System.String
        :rtype: Microsoft.AspNetCore.Localization.ProviderCultureResult
        :return: The :any:`Microsoft.AspNetCore.Localization.RequestCulture` or <code>null</code> if parsing fails.
    
        
        .. code-block:: csharp
    
            public static ProviderCultureResult ParseCookieValue(string value)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Localization.CookieRequestCultureProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Localization.CookieRequestCultureProvider.CookieName
    
        
    
        
        The name of the cookie that contains the user's preferred culture information.
        Defaults to :dn:field:`Microsoft.AspNetCore.Localization.CookieRequestCultureProvider.DefaultCookieName`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string CookieName { get; set; }
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Localization.CookieRequestCultureProvider
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Localization.CookieRequestCultureProvider.DefaultCookieName
    
        
    
        
        Represent the default cookie name used to track the user's preferred culture information, which is ".AspNetCore.Culture".
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string DefaultCookieName
    

