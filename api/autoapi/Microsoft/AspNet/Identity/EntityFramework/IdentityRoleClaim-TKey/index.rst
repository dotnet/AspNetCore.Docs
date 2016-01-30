

IdentityRoleClaim<TKey> Class
=============================



.. contents:: 
   :local:



Summary
-------

Represents a claim that is granted to all users within a role.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim\<TKey>`








Syntax
------

.. code-block:: csharp

   public class IdentityRoleClaim<TKey> where TKey : IEquatable<TKey>





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity.EntityFramework/IdentityRoleClaim.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<TKey>

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<TKey>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<TKey>.ClaimType
    
        
    
        Gets or sets the claim type for this claim.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string ClaimType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<TKey>.ClaimValue
    
        
    
        Gets or sets the claim value for this claim.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string ClaimValue { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<TKey>.Id
    
        
    
        Gets or sets the identifier for this role claim.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public virtual int Id { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<TKey>.RoleId
    
        
    
        Gets or sets the of the primary key of the role associated with this claim.
    
        
        :rtype: {TKey}
    
        
        .. code-block:: csharp
    
           public virtual TKey RoleId { get; set; }
    

