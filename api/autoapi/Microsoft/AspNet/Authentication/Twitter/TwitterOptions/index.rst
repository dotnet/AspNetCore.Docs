

TwitterOptions Class
====================



.. contents:: 
   :local:



Summary
-------

Options for the Twitter authentication middleware.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.AuthenticationOptions`
* :dn:cls:`Microsoft.AspNet.Authentication.RemoteAuthenticationOptions`
* :dn:cls:`Microsoft.AspNet.Authentication.Twitter.TwitterOptions`








Syntax
------

.. code-block:: csharp

   public class TwitterOptions : RemoteAuthenticationOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.Twitter/TwitterOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.Twitter.TwitterOptions

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.Twitter.TwitterOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.Twitter.TwitterOptions.TwitterOptions()
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Authentication.Twitter.TwitterOptions` class.
    
        
    
        
        .. code-block:: csharp
    
           public TwitterOptions()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.Twitter.TwitterOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.Twitter.TwitterOptions.ConsumerKey
    
        
    
        Gets or sets the consumer key used to communicate with Twitter.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ConsumerKey { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Twitter.TwitterOptions.ConsumerSecret
    
        
    
        Gets or sets the consumer secret used to sign requests to Twitter.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ConsumerSecret { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Twitter.TwitterOptions.Events
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Authentication.Twitter.ITwitterEvents` used to handle authentication events.
    
        
        :rtype: Microsoft.AspNet.Authentication.Twitter.ITwitterEvents
    
        
        .. code-block:: csharp
    
           public ITwitterEvents Events { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Twitter.TwitterOptions.SaveTokensAsClaims
    
        
    
        Defines whether access tokens should be stored in the 
        ClaimsPrincipal after a successful authentication.
        This property is set to <c>false</c> by default to reduce
        the size of the final authentication cookie.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool SaveTokensAsClaims { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Twitter.TwitterOptions.StateDataFormat
    
        
    
        Gets or sets the type used to secure data handled by the middleware.
    
        
        :rtype: Microsoft.AspNet.Authentication.ISecureDataFormat{Microsoft.AspNet.Authentication.Twitter.RequestToken}
    
        
        .. code-block:: csharp
    
           public ISecureDataFormat<RequestToken> StateDataFormat { get; set; }
    

