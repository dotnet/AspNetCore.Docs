

UserOptions Class
=================






Options for user validation.


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
* :dn:cls:`Microsoft.AspNetCore.Identity.UserOptions`








Syntax
------

.. code-block:: csharp

    public class UserOptions








.. dn:class:: Microsoft.AspNetCore.Identity.UserOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.UserOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.UserOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.UserOptions.AllowedUserNameCharacters
    
        
    
        
        Gets or sets the list of allowed characters in the username used to validate user names.
    
        
        :rtype: System.String
        :return: 
            The list of allowed characters in the username used to validate user names.
    
        
        .. code-block:: csharp
    
            public string AllowedUserNameCharacters { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.UserOptions.RequireUniqueEmail
    
        
    
        
        Gets or sets a flag indicating whether the application requires unique emails for its users.
    
        
        :rtype: System.Boolean
        :return: 
            True if the application requires each user to have their own, unique email, otherwise false.
    
        
        .. code-block:: csharp
    
            public bool RequireUniqueEmail { get; set; }
    

