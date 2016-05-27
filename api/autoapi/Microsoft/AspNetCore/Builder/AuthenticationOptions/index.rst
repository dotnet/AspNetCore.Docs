

AuthenticationOptions Class
===========================






Base Options for all authentication middleware.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.AuthenticationOptions`








Syntax
------

.. code-block:: csharp

    public abstract class AuthenticationOptions








.. dn:class:: Microsoft.AspNetCore.Builder.AuthenticationOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.AuthenticationOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.AuthenticationOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.AuthenticationOptions.AuthenticationScheme
    
        
    
        
        The AuthenticationScheme in the options corresponds to the logical name for a particular authentication scheme. A different
        value may be assigned in order to use the same authentication middleware type more than once in a pipeline.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AuthenticationScheme
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.AuthenticationOptions.AutomaticAuthenticate
    
        
    
        
        If true the authentication middleware alter the request user coming in. If false the authentication middleware will only provide
        identity when explicitly indicated by the AuthenticationScheme.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool AutomaticAuthenticate
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.AuthenticationOptions.AutomaticChallenge
    
        
    
        
        If true the authentication middleware should handle automatic challenge.
        If false the authentication middleware will only alter responses when explicitly indicated by the AuthenticationScheme.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool AutomaticChallenge
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.AuthenticationOptions.ClaimsIssuer
    
        
    
        
        Gets or sets the issuer that should be used for any claims that are created
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ClaimsIssuer
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.AuthenticationOptions.Description
    
        
    
        
        Additional information about the authentication type which is made available to the application.
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationDescription
    
        
        .. code-block:: csharp
    
            public AuthenticationDescription Description
            {
                get;
                set;
            }
    

