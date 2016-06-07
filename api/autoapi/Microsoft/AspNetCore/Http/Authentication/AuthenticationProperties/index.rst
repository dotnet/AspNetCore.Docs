

AuthenticationProperties Class
==============================






Dictionary used to store state values about the authentication session.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Authentication`
Assemblies
    * Microsoft.AspNetCore.Http.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties`








Syntax
------

.. code-block:: csharp

    public class AuthenticationProperties








.. dn:class:: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties.AllowRefresh
    
        
    
        
        Gets or sets if refreshing the authentication session should be allowed.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public bool ? AllowRefresh
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties.ExpiresUtc
    
        
    
        
        Gets or sets the time at which the authentication ticket expires.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.DateTimeOffset<System.DateTimeOffset>}
    
        
        .. code-block:: csharp
    
            public DateTimeOffset? ExpiresUtc
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties.IsPersistent
    
        
    
        
        Gets or sets whether the authentication session is persisted across multiple requests.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsPersistent
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties.IssuedUtc
    
        
    
        
        Gets or sets the time at which the authentication ticket was issued.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.DateTimeOffset<System.DateTimeOffset>}
    
        
        .. code-block:: csharp
    
            public DateTimeOffset? IssuedUtc
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties.Items
    
        
    
        
        State values about the authentication session.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, string> Items
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties.RedirectUri
    
        
    
        
        Gets or sets the full path or absolute URI to be used as an http redirect response value.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RedirectUri
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties.AuthenticationProperties()
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` class
    
        
    
        
        .. code-block:: csharp
    
            public AuthenticationProperties()
    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties.AuthenticationProperties(System.Collections.Generic.IDictionary<System.String, System.String>)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` class
    
        
    
        
        :type items: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public AuthenticationProperties(IDictionary<string, string> items)
    

