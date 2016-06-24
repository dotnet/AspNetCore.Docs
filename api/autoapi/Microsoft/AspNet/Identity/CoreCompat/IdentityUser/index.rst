

IdentityUser Class
==================





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
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.IdentityUser{System.String,Microsoft.AspNet.Identity.CoreCompat.IdentityUserLogin,Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole,Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim}`
* :dn:cls:`Microsoft.AspNet.Identity.CoreCompat.IdentityUser{System.String,Microsoft.AspNet.Identity.CoreCompat.IdentityUserLogin,Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole,Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim}`
* :dn:cls:`Microsoft.AspNet.Identity.CoreCompat.IdentityUser`








Syntax
------

.. code-block:: csharp

    public class IdentityUser : IdentityUser<string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>, IUser<string>








.. dn:class:: Microsoft.AspNet.Identity.CoreCompat.IdentityUser
    :hidden:

.. dn:class:: Microsoft.AspNet.Identity.CoreCompat.IdentityUser

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.CoreCompat.IdentityUser
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.CoreCompat.IdentityUser.IdentityUser()
    
        
    
        
            Constructor which creates a new Guid for the Id
    
        
    
        
        .. code-block:: csharp
    
            public IdentityUser()
    
    .. dn:constructor:: Microsoft.AspNet.Identity.CoreCompat.IdentityUser.IdentityUser(System.String)
    
        
    
        
            Constructor that takes a userName
    
        
    
        
        :type userName: System.String
    
        
        .. code-block:: csharp
    
            public IdentityUser(string userName)
    

