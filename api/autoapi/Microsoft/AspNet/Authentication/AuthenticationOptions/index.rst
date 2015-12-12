

AuthenticationOptions Class
===========================



.. contents:: 
   :local:



Summary
-------

Base Options for all authentication middleware





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.AuthenticationOptions`








Syntax
------

.. code-block:: csharp

   public abstract class AuthenticationOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication/AuthenticationOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.AuthenticationOptions

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.AuthenticationOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticationOptions.AuthenticationScheme
    
        
    
        The AuthenticationScheme in the options corresponds to the logical name for a particular authentication scheme. A different
        value may be assigned in order to use the same authentication middleware type more than once in a pipeline.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string AuthenticationScheme { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticationOptions.AutomaticAuthenticate
    
        
    
        If true the authentication middleware alter the request user coming in. If false the authentication middleware will only provide
        identity when explicitly indicated by the AuthenticationScheme.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool AutomaticAuthenticate { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticationOptions.AutomaticChallenge
    
        
    
        If true the authentication middleware should handle automatic challenge.
        If false the authentication middleware will only alter responses when explicitly indicated by the AuthenticationScheme.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool AutomaticChallenge { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticationOptions.ClaimsIssuer
    
        
    
        Gets or sets the issuer that should be used for any claims that are created
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ClaimsIssuer { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticationOptions.Description
    
        
    
        Additional information about the authentication type which is made available to the application.
    
        
        :rtype: Microsoft.AspNet.Http.Authentication.AuthenticationDescription
    
        
        .. code-block:: csharp
    
           public AuthenticationDescription Description { get; set; }
    

