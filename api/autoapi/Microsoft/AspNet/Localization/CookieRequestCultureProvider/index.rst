

CookieRequestCultureProvider Class
==================================



.. contents:: 
   :local:



Summary
-------

Determines the culture information for a request via the value of a cookie.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Localization.RequestCultureProvider`
* :dn:cls:`Microsoft.AspNet.Localization.CookieRequestCultureProvider`








Syntax
------

.. code-block:: csharp

   public class CookieRequestCultureProvider : RequestCultureProvider, IRequestCultureProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/localization/src/Microsoft.AspNet.Localization/CookieRequestCultureProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Localization.CookieRequestCultureProvider

Methods
-------

.. dn:class:: Microsoft.AspNet.Localization.CookieRequestCultureProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Localization.CookieRequestCultureProvider.DetermineProviderCultureResult(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Localization.ProviderCultureResult}
    
        
        .. code-block:: csharp
    
           public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
    
    .. dn:method:: Microsoft.AspNet.Localization.CookieRequestCultureProvider.MakeCookieValue(Microsoft.AspNet.Localization.RequestCulture)
    
        
    
        Creates a string representation of a :any:`Microsoft.AspNet.Localization.RequestCulture` for placement in a cookie.
    
        
        
        
        :param requestCulture: The .
        
        :type requestCulture: Microsoft.AspNet.Localization.RequestCulture
        :rtype: System.String
        :return: The cookie value.
    
        
        .. code-block:: csharp
    
           public static string MakeCookieValue(RequestCulture requestCulture)
    
    .. dn:method:: Microsoft.AspNet.Localization.CookieRequestCultureProvider.ParseCookieValue(System.String)
    
        
    
        Parses a :any:`Microsoft.AspNet.Localization.RequestCulture` from the specified cookie value.
        Returns <c>null</c> if parsing fails.
    
        
        
        
        :param value: The cookie value to parse.
        
        :type value: System.String
        :rtype: Microsoft.AspNet.Localization.ProviderCultureResult
        :return: The <see cref="T:Microsoft.AspNet.Localization.RequestCulture" /> or <c>null</c> if parsing fails.
    
        
        .. code-block:: csharp
    
           public static ProviderCultureResult ParseCookieValue(string value)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Localization.CookieRequestCultureProvider
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Localization.CookieRequestCultureProvider.DefaultCookieName
    
        
    
        Represent the default cookie name used to track the user's preferred culture information, which is "ASPNET_CULTURE".
    
        
    
        
        .. code-block:: csharp
    
           public static readonly string DefaultCookieName
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Localization.CookieRequestCultureProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Localization.CookieRequestCultureProvider.CookieName
    
        
    
        The name of the cookie that contains the user's preferred culture information.
        Defaults to :dn:field:`Microsoft.AspNet.Localization.CookieRequestCultureProvider.DefaultCookieName`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string CookieName { get; set; }
    

