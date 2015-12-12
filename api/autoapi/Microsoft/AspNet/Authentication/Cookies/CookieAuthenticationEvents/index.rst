

CookieAuthenticationEvents Class
================================



.. contents:: 
   :local:



Summary
-------

This default implementation of the ICookieAuthenticationEvents may be used if the
application only needs to override a few of the interface methods. This may be used as a base class
or may be instantiated directly.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationEvents`








Syntax
------

.. code-block:: csharp

   public class CookieAuthenticationEvents : ICookieAuthenticationEvents





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.Cookies/Events/CookieAuthenticationEvents.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationEvents

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationEvents
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationEvents.RedirectToAccessDenied(Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext)
    
        
    
        Implements the interface method by invoking the related delegate method.
    
        
        
        
        :param context: Contains information about the event
        
        :type context: Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task RedirectToAccessDenied(CookieRedirectContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationEvents.RedirectToLogin(Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext)
    
        
    
        Implements the interface method by invoking the related delegate method.
    
        
        
        
        :param context: Contains information about the event
        
        :type context: Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task RedirectToLogin(CookieRedirectContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationEvents.RedirectToLogout(Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext)
    
        
    
        Implements the interface method by invoking the related delegate method.
    
        
        
        
        :param context: Contains information about the event
        
        :type context: Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task RedirectToLogout(CookieRedirectContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationEvents.RedirectToReturnUrl(Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext)
    
        
    
        Implements the interface method by invoking the related delegate method.
    
        
        
        
        :param context: Contains information about the event
        
        :type context: Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task RedirectToReturnUrl(CookieRedirectContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationEvents.SignedIn(Microsoft.AspNet.Authentication.Cookies.CookieSignedInContext)
    
        
    
        Implements the interface method by invoking the related delegate method.
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.Cookies.CookieSignedInContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task SignedIn(CookieSignedInContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationEvents.SigningIn(Microsoft.AspNet.Authentication.Cookies.CookieSigningInContext)
    
        
    
        Implements the interface method by invoking the related delegate method.
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.Cookies.CookieSigningInContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task SigningIn(CookieSigningInContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationEvents.SigningOut(Microsoft.AspNet.Authentication.Cookies.CookieSigningOutContext)
    
        
    
        Implements the interface method by invoking the related delegate method.
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.Cookies.CookieSigningOutContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task SigningOut(CookieSigningOutContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationEvents.ValidatePrincipal(Microsoft.AspNet.Authentication.Cookies.CookieValidatePrincipalContext)
    
        
    
        Implements the interface method by invoking the related delegate method.
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.Cookies.CookieValidatePrincipalContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task ValidatePrincipal(CookieValidatePrincipalContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationEvents
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationEvents.OnRedirectToAccessDenied
    
        
    
        A delegate assigned to this property will be invoked when the related method is called.
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<CookieRedirectContext, Task> OnRedirectToAccessDenied { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationEvents.OnRedirectToLogin
    
        
    
        A delegate assigned to this property will be invoked when the related method is called.
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<CookieRedirectContext, Task> OnRedirectToLogin { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationEvents.OnRedirectToLogout
    
        
    
        A delegate assigned to this property will be invoked when the related method is called.
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<CookieRedirectContext, Task> OnRedirectToLogout { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationEvents.OnRedirectToReturnUrl
    
        
    
        A delegate assigned to this property will be invoked when the related method is called.
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<CookieRedirectContext, Task> OnRedirectToReturnUrl { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationEvents.OnSignedIn
    
        
    
        A delegate assigned to this property will be invoked when the related method is called.
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.Cookies.CookieSignedInContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<CookieSignedInContext, Task> OnSignedIn { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationEvents.OnSigningIn
    
        
    
        A delegate assigned to this property will be invoked when the related method is called.
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.Cookies.CookieSigningInContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<CookieSigningInContext, Task> OnSigningIn { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationEvents.OnSigningOut
    
        
    
        A delegate assigned to this property will be invoked when the related method is called.
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.Cookies.CookieSigningOutContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<CookieSigningOutContext, Task> OnSigningOut { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationEvents.OnValidatePrincipal
    
        
    
        A delegate assigned to this property will be invoked when the related method is called.
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.Cookies.CookieValidatePrincipalContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<CookieValidatePrincipalContext, Task> OnValidatePrincipal { get; set; }
    

