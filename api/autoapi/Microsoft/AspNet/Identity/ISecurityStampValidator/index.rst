

ISecurityStampValidator Interface
=================================



.. contents:: 
   :local:



Summary
-------

Provides an abstraction for a validating a security stamp of an incoming identity, and regenerating or rejecting the
identity based on the validation result.











Syntax
------

.. code-block:: csharp

   public interface ISecurityStampValidator





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity/ISecurityStampValidator.cs>`_





.. dn:interface:: Microsoft.AspNet.Identity.ISecurityStampValidator

Methods
-------

.. dn:interface:: Microsoft.AspNet.Identity.ISecurityStampValidator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.ISecurityStampValidator.ValidateAsync(Microsoft.AspNet.Authentication.Cookies.CookieValidatePrincipalContext)
    
        
    
        Validates a security stamp of an identity as an asynchronous operation, and rebuilds the identity if the validation succeeds, otherwise rejects
        the identity.
    
        
        
        
        :param context: The context containing the and  to validate.
        
        :type context: Microsoft.AspNet.Authentication.Cookies.CookieValidatePrincipalContext
        :rtype: System.Threading.Tasks.Task
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous validation operation.
    
        
        .. code-block:: csharp
    
           Task ValidateAsync(CookieValidatePrincipalContext context)
    

