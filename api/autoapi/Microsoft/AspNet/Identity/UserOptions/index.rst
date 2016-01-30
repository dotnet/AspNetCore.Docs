

UserOptions Class
=================



.. contents:: 
   :local:



Summary
-------

Options for user validation.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.UserOptions`








Syntax
------

.. code-block:: csharp

   public class UserOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity/UserOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.UserOptions

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.UserOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.UserOptions.AllowedUserNameCharacters
    
        
    
        Gets or sets the list of allowed characters in the username used to validate user names.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string AllowedUserNameCharacters { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.UserOptions.RequireUniqueEmail
    
        
    
        Gets or sets a flag indicating whether the application requires unique emails for its users.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool RequireUniqueEmail { get; set; }
    

