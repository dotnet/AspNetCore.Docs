

EmailTokenProvider<TUser> Class
===============================






TokenProvider that generates tokens from the user's security stamp and notifies a user via email.


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
* :dn:cls:`Microsoft.AspNetCore.Identity.TotpSecurityStampBasedTokenProvider{{TUser}}`
* :dn:cls:`Microsoft.AspNetCore.Identity.EmailTokenProvider\<TUser>`








Syntax
------

.. code-block:: csharp

    public class EmailTokenProvider<TUser> : TotpSecurityStampBasedTokenProvider<TUser>, IUserTwoFactorTokenProvider<TUser> where TUser : class








.. dn:class:: Microsoft.AspNetCore.Identity.EmailTokenProvider`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.EmailTokenProvider<TUser>

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.EmailTokenProvider<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.EmailTokenProvider<TUser>.CanGenerateTwoFactorTokenAsync(Microsoft.AspNetCore.Identity.UserManager<TUser>, TUser)
    
        
    
        
        Checks if a two factor authentication token can be generated for the specified <em>user</em>.
    
        
    
        
        :param manager: The :any:`Microsoft.AspNetCore.Identity.UserManager\`1` to retrieve the <em>user</em> from.
        
        :type manager: Microsoft.AspNetCore.Identity.UserManager<Microsoft.AspNetCore.Identity.UserManager`1>{TUser}
    
        
        :param user: The <em>TUser</em> to check for the possibility of generating a two factor authentication token.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: True if the user has an email address set, otherwise false.
    
        
        .. code-block:: csharp
    
            public override Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<TUser> manager, TUser user)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EmailTokenProvider<TUser>.GetUserModifierAsync(System.String, Microsoft.AspNetCore.Identity.UserManager<TUser>, TUser)
    
        
    
        
        Returns the a value for the user used as entropy in the generated token.
    
        
    
        
        :param purpose: The purpose of the two factor authentication token.
        
        :type purpose: System.String
    
        
        :param manager: The :any:`Microsoft.AspNetCore.Identity.UserManager\`1` to retrieve the <em>user</em> from.
        
        :type manager: Microsoft.AspNetCore.Identity.UserManager<Microsoft.AspNetCore.Identity.UserManager`1>{TUser}
    
        
        :param user: The <em>TUser</em> to check for the possibility of generating a two factor authentication token.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: A string suitable for use as entropy in token generation.
    
        
        .. code-block:: csharp
    
            public override Task<string> GetUserModifierAsync(string purpose, UserManager<TUser> manager, TUser user)
    

