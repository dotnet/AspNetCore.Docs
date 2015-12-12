

CookieAuthenticationExtensions Class
====================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Owin.CookieAuthenticationExtensions`








Syntax
------

.. code-block:: csharp

   public class CookieAuthenticationExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.Owin.Security.Cookies.Interop/CookieAuthenticationExtensions.cs>`_





.. dn:class:: Owin.CookieAuthenticationExtensions

Methods
-------

.. dn:class:: Owin.CookieAuthenticationExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Owin.CookieAuthenticationExtensions.UseCookieAuthentication(Owin.IAppBuilder, Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions, Microsoft.AspNet.DataProtection.DataProtectionProvider, Owin.PipelineStage)
    
        
        
        
        :type app: Owin.IAppBuilder
        
        
        :type options: Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
        
        
        :type dataProtectionProvider: Microsoft.AspNet.DataProtection.DataProtectionProvider
        
        
        :type stage: Owin.PipelineStage
        :rtype: Owin.IAppBuilder
    
        
        .. code-block:: csharp
    
           public static IAppBuilder UseCookieAuthentication(IAppBuilder app, CookieAuthenticationOptions options, DataProtectionProvider dataProtectionProvider, PipelineStage stage = 0)
    

