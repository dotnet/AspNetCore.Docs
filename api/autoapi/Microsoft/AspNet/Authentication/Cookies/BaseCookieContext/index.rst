

BaseCookieContext Class
=======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNet.Authentication.Cookies.BaseCookieContext`








Syntax
------

.. code-block:: csharp

   public class BaseCookieContext : BaseContext





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.Cookies/Events/BaseCookieContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.Cookies.BaseCookieContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.Cookies.BaseCookieContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.Cookies.BaseCookieContext.BaseCookieContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type options: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions
    
        
        .. code-block:: csharp
    
           public BaseCookieContext(HttpContext context, CookieAuthenticationOptions options)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.Cookies.BaseCookieContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.BaseCookieContext.Options
    
        
        :rtype: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions
    
        
        .. code-block:: csharp
    
           public CookieAuthenticationOptions Options { get; }
    

