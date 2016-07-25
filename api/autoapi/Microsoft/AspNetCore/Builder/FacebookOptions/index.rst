

FacebookOptions Class
=====================






Configuration options for :any:`Microsoft.AspNetCore.Authentication.Facebook.FacebookMiddleware`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Authentication.Facebook

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.AuthenticationOptions`
* :dn:cls:`Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions`
* :dn:cls:`Microsoft.AspNetCore.Builder.OAuthOptions`
* :dn:cls:`Microsoft.AspNetCore.Builder.FacebookOptions`








Syntax
------

.. code-block:: csharp

    public class FacebookOptions : OAuthOptions








.. dn:class:: Microsoft.AspNetCore.Builder.FacebookOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.FacebookOptions

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Builder.FacebookOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Builder.FacebookOptions.FacebookOptions()
    
        
    
        
        Initializes a new :any:`Microsoft.AspNetCore.Builder.FacebookOptions`\.
    
        
    
        
        .. code-block:: csharp
    
            public FacebookOptions()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.FacebookOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.FacebookOptions.AppId
    
        
    
        
        Gets or sets the Facebook-assigned appId.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AppId { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.FacebookOptions.AppSecret
    
        
    
        
        Gets or sets the Facebook-assigned app secret.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AppSecret { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.FacebookOptions.Fields
    
        
    
        
        The list of fields to retrieve from the UserInformationEndpoint.
        https://developers.facebook.com/docs/graph-api/reference/user
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public ICollection<string> Fields { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.FacebookOptions.SendAppSecretProof
    
        
    
        
        Gets or sets if the appsecret_proof should be generated and sent with Facebook API calls.
        This is enabled by default.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool SendAppSecretProof { get; set; }
    

