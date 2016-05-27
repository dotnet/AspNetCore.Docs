

TwitterOptions Class
====================






Options for the Twitter authentication middleware.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Authentication.Twitter

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.AuthenticationOptions`
* :dn:cls:`Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions`
* :dn:cls:`Microsoft.AspNetCore.Builder.TwitterOptions`








Syntax
------

.. code-block:: csharp

    public class TwitterOptions : RemoteAuthenticationOptions








.. dn:class:: Microsoft.AspNetCore.Builder.TwitterOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.TwitterOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.TwitterOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.TwitterOptions.ConsumerKey
    
        
    
        
        Gets or sets the consumer key used to communicate with Twitter.
    
        
        :rtype: System.String
        :return: The consumer key used to communicate with Twitter.
    
        
        .. code-block:: csharp
    
            public string ConsumerKey
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.TwitterOptions.ConsumerSecret
    
        
    
        
        Gets or sets the consumer secret used to sign requests to Twitter.
    
        
        :rtype: System.String
        :return: The consumer secret used to sign requests to Twitter.
    
        
        .. code-block:: csharp
    
            public string ConsumerSecret
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.TwitterOptions.Events
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Authentication.Twitter.ITwitterEvents` used to handle authentication events.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.Twitter.ITwitterEvents
    
        
        .. code-block:: csharp
    
            public ITwitterEvents Events
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.TwitterOptions.StateDataFormat
    
        
    
        
        Gets or sets the type used to secure data handled by the middleware.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.ISecureDataFormat<Microsoft.AspNetCore.Authentication.ISecureDataFormat`1>{Microsoft.AspNetCore.Authentication.Twitter.RequestToken<Microsoft.AspNetCore.Authentication.Twitter.RequestToken>}
    
        
        .. code-block:: csharp
    
            public ISecureDataFormat<RequestToken> StateDataFormat
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.TwitterOptions.SystemClock
    
        
    
        
        For testing purposes only.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.ISystemClock
    
        
        .. code-block:: csharp
    
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ISystemClock SystemClock
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Builder.TwitterOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Builder.TwitterOptions.TwitterOptions()
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Builder.TwitterOptions` class.
    
        
    
        
        .. code-block:: csharp
    
            public TwitterOptions()
    

