

RoleValidator<TRole> Class
==========================






Provides the default validation of roles.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Identity`
Assemblies
    * Microsoft.AspNetCore.Identity

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Identity.RoleValidator\<TRole>`








Syntax
------

.. code-block:: csharp

    public class RoleValidator<TRole> : IRoleValidator<TRole> where TRole : class








.. dn:class:: Microsoft.AspNetCore.Identity.RoleValidator`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.RoleValidator<TRole>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.RoleValidator<TRole>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.RoleValidator<TRole>.RoleValidator(Microsoft.AspNetCore.Identity.IdentityErrorDescriber)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Identity.RoleValidator\`1`\/
    
        
    
        
        :param errors: The :any:`Microsoft.AspNetCore.Identity.IdentityErrorDescriber` used to provider error messages.
        
        :type errors: Microsoft.AspNetCore.Identity.IdentityErrorDescriber
    
        
        .. code-block:: csharp
    
            public RoleValidator(IdentityErrorDescriber errors = null)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.RoleValidator<TRole>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.RoleValidator<TRole>.ValidateAsync(Microsoft.AspNetCore.Identity.RoleManager<TRole>, TRole)
    
        
    
        
        Validates a role as an asynchronous operation.
    
        
    
        
        :param manager: The :any:`Microsoft.AspNetCore.Identity.RoleManager\`1` managing the role store.
        
        :type manager: Microsoft.AspNetCore.Identity.RoleManager<Microsoft.AspNetCore.Identity.RoleManager`1>{TRole}
    
        
        :param role: The role to validate.
        
        :type role: TRole
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: A :any:`System.Threading.Tasks.Task\`1` that represents the :any:`Microsoft.AspNetCore.Identity.IdentityResult` of the asynchronous validation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> ValidateAsync(RoleManager<TRole> manager, TRole role)
    

