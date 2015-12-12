

AuthenticationProperties Class
==============================



.. contents:: 
   :local:



Summary
-------

Dictionary used to store state values about the authentication session.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Authentication.AuthenticationProperties`








Syntax
------

.. code-block:: csharp

   public class AuthenticationProperties





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Abstractions/Authentication/AuthenticationProperties.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Authentication.AuthenticationProperties

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Authentication.AuthenticationProperties.AuthenticationProperties()
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Http.Authentication.AuthenticationProperties` class
    
        
    
        
        .. code-block:: csharp
    
           public AuthenticationProperties()
    
    .. dn:constructor:: Microsoft.AspNet.Http.Authentication.AuthenticationProperties.AuthenticationProperties(System.Collections.Generic.IDictionary<System.String, System.String>)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Http.Authentication.AuthenticationProperties` class
    
        
        
        
        :type items: System.Collections.Generic.IDictionary{System.String,System.String}
    
        
        .. code-block:: csharp
    
           public AuthenticationProperties(IDictionary<string, string> items)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Authentication.AuthenticationProperties.AllowRefresh
    
        
    
        Gets or sets if refreshing the authentication session should be allowed.
    
        
        :rtype: System.Nullable{System.Boolean}
    
        
        .. code-block:: csharp
    
           public bool ? AllowRefresh { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Authentication.AuthenticationProperties.ExpiresUtc
    
        
    
        Gets or sets the time at which the authentication ticket expires.
    
        
        :rtype: System.Nullable{System.DateTimeOffset}
    
        
        .. code-block:: csharp
    
           public DateTimeOffset? ExpiresUtc { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Authentication.AuthenticationProperties.IsPersistent
    
        
    
        Gets or sets whether the authentication session is persisted across multiple requests.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsPersistent { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Authentication.AuthenticationProperties.IssuedUtc
    
        
    
        Gets or sets the time at which the authentication ticket was issued.
    
        
        :rtype: System.Nullable{System.DateTimeOffset}
    
        
        .. code-block:: csharp
    
           public DateTimeOffset? IssuedUtc { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Authentication.AuthenticationProperties.Items
    
        
    
        State values about the authentication session.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.String}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, string> Items { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Authentication.AuthenticationProperties.RedirectUri
    
        
    
        Gets or sets the full path or absolute URI to be used as an http redirect response value.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RedirectUri { get; set; }
    

