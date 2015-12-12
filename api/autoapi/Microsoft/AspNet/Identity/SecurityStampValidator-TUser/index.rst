

SecurityStampValidator<TUser> Class
===================================



.. contents:: 
   :local:



Summary
-------

Provides default implementation of validation functions for security stamps.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.SecurityStampValidator\<TUser>`








Syntax
------

.. code-block:: csharp

   public class SecurityStampValidator<TUser> : ISecurityStampValidator where TUser : class





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/SecurityStampValidator.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.SecurityStampValidator<TUser>

Methods
-------

.. dn:class:: Microsoft.AspNet.Identity.SecurityStampValidator<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.SecurityStampValidator<TUser>.ValidateAsync(Microsoft.AspNet.Authentication.Cookies.CookieValidatePrincipalContext)
    
        
    
        Validates a security stamp of an identity as an asynchronous operation, and rebuilds the identity if the validation succeeds, otherwise rejects
        the identity.
    
        
        
        
        :param context: The context containing the and  to validate.
        
        :type context: Microsoft.AspNet.Authentication.Cookies.CookieValidatePrincipalContext
        :rtype: System.Threading.Tasks.Task
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous validation operation.
    
        
        .. code-block:: csharp
    
           public virtual Task ValidateAsync(CookieValidatePrincipalContext context)
    

