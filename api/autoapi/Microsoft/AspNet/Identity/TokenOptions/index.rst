

TokenOptions Class
==================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.TokenOptions`








Syntax
------

.. code-block:: csharp

   public class TokenOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/TokenOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.TokenOptions

Fields
------

.. dn:class:: Microsoft.AspNet.Identity.TokenOptions
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Identity.TokenOptions.DefaultEmailProvider
    
        
    
        
        .. code-block:: csharp
    
           public static readonly string DefaultEmailProvider
    
    .. dn:field:: Microsoft.AspNet.Identity.TokenOptions.DefaultPhoneProvider
    
        
    
        
        .. code-block:: csharp
    
           public static readonly string DefaultPhoneProvider
    
    .. dn:field:: Microsoft.AspNet.Identity.TokenOptions.DefaultProvider
    
        
    
        
        .. code-block:: csharp
    
           public static readonly string DefaultProvider
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.TokenOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.TokenOptions.ChangeEmailTokenProvider
    
        
    
        Gets or sets the :dn:prop:`Microsoft.AspNet.Identity.TokenOptions.ChangeEmailTokenProvider` used to generate tokens used in email change confirmation emails.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ChangeEmailTokenProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.TokenOptions.EmailConfirmationTokenProvider
    
        
    
        Gets or sets the :dn:prop:`Microsoft.AspNet.Identity.TokenOptions.EmailConfirmationTokenProvider` used to generate tokens used in account confirmation emails.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string EmailConfirmationTokenProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.TokenOptions.PasswordResetTokenProvider
    
        
    
        Gets or sets the :dn:prop:`Microsoft.AspNet.Identity.TokenOptions.PasswordResetTokenProvider` used to generate tokens used in password reset emails.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string PasswordResetTokenProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.TokenOptions.ProviderMap
    
        
    
        Will be used to construct UserTokenProviders with the key used as the providerName.
    
        
        :rtype: System.Collections.Generic.Dictionary{System.String,Microsoft.AspNet.Identity.TokenProviderDescriptor}
    
        
        .. code-block:: csharp
    
           public Dictionary<string, TokenProviderDescriptor> ProviderMap { get; set; }
    

