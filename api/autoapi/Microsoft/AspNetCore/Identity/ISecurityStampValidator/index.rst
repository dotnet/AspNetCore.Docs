

ISecurityStampValidator Interface
=================================






Provides an abstraction for a validating a security stamp of an incoming identity, and regenerating or rejecting the 
identity based on the validation result.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Identity`
Assemblies
    * Microsoft.AspNetCore.Identity

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ISecurityStampValidator








.. dn:interface:: Microsoft.AspNetCore.Identity.ISecurityStampValidator
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Identity.ISecurityStampValidator

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Identity.ISecurityStampValidator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.ISecurityStampValidator.ValidateAsync(Microsoft.AspNetCore.Authentication.Cookies.CookieValidatePrincipalContext)
    
        
    
        
        Validates a security stamp of an identity as an asynchronous operation, and rebuilds the identity if the validation succeeds, otherwise rejects
        the identity.
    
        
    
        
        :param context: The context containing the :any:`System.Security.Claims.ClaimsPrincipal`
            and :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` to validate.
        
        :type context: Microsoft.AspNetCore.Authentication.Cookies.CookieValidatePrincipalContext
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous validation operation.
    
        
        .. code-block:: csharp
    
            Task ValidateAsync(CookieValidatePrincipalContext context)
    

