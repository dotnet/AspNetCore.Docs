

CookiePolicyOptions Class
=========================






Provides programmatic configuration for the :any:`Microsoft.AspNetCore.CookiePolicy.CookiePolicyMiddleware`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.CookiePolicy

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.CookiePolicyOptions`








Syntax
------

.. code-block:: csharp

    public class CookiePolicyOptions








.. dn:class:: Microsoft.AspNetCore.Builder.CookiePolicyOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.CookiePolicyOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.CookiePolicyOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.CookiePolicyOptions.HttpOnly
    
        
    
        
        Affects whether cookies must be HttpOnly.
    
        
        :rtype: Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy
    
        
        .. code-block:: csharp
    
            public HttpOnlyPolicy HttpOnly
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.CookiePolicyOptions.OnAppendCookie
    
        
    
        
        Called when a cookie is appended.
    
        
        :rtype: System.Action<System.Action`1>{Microsoft.AspNetCore.CookiePolicy.AppendCookieContext<Microsoft.AspNetCore.CookiePolicy.AppendCookieContext>}
    
        
        .. code-block:: csharp
    
            public Action<AppendCookieContext> OnAppendCookie
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.CookiePolicyOptions.OnDeleteCookie
    
        
    
        
        Called when a cookie is deleted.
    
        
        :rtype: System.Action<System.Action`1>{Microsoft.AspNetCore.CookiePolicy.DeleteCookieContext<Microsoft.AspNetCore.CookiePolicy.DeleteCookieContext>}
    
        
        .. code-block:: csharp
    
            public Action<DeleteCookieContext> OnDeleteCookie
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.CookiePolicyOptions.Secure
    
        
    
        
        Affects whether cookies must be Secure.
    
        
        :rtype: Microsoft.AspNetCore.CookiePolicy.SecurePolicy
    
        
        .. code-block:: csharp
    
            public SecurePolicy Secure
            {
                get;
                set;
            }
    

