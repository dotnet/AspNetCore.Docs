

IdentityRole Class
==================






The default implementation of :any:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole\`1` which uses a string as the primary key.


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
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole{System.String,Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole{System.String},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim{System.String}}`
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole{System.String}`
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole`








Syntax
------

.. code-block:: csharp

    public class IdentityRole : IdentityRole<string>








.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole.IdentityRole()
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole`\.
    
        
    
        
        .. code-block:: csharp
    
            public IdentityRole()
    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole.IdentityRole(System.String)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole`\.
    
        
    
        
        :param roleName: The role name.
        
        :type roleName: System.String
    
        
        .. code-block:: csharp
    
            public IdentityRole(string roleName)
    

