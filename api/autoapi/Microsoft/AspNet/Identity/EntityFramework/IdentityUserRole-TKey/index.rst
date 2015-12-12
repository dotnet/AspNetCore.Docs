

IdentityUserRole<TKey> Class
============================



.. contents:: 
   :local:



Summary
-------

Represents the link between a user and a role.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole\<TKey>`








Syntax
------

.. code-block:: csharp

   public class IdentityUserRole<TKey> where TKey : IEquatable<TKey>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity.EntityFramework/IdentityUserRole.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<TKey>

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<TKey>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<TKey>.RoleId
    
        
    
        Gets or sets the primary key of the role that is linked to the user.
    
        
        :rtype: {TKey}
    
        
        .. code-block:: csharp
    
           public virtual TKey RoleId { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<TKey>.UserId
    
        
    
        Gets or sets the primary key of the user that is linked to a role.
    
        
        :rtype: {TKey}
    
        
        .. code-block:: csharp
    
           public virtual TKey UserId { get; set; }
    

