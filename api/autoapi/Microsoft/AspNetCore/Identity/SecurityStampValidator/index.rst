

SecurityStampValidator Class
============================






Static helper class used to configure a CookieAuthenticationNotifications to validate a cookie against a user's security
stamp.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Identity`
Assemblies
    * Microsoft.AspNetCore.Identity

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Identity.SecurityStampValidator`








Syntax
------

.. code-block:: csharp

    public class SecurityStampValidator








.. dn:class:: Microsoft.AspNetCore.Identity.SecurityStampValidator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.SecurityStampValidator

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.SecurityStampValidator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.SecurityStampValidator.ValidatePrincipalAsync(Microsoft.AspNetCore.Authentication.Cookies.CookieValidatePrincipalContext)
    
        
    
        
        Validates a principal against a user's stored security stamp.
        the identity.
    
        
    
        
        :param context: The context containing the :any:`System.Security.Claims.ClaimsPrincipal`
            and :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` to validate.
        
        :type context: Microsoft.AspNetCore.Authentication.Cookies.CookieValidatePrincipalContext
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous validation operation.
    
        
        .. code-block:: csharp
    
            public static Task ValidatePrincipalAsync(CookieValidatePrincipalContext context)
    

