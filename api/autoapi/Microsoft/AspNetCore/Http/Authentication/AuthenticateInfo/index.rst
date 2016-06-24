

AuthenticateInfo Class
======================






Used to store the results of an Authenticate call.


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
* :dn:cls:`Microsoft.AspNetCore.Http.Authentication.AuthenticateInfo`








Syntax
------

.. code-block:: csharp

    public class AuthenticateInfo








.. dn:class:: Microsoft.AspNetCore.Http.Authentication.AuthenticateInfo
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Authentication.AuthenticateInfo

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Authentication.AuthenticateInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Authentication.AuthenticateInfo.Description
    
        
    
        
        The :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationDescription`\.
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationDescription
    
        
        .. code-block:: csharp
    
            public AuthenticationDescription Description { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Authentication.AuthenticateInfo.Principal
    
        
    
        
        The :any:`System.Security.Claims.ClaimsPrincipal`\.
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
            public ClaimsPrincipal Principal { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Authentication.AuthenticateInfo.Properties
    
        
    
        
        The :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties`\.
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public AuthenticationProperties Properties { get; set; }
    

