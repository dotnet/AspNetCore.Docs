

IUserClaimsPrincipalFactory<TUser> Interface
============================================



.. contents:: 
   :local:



Summary
-------

Provides an abstraction for a factory to create a :any:`System.Security.Claims.ClaimsPrincipal` from a user.











Syntax
------

.. code-block:: csharp

   public interface IUserClaimsPrincipalFactory<TUser> where TUser : class





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity/IUserClaimsPrincipalFactory.cs>`_





.. dn:interface:: Microsoft.AspNet.Identity.IUserClaimsPrincipalFactory<TUser>

Methods
-------

.. dn:interface:: Microsoft.AspNet.Identity.IUserClaimsPrincipalFactory<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.IUserClaimsPrincipalFactory<TUser>.CreateAsync(TUser)
    
        
    
        Creates a :any:`System.Security.Claims.ClaimsPrincipal` from an user asynchronously.
    
        
        
        
        :param user: The user to create a  from.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.Security.Claims.ClaimsPrincipal}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous creation operation, containing the created <see cref="T:System.Security.Claims.ClaimsPrincipal" />.
    
        
        .. code-block:: csharp
    
           Task<ClaimsPrincipal> CreateAsync(TUser user)
    

