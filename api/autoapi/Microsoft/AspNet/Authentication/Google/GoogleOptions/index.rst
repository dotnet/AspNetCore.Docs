

GoogleOptions Class
===================



.. contents:: 
   :local:



Summary
-------

Configuration options for :any:`Microsoft.AspNet.Authentication.Google.GoogleMiddleware`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.AuthenticationOptions`
* :dn:cls:`Microsoft.AspNet.Authentication.RemoteAuthenticationOptions`
* :dn:cls:`Microsoft.AspNet.Authentication.OAuth.OAuthOptions`
* :dn:cls:`Microsoft.AspNet.Authentication.Google.GoogleOptions`








Syntax
------

.. code-block:: csharp

   public class GoogleOptions : OAuthOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.Google/GoogleOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.Google.GoogleOptions

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.Google.GoogleOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.Google.GoogleOptions.GoogleOptions()
    
        
    
        Initializes a new :any:`Microsoft.AspNet.Authentication.Google.GoogleOptions`\.
    
        
    
        
        .. code-block:: csharp
    
           public GoogleOptions()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.Google.GoogleOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.Google.GoogleOptions.AccessType
    
        
    
        access_type. Set to 'offline' to request a refresh token.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string AccessType { get; set; }
    

