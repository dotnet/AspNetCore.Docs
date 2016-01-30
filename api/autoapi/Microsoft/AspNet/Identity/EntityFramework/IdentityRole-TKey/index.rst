

IdentityRole<TKey> Class
========================



.. contents:: 
   :local:



Summary
-------

Represents a role in the identity system





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.IdentityRole\<TKey>`








Syntax
------

.. code-block:: csharp

   public class IdentityRole<TKey> where TKey : IEquatable<TKey>





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity.EntityFramework/IdentityRole.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.IdentityRole<TKey>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.IdentityRole<TKey>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.EntityFramework.IdentityRole<TKey>.IdentityRole()
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Identity.EntityFramework.IdentityRole\`1`\.
    
        
    
        
        .. code-block:: csharp
    
           public IdentityRole()
    
    .. dn:constructor:: Microsoft.AspNet.Identity.EntityFramework.IdentityRole<TKey>.IdentityRole(System.String)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Identity.EntityFramework.IdentityRole\`1`\.
    
        
        
        
        :param roleName: The role name.
        
        :type roleName: System.String
    
        
        .. code-block:: csharp
    
           public IdentityRole(string roleName)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.IdentityRole<TKey>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.EntityFramework.IdentityRole<TKey>.ToString()
    
        
    
        Returns the name of the role.
    
        
        :rtype: System.String
        :return: The name of the role.
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.IdentityRole<TKey>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityRole<TKey>.Claims
    
        
    
        Navigation property for claims in this role.
    
        
        :rtype: System.Collections.Generic.ICollection{Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim{{TKey}}}
    
        
        .. code-block:: csharp
    
           public virtual ICollection<IdentityRoleClaim<TKey>> Claims { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityRole<TKey>.ConcurrencyStamp
    
        
    
        A random value that should change whenever a role is persisted to the store
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string ConcurrencyStamp { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityRole<TKey>.Id
    
        
    
        Gets or sets the primary key for this role.
    
        
        :rtype: {TKey}
    
        
        .. code-block:: csharp
    
           public virtual TKey Id { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityRole<TKey>.Name
    
        
    
        Gets or sets the name for this role.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string Name { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityRole<TKey>.NormalizedName
    
        
    
        Gets or sets the normalized name for this role.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string NormalizedName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityRole<TKey>.Users
    
        
    
        Navigation property for the users in this role.
    
        
        :rtype: System.Collections.Generic.ICollection{Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole{{TKey}}}
    
        
        .. code-block:: csharp
    
           public virtual ICollection<IdentityUserRole<TKey>> Users { get; }
    

