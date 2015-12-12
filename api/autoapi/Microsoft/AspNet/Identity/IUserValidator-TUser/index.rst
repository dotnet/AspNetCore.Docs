

IUserValidator<TUser> Interface
===============================



.. contents:: 
   :local:



Summary
-------

Provides an abstraction for user validation.











Syntax
------

.. code-block:: csharp

   public interface IUserValidator<TUser> where TUser : class





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/IUserValidator.cs>`_





.. dn:interface:: Microsoft.AspNet.Identity.IUserValidator<TUser>

Methods
-------

.. dn:interface:: Microsoft.AspNet.Identity.IUserValidator<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.IUserValidator<TUser>.ValidateAsync(Microsoft.AspNet.Identity.UserManager<TUser>, TUser)
    
        
    
        Validates the specified ``user`` as an asynchronous operation.
    
        
        
        
        :param manager: The  that can be used to retrieve user properties.
        
        :type manager: Microsoft.AspNet.Identity.UserManager{{TUser}}
        
        
        :param user: The user to validate.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" /> of the validation operation.
    
        
        .. code-block:: csharp
    
           Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user)
    

