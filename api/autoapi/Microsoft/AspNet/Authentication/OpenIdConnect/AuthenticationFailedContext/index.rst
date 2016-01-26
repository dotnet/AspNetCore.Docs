

AuthenticationFailedContext Class
=================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseControlContext`
* :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.BaseOpenIdConnectContext`
* :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.AuthenticationFailedContext`








Syntax
------

.. code-block:: csharp

   public class AuthenticationFailedContext : BaseOpenIdConnectContext





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.OpenIdConnect/Events/AuthenticationFailedContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.AuthenticationFailedContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.AuthenticationFailedContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.OpenIdConnect.AuthenticationFailedContext.AuthenticationFailedContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type options: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions
    
        
        .. code-block:: csharp
    
           public AuthenticationFailedContext(HttpContext context, OpenIdConnectOptions options)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.AuthenticationFailedContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.AuthenticationFailedContext.Exception
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
           public Exception Exception { get; set; }
    

