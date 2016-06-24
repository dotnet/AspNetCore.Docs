

IdentityUser<TKey, TUserLogin, TUserRole, TUserClaim> Class
===========================================================





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
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.IdentityUser{{TKey},{TUserLogin},{TUserRole},{TUserClaim}}`
* :dn:cls:`Microsoft.AspNet.Identity.CoreCompat.IdentityUser\<TKey, TUserLogin, TUserRole, TUserClaim>`








Syntax
------

.. code-block:: csharp

    public class IdentityUser<TKey, TUserLogin, TUserRole, TUserClaim> : IdentityUser<TKey, TUserLogin, TUserRole, TUserClaim>, IUser<TKey> where TUserLogin : IdentityUserLogin<TKey> where TUserRole : IdentityUserRole<TKey> where TUserClaim : IdentityUserClaim<TKey>








.. dn:class:: Microsoft.AspNet.Identity.CoreCompat.IdentityUser`4
    :hidden:

.. dn:class:: Microsoft.AspNet.Identity.CoreCompat.IdentityUser<TKey, TUserLogin, TUserRole, TUserClaim>

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.CoreCompat.IdentityUser<TKey, TUserLogin, TUserRole, TUserClaim>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.CoreCompat.IdentityUser<TKey, TUserLogin, TUserRole, TUserClaim>.ConcurrencyStamp
    
        
    
        
            Concurrency stamp
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string ConcurrencyStamp { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.CoreCompat.IdentityUser<TKey, TUserLogin, TUserRole, TUserClaim>.NormalizedEmail
    
        
    
        
            Normalized email
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string NormalizedEmail { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.CoreCompat.IdentityUser<TKey, TUserLogin, TUserRole, TUserClaim>.NormalizedUserName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string NormalizedUserName { get; set; }
    

