

CookieOptions Class
===================



.. contents:: 
   :local:



Summary
-------

Options used to create a new cookie.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.CookieOptions`








Syntax
------

.. code-block:: csharp

   public class CookieOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Abstractions/CookieOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Http.CookieOptions

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.CookieOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.CookieOptions.CookieOptions()
    
        
    
        Creates a default cookie with a path of '/'.
    
        
    
        
        .. code-block:: csharp
    
           public CookieOptions()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.CookieOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.CookieOptions.Domain
    
        
    
        Gets or sets the domain to associate the cookie with.
    
        
        :rtype: System.String
        :return: The domain to associate the cookie with.
    
        
        .. code-block:: csharp
    
           public string Domain { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.CookieOptions.Expires
    
        
    
        Gets or sets the expiration date and time for the cookie.
    
        
        :rtype: System.Nullable{System.DateTime}
        :return: The expiration date and time for the cookie.
    
        
        .. code-block:: csharp
    
           public DateTime? Expires { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.CookieOptions.HttpOnly
    
        
    
        Gets or sets a value that indicates whether a cookie is accessible by client-side script.
    
        
        :rtype: System.Boolean
        :return: true if a cookie is accessible by client-side script; otherwise, false.
    
        
        .. code-block:: csharp
    
           public bool HttpOnly { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.CookieOptions.Path
    
        
    
        Gets or sets the cookie path.
    
        
        :rtype: System.String
        :return: The cookie path.
    
        
        .. code-block:: csharp
    
           public string Path { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.CookieOptions.Secure
    
        
    
        Gets or sets a value that indicates whether to transmit the cookie using Secure Sockets Layer (SSL)ï¿½that is, over HTTPS only.
    
        
        :rtype: System.Boolean
        :return: true to transmit the cookie only over an SSL connection (HTTPS); otherwise, false.
    
        
        .. code-block:: csharp
    
           public bool Secure { get; set; }
    

