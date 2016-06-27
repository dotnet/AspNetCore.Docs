

PrincipalExtensions Class
=========================






Claims related extensions for :any:`System.Security.Claims.ClaimsPrincipal`\.


Namespace
    :dn:ns:`System.Security.Claims`
Assemblies
    * Microsoft.AspNetCore.Identity

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Security.Claims.PrincipalExtensions`








Syntax
------

.. code-block:: csharp

    public class PrincipalExtensions








.. dn:class:: System.Security.Claims.PrincipalExtensions
    :hidden:

.. dn:class:: System.Security.Claims.PrincipalExtensions

Methods
-------

.. dn:class:: System.Security.Claims.PrincipalExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: System.Security.Claims.PrincipalExtensions.FindFirstValue(System.Security.Claims.ClaimsPrincipal, System.String)
    
        
    
        
        Returns the value for the first claim of the specified type otherwise null the claim is not present.
    
        
    
        
        :param principal: The :any:`System.Security.Claims.ClaimsPrincipal` instance this method extends.
        
        :type principal: System.Security.Claims.ClaimsPrincipal
    
        
        :param claimType: The claim type whose first value should be returned.
        
        :type claimType: System.String
        :rtype: System.String
        :return: The value of the first instance of the specified claim type, or null if the claim is not present.
    
        
        .. code-block:: csharp
    
            public static string FindFirstValue(this ClaimsPrincipal principal, string claimType)
    

