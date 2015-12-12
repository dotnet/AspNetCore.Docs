

SecurityStampValidator Class
============================



.. contents:: 
   :local:



Summary
-------

Static helper class used to configure a CookieAuthenticationNotifications to validate a cookie against a user's security
stamp.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.SecurityStampValidator`








Syntax
------

.. code-block:: csharp

   public class SecurityStampValidator





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/SecurityStampValidator.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.SecurityStampValidator

Methods
-------

.. dn:class:: Microsoft.AspNet.Identity.SecurityStampValidator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.SecurityStampValidator.ValidatePrincipalAsync(Microsoft.AspNet.Authentication.Cookies.CookieValidatePrincipalContext)
    
        
    
        Validates a principal against a user's stored security stamp.
        the identity.
    
        
        
        
        :param context: The context containing the and  to validate.
        
        :type context: Microsoft.AspNet.Authentication.Cookies.CookieValidatePrincipalContext
        :rtype: System.Threading.Tasks.Task
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous validation operation.
    
        
        .. code-block:: csharp
    
           public static Task ValidatePrincipalAsync(CookieValidatePrincipalContext context)
    

