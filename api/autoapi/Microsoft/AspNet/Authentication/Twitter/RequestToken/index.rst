

RequestToken Class
==================



.. contents:: 
   :local:



Summary
-------

The Twitter request token obtained from the request token endpoint.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.Twitter.RequestToken`








Syntax
------

.. code-block:: csharp

   public class RequestToken





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.Twitter/Messages/RequestToken.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.Twitter.RequestToken

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.Twitter.RequestToken
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.Twitter.RequestToken.CallbackConfirmed
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool CallbackConfirmed { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Twitter.RequestToken.Properties
    
        
    
        Gets or sets a property bag for common authentication properties.
    
        
        :rtype: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
           public AuthenticationProperties Properties { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Twitter.RequestToken.Token
    
        
    
        Gets or sets the Twitter request token.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Token { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Twitter.RequestToken.TokenSecret
    
        
    
        Gets or sets the Twitter token secret.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string TokenSecret { get; set; }
    

