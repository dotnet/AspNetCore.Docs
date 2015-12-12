

IRoleValidator<TRole> Interface
===============================



.. contents:: 
   :local:



Summary
-------

Provides an abstraction for a validating a role.











Syntax
------

.. code-block:: csharp

   public interface IRoleValidator<TRole> where TRole : class





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/IRoleValidator.cs>`_





.. dn:interface:: Microsoft.AspNet.Identity.IRoleValidator<TRole>

Methods
-------

.. dn:interface:: Microsoft.AspNet.Identity.IRoleValidator<TRole>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.IRoleValidator<TRole>.ValidateAsync(Microsoft.AspNet.Identity.RoleManager<TRole>, TRole)
    
        
    
        Validates a role as an asynchronous operation.
    
        
        
        
        :param manager: The  managing the role store.
        
        :type manager: Microsoft.AspNet.Identity.RoleManager{{TRole}}
        
        
        :param role: The role to validate.
        
        :type role: {TRole}
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: A <see cref="T:System.Threading.Tasks.Task`1" /> that represents the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" /> of the asynchronous validation.
    
        
        .. code-block:: csharp
    
           Task<IdentityResult> ValidateAsync(RoleManager<TRole> manager, TRole role)
    

