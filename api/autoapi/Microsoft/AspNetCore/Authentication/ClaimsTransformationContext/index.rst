

ClaimsTransformationContext Class
=================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.ClaimsTransformationContext`








Syntax
------

.. code-block:: csharp

    public class ClaimsTransformationContext








.. dn:class:: Microsoft.AspNetCore.Authentication.ClaimsTransformationContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.ClaimsTransformationContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.ClaimsTransformationContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.ClaimsTransformationContext.Context
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public HttpContext Context
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.ClaimsTransformationContext.Principal
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
            public ClaimsPrincipal Principal
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.ClaimsTransformationContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.ClaimsTransformationContext.ClaimsTransformationContext(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public ClaimsTransformationContext(HttpContext context)
    

