

SessionOptions Class
====================






Represents the session state options for the application.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Session

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.SessionOptions`








Syntax
------

.. code-block:: csharp

    public class SessionOptions








.. dn:class:: Microsoft.AspNetCore.Builder.SessionOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.SessionOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.SessionOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.SessionOptions.CookieDomain
    
        
    
        
        Determines the domain used to create the cookie. Is not provided by default.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string CookieDomain
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.SessionOptions.CookieHttpOnly
    
        
    
        
        Determines if the browser should allow the cookie to be accessed by client-side JavaScript. The
        default is true, which means the cookie will only be passed to HTTP requests and is not made available
        to script on the page.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool CookieHttpOnly
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.SessionOptions.CookieName
    
        
    
        
        Determines the cookie name used to persist the session ID.
        Defaults to :dn:field:`Microsoft.AspNetCore.Session.SessionDefaults.CookieName`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string CookieName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.SessionOptions.CookiePath
    
        
    
        
        Determines the path used to create the cookie.
        Defaults to :dn:field:`Microsoft.AspNetCore.Session.SessionDefaults.CookiePath`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string CookiePath
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.SessionOptions.IdleTimeout
    
        
    
        
        The IdleTimeout indicates how long the session can be idle before its contents are abandoned. Each session access
        resets the timeout. Note this only applies to the content of the session, not the cookie.
    
        
        :rtype: System.TimeSpan
    
        
        .. code-block:: csharp
    
            public TimeSpan IdleTimeout
            {
                get;
                set;
            }
    

