

GoogleOptions Class
===================






Configuration options for :any:`Microsoft.AspNetCore.Authentication.Google.GoogleMiddleware`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Authentication.Google

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.AuthenticationOptions`
* :dn:cls:`Microsoft.AspNetCore.Builder.RemoteAuthenticationOptions`
* :dn:cls:`Microsoft.AspNetCore.Builder.OAuthOptions`
* :dn:cls:`Microsoft.AspNetCore.Builder.GoogleOptions`








Syntax
------

.. code-block:: csharp

    public class GoogleOptions : OAuthOptions








.. dn:class:: Microsoft.AspNetCore.Builder.GoogleOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.GoogleOptions

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Builder.GoogleOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Builder.GoogleOptions.GoogleOptions()
    
        
    
        
        Initializes a new :any:`Microsoft.AspNetCore.Builder.GoogleOptions`\.
    
        
    
        
        .. code-block:: csharp
    
            public GoogleOptions()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.GoogleOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.GoogleOptions.AccessType
    
        
    
        
        access_type. Set to 'offline' to request a refresh token.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AccessType { get; set; }
    

