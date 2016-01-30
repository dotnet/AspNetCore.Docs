

PrincipalExtensions Class
=========================



.. contents:: 
   :local:



Summary
-------

Claims related extensions for :any:`System.Security.Claims.ClaimsPrincipal`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Security.Claims.PrincipalExtensions`








Syntax
------

.. code-block:: csharp

   public class PrincipalExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity/PrincipalExtensions.cs>`_





.. dn:class:: System.Security.Claims.PrincipalExtensions

Methods
-------

.. dn:class:: System.Security.Claims.PrincipalExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: System.Security.Claims.PrincipalExtensions.FindFirstValue(System.Security.Claims.ClaimsPrincipal, System.String)
    
        
    
        Returns the value for the first claim of the specified type otherwise null the claim is not present.
    
        
        
        
        :param principal: The  instance this method extends.
        
        :type principal: System.Security.Claims.ClaimsPrincipal
        
        
        :param claimType: The claim type whose first value should be returned.
        
        :type claimType: System.String
        :rtype: System.String
        :return: The value of the first instance of the specified claim type, or null if the claim is not present.
    
        
        .. code-block:: csharp
    
           public static string FindFirstValue(ClaimsPrincipal principal, string claimType)
    
    .. dn:method:: System.Security.Claims.PrincipalExtensions.GetUserId(System.Security.Claims.ClaimsPrincipal)
    
        
    
        Returns the User ID claim value if present otherwise returns null.
    
        
        
        
        :param principal: The  instance this method extends.
        
        :type principal: System.Security.Claims.ClaimsPrincipal
        :rtype: System.String
        :return: The User ID claim value, or null if the claim is not present.
    
        
        .. code-block:: csharp
    
           public static string GetUserId(ClaimsPrincipal principal)
    
    .. dn:method:: System.Security.Claims.PrincipalExtensions.GetUserName(System.Security.Claims.ClaimsPrincipal)
    
        
    
        Returns the Name claim value if present otherwise returns null.
    
        
        
        
        :param principal: The  instance this method extends.
        
        :type principal: System.Security.Claims.ClaimsPrincipal
        :rtype: System.String
        :return: The Name claim value, or null if the claim is not present.
    
        
        .. code-block:: csharp
    
           public static string GetUserName(ClaimsPrincipal principal)
    
    .. dn:method:: System.Security.Claims.PrincipalExtensions.IsSignedIn(System.Security.Claims.ClaimsPrincipal)
    
        
    
        Returns true if the principal has an identity with the application cookie identity
    
        
        
        
        :param principal: The  instance this method extends.
        
        :type principal: System.Security.Claims.ClaimsPrincipal
        :rtype: System.Boolean
        :return: True if the user is logged in with identity.
    
        
        .. code-block:: csharp
    
           public static bool IsSignedIn(ClaimsPrincipal principal)
    

