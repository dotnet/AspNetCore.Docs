

SignInOptions Class
===================






Options for configuring sign in..


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
* :dn:cls:`Microsoft.AspNetCore.Identity.SignInOptions`








Syntax
------

.. code-block:: csharp

    public class SignInOptions








.. dn:class:: Microsoft.AspNetCore.Identity.SignInOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.SignInOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.SignInOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.SignInOptions.RequireConfirmedEmail
    
        
    
        
        Gets or sets a flag indicating whether a confirmed email address is required to sign in.
    
        
        :rtype: System.Boolean
        :return: True if a user must have a confirmed email address before they can sign in, otherwise false.
    
        
        .. code-block:: csharp
    
            public bool RequireConfirmedEmail { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.SignInOptions.RequireConfirmedPhoneNumber
    
        
    
        
        Gets or sets a flag indicating whether a confirmed telephone number is required to sign in.
    
        
        :rtype: System.Boolean
        :return: True if a user must have a confirmed telephone number before they can sign in, otherwise false.
    
        
        .. code-block:: csharp
    
            public bool RequireConfirmedPhoneNumber { get; set; }
    

