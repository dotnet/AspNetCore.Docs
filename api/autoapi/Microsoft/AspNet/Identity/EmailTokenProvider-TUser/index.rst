

EmailTokenProvider<TUser> Class
===============================



.. contents:: 
   :local:



Summary
-------

TokenProvider that generates tokens from the user's security stamp and notifies a user via email.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.TotpSecurityStampBasedTokenProvider{{TUser}}`
* :dn:cls:`Microsoft.AspNet.Identity.EmailTokenProvider\<TUser>`








Syntax
------

.. code-block:: csharp

   public class EmailTokenProvider<TUser> : TotpSecurityStampBasedTokenProvider<TUser>, IUserTokenProvider<TUser> where TUser : class





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity/EmailTokenProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.EmailTokenProvider<TUser>

Methods
-------

.. dn:class:: Microsoft.AspNet.Identity.EmailTokenProvider<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.EmailTokenProvider<TUser>.CanGenerateTwoFactorTokenAsync(Microsoft.AspNet.Identity.UserManager<TUser>, TUser)
    
        
    
        Checks if a two factor authentication token can be generated for the specified ``user``.
    
        
        
        
        :param manager: The  to retrieve the  from.
        
        :type manager: Microsoft.AspNet.Identity.UserManager{{TUser}}
        
        
        :param user: The  to check for the possibility of generating a two factor authentication token.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: True if the user has an email address set, otherwise false.
    
        
        .. code-block:: csharp
    
           public override Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<TUser> manager, TUser user)
    
    .. dn:method:: Microsoft.AspNet.Identity.EmailTokenProvider<TUser>.GetUserModifierAsync(System.String, Microsoft.AspNet.Identity.UserManager<TUser>, TUser)
    
        
    
        Returns the a value for the user used as entropy in the generated token.
    
        
        
        
        :param purpose: The purpose of the two factor authentication token.
        
        :type purpose: System.String
        
        
        :param manager: The  to retrieve the  from.
        
        :type manager: Microsoft.AspNet.Identity.UserManager{{TUser}}
        
        
        :param user: The  to check for the possibility of generating a two factor authentication token.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: A string suitable for use as entropy in token generation.
    
        
        .. code-block:: csharp
    
           public override Task<string> GetUserModifierAsync(string purpose, UserManager<TUser> manager, TUser user)
    

