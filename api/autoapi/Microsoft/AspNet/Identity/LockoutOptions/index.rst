

LockoutOptions Class
====================



.. contents:: 
   :local:



Summary
-------

Options for configuring user lockout.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.LockoutOptions`








Syntax
------

.. code-block:: csharp

   public class LockoutOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/LockoutOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.LockoutOptions

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.LockoutOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.LockoutOptions.AllowedForNewUsers
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool AllowedForNewUsers { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.LockoutOptions.DefaultLockoutTimeSpan
    
        
    
        Gets or sets the :any:`System.TimeSpan` a user is locked out for when a lockout occurs.
    
        
        :rtype: System.TimeSpan
    
        
        .. code-block:: csharp
    
           public TimeSpan DefaultLockoutTimeSpan { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.LockoutOptions.MaxFailedAccessAttempts
    
        
    
        Gets or sets the number of failed access attempts allowed before a user is locked out,
        assuming lock out is enabled.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int MaxFailedAccessAttempts { get; set; }
    

