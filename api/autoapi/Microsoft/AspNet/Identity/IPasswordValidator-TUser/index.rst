

IPasswordValidator<TUser> Interface
===================================



.. contents:: 
   :local:



Summary
-------

Provides an abstraction for validating passwords.











Syntax
------

.. code-block:: csharp

   public interface IPasswordValidator<TUser> where TUser : class





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/IPasswordValidator.cs>`_





.. dn:interface:: Microsoft.AspNet.Identity.IPasswordValidator<TUser>

Methods
-------

.. dn:interface:: Microsoft.AspNet.Identity.IPasswordValidator<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.IPasswordValidator<TUser>.ValidateAsync(Microsoft.AspNet.Identity.UserManager<TUser>, TUser, System.String)
    
        
    
        Validates a password as an asynchronous operation.
    
        
        
        
        :param manager: The  to retrieve the  properties from.
        
        :type manager: Microsoft.AspNet.Identity.UserManager{{TUser}}
        
        
        :param user: The user whose password should be validated.
        
        :type user: {TUser}
        
        
        :param password: The password supplied for validation
        
        :type password: System.String
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
           Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string password)
    

