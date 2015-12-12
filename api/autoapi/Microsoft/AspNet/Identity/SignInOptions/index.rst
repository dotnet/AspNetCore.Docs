

SignInOptions Class
===================



.. contents:: 
   :local:



Summary
-------

Options for configuring sign in..





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.SignInOptions`








Syntax
------

.. code-block:: csharp

   public class SignInOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity/SignInOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.SignInOptions

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.SignInOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.SignInOptions.RequireConfirmedEmail
    
        
    
        Gets or sets a flag indicating whether a confirmed email address is required to sign in.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool RequireConfirmedEmail { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.SignInOptions.RequireConfirmedPhoneNumber
    
        
    
        Gets or sets a flag indicating whether a confirmed telephone number is required to sign in.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool RequireConfirmedPhoneNumber { get; set; }
    

