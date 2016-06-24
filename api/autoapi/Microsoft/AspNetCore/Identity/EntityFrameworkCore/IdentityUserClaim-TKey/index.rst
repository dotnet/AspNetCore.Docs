

IdentityUserClaim<TKey> Class
=============================






Represents a claim that a user possesses. 


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
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim\<TKey>`








Syntax
------

.. code-block:: csharp

    public class IdentityUserClaim<TKey>
        where TKey : IEquatable<TKey>








.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<TKey>

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<TKey>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<TKey>.ClaimType
    
        
    
        
        Gets or sets the claim type for this claim.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string ClaimType { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<TKey>.ClaimValue
    
        
    
        
        Gets or sets the claim value for this claim.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string ClaimValue { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<TKey>.Id
    
        
    
        
        Gets or sets the identifier for this user claim.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public virtual int Id { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<TKey>.UserId
    
        
    
        
        Gets or sets the primary key of the user associated with this claim.
    
        
        :rtype: TKey
    
        
        .. code-block:: csharp
    
            public virtual TKey UserId { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<TKey>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<TKey>.InitializeFromClaim(System.Security.Claims.Claim)
    
        
    
        
        Reads the type and value from the Claim.
    
        
    
        
        :type claim: System.Security.Claims.Claim
    
        
        .. code-block:: csharp
    
            public virtual void InitializeFromClaim(Claim claim)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<TKey>.ToClaim()
    
        
    
        
        Converts the entity into a Claim instance.
    
        
        :rtype: System.Security.Claims.Claim
    
        
        .. code-block:: csharp
    
            public virtual Claim ToClaim()
    

