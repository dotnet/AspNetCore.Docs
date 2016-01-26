

AuthenticationDescription Class
===============================



.. contents:: 
   :local:



Summary
-------

Contains information describing an authentication provider.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.Authentication.AuthenticationDescription`








Syntax
------

.. code-block:: csharp

   public class AuthenticationDescription





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Abstractions/Authentication/AuthenticationDescription.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Authentication.AuthenticationDescription

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Authentication.AuthenticationDescription
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Authentication.AuthenticationDescription.AuthenticationDescription()
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Http.Authentication.AuthenticationDescription` class
    
        
    
        
        .. code-block:: csharp
    
           public AuthenticationDescription()
    
    .. dn:constructor:: Microsoft.AspNet.Http.Authentication.AuthenticationDescription.AuthenticationDescription(System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Http.Authentication.AuthenticationDescription` class
    
        
        
        
        :type items: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public AuthenticationDescription(IDictionary<string, object> items)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Authentication.AuthenticationDescription
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Authentication.AuthenticationDescription.AuthenticationScheme
    
        
    
        Gets or sets the name used to reference the authentication middleware instance.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string AuthenticationScheme { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Authentication.AuthenticationDescription.DisplayName
    
        
    
        Gets or sets the display name for the authentication provider.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string DisplayName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Authentication.AuthenticationDescription.Items
    
        
    
        Contains metadata about the authentication provider.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, object> Items { get; }
    

