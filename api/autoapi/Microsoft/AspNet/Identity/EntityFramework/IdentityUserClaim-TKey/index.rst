

IdentityUserClaim<TKey> Class
=============================



.. contents:: 
   :local:



Summary
-------

Represents a claim that a user possesses.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim\<TKey>`








Syntax
------

.. code-block:: csharp

   public class IdentityUserClaim<TKey> where TKey : IEquatable<TKey>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity.EntityFramework/IdentityUserClaim.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<TKey>

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<TKey>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<TKey>.ClaimType
    
        
    
        Gets or sets the claim type for this claim.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string ClaimType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<TKey>.ClaimValue
    
        
    
        Gets or sets the claim value for this claim.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string ClaimValue { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<TKey>.Id
    
        
    
        Gets or sets the identifier for this user claim.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public virtual int Id { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<TKey>.UserId
    
        
    
        Gets or sets the of the primary key of the user associated with this claim.
    
        
        :rtype: {TKey}
    
        
        .. code-block:: csharp
    
           public virtual TKey UserId { get; set; }
    

