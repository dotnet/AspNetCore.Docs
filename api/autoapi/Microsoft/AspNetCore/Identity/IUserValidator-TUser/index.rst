

IUserValidator<TUser> Interface
===============================






Provides an abstraction for user validation.


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

    public interface IUserValidator<TUser>
        where TUser : class








.. dn:interface:: Microsoft.AspNetCore.Identity.IUserValidator`1
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Identity.IUserValidator<TUser>

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Identity.IUserValidator<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserValidator<TUser>.ValidateAsync(Microsoft.AspNetCore.Identity.UserManager<TUser>, TUser)
    
        
    
        
        Validates the specified <em>user</em> as an asynchronous operation.
    
        
    
        
        :param manager: The :any:`Microsoft.AspNetCore.Identity.UserManager\`1` that can be used to retrieve user properties.
        
        :type manager: Microsoft.AspNetCore.Identity.UserManager<Microsoft.AspNetCore.Identity.UserManager`1>{TUser}
    
        
        :param user: The user to validate.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult` of the validation operation.
    
        
        .. code-block:: csharp
    
            Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user)
    

