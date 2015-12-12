

CookiePolicyOptions Class
=========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.CookiePolicy.CookiePolicyOptions`








Syntax
------

.. code-block:: csharp

   public class CookiePolicyOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.CookiePolicy/CookiePolicyOptions.cs>`_





.. dn:class:: Microsoft.AspNet.CookiePolicy.CookiePolicyOptions

Properties
----------

.. dn:class:: Microsoft.AspNet.CookiePolicy.CookiePolicyOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.CookiePolicy.CookiePolicyOptions.HttpOnly
    
        
        :rtype: Microsoft.AspNet.CookiePolicy.HttpOnlyPolicy
    
        
        .. code-block:: csharp
    
           public HttpOnlyPolicy HttpOnly { get; set; }
    
    .. dn:property:: Microsoft.AspNet.CookiePolicy.CookiePolicyOptions.OnAppendCookie
    
        
        :rtype: System.Action{Microsoft.AspNet.CookiePolicy.AppendCookieContext}
    
        
        .. code-block:: csharp
    
           public Action<AppendCookieContext> OnAppendCookie { get; set; }
    
    .. dn:property:: Microsoft.AspNet.CookiePolicy.CookiePolicyOptions.OnDeleteCookie
    
        
        :rtype: System.Action{Microsoft.AspNet.CookiePolicy.DeleteCookieContext}
    
        
        .. code-block:: csharp
    
           public Action<DeleteCookieContext> OnDeleteCookie { get; set; }
    
    .. dn:property:: Microsoft.AspNet.CookiePolicy.CookiePolicyOptions.Secure
    
        
        :rtype: Microsoft.AspNet.CookiePolicy.SecurePolicy
    
        
        .. code-block:: csharp
    
           public SecurePolicy Secure { get; set; }
    

