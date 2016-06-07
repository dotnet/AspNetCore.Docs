

CookieAuthenticationEvents Class
================================






This default implementation of the ICookieAuthenticationEvents may be used if the 
application only needs to override a few of the interface methods. This may be used as a base class
or may be instantiated directly.


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
* :dn:cls:`Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents`








Syntax
------

.. code-block:: csharp

    public class CookieAuthenticationEvents : ICookieAuthenticationEvents








.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.OnRedirectToAccessDenied
    
        
    
        
        A delegate assigned to this property will be invoked when the related method is called.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.Cookies.CookieRedirectContext<Microsoft.AspNetCore.Authentication.Cookies.CookieRedirectContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<CookieRedirectContext, Task> OnRedirectToAccessDenied
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.OnRedirectToLogin
    
        
    
        
        A delegate assigned to this property will be invoked when the related method is called.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.Cookies.CookieRedirectContext<Microsoft.AspNetCore.Authentication.Cookies.CookieRedirectContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<CookieRedirectContext, Task> OnRedirectToLogin
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.OnRedirectToLogout
    
        
    
        
        A delegate assigned to this property will be invoked when the related method is called.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.Cookies.CookieRedirectContext<Microsoft.AspNetCore.Authentication.Cookies.CookieRedirectContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<CookieRedirectContext, Task> OnRedirectToLogout
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.OnRedirectToReturnUrl
    
        
    
        
        A delegate assigned to this property will be invoked when the related method is called.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.Cookies.CookieRedirectContext<Microsoft.AspNetCore.Authentication.Cookies.CookieRedirectContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<CookieRedirectContext, Task> OnRedirectToReturnUrl
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.OnSignedIn
    
        
    
        
        A delegate assigned to this property will be invoked when the related method is called.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.Cookies.CookieSignedInContext<Microsoft.AspNetCore.Authentication.Cookies.CookieSignedInContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<CookieSignedInContext, Task> OnSignedIn
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.OnSigningIn
    
        
    
        
        A delegate assigned to this property will be invoked when the related method is called.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.Cookies.CookieSigningInContext<Microsoft.AspNetCore.Authentication.Cookies.CookieSigningInContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<CookieSigningInContext, Task> OnSigningIn
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.OnSigningOut
    
        
    
        
        A delegate assigned to this property will be invoked when the related method is called.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.Cookies.CookieSigningOutContext<Microsoft.AspNetCore.Authentication.Cookies.CookieSigningOutContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<CookieSigningOutContext, Task> OnSigningOut
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.OnValidatePrincipal
    
        
    
        
        A delegate assigned to this property will be invoked when the related method is called.
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.Cookies.CookieValidatePrincipalContext<Microsoft.AspNetCore.Authentication.Cookies.CookieValidatePrincipalContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<CookieValidatePrincipalContext, Task> OnValidatePrincipal
            {
                get;
                set;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.RedirectToAccessDenied(Microsoft.AspNetCore.Authentication.Cookies.CookieRedirectContext)
    
        
    
        
        Implements the interface method by invoking the related delegate method.
    
        
    
        
        :param context: Contains information about the event
        
        :type context: Microsoft.AspNetCore.Authentication.Cookies.CookieRedirectContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task RedirectToAccessDenied(CookieRedirectContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.RedirectToLogin(Microsoft.AspNetCore.Authentication.Cookies.CookieRedirectContext)
    
        
    
        
        Implements the interface method by invoking the related delegate method.
    
        
    
        
        :param context: Contains information about the event
        
        :type context: Microsoft.AspNetCore.Authentication.Cookies.CookieRedirectContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task RedirectToLogin(CookieRedirectContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.RedirectToLogout(Microsoft.AspNetCore.Authentication.Cookies.CookieRedirectContext)
    
        
    
        
        Implements the interface method by invoking the related delegate method.
    
        
    
        
        :param context: Contains information about the event
        
        :type context: Microsoft.AspNetCore.Authentication.Cookies.CookieRedirectContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task RedirectToLogout(CookieRedirectContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.RedirectToReturnUrl(Microsoft.AspNetCore.Authentication.Cookies.CookieRedirectContext)
    
        
    
        
        Implements the interface method by invoking the related delegate method.
    
        
    
        
        :param context: Contains information about the event
        
        :type context: Microsoft.AspNetCore.Authentication.Cookies.CookieRedirectContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task RedirectToReturnUrl(CookieRedirectContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.SignedIn(Microsoft.AspNetCore.Authentication.Cookies.CookieSignedInContext)
    
        
    
        
        Implements the interface method by invoking the related delegate method.
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.Cookies.CookieSignedInContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task SignedIn(CookieSignedInContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.SigningIn(Microsoft.AspNetCore.Authentication.Cookies.CookieSigningInContext)
    
        
    
        
        Implements the interface method by invoking the related delegate method.
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.Cookies.CookieSigningInContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task SigningIn(CookieSigningInContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.SigningOut(Microsoft.AspNetCore.Authentication.Cookies.CookieSigningOutContext)
    
        
    
        
        Implements the interface method by invoking the related delegate method.
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.Cookies.CookieSigningOutContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task SigningOut(CookieSigningOutContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.ValidatePrincipal(Microsoft.AspNetCore.Authentication.Cookies.CookieValidatePrincipalContext)
    
        
    
        
        Implements the interface method by invoking the related delegate method.
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.Cookies.CookieValidatePrincipalContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task ValidatePrincipal(CookieValidatePrincipalContext context)
    

