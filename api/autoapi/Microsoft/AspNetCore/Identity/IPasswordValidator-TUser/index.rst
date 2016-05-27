

IPasswordValidator<TUser> Interface
===================================






Provides an abstraction for validating passwords.


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

    public interface IPasswordValidator<TUser>
        where TUser : class








.. dn:interface:: Microsoft.AspNetCore.Identity.IPasswordValidator`1
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Identity.IPasswordValidator<TUser>

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Identity.IPasswordValidator<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.IPasswordValidator<TUser>.ValidateAsync(Microsoft.AspNetCore.Identity.UserManager<TUser>, TUser, System.String)
    
        
    
        
        Validates a password as an asynchronous operation.
    
        
    
        
        :param manager: The :any:`Microsoft.AspNetCore.Identity.UserManager\`1` to retrieve the <em>user</em> properties from.
        
        :type manager: Microsoft.AspNetCore.Identity.UserManager<Microsoft.AspNetCore.Identity.UserManager`1>{TUser}
    
        
        :param user: The user whose password should be validated.
        
        :type user: TUser
    
        
        :param password: The password supplied for validation
        
        :type password: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
            Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string password)
    

