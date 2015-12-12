

ICookieAuthenticationEvents Interface
=====================================



.. contents:: 
   :local:



Summary
-------

Specifies callback methods which the :any:`Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationMiddleware` invokes to enable developer control over the authentication process. /&gt;











Syntax
------

.. code-block:: csharp

   public interface ICookieAuthenticationEvents





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.Cookies/Events/ICookieAuthenticationEvents.cs>`_





.. dn:interface:: Microsoft.AspNet.Authentication.Cookies.ICookieAuthenticationEvents

Methods
-------

.. dn:interface:: Microsoft.AspNet.Authentication.Cookies.ICookieAuthenticationEvents
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.ICookieAuthenticationEvents.RedirectToAccessDenied(Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext)
    
        
    
        Called when an access denied causes a redirect in the cookie middleware.
    
        
        
        
        :param context: Contains information about the event
        
        :type context: Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task RedirectToAccessDenied(CookieRedirectContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.ICookieAuthenticationEvents.RedirectToLogin(Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext)
    
        
    
        Called when a SignIn causes a redirect in the cookie middleware.
    
        
        
        
        :param context: Contains information about the event
        
        :type context: Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task RedirectToLogin(CookieRedirectContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.ICookieAuthenticationEvents.RedirectToLogout(Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext)
    
        
    
        Called when a SignOut causes a redirect in the cookie middleware.
    
        
        
        
        :param context: Contains information about the event
        
        :type context: Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task RedirectToLogout(CookieRedirectContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.ICookieAuthenticationEvents.RedirectToReturnUrl(Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext)
    
        
    
        Called when redirecting back to the return url in the cookie middleware.
    
        
        
        
        :param context: Contains information about the event
        
        :type context: Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task RedirectToReturnUrl(CookieRedirectContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.ICookieAuthenticationEvents.SignedIn(Microsoft.AspNet.Authentication.Cookies.CookieSignedInContext)
    
        
    
        Called when an endpoint has provided sign in information after it is converted into a cookie.
    
        
        
        
        :param context: Contains information about the login session as well as the user .
        
        :type context: Microsoft.AspNet.Authentication.Cookies.CookieSignedInContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task SignedIn(CookieSignedInContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.ICookieAuthenticationEvents.SigningIn(Microsoft.AspNet.Authentication.Cookies.CookieSigningInContext)
    
        
    
        Called when an endpoint has provided sign in information before it is converted into a cookie. By
        implementing this method the claims and extra information that go into the ticket may be altered.
    
        
        
        
        :param context: Contains information about the login session as well as the user .
        
        :type context: Microsoft.AspNet.Authentication.Cookies.CookieSigningInContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task SigningIn(CookieSigningInContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.ICookieAuthenticationEvents.SigningOut(Microsoft.AspNet.Authentication.Cookies.CookieSigningOutContext)
    
        
    
        Called during the sign-out flow to augment the cookie cleanup process.
    
        
        
        
        :param context: Contains information about the login session as well as information about the authentication cookie.
        
        :type context: Microsoft.AspNet.Authentication.Cookies.CookieSigningOutContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task SigningOut(CookieSigningOutContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.ICookieAuthenticationEvents.ValidatePrincipal(Microsoft.AspNet.Authentication.Cookies.CookieValidatePrincipalContext)
    
        
    
        Called each time a request principal has been validated by the middleware. By implementing this method the
        application may alter or reject the principal which has arrived with the request.
    
        
        
        
        :param context: Contains information about the login session as well as the user .
        
        :type context: Microsoft.AspNet.Authentication.Cookies.CookieValidatePrincipalContext
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> representing the completed operation.
    
        
        .. code-block:: csharp
    
           Task ValidatePrincipal(CookieValidatePrincipalContext context)
    

