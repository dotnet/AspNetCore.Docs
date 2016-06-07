

IUserClaimsPrincipalFactory<TUser> Interface
============================================






Provides an abstraction for a factory to create a :any:`System.Security.Claims.ClaimsPrincipal` from a user.


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

    public interface IUserClaimsPrincipalFactory<TUser>
        where TUser : class








.. dn:interface:: Microsoft.AspNetCore.Identity.IUserClaimsPrincipalFactory`1
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Identity.IUserClaimsPrincipalFactory<TUser>

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Identity.IUserClaimsPrincipalFactory<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserClaimsPrincipalFactory<TUser>.CreateAsync(TUser)
    
        
    
        
        Creates a :any:`System.Security.Claims.ClaimsPrincipal` from an user asynchronously.
    
        
    
        
        :param user: The user to create a :any:`System.Security.Claims.ClaimsPrincipal` from.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Security.Claims.ClaimsPrincipal<System.Security.Claims.ClaimsPrincipal>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous creation operation, containing the created :any:`System.Security.Claims.ClaimsPrincipal`\.
    
        
        .. code-block:: csharp
    
            Task<ClaimsPrincipal> CreateAsync(TUser user)
    

