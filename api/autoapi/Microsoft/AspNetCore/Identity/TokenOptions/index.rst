

TokenOptions Class
==================





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
* :dn:cls:`Microsoft.AspNetCore.Identity.TokenOptions`








Syntax
------

.. code-block:: csharp

    public class TokenOptions








.. dn:class:: Microsoft.AspNetCore.Identity.TokenOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.TokenOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.TokenOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.TokenOptions.ChangeEmailTokenProvider
    
        
    
        
        Gets or sets the :dn:prop:`Microsoft.AspNetCore.Identity.TokenOptions.ChangeEmailTokenProvider` used to generate tokens used in email change confirmation emails.
    
        
        :rtype: System.String
        :return: 
            The :dn:prop:`Microsoft.AspNetCore.Identity.TokenOptions.ChangeEmailTokenProvider` used to generate tokens used in email change confirmation emails.
    
        
        .. code-block:: csharp
    
            public string ChangeEmailTokenProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.TokenOptions.EmailConfirmationTokenProvider
    
        
    
        
        Gets or sets the :dn:prop:`Microsoft.AspNetCore.Identity.TokenOptions.EmailConfirmationTokenProvider` used to generate tokens used in account confirmation emails.
    
        
        :rtype: System.String
        :return: 
            The :dn:prop:`Microsoft.AspNetCore.Identity.TokenOptions.EmailConfirmationTokenProvider` used to generate tokens used in account confirmation emails.
    
        
        .. code-block:: csharp
    
            public string EmailConfirmationTokenProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.TokenOptions.PasswordResetTokenProvider
    
        
    
        
        Gets or sets the :dn:prop:`Microsoft.AspNetCore.Identity.TokenOptions.PasswordResetTokenProvider` used to generate tokens used in password reset emails.
    
        
        :rtype: System.String
        :return: 
            The :dn:prop:`Microsoft.AspNetCore.Identity.TokenOptions.PasswordResetTokenProvider` used to generate tokens used in password reset emails.
    
        
        .. code-block:: csharp
    
            public string PasswordResetTokenProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.TokenOptions.ProviderMap
    
        
    
        
        Will be used to construct UserTokenProviders with the key used as the providerName.
    
        
        :rtype: System.Collections.Generic.Dictionary<System.Collections.Generic.Dictionary`2>{System.String<System.String>, Microsoft.AspNetCore.Identity.TokenProviderDescriptor<Microsoft.AspNetCore.Identity.TokenProviderDescriptor>}
    
        
        .. code-block:: csharp
    
            public Dictionary<string, TokenProviderDescriptor> ProviderMap { get; set; }
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Identity.TokenOptions
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Identity.TokenOptions.DefaultEmailProvider
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string DefaultEmailProvider
    
    .. dn:field:: Microsoft.AspNetCore.Identity.TokenOptions.DefaultPhoneProvider
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string DefaultPhoneProvider
    
    .. dn:field:: Microsoft.AspNetCore.Identity.TokenOptions.DefaultProvider
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string DefaultProvider
    

