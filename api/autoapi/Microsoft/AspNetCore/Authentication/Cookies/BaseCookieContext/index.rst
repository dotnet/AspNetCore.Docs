

BaseCookieContext Class
=======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.Cookies`
Assemblies
    * Microsoft.AspNetCore.Authentication.Cookies

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.Cookies.BaseCookieContext`








Syntax
------

.. code-block:: csharp

    public class BaseCookieContext : BaseContext








.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.BaseCookieContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.BaseCookieContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.BaseCookieContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Cookies.BaseCookieContext.Options
    
        
        :rtype: Microsoft.AspNetCore.Builder.CookieAuthenticationOptions
    
        
        .. code-block:: csharp
    
            public CookieAuthenticationOptions Options
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.BaseCookieContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.Cookies.BaseCookieContext.BaseCookieContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.CookieAuthenticationOptions)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type options: Microsoft.AspNetCore.Builder.CookieAuthenticationOptions
    
        
        .. code-block:: csharp
    
            public BaseCookieContext(HttpContext context, CookieAuthenticationOptions options)
    

