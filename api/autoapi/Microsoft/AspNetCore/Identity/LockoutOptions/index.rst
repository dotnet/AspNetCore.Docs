

LockoutOptions Class
====================






Options for configuring user lockout.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Identity`
Assemblies
    * Microsoft.AspNetCore.Identity

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Identity.LockoutOptions`








Syntax
------

.. code-block:: csharp

    public class LockoutOptions








.. dn:class:: Microsoft.AspNetCore.Identity.LockoutOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.LockoutOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.LockoutOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.LockoutOptions.AllowedForNewUsers
    
        
        :rtype: System.Boolean
        :return: 
            True if a newly created user can be locked out, otherwise false.
    
        
        .. code-block:: csharp
    
            public bool AllowedForNewUsers
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.LockoutOptions.DefaultLockoutTimeSpan
    
        
    
        
        Gets or sets the :any:`System.TimeSpan` a user is locked out for when a lockout occurs.
    
        
        :rtype: System.TimeSpan
        :return: The :any:`System.TimeSpan` a user is locked out for when a lockout occurs.
    
        
        .. code-block:: csharp
    
            public TimeSpan DefaultLockoutTimeSpan
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.LockoutOptions.MaxFailedAccessAttempts
    
        
    
        
        Gets or sets the number of failed access attempts allowed before a user is locked out,
        assuming lock out is enabled.
    
        
        :rtype: System.Int32
        :return: 
            The number of failed access attempts allowed before a user is locked out, if lockout is enabled.
    
        
        .. code-block:: csharp
    
            public int MaxFailedAccessAttempts
            {
                get;
                set;
            }
    

