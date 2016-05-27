

IClaimUidExtractor Interface
============================






This interface can extract unique identifers for a :any:`System.Security.Claims.ClaimsPrincipal`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Antiforgery.Internal`
Assemblies
    * Microsoft.AspNetCore.Antiforgery

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IClaimUidExtractor








.. dn:interface:: Microsoft.AspNetCore.Antiforgery.Internal.IClaimUidExtractor
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Antiforgery.Internal.IClaimUidExtractor

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Antiforgery.Internal.IClaimUidExtractor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.IClaimUidExtractor.ExtractClaimUid(System.Security.Claims.ClaimsPrincipal)
    
        
    
        
        Extracts claims identifier.
    
        
    
        
        :param claimsPrincipal: The :any:`System.Security.Claims.ClaimsPrincipal`\.
        
        :type claimsPrincipal: System.Security.Claims.ClaimsPrincipal
        :rtype: System.String
        :return: The claims identifier.
    
        
        .. code-block:: csharp
    
            string ExtractClaimUid(ClaimsPrincipal claimsPrincipal)
    

