

FacebookOptions Class
=====================



.. contents:: 
   :local:



Summary
-------

Configuration options for :any:`Microsoft.AspNet.Authentication.Facebook.FacebookMiddleware`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.AuthenticationOptions`
* :dn:cls:`Microsoft.AspNet.Authentication.RemoteAuthenticationOptions`
* :dn:cls:`Microsoft.AspNet.Authentication.OAuth.OAuthOptions`
* :dn:cls:`Microsoft.AspNet.Authentication.Facebook.FacebookOptions`








Syntax
------

.. code-block:: csharp

   public class FacebookOptions : OAuthOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.Facebook/FacebookOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.Facebook.FacebookOptions

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.Facebook.FacebookOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.Facebook.FacebookOptions.FacebookOptions()
    
        
    
        Initializes a new :any:`Microsoft.AspNet.Authentication.Facebook.FacebookOptions`\.
    
        
    
        
        .. code-block:: csharp
    
           public FacebookOptions()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.Facebook.FacebookOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.Facebook.FacebookOptions.AppId
    
        
    
        Gets or sets the Facebook-assigned appId.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string AppId { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Facebook.FacebookOptions.AppSecret
    
        
    
        Gets or sets the Facebook-assigned app secret.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string AppSecret { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Facebook.FacebookOptions.SendAppSecretProof
    
        
    
        Gets or sets if the appsecret_proof should be generated and sent with Facebook API calls.
        This is enabled by default.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool SendAppSecretProof { get; set; }
    

