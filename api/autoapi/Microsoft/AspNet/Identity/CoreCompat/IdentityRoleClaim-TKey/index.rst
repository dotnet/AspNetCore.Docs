

IdentityRoleClaim<TKey> Class
=============================






    EntityType that represents one specific role claim


Namespace
    :dn:ns:`Microsoft.AspNet.Identity.CoreCompat`
Assemblies
    * Microsoft.AspNet.Identity.AspNetCoreCompat

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.CoreCompat.IdentityRoleClaim\<TKey>`








Syntax
------

.. code-block:: csharp

    public class IdentityRoleClaim<TKey>








.. dn:class:: Microsoft.AspNet.Identity.CoreCompat.IdentityRoleClaim`1
    :hidden:

.. dn:class:: Microsoft.AspNet.Identity.CoreCompat.IdentityRoleClaim<TKey>

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.CoreCompat.IdentityRoleClaim<TKey>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.CoreCompat.IdentityRoleClaim<TKey>.ClaimType
    
        
    
        
            Claim type
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string ClaimType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.CoreCompat.IdentityRoleClaim<TKey>.ClaimValue
    
        
    
        
            Claim value
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string ClaimValue { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.CoreCompat.IdentityRoleClaim<TKey>.Id
    
        
    
        
            Primary key
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public virtual int Id { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.CoreCompat.IdentityRoleClaim<TKey>.RoleId
    
        
    
        
            User Id for the role this claim belongs to
    
        
        :rtype: TKey
    
        
        .. code-block:: csharp
    
            public virtual TKey RoleId { get; set; }
    

