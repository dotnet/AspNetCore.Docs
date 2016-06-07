

AuthenticationFailedContext Class
=================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.OpenIdConnect`
Assemblies
    * Microsoft.AspNetCore.Authentication.OpenIdConnect

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.BaseControlContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.OpenIdConnect.BaseOpenIdConnectContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthenticationFailedContext`








Syntax
------

.. code-block:: csharp

    public class AuthenticationFailedContext : BaseOpenIdConnectContext








.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthenticationFailedContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthenticationFailedContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthenticationFailedContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthenticationFailedContext.Exception
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
            public Exception Exception
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthenticationFailedContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthenticationFailedContext.AuthenticationFailedContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.OpenIdConnectOptions)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type options: Microsoft.AspNetCore.Builder.OpenIdConnectOptions
    
        
        .. code-block:: csharp
    
            public AuthenticationFailedContext(HttpContext context, OpenIdConnectOptions options)
    

