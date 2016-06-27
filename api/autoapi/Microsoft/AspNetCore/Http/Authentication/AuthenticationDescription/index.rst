

AuthenticationDescription Class
===============================






Contains information describing an authentication provider.


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
* :dn:cls:`Microsoft.AspNetCore.Http.Authentication.AuthenticationDescription`








Syntax
------

.. code-block:: csharp

    public class AuthenticationDescription








.. dn:class:: Microsoft.AspNetCore.Http.Authentication.AuthenticationDescription
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Authentication.AuthenticationDescription

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.Authentication.AuthenticationDescription
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Authentication.AuthenticationDescription.AuthenticationDescription()
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationDescription` class
    
        
    
        
        .. code-block:: csharp
    
            public AuthenticationDescription()
    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Authentication.AuthenticationDescription.AuthenticationDescription(System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationDescription` class
    
        
    
        
        :type items: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public AuthenticationDescription(IDictionary<string, object> items)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Authentication.AuthenticationDescription
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Authentication.AuthenticationDescription.AuthenticationScheme
    
        
    
        
        Gets or sets the name used to reference the authentication middleware instance.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AuthenticationScheme { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Authentication.AuthenticationDescription.DisplayName
    
        
    
        
        Gets or sets the display name for the authentication provider.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string DisplayName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Authentication.AuthenticationDescription.Items
    
        
    
        
        Contains metadata about the authentication provider.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, object> Items { get; }
    

