

IRoleValidator<TRole> Interface
===============================






Provides an abstraction for a validating a role.


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

    public interface IRoleValidator<TRole>
        where TRole : class








.. dn:interface:: Microsoft.AspNetCore.Identity.IRoleValidator`1
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Identity.IRoleValidator<TRole>

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Identity.IRoleValidator<TRole>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.IRoleValidator<TRole>.ValidateAsync(Microsoft.AspNetCore.Identity.RoleManager<TRole>, TRole)
    
        
    
        
        Validates a role as an asynchronous operation.
    
        
    
        
        :param manager: The :any:`Microsoft.AspNetCore.Identity.RoleManager\`1` managing the role store.
        
        :type manager: Microsoft.AspNetCore.Identity.RoleManager<Microsoft.AspNetCore.Identity.RoleManager`1>{TRole}
    
        
        :param role: The role to validate.
        
        :type role: TRole
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: A :any:`System.Threading.Tasks.Task\`1` that represents the :any:`Microsoft.AspNetCore.Identity.IdentityResult` of the asynchronous validation.
    
        
        .. code-block:: csharp
    
            Task<IdentityResult> ValidateAsync(RoleManager<TRole> manager, TRole role)
    

