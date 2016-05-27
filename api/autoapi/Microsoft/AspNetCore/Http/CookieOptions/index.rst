

CookieOptions Class
===================






Options used to create a new cookie.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http`
Assemblies
    * Microsoft.AspNetCore.Http.Features

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.CookieOptions`








Syntax
------

.. code-block:: csharp

    public class CookieOptions








.. dn:class:: Microsoft.AspNetCore.Http.CookieOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.CookieOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.CookieOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.CookieOptions.Domain
    
        
    
        
        Gets or sets the domain to associate the cookie with.
    
        
        :rtype: System.String
        :return: The domain to associate the cookie with.
    
        
        .. code-block:: csharp
    
            public string Domain
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.CookieOptions.Expires
    
        
    
        
        Gets or sets the expiration date and time for the cookie.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.DateTimeOffset<System.DateTimeOffset>}
        :return: The expiration date and time for the cookie.
    
        
        .. code-block:: csharp
    
            public DateTimeOffset? Expires
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.CookieOptions.HttpOnly
    
        
    
        
        Gets or sets a value that indicates whether a cookie is accessible by client-side script.
    
        
        :rtype: System.Boolean
        :return: true if a cookie is accessible by client-side script; otherwise, false.
    
        
        .. code-block:: csharp
    
            public bool HttpOnly
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.CookieOptions.Path
    
        
    
        
        Gets or sets the cookie path.
    
        
        :rtype: System.String
        :return: The cookie path.
    
        
        .. code-block:: csharp
    
            public string Path
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.CookieOptions.Secure
    
        
    
        
        Gets or sets a value that indicates whether to transmit the cookie using Secure Sockets Layer (SSL)ï¿½that is, over HTTPS only.
    
        
        :rtype: System.Boolean
        :return: true to transmit the cookie only over an SSL connection (HTTPS); otherwise, false.
    
        
        .. code-block:: csharp
    
            public bool Secure
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.CookieOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.CookieOptions.CookieOptions()
    
        
    
        
        Creates a default cookie with a path of '/'.
    
        
    
        
        .. code-block:: csharp
    
            public CookieOptions()
    

