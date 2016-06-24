

IdentityRole<TKey, TUserRole> Class
===================================





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
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.IdentityRole{{TKey},{TUserRole}}`
* :dn:cls:`Microsoft.AspNet.Identity.CoreCompat.IdentityRole\<TKey, TUserRole>`








Syntax
------

.. code-block:: csharp

    public class IdentityRole<TKey, TUserRole> : IdentityRole<TKey, TUserRole>, IRole<TKey> where TUserRole : IdentityUserRole<TKey>








.. dn:class:: Microsoft.AspNet.Identity.CoreCompat.IdentityRole`2
    :hidden:

.. dn:class:: Microsoft.AspNet.Identity.CoreCompat.IdentityRole<TKey, TUserRole>

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.CoreCompat.IdentityRole<TKey, TUserRole>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.CoreCompat.IdentityRole<TKey, TUserRole>.Claims
    
        
    
        
            Navigation property for claims in the role
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{Microsoft.AspNet.Identity.CoreCompat.IdentityRoleClaim<Microsoft.AspNet.Identity.CoreCompat.IdentityRoleClaim`1>{TKey}}
    
        
        .. code-block:: csharp
    
            public virtual ICollection<IdentityRoleClaim<TKey>> Claims { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.CoreCompat.IdentityRole<TKey, TUserRole>.ConcurrencyStamp
    
        
    
        
            Concurrency stamp 
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string ConcurrencyStamp { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.CoreCompat.IdentityRole<TKey, TUserRole>.NormalizedName
    
        
    
        
            Normalized role name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string NormalizedName { get; set; }
    

