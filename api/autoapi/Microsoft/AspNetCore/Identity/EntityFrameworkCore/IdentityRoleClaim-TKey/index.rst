

IdentityRoleClaim<TKey> Class
=============================






Represents a claim that is granted to all users within a role.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Identity.EntityFrameworkCore`
Assemblies
    * Microsoft.AspNetCore.Identity.EntityFrameworkCore

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim\<TKey>`








Syntax
------

.. code-block:: csharp

    public class IdentityRoleClaim<TKey>
        where TKey : IEquatable<TKey>








.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<TKey>

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<TKey>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<TKey>.ClaimType
    
        
    
        
        Gets or sets the claim type for this claim.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string ClaimType { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<TKey>.ClaimValue
    
        
    
        
        Gets or sets the claim value for this claim.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string ClaimValue { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<TKey>.Id
    
        
    
        
        Gets or sets the identifier for this role claim.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public virtual int Id { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<TKey>.RoleId
    
        
    
        
        Gets or sets the of the primary key of the role associated with this claim.
    
        
        :rtype: TKey
    
        
        .. code-block:: csharp
    
            public virtual TKey RoleId { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<TKey>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<TKey>.InitializeFromClaim(System.Security.Claims.Claim)
    
        
    
        
        :type other: System.Security.Claims.Claim
    
        
        .. code-block:: csharp
    
            public virtual void InitializeFromClaim(Claim other)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<TKey>.ToClaim()
    
        
        :rtype: System.Security.Claims.Claim
    
        
        .. code-block:: csharp
    
            public virtual Claim ToClaim()
    

